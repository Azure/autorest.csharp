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

namespace BodyAndPath_LowLevel.Samples
{
    public class Samples_BodyAndPathClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Create()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new BodyAndPathClient(credential);

            var data = new { };

            Response response = client.Create("<itemName>", RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Create_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new BodyAndPathClient(credential);

            var data = new { };

            Response response = client.Create("<itemName>", RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Create_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new BodyAndPathClient(credential);

            var data = new { };

            Response response = await client.CreateAsync("<itemName>", RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Create_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new BodyAndPathClient(credential);

            var data = new { };

            Response response = await client.CreateAsync("<itemName>", RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CreateStream()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new BodyAndPathClient(credential);

            var data = File.OpenRead("<filePath>");

            Response response = client.CreateStream("<itemNameStream>", RequestContent.Create(data), ContentType.ApplicationOctetStream);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CreateStream_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new BodyAndPathClient(credential);

            var data = File.OpenRead("<filePath>");

            Response response = client.CreateStream("<itemNameStream>", RequestContent.Create(data), ContentType.ApplicationOctetStream, new string[] { "<excluded>" });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CreateStream_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new BodyAndPathClient(credential);

            var data = File.OpenRead("<filePath>");

            Response response = await client.CreateStreamAsync("<itemNameStream>", RequestContent.Create(data), ContentType.ApplicationOctetStream);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CreateStream_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new BodyAndPathClient(credential);

            var data = File.OpenRead("<filePath>");

            Response response = await client.CreateStreamAsync("<itemNameStream>", RequestContent.Create(data), ContentType.ApplicationOctetStream, new string[] { "<excluded>" });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CreateEnum()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new BodyAndPathClient(credential);

            var data = new { };

            Response response = client.CreateEnum("<enumName1>", "<enumName2>", RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CreateEnum_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new BodyAndPathClient(credential);

            var data = new { };

            Response response = client.CreateEnum("<enumName1>", "<enumName2>", RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CreateEnum_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new BodyAndPathClient(credential);

            var data = new { };

            Response response = await client.CreateEnumAsync("<enumName1>", "<enumName2>", RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CreateEnum_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new BodyAndPathClient(credential);

            var data = new { };

            Response response = await client.CreateEnumAsync("<enumName1>", "<enumName2>", RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetBodyAndPaths()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new BodyAndPathClient(credential);

            Response response = client.GetBodyAndPaths();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetBodyAndPaths_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new BodyAndPathClient(credential);

            Response response = client.GetBodyAndPaths();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetBodyAndPaths_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new BodyAndPathClient(credential);

            Response response = await client.GetBodyAndPathsAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetBodyAndPaths_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new BodyAndPathClient(credential);

            Response response = await client.GetBodyAndPathsAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetItems()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new BodyAndPathClient(credential);

            Response response = client.GetItems();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetItems_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new BodyAndPathClient(credential);

            Response response = client.GetItems();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetItems_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new BodyAndPathClient(credential);

            Response response = await client.GetItemsAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetItems_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new BodyAndPathClient(credential);

            Response response = await client.GetItemsAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Update()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new BodyAndPathClient(credential);

            var data = new { };

            Response response = client.Update("<item3>", "<item2>", "<item4>", RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Update_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new BodyAndPathClient(credential);

            var data = new
            {
                invalid_int_name = 1234,
            };

            Response response = client.Update("<item3>", "<item2>", "<item4>", RequestContent.Create(data), "<item5>", "value");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Update_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new BodyAndPathClient(credential);

            var data = new { };

            Response response = await client.UpdateAsync("<item3>", "<item2>", "<item4>", RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Update_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new BodyAndPathClient(credential);

            var data = new
            {
                invalid_int_name = 1234,
            };

            Response response = await client.UpdateAsync("<item3>", "<item2>", "<item4>", RequestContent.Create(data), "<item5>", "value");
            Console.WriteLine(response.Status);
        }
    }
}
