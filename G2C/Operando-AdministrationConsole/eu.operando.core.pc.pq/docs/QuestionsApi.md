# IO.Swagger.Api.QuestionsApi

All URIs are relative to *http://operando.eu/pq*

Method | HTTP request | Description
------------- | ------------- | -------------
[**QuestionsUserIdOspIdGet**](QuestionsApi.md#questionsuseridospidget) | **GET** /questions/{user-id}/{osp-id} | Obtain a set of 9 questions related to privacy and the specified OSP.
[**QuestionsUserIdOspIdPost**](QuestionsApi.md#questionsuseridospidpost) | **POST** /questions/{user-id}/{osp-id} | Enter the answers to the questionnaire.


<a name="questionsuseridospidget"></a>
# **QuestionsUserIdOspIdGet**
> List<Questionobject> QuestionsUserIdOspIdGet (string userId, string ospId, string language)

Obtain a set of 9 questions related to privacy and the specified OSP.

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
    public class QuestionsUserIdOspIdGetExample
    {
        public void main()
        {
            var apiInstance = new QuestionsApi();
            var userId = userId_example;  // string | The user identifier number
            var ospId = ospId_example;  // string | The identifier number of an OSP
            var language = language_example;  // string | The language for the question (EN, IT, FR etc.)

            try
            {
                // Obtain a set of 9 questions related to privacy and the specified OSP.
                List&lt;Questionobject&gt; result = apiInstance.QuestionsUserIdOspIdGet(userId, ospId, language);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling QuestionsApi.QuestionsUserIdOspIdGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **userId** | **string**| The user identifier number | 
 **ospId** | **string**| The identifier number of an OSP | 
 **language** | **string**| The language for the question (EN, IT, FR etc.) | 

### Return type

[**List<Questionobject>**](Questionobject.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="questionsuseridospidpost"></a>
# **QuestionsUserIdOspIdPost**
> List<Answerobject> QuestionsUserIdOspIdPost (string userId, List<Questionobject> upp)

Enter the answers to the questionnaire.

Once the questions have been answered by the user they are pushed to be  processed and the user preferences calculated and stored in the UPP. 

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class QuestionsUserIdOspIdPostExample
    {
        public void main()
        {
            var apiInstance = new QuestionsApi();
            var userId = userId_example;  // string | The user identifier number
            var upp = new List<Questionobject>(); // List<Questionobject> | The answers to the questions

            try
            {
                // Enter the answers to the questionnaire.
                List&lt;Answerobject&gt; result = apiInstance.QuestionsUserIdOspIdPost(userId, upp);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling QuestionsApi.QuestionsUserIdOspIdPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **userId** | **string**| The user identifier number | 
 **upp** | [**List&lt;Questionobject&gt;**](Questionobject.md)| The answers to the questions | 

### Return type

[**List<Answerobject>**](Answerobject.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

