<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="WindowsAzurePHP" generation="1" functional="0" release="0" Id="56757100-7544-4974-9f4b-310b08a021a2" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="WindowsAzurePHPGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="PHPApp:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/WindowsAzurePHP/WindowsAzurePHPGroup/LB:PHPApp:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="PHPApp:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/WindowsAzurePHP/WindowsAzurePHPGroup/MapPHPApp:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="PHPAppInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/WindowsAzurePHP/WindowsAzurePHPGroup/MapPHPAppInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:PHPApp:Endpoint1">
          <toPorts>
            <inPortMoniker name="/WindowsAzurePHP/WindowsAzurePHPGroup/PHPApp/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapPHPApp:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/WindowsAzurePHP/WindowsAzurePHPGroup/PHPApp/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapPHPAppInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/WindowsAzurePHP/WindowsAzurePHPGroup/PHPAppInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="PHPApp" generation="1" functional="0" release="0" software="D:\Outros\Desenvolvimento\Windows Azure\PHP\DeployWindowsAzurePHP\WindowsAzurePHP\WindowsAzurePHP\csx\Release\roles\PHPApp" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="1792" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;PHPApp&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;PHPApp&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/WindowsAzurePHP/WindowsAzurePHPGroup/PHPAppInstances" />
            <sCSPolicyFaultDomainMoniker name="/WindowsAzurePHP/WindowsAzurePHPGroup/PHPAppFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyFaultDomain name="PHPAppFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="PHPAppInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="3f98f803-1956-475e-be7c-df9980e7582f" ref="Microsoft.RedDog.Contract\ServiceContract\WindowsAzurePHPContract@ServiceDefinition.build">
      <interfacereferences>
        <interfaceReference Id="84fd9787-148f-4ceb-bf9e-958c18fd286e" ref="Microsoft.RedDog.Contract\Interface\PHPApp:Endpoint1@ServiceDefinition.build">
          <inPort>
            <inPortMoniker name="/WindowsAzurePHP/WindowsAzurePHPGroup/PHPApp:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>