# IO.Swagger.Model.OSPDataRequest
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**RequesterId** | **string** | Id of the requester (typically the id of an OSP). | [optional] 
**Subject** | **string** | A description of the subject who the policies grants/doesn&#39;t grant to carry out.  | [optional] 
**RequestedUrl** | **string** | The Requested URL of the data.  | [optional] 
**Action** | **string** | The action being carried out on the private date e.g. accessing, disclosing to a third party.   | [optional] 
**Attributes** | [**List&lt;PolicyAttribute&gt;**](PolicyAttribute.md) | The set of context attributes attached to the policy (e.g. subject role, subject purpose)  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

