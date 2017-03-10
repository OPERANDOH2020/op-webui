# IO.Swagger.Api.OSPApi

All URIs are relative to *http://operando.eu/policy_database*

Method | HTTP request | Description
------------- | ------------- | -------------
[**OSPGet**](OSPApi.md#ospget) | **GET** /OSP/ | Perform a search query across the collection of OSP behaviour.
[**OSPOspIdDelete**](OSPApi.md#ospospiddelete) | **DELETE** /OSP/{osp-id}/ | Remove the OSPRequest entry in the database.
[**OSPOspIdGet**](OSPApi.md#ospospidget) | **GET** /OSP/{osp-id}/ | Read a given OSP behaviour policy.
[**OSPOspIdPrivacyPolicyAccessReasonsGet**](OSPApi.md#ospospidprivacypolicyaccessreasonsget) | **GET** /OSP/{osp-id}/privacy-policy/access-reasons | Get the list of access reason policy statements.
[**OSPOspIdPrivacyPolicyAccessReasonsPost**](OSPApi.md#ospospidprivacypolicyaccessreasonspost) | **POST** /OSP/{osp-id}/privacy-policy/access-reasons | Create a new access reason statement in the privacy policy.
[**OSPOspIdPrivacyPolicyAccessReasonsReasonIdDelete**](OSPApi.md#ospospidprivacypolicyaccessreasonsreasoniddelete) | **DELETE** /OSP/{osp-id}/privacy-policy/access-reasons/{reason-id} | Remove the AccessReason entry in the list.
[**OSPOspIdPrivacyPolicyAccessReasonsReasonIdPut**](OSPApi.md#ospospidprivacypolicyaccessreasonsreasonidput) | **PUT** /OSP/{osp-id}/privacy-policy/access-reasons/{reason-id} | Update an access reason statement in the privacy policy.
[**OSPOspIdPrivacyPolicyGet**](OSPApi.md#ospospidprivacypolicyget) | **GET** /OSP/{osp-id}/privacy-policy/ | Get the current set of privacy policy statements about the usage of data for stated reasons.
[**OSPOspIdPrivacyPolicyPut**](OSPApi.md#ospospidprivacypolicyput) | **PUT** /OSP/{osp-id}/privacy-policy/ | Update OSP text policy entry in the database.
[**OSPOspIdPut**](OSPApi.md#ospospidput) | **PUT** /OSP/{osp-id}/ | Update OSPBehaviour entry in the database.
[**OSPPost**](OSPApi.md#osppost) | **POST** /OSP/ | Create a new OSP entry in the database.


<a name="ospget"></a>
# **OSPGet**
> List<OSPPrivacyPolicy> OSPGet (string filter)

Perform a search query across the collection of OSP behaviour.

The query contains a json object (names, values) and the request returns the list of documents (regulations) where the filter matches i.e. the document contains fields with those values. 

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class OSPGetExample
    {
        public void main()
        {
            
            var apiInstance = new OSPApi();
            var filter = filter_example;  // string | The query filter to be matched - ?filter={json description}

            try
            {
                // Perform a search query across the collection of OSP behaviour.
                List&lt;OSPPrivacyPolicy&gt; result = apiInstance.OSPGet(filter);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling OSPApi.OSPGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **filter** | **string**| The query filter to be matched - ?filter&#x3D;{json description} | 

### Return type

[**List<OSPPrivacyPolicy>**](OSPPrivacyPolicy.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

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
            
            var apiInstance = new OSPApi();
            var ospId = ospId_example;  // string | The identifier number of an OSP

            try
            {
                // Remove the OSPRequest entry in the database.
                apiInstance.OSPOspIdDelete(ospId);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling OSPApi.OSPOspIdDelete: " + e.Message );
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

<a name="ospospidget"></a>
# **OSPOspIdGet**
> OSPPrivacyPolicy OSPOspIdGet (string ospId)

Read a given OSP behaviour policy.

Get a specific OSP document via the id. This will return the full OSP document in json format. 

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class OSPOspIdGetExample
    {
        public void main()
        {
            
            var apiInstance = new OSPApi();
            var ospId = ospId_example;  // string | The identifier number of an OSP

            try
            {
                // Read a given OSP behaviour policy.
                OSPPrivacyPolicy result = apiInstance.OSPOspIdGet(ospId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling OSPApi.OSPOspIdGet: " + e.Message );
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

[**OSPPrivacyPolicy**](OSPPrivacyPolicy.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="ospospidprivacypolicyaccessreasonsget"></a>
# **OSPOspIdPrivacyPolicyAccessReasonsGet**
> List<OSPReasonPolicy> OSPOspIdPrivacyPolicyAccessReasonsGet (string ospId)

Get the list of access reason policy statements.

List of policy statements.  

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class OSPOspIdPrivacyPolicyAccessReasonsGetExample
    {
        public void main()
        {
            
            var apiInstance = new OSPApi();
            var ospId = ospId_example;  // string | The identifier number of an OSP

            try
            {
                // Get the list of access reason policy statements.
                List&lt;OSPReasonPolicy&gt; result = apiInstance.OSPOspIdPrivacyPolicyAccessReasonsGet(ospId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling OSPApi.OSPOspIdPrivacyPolicyAccessReasonsGet: " + e.Message );
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

[**List<OSPReasonPolicy>**](OSPReasonPolicy.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

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
            
            var apiInstance = new OSPApi();
            var ospId = ospId_example;  // string | The identifier number of an OSP
            var ospPolicy = new AccessReason(); // AccessReason | The first instance of this new statement.

            try
            {
                // Create a new access reason statement in the privacy policy.
                apiInstance.OSPOspIdPrivacyPolicyAccessReasonsPost(ospId, ospPolicy);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling OSPApi.OSPOspIdPrivacyPolicyAccessReasonsPost: " + e.Message );
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
            
            var apiInstance = new OSPApi();
            var ospId = ospId_example;  // string | The identifier number of an OSP
            var reasonId = reasonId_example;  // string | The identifier of a statement in a policy, is only unique to the policy.

            try
            {
                // Remove the AccessReason entry in the list.
                apiInstance.OSPOspIdPrivacyPolicyAccessReasonsReasonIdDelete(ospId, reasonId);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling OSPApi.OSPOspIdPrivacyPolicyAccessReasonsReasonIdDelete: " + e.Message );
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
            
            var apiInstance = new OSPApi();
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
                Debug.Print("Exception when calling OSPApi.OSPOspIdPrivacyPolicyAccessReasonsReasonIdPut: " + e.Message );
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

<a name="ospospidprivacypolicyget"></a>
# **OSPOspIdPrivacyPolicyGet**
> OSPReasonPolicy OSPOspIdPrivacyPolicyGet (string ospId)

Get the current set of privacy policy statements about the usage of data for stated reasons.

This is a machine readable version of a G2C privacy policy statement entered using the OSP Admin dashboard; and retrieved by both the OSP & PSP analyst dashboard for display purposes and also by the OSE component for checking regulation compliance.  

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class OSPOspIdPrivacyPolicyGetExample
    {
        public void main()
        {
            
            var apiInstance = new OSPApi();
            var ospId = ospId_example;  // string | The identifier number of an OSP

            try
            {
                // Get the current set of privacy policy statements about the usage of data for stated reasons.
                OSPReasonPolicy result = apiInstance.OSPOspIdPrivacyPolicyGet(ospId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling OSPApi.OSPOspIdPrivacyPolicyGet: " + e.Message );
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

[**OSPReasonPolicy**](OSPReasonPolicy.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="ospospidprivacypolicyput"></a>
# **OSPOspIdPrivacyPolicyPut**
> void OSPOspIdPrivacyPolicyPut (string ospId, OSPReasonPolicyInput ospPolicy)

Update OSP text policy entry in the database.

Called when by the watchdog detects a change in the textual policy and wants to update the current policy. 

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class OSPOspIdPrivacyPolicyPutExample
    {
        public void main()
        {
            
            var apiInstance = new OSPApi();
            var ospId = ospId_example;  // string | The identifier number of an OSP
            var ospPolicy = new OSPReasonPolicyInput(); // OSPReasonPolicyInput | The changed instance of this OSPRequest

            try
            {
                // Update OSP text policy entry in the database.
                apiInstance.OSPOspIdPrivacyPolicyPut(ospId, ospPolicy);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling OSPApi.OSPOspIdPrivacyPolicyPut: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ospId** | **string**| The identifier number of an OSP | 
 **ospPolicy** | [**OSPReasonPolicyInput**](OSPReasonPolicyInput.md)| The changed instance of this OSPRequest | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

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
            
            var apiInstance = new OSPApi();
            var ospId = ospId_example;  // string | The identifier number of an OSP
            var ospPolicy = new OSPPrivacyPolicyInput(); // OSPPrivacyPolicyInput | The changed instance of this OSPRequest

            try
            {
                // Update OSPBehaviour entry in the database.
                apiInstance.OSPOspIdPut(ospId, ospPolicy);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling OSPApi.OSPOspIdPut: " + e.Message );
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
            
            var apiInstance = new OSPApi();
            var ospPolicy = new OSPPrivacyPolicyInput(); // OSPPrivacyPolicyInput | The first instance of this OSP document

            try
            {
                // Create a new OSP entry in the database.
                string result = apiInstance.OSPPost(ospPolicy);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling OSPApi.OSPPost: " + e.Message );
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

