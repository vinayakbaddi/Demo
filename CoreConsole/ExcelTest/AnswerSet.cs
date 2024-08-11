using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreConsole.ExcelTest
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class answerset
    {

        private answersetSection sectionField;

        private answersetCell cellField;

        /// <remarks/>
        public answersetSection section
        {
            get
            {
                return this.sectionField;
            }
            set
            {
                this.sectionField = value;
            }
        }

        /// <remarks/>
        public answersetCell cell
        {
            get
            {
                return this.cellField;
            }
            set
            {
                this.cellField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class answersetSection
    {

        private answersetSectionHeader headerField;

        private answersetSectionBody bodyField;

        private answersetSectionFooter footerField;

        private string nameField;

        /// <remarks/>
        public answersetSectionHeader header
        {
            get
            {
                return this.headerField;
            }
            set
            {
                this.headerField = value;
            }
        }

        /// <remarks/>
        public answersetSectionBody body
        {
            get
            {
                return this.bodyField;
            }
            set
            {
                this.bodyField = value;
            }
        }

        /// <remarks/>
        public answersetSectionFooter footer
        {
            get
            {
                return this.footerField;
            }
            set
            {
                this.footerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class answersetSectionHeader
    {

        private answersetSectionHeaderTable tableField;

        /// <remarks/>
        public answersetSectionHeaderTable table
        {
            get
            {
                return this.tableField;
            }
            set
            {
                this.tableField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class answersetSectionHeaderTable
    {

        private string[] thField;

        private string[] trField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("c", IsNullable = false)]
        public string[] th
        {
            get
            {
                return this.thField;
            }
            set
            {
                this.thField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("c", IsNullable = false)]
        public string[] tr
        {
            get
            {
                return this.trField;
            }
            set
            {
                this.trField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class answersetSectionBody
    {

        private answersetSectionBodyTable tableField;

        /// <remarks/>
        public answersetSectionBodyTable table
        {
            get
            {
                return this.tableField;
            }
            set
            {
                this.tableField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class answersetSectionBodyTable
    {

        private string[] thField;

        private string[] trField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("c", IsNullable = false)]
        public string[] th
        {
            get
            {
                return this.thField;
            }
            set
            {
                this.thField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("c", IsNullable = false)]
        public string[] tr
        {
            get
            {
                return this.trField;
            }
            set
            {
                this.trField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class answersetSectionFooter
    {

        private answersetSectionFooterTable tableField;

        /// <remarks/>
        public answersetSectionFooterTable table
        {
            get
            {
                return this.tableField;
            }
            set
            {
                this.tableField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class answersetSectionFooterTable
    {

        private string[] thField;

        private string[] trField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("c", IsNullable = false)]
        public string[] th
        {
            get
            {
                return this.thField;
            }
            set
            {
                this.thField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("c", IsNullable = false)]
        public string[] tr
        {
            get
            {
                return this.trField;
            }
            set
            {
                this.trField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class answersetCell
    {

        private string nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }


}
