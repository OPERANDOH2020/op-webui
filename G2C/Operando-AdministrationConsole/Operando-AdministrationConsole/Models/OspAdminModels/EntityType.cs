using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Xml.Serialization;



namespace Operando_AdministrationConsole.Models.OspAdminModels
{
        [XmlRoot(ElementName = "EntityType")]
            public class EntityType
            {
                [XmlElement(ElementName = "Key")]
                public Key Key { get; set; }
                [XmlElement(ElementName = "Property")]
                public List<Property> Property { get; set; }
                [XmlElement(ElementName = "NavigationProperty")]
                public List<NavigationProperty> NavigationProperty { get; set; }
                [XmlAttribute(AttributeName = "Name")]
                public string Name { get; set; }
            }
}