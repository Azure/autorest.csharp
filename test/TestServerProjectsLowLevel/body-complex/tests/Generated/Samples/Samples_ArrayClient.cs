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
    public class Samples_ArrayClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetValid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetValid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetValid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetValid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("array")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetValid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetValid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("array")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutValid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new { };

            Response response = client.PutValid(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutValid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new
            {
                array = new[] {
        "<String>"
    },
            };

            Response response = client.PutValid(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutValid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new { };

            Response response = await client.PutValidAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutValid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new
            {
                array = new[] {
        "<String>"
    },
            };

            Response response = await client.PutValidAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetEmpty()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetEmpty();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetEmpty_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetEmpty();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("array")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetEmpty_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetEmptyAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetEmpty_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetEmptyAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("array")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutEmpty()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new { };

            Response response = client.PutEmpty(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutEmpty_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new
            {
                array = new[] {
        "<String>"
    },
            };

            Response response = client.PutEmpty(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutEmpty_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new { };

            Response response = await client.PutEmptyAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutEmpty_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new
            {
                array = new[] {
        "<String>"
    },
            };

            Response response = await client.PutEmptyAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNotProvided()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetNotProvided();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNotProvided_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetNotProvided();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("array")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNotProvided_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetNotProvidedAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNotProvided_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetNotProvidedAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("array")[0].ToString());
        }
    }
}
