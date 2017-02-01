using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    
    
    /// <summary>
    /// The ReportsSection Configuration Section.
    /// </summary>
    public partial class ReportsSection : global::System.Configuration.ConfigurationSection
    {
        
        #region Singleton Instance
        /// <summary>
        /// The XML name of the ReportsSection Configuration Section.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        internal const string ReportsSectionSectionName = "reportsSection";
        
        /// <summary>
        /// The XML path of the ReportsSection Configuration Section.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        internal const string ReportsSectionSectionPath = "reportsSection";
        
        /// <summary>
        /// Gets the ReportsSection instance.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        public static global::ConsoleApplication1.ReportsSection Instance
        {
            get
            {
                return ((global::ConsoleApplication1.ReportsSection)(global::System.Configuration.ConfigurationManager.GetSection(global::ConsoleApplication1.ReportsSection.ReportsSectionSectionPath)));
            }
        }
        #endregion
        
        #region Xmlns Property
        /// <summary>
        /// The XML name of the <see cref="Xmlns"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        internal const string XmlnsPropertyName = "xmlns";
        
        /// <summary>
        /// Gets the XML namespace of this Configuration Section.
        /// </summary>
        /// <remarks>
        /// This property makes sure that if the configuration file contains the XML namespace,
        /// the parser doesn't throw an exception because it encounters the unknown "xmlns" attribute.
        /// </remarks>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::ConsoleApplication1.ReportsSection.XmlnsPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public string Xmlns
        {
            get
            {
                return ((string)(base[global::ConsoleApplication1.ReportsSection.XmlnsPropertyName]));
            }
        }
        #endregion
        
        #region IsReadOnly override
        /// <summary>
        /// Gets a value indicating whether the element is read-only.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion
        
        #region Name Property
        /// <summary>
        /// The XML name of the <see cref="Name"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        internal const string NamePropertyName = "name";
        
        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        [global::System.ComponentModel.DescriptionAttribute("The Name.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::ConsoleApplication1.ReportsSection.NamePropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public virtual string Name
        {
            get
            {
                return ((string)(base[global::ConsoleApplication1.ReportsSection.NamePropertyName]));
            }
            set
            {
                base[global::ConsoleApplication1.ReportsSection.NamePropertyName] = value;
            }
        }
        #endregion
        
        #region Reports Property
        /// <summary>
        /// The XML name of the <see cref="Reports"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        internal const string ReportsPropertyName = "reports";
        
        /// <summary>
        /// Gets or sets the Reports.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        [global::System.ComponentModel.DescriptionAttribute("The Reports.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::ConsoleApplication1.ReportsSection.ReportsPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public virtual global::ConsoleApplication1.Reports Reports
        {
            get
            {
                return ((global::ConsoleApplication1.Reports)(base[global::ConsoleApplication1.ReportsSection.ReportsPropertyName]));
            }
            set
            {
                base[global::ConsoleApplication1.ReportsSection.ReportsPropertyName] = value;
            }
        }
        #endregion
    }
}
namespace ConsoleApplication1
{
    
    
    /// <summary>
    /// A collection of Report instances.
    /// </summary>
    [global::System.Configuration.ConfigurationCollectionAttribute(typeof(global::ConsoleApplication1.Report), CollectionType=global::System.Configuration.ConfigurationElementCollectionType.BasicMapAlternate, AddItemName=global::ConsoleApplication1.Reports.ReportPropertyName)]
    public partial class Reports : global::System.Configuration.ConfigurationElementCollection
    {
        
        #region Constants
        /// <summary>
        /// The XML name of the individual <see cref="global::ConsoleApplication1.Report"/> instances in this collection.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        internal const string ReportPropertyName = "report";
        #endregion
        
        #region Overrides
        /// <summary>
        /// Gets the type of the <see cref="global::System.Configuration.ConfigurationElementCollection"/>.
        /// </summary>
        /// <returns>The <see cref="global::System.Configuration.ConfigurationElementCollectionType"/> of this collection.</returns>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        public override global::System.Configuration.ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return global::System.Configuration.ConfigurationElementCollectionType.BasicMapAlternate;
            }
        }
        
        /// <summary>
        /// Gets the name used to identify this collection of elements
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        protected override string ElementName
        {
            get
            {
                return global::ConsoleApplication1.Reports.ReportPropertyName;
            }
        }
        
        /// <summary>
        /// Indicates whether the specified <see cref="global::System.Configuration.ConfigurationElement"/> exists in the <see cref="global::System.Configuration.ConfigurationElementCollection"/>.
        /// </summary>
        /// <param name="elementName">The name of the element to verify.</param>
        /// <returns>
        /// <see langword="true"/> if the element exists in the collection; otherwise, <see langword="false"/>.
        /// </returns>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        protected override bool IsElementName(string elementName)
        {
            return (elementName == global::ConsoleApplication1.Reports.ReportPropertyName);
        }
        
        /// <summary>
        /// Gets the element key for the specified configuration element.
        /// </summary>
        /// <param name="element">The <see cref="global::System.Configuration.ConfigurationElement"/> to return the key for.</param>
        /// <returns>
        /// An <see cref="object"/> that acts as the key for the specified <see cref="global::System.Configuration.ConfigurationElement"/>.
        /// </returns>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        protected override object GetElementKey(global::System.Configuration.ConfigurationElement element)
        {
            return ((global::ConsoleApplication1.Report)(element)).Name;
        }
        
        /// <summary>
        /// Creates a new <see cref="global::ConsoleApplication1.Report"/>.
        /// </summary>
        /// <returns>
        /// A new <see cref="global::ConsoleApplication1.Report"/>.
        /// </returns>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        protected override global::System.Configuration.ConfigurationElement CreateNewElement()
        {
            return new global::ConsoleApplication1.Report();
        }
        #endregion
        
        #region Indexer
        /// <summary>
        /// Gets the <see cref="global::ConsoleApplication1.Report"/> at the specified index.
        /// </summary>
        /// <param name="index">The index of the <see cref="global::ConsoleApplication1.Report"/> to retrieve.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        public global::ConsoleApplication1.Report this[int index]
        {
            get
            {
                return ((global::ConsoleApplication1.Report)(base.BaseGet(index)));
            }
        }
        
        /// <summary>
        /// Gets the <see cref="global::ConsoleApplication1.Report"/> with the specified key.
        /// </summary>
        /// <param name="name">The key of the <see cref="global::ConsoleApplication1.Report"/> to retrieve.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        public global::ConsoleApplication1.Report this[object name]
        {
            get
            {
                return ((global::ConsoleApplication1.Report)(base.BaseGet(name)));
            }
        }
        #endregion
        
        #region Add
        /// <summary>
        /// Adds the specified <see cref="global::ConsoleApplication1.Report"/> to the <see cref="global::System.Configuration.ConfigurationElementCollection"/>.
        /// </summary>
        /// <param name="report">The <see cref="global::ConsoleApplication1.Report"/> to add.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        public void Add(global::ConsoleApplication1.Report report)
        {
            base.BaseAdd(report);
        }
        #endregion
        
        #region Remove
        /// <summary>
        /// Removes the specified <see cref="global::ConsoleApplication1.Report"/> from the <see cref="global::System.Configuration.ConfigurationElementCollection"/>.
        /// </summary>
        /// <param name="report">The <see cref="global::ConsoleApplication1.Report"/> to remove.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        public void Remove(global::ConsoleApplication1.Report report)
        {
            base.BaseRemove(this.GetElementKey(report));
        }
        #endregion
        
        #region GetItem
        /// <summary>
        /// Gets the <see cref="global::ConsoleApplication1.Report"/> at the specified index.
        /// </summary>
        /// <param name="index">The index of the <see cref="global::ConsoleApplication1.Report"/> to retrieve.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        public global::ConsoleApplication1.Report GetItemAt(int index)
        {
            return ((global::ConsoleApplication1.Report)(base.BaseGet(index)));
        }
        
        /// <summary>
        /// Gets the <see cref="global::ConsoleApplication1.Report"/> with the specified key.
        /// </summary>
        /// <param name="name">The key of the <see cref="global::ConsoleApplication1.Report"/> to retrieve.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        public global::ConsoleApplication1.Report GetItemByKey(string name)
        {
            return ((global::ConsoleApplication1.Report)(base.BaseGet(((object)(name)))));
        }
        #endregion
        
        #region IsReadOnly override
        /// <summary>
        /// Gets a value indicating whether the element is read-only.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion
    }
}
namespace ConsoleApplication1
{
    
    
    /// <summary>
    /// The Report Configuration Element.
    /// </summary>
    public partial class Report : global::System.Configuration.ConfigurationElement
    {
        
