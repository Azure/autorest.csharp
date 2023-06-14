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
    public class Samples_InheritanceClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetValid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new InheritanceClient(credential);

            Response response = client.GetValid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetValid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new InheritanceClient(credential);

            Response response = client.GetValid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("breed").ToString());
            Console.WriteLine(result.GetProperty("color").ToString());
            Console.WriteLine(result.GetProperty("hates")[0].GetProperty("food").ToString());
            Console.WriteLine(result.GetProperty("hates")[0].GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("hates")[0].GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetValid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new InheritanceClient(credential);

            Response response = await client.GetValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetValid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new InheritanceClient(credential);

            Response response = await client.GetValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("breed").ToString());
            Console.WriteLine(result.GetProperty("color").ToString());
            Console.WriteLine(result.GetProperty("hates")[0].GetProperty("food").ToString());
            Console.WriteLine(result.GetProperty("hates")[0].GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("hates")[0].GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutValid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new InheritanceClient(credential);

            var data = new { };

            Response response = client.PutValid(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutValid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new InheritanceClient(credential);

            var data = new
            {
                breed = "<breed>",
                color = "<color>",
                hates = new[] {
        new {
            food = "<food>",
            id = 1234,
            name = "<name>",
        }
    },
                id = 1234,
                name = "<name>",
            };

            Response response = client.PutValid(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutValid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new InheritanceClient(credential);

            var data = new { };

            Response response = await client.PutValidAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutValid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new InheritanceClient(credential);

            var data = new
            {
                breed = "<breed>",
                color = "<color>",
                hates = new[] {
        new {
            food = "<food>",
            id = 1234,
            name = "<name>",
        }
    },
                id = 1234,
                name = "<name>",
            };

            Response response = await client.PutValidAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }
    }
}
