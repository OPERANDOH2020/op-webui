# IO.Swagger.Api.GETCPCUApi

All URIs are relative to *https://localhost:8080/operandocpcu*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetCPCUGET**](GETCPCUApi.md#getcpcuget) | **GET** /cpcu/{userID}/{serviceID}/{questionnaireID} | Get service specific questionnaire


<a name="getcpcuget"></a>
# **GetCPCUGET**
> QNRootObject GetCPCUGET (string userID, int? serviceID, int? questionnaireID)

Get service specific questionnaire

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetCPCUGETExample
    {
        public void main()
        {
            
            var apiInstance = new GETCPCUApi();
            var userID = userID_example;  // string | userID
            var serviceID = 56;  // int? | service ID
            var questionnaireID = 56;  // int? | questionnaire ID

            try
            {
                // Get service specific questionnaire
                QNRootObject result = apiInstance.GetCPCUGET(userID, serviceID, questionnaireID);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling GETCPCUApi.GetCPCUGET: " + e.Message );
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
 **questionnaireID** | **int?**| questionnaire ID | 

### Return type

[**QNRootObject**](QNRootObject.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json, */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

