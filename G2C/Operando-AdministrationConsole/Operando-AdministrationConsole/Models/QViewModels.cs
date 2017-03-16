using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Operando_AdministrationConsole.Models
{
    public class QViewModels
    {
        public IList<QCat> categories { get; set; }
    }
    public class QCat
    {
        public string title { get; set; }
        public IList<QQuestion> questions { get; set; }
    }
    public class QQuestion
    {
        public string question { get; set; }
        public QSelectValue qValue { get; set; }
        public IList<QSelectValue> valueList { get; set; }
    }
    public class QSelectValue
    {
        public string id { get; set; }
        public string Type { get; set; }
    }
}