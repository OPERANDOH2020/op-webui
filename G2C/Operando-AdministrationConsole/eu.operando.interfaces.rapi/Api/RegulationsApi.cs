/* 
 * Regulator API
 *
 * API specification for OPERANDO's Regulator API
 *
 * OpenAPI spec version: 0.0.1
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Collections.Generic;
using System.Linq;
using eu.operando.interfaces.rapi.Client;
using eu.operando.interfaces.rapi.Model;
using RestSharp;

namespace eu.operando.interfaces.rapi.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IRegulationsApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Add a new regulation to the system.
        /// </summary>
        /// <remarks>
        /// Called by a regulator to ensure that the platform becomes compliant with the new regulation. The regulation that was saved is returned, along with an identifer which should be used to refer to it in later communication. 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="serviceTicket"></param>
        /// <param name="regulationBody"></param>
        /// <returns>PrivacyRegulation</returns>
        PrivacyRegulation RegulationsPost (string serviceTicket, RegulationBody regulationBody);

        /// <summary>
        /// Add a new regulation to the system.
        /// </summary>
        /// <remarks>
        /// Called by a regulator to ensure that the platform becomes compliant with the new regulation. The regulation that was saved is returned, along with an identifer which should be used to refer to it in later communication. 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="serviceTicket"></param>
        /// <param name="regulationBody"></param>
        /// <returns>ApiResponse of PrivacyRegulation</returns>
        ApiResponse<PrivacyRegulation> RegulationsPostWithHttpInfo (string serviceTicket, RegulationBody regulationBody);
        /// <summary>
        /// Update an exisiting regulation.
        /// </summary>
        /// <remarks>
        /// Called by a regulator to ensure that the platform becomes compliant with the new terms of the regulation. The regulation that was saved is returned, along with an identifer which should be used to refer to it in later communication. 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="serviceTicket"></param>
        /// <param name="regulationBody"></param>
        /// <param name="regId">the unique identifier of a regulation.</param>
        /// <returns>PrivacyRegulationInput</returns>
        PrivacyRegulationInput RegulationsRegIdPut (string serviceTicket, RegulationBody regulationBody, string regId);

        /// <summary>
        /// Update an exisiting regulation.
        /// </summary>
        /// <remarks>
        /// Called by a regulator to ensure that the platform becomes compliant with the new terms of the regulation. The regulation that was saved is returned, along with an identifer which should be used to refer to it in later communication. 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="serviceTicket"></param>
        /// <param name="regulationBody"></param>
        /// <param name="regId">the unique identifier of a regulation.</param>
        /// <returns>ApiResponse of PrivacyRegulationInput</returns>
        ApiResponse<PrivacyRegulationInput> RegulationsRegIdPutWithHttpInfo (string serviceTicket, RegulationBody regulationBody, string regId);
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Add a new regulation to the system.
        /// </summary>
        /// <remarks>
        /// Called by a regulator to ensure that the platform becomes compliant with the new regulation. The regulation that was saved is returned, along with an identifer which should be used to refer to it in later communication. 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="serviceTicket"></param>
        /// <param name="regulationBody"></param>
        /// <returns>Task of PrivacyRegulation</returns>
        System.Threading.Tasks.Task<PrivacyRegulation> RegulationsPostAsync (string serviceTicket, RegulationBody regulationBody);

        /// <summary>
        /// Add a new regulation to the system.
        /// </summary>
        /// <remarks>
        /// Called by a regulator to ensure that the platform becomes compliant with the new regulation. The regulation that was saved is returned, along with an identifer which should be used to refer to it in later communication. 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="serviceTicket"></param>
        /// <param name="regulationBody"></param>
        /// <returns>Task of ApiResponse (PrivacyRegulation)</returns>
        System.Threading.Tasks.Task<ApiResponse<PrivacyRegulation>> RegulationsPostAsyncWithHttpInfo (string serviceTicket, RegulationBody regulationBody);
        /// <summary>
        /// Update an exisiting regulation.
        /// </summary>
        /// <remarks>
        /// Called by a regulator to ensure that the platform becomes compliant with the new terms of the regulation. The regulation that was saved is returned, along with an identifer which should be used to refer to it in later communication. 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="serviceTicket"></param>
        /// <param name="regulationBody"></param>
        /// <param name="regId">the unique identifier of a regulation.</param>
        /// <returns>Task of PrivacyRegulationInput</returns>
        System.Threading.Tasks.Task<PrivacyRegulationInput> RegulationsRegIdPutAsync (string serviceTicket, RegulationBody regulationBody, string regId);

        /// <summary>
        /// Update an exisiting regulation.
        /// </summary>
        /// <remarks>
        /// Called by a regulator to ensure that the platform becomes compliant with the new terms of the regulation. The regulation that was saved is returned, along with an identifer which should be used to refer to it in later communication. 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="serviceTicket"></param>
        /// <param name="regulationBody"></param>
        /// <param name="regId">the unique identifier of a regulation.</param>
        /// <returns>Task of ApiResponse (PrivacyRegulationInput)</returns>
        System.Threading.Tasks.Task<ApiResponse<PrivacyRegulationInput>> RegulationsRegIdPutAsyncWithHttpInfo (string serviceTicket, RegulationBody regulationBody, string regId);
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class RegulationsApi : IRegulationsApi
    {
        private ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegulationsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public RegulationsApi(String basePath)
        {
            this.Configuration = new Configuration(new ApiClient(basePath));

            ExceptionFactory = Configuration.DefaultExceptionFactory;

            // ensure API client has configuration ready
            if (Configuration.ApiClient.Configuration == null)
            {
                this.Configuration.ApiClient.Configuration = this.Configuration;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegulationsApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public RegulationsApi(Configuration configuration = null)
        {
            if (configuration == null) // use the default one in Configuration
                this.Configuration = Configuration.Default;
            else
                this.Configuration = configuration;

            ExceptionFactory = Configuration.DefaultExceptionFactory;

            // ensure API client has configuration ready
            if (Configuration.ApiClient.Configuration == null)
            {
                this.Configuration.ApiClient.Configuration = this.Configuration;
            }
        }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public String GetBasePath()
        {
            return this.Configuration.ApiClient.RestClient.BaseUrl.ToString();
        }

        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        [Obsolete("SetBasePath is deprecated, please do 'Configuration.ApiClient = new ApiClient(\"http://new-path\")' instead.")]
        public void SetBasePath(String basePath)
        {
            // do nothing
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public Configuration Configuration {get; set;}

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// Gets the default header.
        /// </summary>
        /// <returns>Dictionary of HTTP header</returns>
        [Obsolete("DefaultHeader is deprecated, please use Configuration.DefaultHeader instead.")]
        public Dictionary<String, String> DefaultHeader()
        {
            return this.Configuration.DefaultHeader;
        }

        /// <summary>
        /// Add default header.
        /// </summary>
        /// <param name="key">Header field name.</param>
        /// <param name="value">Header field value.</param>
        /// <returns></returns>
        [Obsolete("AddDefaultHeader is deprecated, please use Configuration.AddDefaultHeader instead.")]
        public void AddDefaultHeader(string key, string value)
        {
            this.Configuration.AddDefaultHeader(key, value);
        }

        /// <summary>
        /// Add a new regulation to the system. Called by a regulator to ensure that the platform becomes compliant with the new regulation. The regulation that was saved is returned, along with an identifer which should be used to refer to it in later communication. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="serviceTicket"></param>
        /// <param name="regulationBody"></param>
        /// <returns>PrivacyRegulation</returns>
        public PrivacyRegulation RegulationsPost (string serviceTicket, RegulationBody regulationBody)
        {
             ApiResponse<PrivacyRegulation> localVarResponse = RegulationsPostWithHttpInfo(serviceTicket, regulationBody);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Add a new regulation to the system. Called by a regulator to ensure that the platform becomes compliant with the new regulation. The regulation that was saved is returned, along with an identifer which should be used to refer to it in later communication. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="serviceTicket"></param>
        /// <param name="regulationBody"></param>
        /// <returns>ApiResponse of PrivacyRegulation</returns>
        public ApiResponse< PrivacyRegulation > RegulationsPostWithHttpInfo (string serviceTicket, RegulationBody regulationBody)
        {
            // verify the required parameter 'serviceTicket' is set
            if (serviceTicket == null)
                throw new ApiException(400, "Missing required parameter 'serviceTicket' when calling RegulationsApi->RegulationsPost");
            // verify the required parameter 'regulationBody' is set
            if (regulationBody == null)
                throw new ApiException(400, "Missing required parameter 'regulationBody' when calling RegulationsApi->RegulationsPost");

            var localVarPath = "/regulations";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (serviceTicket != null) localVarHeaderParams.Add("service-ticket", Configuration.ApiClient.ParameterToString(serviceTicket)); // header parameter
            if (regulationBody != null && regulationBody.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(regulationBody); // http body (model) parameter
            }
            else
            {
                localVarPostBody = regulationBody; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("RegulationsPost", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<PrivacyRegulation>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (PrivacyRegulation) Configuration.ApiClient.Deserialize(localVarResponse, typeof(PrivacyRegulation)));
            
        }

        /// <summary>
        /// Add a new regulation to the system. Called by a regulator to ensure that the platform becomes compliant with the new regulation. The regulation that was saved is returned, along with an identifer which should be used to refer to it in later communication. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="serviceTicket"></param>
        /// <param name="regulationBody"></param>
        /// <returns>Task of PrivacyRegulation</returns>
        public async System.Threading.Tasks.Task<PrivacyRegulation> RegulationsPostAsync (string serviceTicket, RegulationBody regulationBody)
        {
             ApiResponse<PrivacyRegulation> localVarResponse = await RegulationsPostAsyncWithHttpInfo(serviceTicket, regulationBody);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Add a new regulation to the system. Called by a regulator to ensure that the platform becomes compliant with the new regulation. The regulation that was saved is returned, along with an identifer which should be used to refer to it in later communication. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="serviceTicket"></param>
        /// <param name="regulationBody"></param>
        /// <returns>Task of ApiResponse (PrivacyRegulation)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<PrivacyRegulation>> RegulationsPostAsyncWithHttpInfo (string serviceTicket, RegulationBody regulationBody)
        {
            // verify the required parameter 'serviceTicket' is set
            if (serviceTicket == null)
                throw new ApiException(400, "Missing required parameter 'serviceTicket' when calling RegulationsApi->RegulationsPost");
            // verify the required parameter 'regulationBody' is set
            if (regulationBody == null)
                throw new ApiException(400, "Missing required parameter 'regulationBody' when calling RegulationsApi->RegulationsPost");

            var localVarPath = "/regulations";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (serviceTicket != null) localVarHeaderParams.Add("service-ticket", Configuration.ApiClient.ParameterToString(serviceTicket)); // header parameter
            if (regulationBody != null && regulationBody.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(regulationBody); // http body (model) parameter
            }
            else
            {
                localVarPostBody = regulationBody; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("RegulationsPost", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<PrivacyRegulation>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (PrivacyRegulation) Configuration.ApiClient.Deserialize(localVarResponse, typeof(PrivacyRegulation)));
            
        }

        /// <summary>
        /// Update an exisiting regulation. Called by a regulator to ensure that the platform becomes compliant with the new terms of the regulation. The regulation that was saved is returned, along with an identifer which should be used to refer to it in later communication. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="serviceTicket"></param>
        /// <param name="regulationBody"></param>
        /// <param name="regId">the unique identifier of a regulation.</param>
        /// <returns>PrivacyRegulationInput</returns>
        public PrivacyRegulationInput RegulationsRegIdPut (string serviceTicket, RegulationBody regulationBody, string regId)
        {
             ApiResponse<PrivacyRegulationInput> localVarResponse = RegulationsRegIdPutWithHttpInfo(serviceTicket, regulationBody, regId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Update an exisiting regulation. Called by a regulator to ensure that the platform becomes compliant with the new terms of the regulation. The regulation that was saved is returned, along with an identifer which should be used to refer to it in later communication. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="serviceTicket"></param>
        /// <param name="regulationBody"></param>
        /// <param name="regId">the unique identifier of a regulation.</param>
        /// <returns>ApiResponse of PrivacyRegulationInput</returns>
        public ApiResponse< PrivacyRegulationInput > RegulationsRegIdPutWithHttpInfo (string serviceTicket, RegulationBody regulationBody, string regId)
        {
            // verify the required parameter 'serviceTicket' is set
            if (serviceTicket == null)
                throw new ApiException(400, "Missing required parameter 'serviceTicket' when calling RegulationsApi->RegulationsRegIdPut");
            // verify the required parameter 'regulationBody' is set
            if (regulationBody == null)
                throw new ApiException(400, "Missing required parameter 'regulationBody' when calling RegulationsApi->RegulationsRegIdPut");
            // verify the required parameter 'regId' is set
            if (regId == null)
                throw new ApiException(400, "Missing required parameter 'regId' when calling RegulationsApi->RegulationsRegIdPut");

            var localVarPath = "/regulations/{reg-id}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (regId != null) localVarPathParams.Add("reg-id", Configuration.ApiClient.ParameterToString(regId)); // path parameter
            if (serviceTicket != null) localVarHeaderParams.Add("service-ticket", Configuration.ApiClient.ParameterToString(serviceTicket)); // header parameter
            if (regulationBody != null && regulationBody.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(regulationBody); // http body (model) parameter
            }
            else
            {
                localVarPostBody = regulationBody; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("RegulationsRegIdPut", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<PrivacyRegulationInput>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (PrivacyRegulationInput) Configuration.ApiClient.Deserialize(localVarResponse, typeof(PrivacyRegulationInput)));
            
        }

        /// <summary>
        /// Update an exisiting regulation. Called by a regulator to ensure that the platform becomes compliant with the new terms of the regulation. The regulation that was saved is returned, along with an identifer which should be used to refer to it in later communication. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="serviceTicket"></param>
        /// <param name="regulationBody"></param>
        /// <param name="regId">the unique identifier of a regulation.</param>
        /// <returns>Task of PrivacyRegulationInput</returns>
        public async System.Threading.Tasks.Task<PrivacyRegulationInput> RegulationsRegIdPutAsync (string serviceTicket, RegulationBody regulationBody, string regId)
        {
             ApiResponse<PrivacyRegulationInput> localVarResponse = await RegulationsRegIdPutAsyncWithHttpInfo(serviceTicket, regulationBody, regId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Update an exisiting regulation. Called by a regulator to ensure that the platform becomes compliant with the new terms of the regulation. The regulation that was saved is returned, along with an identifer which should be used to refer to it in later communication. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="serviceTicket"></param>
        /// <param name="regulationBody"></param>
        /// <param name="regId">the unique identifier of a regulation.</param>
        /// <returns>Task of ApiResponse (PrivacyRegulationInput)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<PrivacyRegulationInput>> RegulationsRegIdPutAsyncWithHttpInfo (string serviceTicket, RegulationBody regulationBody, string regId)
        {
            // verify the required parameter 'serviceTicket' is set
            if (serviceTicket == null)
                throw new ApiException(400, "Missing required parameter 'serviceTicket' when calling RegulationsApi->RegulationsRegIdPut");
            // verify the required parameter 'regulationBody' is set
            if (regulationBody == null)
                throw new ApiException(400, "Missing required parameter 'regulationBody' when calling RegulationsApi->RegulationsRegIdPut");
            // verify the required parameter 'regId' is set
            if (regId == null)
                throw new ApiException(400, "Missing required parameter 'regId' when calling RegulationsApi->RegulationsRegIdPut");

            var localVarPath = "/regulations/{reg-id}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (regId != null) localVarPathParams.Add("reg-id", Configuration.ApiClient.ParameterToString(regId)); // path parameter
            if (serviceTicket != null) localVarHeaderParams.Add("service-ticket", Configuration.ApiClient.ParameterToString(serviceTicket)); // header parameter
            if (regulationBody != null && regulationBody.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(regulationBody); // http body (model) parameter
            }
            else
            {
                localVarPostBody = regulationBody; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("RegulationsRegIdPut", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<PrivacyRegulationInput>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (PrivacyRegulationInput) Configuration.ApiClient.Deserialize(localVarResponse, typeof(PrivacyRegulationInput)));
            
        }

    }
}