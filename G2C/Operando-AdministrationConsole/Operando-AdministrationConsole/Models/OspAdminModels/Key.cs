using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
namespace Operando_AdministrationConsole.Models.OspAdminModels
{
   [XmlRoot(ElementName = "Key")]
        public class Key
        {
            [XmlElement(ElementName = "PropertyRef")]
            public PropertyRef PropertyRef { get; set; }
        }
    
}