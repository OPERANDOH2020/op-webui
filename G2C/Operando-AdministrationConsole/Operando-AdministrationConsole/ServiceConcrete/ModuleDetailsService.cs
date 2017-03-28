using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Operando_AdministrationConsole.DomainEntities;
using Operando_AdministrationConsole.ServiceInterfaces;

namespace Operando_AdministrationConsole.ServiceConcrete
{
    public class ModuleDetailsService : IModuleDetailsService
    {
        public IDictionary<Module, string> GetModuleConfigurationDetailsDictionary()
        {
            var configurationDetailsDictionary = new Dictionary<Module, string>();

            IList<Module> modules = GetModuleList();
            IDictionary<string, string> configurationDetailsDictionaryIndexedByAcronym =
                this.GetModuleConfigurationDetailsDictionaryIndexedByAcronym();

            foreach (var module in modules)
            {
                string configurationDetails = configurationDetailsDictionaryIndexedByAcronym[module.Acronym];
                configurationDetailsDictionary.Add(module, configurationDetails);
            }

            return configurationDetailsDictionary;
        }

        public IList<string> GetContainerList()
        {
            IList<string> containerList = new List<string>();

            foreach (var module in GetModuleList())
            {
                string moduleContainer = module.Container;
                if (!containerList.Contains(moduleContainer))
                {
                    containerList.Add(moduleContainer);
                }
            }

            return containerList;
        }

        private IDictionary<string, string> GetModuleConfigurationDetailsDictionaryIndexedByAcronym()
        {
            var configurationDetailsDictionary = new Dictionary<string, string>
            {
                {"AAPI", "AAPI Configuration"},
                {"OAPI", "OAPI Configuration"},
                {"RAPI", "RAPI Configuration"},
                {"PC", "PC Configuration"},
                {"OSE", "OSE Configuration"},
                {"RM", "RM Configuration"},
                {"BDA", "BDA Configuration"},
                {"AE", "AE Configuration"},
                {"UDB", "UDB Configuration"},
                {"PDB", "PDB Configuration"},
                {"LDB", "LDB Configuration"},
                {"GK", "GK Configuration"},
                {"DAN", "DAN Configuration"},
                {"RPM", "RPM Configuration"},
                {"AMC", "AMC Configuration"},
                {"RG", "RG Configuration"}
            };


            return configurationDetailsDictionary;
        }

        private IList<Module> GetModuleList()
        {
            List<Module> moduleList = new List<Module>
            {
                new Module {Name = "Authentication API", Acronym = "AAPI", Container = "External Interfaces"},
                new Module {Name = "OSP API", Acronym = "OAPI", Container = "External Interfaces"},
                new Module {Name = "Regulator API", Acronym = "RAPI", Container = "External Interfaces"},
                new Module {Name = "Policy Computation", Acronym = "PC", Container = "PA Core"},
                new Module {Name = "OSP Enforcement", Acronym = "OSE", Container = "PA Core"},
                new Module {Name = "Rights Management", Acronym = "RM", Container = "PA Core"},
                new Module {Name = "Big Data Analytics", Acronym = "BDA", Container = "PA Core"},
                new Module {Name = "Anonymization Engine", Acronym = "AE", Container = "PA Core"},
                new Module {Name = "User Accounts DB", Acronym = "UDB", Container = "PA Core"},
                new Module {Name = "Policies DB", Acronym = "PDB", Container = "PA Core"},
                new Module {Name = "Log DB", Acronym = "LDB", Container = "PA Core"},
                new Module {Name = "Gatekeeper", Acronym = "GK", Container = "Personal Data Repository"},
                new Module {Name = "Data Access Node", Acronym = "DAN", Container = "Personal Data Repository"},
                new Module {Name = "Repository Manager", Acronym = "RPM", Container = "Personal Data Repository"},
                new Module {Name = "Web Console", Acronym = "AMC", Container = "Web UI"},
                new Module {Name = "Report Generator", Acronym = "RG", Container = "Web UI"}
            };

            return moduleList;
        }
    }
}