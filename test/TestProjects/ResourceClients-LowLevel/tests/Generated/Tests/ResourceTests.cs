// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using NUnit.Framework;
using ResourceClients_LowLevel;

namespace ResourceClients_LowLevel.Tests
{
    public class ResourceTests : ResourceClients_LowLevelTestBase
    {
        public ResourceTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task GetItem_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Resource client = CreateResourceServiceClient(credential, endpoint).GetResourceGroup("<GroupId>").GetResource("<ItemId>");

            Response response = await client.GetItemAsync(null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task GetItem_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Resource client = CreateResourceServiceClient(credential, endpoint).GetResourceGroup("<GroupId>").GetResource("<ItemId>");

            Response response = await client.GetItemAsync(null);
        }
    }
}
