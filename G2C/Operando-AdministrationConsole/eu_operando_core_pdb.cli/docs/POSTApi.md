# IO.Swagger.Api.POSTApi

All URIs are relative to *http://operando.eu/policy_database*

Method | HTTP request | Description
------------- | ------------- | -------------
[**OSPOspIdPrivacyPolicyAccessReasonsPost**](POSTApi.md#ospospidprivacypolicyaccessreasonspost) | **POST** /OSP/{osp-id}/privacy-policy/access-reasons | Create a new access reason statement in the privacy policy.
[**OSPOspIdPrivacyPolicyAccessReasonsReasonIdPut**](POSTApi.md#ospospidprivacypolicyaccessreasonsreasonidput) | **PUT** /OSP/{osp-id}/privacy-policy/access-reasons/{reason-id} | Update an access reason statement in the privacy policy.
[**OSPPost**](POSTApi.md#osppost) | **POST** /OSP/ | Create a new OSP entry in the database.
[**RegulationsPost**](POSTApi.md#regulationspost) | **POST** /regulations/ | Create a new legislation entry in the database.
[**UserPrivacyPolicyPost**](POSTApi.md#userprivacypolicypost) | **POST** /user_privacy_policy/ | Create a new UPP entry in the database for the user.


<a name="ospospidprivacypolicyaccessreasonspost"></a>
# **OSPOspIdPrivacyPolicyAccessReasonsPost**
> void OSPOspIdPrivacyPolicyAccessReasonsPost (string ospId, AccessReason ospPolicy)

Create a new access reason statement in the privacy policy.

Called by the UI when OSP updating the policy statements 

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class OSPOspIdPrivacyPolicyAccessReasonsPostExample
    {
        public void main()
        {
            
            var apiInstance = new POSTApi();
            var ospId = ospId_example;  // string | The identifier number of an OSP
            var ospPolicy = new AccessReason(); // AccessReason | The first instance of this new statement.

            try
            {
                // Create a new access reason statement in the privacy policy.
                apiInstance.OSPOspIdPrivacyPolicyAccessReasonsPost(ospId, ospPolicy);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling POSTApi.OSPOspIdPrivacyPolicyAccessReasonsPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ospId** | **string**| The identifier number of an OSP | 
 **ospPolicy** | [**AccessReason**](AccessReason.md)| The first instance of this new statement. | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="ospospidprivacypolicyaccessreasonsreasonidput"></a>
# **OSPOspIdPrivacyPolicyAccessReasonsReasonIdPut**
> void OSPOspIdPrivacyPolicyAccessReasonsReasonIdPut (string ospId, string reasonId, AccessReason ospPolicy)

Update an access reason statement in the privacy policy.

Called by the UI when OSP updating the policy statements 

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class OSPOspIdPrivacyPolicyAccessReasonsReasonIdPutExample
    {
        public void main()
        {
            
            var apiInstance = new POSTApi();
            var ospId = ospId_example;  // string | The identifier number of an OSP
            var reasonId = reasonId_example;  // string | The identifier of a statement in a policy, is only unique to the policy.
            var ospPolicy = new AccessReason(); // AccessReason | The updated instance of this OSP policy statement.

            try
            {
                // Update an access reason statement in the privacy policy.
                apiInstance.OSPOspIdPrivacyPolicyAccessReasonsReasonIdPut(ospId, reasonId, ospPolicy);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling POSTApi.OSPOspIdPrivacyPolicyAccessReasonsReasonIdPut: " + e.Message );
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
 **ospPolicy** | [**AccessReason**](AccessReason.md)| The updated instance of this OSP policy statement. | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="osppost"></a>
# **OSPPost**
> string OSPPost (OSPPrivacyPolicyInput ospPolicy)

Create a new OSP entry in the database.

Called by the policy computation component when a new regulation is added to OPERANDO. 

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class OSPPostExample
    {
        public void main()
        {
            
            var apiInstance = new POSTApi();
            var ospPolicy = new OSPPrivacyPolicyInput(); // OSPPrivacyPolicyInput | The first instance of this OSP document

            try
            {
                // Create a new OSP entry in the database.
                string result = apiInstance.OSPPost(ospPolicy);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling POSTApi.OSPPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ospPolicy** | [**OSPPrivacyPolicyInput**](OSPPrivacyPolicyInput.md)| The first instance of this OSP document | 

### Return type

**string**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="regulationspost"></a>
# **RegulationsPost**
> PrivacyRegulation RegulationsPost (PrivacyRegulationInput regulation)

Create a new legislation entry in the database.

Called by the policy computation component when a new regulation is added to OPERANDO. 

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class RegulationsPostExample
    {
        public void main()
        {
            
            var apiInstance = new POSTApi();
            var regulation = new PrivacyRegulationInput(); // PrivacyRegulationInput | The first instance of this regulation document

            try
            {
                // Create a new legislation entry in the database.
                PrivacyRegulation result = apiInstance.RegulationsPost(regulation);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling POSTApi.RegulationsPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **regulation** | [**PrivacyRegulationInput**](PrivacyRegulationInput.md)| The first instance of this regulation document | 

### Return type

[**PrivacyRegulation**](PrivacyRegulation.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="userprivacypolicypost"></a>
# **UserPrivacyPolicyPost**
> string UserPrivacyPolicyPost (UserPrivacyPolicy upp)

Create a new UPP entry in the database for the user.

Called when a new user is registered with operando. Their new privacy preferences are passed in the UPP document and stored in the policy DB. 

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class UserPrivacyPolicyPostExample
    {
        public void main()
        {
            
            var apiInstance = new POSTApi();
            var upp = new UserPrivacyPolicy(); // UserPrivacyPolicy | The first instance of this user's UPP

            try
            {
                // Create a new UPP entry in the database for the user.
                string result = apiInstance.UserPrivacyPolicyPost(upp);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling POSTApi.UserPrivacyPolicyPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **upp** | [**UserPrivacyPolicy**](UserPrivacyPolicy.md)| The first instance of this user&#39;s UPP | 

### Return type

**string**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

