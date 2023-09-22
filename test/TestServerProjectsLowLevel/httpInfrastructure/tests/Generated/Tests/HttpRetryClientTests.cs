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
using httpInfrastructure_LowLevel;

namespace httpInfrastructure_LowLevel.Tests
{
    public class HttpRetryClientTests : httpInfrastructure_LowLevelTestBase
    {
        public HttpRetryClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Head408_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            HttpRetryClient client = CreateHttpRetryClient(credential, endpoint);

            Response response = await client.Head408Async();
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Head408_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            HttpRetryClient client = CreateHttpRetryClient(credential, endpoint);

            Response response = await client.Head408Async();
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Put500_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            HttpRetryClient client = CreateHttpRetryClient(credential, endpoint);

            RequestContent content = null;
            Response response = await client.Put500Async(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Put500_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            HttpRetryClient client = CreateHttpRetryClient(credential, endpoint);

            RequestContent content = RequestContent.Create("true");
            Response response = await client.Put500Async(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Patch500_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            HttpRetryClient client = CreateHttpRetryClient(credential, endpoint);

            RequestContent content = null;
            Response response = await client.Patch500Async(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Patch500_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            HttpRetryClient client = CreateHttpRetryClient(credential, endpoint);

            RequestContent content = RequestContent.Create("true");
            Response response = await client.Patch500Async(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Get502_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            HttpRetryClient client = CreateHttpRetryClient(credential, endpoint);

            Response response = await client.Get502Async();
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Get502_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            HttpRetryClient client = CreateHttpRetryClient(credential, endpoint);

            Response response = await client.Get502Async();
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Options502_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            HttpRetryClient client = CreateHttpRetryClient(credential, endpoint);

            Response response = await client.Options502Async(null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Options502_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            HttpRetryClient client = CreateHttpRetryClient(credential, endpoint);

            Response response = await client.Options502Async(null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Post503_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            HttpRetryClient client = CreateHttpRetryClient(credential, endpoint);

            RequestContent content = null;
            Response response = await client.Post503Async(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Post503_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            HttpRetryClient client = CreateHttpRetryClient(credential, endpoint);

            RequestContent content = RequestContent.Create("true");
            Response response = await client.Post503Async(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Delete503_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            HttpRetryClient client = CreateHttpRetryClient(credential, endpoint);

            RequestContent content = null;
            Response response = await client.Delete503Async(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Delete503_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            HttpRetryClient client = CreateHttpRetryClient(credential, endpoint);

            RequestContent content = RequestContent.Create("true");
            Response response = await client.Delete503Async(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Put504_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            HttpRetryClient client = CreateHttpRetryClient(credential, endpoint);

            RequestContent content = null;
            Response response = await client.Put504Async(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Put504_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            HttpRetryClient client = CreateHttpRetryClient(credential, endpoint);

            RequestContent content = RequestContent.Create("true");
            Response response = await client.Put504Async(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Patch504_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            HttpRetryClient client = CreateHttpRetryClient(credential, endpoint);

            RequestContent content = null;
            Response response = await client.Patch504Async(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Patch504_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            HttpRetryClient client = CreateHttpRetryClient(credential, endpoint);

            RequestContent content = RequestContent.Create("true");
            Response response = await client.Patch504Async(content);
        }
    }
}
