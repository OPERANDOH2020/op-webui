# IO.Swagger.Api.DefaultApi

All URIs are relative to *https://localhost:8080/operando/interfaces/authentication*

Method | HTTP request | Description
------------- | ------------- | -------------
[**AapiTicketsPost**](DefaultApi.md#aapiticketspost) | **POST** /aapi/tickets |  This operation makes a request for a ticket granting ticket (TGT) to the AAPI, which is the session key for the application SSO session. This operation should be called the very first time for an application to be authenticated  to OPERANDOs CAS server, through a login form.
[**AapiTicketsStValidateGet**](DefaultApi.md#aapiticketsstvalidateget) | **GET** /aapi/tickets/{st}/validate | 
[**AapiTicketsTgtPost**](DefaultApi.md#aapiticketstgtpost) | **POST** /aapi/tickets/{tgt} |  This operation makes a request for a service ticket (ST) to the AAPI, which is the authorization ticket for a specific protected service of OPERANDOs system. This operation should be called each time the user tried to access a protected service
[**AapiUserRegisterPost**](DefaultApi.md#aapiuserregisterpost) | **POST** /aapi/user/register | This operation registers a user to OPERANDOs platform.
[**UserUsernameDelete**](DefaultApi.md#userusernamedelete) | **DELETE** /user/{username} | 
[**UserUsernameGet**](DefaultApi.md#userusernameget) | **GET** /user/{username} | This operation returns the OPERANDOs registed user with given username
[**UserUsernamePut**](DefaultApi.md#userusernameput) | **PUT** /user/{username} | 


<a name="aapiticketspost"></a>
# **AapiTicketsPost**
> string AapiTicketsPost (UserCredential userCredential)

 This operation makes a request for a ticket granting ticket (TGT) to the AAPI, which is the session key for the application SSO session. This operation should be called the very first time for an application to be authenticated  to OPERANDOs CAS server, through a login form.

Login to AS and issue a session ticket (tgt)

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class AapiTicketsPostExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();
            var userCredential = new UserCredential(); // UserCredential | Users username, password

            try
            {
                //  This operation makes a request for a ticket granting ticket (TGT) to the AAPI, which is the session key for the application SSO session. This operation should be called the very first time for an application to be authenticated  to OPERANDOs CAS server, through a login form.
                string result = apiInstance.AapiTicketsPost(userCredential);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.AapiTicketsPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **userCredential** | [**UserCredential**](UserCredential.md)| Users username, password | 

### Return type

**string**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="aapiticketsstvalidateget"></a>
# **AapiTicketsStValidateGet**
> void AapiTicketsStValidateGet (string st, string serviceId)



Validate the service ticket (ST)

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class AapiTicketsStValidateGetExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();
            var st = st_example;  // string | service ticket (ST)
            var serviceId = serviceId_example;  // string | service identifier

            try
            {
                // 
                apiInstance.AapiTicketsStValidateGet(st, serviceId);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.AapiTicketsStValidateGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **st** | **string**| service ticket (ST) | 
 **serviceId** | **string**| service identifier | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="aapiticketstgtpost"></a>
# **AapiTicketsTgtPost**
> string AapiTicketsTgtPost (string tgt, string serviceId)

 This operation makes a request for a service ticket (ST) to the AAPI, which is the authorization ticket for a specific protected service of OPERANDOs system. This operation should be called each time the user tried to access a protected service

Request a service ticket (ST) for the service with id serviceId

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class AapiTicketsTgtPostExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();
            var tgt = tgt_example;  // string | Users session ticket (TGT)
            var serviceId = serviceId_example;  // string | Services endpoint

            try
            {
                //  This operation makes a request for a service ticket (ST) to the AAPI, which is the authorization ticket for a specific protected service of OPERANDOs system. This operation should be called each time the user tried to access a protected service
                string result = apiInstance.AapiTicketsTgtPost(tgt, serviceId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.AapiTicketsTgtPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **tgt** | **string**| Users session ticket (TGT) | 
 **serviceId** | **string**| Services endpoint | 

### Return type

**string**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="aapiuserregisterpost"></a>
# **AapiUserRegisterPost**
> User AapiUserRegisterPost (User user)

This operation registers a user to OPERANDOs platform.

This operation registers a user to OPERANDOs platform.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class AapiUserRegisterPostExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();
            var user = new User(); // User | User description

            try
            {
                // This operation registers a user to OPERANDOs platform.
                User result = apiInstance.AapiUserRegisterPost(user);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.AapiUserRegisterPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **user** | [**User**](User.md)| User description | 

### Return type

[**User**](User.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="userusernamedelete"></a>
# **UserUsernameDelete**
> User UserUsernameDelete (string username)



Delete ASs registed user with corresponding username

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class UserUsernameDeleteExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();
            var username = username_example;  // string | Users username

            try
            {
                // 
                User result = apiInstance.UserUsernameDelete(username);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.UserUsernameDelete: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **username** | **string**| Users username | 

### Return type

[**User**](User.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="userusernameget"></a>
# **UserUsernameGet**
> User UserUsernameGet (string username)

This operation returns the OPERANDOs registed user with given username

This operation returns the OPERANDOs registed user with given username

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class UserUsernameGetExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();
            var username = username_example;  // string | Users username

            try
            {
                // This operation returns the OPERANDOs registed user with given username
                User result = apiInstance.UserUsernameGet(username);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.UserUsernameGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **username** | **string**| Users username | 

### Return type

[**User**](User.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="userusernameput"></a>
# **UserUsernamePut**
> User UserUsernamePut (string username, User user)



Updates the content of ASs registed user with corresponding username

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class UserUsernamePutExample
    {
        public void main()
        {
            
            var apiInstance = new DefaultApi();
            var username = username_example;  // string | Users username
            var user = new User(); // User | Users data

            try
            {
                // 
                User result = apiInstance.UserUsernamePut(username, user);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.UserUsernamePut: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **username** | **string**| Users username | 
 **user** | [**User**](User.md)| Users data | 

### Return type

[**User**](User.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

