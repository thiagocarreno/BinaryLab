<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="WindowsAzure" generation="1" functional="0" release="0" Id="a05ee678-8b85-44f5-9bf4-4fe014ed0b92" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="WindowsAzureGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="DjangoApplication:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/WindowsAzure/WindowsAzureGroup/LB:DjangoApplication:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="DjangoApplication:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/WindowsAzure/WindowsAzureGroup/MapDjangoApplication:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="DjangoApplicationInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/WindowsAzure/WindowsAzureGroup/MapDjangoApplicationInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:DjangoApplication:Endpoint1">
          <toPorts>
            <inPortMoniker name="/WindowsAzure/WindowsAzureGroup/DjangoApplication/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapDjangoApplication:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/WindowsAzure/WindowsAzureGroup/DjangoApplication/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapDjangoApplicationInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/WindowsAzure/WindowsAzureGroup/DjangoApplicationInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="DjangoApplication" generation="1" functional="0" release="0" software="D:\Outros\Thiago\Testes\Python\DjangoApplication\WindowsAzure\csx\Debug\roles\DjangoApplication" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="1792" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;DjangoApplication&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;DjangoApplication&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/WindowsAzure/WindowsAzureGroup/DjangoApplicationInstances" />
            <sCSPolicyFaultDomainMoniker name="/WindowsAzure/WindowsAzureGroup/DjangoApplicationFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyFaultDomain name="DjangoApplicationFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="DjangoApplicationInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="2a7a19bd-e8b2-4f3d-8fe8-27863d559a97" ref="Microsoft.RedDog.Contract\ServiceContract\WindowsAzureContract@ServiceDefinition.build">
      <interfacereferences>
        <interfaceReference Id="255c5eed-b6f5-4a4f-921a-92c182d1e4fe" ref="Microsoft.RedDog.Contract\Interface\DjangoApplication:Endpoint1@ServiceDefinition.build">
          <inPort>
            <inPortMoniker name="/WindowsAzure/WindowsAzureGroup/DjangoApplication:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>