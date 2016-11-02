/* 
 * OSP Enforcement (OSE)
 *
 *  The OSP enforcement component provides a set of functions that manage the interaction of OSP behaviour with the user's private data. The OSE component is largely in charge of ensuring that an OSP follows both privacy regulations and policies put in place by the user (i.e. in the OPERANDO UPPs). There are a set of events that trigger the usage of this API.  1) When a new G2C OSP registers with OPERANDO via the OPERANDO console. The management console informs the OSE, which then checks that an OSP conforms with existing privacy regulations; if it breaches the regulations, the OSE returns via the management console a report describing the breaches.  2) When a change of OSP privacy policy or of the OSP's privacy settings are detected by the watchdog component. The watchdog component sends a message to a privacy analyst who reviews any changes. The privacy analyst may then inform the OSE of the new OSP information (to be checked for compliance with regulations and users' UPPs.  3) When a privacy legislation is entered (or changed) via the Regulator API. The OSE checks registered OSPs for compliance with the new regulations; where there is a breach the OSP is notified either by e-mail or the console. 
 *
 * OpenAPI spec version: 0.0.8
 * Contact: support@operando.eu
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


using NUnit.Framework;

using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using IO.Swagger.Api;
using IO.Swagger.Model;
using IO.Swagger.Client;
using System.Reflection;

namespace IO.Swagger.Test
{
    /// <summary>
    ///  Class for testing PolicyAttribute
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by Swagger Codegen.
    /// Please update the test case below to test the model.
    /// </remarks>
    [TestFixture]
    public class PolicyAttributeTests
    {
        // TODO uncomment below to declare an instance variable for PolicyAttribute
        //private PolicyAttribute instance;

        /// <summary>
        /// Setup before each test
        /// </summary>
        [SetUp]
        public void Init()
        {
            // TODO uncomment below to create an instance of PolicyAttribute
            //instance = new PolicyAttribute();
        }

        /// <summary>
        /// Clean up after each test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

        }

        /// <summary>
        /// Test an instance of PolicyAttribute
        /// </summary>
        [Test]
        public void PolicyAttributeInstanceTest()
        {
            // TODO uncomment below to test "IsInstanceOfType" PolicyAttribute
            //Assert.IsInstanceOfType<PolicyAttribute> (instance, "variable 'instance' is a PolicyAttribute");
        }

        /// <summary>
        /// Test the property 'AttributeName'
        /// </summary>
        [Test]
        public void AttributeNameTest()
        {
            // TODO unit test for the property 'AttributeName'
        }
        /// <summary>
        /// Test the property 'AttributeValue'
        /// </summary>
        [Test]
        public void AttributeValueTest()
        {
            // TODO unit test for the property 'AttributeValue'
        }

    }

}
