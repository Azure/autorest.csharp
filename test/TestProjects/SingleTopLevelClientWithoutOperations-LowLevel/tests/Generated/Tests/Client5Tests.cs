// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using NUnit.Framework;
using SingleTopLevelClientWithoutOperations_LowLevel;

namespace SingleTopLevelClientWithoutOperations_LowLevel.Tests
{
    public class Client5Tests : SingleTopLevelClientWithoutOperations_LowLevelTestBase
    {
        public Client5Tests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Operation_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Client5 client = CreateTopLevelClientWithoutOperationClient(credential, endpoint).GetClient5Client();

            Response response = await client.OperationAsync(null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Operation_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Client5 client = CreateTopLevelClientWithoutOperationClient(credential, endpoint).GetClient5Client();

            Response response = await client.OperationAsync(null);
        }
    }
}
