# IO.Swagger.Api.DELETEApi

All URIs are relative to *http://operando.eu/policy_database*

Method | HTTP request | Description
------------- | ------------- | -------------
[**OSPOspIdDelete**](DELETEApi.md#ospospiddelete) | **DELETE** /OSP/{osp-id}/ | Remove the OSPRequest entry in the database.
[**OSPOspIdPrivacyPolicyAccessReasonsReasonIdDelete**](DELETEApi.md#ospospidprivacypolicyaccessreasonsreasoniddelete) | **DELETE** /OSP/{osp-id}/privacy-policy/access-reasons/{reason-id} | Remove the AccessReason entry in the list.
[**RegulationsRegIdDelete**](DELETEApi.md#regulationsregiddelete) | **DELETE** /regulations/{reg-id}/ | Remove the PrivacyRegulation entry in the database.
[**UserPrivacyPolicyUserIdDelete**](DELETEApi.md#userprivacypolicyuseriddelete) | **DELETE** /user_privacy_policy/{user-id}/ | Remove the UPP entry in the database for the user.


<a name="ospospiddelete"></a>
# **OSPOspIdDelete**
> void OSPOspIdDelete (string ospId)

Remove the OSPRequest entry in the database.

Called when by the policy computation component when the regulator api requests that the regulation be deleted. 

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class OSPOspIdDeleteExample
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

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ospId** | **string**| The identifier number of an OSP | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="ospospidprivacypolicyaccessreasonsreasoniddelete"></a>
# **OSPOspIdPrivacyPolicyAccessReasonsReasonIdDelete**
> void OSPOspIdPrivacyPolicyAccessReasonsReasonIdDelete (string ospId, string reasonId)

Remove the AccessReason entry in the list.

Remove an identified value. 

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class OSPOspIdPrivacyPolicyAccessReasonsReasonIdDeleteExample
    {
        public void main()
        {
            
            var apiInstance = new DELETEApi();
            var ospId = ospId_example;  // string | The identifier number of an OSP
            var reasonId = reasonId_example;  // string | The identifier of a statement in a policy, is only unique to the policy.

            try
            {
                // Remove the AccessReason entry in the list.
                apiInstance.OSPOspIdPrivacyPolicyAccessReasonsReasonIdDelete(ospId, reasonId);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DELETEApi.OSPOspIdPrivacyPolicyAccessReasonsReasonIdDelete: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ospId** | **string**| The identifier number of an OSP | 
 **reasonId** | **string**| The identifier of a statement in a policy, is only unique to the policy. | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="regulationsregiddelete"></a>
# **RegulationsRegIdDelete**
> void RegulationsRegIdDelete (string regId)

Remove the PrivacyRegulation entry in the database.

Called when by the policy computation component when the regulator api requests that the regulation be deleted. 

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class RegulationsRegIdDeleteExample
    {
        public void main()
        {
            
            var apiInstance = new DELETEApi();
            var regId = regId_example;  // string | The identifier number of a regulation

            try
            {
                // Remove the PrivacyRegulation entry in the database.
                apiInstance.RegulationsRegIdDelete(regId);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DELETEApi.RegulationsRegIdDelete: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **regId** | **string**| The identifier number of a regulation | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="userprivacypolicyuseriddelete"></a>
# **UserPrivacyPolicyUserIdDelete**
> void UserPrivacyPolicyUserIdDelete (string userId)

Remove the UPP entry in the database for the user.

Called when a user leaves operando. Their privacy preferences and policies are deleted from the database. 

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class UserPrivacyPolicyUserIdDeleteExample
    {
        public void main()
        {
            
            var apiInstance = new DELETEApi();
            var userId = userId_example;  // string | The user identifier number

            try
            {
                // Remove the UPP entry in the database for the user.
                apiInstance.UserPrivacyPolicyUserIdDelete(userId);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DELETEApi.UserPrivacyPolicyUserIdDelete: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **userId** | **string**| The user identifier number | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

