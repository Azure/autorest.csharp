// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Authentication.Union;
using Azure;
using Azure.Identity;
using NUnit.Framework;

namespace Authentication.Union.Tests
{
    public class UnionClientTests : AuthenticationUnionTestBase
    {
        public UnionClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ValidKey_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            UnionClient client = CreateUnionClient(credential, endpoint);

            Response response = await client.ValidKeyAsync();
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ValidKey_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            UnionClient client = CreateUnionClient(credential, endpoint);

            Response response = await client.ValidKeyAsync();
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ValidToken_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            UnionClient client = CreateUnionClient(credential, endpoint);

            Response response = await client.ValidTokenAsync();
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task ValidToken_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            UnionClient client = CreateUnionClient(credential, endpoint);

            Response response = await client.ValidTokenAsync();
        }
    }
}
