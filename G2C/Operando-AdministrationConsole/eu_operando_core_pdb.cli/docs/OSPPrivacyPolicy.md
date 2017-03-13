# IO.Swagger.Model.OSPPrivacyPolicy
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**OspPolicyId** | **string** |  | [optional] 
**PolicyText** | **string** | The content of the OSP privacy policy, textually described and published. It is a the full text adverstised by the OSP.  | [optional] 
**PolicyUrl** | **string** | The url location of the privacy policy of the OSP  | [optional] 
**Workflow** | [**List&lt;OSPDataRequest&gt;**](OSPDataRequest.md) | The sequence of requests that this OSP makes (simple ordered array list in this version). The requests describes the operations that the OSP may carry out on the data. This can be used for compliance checking and computation of user policies.  | [optional] 
**Policies** | [**List&lt;AccessPolicy&gt;**](AccessPolicy.md) | The list of rights that the OSP intends to follow e.g. give X access to Y data for Z purpose. This information can then be used in calculation of the policy and in compliance checking.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

