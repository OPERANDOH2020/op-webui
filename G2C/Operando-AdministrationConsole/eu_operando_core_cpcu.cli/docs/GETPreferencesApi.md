# IO.Swagger.Api.GETPreferencesApi

All URIs are relative to *https://localhost:8080/operandocpcu*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetPreferencesGET**](GETPreferencesApi.md#getpreferencesget) | **GET** /cpcu/{userID}/{serviceID}/ | Get service specific questionnaire preferences


<a name="getpreferencesget"></a>
# **GetPreferencesGET**
> PrefRootObject GetPreferencesGET (string userID, int? serviceID)

Get service specific questionnaire preferences

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetPreferencesGETExample
    {
        public void main()
        {
            
            var apiInstance = new GETPreferencesApi();
            var userID = userID_example;  // string | userID
            var serviceID = 56;  // int? | service ID

            try
            {
                // Get service specific questionnaire preferences
                PrefRootObject result = apiInstance.GetPreferencesGET(userID, serviceID);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling GETPreferencesApi.GetPreferencesGET: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **userID** | **string**| userID | 
 **serviceID** | **int?**| service ID | 

### Return type

[**PrefRootObject**](PrefRootObject.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json, */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

