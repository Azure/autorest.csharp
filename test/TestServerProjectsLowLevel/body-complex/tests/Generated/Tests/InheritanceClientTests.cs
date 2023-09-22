// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;
using body_complex_LowLevel;

namespace body_complex_LowLevel.Tests
{
    public class InheritanceClientTests : body_complex_LowLevelTestBase
    {
        public InheritanceClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task GetValid_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            InheritanceClient client = CreateInheritanceClient(endpoint, credential);

            Response response = await client.GetValidAsync(null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task GetValid_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            InheritanceClient client = CreateInheritanceClient(endpoint, credential);

            Response response = await client.GetValidAsync(null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task PutValid_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            InheritanceClient client = CreateInheritanceClient(endpoint, credential);

            RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutValidAsync(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task PutValid_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            InheritanceClient client = CreateInheritanceClient(endpoint, credential);

            RequestContent content = RequestContent.Create(new
            {
                breed = "<breed>",
                color = "<color>",
                hates = new List<object>()
{
new
{
food = "<food>",
id = 1234,
name = "<name>",
}
},
                id = 1234,
                name = "<name>",
            });
            Response response = await client.PutValidAsync(content);
        }
    }
}