        #region IsReadOnly override
        /// <summary>
        /// Gets a value indicating whether the element is read-only.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion
        
        #region Name Property
        /// <summary>
        /// The XML name of the <see cref="Name"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        internal const string NamePropertyName = "name";
        
        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        [global::System.ComponentModel.DescriptionAttribute("The Name.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::ConsoleApplication1.Report.NamePropertyName, IsRequired=true, IsKey=true, IsDefaultCollection=false)]
        public virtual string Name
        {
            get
            {
                return ((string)(base[global::ConsoleApplication1.Report.NamePropertyName]));
            }
            set
            {
                base[global::ConsoleApplication1.Report.NamePropertyName] = value;
            }
        }
        #endregion
        
        #region Sheets Property
        /// <summary>
        /// The XML name of the <see cref="Sheets"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        internal const string SheetsPropertyName = "sheets";
        
        /// <summary>
        /// Gets or sets the Sheets.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        [global::System.ComponentModel.DescriptionAttribute("The Sheets.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::ConsoleApplication1.Report.SheetsPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public virtual global::ConsoleApplication1.Sheets Sheets
        {
            get
            {
                return ((global::ConsoleApplication1.Sheets)(base[global::ConsoleApplication1.Report.SheetsPropertyName]));
            }
            set
            {
                base[global::ConsoleApplication1.Report.SheetsPropertyName] = value;
            }
        }
        #endregion
    }
}
namespace ConsoleApplication1
{
    
    
    /// <summary>
    /// A collection of Sheet instances.
    /// </summary>
    [global::System.Configuration.ConfigurationCollectionAttribute(typeof(global::ConsoleApplication1.Sheet), CollectionType=global::System.Configuration.ConfigurationElementCollectionType.BasicMapAlternate, AddItemName=global::ConsoleApplication1.Sheets.SheetPropertyName)]
    public partial class Sheets : global::System.Configuration.ConfigurationElementCollection
    {
        
