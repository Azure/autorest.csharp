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

namespace httpInfrastructure_LowLevel.Tests
{
    public partial class HttpRetryClientTests : httpInfrastructure_LowLevelTestBase
    {
        public HttpRetryClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Head408_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpRetryClient client = CreateHttpRetryClient(endpoint, credential);

            Response response = await client.Head408Async();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Head408_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpRetryClient client = CreateHttpRetryClient(endpoint, credential);

            Response response = await client.Head408Async();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Put500_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpRetryClient client = CreateHttpRetryClient(endpoint, credential);

            using RequestContent content = null;
            Response response = await client.Put500Async(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Put500_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpRetryClient client = CreateHttpRetryClient(endpoint, credential);

            using RequestContent content = RequestContent.Create("true");
            Response response = await client.Put500Async(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Patch500_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpRetryClient client = CreateHttpRetryClient(endpoint, credential);

            using RequestContent content = null;
            Response response = await client.Patch500Async(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Patch500_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpRetryClient client = CreateHttpRetryClient(endpoint, credential);

            using RequestContent content = RequestContent.Create("true");
            Response response = await client.Patch500Async(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Get502_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpRetryClient client = CreateHttpRetryClient(endpoint, credential);

            Response response = await client.Get502Async();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Get502_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpRetryClient client = CreateHttpRetryClient(endpoint, credential);

            Response response = await client.Get502Async();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Options502_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpRetryClient client = CreateHttpRetryClient(endpoint, credential);

            Response response = await client.Options502Async(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Options502_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpRetryClient client = CreateHttpRetryClient(endpoint, credential);

            Response response = await client.Options502Async(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Post503_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpRetryClient client = CreateHttpRetryClient(endpoint, credential);

            using RequestContent content = null;
            Response response = await client.Post503Async(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Post503_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpRetryClient client = CreateHttpRetryClient(endpoint, credential);

            using RequestContent content = RequestContent.Create("true");
            Response response = await client.Post503Async(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Delete503_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpRetryClient client = CreateHttpRetryClient(endpoint, credential);

            using RequestContent content = null;
            Response response = await client.Delete503Async(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Delete503_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpRetryClient client = CreateHttpRetryClient(endpoint, credential);

            using RequestContent content = RequestContent.Create("true");
            Response response = await client.Delete503Async(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Put504_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpRetryClient client = CreateHttpRetryClient(endpoint, credential);

            using RequestContent content = null;
            Response response = await client.Put504Async(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Put504_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpRetryClient client = CreateHttpRetryClient(endpoint, credential);

            using RequestContent content = RequestContent.Create("true");
            Response response = await client.Put504Async(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Patch504_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpRetryClient client = CreateHttpRetryClient(endpoint, credential);

            using RequestContent content = null;
            Response response = await client.Patch504Async(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Patch504_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpRetryClient client = CreateHttpRetryClient(endpoint, credential);

            using RequestContent content = RequestContent.Create("true");
            Response response = await client.Patch504Async(content);
        }
    }
}
