// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using NUnit.Framework;
using SingleTopLevelClientWithoutOperations_LowLevel;

namespace SingleTopLevelClientWithoutOperations_LowLevel.Samples
{
    public class Samples_Client6
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Operation()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Client6 client = new TopLevelClientWithoutOperationClient(credential).GetClient6Client();

            Response response = client.Operation(null);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Operation_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Client6 client = new TopLevelClientWithoutOperationClient(credential).GetClient6Client();

            Response response = await client.OperationAsync(null);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Operation_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Client6 client = new TopLevelClientWithoutOperationClient(credential).GetClient6Client();

            Response response = client.Operation(null);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Operation_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Client6 client = new TopLevelClientWithoutOperationClient(credential).GetClient6Client();

            Response response = await client.OperationAsync(null);
        }
    }
}
