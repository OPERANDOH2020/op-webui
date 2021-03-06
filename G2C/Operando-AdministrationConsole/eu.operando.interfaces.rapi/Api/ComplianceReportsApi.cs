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
    public interface IComplianceReportsApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Get a report.
        /// </summary>
        /// <remarks>
        /// Called by a regulator to obtain a compliance report relating to the specified OSP. 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="serviceTicket"></param>
        /// <param name="ospId">the unique identifier of an online service provider</param>
        /// <returns>ComplianceReport</returns>
        ComplianceReport OspsOspIdComplianceReportGet (string serviceTicket, string ospId);

        /// <summary>
        /// Get a report.
        /// </summary>
        /// <remarks>
        /// Called by a regulator to obtain a compliance report relating to the specified OSP. 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="serviceTicket"></param>
        /// <param name="ospId">the unique identifier of an online service provider</param>
        /// <returns>ApiResponse of ComplianceReport</returns>
        ApiResponse<ComplianceReport> OspsOspIdComplianceReportGetWithHttpInfo (string serviceTicket, string ospId);
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Get a report.
        /// </summary>
        /// <remarks>
        /// Called by a regulator to obtain a compliance report relating to the specified OSP. 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="serviceTicket"></param>
        /// <param name="ospId">the unique identifier of an online service provider</param>
        /// <returns>Task of ComplianceReport</returns>
        System.Threading.Tasks.Task<ComplianceReport> OspsOspIdComplianceReportGetAsync (string serviceTicket, string ospId);

        /// <summary>
        /// Get a report.
        /// </summary>
        /// <remarks>
        /// Called by a regulator to obtain a compliance report relating to the specified OSP. 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="serviceTicket"></param>
        /// <param name="ospId">the unique identifier of an online service provider</param>
        /// <returns>Task of ApiResponse (ComplianceReport)</returns>
        System.Threading.Tasks.Task<ApiResponse<ComplianceReport>> OspsOspIdComplianceReportGetAsyncWithHttpInfo (string serviceTicket, string ospId);
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class ComplianceReportsApi : IComplianceReportsApi
    {
        private ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ComplianceReportsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ComplianceReportsApi(String basePath)
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
        /// Initializes a new instance of the <see cref="ComplianceReportsApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public ComplianceReportsApi(Configuration configuration = null)
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
        /// Get a report. Called by a regulator to obtain a compliance report relating to the specified OSP. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="serviceTicket"></param>
        /// <param name="ospId">the unique identifier of an online service provider</param>
        /// <returns>ComplianceReport</returns>
        public ComplianceReport OspsOspIdComplianceReportGet (string serviceTicket, string ospId)
        {
             ApiResponse<ComplianceReport> localVarResponse = OspsOspIdComplianceReportGetWithHttpInfo(serviceTicket, ospId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get a report. Called by a regulator to obtain a compliance report relating to the specified OSP. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="serviceTicket"></param>
        /// <param name="ospId">the unique identifier of an online service provider</param>
        /// <returns>ApiResponse of ComplianceReport</returns>
        public ApiResponse< ComplianceReport > OspsOspIdComplianceReportGetWithHttpInfo (string serviceTicket, string ospId)
        {
            // verify the required parameter 'serviceTicket' is set
            if (serviceTicket == null)
                throw new ApiException(400, "Missing required parameter 'serviceTicket' when calling ComplianceReportsApi->OspsOspIdComplianceReportGet");
            // verify the required parameter 'ospId' is set
            if (ospId == null)
                throw new ApiException(400, "Missing required parameter 'ospId' when calling ComplianceReportsApi->OspsOspIdComplianceReportGet");

            var localVarPath = "/osps/{osp-id}/compliance-report";
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
            if (ospId != null) localVarPathParams.Add("osp-id", Configuration.ApiClient.ParameterToString(ospId)); // path parameter
            if (serviceTicket != null) localVarHeaderParams.Add("service-ticket", Configuration.ApiClient.ParameterToString(serviceTicket)); // header parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("OspsOspIdComplianceReportGet", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<ComplianceReport>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (ComplianceReport) Configuration.ApiClient.Deserialize(localVarResponse, typeof(ComplianceReport)));
            
        }

        /// <summary>
        /// Get a report. Called by a regulator to obtain a compliance report relating to the specified OSP. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="serviceTicket"></param>
        /// <param name="ospId">the unique identifier of an online service provider</param>
        /// <returns>Task of ComplianceReport</returns>
        public async System.Threading.Tasks.Task<ComplianceReport> OspsOspIdComplianceReportGetAsync (string serviceTicket, string ospId)
        {
             ApiResponse<ComplianceReport> localVarResponse = await OspsOspIdComplianceReportGetAsyncWithHttpInfo(serviceTicket, ospId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get a report. Called by a regulator to obtain a compliance report relating to the specified OSP. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="serviceTicket"></param>
        /// <param name="ospId">the unique identifier of an online service provider</param>
        /// <returns>Task of ApiResponse (ComplianceReport)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<ComplianceReport>> OspsOspIdComplianceReportGetAsyncWithHttpInfo (string serviceTicket, string ospId)
        {
            // verify the required parameter 'serviceTicket' is set
            if (serviceTicket == null)
                throw new ApiException(400, "Missing required parameter 'serviceTicket' when calling ComplianceReportsApi->OspsOspIdComplianceReportGet");
            // verify the required parameter 'ospId' is set
            if (ospId == null)
                throw new ApiException(400, "Missing required parameter 'ospId' when calling ComplianceReportsApi->OspsOspIdComplianceReportGet");

            var localVarPath = "/osps/{osp-id}/compliance-report";
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
            if (ospId != null) localVarPathParams.Add("osp-id", Configuration.ApiClient.ParameterToString(ospId)); // path parameter
            if (serviceTicket != null) localVarHeaderParams.Add("service-ticket", Configuration.ApiClient.ParameterToString(serviceTicket)); // header parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("OspsOspIdComplianceReportGet", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<ComplianceReport>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (ComplianceReport) Configuration.ApiClient.Deserialize(localVarResponse, typeof(ComplianceReport)));
            
        }

    }
}
