// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;
using Parameters.Spread;

namespace Parameters.Spread.Tests
{
    public class AliasTests : ParametersSpreadTestBase
    {
        public AliasTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task SpreadAsRequestBody_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Alias client = CreateSpreadClient(endpoint).GetAliasClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
            });
            Response response = await client.SpreadAsRequestBodyAsync(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task SpreadAsRequestBody_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Alias client = CreateSpreadClient(endpoint).GetAliasClient(apiVersion: "1.0.0");

            Response response = await client.SpreadAsRequestBodyAsync("<name>");
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task SpreadAsRequestBody_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Alias client = CreateSpreadClient(endpoint).GetAliasClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
            });
            Response response = await client.SpreadAsRequestBodyAsync(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task SpreadAsRequestBody_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Alias client = CreateSpreadClient(endpoint).GetAliasClient(apiVersion: "1.0.0");

            Response response = await client.SpreadAsRequestBodyAsync("<name>");
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task SpreadAsRequestParameter_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Alias client = CreateSpreadClient(endpoint).GetAliasClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
            });
            Response response = await client.SpreadAsRequestParameterAsync("<id>", "<x-ms-test-header>", content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task SpreadAsRequestParameter_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Alias client = CreateSpreadClient(endpoint).GetAliasClient(apiVersion: "1.0.0");

            Response response = await client.SpreadAsRequestParameterAsync("<id>", "<x-ms-test-header>", "<name>");
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task SpreadAsRequestParameter_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Alias client = CreateSpreadClient(endpoint).GetAliasClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
            });
            Response response = await client.SpreadAsRequestParameterAsync("<id>", "<x-ms-test-header>", content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task SpreadAsRequestParameter_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Alias client = CreateSpreadClient(endpoint).GetAliasClient(apiVersion: "1.0.0");

            Response response = await client.SpreadAsRequestParameterAsync("<id>", "<x-ms-test-header>", "<name>");
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task SpreadWithMultipleParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Alias client = CreateSpreadClient(endpoint).GetAliasClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                prop1 = "<prop1>",
                prop2 = "<prop2>",
                prop3 = "<prop3>",
                prop4 = "<prop4>",
                prop5 = "<prop5>",
                prop6 = "<prop6>",
            });
            Response response = await client.SpreadWithMultipleParametersAsync("<id>", "<x-ms-test-header>", content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task SpreadWithMultipleParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Alias client = CreateSpreadClient(endpoint).GetAliasClient(apiVersion: "1.0.0");

            Response response = await client.SpreadWithMultipleParametersAsync("<id>", "<x-ms-test-header>", "<prop1>", "<prop2>", "<prop3>", "<prop4>", "<prop5>", "<prop6>");
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task SpreadWithMultipleParameters_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Alias client = CreateSpreadClient(endpoint).GetAliasClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                prop1 = "<prop1>",
                prop2 = "<prop2>",
                prop3 = "<prop3>",
                prop4 = "<prop4>",
                prop5 = "<prop5>",
                prop6 = "<prop6>",
            });
            Response response = await client.SpreadWithMultipleParametersAsync("<id>", "<x-ms-test-header>", content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task SpreadWithMultipleParameters_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Alias client = CreateSpreadClient(endpoint).GetAliasClient(apiVersion: "1.0.0");

            Response response = await client.SpreadWithMultipleParametersAsync("<id>", "<x-ms-test-header>", "<prop1>", "<prop2>", "<prop3>", "<prop4>", "<prop5>", "<prop6>");
        }
    }
}
