# IO.Swagger - the C# library for the Policy DB

The Policy Database that stores three types of documents in dedicated collections.   1) User Privacy Policy. Each OPERANDO user has one UPP document describing their privacy policies for each of the OSP services they are subscribed to. The UPP contains the current B2C privacy settings for a subscribed to OSP. The UPP contains the users privacy preferences. The UPP contains the G2C access policies for the OSP with justification for access.   2) The legislation policies. The regulations entered into OPERANDO using the OPERANDO regulation API.   3) The OSP descriptions and data requests. For each OSP its privacy policy, its access control rules, and the data it requests (as a workflow). For B2C, the set of privacy settings is stored. 

This C# SDK is automatically generated by the [Swagger Codegen](https://github.com/swagger-api/swagger-codegen) project:

- API version: 1.0.0
- SDK version: 1.0.0
- Build package: io.swagger.codegen.languages.CSharpClientCodegen
    For more information, please visit [http://www.operando.eu/support](http://www.operando.eu/support)

<a name="frameworks-supported"></a>
## Frameworks supported
- .NET 4.0 or later
- Windows Phone 7.1 (Mango)

<a name="dependencies"></a>
## Dependencies
- [RestSharp](https://www.nuget.org/packages/RestSharp) - 105.1.0 or later
- [Json.NET](https://www.nuget.org/packages/Newtonsoft.Json/) - 7.0.0 or later

The DLLs included in the package may not be the latest version. We recommned using [NuGet] (https://docs.nuget.org/consume/installing-nuget) to obtain the latest version of the packages:
```
Install-Package RestSharp
Install-Package Newtonsoft.Json
```

NOTE: RestSharp versions greater than 105.1.0 have a bug which causes file uploads to fail. See [RestSharp#742](https://github.com/restsharp/RestSharp/issues/742)

<a name="installation"></a>
## Installation
Run the following command to generate the DLL
- [Mac/Linux] `/bin/sh build.sh`
- [Windows] `build.bat`

Then include the DLL (under the `bin` folder) in the C# project, and use the namespaces:
```csharp
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;
```
<a name="getting-started"></a>
## Getting Started

```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class Example
    {
        public void main()
        {
            
            var apiInstance = new DELETEApi();
            var ospId = ospId_example;  // string | The identifier number of an OSP

            try
            {
                // Remove the OSPRequest entry in the database.
                apiInstance.OSPOspIdDelete(ospId);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DELETEApi.OSPOspIdDelete: " + e.Message );
            }
        }
    }
}
```

<a name="documentation-for-api-endpoints"></a>
## Documentation for API Endpoints

All URIs are relative to *http://operando.eu/policy_database*

Class | Method | HTTP request | Description
------------ | ------------- | ------------- | -------------
*DELETEApi* | [**OSPOspIdDelete**](docs/DELETEApi.md#ospospiddelete) | **DELETE** /OSP/{osp-id}/ | Remove the OSPRequest entry in the database.
*DELETEApi* | [**OSPOspIdPrivacyPolicyAccessReasonsReasonIdDelete**](docs/DELETEApi.md#ospospidprivacypolicyaccessreasonsreasoniddelete) | **DELETE** /OSP/{osp-id}/privacy-policy/access-reasons/{reason-id} | Remove the AccessReason entry in the list.
*DELETEApi* | [**RegulationsRegIdDelete**](docs/DELETEApi.md#regulationsregiddelete) | **DELETE** /regulations/{reg-id}/ | Remove the PrivacyRegulation entry in the database.
*DELETEApi* | [**UserPrivacyPolicyUserIdDelete**](docs/DELETEApi.md#userprivacypolicyuseriddelete) | **DELETE** /user_privacy_policy/{user-id}/ | Remove the UPP entry in the database for the user.
*GETApi* | [**OSPGet**](docs/GETApi.md#ospget) | **GET** /OSP/ | Perform a search query across the collection of OSP behaviour.
*GETApi* | [**OSPOspIdGet**](docs/GETApi.md#ospospidget) | **GET** /OSP/{osp-id}/ | Read a given OSP behaviour policy.
*GETApi* | [**OSPOspIdPrivacyPolicyAccessReasonsGet**](docs/GETApi.md#ospospidprivacypolicyaccessreasonsget) | **GET** /OSP/{osp-id}/privacy-policy/access-reasons | Get the list of access reason policy statements.
*GETApi* | [**OSPOspIdPrivacyPolicyGet**](docs/GETApi.md#ospospidprivacypolicyget) | **GET** /OSP/{osp-id}/privacy-policy/ | Get the current set of privacy policy statements about the usage of data for stated reasons.
*GETApi* | [**RegulationsGet**](docs/GETApi.md#regulationsget) | **GET** /regulations/ | Perform a search query across the collection of regulation.
*GETApi* | [**RegulationsRegIdGet**](docs/GETApi.md#regulationsregidget) | **GET** /regulations/{reg-id}/ | Read a given legislation with its ID.
*GETApi* | [**UserPrivacyPolicyGet**](docs/GETApi.md#userprivacypolicyget) | **GET** /user_privacy_policy/ | Perform a search query across the collection of UPPs.
*GETApi* | [**UserPrivacyPolicyUserIdGet**](docs/GETApi.md#userprivacypolicyuseridget) | **GET** /user_privacy_policy/{user-id}/ | Read the user privacy policy for the given user id.
*LegislationApi* | [**RegulationsGet**](docs/LegislationApi.md#regulationsget) | **GET** /regulations/ | Perform a search query across the collection of regulation.
*LegislationApi* | [**RegulationsPost**](docs/LegislationApi.md#regulationspost) | **POST** /regulations/ | Create a new legislation entry in the database.
*LegislationApi* | [**RegulationsRegIdDelete**](docs/LegislationApi.md#regulationsregiddelete) | **DELETE** /regulations/{reg-id}/ | Remove the PrivacyRegulation entry in the database.
*LegislationApi* | [**RegulationsRegIdGet**](docs/LegislationApi.md#regulationsregidget) | **GET** /regulations/{reg-id}/ | Read a given legislation with its ID.
*LegislationApi* | [**RegulationsRegIdPut**](docs/LegislationApi.md#regulationsregidput) | **PUT** /regulations/{reg-id}/ | Update PrivacyRegulation entry in the database.
*OSPApi* | [**OSPGet**](docs/OSPApi.md#ospget) | **GET** /OSP/ | Perform a search query across the collection of OSP behaviour.
*OSPApi* | [**OSPOspIdDelete**](docs/OSPApi.md#ospospiddelete) | **DELETE** /OSP/{osp-id}/ | Remove the OSPRequest entry in the database.
*OSPApi* | [**OSPOspIdGet**](docs/OSPApi.md#ospospidget) | **GET** /OSP/{osp-id}/ | Read a given OSP behaviour policy.
*OSPApi* | [**OSPOspIdPrivacyPolicyAccessReasonsGet**](docs/OSPApi.md#ospospidprivacypolicyaccessreasonsget) | **GET** /OSP/{osp-id}/privacy-policy/access-reasons | Get the list of access reason policy statements.
*OSPApi* | [**OSPOspIdPrivacyPolicyAccessReasonsPost**](docs/OSPApi.md#ospospidprivacypolicyaccessreasonspost) | **POST** /OSP/{osp-id}/privacy-policy/access-reasons | Create a new access reason statement in the privacy policy.
*OSPApi* | [**OSPOspIdPrivacyPolicyAccessReasonsReasonIdDelete**](docs/OSPApi.md#ospospidprivacypolicyaccessreasonsreasoniddelete) | **DELETE** /OSP/{osp-id}/privacy-policy/access-reasons/{reason-id} | Remove the AccessReason entry in the list.
*OSPApi* | [**OSPOspIdPrivacyPolicyAccessReasonsReasonIdPut**](docs/OSPApi.md#ospospidprivacypolicyaccessreasonsreasonidput) | **PUT** /OSP/{osp-id}/privacy-policy/access-reasons/{reason-id} | Update an access reason statement in the privacy policy.
*OSPApi* | [**OSPOspIdPrivacyPolicyGet**](docs/OSPApi.md#ospospidprivacypolicyget) | **GET** /OSP/{osp-id}/privacy-policy/ | Get the current set of privacy policy statements about the usage of data for stated reasons.
*OSPApi* | [**OSPOspIdPrivacyPolicyPut**](docs/OSPApi.md#ospospidprivacypolicyput) | **PUT** /OSP/{osp-id}/privacy-policy/ | Update OSP text policy entry in the database.
*OSPApi* | [**OSPOspIdPut**](docs/OSPApi.md#ospospidput) | **PUT** /OSP/{osp-id}/ | Update OSPBehaviour entry in the database.
*OSPApi* | [**OSPPost**](docs/OSPApi.md#osppost) | **POST** /OSP/ | Create a new OSP entry in the database.
*POSTApi* | [**OSPOspIdPrivacyPolicyAccessReasonsPost**](docs/POSTApi.md#ospospidprivacypolicyaccessreasonspost) | **POST** /OSP/{osp-id}/privacy-policy/access-reasons | Create a new access reason statement in the privacy policy.
*POSTApi* | [**OSPOspIdPrivacyPolicyAccessReasonsReasonIdPut**](docs/POSTApi.md#ospospidprivacypolicyaccessreasonsreasonidput) | **PUT** /OSP/{osp-id}/privacy-policy/access-reasons/{reason-id} | Update an access reason statement in the privacy policy.
*POSTApi* | [**OSPPost**](docs/POSTApi.md#osppost) | **POST** /OSP/ | Create a new OSP entry in the database.
*POSTApi* | [**RegulationsPost**](docs/POSTApi.md#regulationspost) | **POST** /regulations/ | Create a new legislation entry in the database.
*POSTApi* | [**UserPrivacyPolicyPost**](docs/POSTApi.md#userprivacypolicypost) | **POST** /user_privacy_policy/ | Create a new UPP entry in the database for the user.
*PUTApi* | [**OSPOspIdPrivacyPolicyPut**](docs/PUTApi.md#ospospidprivacypolicyput) | **PUT** /OSP/{osp-id}/privacy-policy/ | Update OSP text policy entry in the database.
*PUTApi* | [**OSPOspIdPut**](docs/PUTApi.md#ospospidput) | **PUT** /OSP/{osp-id}/ | Update OSPBehaviour entry in the database.
*PUTApi* | [**RegulationsRegIdPut**](docs/PUTApi.md#regulationsregidput) | **PUT** /regulations/{reg-id}/ | Update PrivacyRegulation entry in the database.
*PUTApi* | [**UserPrivacyPolicyUserIdPut**](docs/PUTApi.md#userprivacypolicyuseridput) | **PUT** /user_privacy_policy/{user-id}/ | Update UPP entry in the database for the user.
*UPPApi* | [**UserPrivacyPolicyGet**](docs/UPPApi.md#userprivacypolicyget) | **GET** /user_privacy_policy/ | Perform a search query across the collection of UPPs.
*UPPApi* | [**UserPrivacyPolicyPost**](docs/UPPApi.md#userprivacypolicypost) | **POST** /user_privacy_policy/ | Create a new UPP entry in the database for the user.
*UPPApi* | [**UserPrivacyPolicyUserIdDelete**](docs/UPPApi.md#userprivacypolicyuseriddelete) | **DELETE** /user_privacy_policy/{user-id}/ | Remove the UPP entry in the database for the user.
*UPPApi* | [**UserPrivacyPolicyUserIdGet**](docs/UPPApi.md#userprivacypolicyuseridget) | **GET** /user_privacy_policy/{user-id}/ | Read the user privacy policy for the given user id.
*UPPApi* | [**UserPrivacyPolicyUserIdPut**](docs/UPPApi.md#userprivacypolicyuseridput) | **PUT** /user_privacy_policy/{user-id}/ | Update UPP entry in the database for the user.


<a name="documentation-for-models"></a>
## Documentation for Models

 - [Model.AccessPolicy](docs/AccessPolicy.md)
 - [Model.AccessReason](docs/AccessReason.md)
 - [Model.OSPConsents](docs/OSPConsents.md)
 - [Model.OSPDataRequest](docs/OSPDataRequest.md)
 - [Model.OSPPrivacyPolicy](docs/OSPPrivacyPolicy.md)
 - [Model.OSPPrivacyPolicyInput](docs/OSPPrivacyPolicyInput.md)
 - [Model.OSPReasonPolicy](docs/OSPReasonPolicy.md)
 - [Model.OSPReasonPolicyInput](docs/OSPReasonPolicyInput.md)
 - [Model.OSPSettings](docs/OSPSettings.md)
 - [Model.PolicyAttribute](docs/PolicyAttribute.md)
 - [Model.PrivacyRegulation](docs/PrivacyRegulation.md)
 - [Model.PrivacyRegulationInput](docs/PrivacyRegulationInput.md)
 - [Model.PrivacySetting](docs/PrivacySetting.md)
 - [Model.UserPreference](docs/UserPreference.md)
 - [Model.UserPrivacyPolicy](docs/UserPrivacyPolicy.md)


<a name="documentation-for-authorization"></a>
## Documentation for Authorization

All endpoints do not require authorization.