        #region Constants
        /// <summary>
        /// The XML name of the individual <see cref="global::ConsoleApplication1.Sheet"/> instances in this collection.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        internal const string SheetPropertyName = "sheet";
        #endregion
        
        #region Overrides
        /// <summary>
        /// Gets the type of the <see cref="global::System.Configuration.ConfigurationElementCollection"/>.
        /// </summary>
        /// <returns>The <see cref="global::System.Configuration.ConfigurationElementCollectionType"/> of this collection.</returns>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        public override global::System.Configuration.ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return global::System.Configuration.ConfigurationElementCollectionType.BasicMapAlternate;
            }
        }
        
        /// <summary>
        /// Gets the name used to identify this collection of elements
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        protected override string ElementName
        {
            get
            {
                return global::ConsoleApplication1.Sheets.SheetPropertyName;
            }
        }
        
        /// <summary>
        /// Indicates whether the specified <see cref="global::System.Configuration.ConfigurationElement"/> exists in the <see cref="global::System.Configuration.ConfigurationElementCollection"/>.
        /// </summary>
        /// <param name="elementName">The name of the element to verify.</param>
        /// <returns>
        /// <see langword="true"/> if the element exists in the collection; otherwise, <see langword="false"/>.
        /// </returns>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        protected override bool IsElementName(string elementName)
        {
            return (elementName == global::ConsoleApplication1.Sheets.SheetPropertyName);
        }
        
        /// <summary>
        /// Gets the element key for the specified configuration element.
        /// </summary>
        /// <param name="element">The <see cref="global::System.Configuration.ConfigurationElement"/> to return the key for.</param>
        /// <returns>
        /// An <see cref="object"/> that acts as the key for the specified <see cref="global::System.Configuration.ConfigurationElement"/>.
        /// </returns>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        protected override object GetElementKey(global::System.Configuration.ConfigurationElement element)
        {
            return ((global::ConsoleApplication1.Sheet)(element)).Name;
        }
        
