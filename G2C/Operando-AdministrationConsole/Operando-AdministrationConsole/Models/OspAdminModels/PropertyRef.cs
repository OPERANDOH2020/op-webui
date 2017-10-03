using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
namespace Operando_AdministrationConsole.Models.OspAdminModels
{
    [XmlRoot(ElementName = "PropertyRef")]
    public class PropertyRef
    {
        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }
    }
}