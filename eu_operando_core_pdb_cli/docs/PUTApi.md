# IO.Swagger.Api.PUTApi

All URIs are relative to *http://operando.eu/policy_database*

Method | HTTP request | Description
------------- | ------------- | -------------
[**OSPOspIdPut**](PUTApi.md#ospospidput) | **PUT** /OSP/{osp-id}/ | Update OSPBehaviour entry in the database.
[**RegulationsRegIdPut**](PUTApi.md#regulationsregidput) | **PUT** /regulations/{reg-id}/ | Update PrivacyRegulation entry in the database.
[**UserPrivacyPolicyUserIdPut**](PUTApi.md#userprivacypolicyuseridput) | **PUT** /user_privacy_policy/{user-id}/ | Update UPP entry in the database for the user.


<a name="ospospidput"></a>
# **OSPOspIdPut**
> void OSPOspIdPut (string ospId, OSPPrivacyPolicyInput ospPolicy)

Update OSPBehaviour entry in the database.

Called when by the policy computation component when the regulator api updates a regulation. Their new OSPRequest document is stored in the policy DB. 

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class OSPOspIdPutExample
    {
        public void main()
        {
            
            var apiInstance = new PUTApi();
            var ospId = ospId_example;  // string | The identifier number of an OSP
            var ospPolicy = new OSPPrivacyPolicyInput(); // OSPPrivacyPolicyInput | The changed instance of this OSPRequest

            try
            {
                // Update OSPBehaviour entry in the database.
                apiInstance.OSPOspIdPut(ospId, ospPolicy);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling PUTApi.OSPOspIdPut: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ospId** | **string**| The identifier number of an OSP | 
 **ospPolicy** | [**OSPPrivacyPolicyInput**](OSPPrivacyPolicyInput.md)| The changed instance of this OSPRequest | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="regulationsregidput"></a>
# **RegulationsRegIdPut**
> void RegulationsRegIdPut (string regId, PrivacyRegulationInput regulation)

Update PrivacyRegulation entry in the database.

Called when by the policy computation component when the regulator api updates a regulation. Their new PrivacyRegulation document is stored in the policy DB. 

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class RegulationsRegIdPutExample
    {
        public void main()
        {
            
            var apiInstance = new PUTApi();
            var regId = regId_example;  // string | The identifier number of a regulation
            var regulation = new PrivacyRegulationInput(); // PrivacyRegulationInput | The changed instance of this PrivacyRegulation

            try
            {
                // Update PrivacyRegulation entry in the database.
                apiInstance.RegulationsRegIdPut(regId, regulation);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling PUTApi.RegulationsRegIdPut: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **regId** | **string**| The identifier number of a regulation | 
 **regulation** | [**PrivacyRegulationInput**](PrivacyRegulationInput.md)| The changed instance of this PrivacyRegulation | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="userprivacypolicyuseridput"></a>
# **UserPrivacyPolicyUserIdPut**
> void UserPrivacyPolicyUserIdPut (string userId, UserPrivacyPolicy upp)

Update UPP entry in the database for the user.

Called when a user makes a change to the UPP registered with operando. Their new privacy preferences are passed in the UPP document and stored in the policy DB. 

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class UserPrivacyPolicyUserIdPutExample
    {
        public void main()
        {
            
            var apiInstance = new PUTApi();
            var userId = userId_example;  // string | The user identifier number
            var upp = new UserPrivacyPolicy(); // UserPrivacyPolicy | The changed instance of this user's UPP

            try
            {
                // Update UPP entry in the database for the user.
                apiInstance.UserPrivacyPolicyUserIdPut(userId, upp);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling PUTApi.UserPrivacyPolicyUserIdPut: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **userId** | **string**| The user identifier number | 
 **upp** | [**UserPrivacyPolicy**](UserPrivacyPolicy.md)| The changed instance of this user&#39;s UPP | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

