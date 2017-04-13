# IO.Swagger.Api.POSTCPCUApi

All URIs are relative to *https://localhost:8080/operandocpcu*

Method | HTTP request | Description
------------- | ------------- | -------------
[**PostCPCUPOST**](POSTCPCUApi.md#postcpcupost) | **POST** /cpcu/{userID}/{serviceID}/{questionnaireID} | Reply to questionnaire


<a name="postcpcupost"></a>
# **PostCPCUPOST**
> QNRootObject PostCPCUPOST (string userID, int? serviceID, int? questionnaireID, QNRootObject qn)

Reply to questionnaire

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class PostCPCUPOSTExample
    {
        public void main()
        {
            
            var apiInstance = new POSTCPCUApi();
            var userID = userID_example;  // string | userID
            var serviceID = 56;  // int? | service ID
            var questionnaireID = 56;  // int? | questionnaire ID
            var qn = new QNRootObject(); // QNRootObject | questionnaire answered

            try
            {
                // Reply to questionnaire
                QNRootObject result = apiInstance.PostCPCUPOST(userID, serviceID, questionnaireID, qn);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling POSTCPCUApi.PostCPCUPOST: " + e.Message );
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
 **qn** | [**QNRootObject**](QNRootObject.md)| questionnaire answered | 

### Return type

[**QNRootObject**](QNRootObject.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

