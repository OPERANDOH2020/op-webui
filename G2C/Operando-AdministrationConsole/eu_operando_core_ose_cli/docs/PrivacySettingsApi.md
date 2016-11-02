# IO.Swagger.Api.PrivacySettingsApi

All URIs are relative to *http://operando.eu/*

Method | HTTP request | Description
------------- | ------------- | -------------
[**OspsOspIdPrivacySettingsGet**](PrivacySettingsApi.md#ospsospidprivacysettingsget) | **GET** /osps/{osp-id}/privacy_settings/ | 
[**OspsOspIdPrivacySettingsPut**](PrivacySettingsApi.md#ospsospidprivacysettingsput) | **PUT** /osps/{osp-id}/privacy_settings/ | 


<a name="ospsospidprivacysettingsget"></a>
# **OspsOspIdPrivacySettingsGet**
> List<PrivacySetting> OspsOspIdPrivacySettingsGet (string ospId, string userId)



Simple retrieval of an OPERANDO registered OSP's privacy settings. This method is called by the watchdog component when it requests the settings last applied by the OSE component.  Pre condition - - An OPERANDO user must have registered with the OPERANDO platform and subscribed to the OSP service in question.  Pre condition - -The user's UPP must be stored in the Policy DB component and contain the privacy settings for the OSP service in question.  When the query includes a user id; that user's settings are returned. For a request with no user id as a query parameter, the operation returns the general set of settings covered by this OSP. 

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class OspsOspIdPrivacySettingsGetExample
    {
        public void main()
        {
            
            var apiInstance = new PrivacySettingsApi();
            var ospId = ospId_example;  // string | The identifier number of an OSP
            var userId = userId_example;  // string | The user identifier number

            try
            {
                List&lt;PrivacySetting&gt; result = apiInstance.OspsOspIdPrivacySettingsGet(ospId, userId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling PrivacySettingsApi.OspsOspIdPrivacySettingsGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ospId** | **string**| The identifier number of an OSP | 
 **userId** | **string**| The user identifier number | 

### Return type

[**List<PrivacySetting>**](PrivacySetting.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="ospsospidprivacysettingsput"></a>
# **OspsOspIdPrivacySettingsPut**
> void OspsOspIdPrivacySettingsPut (string ospId, string userId, List<PrivacySetting> ospSettings)



Called when a change in privacy settings is detected at a specific OSP. The OSE evaluates the impact of the changed settings and computes the required new settings and ensures that they are enforced at the OSP and the new settings stored in the policy DB. 

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class OspsOspIdPrivacySettingsPutExample
    {
        public void main()
        {
            
            var apiInstance = new PrivacySettingsApi();
            var ospId = ospId_example;  // string | The identifier number of an OSP
            var userId = userId_example;  // string | The user identifier number
            var ospSettings = new List<PrivacySetting>(); // List<PrivacySetting> | The set of settings that have now changed. This is the complete OSP settings list to be compared with the existing stored settings for this OSP for the user.

            try
            {
                apiInstance.OspsOspIdPrivacySettingsPut(ospId, userId, ospSettings);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling PrivacySettingsApi.OspsOspIdPrivacySettingsPut: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ospId** | **string**| The identifier number of an OSP | 
 **userId** | **string**| The user identifier number | 
 **ospSettings** | [**List<PrivacySetting>**](PrivacySetting.md)| The set of settings that have now changed. This is the complete OSP settings list to be compared with the existing stored settings for this OSP for the user. | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

