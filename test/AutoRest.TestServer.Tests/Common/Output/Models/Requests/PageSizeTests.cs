// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.TestServer.Tests;
using System.Text;
using NUnit.Framework;
using MgmtPagination;
using Microsoft.Extensions.Primitives;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace AutoRest.CSharp.Output.Models.Requests.Tests
{
    public class PageSizeTests : InProcTestBase
    {
        private static Type GetRestOperationsType(string name)
            => typeof(PageSizeIntegerModelResource).Assembly.GetTypes().FirstOrDefault(t => t.Name == name);

        private InProcTestServer testServer = new InProcTestServer(async content =>
        {
            StringValues pageSize;
            Assert.True(content.Request.Query.TryGetValue("maxpagesize", out pageSize));
            Assert.That(pageSize, Has.Count.EqualTo(1));
            Assert.AreEqual("123", pageSize);
            await content.Response.Body.WriteAsync(Encoding.UTF8.GetBytes("{\"value\":[]}"));
        });

        [Test]
        public async Task ValidateInteger()
            => await InvokeInternalMethod(
                GetObject(GetRestOperationsType("PageSizeIntegerModelsRestOperations"), HttpPipeline, "testAppId", testServer.Address),
                "ListAsync",
                "test",
                "test",
                123);

        [Test]
        public async Task ValidateInt64()
            => await InvokeInternalMethod(
                GetObject(GetRestOperationsType("PageSizeInt64ModelsRestOperations"), HttpPipeline, "testAppId", testServer.Address),
                "ListAsync",
                "test",
                "test",
                123);

        [Test]
        public async Task ValidateInt32()
            => await InvokeInternalMethod(
                GetObject(GetRestOperationsType("PageSizeInt32ModelsRestOperations"), HttpPipeline, "testAppId", testServer.Address),
                "ListAsync",
                "test",
                "test",
                123);

        [Test]
        public async Task ValidateNumeric()
            => await InvokeInternalMethod(
                GetObject(GetRestOperationsType("PageSizeNumericModelsRestOperations"), HttpPipeline, "testAppId", testServer.Address),
                "ListAsync",
                "test",
                "test",
                123);

        [Test]
        public async Task ValidateFloat()
            => await InvokeInternalMethod(
                GetObject(GetRestOperationsType("PageSizeFloatModelsRestOperations"), HttpPipeline, "testAppId", testServer.Address),
                "ListAsync",
                "test",
                "test",
                123);

        [Test]
        public async Task ValidateDouble()
            => await InvokeInternalMethod(
                GetObject(GetRestOperationsType("PageSizeDoubleModelsRestOperations"), HttpPipeline, "testAppId", testServer.Address),
                "ListAsync",
                "test",
                "test",
                123);

        [Test]
        public async Task ValidateDecimal()
            => await InvokeInternalMethod(
                GetObject(GetRestOperationsType("PageSizeDecimalModelsRestOperations"), HttpPipeline, "testAppId", testServer.Address),
                "ListAsync",
                "test",
                "test",
                123);

        [Test]
        public async Task ValidateString()
            => await InvokeInternalMethod(
                GetObject(GetRestOperationsType("PageSizeStringModelsRestOperations"), HttpPipeline, "testAppId", testServer.Address),
                "ListAsync",
                "test",
                "test",
                Convert.ToString(123));
    }
}
