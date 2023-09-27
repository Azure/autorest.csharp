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
using SubClients_LowLevel;

namespace SubClients_LowLevel.Samples
{
    public class Samples_RootClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetCachedParameter_ShortVersion()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            RootClient client = new RootClient("<CachedParameter>", credential);

            Response response = client.GetCachedParameter(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetCachedParameter_ShortVersion_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            RootClient client = new RootClient("<CachedParameter>", credential);

            Response response = await client.GetCachedParameterAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetCachedParameter_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            RootClient client = new RootClient("<CachedParameter>", credential);

            Response response = client.GetCachedParameter(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetCachedParameter_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            RootClient client = new RootClient("<CachedParameter>", credential);

            Response response = await client.GetCachedParameterAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }
    }
}
