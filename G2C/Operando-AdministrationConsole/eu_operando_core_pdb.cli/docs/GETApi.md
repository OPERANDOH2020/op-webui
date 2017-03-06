# IO.Swagger.Api.GETApi

All URIs are relative to *http://operando.eu/policy_database*

Method | HTTP request | Description
------------- | ------------- | -------------
[**OSPGet**](GETApi.md#ospget) | **GET** /OSP/ | Perform a search query across the collection of OSP behaviour.
[**OSPOspIdGet**](GETApi.md#ospospidget) | **GET** /OSP/{osp-id}/ | Read a given OSP behaviour policy.
[**OSPOspIdPrivacyPolicyAccessReasonsGet**](GETApi.md#ospospidprivacypolicyaccessreasonsget) | **GET** /OSP/{osp-id}/privacy-policy/access-reasons | Get the list of access reason policy statements.
[**OSPOspIdPrivacyPolicyGet**](GETApi.md#ospospidprivacypolicyget) | **GET** /OSP/{osp-id}/privacy-policy/ | Get the current set of privacy policy statements about the usage of data for stated reasons.
[**RegulationsGet**](GETApi.md#regulationsget) | **GET** /regulations/ | Perform a search query across the collection of regulation.
[**RegulationsRegIdGet**](GETApi.md#regulationsregidget) | **GET** /regulations/{reg-id}/ | Read a given legislation with its ID.
[**UserPrivacyPolicyGet**](GETApi.md#userprivacypolicyget) | **GET** /user_privacy_policy/ | Perform a search query across the collection of UPPs.
[**UserPrivacyPolicyUserIdGet**](GETApi.md#userprivacypolicyuseridget) | **GET** /user_privacy_policy/{user-id}/ | Read the user privacy policy for the given user id.


<a name="ospget"></a>
# **OSPGet**
> List<OSPPrivacyPolicy> OSPGet (string filter)

Perform a search query across the collection of OSP behaviour.

The query contains a json object (names, values) and the request returns the list of documents (regulations) where the filter matches i.e. the document contains fields with those values. 

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class OSPGetExample
    {
        public void main()
        {
            
            var apiInstance = new GETApi();
            var filter = filter_example;  // string | The query filter to be matched - ?filter={json description}

            try
            {
                // Perform a search query across the collection of OSP behaviour.
                List&lt;OSPPrivacyPolicy&gt; result = apiInstance.OSPGet(filter);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling GETApi.OSPGet: " + e.Message );
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

[**List<OSPPrivacyPolicy>**](OSPPrivacyPolicy.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="ospospidget"></a>
# **OSPOspIdGet**
> OSPPrivacyPolicy OSPOspIdGet (string ospId)

Read a given OSP behaviour policy.

Get a specific OSP document via the id. This will return the full OSP document in json format. 

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class OSPOspIdGetExample
    {
        public void main()
        {
            
            var apiInstance = new GETApi();
            var ospId = ospId_example;  // string | The identifier number of an OSP

            try
            {
                // Read a given OSP behaviour policy.
                OSPPrivacyPolicy result = apiInstance.OSPOspIdGet(ospId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling GETApi.OSPOspIdGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ospId** | **string**| The identifier number of an OSP | 

### Return type

[**OSPPrivacyPolicy**](OSPPrivacyPolicy.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="ospospidprivacypolicyaccessreasonsget"></a>
# **OSPOspIdPrivacyPolicyAccessReasonsGet**
> List<OSPReasonPolicy> OSPOspIdPrivacyPolicyAccessReasonsGet (string ospId)

Get the list of access reason policy statements.

List of policy statements.  

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class OSPOspIdPrivacyPolicyAccessReasonsGetExample
    {
        public void main()
        {
            
            var apiInstance = new GETApi();
            var ospId = ospId_example;  // string | The identifier number of an OSP

            try
            {
                // Get the list of access reason policy statements.
                List&lt;OSPReasonPolicy&gt; result = apiInstance.OSPOspIdPrivacyPolicyAccessReasonsGet(ospId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling GETApi.OSPOspIdPrivacyPolicyAccessReasonsGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ospId** | **string**| The identifier number of an OSP | 

### Return type

[**List<OSPReasonPolicy>**](OSPReasonPolicy.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="ospospidprivacypolicyget"></a>
# **OSPOspIdPrivacyPolicyGet**
> OSPReasonPolicy OSPOspIdPrivacyPolicyGet (string ospId)

Get the current set of privacy policy statements about the usage of data for stated reasons.

This is a machine readable version of a G2C privacy policy statement entered using the OSP Admin dashboard; and retrieved by both the OSP & PSP analyst dashboard for display purposes and also by the OSE component for checking regulation compliance.  

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class OSPOspIdPrivacyPolicyGetExample
    {
        public void main()
        {
            
            var apiInstance = new GETApi();
            var ospId = ospId_example;  // string | The identifier number of an OSP

            try
            {
                // Get the current set of privacy policy statements about the usage of data for stated reasons.
                OSPReasonPolicy result = apiInstance.OSPOspIdPrivacyPolicyGet(ospId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling GETApi.OSPOspIdPrivacyPolicyGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ospId** | **string**| The identifier number of an OSP | 

### Return type

[**OSPReasonPolicy**](OSPReasonPolicy.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

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
            
            var apiInstance = new GETApi();
            var filter = filter_example;  // string | The query filter to be matched - ?filter={json description}

            try
            {
                // Perform a search query across the collection of regulation.
                List&lt;PrivacyRegulation&gt; result = apiInstance.RegulationsGet(filter);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling GETApi.RegulationsGet: " + e.Message );
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
            
            var apiInstance = new GETApi();
            var regId = regId_example;  // string | The identifier number of a regulation

            try
            {
                // Read a given legislation with its ID.
                PrivacyRegulation result = apiInstance.RegulationsRegIdGet(regId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling GETApi.RegulationsRegIdGet: " + e.Message );
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
            
            var apiInstance = new GETApi();
            var filter = filter_example;  // string | The query filter to be matched - ?filter={json description}

            try
            {
                // Perform a search query across the collection of UPPs.
                List&lt;UserPrivacyPolicy&gt; result = apiInstance.UserPrivacyPolicyGet(filter);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling GETApi.UserPrivacyPolicyGet: " + e.Message );
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
            
            var apiInstance = new GETApi();
            var userId = userId_example;  // string | The user identifier number

            try
            {
                // Read the user privacy policy for the given user id.
                UserPrivacyPolicy result = apiInstance.UserPrivacyPolicyUserIdGet(userId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling GETApi.UserPrivacyPolicyUserIdGet: " + e.Message );
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

