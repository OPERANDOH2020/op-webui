/* 
 * eu.operando.interfaces.aapi
 *
 * Operandos AS interfaces
 *
 * OpenAPI spec version: 0.0.1
 * Contact: kpatsak@gmail.com
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using RestSharp;
using NUnit.Framework;

using eu.operando.interfaces.aapi.Client;
using eu.operando.interfaces.aapi.Api;
using eu.operando.interfaces.aapi.Model;

namespace eu.operando.interfaces.aapi.Test
{
    /// <summary>
    ///  Class for testing DefaultApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by Swagger Codegen.
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    [TestFixture]
    public class DefaultApiTests
    {
        private DefaultApi instance;

        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [SetUp]
        public void Init()
        {
            instance = new DefaultApi();
        }

        /// <summary>
        /// Clean up after each unit test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

        }

        /// <summary>
        /// Test an instance of DefaultApi
        /// </summary>
        [Test]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsInstanceOfType' DefaultApi
            //Assert.IsInstanceOfType(typeof(DefaultApi), instance, "instance is a DefaultApi");
        }

        
        /// <summary>
        /// Test AapiTicketsPost
        /// </summary>
        [Test]
        public void AapiTicketsPostTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //UserCredential userCredential = null;
            //var response = instance.AapiTicketsPost(userCredential);
            //Assert.IsInstanceOf<string> (response, "response is string");
        }
        
        /// <summary>
        /// Test AapiTicketsStValidateGet
        /// </summary>
        [Test]
        public void AapiTicketsStValidateGetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string st = null;
            //string serviceId = null;
            //instance.AapiTicketsStValidateGet(st, serviceId);
            
        }
        
        /// <summary>
        /// Test AapiTicketsTgtPost
        /// </summary>
        [Test]
        public void AapiTicketsTgtPostTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string tgt = null;
            //string serviceId = null;
            //var response = instance.AapiTicketsTgtPost(tgt, serviceId);
            //Assert.IsInstanceOf<string> (response, "response is string");
        }
        
        /// <summary>
        /// Test AapiUserRegisterPost
        /// </summary>
        [Test]
        public void AapiUserRegisterPostTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //User user = null;
            //var response = instance.AapiUserRegisterPost(user);
            //Assert.IsInstanceOf<User> (response, "response is User");
        }
        
        /// <summary>
        /// Test UserUsernameDelete
        /// </summary>
        [Test]
        public void UserUsernameDeleteTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string username = null;
            //var response = instance.UserUsernameDelete(username);
            //Assert.IsInstanceOf<User> (response, "response is User");
        }
        
        /// <summary>
        /// Test UserUsernameGet
        /// </summary>
        [Test]
        public void UserUsernameGetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string username = null;
            //var response = instance.UserUsernameGet(username);
            //Assert.IsInstanceOf<User> (response, "response is User");
        }
        
        /// <summary>
        /// Test UserUsernamePut
        /// </summary>
        [Test]
        public void UserUsernamePutTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string username = null;
            //User user = null;
            //var response = instance.UserUsernamePut(username, user);
            //Assert.IsInstanceOf<User> (response, "response is User");
        }
        
    }

}