<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="DjangoApplication.Azure" generation="1" functional="0" release="0" Id="e2efa18d-d67c-4bbb-9620-d4a92760a950" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="DjangoApplication.AzureGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="DjangoApplication:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/DjangoApplication.Azure/DjangoApplication.AzureGroup/LB:DjangoApplication:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="DjangoApplication:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/DjangoApplication.Azure/DjangoApplication.AzureGroup/MapDjangoApplication:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="DjangoApplicationInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/DjangoApplication.Azure/DjangoApplication.AzureGroup/MapDjangoApplicationInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:DjangoApplication:Endpoint1">
          <toPorts>
            <inPortMoniker name="/DjangoApplication.Azure/DjangoApplication.AzureGroup/DjangoApplication/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapDjangoApplication:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/DjangoApplication.Azure/DjangoApplication.AzureGroup/DjangoApplication/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapDjangoApplicationInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/DjangoApplication.Azure/DjangoApplication.AzureGroup/DjangoApplicationInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="DjangoApplication" generation="1" functional="0" release="0" software="D:\Outros\Thiago\Testes\Python\DjangoApplication\DjangoApplication.Azure\csx\Release\roles\DjangoApplication" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="1792" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
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
            <sCSPolicyIDMoniker name="/DjangoApplication.Azure/DjangoApplication.AzureGroup/DjangoApplicationInstances" />
            <sCSPolicyFaultDomainMoniker name="/DjangoApplication.Azure/DjangoApplication.AzureGroup/DjangoApplicationFaultDomains" />
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
    <implementation Id="765ae715-8d24-48aa-aaee-305524515422" ref="Microsoft.RedDog.Contract\ServiceContract\DjangoApplication.AzureContract@ServiceDefinition.build">
      <interfacereferences>
        <interfaceReference Id="fca9f1b2-deea-45eb-ac5d-f8be107d3ee0" ref="Microsoft.RedDog.Contract\Interface\DjangoApplication:Endpoint1@ServiceDefinition.build">
          <inPort>
            <inPortMoniker name="/DjangoApplication.Azure/DjangoApplication.AzureGroup/DjangoApplication:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>