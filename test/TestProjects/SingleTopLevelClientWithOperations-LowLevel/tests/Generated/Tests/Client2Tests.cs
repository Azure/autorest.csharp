// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using NUnit.Framework;
using SingleTopLevelClientWithOperations_LowLevel;

namespace SingleTopLevelClientWithOperations_LowLevel.Tests
{
    public partial class Client2Tests : SingleTopLevelClientWithOperations_LowLevelTestBase
    {
        public Client2Tests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task Operation_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Client2 client = CreateTopLevelClientWithOperationClient(endpoint, credential).GetClient2Client();

            Response response = await client.OperationAsync(null);
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task Operation_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Client2 client = CreateTopLevelClientWithOperationClient(endpoint, credential).GetClient2Client();

            Response response = await client.OperationAsync(null);
        }
    }
}
