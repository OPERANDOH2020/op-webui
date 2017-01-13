# IO.Swagger.Model.UserPrivacyPolicy
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**UserId** | **string** | The unique operando id of the user this policy is about. Each OPERANDO user has one and only one UPP. | [optional] 
**UserPreferences** | [**List&lt;UserPreference&gt;**](UserPreference.md) | User stated preferences (questionnaire answers) | [optional] 
**SubscribedOspPolicies** | [**List&lt;OSPConsents&gt;**](OSPConsents.md) | The user policies for each OSP they subscribe to. | [optional] 
**SubscribedOspSettings** | [**List&lt;OSPSettings&gt;**](OSPSettings.md) | The user settings for each of their services | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

