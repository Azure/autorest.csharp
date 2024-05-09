﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Scm._Type.Union;
using Scm._Type.Union.Models;

using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;
using System.ClientModel.Primitives;

namespace CadlRanchProjectsNonAzure.Tests
{
    public class TypeUnionTests : CadlRanchNonAzureTestBase
    {
        [Test]
        public Task GetStringsOnly() => Test(async (host) =>
        {
            var response = await new UnionClient(host, null).GetStringsOnlyClient().GetStringsOnlyAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(GetResponseProp4.B, response.Value.Prop);
        });

        [Test]
        public Task SendStringsOnly() => Test(async (host) =>
        {
            var response = await new UnionClient(host, null).GetStringsOnlyClient().SendAsync(GetResponseProp4.B);
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task GetStringExtensibleOnly() => Test(async (host) =>
        {
            var response = await new UnionClient(host, null).GetStringExtensibleClient().GetStringExtensibleAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(new GetResponseProp3("custom"), response.Value.Prop);
        });

        [Test]
        public Task SendStringExtensibleOnly() => Test(async (host) =>
        {
            var response = await new UnionClient(host, null).GetStringExtensibleClient().SendAsync(new GetResponseProp3("custom"));
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task GetStringExtensibleNamedOnly() => Test(async (host) =>
        {
            var response = await new UnionClient(host, null).GetStringExtensibleNamedClient().GetStringExtensibleNamedAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(new StringExtensibleNamedUnion("custom"), response.Value.Prop);
        });

        [Test]
        public Task SendStringExtensibleNamedOnly() => Test(async (host) =>
        {
            var response = await new UnionClient(host, null).GetStringExtensibleNamedClient().SendAsync(new StringExtensibleNamedUnion("custom"));
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task GetIntsOnly() => Test(async (host) =>
        {
            var response = await new UnionClient(host, null).GetIntsOnlyClient().GetIntsOnlyAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(GetResponseProp2._2, response.Value.Prop);
        });

        [Test]
        public Task SendIntsOnly() => Test(async (host) =>
        {
            var response = await new UnionClient(host, null).GetIntsOnlyClient().SendAsync(GetResponseProp2._2);
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task GetFloatsOnly() => Test(async (host) =>
        {
            var response = await new UnionClient(host, null).GetFloatsOnlyClient().GetFloatsOnlyAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(GetResponseProp1._22, response.Value.Prop);
        });

        [Test]
        public Task SendFloatsOnly() => Test(async (host) =>
        {
            var response = await new UnionClient(host, null).GetFloatsOnlyClient().SendAsync(GetResponseProp1._22);
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task GetModelsOnly() => Test(async (host) =>
        {
            var response = await new UnionClient(host, null).GetModelsOnlyClient().GetModelsOnlyAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            AssertEqual(new Cat("test"), Cat.DeserializeCat(JsonDocument.Parse(response.Value.Prop).RootElement));
        });

        [Test]
        public Task SendModelsOnly() => Test(async (host) =>
        {
            var response = await new UnionClient(host, null).GetModelsOnlyClient().SendAsync(ModelReaderWriter.Write(new Cat("test")));
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });


        [Test]
        public Task GetEnumsOnly() => Test(async (host) =>
        {
            var response = await new UnionClient(host, null).GetEnumsOnlyClient().GetEnumsOnlyAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(EnumsOnlyCasesLr.Right, response.Value.Prop.Lr);
            Assert.AreEqual(EnumsOnlyCasesUd.Up, response.Value.Prop.Ud);
        });

        [Test]
        public Task SendEnumsOnly() => Test(async (host) =>
        {
            var response = await new UnionClient(host, null).GetEnumsOnlyClient().SendAsync(new EnumsOnlyCases(EnumsOnlyCasesLr.Right,
                EnumsOnlyCasesUd.Up));
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task GetStringAndArray() => Test(async (host) =>
        {
            var response = await new UnionClient(host, null).GetStringAndArrayClient().GetStringAndArrayAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            AssertEqual(BinaryData.FromObjectAsJson("test"), response.Value.Prop.String);
            AssertEqual(BinaryData.FromObjectAsJson(new List<string>() { "test1", "test2" }), response.Value.Prop.Array);
        });

        [Test]
        public Task SendStringAndArray() => Test(async (host) =>
        {
            var response = await new UnionClient(host, null).GetStringAndArrayClient().SendAsync(new StringAndArrayCases(BinaryData.FromObjectAsJson("test"),
                BinaryData.FromObjectAsJson(new List<string>() { "test1", "test2" })));
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task GetMixedLiterals() => Test(async (host) =>
        {
            var response = await new UnionClient(host, null).GetMixedLiteralsClient().GetMixedLiteralAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            AssertEqual(BinaryData.FromObjectAsJson("a"), response.Value.Prop.StringLiteral);
            AssertEqual(BinaryData.FromObjectAsJson(2), response.Value.Prop.IntLiteral);
            AssertEqual(BinaryData.FromObjectAsJson(3.3), response.Value.Prop.FloatLiteral);
            AssertEqual(BinaryData.FromObjectAsJson(true), response.Value.Prop.BooleanLiteral);
        });

        [Test]
        public Task SendMixedLiteralsOnlyOnly() => Test(async (host) =>
        {
            var response = await new UnionClient(host, null).GetMixedLiteralsClient().SendAsync(new MixedLiteralsCases(BinaryData.FromObjectAsJson("a"),
                BinaryData.FromObjectAsJson(2),
                BinaryData.FromObjectAsJson(3.3),
                BinaryData.FromObjectAsJson(true)));
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task GetMixedTypes() => Test(async (host) =>
        {
            var response = await new UnionClient(host, null).GetMixedTypesClient().GetMixedTypeAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            AssertEqual(BinaryData.FromObjectAsJson(new { name = "test" }), response.Value.Prop.Model);
            AssertEqual(BinaryData.FromObjectAsJson("a"), response.Value.Prop.Literal);
            AssertEqual(BinaryData.FromObjectAsJson(2), response.Value.Prop.Int);
            AssertEqual(BinaryData.FromObjectAsJson(true), response.Value.Prop.Boolean);
        });

        [Test]
        public Task SendMixedTypesOnlyOnly() => Test(async (host) =>
        {
            var response = await new UnionClient(host, null).GetMixedTypesClient().SendAsync(new MixedTypesCases(
                ModelReaderWriter.Write(new Cat("test")),
                BinaryData.FromObjectAsJson("a"),
                BinaryData.FromObjectAsJson(2),
                BinaryData.FromObjectAsJson(true),
                new[]
                {
                    ModelReaderWriter.Write(new Cat("test")),
                    BinaryData.FromObjectAsJson("a"),
                    BinaryData.FromObjectAsJson(2),
                    BinaryData.FromObjectAsJson(true)
                }));
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        private static void AssertEqual(BinaryData source, BinaryData target)
        {
            BinaryDataAssert.AreEqual(source, target);
        }

        private void AssertEqual(Cat cat1, Cat cat2)
        {
            Assert.IsTrue(cat1 == cat2 || cat1.Name == cat2.Name);
        }
    }
}