        /// <summary>
        /// Creates a new <see cref="global::ConsoleApplication1.Sheet"/>.
        /// </summary>
        /// <returns>
        /// A new <see cref="global::ConsoleApplication1.Sheet"/>.
        /// </returns>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        protected override global::System.Configuration.ConfigurationElement CreateNewElement()
        {
            return new global::ConsoleApplication1.Sheet();
        }
        #endregion
        
        #region Indexer
        /// <summary>
        /// Gets the <see cref="global::ConsoleApplication1.Sheet"/> at the specified index.
        /// </summary>
        /// <param name="index">The index of the <see cref="global::ConsoleApplication1.Sheet"/> to retrieve.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        public global::ConsoleApplication1.Sheet this[int index]
        {
            get
            {
                return ((global::ConsoleApplication1.Sheet)(base.BaseGet(index)));
            }
        }
        
        /// <summary>
        /// Gets the <see cref="global::ConsoleApplication1.Sheet"/> with the specified key.
        /// </summary>
        /// <param name="name">The key of the <see cref="global::ConsoleApplication1.Sheet"/> to retrieve.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        public global::ConsoleApplication1.Sheet this[object name]
        {
            get
            {
                return ((global::ConsoleApplication1.Sheet)(base.BaseGet(name)));
            }
        }
        #endregion
        
        #region Add
        /// <summary>
        /// Adds the specified <see cref="global::ConsoleApplication1.Sheet"/> to the <see cref="global::System.Configuration.ConfigurationElementCollection"/>.
        /// </summary>
        /// <param name="sheet">The <see cref="global::ConsoleApplication1.Sheet"/> to add.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        public void Add(global::ConsoleApplication1.Sheet sheet)
        {
            base.BaseAdd(sheet);
        }
        #endregion
        
        #region Remove
        /// <summary>
        /// Removes the specified <see cref="global::ConsoleApplication1.Sheet"/> from the <see cref="global::System.Configuration.ConfigurationElementCollection"/>.
        /// </summary>
        /// <param name="sheet">The <see cref="global::ConsoleApplication1.Sheet"/> to remove.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        public void Remove(global::ConsoleApplication1.Sheet sheet)
        {
            base.BaseRemove(this.GetElementKey(sheet));
        }
        #endregion
        
        #region GetItem
        /// <summary>
        /// Gets the <see cref="global::ConsoleApplication1.Sheet"/> at the specified index.
        /// </summary>
        /// <param name="index">The index of the <see cref="global::ConsoleApplication1.Sheet"/> to retrieve.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        public global::ConsoleApplication1.Sheet GetItemAt(int index)
        {
            return ((global::ConsoleApplication1.Sheet)(base.BaseGet(index)));
        }
        
        /// <summary>
        /// Gets the <see cref="global::ConsoleApplication1.Sheet"/> with the specified key.
        /// </summary>
        /// <param name="name">The key of the <see cref="global::ConsoleApplication1.Sheet"/> to retrieve.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        public global::ConsoleApplication1.Sheet GetItemByKey(string name)
        {
            return ((global::ConsoleApplication1.Sheet)(base.BaseGet(((object)(name)))));
        }
        #endregion
        
        #region IsReadOnly override
        /// <summary>
        /// Gets a value indicating whether the element is read-only.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion
    }
}
namespace ConsoleApplication1
{


    /// <summary>
    /// The Sheet Configuration Element.
    /// </summary>
    public partial class Sheet : global::System.Configuration.ConfigurationElement
    {

        #region IsReadOnly override
        /// <summary>
        /// Gets a value indicating whether the element is read-only.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion

        #region Name Property
        /// <summary>
        /// The XML name of the <see cref="Name"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        internal const string NamePropertyName = "name";

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        [global::System.ComponentModel.DescriptionAttribute("The Name.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::ConsoleApplication1.Sheet.NamePropertyName, IsRequired = true, IsKey = true, IsDefaultCollection = false)]
        public virtual string Name
        {
            get
            {
                return ((string)(base[global::ConsoleApplication1.Sheet.NamePropertyName]));
            }
            set
            {
                base[global::ConsoleApplication1.Sheet.NamePropertyName] = value;
            }
        }
        #endregion
    }
}