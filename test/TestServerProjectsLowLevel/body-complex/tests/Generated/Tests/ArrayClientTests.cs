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
using body_complex_LowLevel;

namespace body_complex_LowLevel.Tests
{
    public partial class ArrayClientTests : body_complex_LowLevelTestBase
    {
        public ArrayClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetValid_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ArrayClient client = CreateArrayClient(endpoint, credential);

            Response response = await client.GetValidAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetValid_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ArrayClient client = CreateArrayClient(endpoint, credential);

            Response response = await client.GetValidAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task PutValid_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ArrayClient client = CreateArrayClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutValidAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task PutValid_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ArrayClient client = CreateArrayClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new
            {
                array = new object[]
            {
"<array>"
            },
            });
            Response response = await client.PutValidAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetEmpty_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ArrayClient client = CreateArrayClient(endpoint, credential);

            Response response = await client.GetEmptyAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetEmpty_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ArrayClient client = CreateArrayClient(endpoint, credential);

            Response response = await client.GetEmptyAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task PutEmpty_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ArrayClient client = CreateArrayClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutEmptyAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task PutEmpty_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ArrayClient client = CreateArrayClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new
            {
                array = new object[]
            {
"<array>"
            },
            });
            Response response = await client.PutEmptyAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetNotProvided_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ArrayClient client = CreateArrayClient(endpoint, credential);

            Response response = await client.GetNotProvidedAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetNotProvided_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ArrayClient client = CreateArrayClient(endpoint, credential);

            Response response = await client.GetNotProvidedAsync(null);
        }
    }
}
