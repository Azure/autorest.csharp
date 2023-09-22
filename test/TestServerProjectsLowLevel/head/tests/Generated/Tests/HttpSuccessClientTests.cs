// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using NUnit.Framework;
using head_LowLevel;

namespace head_LowLevel.Tests
{
    public class HttpSuccessClientTests : head_LowLevelTestBase
    {
        public HttpSuccessClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Head200_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            HttpSuccessClient client = CreateHttpSuccessClient(credential, endpoint);

            Response response = await client.Head200Async();
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Head200_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            HttpSuccessClient client = CreateHttpSuccessClient(credential, endpoint);

            Response response = await client.Head200Async();
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Head204_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            HttpSuccessClient client = CreateHttpSuccessClient(credential, endpoint);

            Response response = await client.Head204Async();
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Head204_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            HttpSuccessClient client = CreateHttpSuccessClient(credential, endpoint);

            Response response = await client.Head204Async();
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Head404_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            HttpSuccessClient client = CreateHttpSuccessClient(credential, endpoint);

            Response response = await client.Head404Async();
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Head404_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            HttpSuccessClient client = CreateHttpSuccessClient(credential, endpoint);

            Response response = await client.Head404Async();
        }
    }
}
