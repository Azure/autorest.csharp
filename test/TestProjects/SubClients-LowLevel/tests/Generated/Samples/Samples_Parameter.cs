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
    internal class Samples_Parameter
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetSubParameter()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new RootClient("<cachedParameter>", credential).GetParameterClient();

            Response response = client.GetSubParameter("<subParameter>", new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetSubParameter_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new RootClient("<cachedParameter>", credential).GetParameterClient();

            Response response = client.GetSubParameter("<subParameter>", new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetSubParameter_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new RootClient("<cachedParameter>", credential).GetParameterClient();

            Response response = await client.GetSubParameterAsync("<subParameter>", new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetSubParameter_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new RootClient("<cachedParameter>", credential).GetParameterClient();

            Response response = await client.GetSubParameterAsync("<subParameter>", new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }
    }
}
