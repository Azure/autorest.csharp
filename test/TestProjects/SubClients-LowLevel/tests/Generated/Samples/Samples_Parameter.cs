// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using NUnit.Framework;

namespace SubClients_LowLevel.Samples
{
    public partial class Samples_Parameter
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetSubParameter_ShortVersion()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Parameter client = new RootClient(null, credential).GetParameterClient();

            Response response = client.GetSubParameter("<subParameter>", null);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetSubParameter_ShortVersion_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Parameter client = new RootClient(null, credential).GetParameterClient();

            Response response = await client.GetSubParameterAsync("<subParameter>", null);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetSubParameter_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Parameter client = new RootClient(null, credential).GetParameterClient();

            Response response = client.GetSubParameter("<subParameter>", null);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetSubParameter_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Parameter client = new RootClient(null, credential).GetParameterClient();

            Response response = await client.GetSubParameterAsync("<subParameter>", null);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result.ToString());
        }
    }
}
