// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.TestServer.Tests;
using System.Text;
using NUnit.Framework;
using Pagination;
using Microsoft.Extensions.Primitives;
using System.Threading.Tasks;
using System;

namespace AutoRest.CSharp.Output.Models.Requests.Tests
{
    public class PageSizeTests : InProcTestBase
    {
        private InProcTestServer testServer = new InProcTestServer(async content =>
        {
            StringValues pageSize;
            Assert.True(content.Request.Query.TryGetValue("maxpagesize", out pageSize));
            Assert.That(pageSize, Has.Count.EqualTo(1));
            Assert.AreEqual("123", pageSize);
            await content.Response.Body.WriteAsync(Encoding.UTF8.GetBytes("{\"value\":[]}"));
        });

        [Test]
        public async Task ValidateInteger() => await new PageSizeIntegerModelsRestOperations(ClientDiagnostics, HttpPipeline, "test", testServer.Address).ListAsync("test", 123);

        [Test]
        public async Task ValidateInt64() => await new PageSizeInt64ModelsRestOperations(ClientDiagnostics, HttpPipeline, "test", testServer.Address).ListAsync("test", 123);

        [Test]
        public async Task ValidateInt32() => await new PageSizeInt32ModelsRestOperations(ClientDiagnostics, HttpPipeline, "test", testServer.Address).ListAsync("test", 123);

        [Test]
        public async Task ValidateNumeric() => await new PageSizeNumericModelsRestOperations(ClientDiagnostics, HttpPipeline, "test", testServer.Address).ListAsync("test", 123);

        [Test]
        public async Task ValidateFloat() => await new PageSizeFloatModelsRestOperations(ClientDiagnostics, HttpPipeline, "test", testServer.Address).ListAsync("test", 123);

        [Test]
        public async Task ValidateDouble() => await new PageSizeDoubleModelsRestOperations(ClientDiagnostics, HttpPipeline, "test", testServer.Address).ListAsync("test", 123);

        [Test]
        public async Task ValidateDecimal() => await new PageSizeDecimalModelsRestOperations(ClientDiagnostics, HttpPipeline, "test", testServer.Address).ListAsync("test", 123);

        [Test]
        public async Task ValidateString() => await new PageSizeStringModelsRestOperations(ClientDiagnostics, HttpPipeline, "test", testServer.Address).ListAsync("test", Convert.ToString(123));
    }
}
