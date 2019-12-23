// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;
using validation;
using validation.Models.V100;

namespace AutoRest.TestServer.Tests
{
    public class ValidationTests : TestServerTestBase
    {
        public ValidationTests(TestServerVersion version) : base(version, "validation") { }

        [Test]
        public Task ConstantsInBody() => Test(async (host, pipeline) =>
        {
            var value = new Product
            {
                ConstString = "constant",
                ConstInt = 0,
                Child = new ChildProduct
                {
                    ConstProperty = "constant"
                },
                ConstChild = new ConstantProduct
                {
                    ConstProperty = "constant",
                    ConstProperty2 = "constant2"
                }
            };
            var result = await new AllOperations(ClientDiagnostics, pipeline, host).PostWithConstantInBodyAsync( value);
            Assert.AreEqual(value.ConstString, result.Value.ConstString);
            Assert.AreEqual(value.ConstInt, result.Value.ConstInt);
            Assert.AreEqual(value.Child.ConstProperty, result.Value.Child.ConstProperty);
            Assert.AreEqual(value.ConstChild.ConstProperty, result.Value.ConstChild.ConstProperty);
            Assert.AreEqual(value.ConstChild.ConstProperty2, result.Value.ConstChild.ConstProperty2);
        });

        [Test]
        public Task ConstantsInPath() => TestStatus(async (host, pipeline) => await new AllOperations(ClientDiagnostics, pipeline, host).GetWithConstantInPathAsync());
    }
}
