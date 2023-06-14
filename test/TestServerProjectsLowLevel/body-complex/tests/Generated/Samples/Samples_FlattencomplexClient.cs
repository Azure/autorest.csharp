// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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

namespace body_complex_LowLevel.Samples
{
    public class Samples_FlattencomplexClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetValid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new FlattencomplexClient(credential);

            Response response = client.GetValid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetValid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new FlattencomplexClient(credential);

            Response response = client.GetValid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("propB1").ToString());
            Console.WriteLine(result.GetProperty("helper").GetProperty("propBH1").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetValid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new FlattencomplexClient(credential);

            Response response = await client.GetValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetValid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new FlattencomplexClient(credential);

            Response response = await client.GetValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("kind").ToString());
            Console.WriteLine(result.GetProperty("propB1").ToString());
            Console.WriteLine(result.GetProperty("helper").GetProperty("propBH1").ToString());
        }
    }
}
