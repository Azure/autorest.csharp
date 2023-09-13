// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Text.Json;
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

        [Test]
        public Task Type_Union_receiveString() => Test(async (host) =>
        {
            var response = await new UnionClient(host, null).ReceiveStringAsync(null); // explicitly pass null to call the protocol method
            Assert.AreEqual(200, response.Status);

            var root = JsonDocument.Parse(response.ContentStream).RootElement;
            Assert.AreEqual("string", root.GetProperty("simpleUnion").GetString());
        });

        [Test]
        public Task Type_Union_receiveIntArray() => Test(async (host) =>
        {
            var response = await new UnionClient(host, null).ReceiveIntArrayAsync(null); // explicitly pass null to call the protocol method
            Assert.AreEqual(200, response.Status);

            var root = JsonDocument.Parse(response.ContentStream).RootElement;
            var array = root.GetProperty("simpleUnion").EnumerateArray().Select(e => e.GetInt32());
            CollectionAssert.AreEquivalent(new[] { 1, 2 }, array);
        });

        [Test]
        public Task Type_Union_receiveFirstNamedUnionValue() => Test(async (host) =>
        {
            var response = await new UnionClient(host, null).ReceiveFirstNamedUnionValueAsync(null);
            Assert.AreEqual(200, response.Status);

            var root = JsonDocument.Parse(response.ContentStream).RootElement;
            Assert.AreEqual("model1", root.GetProperty("namedUnion").GetProperty("name").GetString());
            Assert.AreEqual(1, root.GetProperty("namedUnion").GetProperty("prop1").GetInt32());
        });

        [Test]
        public Task Type_Union_receiveSecondNamedUnionValue() => Test(async (host) =>
        {
            var response = await new UnionClient(host, null).ReceiveSecondNamedUnionValueAsync(null);
            Assert.AreEqual(200, response.Status);

            var root = JsonDocument.Parse(response.ContentStream).RootElement;
            Assert.AreEqual("model2", root.GetProperty("namedUnion").GetProperty("name").GetString());
            Assert.AreEqual(2, root.GetProperty("namedUnion").GetProperty("prop2").GetInt32());
        });
    }
}
