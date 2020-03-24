﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;
using validation;
using validation.Models;

namespace AutoRest.TestServer.Tests
{
    public class ValidationTests : TestServerTestBase
    {
        public ValidationTests(TestServerVersion version) : base(version, "validation") { }

        [Test]
        public Task ConstantsInBody() => Test(async (host, pipeline) =>
        {
            var value = new Product(new ChildProduct(), new ConstantProduct());
            var result = await new ServiceClient(ClientDiagnostics, pipeline, string.Empty, host).PostWithConstantInBodyAsync(value);
            Assert.AreEqual(value.ConstString, result.Value.ConstString);
            Assert.AreEqual(value.ConstInt, result.Value.ConstInt);
            Assert.AreEqual(value.Child.ConstProperty, result.Value.Child.ConstProperty);
            Assert.AreEqual(value.ConstChild.ConstProperty, result.Value.ConstChild.ConstProperty);
            Assert.AreEqual(value.ConstChild.ConstProperty2, result.Value.ConstChild.ConstProperty2);
        });

        [Test]
        public Task ConstantsInPath() => TestStatus(async (host, pipeline) => await new ServiceClient(ClientDiagnostics, pipeline, string.Empty, host).GetWithConstantInPathAsync());

        [Test]
        public void ConstructorsCheckRequiredProperties()
        {
            Assert.Throws<ArgumentNullException>(() => new Product(null, new ConstantProduct()));
            Assert.Throws<ArgumentNullException>(() => new Product(new ChildProduct(), null));
        }
    }
}
