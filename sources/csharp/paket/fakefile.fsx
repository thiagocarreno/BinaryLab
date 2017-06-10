#r @"packages\build\FAKE\tools\FakeLib.dll"

open Fake
open Fake.AssemblyInfoFile
open Fake.SonarQubeHelper
open Fake.ProcessHelper
open Fake.NuGetHelper
open Fake.Testing
open Fake.OpenCoverHelper

Log "fake started..."

let artifactsDir = "./artifacts"
let buildDir = artifactsDir + "/build/"
let testDir = artifactsDir + "/tests/"
let deployDir = artifactsDir + "/deploy/"

let version = "0.1.1"

Target "Clean" (fun _ ->
    killMSBuild()
    CleanDirs [buildDir; testDir; deployDir]
)

Target "SetVersions" (fun _ ->
    CreateCSharpAssemblyInfo "./source/App/App.Core/Properties/AssemblyInfo.cs"
        [Attribute.Title "App"
         Attribute.Description "App"
         Attribute.Product "App"
         Attribute.Guid "a15a723f-7c82-4e40-b7ec-c5003a5310d5"
         Attribute.Version version
         Attribute.FileVersion version]
)

Target "BuildApp" (fun _ ->
    !! @"source\App\App.Core\*.csproj"
      |> MSBuildRelease buildDir "Build"
      |> Log "AppBuild-Output: "
)

Target "BuildTest" (fun _ ->
    !! @"source\App\App.Test\*.csproj"
      |> MSBuildRelease testDir "Build"
      |> Log "AppBuild-Output: "
)

Target "Zip" (fun _ ->
    !! (buildDir + "\**\*.*")
        -- "*.zip"
        |> Zip buildDir (deployDir + "App.Core." + version + ".zip")
)

Target "BeginSonarQube" (fun _ ->
    SonarQube Begin (fun p ->
        {p with
            Key = "App"
            Name = "App"
            Version = version }
        )
)

Target "EndSonarQube" (fun _ ->
    SonarQube End (fun p ->
        {p with
            Key = "App"
            Name = "App"
            Version = version }
        )
)

Target "xUnitTest" (fun _ ->
    !! (testDir + @"\App.Test.dll")
        |> xUnit2 (fun p ->
            {p with
                ShadowCopy = false;
                HtmlOutputPath = Some (testDir @@ "app.html"); })
)

"Clean"
  ==> "SetVersions"
  ==> "BeginSonarQube"
  ==> "BuildApp"
  ==> "EndSonarQube"
  ==> "BuildTest"
  ==> "xUnitTest"
  ==> "Zip"
  
RunTargetOrDefault "Zip"