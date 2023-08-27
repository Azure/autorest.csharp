// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using _Type.Union;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure.Core;
using NUnit.Framework;

namespace CadlRanchProjects.Tests
{
    public class TypeUnionTests : CadlRanchTestBase
    {
        [Test]
        public Task Type_Union_sendFirstNamedUnionValue() => Test(async (host) =>
        {
            var data = new
            {
                namedUnion = new
                {
                    name = "model1",
                    prop1 = 1
                }
            };
            var response = await new UnionClient(host, null).SendFirstNamedUnionValueAsync(RequestContent.Create(data));
            Assert.AreEqual(200, response.Status);
        });

        [Test]
        public Task Type_Union_sendSecondNamedUnionValue() => Test(async (host) =>
        {
            var data = new
            {
                namedUnion = new
                {
                    name = "model2",
                    prop2 = 2
                }
            };
            var response = await new UnionClient(host, null).SendSecondNamedUnionValueAsync(RequestContent.Create(data));
            Assert.AreEqual(200, response.Status);
        });

        [Test]
        public Task Type_Union_sendInt() => Test(async (host) =>
        {
            var data = new
            {
                simpleUnion = 1
            };
            var response = await new UnionClient(host, null).SendIntAsync(RequestContent.Create(data));
            Assert.AreEqual(200, response.Status);
        });

        [Test]
        public Task Type_Union_sendIntArray() => Test(async (host) =>
        {
            var data = new
            {
                simpleUnion = new[] { 1, 2 }
            };
            var response = await new UnionClient(host, null).SendIntArrayAsync(RequestContent.Create(data));
            Assert.AreEqual(200, response.Status);
        });
    }
}
