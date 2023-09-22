// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using NUnit.Framework;
using body_complex_LowLevel;

namespace body_complex_LowLevel.Tests
{
    public class FlattencomplexClientTests : body_complex_LowLevelTestBase
    {
        public FlattencomplexClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task GetValid_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            FlattencomplexClient client = CreateFlattencomplexClient(credential, endpoint);

            Response response = await client.GetValidAsync(null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task GetValid_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            FlattencomplexClient client = CreateFlattencomplexClient(credential, endpoint);

            Response response = await client.GetValidAsync(null);
        }
    }
}
