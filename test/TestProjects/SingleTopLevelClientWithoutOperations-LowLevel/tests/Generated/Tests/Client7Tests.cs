// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using NUnit.Framework;

namespace SingleTopLevelClientWithoutOperations_LowLevel.Tests
{
    public partial class Client7Tests : SingleTopLevelClientWithoutOperations_LowLevelTestBase
    {
        public Client7Tests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Operation_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Client7 client = CreateTopLevelClientWithoutOperationClient(endpoint, credential).GetClient7Client();

            Response response = await client.OperationAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Operation_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Client7 client = CreateTopLevelClientWithoutOperationClient(endpoint, credential).GetClient7Client();

            Response response = await client.OperationAsync(null);
        }
    }
}
