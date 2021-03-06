/* 
 * Privacy Questionairre API
 *
 * A set of methods to manage privacy quesions.   Privacy questions are generated to form a questionairre that can be displayed to the user. The answers to these questions form a privacy sensitivity index.  For an individual service (OSP) a set of questions can be generated  
 *
 * OpenAPI spec version: 1.0.0
 * Contact: support@operando.eu
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */


using System;
using RestSharp;

namespace eu.operando.core.pc.pq.Client
{
    /// <summary>
    /// A delegate to ExceptionFactory method
    /// </summary>
    /// <param name="methodName">Method name</param>
    /// <param name="response">Response</param>
    /// <returns>Exceptions</returns>
    public delegate Exception ExceptionFactory(string methodName, IRestResponse response);
}
