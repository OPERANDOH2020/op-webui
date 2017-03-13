/* 
 * Policy DB
 *
 * The Policy Database that stores three types of documents in dedicated collections.   1) User Privacy Policy. Each OPERANDO user has one UPP document describing their privacy policies for each of the OSP services they are subscribed to. The UPP contains the current B2C privacy settings for a subscribed to OSP. The UPP contains the users privacy preferences. The UPP contains the G2C access policies for the OSP with justification for access.   2) The legislation policies. The regulations entered into OPERANDO using the OPERANDO regulation API.   3) The OSP descriptions and data requests. For each OSP its privacy policy, its access control rules, and the data it requests (as a workflow). For B2C, the set of privacy settings is stored. 
 *
 * OpenAPI spec version: 1.0.0
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
    ///  Class for testing UPPApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by Swagger Codegen.
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    [TestFixture]
    public class UPPApiTests
    {
        private UPPApi instance;

        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [SetUp]
        public void Init()
        {
            instance = new UPPApi();
        }

        /// <summary>
        /// Clean up after each unit test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

        }

        /// <summary>
        /// Test an instance of UPPApi
        /// </summary>
        [Test]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsInstanceOfType' UPPApi
            //Assert.IsInstanceOfType(typeof(UPPApi), instance, "instance is a UPPApi");
        }

        
        /// <summary>
        /// Test UserPrivacyPolicyGet
        /// </summary>
        [Test]
        public void UserPrivacyPolicyGetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string filter = null;
            //var response = instance.UserPrivacyPolicyGet(filter);
            //Assert.IsInstanceOf<List<UserPrivacyPolicy>> (response, "response is List<UserPrivacyPolicy>");
        }
        
        /// <summary>
        /// Test UserPrivacyPolicyPost
        /// </summary>
        [Test]
        public void UserPrivacyPolicyPostTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //UserPrivacyPolicy upp = null;
            //var response = instance.UserPrivacyPolicyPost(upp);
            //Assert.IsInstanceOf<string> (response, "response is string");
        }
        
        /// <summary>
        /// Test UserPrivacyPolicyUserIdDelete
        /// </summary>
        [Test]
        public void UserPrivacyPolicyUserIdDeleteTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string userId = null;
            //instance.UserPrivacyPolicyUserIdDelete(userId);
            
        }
        
        /// <summary>
        /// Test UserPrivacyPolicyUserIdGet
        /// </summary>
        [Test]
        public void UserPrivacyPolicyUserIdGetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string userId = null;
            //var response = instance.UserPrivacyPolicyUserIdGet(userId);
            //Assert.IsInstanceOf<UserPrivacyPolicy> (response, "response is UserPrivacyPolicy");
        }
        
        /// <summary>
        /// Test UserPrivacyPolicyUserIdPut
        /// </summary>
        [Test]
        public void UserPrivacyPolicyUserIdPutTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string userId = null;
            //UserPrivacyPolicy upp = null;
            //instance.UserPrivacyPolicyUserIdPut(userId, upp);
            
        }
        
    }

}