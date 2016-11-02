# IO.Swagger.Api.POSTApi

All URIs are relative to *http://operando.eu/policy_database*

Method | HTTP request | Description
------------- | ------------- | -------------
[**OSPPost**](POSTApi.md#osppost) | **POST** /OSP/ | Create a new OSP entry in the database.
[**RegulationsPost**](POSTApi.md#regulationspost) | **POST** /regulations/ | Create a new legislation entry in the database.
[**UserPrivacyPolicyPost**](POSTApi.md#userprivacypolicypost) | **POST** /user_privacy_policy/ | Create a new UPP entry in the database for the user.


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
            
            var apiInstance = new POSTApi();
            var ospPolicy = new OSPPrivacyPolicyInput(); // OSPPrivacyPolicyInput | The first instance of this OSP document

            try
            {
                // Create a new OSP entry in the database.
                apiInstance.OSPPost(ospPolicy);
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

void (empty response body)

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
> void UserPrivacyPolicyPost (UserPrivacyPolicy upp)

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
                apiInstance.UserPrivacyPolicyPost(upp);
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

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

