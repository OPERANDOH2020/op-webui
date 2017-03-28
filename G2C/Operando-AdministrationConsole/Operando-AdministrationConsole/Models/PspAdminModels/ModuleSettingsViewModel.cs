using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Operando_AdministrationConsole.Models.PspAdminModels
{
    public class ModuleSettingsViewModel
    {
        public IDictionary<string, ContainerConfigurationDetailsModel> ContainerConfigurationDetailsModelsIndexedByContainerName { get; set; }

        public class ContainerConfigurationDetailsModel
        {
            public string ContainerName { get; set; }

            public string ContainerId { get; set; }
            public IDictionary<string, ModuleConfigurationDetailsModel> ConfigurationDetailsIndexedByModuleAcronym { get; set; }
        }

        public class ModuleConfigurationDetailsModel
        {
            public string ModuleName { get; set; }
            public string ConfigurationDescription { get; set; }
        }
    }
}