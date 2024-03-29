// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using NUnit.Framework;
using httpInfrastructure_LowLevel;

namespace httpInfrastructure_LowLevel.Tests
{
    public partial class HttpFailureClientTests : httpInfrastructure_LowLevelTestBase
    {
        public HttpFailureClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetEmptyError_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpFailureClient client = CreateHttpFailureClient(endpoint, credential);

            Response response = await client.GetEmptyErrorAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetEmptyError_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpFailureClient client = CreateHttpFailureClient(endpoint, credential);

            Response response = await client.GetEmptyErrorAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetNoModelError_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpFailureClient client = CreateHttpFailureClient(endpoint, credential);

            Response response = await client.GetNoModelErrorAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetNoModelError_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpFailureClient client = CreateHttpFailureClient(endpoint, credential);

            Response response = await client.GetNoModelErrorAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetNoModelEmpty_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpFailureClient client = CreateHttpFailureClient(endpoint, credential);

            Response response = await client.GetNoModelEmptyAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetNoModelEmpty_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpFailureClient client = CreateHttpFailureClient(endpoint, credential);

            Response response = await client.GetNoModelEmptyAsync(null);
        }
    }
}
