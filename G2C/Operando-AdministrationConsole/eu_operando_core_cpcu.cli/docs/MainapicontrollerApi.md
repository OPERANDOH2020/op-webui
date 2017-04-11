# IO.Swagger.Api.MainapicontrollerApi

All URIs are relative to *https://localhost:8080/operandocpcu*

Method | HTTP request | Description
------------- | ------------- | -------------
[**AddQuestionUsingPOST**](MainapicontrollerApi.md#addquestionusingpost) | **POST** /api/qp/{questionnaireID} | Adds a Question
[**CreateQuestionnaireUsingPOST**](MainapicontrollerApi.md#createquestionnaireusingpost) | **POST** /api/qu | Creates a Questionnaire
[**CreateServiceUsingPOST**](MainapicontrollerApi.md#createserviceusingpost) | **POST** /api/se | Creates a Service
[**DeleteQuestionUsingDELETE**](MainapicontrollerApi.md#deletequestionusingdelete) | **DELETE** /api/qp/{questionnaireID}/{questionID} | Deletes a Question
[**DeleteQuestionnaireUsingDELETE**](MainapicontrollerApi.md#deletequestionnaireusingdelete) | **DELETE** /api/qu/{questionnaireID} | Deletes a Questionnaire
[**DeleteServiceUsingDELETE**](MainapicontrollerApi.md#deleteserviceusingdelete) | **DELETE** /api/se/{serviceID} | Deletes a Service
[**GetQuestionPoolUsingGET**](MainapicontrollerApi.md#getquestionpoolusingget) | **GET** /api/qp/{questionnaireID} | Retrieves a Question pool
[**GetQuestionnairesUsingGET**](MainapicontrollerApi.md#getquestionnairesusingget) | **GET** /api/qu | Reads Questionnaires
[**GetQuestionplUsingGET**](MainapicontrollerApi.md#getquestionplusingget) | **GET** /api/qp | getQuestionpl
[**GetServicesUsingGET**](MainapicontrollerApi.md#getservicesusingget) | **GET** /api/se | Read Services
[**GetSpecificQuestionnaireUsingGET**](MainapicontrollerApi.md#getspecificquestionnaireusingget) | **GET** /api/qu/{questionnaireID} | Reads a specific Questionnaire
[**GetSpecificServiceUsingGET**](MainapicontrollerApi.md#getspecificserviceusingget) | **GET** /api/se/{serviceID} | Reads a specific Service
[**ReloadAppUsingGET**](MainapicontrollerApi.md#reloadappusingget) | **GET** /api/reload | Reload
[**ShowPageUsingGET**](MainapicontrollerApi.md#showpageusingget) | **GET** /api/show | Display the Admin Panel
[**UpdateQuestionUsingPOST**](MainapicontrollerApi.md#updatequestionusingpost) | **POST** /api/qp/{questionnaireID}/{questionID} | Updates a Question
[**UpdateQuestionniareUsingPOST**](MainapicontrollerApi.md#updatequestionniareusingpost) | **POST** /api/qu/{questionnaireID} | Updates a Questionnaire
[**UpdateServiceUsingPOST**](MainapicontrollerApi.md#updateserviceusingpost) | **POST** /api/se/{serviceID} | Updates a Service
[**ValidateQuestionIDUsingGET**](MainapicontrollerApi.md#validatequestionidusingget) | **GET** /api/qpid/{questionnaireID}/{validateID} | Verifies an ID is valid
[**ValidateQuestionnaireIDUsingGET**](MainapicontrollerApi.md#validatequestionnaireidusingget) | **GET** /api/quid/{validateID} | Verifies an ID is valid


<a name="addquestionusingpost"></a>
# **AddQuestionUsingPOST**
> Object AddQuestionUsingPOST (string questionnaireID, QuestionConfiguration qc)

Adds a Question

 Adds a new Question to a specfic Questionnaire

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class AddQuestionUsingPOSTExample
    {
        public void main()
        {
            
            var apiInstance = new MainapicontrollerApi();
            var questionnaireID = questionnaireID_example;  // string | The questionnaireID of the Questionnaire that contains the Question
            var qc = new QuestionConfiguration(); // QuestionConfiguration | The QuestionnaireConfiguration which defines the parameters to create a new Questionnaire

            try
            {
                // Adds a Question
                Object result = apiInstance.AddQuestionUsingPOST(questionnaireID, qc);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MainapicontrollerApi.AddQuestionUsingPOST: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **questionnaireID** | **string**| The questionnaireID of the Questionnaire that contains the Question | 
 **qc** | [**QuestionConfiguration**](QuestionConfiguration.md)| The QuestionnaireConfiguration which defines the parameters to create a new Questionnaire | 

### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="createquestionnaireusingpost"></a>
# **CreateQuestionnaireUsingPOST**
> Object CreateQuestionnaireUsingPOST (QuestionnaireConfiguration qc)

Creates a Questionnaire

Creates a new Questionnaire and adds it to the accessible Questionnaires

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class CreateQuestionnaireUsingPOSTExample
    {
        public void main()
        {
            
            var apiInstance = new MainapicontrollerApi();
            var qc = new QuestionnaireConfiguration(); // QuestionnaireConfiguration | The QuestionnaireConfiguration which defines the parameters to create a new Questionnaire

            try
            {
                // Creates a Questionnaire
                Object result = apiInstance.CreateQuestionnaireUsingPOST(qc);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MainapicontrollerApi.CreateQuestionnaireUsingPOST: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **qc** | [**QuestionnaireConfiguration**](QuestionnaireConfiguration.md)| The QuestionnaireConfiguration which defines the parameters to create a new Questionnaire | 

### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="createserviceusingpost"></a>
# **CreateServiceUsingPOST**
> Object CreateServiceUsingPOST (ServiceConfiguration sc)

Creates a Service

Creates a new Service and adds it to the accessible Services

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class CreateServiceUsingPOSTExample
    {
        public void main()
        {
            
            var apiInstance = new MainapicontrollerApi();
            var sc = new ServiceConfiguration(); // ServiceConfiguration | The ServiceConfiguration containing the parameters to create a new Service

            try
            {
                // Creates a Service
                Object result = apiInstance.CreateServiceUsingPOST(sc);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MainapicontrollerApi.CreateServiceUsingPOST: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **sc** | [**ServiceConfiguration**](ServiceConfiguration.md)| The ServiceConfiguration containing the parameters to create a new Service | 

### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deletequestionusingdelete"></a>
# **DeleteQuestionUsingDELETE**
> Object DeleteQuestionUsingDELETE (string questionnaireID, string questionID)

Deletes a Question

Deletes a specific Question within a Questionnaire

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class DeleteQuestionUsingDELETEExample
    {
        public void main()
        {
            
            var apiInstance = new MainapicontrollerApi();
            var questionnaireID = questionnaireID_example;  // string | The questionnaireID of the Questionnaire that contains the Question
            var questionID = questionID_example;  // string | The questionID which identifies the Question to be deleted

            try
            {
                // Deletes a Question
                Object result = apiInstance.DeleteQuestionUsingDELETE(questionnaireID, questionID);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MainapicontrollerApi.DeleteQuestionUsingDELETE: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **questionnaireID** | **string**| The questionnaireID of the Questionnaire that contains the Question | 
 **questionID** | **string**| The questionID which identifies the Question to be deleted | 

### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deletequestionnaireusingdelete"></a>
# **DeleteQuestionnaireUsingDELETE**
> Object DeleteQuestionnaireUsingDELETE (int? questionnaireID)

Deletes a Questionnaire

Deletes a specific Questionnaire

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class DeleteQuestionnaireUsingDELETEExample
    {
        public void main()
        {
            
            var apiInstance = new MainapicontrollerApi();
            var questionnaireID = 56;  // int? | The questionnaireID of the Questionnaire that contains the Question to be deleted

            try
            {
                // Deletes a Questionnaire
                Object result = apiInstance.DeleteQuestionnaireUsingDELETE(questionnaireID);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MainapicontrollerApi.DeleteQuestionnaireUsingDELETE: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **questionnaireID** | **int?**| The questionnaireID of the Questionnaire that contains the Question to be deleted | 

### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deleteserviceusingdelete"></a>
# **DeleteServiceUsingDELETE**
> Object DeleteServiceUsingDELETE (int? serviceID)

Deletes a Service

Deletes a specific service from the accessible services

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class DeleteServiceUsingDELETEExample
    {
        public void main()
        {
            
            var apiInstance = new MainapicontrollerApi();
            var serviceID = 56;  // int? | The ServiceID to be deleted

            try
            {
                // Deletes a Service
                Object result = apiInstance.DeleteServiceUsingDELETE(serviceID);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MainapicontrollerApi.DeleteServiceUsingDELETE: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **serviceID** | **int?**| The ServiceID to be deleted | 

### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getquestionpoolusingget"></a>
# **GetQuestionPoolUsingGET**
> List<QuestionConfiguration> GetQuestionPoolUsingGET (int? questionnaireID)

Retrieves a Question pool

Gets the entire Question pool for a given Questionnaire. NOTE: This returns all the Questions, not a subset (as done in the Application)

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetQuestionPoolUsingGETExample
    {
        public void main()
        {
            
            var apiInstance = new MainapicontrollerApi();
            var questionnaireID = 56;  // int? | questionnaireID

            try
            {
                // Retrieves a Question pool
                List&lt;QuestionConfiguration&gt; result = apiInstance.GetQuestionPoolUsingGET(questionnaireID);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MainapicontrollerApi.GetQuestionPoolUsingGET: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **questionnaireID** | **int?**| questionnaireID | 

### Return type

[**List<QuestionConfiguration>**](QuestionConfiguration.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json, */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getquestionnairesusingget"></a>
# **GetQuestionnairesUsingGET**
> List<QuestionnaireConfiguration> GetQuestionnairesUsingGET (string search = null, string field = null)

Reads Questionnaires

Gets the accessible questionnaires as a JSON String. If optional parameters are filled, then a specific Questionnaire can be returned. Must be correctly capitalised to returnthe correct result. Will return a JSON Array if multiple Objects satisfy the predicate.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetQuestionnairesUsingGETExample
    {
        public void main()
        {
            
            var apiInstance = new MainapicontrollerApi();
            var search = search_example;  // string | The String to search by, when searching for a specific Questionnaire (optional) 
            var field = field_example;  // string | The field to search for the String. This can be any valid field in the Questionnaire. (optional) 

            try
            {
                // Reads Questionnaires
                List&lt;QuestionnaireConfiguration&gt; result = apiInstance.GetQuestionnairesUsingGET(search, field);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MainapicontrollerApi.GetQuestionnairesUsingGET: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **search** | **string**| The String to search by, when searching for a specific Questionnaire | [optional] 
 **field** | **string**| The field to search for the String. This can be any valid field in the Questionnaire. | [optional] 

### Return type

[**List<QuestionnaireConfiguration>**](QuestionnaireConfiguration.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getquestionplusingget"></a>
# **GetQuestionplUsingGET**
> List<QuestionConfiguration> GetQuestionplUsingGET ()

getQuestionpl

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetQuestionplUsingGETExample
    {
        public void main()
        {
            
            var apiInstance = new MainapicontrollerApi();

            try
            {
                // getQuestionpl
                List&lt;QuestionConfiguration&gt; result = apiInstance.GetQuestionplUsingGET();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MainapicontrollerApi.GetQuestionplUsingGET: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**List<QuestionConfiguration>**](QuestionConfiguration.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getservicesusingget"></a>
# **GetServicesUsingGET**
> List<ServiceConfiguration> GetServicesUsingGET (string search = null, string field = null)

Read Services

Returns the JSON representation of the currently accessible services. If the parameters are filled then a specific service can be returned.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetServicesUsingGETExample
    {
        public void main()
        {
            
            var apiInstance = new MainapicontrollerApi();
            var search = search_example;  // string | The String to search by, when searching for a specific service (optional) 
            var field = field_example;  // string | The field to search for the String. This can be any valid field in the Service. (optional) 

            try
            {
                // Read Services
                List&lt;ServiceConfiguration&gt; result = apiInstance.GetServicesUsingGET(search, field);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MainapicontrollerApi.GetServicesUsingGET: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **search** | **string**| The String to search by, when searching for a specific service | [optional] 
 **field** | **string**| The field to search for the String. This can be any valid field in the Service. | [optional] 

### Return type

[**List<ServiceConfiguration>**](ServiceConfiguration.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json, */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getspecificquestionnaireusingget"></a>
# **GetSpecificQuestionnaireUsingGET**
> List<QuestionnaireConfiguration> GetSpecificQuestionnaireUsingGET (int? questionnaireID)

Reads a specific Questionnaire

Gets a specific Questionnaire as a JSON String

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetSpecificQuestionnaireUsingGETExample
    {
        public void main()
        {
            
            var apiInstance = new MainapicontrollerApi();
            var questionnaireID = 56;  // int? | questionnaireID

            try
            {
                // Reads a specific Questionnaire
                List&lt;QuestionnaireConfiguration&gt; result = apiInstance.GetSpecificQuestionnaireUsingGET(questionnaireID);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MainapicontrollerApi.GetSpecificQuestionnaireUsingGET: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **questionnaireID** | **int?**| questionnaireID | 

### Return type

[**List<QuestionnaireConfiguration>**](QuestionnaireConfiguration.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getspecificserviceusingget"></a>
# **GetSpecificServiceUsingGET**
> List<ServiceConfiguration> GetSpecificServiceUsingGET (int? serviceID)

Reads a specific Service

Gets a specific Service as a JSON String

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetSpecificServiceUsingGETExample
    {
        public void main()
        {
            
            var apiInstance = new MainapicontrollerApi();
            var serviceID = 56;  // int? | serviceID

            try
            {
                // Reads a specific Service
                List&lt;ServiceConfiguration&gt; result = apiInstance.GetSpecificServiceUsingGET(serviceID);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MainapicontrollerApi.GetSpecificServiceUsingGET: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **serviceID** | **int?**| serviceID | 

### Return type

[**List<ServiceConfiguration>**](ServiceConfiguration.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json, */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="reloadappusingget"></a>
# **ReloadAppUsingGET**
> Object ReloadAppUsingGET ()

Reload

Reloads the Active configuration within the Application, this means that any changes made within the API are then accessible to the CPCU Application.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ReloadAppUsingGETExample
    {
        public void main()
        {
            
            var apiInstance = new MainapicontrollerApi();

            try
            {
                // Reload
                Object result = apiInstance.ReloadAppUsingGET();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MainapicontrollerApi.ReloadAppUsingGET: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="showpageusingget"></a>
# **ShowPageUsingGET**
> ModelAndView ShowPageUsingGET ()

Display the Admin Panel

This displays a UI in which the Questionnaires and Questions can be altered

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ShowPageUsingGETExample
    {
        public void main()
        {
            
            var apiInstance = new MainapicontrollerApi();

            try
            {
                // Display the Admin Panel
                ModelAndView result = apiInstance.ShowPageUsingGET();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MainapicontrollerApi.ShowPageUsingGET: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**ModelAndView**](ModelAndView.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updatequestionusingpost"></a>
# **UpdateQuestionUsingPOST**
> Object UpdateQuestionUsingPOST (string questionnaireID, string questionID, QuestionConfiguration qc)

Updates a Question

Updates a specfic Question within a Questionnaire with the given JSON Data

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class UpdateQuestionUsingPOSTExample
    {
        public void main()
        {
            
            var apiInstance = new MainapicontrollerApi();
            var questionnaireID = questionnaireID_example;  // string | The questionnaireID of the Questionnaire that contains the Question
            var questionID = questionID_example;  // string | The questionID which identifies the Question to be updated
            var qc = new QuestionConfiguration(); // QuestionConfiguration | The QuestionnaireConfiguration which defines the parameters to create a new Questionnaire

            try
            {
                // Updates a Question
                Object result = apiInstance.UpdateQuestionUsingPOST(questionnaireID, questionID, qc);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MainapicontrollerApi.UpdateQuestionUsingPOST: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **questionnaireID** | **string**| The questionnaireID of the Questionnaire that contains the Question | 
 **questionID** | **string**| The questionID which identifies the Question to be updated | 
 **qc** | [**QuestionConfiguration**](QuestionConfiguration.md)| The QuestionnaireConfiguration which defines the parameters to create a new Questionnaire | 

### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updatequestionniareusingpost"></a>
# **UpdateQuestionniareUsingPOST**
> Object UpdateQuestionniareUsingPOST (QuestionnaireConfiguration qc, int? questionnaireID)

Updates a Questionnaire

Updates a new Questionnaire and adds it back to the accessible Questionnaires

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class UpdateQuestionniareUsingPOSTExample
    {
        public void main()
        {
            
            var apiInstance = new MainapicontrollerApi();
            var qc = new QuestionnaireConfiguration(); // QuestionnaireConfiguration | The QuestionnaireConfiguration which defines the parameters to create a new Questionnaire
            var questionnaireID = 56;  // int? | The Questionnaire ID to be updated

            try
            {
                // Updates a Questionnaire
                Object result = apiInstance.UpdateQuestionniareUsingPOST(qc, questionnaireID);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MainapicontrollerApi.UpdateQuestionniareUsingPOST: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **qc** | [**QuestionnaireConfiguration**](QuestionnaireConfiguration.md)| The QuestionnaireConfiguration which defines the parameters to create a new Questionnaire | 
 **questionnaireID** | **int?**| The Questionnaire ID to be updated | 

### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updateserviceusingpost"></a>
# **UpdateServiceUsingPOST**
> Object UpdateServiceUsingPOST (ServiceConfiguration sc, int? serviceID)

Updates a Service

Updates a specific service with the data submitted to this operation.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class UpdateServiceUsingPOSTExample
    {
        public void main()
        {
            
            var apiInstance = new MainapicontrollerApi();
            var sc = new ServiceConfiguration(); // ServiceConfiguration | The ServiceConfiguration containing the parameters to create a new Service
            var serviceID = 56;  // int? | The ServiceID of the service to be updated

            try
            {
                // Updates a Service
                Object result = apiInstance.UpdateServiceUsingPOST(sc, serviceID);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MainapicontrollerApi.UpdateServiceUsingPOST: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **sc** | [**ServiceConfiguration**](ServiceConfiguration.md)| The ServiceConfiguration containing the parameters to create a new Service | 
 **serviceID** | **int?**| The ServiceID of the service to be updated | 

### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="validatequestionidusingget"></a>
# **ValidateQuestionIDUsingGET**
> Object ValidateQuestionIDUsingGET (int? questionnaireID, int? validateID)

Verifies an ID is valid

Checks through the Questionnaire List to make sure the ID is valid

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ValidateQuestionIDUsingGETExample
    {
        public void main()
        {
            
            var apiInstance = new MainapicontrollerApi();
            var questionnaireID = 56;  // int? | questionnaireID
            var validateID = 56;  // int? | validateID

            try
            {
                // Verifies an ID is valid
                Object result = apiInstance.ValidateQuestionIDUsingGET(questionnaireID, validateID);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MainapicontrollerApi.ValidateQuestionIDUsingGET: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **questionnaireID** | **int?**| questionnaireID | 
 **validateID** | **int?**| validateID | 

### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="validatequestionnaireidusingget"></a>
# **ValidateQuestionnaireIDUsingGET**
> Object ValidateQuestionnaireIDUsingGET (int? validateID)

Verifies an ID is valid

Checks through the Questionnaire List to make sure the ID is valid

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ValidateQuestionnaireIDUsingGETExample
    {
        public void main()
        {
            
            var apiInstance = new MainapicontrollerApi();
            var validateID = 56;  // int? | validateID

            try
            {
                // Verifies an ID is valid
                Object result = apiInstance.ValidateQuestionnaireIDUsingGET(validateID);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MainapicontrollerApi.ValidateQuestionnaireIDUsingGET: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **validateID** | **int?**| validateID | 

### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

