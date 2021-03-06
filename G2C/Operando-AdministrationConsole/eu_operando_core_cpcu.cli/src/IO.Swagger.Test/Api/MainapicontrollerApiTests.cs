/* 
 * REST API for CPCU Operando
 *
 * A REST API to access and edit Questionnaires and Services within the CPCU platform
 *
 * OpenAPI spec version: 2.0
 * Contact: support@operando.eu
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using RestSharp;
using NUnit.Framework;

using IO.Swagger.Client;
using IO.Swagger.Api;
using IO.Swagger.Model;

namespace IO.Swagger.Test
{
    /// <summary>
    ///  Class for testing MainapicontrollerApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by Swagger Codegen.
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    [TestFixture]
    public class MainapicontrollerApiTests
    {
        private MainapicontrollerApi instance;

        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [SetUp]
        public void Init()
        {
            instance = new MainapicontrollerApi();
        }

        /// <summary>
        /// Clean up after each unit test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

        }

        /// <summary>
        /// Test an instance of MainapicontrollerApi
        /// </summary>
        [Test]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsInstanceOfType' MainapicontrollerApi
            //Assert.IsInstanceOfType(typeof(MainapicontrollerApi), instance, "instance is a MainapicontrollerApi");
        }

        
        /// <summary>
        /// Test AddQuestionUsingPOST
        /// </summary>
        [Test]
        public void AddQuestionUsingPOSTTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string questionnaireID = null;
            //QuestionConfiguration qc = null;
            //var response = instance.AddQuestionUsingPOST(questionnaireID, qc);
            //Assert.IsInstanceOf<Object> (response, "response is Object");
        }
        
        /// <summary>
        /// Test CreateQuestionnaireUsingPOST
        /// </summary>
        [Test]
        public void CreateQuestionnaireUsingPOSTTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //QuestionnaireConfiguration qc = null;
            //var response = instance.CreateQuestionnaireUsingPOST(qc);
            //Assert.IsInstanceOf<Object> (response, "response is Object");
        }
        
        /// <summary>
        /// Test CreateServiceUsingPOST
        /// </summary>
        [Test]
        public void CreateServiceUsingPOSTTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //ServiceConfiguration sc = null;
            //var response = instance.CreateServiceUsingPOST(sc);
            //Assert.IsInstanceOf<Object> (response, "response is Object");
        }
        
        /// <summary>
        /// Test DeleteQuestionUsingDELETE
        /// </summary>
        [Test]
        public void DeleteQuestionUsingDELETETest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string questionnaireID = null;
            //string questionID = null;
            //var response = instance.DeleteQuestionUsingDELETE(questionnaireID, questionID);
            //Assert.IsInstanceOf<Object> (response, "response is Object");
        }
        
        /// <summary>
        /// Test DeleteQuestionnaireUsingDELETE
        /// </summary>
        [Test]
        public void DeleteQuestionnaireUsingDELETETest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int? questionnaireID = null;
            //var response = instance.DeleteQuestionnaireUsingDELETE(questionnaireID);
            //Assert.IsInstanceOf<Object> (response, "response is Object");
        }
        
        /// <summary>
        /// Test DeleteServiceUsingDELETE
        /// </summary>
        [Test]
        public void DeleteServiceUsingDELETETest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int? serviceID = null;
            //var response = instance.DeleteServiceUsingDELETE(serviceID);
            //Assert.IsInstanceOf<Object> (response, "response is Object");
        }
        
        /// <summary>
        /// Test GetQuestionPoolUsingGET
        /// </summary>
        [Test]
        public void GetQuestionPoolUsingGETTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int? questionnaireID = null;
            //var response = instance.GetQuestionPoolUsingGET(questionnaireID);
            //Assert.IsInstanceOf<List<QuestionConfiguration>> (response, "response is List<QuestionConfiguration>");
        }
        
        /// <summary>
        /// Test GetQuestionnairesUsingGET
        /// </summary>
        [Test]
        public void GetQuestionnairesUsingGETTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string search = null;
            //string field = null;
            //var response = instance.GetQuestionnairesUsingGET(search, field);
            //Assert.IsInstanceOf<List<QuestionnaireConfiguration>> (response, "response is List<QuestionnaireConfiguration>");
        }
        
        /// <summary>
        /// Test GetQuestionplUsingGET
        /// </summary>
        [Test]
        public void GetQuestionplUsingGETTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //var response = instance.GetQuestionplUsingGET();
            //Assert.IsInstanceOf<List<QuestionConfiguration>> (response, "response is List<QuestionConfiguration>");
        }
        
        /// <summary>
        /// Test GetServicesUsingGET
        /// </summary>
        [Test]
        public void GetServicesUsingGETTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string search = null;
            //string field = null;
            //var response = instance.GetServicesUsingGET(search, field);
            //Assert.IsInstanceOf<List<ServiceConfiguration>> (response, "response is List<ServiceConfiguration>");
        }
        
        /// <summary>
        /// Test GetSpecificQuestionnaireUsingGET
        /// </summary>
        [Test]
        public void GetSpecificQuestionnaireUsingGETTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int? questionnaireID = null;
            //var response = instance.GetSpecificQuestionnaireUsingGET(questionnaireID);
            //Assert.IsInstanceOf<List<QuestionnaireConfiguration>> (response, "response is List<QuestionnaireConfiguration>");
        }
        
        /// <summary>
        /// Test GetSpecificServiceUsingGET
        /// </summary>
        [Test]
        public void GetSpecificServiceUsingGETTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int? serviceID = null;
            //var response = instance.GetSpecificServiceUsingGET(serviceID);
            //Assert.IsInstanceOf<List<ServiceConfiguration>> (response, "response is List<ServiceConfiguration>");
        }
        
        /// <summary>
        /// Test ReloadAppUsingGET
        /// </summary>
        [Test]
        public void ReloadAppUsingGETTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //var response = instance.ReloadAppUsingGET();
            //Assert.IsInstanceOf<Object> (response, "response is Object");
        }
        
        /// <summary>
        /// Test ShowPageUsingGET
        /// </summary>
        [Test]
        public void ShowPageUsingGETTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //var response = instance.ShowPageUsingGET();
            //Assert.IsInstanceOf<ModelAndView> (response, "response is ModelAndView");
        }
        
        /// <summary>
        /// Test UpdateQuestionUsingPOST
        /// </summary>
        [Test]
        public void UpdateQuestionUsingPOSTTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string questionnaireID = null;
            //string questionID = null;
            //QuestionConfiguration qc = null;
            //var response = instance.UpdateQuestionUsingPOST(questionnaireID, questionID, qc);
            //Assert.IsInstanceOf<Object> (response, "response is Object");
        }
        
        /// <summary>
        /// Test UpdateQuestionniareUsingPOST
        /// </summary>
        [Test]
        public void UpdateQuestionniareUsingPOSTTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //QuestionnaireConfiguration qc = null;
            //int? questionnaireID = null;
            //var response = instance.UpdateQuestionniareUsingPOST(qc, questionnaireID);
            //Assert.IsInstanceOf<Object> (response, "response is Object");
        }
        
        /// <summary>
        /// Test UpdateServiceUsingPOST
        /// </summary>
        [Test]
        public void UpdateServiceUsingPOSTTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //ServiceConfiguration sc = null;
            //int? serviceID = null;
            //var response = instance.UpdateServiceUsingPOST(sc, serviceID);
            //Assert.IsInstanceOf<Object> (response, "response is Object");
        }
        
        /// <summary>
        /// Test ValidateQuestionIDUsingGET
        /// </summary>
        [Test]
        public void ValidateQuestionIDUsingGETTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int? questionnaireID = null;
            //int? validateID = null;
            //var response = instance.ValidateQuestionIDUsingGET(questionnaireID, validateID);
            //Assert.IsInstanceOf<Object> (response, "response is Object");
        }
        
        /// <summary>
        /// Test ValidateQuestionnaireIDUsingGET
        /// </summary>
        [Test]
        public void ValidateQuestionnaireIDUsingGETTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int? validateID = null;
            //var response = instance.ValidateQuestionnaireIDUsingGET(validateID);
            //Assert.IsInstanceOf<Object> (response, "response is Object");
        }
        
    }

}
