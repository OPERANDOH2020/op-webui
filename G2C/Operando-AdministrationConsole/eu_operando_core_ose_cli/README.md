# IO.Swagger - the C# library for the OSP Enforcement (OSE)

 The OSP enforcement component provides a set of functions that manage the interaction of OSP behaviour with the user's private data. The OSE component is largely in charge of ensuring that an OSP follows both privacy regulations and policies put in place by the user (i.e. in the OPERANDO UPPs). There are a set of events that trigger the usage of this API.  1) When a new G2C OSP registers with OPERANDO via the OPERANDO console. The management console informs the OSE, which then checks that an OSP conforms with existing privacy regulations; if it breaches the regulations, the OSE returns via the management console a report describing the breaches.  2) When a change of OSP privacy policy or of the OSP's privacy settings are detected by the watchdog component. The watchdog component sends a message to a privacy analyst who reviews any changes. The privacy analyst may then inform the OSE of the new OSP information (to be checked for compliance with regulations and users' UPPs.  3) When a privacy legislation is entered (or changed) via the Regulator API. The OSE checks registered OSPs for compliance with the new regulations; where there is a breach the OSP is notified either by e-mail or the console. 

This C# SDK is automatically generated by the [Swagger Codegen](https://github.com/swagger-api/swagger-codegen) project:

- API version: 0.0.8
- SDK version: 1.0.0
- Build date: 2016-09-30T10:23:53.026Z
- Build package: class io.swagger.codegen.languages.CSharpClientCodegen
    For more information, please visit [http://www.operando.eu/support](http://www.operando.eu/support)

## Frameworks supported
- .NET 4.0 or later
- Windows Phone 7.1 (Mango)

## Dependencies
- [RestSharp](https://www.nuget.org/packages/RestSharp) - 105.1.0 or later
- [Json.NET](https://www.nuget.org/packages/Newtonsoft.Json/) - 7.0.0 or later

The DLLs included in the package may not be the latest version. We recommned using [NuGet] (https://docs.nuget.org/consume/installing-nuget) to obtain the latest version of the packages:
```
Install-Package RestSharp
Install-Package Newtonsoft.Json
```

NOTE: RestSharp versions greater than 105.1.0 have a bug which causes file uploads to fail. See [RestSharp#742](https://github.com/restsharp/RestSharp/issues/742)

## Installation
Run the following command to generate the DLL
- [Mac/Linux] `/bin/sh build.sh`
- [Windows] `build.bat`

Then include the DLL (under the `bin` folder) in the C# project, and use the namespaces:
```csharp
using IO.Swagger.Api;
using IO.Swagger.Client;
using Model;
```

## Getting Started

```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using Model;

namespace Example
{
    public class Example
    {
        public void main()
        {
            
            var apiInstance = new PrivacyLegislationApi();
            var regulation = new PrivacyRegulation(); // PrivacyRegulation | The description of the new regulation.

            try
            {
                apiInstance.RegulationsPost(regulation);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling PrivacyLegislationApi.RegulationsPost: " + e.Message );
            }
        }
    }
}
```

<a name="documentation-for-api-endpoints"></a>
## Documentation for API Endpoints

All URIs are relative to *http://operando.eu/*

Class | Method | HTTP request | Description
------------ | ------------- | ------------- | -------------
*PrivacyLegislationApi* | [**RegulationsPost**](docs/PrivacyLegislationApi.md#regulationspost) | **POST** /regulations/ | 
*PrivacyLegislationApi* | [**RegulationsRegIdPut**](docs/PrivacyLegislationApi.md#regulationsregidput) | **PUT** /regulations/{reg-id}/ | 
*PrivacyPolicyApi* | [**OspsOspIdPrivacytextPut**](docs/PrivacyPolicyApi.md#ospsospidprivacytextput) | **PUT** /osps/{osp-id}/privacytext/ | 
*PrivacyPolicyApi* | [**OspsOspIdPut**](docs/PrivacyPolicyApi.md#ospsospidput) | **PUT** /osps/{osp-id}/ | 
*PrivacyPolicyApi* | [**OspsOspIdWorkflowsPut**](docs/PrivacyPolicyApi.md#ospsospidworkflowsput) | **PUT** /osps/{osp-id}/workflows/ | 
*PrivacySettingsApi* | [**OspsOspIdPrivacySettingsGet**](docs/PrivacySettingsApi.md#ospsospidprivacysettingsget) | **GET** /osps/{osp-id}/privacy_settings/ | 
*PrivacySettingsApi* | [**OspsOspIdPrivacySettingsPut**](docs/PrivacySettingsApi.md#ospsospidprivacysettingsput) | **PUT** /osps/{osp-id}/privacy_settings/ | 


<a name="documentation-for-models"></a>
## Documentation for Models

 - [Model.AccessPolicy](docs/AccessPolicy.md)
 - [Model.OSPDataRequest](docs/OSPDataRequest.md)
 - [Model.OSPPrivacyPolicy](docs/OSPPrivacyPolicy.md)
 - [Model.PolicyAttribute](docs/PolicyAttribute.md)
 - [Model.PrivacyRegulation](docs/PrivacyRegulation.md)
 - [Model.PrivacyRegulationInput](docs/PrivacyRegulationInput.md)
 - [Model.PrivacySetting](docs/PrivacySetting.md)


## Documentation for Authorization

All endpoints do not require authorization.
