<?xml version="1.0" encoding="utf-8"?>
<configurationSectionModel xmlns:dm0="http://schemas.microsoft.com/VisualStudio/2008/DslTools/Core" dslVersion="1.0.0.0" Id="d0ed9acb-0435-4532-afdd-b5115bc4d562" namespace="ConsoleApplication1" xmlSchemaNamespace="ConsoleApplication1" xmlns="http://schemas.microsoft.com/dsltools/ConfigurationSectionDesigner">
  <typeDefinitions>
    <externalType name="String" namespace="System" />
    <externalType name="Boolean" namespace="System" />
    <externalType name="Int32" namespace="System" />
    <externalType name="Int64" namespace="System" />
    <externalType name="Single" namespace="System" />
    <externalType name="Double" namespace="System" />
    <externalType name="DateTime" namespace="System" />
    <externalType name="TimeSpan" namespace="System" />
  </typeDefinitions>
  <configurationElements>
    <configurationSection name="ReportsSection" codeGenOptions="Singleton, XmlnsProperty" xmlSectionName="reportsSection">
      <attributeProperties>
        <attributeProperty name="Name" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="name" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
      <elementProperties>
        <elementProperty name="Reports" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="reports" isReadOnly="false">
          <type>
            <configurationElementCollectionMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/Reports" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationSection>
    <configurationElementCollection name="Reports" xmlItemName="report" codeGenOptions="Indexer, AddMethod, RemoveMethod, GetItemMethods">
      <itemType>
        <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/Report" />
      </itemType>
    </configurationElementCollection>
    <configurationElement name="Report">
      <attributeProperties>
        <attributeProperty name="Name" isRequired="true" isKey="true" isDefaultCollection="false" xmlName="name" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="XlsxTemplate" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="xlsxTemplate" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="EmailTemplate" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="emailTemplate" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="EmailSubject" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="emailSubject" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="SendTo" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="sendTo" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="Enabled" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="enabled" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/Boolean" />
          </type>
        </attributeProperty>
      </attributeProperties>
      <elementProperties>
        <elementProperty name="Sheets" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="sheets" isReadOnly="false">
          <type>
            <configurationElementCollectionMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/Sheets" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationElement>
    <configurationElementCollection name="Sheets" xmlItemName="sheet" codeGenOptions="Indexer, AddMethod, RemoveMethod, GetItemMethods">
      <itemType>
        <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/Sheet" />
      </itemType>
    </configurationElementCollection>
    <configurationElement name="Sheet">
      <attributeProperties>
        <attributeProperty name="Name" isRequired="true" isKey="true" isDefaultCollection="false" xmlName="name" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
  </configurationElements>
  <propertyValidators>
    <validators />
  </propertyValidators>
</configurationSectionModel>