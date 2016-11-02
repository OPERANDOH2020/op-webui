# IO.Swagger.Api.PrivacyPolicyApi

All URIs are relative to *http://operando.eu/*

Method | HTTP request | Description
------------- | ------------- | -------------
[**OspsOspIdPrivacytextPut**](PrivacyPolicyApi.md#ospsospidprivacytextput) | **PUT** /osps/{osp-id}/privacytext/ | 
[**OspsOspIdPut**](PrivacyPolicyApi.md#ospsospidput) | **PUT** /osps/{osp-id}/ | 
[**OspsOspIdWorkflowsPut**](PrivacyPolicyApi.md#ospsospidworkflowsput) | **PUT** /osps/{osp-id}/workflows/ | 


<a name="ospsospidprivacytextput"></a>
# **OspsOspIdPrivacytextPut**
> void OspsOspIdPrivacytextPut (string ospId, string ospPrivacyText)



Notify the OSE of a change in policy text 

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class OspsOspIdPrivacytextPutExample
    {
        public void main()
        {
            
            var apiInstance = new PrivacyPolicyApi();
            var ospId = ospId_example;  // string | The identifier number of an OSP
            var ospPrivacyText = ospPrivacyText_example;  // string | The complete privacy policy text of the OSP.

            try
            {
                apiInstance.OspsOspIdPrivacytextPut(ospId, ospPrivacyText);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling PrivacyPolicyApi.OspsOspIdPrivacytextPut: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ospId** | **string**| The identifier number of an OSP | 
 **ospPrivacyText** | **string**| The complete privacy policy text of the OSP. | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="ospsospidput"></a>
# **OspsOspIdPut**
> void OspsOspIdPut (string ospId, OSPPrivacyPolicy ospPolicy)



Called when a change in an OSP's privacy policy detected by OPERANDO (or a new OSP is registered). OSE computes whether the OSP policy complies with regulations; complies with UPP. It updates UPPs where appropriate and notifies users and OSP if there are issues with the updated privacy policy.    Pre-condition - - The OSP must be registered with OPERANDO and it must have an existing policy stored in the policy DB.    

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class OspsOspIdPutExample
    {
        public void main()
        {
            
            var apiInstance = new PrivacyPolicyApi();
            var ospId = ospId_example;  // string | The identifier number of an OSP
            var ospPolicy = new OSPPrivacyPolicy(); // OSPPrivacyPolicy | The set of individual policies that have now compose the OSP's new privacy policy. This is the complete OSP list of the policies to be compared with the existing stored policy for this OSP.

            try
            {
                apiInstance.OspsOspIdPut(ospId, ospPolicy);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling PrivacyPolicyApi.OspsOspIdPut: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ospId** | **string**| The identifier number of an OSP | 
 **ospPolicy** | [**OSPPrivacyPolicy**](OSPPrivacyPolicy.md)| The set of individual policies that have now compose the OSP&#39;s new privacy policy. This is the complete OSP list of the policies to be compared with the existing stored policy for this OSP. | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="ospsospidworkflowsput"></a>
# **OspsOspIdWorkflowsPut**
> void OspsOspIdWorkflowsPut (string ospId, OSPDataRequest ospWorkflow)



Notify the OSE of a change in an OSP's workflow 

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class OspsOspIdWorkflowsPutExample
    {
        public void main()
        {
            
            var apiInstance = new PrivacyPolicyApi();
            var ospId = ospId_example;  // string | The identifier number of an OSP
            var ospWorkflow = new OSPDataRequest(); // OSPDataRequest | The workflow changes of the OSP.

            try
            {
                apiInstance.OspsOspIdWorkflowsPut(ospId, ospWorkflow);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling PrivacyPolicyApi.OspsOspIdWorkflowsPut: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ospId** | **string**| The identifier number of an OSP | 
 **ospWorkflow** | [**OSPDataRequest**](OSPDataRequest.md)| The workflow changes of the OSP. | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

