// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Reflection;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using Azure.Core;
using NUnit.Framework;
using PublicClientCtor;

namespace AutoRest.TestServer.Tests
{
    public class PublicClientCtorTests : TestServerTestBase
    {
        public PublicClientCtorTests(TestServerVersion version) : base(version) { }

        [Test]
        public void PublicClientCtorWithAzureKeyCredential()
        {
            var constructors = typeof(PublicClientCtorClient).GetConstructors(BindingFlags.Instance | BindingFlags.Public);
            Assert.AreEqual(2, constructors.Length);

            var ctor = constructors[0];
            Assert.AreEqual(3, ctor.GetParameters().Length);

            var firstParam = TypeAsserts.HasParameter(ctor, "endpoint");
            Assert.NotNull(firstParam);
            Assert.AreEqual(typeof(Uri), firstParam.ParameterType);

            var secondParam = TypeAsserts.HasParameter(ctor, "credential");
            Assert.NotNull(secondParam);
            Assert.AreEqual(typeof(AzureKeyCredential), secondParam.ParameterType);

            var thirdParam = TypeAsserts.HasParameter(ctor, "options");
            Assert.NotNull(thirdParam);
            Assert.AreEqual(typeof(PublicClientCtorClientOptions), thirdParam.ParameterType);
            Assert.IsTrue(thirdParam.IsOptional);
        }

        [Test]
        public void PublicClientCtorWithTokenCredential()
        {
            var constructors = typeof(PublicClientCtorClient).GetConstructors(BindingFlags.Instance | BindingFlags.Public);
            Assert.AreEqual(2, constructors.Length);

            var ctor = constructors[1];
            Assert.AreEqual(3, ctor.GetParameters().Length);

            var firstParam = TypeAsserts.HasParameter(ctor, "endpoint");
            Assert.NotNull(firstParam);
            Assert.AreEqual(typeof(Uri), firstParam.ParameterType);

            var secondParam = TypeAsserts.HasParameter(ctor, "credential");
            Assert.NotNull(secondParam);
            Assert.AreEqual(typeof(TokenCredential), secondParam.ParameterType);

            var thirdParam = TypeAsserts.HasParameter(ctor, "options");
            Assert.NotNull(thirdParam);
            Assert.AreEqual(typeof(PublicClientCtorClientOptions), thirdParam.ParameterType);
            Assert.IsTrue(thirdParam.IsOptional);
        }
    }
}
