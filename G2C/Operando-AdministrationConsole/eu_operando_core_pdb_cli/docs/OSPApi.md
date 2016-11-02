# IO.Swagger.Api.OSPApi

All URIs are relative to *http://operando.eu/policy_database*

Method | HTTP request | Description
------------- | ------------- | -------------
[**OSPGet**](OSPApi.md#ospget) | **GET** /OSP/ | Perform a search query across the collection of OSP behaviour.
[**OSPOspIdDelete**](OSPApi.md#ospospiddelete) | **DELETE** /OSP/{osp-id}/ | Remove the OSPRequest entry in the database.
[**OSPOspIdGet**](OSPApi.md#ospospidget) | **GET** /OSP/{osp-id}/ | Read a given OSP behaviour policy.
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
> void OSPPost (OSPPrivacyPolicyInput ospPolicy)

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
                apiInstance.OSPPost(ospPolicy);
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

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

