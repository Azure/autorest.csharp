// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using NUnit.Framework;
using ParameterSequence_LowLevel;

namespace ParameterSequence_LowLevel.Tests
{
    public class ParameterSequenceClientTests : ParameterSequence_LowLevelTestBase
    {
        public ParameterSequenceClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task GetItem_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParameterSequenceClient client = CreateParameterSequenceClient(endpoint, credential);

            Response response = await client.GetItemAsync("<itemName>", "<origin>", null, null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task GetItem_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParameterSequenceClient client = CreateParameterSequenceClient(endpoint, credential);

            Response response = await client.GetItemAsync("<itemName>", "<origin>", "<version>", null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task SelectItem_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParameterSequenceClient client = CreateParameterSequenceClient(endpoint, credential);

            Response response = await client.SelectItemAsync("<itemName>", "<origin>", null, null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task SelectItem_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParameterSequenceClient client = CreateParameterSequenceClient(endpoint, credential);

            Response response = await client.SelectItemAsync("<itemName>", "<origin>", "<version>", null);
        }
    }
}
