# IO.Swagger.Api.UPPApi

All URIs are relative to *http://operando.eu/policy_database*

Method | HTTP request | Description
------------- | ------------- | -------------
[**UserPrivacyPolicyGet**](UPPApi.md#userprivacypolicyget) | **GET** /user_privacy_policy/ | Perform a search query across the collection of UPPs.
[**UserPrivacyPolicyPost**](UPPApi.md#userprivacypolicypost) | **POST** /user_privacy_policy/ | Create a new UPP entry in the database for the user.
[**UserPrivacyPolicyUserIdDelete**](UPPApi.md#userprivacypolicyuseriddelete) | **DELETE** /user_privacy_policy/{user-id}/ | Remove the UPP entry in the database for the user.
[**UserPrivacyPolicyUserIdGet**](UPPApi.md#userprivacypolicyuseridget) | **GET** /user_privacy_policy/{user-id}/ | Read the user privacy policy for the given user id.
[**UserPrivacyPolicyUserIdPut**](UPPApi.md#userprivacypolicyuseridput) | **PUT** /user_privacy_policy/{user-id}/ | Update UPP entry in the database for the user.


<a name="userprivacypolicyget"></a>
# **UserPrivacyPolicyGet**
> List<UserPrivacyPolicy> UserPrivacyPolicyGet (string filter)

Perform a search query across the collection of UPPs.

The query contains a json object (names, values) and the request returns the list of documents (UPPs) where the filter matches i.e. each document contains fields with those values. 

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class UserPrivacyPolicyGetExample
    {
        public void main()
        {
            
            var apiInstance = new UPPApi();
            var filter = filter_example;  // string | The query filter to be matched - ?filter={json description}

            try
            {
                // Perform a search query across the collection of UPPs.
                List&lt;UserPrivacyPolicy&gt; result = apiInstance.UserPrivacyPolicyGet(filter);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling UPPApi.UserPrivacyPolicyGet: " + e.Message );
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

[**List<UserPrivacyPolicy>**](UserPrivacyPolicy.md)

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
            
            var apiInstance = new UPPApi();
            var upp = new UserPrivacyPolicy(); // UserPrivacyPolicy | The first instance of this user's UPP

            try
            {
                // Create a new UPP entry in the database for the user.
                apiInstance.UserPrivacyPolicyPost(upp);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling UPPApi.UserPrivacyPolicyPost: " + e.Message );
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

<a name="userprivacypolicyuseriddelete"></a>
# **UserPrivacyPolicyUserIdDelete**
> void UserPrivacyPolicyUserIdDelete (string userId)

Remove the UPP entry in the database for the user.

Called when a user leaves operando. Their privacy preferences and policies are deleted from the database. 

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class UserPrivacyPolicyUserIdDeleteExample
    {
        public void main()
        {
            
            var apiInstance = new UPPApi();
            var userId = userId_example;  // string | The user identifier number

            try
            {
                // Remove the UPP entry in the database for the user.
                apiInstance.UserPrivacyPolicyUserIdDelete(userId);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling UPPApi.UserPrivacyPolicyUserIdDelete: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **userId** | **string**| The user identifier number | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="userprivacypolicyuseridget"></a>
# **UserPrivacyPolicyUserIdGet**
> UserPrivacyPolicy UserPrivacyPolicyUserIdGet (string userId)

Read the user privacy policy for the given user id.

Get a specific UPP document via the user's id. This will return the full user privacy policy document in json format. 

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class UserPrivacyPolicyUserIdGetExample
    {
        public void main()
        {
            
            var apiInstance = new UPPApi();
            var userId = userId_example;  // string | The user identifier number

            try
            {
                // Read the user privacy policy for the given user id.
                UserPrivacyPolicy result = apiInstance.UserPrivacyPolicyUserIdGet(userId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling UPPApi.UserPrivacyPolicyUserIdGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **userId** | **string**| The user identifier number | 

### Return type

[**UserPrivacyPolicy**](UserPrivacyPolicy.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="userprivacypolicyuseridput"></a>
# **UserPrivacyPolicyUserIdPut**
> void UserPrivacyPolicyUserIdPut (string userId, UserPrivacyPolicy upp)

Update UPP entry in the database for the user.

Called when a user makes a change to the UPP registered with operando. Their new privacy preferences are passed in the UPP document and stored in the policy DB. 

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class UserPrivacyPolicyUserIdPutExample
    {
        public void main()
        {
            
            var apiInstance = new UPPApi();
            var userId = userId_example;  // string | The user identifier number
            var upp = new UserPrivacyPolicy(); // UserPrivacyPolicy | The changed instance of this user's UPP

            try
            {
                // Update UPP entry in the database for the user.
                apiInstance.UserPrivacyPolicyUserIdPut(userId, upp);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling UPPApi.UserPrivacyPolicyUserIdPut: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **userId** | **string**| The user identifier number | 
 **upp** | [**UserPrivacyPolicy**](UserPrivacyPolicy.md)| The changed instance of this user&#39;s UPP | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

