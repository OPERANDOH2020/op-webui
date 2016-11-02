# IO.Swagger.Api.PrivacyLegislationApi

All URIs are relative to *http://operando.eu/*

Method | HTTP request | Description
------------- | ------------- | -------------
[**RegulationsPost**](PrivacyLegislationApi.md#regulationspost) | **POST** /regulations/ | 
[**RegulationsRegIdPut**](PrivacyLegislationApi.md#regulationsregidput) | **PUT** /regulations/{reg-id}/ | 


<a name="regulationspost"></a>
# **RegulationsPost**
> void RegulationsPost (PrivacyRegulation regulation)



Called by the Regulator API. A New regulation is entered into OPERANDO. Existing OSPs are then evaluated to see if they comply with the regulation. If not they are sent a report about how to comply. 

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

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **regulation** | [**PrivacyRegulation**](PrivacyRegulation.md)| The description of the new regulation. | 

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



Called by the Regulator API. A change to a regulation is entered into OPERANDO. Existing OSPs are then evaluated to see if they comply with the regulation. If not they are sent a report about how to comply.      Pre-condition - - The regulation must have been written to the system.    

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
            
            var apiInstance = new PrivacyLegislationApi();
            var regId = regId_example;  // string | The identifier number of a regulation
            var regulation = new PrivacyRegulationInput(); // PrivacyRegulationInput | The description of the changed regulation.

            try
            {
                apiInstance.RegulationsRegIdPut(regId, regulation);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling PrivacyLegislationApi.RegulationsRegIdPut: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **regId** | **string**| The identifier number of a regulation | 
 **regulation** | [**PrivacyRegulationInput**](PrivacyRegulationInput.md)| The description of the changed regulation. | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

