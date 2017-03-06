# IO.Swagger.Api.LegislationApi

All URIs are relative to *http://operando.eu/policy_database*

Method | HTTP request | Description
------------- | ------------- | -------------
[**RegulationsGet**](LegislationApi.md#regulationsget) | **GET** /regulations/ | Perform a search query across the collection of regulation.
[**RegulationsPost**](LegislationApi.md#regulationspost) | **POST** /regulations/ | Create a new legislation entry in the database.
[**RegulationsRegIdDelete**](LegislationApi.md#regulationsregiddelete) | **DELETE** /regulations/{reg-id}/ | Remove the PrivacyRegulation entry in the database.
[**RegulationsRegIdGet**](LegislationApi.md#regulationsregidget) | **GET** /regulations/{reg-id}/ | Read a given legislation with its ID.
[**RegulationsRegIdPut**](LegislationApi.md#regulationsregidput) | **PUT** /regulations/{reg-id}/ | Update PrivacyRegulation entry in the database.


<a name="regulationsget"></a>
# **RegulationsGet**
> List<PrivacyRegulation> RegulationsGet (string filter)

Perform a search query across the collection of regulation.

The query contains a json object (names, values) and the request returns  the list of documents (regulations) where the filter matches i.e. the  document contains fields with those values. 

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class RegulationsGetExample
    {
        public void main()
        {
            
            var apiInstance = new LegislationApi();
            var filter = filter_example;  // string | The query filter to be matched - ?filter={json description}

            try
            {
                // Perform a search query across the collection of regulation.
                List&lt;PrivacyRegulation&gt; result = apiInstance.RegulationsGet(filter);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling LegislationApi.RegulationsGet: " + e.Message );
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

[**List<PrivacyRegulation>**](PrivacyRegulation.md)

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
            
            var apiInstance = new LegislationApi();
            var regulation = new PrivacyRegulationInput(); // PrivacyRegulationInput | The first instance of this regulation document

            try
            {
                // Create a new legislation entry in the database.
                PrivacyRegulation result = apiInstance.RegulationsPost(regulation);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling LegislationApi.RegulationsPost: " + e.Message );
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
            
            var apiInstance = new LegislationApi();
            var regId = regId_example;  // string | The identifier number of a regulation

            try
            {
                // Remove the PrivacyRegulation entry in the database.
                apiInstance.RegulationsRegIdDelete(regId);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling LegislationApi.RegulationsRegIdDelete: " + e.Message );
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

<a name="regulationsregidget"></a>
# **RegulationsRegIdGet**
> PrivacyRegulation RegulationsRegIdGet (string regId)

Read a given legislation with its ID.

Get a specific legislation document via the id. This will return the  full legislation document in json format. 

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class RegulationsRegIdGetExample
    {
        public void main()
        {
            
            var apiInstance = new LegislationApi();
            var regId = regId_example;  // string | The identifier number of a regulation

            try
            {
                // Read a given legislation with its ID.
                PrivacyRegulation result = apiInstance.RegulationsRegIdGet(regId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling LegislationApi.RegulationsRegIdGet: " + e.Message );
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

[**PrivacyRegulation**](PrivacyRegulation.md)

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
            
            var apiInstance = new LegislationApi();
            var regId = regId_example;  // string | The identifier number of a regulation
            var regulation = new PrivacyRegulationInput(); // PrivacyRegulationInput | The changed instance of this PrivacyRegulation

            try
            {
                // Update PrivacyRegulation entry in the database.
                apiInstance.RegulationsRegIdPut(regId, regulation);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling LegislationApi.RegulationsRegIdPut: " + e.Message );
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

