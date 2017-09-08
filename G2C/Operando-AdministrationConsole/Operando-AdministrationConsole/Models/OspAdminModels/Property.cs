using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
namespace Operando_AdministrationConsole.Models.OspAdminModels
{

    [XmlRoot(ElementName = "Property")]
    public class Property
    {
        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "Type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "Nullable")]
        public string Nullable { get; set; }
    }
}