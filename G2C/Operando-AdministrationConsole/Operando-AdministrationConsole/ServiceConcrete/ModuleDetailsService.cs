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

        private IDictionary<string, string> GetModuleConfigurationDetailsDictionaryIndexedByAcronym()
        {
            var configurationDetailsDictionary = new Dictionary<string, string>
            {
                {"AAPI", GetAapiConfigurationInformation()},
                {"OAPI", GetOapiConfigurationInformation()},
                {"RAPI", GetRapiConfigurationInformation()},
                {"PC", GetPcConfigurationInformation()},
                {"OSE", GetOseConfigurationInformation()},
                {"RM", GetRmConfigurationInformation()},
                {"BDA", GetBdaConfigurationInformation()},
                {"AE", GetAeConfigurationDetails()},
                {"PDB", GetPdbConfigurationInformation()},
                {"LDB", GetLdbConfigurationInformation()},
                {"GK", GetGkConfigurationInformation()},
                {"DAN", GetDanConfigurationInformation()},
                {"RPM", GetRpmConfigurationInformation()},
                { "AMC", GetAmcConfigurationInformation()},
                {"RG", GetRgConfigurationInformation()}
            };


            return configurationDetailsDictionary;
        }

        private static string GetAapiConfigurationInformation()
        {
            return "AAPI:"
                + "\nGeneral AAPI configuration: https://github.com/OPERANDOH2020/op-interfaces/blob/master/op-interfaces-aapi/eu.operando.interfaces.aapi.server/src/main/resources/aapi-config.properties"
                + "\nAAPI log4j configuration: https://github.com/OPERANDOH2020/op-interfaces/blob/master/op-interfaces-aapi/eu.operando.interfaces.aapi.server/src/main/resources/log4j.properties"
                + "\n"
                + "\nCAS:"
                + "\nGeneral CAS configuration: https://github.com/OPERANDOH2020/op-core/blob/master/op-core-cas/eu.operando.core.cas.server/src/main/docker/etc/cas/cas.properties"
                + "\nCAS Log4j configuration: https://github.com/OPERANDOH2020/op-core/blob/master/op-core-cas/eu.operando.core.cas.server/src/main/docker/etc/cas/log4j2.xml"
                + "\n"
                + "\nAlso configurable is the deployerConfigContext.xml that contains the service registry and is located here:"
                + "\nhttps://github.com/OPERANDOH2020/op-core/blob/master/op-core-cas/eu.operando.core.cas.server/src/main/docker/cas-overlay/src/main/webapp/WEB-INF/deployerConfigContext.xml";
        }

        private static string GetOapiConfigurationInformation()
        {
            return "There is a config.properties file \\op-interfaces\\op-interfaces-oapi\\src\\main\\resources\\config.properties and a pom file \\op-interfaces\\op-interfaces-oapi\\pom.xml." +
                   " The config.properties file is populated from the pom, so you can read configuration from the properties file but you need to write to the pom to make lasting changes.";
        }

        private static string GetRapiConfigurationInformation()
        {
            return "There is a config.properties file \\op-interfaces\\op-interfaces-rapi\\src\\main\\resources\\config.properties and a pom file \\op-interfaces\\op-interfaces-rapi\\pom.xml." +
                   " The config.properties file is populated from the pom, so you can read configuration from the properties file but you need to write to the pom to make lasting changes.";
        }

        private static string GetPcConfigurationInformation()
        {
            return "op-core-pc/pc-server/src/main/resources/config/operando.properties";
        }

        private static string GetOseConfigurationInformation()
        {
            return "op-core-ose/ose-server/src/main/resources/operando.properties";
        }

        private static string GetRmConfigurationInformation()
        {
            return "Rights Management has a configuration file which has the following information user/password, the credentials for CAS. Other parameters that are now hardcoded are the following:"
                + "\n__DAN_url"
                + "\n__aapi_st_url"
                + "\n__aapi_tgt_url"
                + "\n__aapi_tckt_val_url"
                + "\n__URL_LOGDB"
                + "\nWhich more or less are self explanatory, the URL of DAN, the URL of CAS to get ST and TGT, the URL of CAS to validate tickets and the URL of LogDB";
        }

        private static string GetBdaConfigurationInformation()
        {
            return "The configuration files are placed under /WEB-INF/classes/";
        }

        private static string GetPdbConfigurationInformation()
        {
            return "op-core-pdb/pdb-server/src/main/resources/config/service.properties, op-core-pdb/pdb-server/src/main/resources/config/db.properties";
        }

        private static string GetAeConfigurationDetails()
        {
            return "/WEB-INF/classes/db.properties";
        }

        private static string GetLdbConfigurationInformation()
        {
            return "LogDB is divided in two submodules: LogDB, LogDBSearch." +
                   "\nLogDB: the config file is log4j.properties, that is under /WEB-INF/classes/ folder in the war." +
                   "\nLogDBSearch: the config file is db.properties, that is under /WEB-INF/classes/ folder in the war.";
        }

        private static string GetGkConfigurationInformation()
        {
            return "There is a config.properties file \\op-pdr\\op-pdr-gatekeeper\\src\\main\\resources\\config.properties and a pom file \\op-pdr\\op-pdr-gatekeeper\\pom.xml." +
                   " The config.properties file is populated from the pom, so you can read configuration from the properties file but you need to write to the pom to make lasting changes.";
        }

        private static string GetDanConfigurationInformation()
        {
            return "Basic Configuration:"
                + "\nhttps://github.com/OPERANDOH2020/op-pdr/blob/master/op-pdr-dan/eu.operando.pdr.dan.server/src/main/resources/dan-config.properties"
                + "\n"
                + "\nDan’s Logging Configuration"
                + "\nhttps://github.com/OPERANDOH2020/op-pdr/blob/master/op-pdr-dan/eu.operando.pdr.dan.server/src/main/resources/log4j.properties"
                + "\n"
                + "\nList with Repository Managers Info"
                + "\nhttps://github.com/OPERANDOH2020/op-pdr/blob/master/op-pdr-dan/eu.operando.pdr.dan.server/src/main/resources/repositoryManagersRegistry.yml";
        }

        private static string GetRpmConfigurationInformation()
        {
            return "Basic Configuration: https://github.com/OPERANDOH2020/op-pdr/blob/master/op-pdr-rpm/eu.operando.pdr.rpm.server/src/main/resources/META-INF/persistence.xml";
        }

        private static string GetAmcConfigurationInformation()
        {
            return "All available configuration can be found in the Web.config file of the Operando-AdministationConsole project." +
                   "\n" +
                   "\nConfiguration options include database connection strings and URLs for other modules.";
        }

        private static string GetRgConfigurationInformation()
        {
            return "Report Generator module (inside OPERANDO UI):"
                + "\nWeb.config: Inside root of the website. Contains keys:"
                + "\nMySQLConnection: connection string to MySql Report DB."
                + "\n"
                + "\nReport Scheduler (is a \"stand alone\" executable that goes to read MySql tables and runs reports and saves them):"
                + "\nApp.config: Inside root of the project. Contains keys:"
                + "\nMySQLConnection: Connection string to MySql Report DB."
                + "\npathSave: Path where the reports are saved."
                + "\n"
                + "\nReport REST service (\"stand alone\" web service):"
                + "\nWeb.config: Inside root of the website. Contains keys:"
                + "\nMySQLConnection: Connection string to MySql Report DB."
                + "\naapiBasePath: AAPI url endpoint."
                + "\nserviceId: Report service id."
                + "\nstHeaderName: Service ticket name in HTTP Header."
                + "\n"
                + "\nI think for what concerns the Report Scheduler and Report REST service you can not edit the configuration from UI bacause they are \"stand alone\" applications that can be placed anywhere inside the server...if you want to make them configurable from UI you have to put them always in the same path (this can be a solution if you prefer)."
                + "\n"
                + "\nReport Scheduler can be found here: https://github.com/OPERANDOH2020/op-webui/tree/master/G2C/Operando-AdministrationConsole/Operando-AdministrationConsole/ExecuteSchedule"
                + "\n"
                + "\nReport REST service can be found here: https://github.com/OPERANDOH2020/op-webui/tree/master/reportsREST_WP"
                + "\n"
                + "\nReport Generator module is inside OPERANDO UI (OSP Admin -> Reports and PSP Admin -> Reports)";
        }
    }
}