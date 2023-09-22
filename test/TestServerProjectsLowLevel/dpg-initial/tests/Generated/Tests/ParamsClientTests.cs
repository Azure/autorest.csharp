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
using dpg_initial_LowLevel;

namespace dpg_initial_LowLevel.Tests
{
    public class ParamsClientTests : dpg_initial_LowLevelTestBase
    {
        public ParamsClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task HeadNoParams_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ParamsClient client = CreateParamsClient(credential, endpoint);

            Response response = await client.HeadNoParamsAsync(null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task HeadNoParams_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ParamsClient client = CreateParamsClient(credential, endpoint);

            Response response = await client.HeadNoParamsAsync(null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task GetRequired_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ParamsClient client = CreateParamsClient(credential, endpoint);

            Response response = await client.GetRequiredAsync("<parameter>", null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task GetRequired_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ParamsClient client = CreateParamsClient(credential, endpoint);

            Response response = await client.GetRequiredAsync("<parameter>", null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task PutRequiredOptional_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ParamsClient client = CreateParamsClient(credential, endpoint);

            Response response = await client.PutRequiredOptionalAsync("<requiredParam>", null, null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task PutRequiredOptional_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ParamsClient client = CreateParamsClient(credential, endpoint);

            Response response = await client.PutRequiredOptionalAsync("<requiredParam>", "<optionalParam>", null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task PostParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ParamsClient client = CreateParamsClient(credential, endpoint);

            RequestContent content = RequestContent.Create(new
            {
                url = "<url>",
            });
            Response response = await client.PostParametersAsync(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task PostParameters_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ParamsClient client = CreateParamsClient(credential, endpoint);

            RequestContent content = RequestContent.Create(new
            {
                url = "<url>",
            });
            Response response = await client.PostParametersAsync(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task GetOptional_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ParamsClient client = CreateParamsClient(credential, endpoint);

            Response response = await client.GetOptionalAsync(null, null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task GetOptional_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ParamsClient client = CreateParamsClient(credential, endpoint);

            Response response = await client.GetOptionalAsync("<optionalParam>", null);
        }
    }
}
