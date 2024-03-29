// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using NUnit.Framework;

namespace SingleTopLevelClientWithOperations_LowLevel.Tests
{
    public partial class Client1Tests : SingleTopLevelClientWithOperations_LowLevelTestBase
    {
        public Client1Tests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Operation_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Client1 client = CreateTopLevelClientWithOperationClient(endpoint, credential).GetClient1Client();

            Response response = await client.OperationAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Operation_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Client1 client = CreateTopLevelClientWithOperationClient(endpoint, credential).GetClient1Client();

            Response response = await client.OperationAsync(null);
        }
    }
}
