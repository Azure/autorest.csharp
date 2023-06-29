// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;

namespace SubClients_LowLevel.Samples
{
    public class Samples_RootClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetCachedParameter()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new RootClient("<cachedParameter>", credential);

            Response response = client.GetCachedParameter();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetCachedParameter_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new RootClient("<cachedParameter>", credential);

            Response response = client.GetCachedParameter();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetCachedParameter_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new RootClient("<cachedParameter>", credential);

            Response response = await client.GetCachedParameterAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetCachedParameter_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new RootClient("<cachedParameter>", credential);

            Response response = await client.GetCachedParameterAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }
    }
}
