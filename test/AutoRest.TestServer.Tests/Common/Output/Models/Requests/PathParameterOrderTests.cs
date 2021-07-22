// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.TestServer.Tests;
using System.Text;
using NUnit.Framework;
using PathParameters;
using Microsoft.Extensions.Primitives;
using System.Threading.Tasks;
using System;

namespace AutoRest.CSharp.Output.Models.Requests.Tests
{
    public class PathParameterOrderTests : InProcTestBase
    {
        [Test]
        public async Task ValidateNormalOrder()
        {
            var testServer = new InProcTestServer(async content =>
            {
                Assert.That(content.Request.Path.ToString(), Does.EndWith("/Microsoft.PathOrder/parents/abc/normalResources/foo"));
                await content.Response.Body.WriteAsync(Encoding.UTF8.GetBytes("{\"name\":\"xyz\"}"));
            });
            var response = await new NormalResourcesRestOperations(ClientDiagnostics, HttpPipeline, "test", testServer.Address).GetAsync("rg1", "abc", "foo");
            // Assert.AreEqual("def", response.Value.Id);
            Assert.AreEqual("xyz", response.Value.Name);
        }

        [Test]
        public async Task ValidateReverseOrder()
        {
            var testServer = new InProcTestServer(async content =>
            {
                Assert.That(content.Request.Path.ToString(), Does.EndWith("/Microsoft.PathOrder/parents/abc/reverseResources/bar"));
                await content.Response.Body.WriteAsync(Encoding.UTF8.GetBytes("{\"name\":\"uvw\"}"));
            });
            var response = await new ReverseResourcesRestOperations(ClientDiagnostics, HttpPipeline, "test", testServer.Address).GetAsync("rg1", "abc", "bar");
            // Assert.AreEqual("ghi", response.Value.Id);
            Assert.AreEqual("uvw", response.Value.Name);
        }
    }
}
