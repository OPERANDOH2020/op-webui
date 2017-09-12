using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operando_AdministrationConsole.Helper
{
    public interface INiceStringConverter
    {
        string NiceAccessorNameOrDefault(string accessor);

        string NiceResourceNameOrDefault(string resource);

        string NiceActionNameOrDefault(string action);

        string NiceSubjectNameOrDefault(string subject);
    }
}
