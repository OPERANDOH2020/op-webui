using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Operando_AdministrationConsole.DomainEntities;

namespace Operando_AdministrationConsole.ServiceInterfaces
{
    interface IModuleDetailsService
    {
        IDictionary<Module, string> GetModuleConfigurationDetailsDictionary();

        IList<string> GetContainerList();
    }
}
