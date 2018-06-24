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
    <configurationSection name="Section" namespace="ConsoleApplication1" codeGenOptions="Singleton, XmlnsProperty" xmlSectionName="section">
      <elementProperties>
        <elementProperty name="Collection01" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="collection01" isReadOnly="false">
          <type>
            <configurationElementCollectionMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/Collection01" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationSection>
    <configurationElementCollection name="Collection01" namespace="ConsoleApplication1" xmlItemName="ConsoleApplication1" codeGenOptions="Indexer, AddMethod, RemoveMethod, GetItemMethods">
      <elementProperties>
        <elementProperty name="Element" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="element" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/Element01" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationElementCollection>
    <configurationElement name="Element01">
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