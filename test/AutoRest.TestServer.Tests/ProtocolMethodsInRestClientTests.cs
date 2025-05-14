// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Reflection;
using Azure;
using Azure.Core;
using NUnit.Framework;
using ProtocolMethodsInRestClient;
using ProtocolMethodsInRestClient.Models;
using static AutoRest.TestServer.Tests.Infrastructure.TestServerTestBase;

namespace AutoRest.TestServer.Tests
{
    internal class ProtocolMethodsInRestClientTests
    {
        [TestCase("Create", "TestServiceRestClient")]
        [TestCase("CreateAsync", "TestServiceRestClient")]
        [TestCase("Delete", "TestServiceRestClient")]
        [TestCase("DeleteAsync", "TestServiceRestClient")]

        [TestCase("Create", "FirstTemplateRestClient")]
        [TestCase("CreateAsync", "FirstTemplateRestClient")]
        [TestCase("Get", "FirstTemplateRestClient")]
        [TestCase("GetAsync", "FirstTemplateRestClient")]

        [TestCase("Get", "SecondTemplateRestClient")]
        [TestCase("GetAsync", "SecondTemplateRestClient")]
        public void ProtocolMethodGeneratedInRestClient(string methodName, string clientTypeName)
        {
            var clientType = FindType(typeof(TestServiceClient).Assembly, clientTypeName);
            var methods = clientType.GetMethods();
            Assert.IsNotNull(methods);

            var restClientMethods = methods.Where(m => m.Name.Equals(methodName));
            Assert.AreEqual(2, restClientMethods.Count());

            var isProtocolMethodExists = false;
            foreach (var method in restClientMethods)
            {
                if (method.GetParameters().Any(p => p.ParameterType.Equals(typeof(RequestContext))))
                {
                    isProtocolMethodExists = true;
                }
            }

            Assert.IsTrue(isProtocolMethodExists);
        }

        [TestCase("Get", "TestServiceRestClient")]
        [TestCase("GetAsync", "TestServiceRestClient")]

        [TestCase("Delete", "FirstTemplateRestClient")]
        [TestCase("DeleteAsync", "FirstTemplateRestClient")]

        [TestCase("Create", "SecondTemplateRestClient")]
        [TestCase("CreateAsync", "SecondTemplateRestClient")]
        [TestCase("Delete", "SecondTemplateRestClient")]
        [TestCase("DeleteAsync", "SecondTemplateRestClient")]

        [TestCase("Create", "ThirdTemplateRestClient")]
        [TestCase("CreateAsync", "ThirdTemplateRestClient")]
        [TestCase("Delete", "ThirdTemplateRestClient")]
        [TestCase("DeleteAsync", "ThirdTemplateRestClient")]
        [TestCase("Get", "ThirdTemplateRestClient")]
        [TestCase("GetAsync", "ThirdTemplateRestClient")]
        public void ProtocolMethodNotGeneratedInRestClient(string methodName, string clientTypeName)
        {
            var clientType = FindType(typeof(TestServiceClient).Assembly, clientTypeName);
            var methods = clientType.GetMethods();
            Assert.IsNotNull(methods);

            var restClientMethods = methods.Where(m => m.Name.Equals(methodName));
            Assert.AreEqual(1, restClientMethods.Count());
            var parameters = restClientMethods.FirstOrDefault().GetParameters();
            Assert.IsFalse(parameters.Any(p => p.GetType().Equals(typeof(RequestContext))));
        }

        [Test]
        public void CorrectSignatureForGroupedParameters()
        {
            TypeAsserts.HasInternalInstanceMethod(
                FindType(typeof(TestServiceClient).Assembly, "TestServiceRestClient"),
                "CreateCreateRequest",
                new TypeAsserts.Parameter[] {
                    new("grouped", typeof(Grouped)),
                    new("resource", typeof(Resource))
                });

            TypeAsserts.HasInternalInstanceMethod(
                FindType(typeof(TestServiceClient).Assembly, "TestServiceRestClient"),
                "CreateCreateRequest",
                new TypeAsserts.Parameter[] {
                    new("second", typeof(int)),
                    new("content", typeof(RequestContent)),
                    new("first", typeof(string)),
                    new("context", typeof(RequestContext))
                });
        }

        [Test]
        public void RepeatabilityHeadersNotInMethodSignature()
        {
            foreach (var m in FindType(typeof(TestServiceClient).Assembly, "TestServiceRestClient").GetMethods(BindingFlags.Public | BindingFlags.Instance).Where(m => m.Name.StartsWith("Create")))
            {
                Assert.False(m.GetParameters().Any(p => p.Name == "repeatabilityRequestId" || p.Name == "repeatabilityFirstSent"));
            }
        }
    }
}
