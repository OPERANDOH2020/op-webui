/* 
 * Policy DB
 *
 * The Policy Database that stores three types of documents in dedicated collections.   1) User Privacy Policy. Each OPERANDO user has one UPP document describing their privacy policies for each of the OSP services they are subscribed to. The UPP contains the current B2C privacy settings for a subscribed to OSP. The UPP contains the users privacy preferences. The UPP contains the G2C access policies for the OSP with justification for access.   2) The legislation policies. The regulations entered into OPERANDO using the OPERANDO regulation API.   3) The OSP descriptions and data requests. For each OSP its privacy policy, its access control rules, and the data it requests (as a workflow). For B2C, the set of privacy settings is stored. 
 *
 * OpenAPI spec version: 1.0.0
 * Contact: support@operando.eu
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
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
    ///  Class for testing OSPPrivacyPolicy
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by Swagger Codegen.
    /// Please update the test case below to test the model.
    /// </remarks>
    [TestFixture]
    public class OSPPrivacyPolicyTests
    {
        // TODO uncomment below to declare an instance variable for OSPPrivacyPolicy
        //private OSPPrivacyPolicy instance;

        /// <summary>
        /// Setup before each test
        /// </summary>
        [SetUp]
        public void Init()
        {
            // TODO uncomment below to create an instance of OSPPrivacyPolicy
            //instance = new OSPPrivacyPolicy();
        }

        /// <summary>
        /// Clean up after each test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

        }

        /// <summary>
        /// Test an instance of OSPPrivacyPolicy
        /// </summary>
        [Test]
        public void OSPPrivacyPolicyInstanceTest()
        {
            // TODO uncomment below to test "IsInstanceOfType" OSPPrivacyPolicy
            //Assert.IsInstanceOfType<OSPPrivacyPolicy> (instance, "variable 'instance' is a OSPPrivacyPolicy");
        }

        /// <summary>
        /// Test the property 'OspPolicyId'
        /// </summary>
        [Test]
        public void OspPolicyIdTest()
        {
            // TODO unit test for the property 'OspPolicyId'
        }
        /// <summary>
        /// Test the property 'PolicyText'
        /// </summary>
        [Test]
        public void PolicyTextTest()
        {
            // TODO unit test for the property 'PolicyText'
        }
        /// <summary>
        /// Test the property 'PolicyUrl'
        /// </summary>
        [Test]
        public void PolicyUrlTest()
        {
            // TODO unit test for the property 'PolicyUrl'
        }
        /// <summary>
        /// Test the property 'Workflow'
        /// </summary>
        [Test]
        public void WorkflowTest()
        {
            // TODO unit test for the property 'Workflow'
        }
        /// <summary>
        /// Test the property 'Policies'
        /// </summary>
        [Test]
        public void PoliciesTest()
        {
            // TODO unit test for the property 'Policies'
        }

    }

}
