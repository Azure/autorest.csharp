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

namespace body_string_LowLevel.Samples
{
    public class Samples_EnumClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNotExpandable()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new EnumClient(credential);

            Response response = client.GetNotExpandable();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNotExpandable_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new EnumClient(credential);

            Response response = client.GetNotExpandable();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNotExpandable_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new EnumClient(credential);

            Response response = await client.GetNotExpandableAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNotExpandable_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new EnumClient(credential);

            Response response = await client.GetNotExpandableAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutNotExpandable()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new EnumClient(credential);

            var data = "red color";

            Response response = client.PutNotExpandable(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutNotExpandable_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new EnumClient(credential);

            var data = "red color";

            Response response = client.PutNotExpandable(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutNotExpandable_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new EnumClient(credential);

            var data = "red color";

            Response response = await client.PutNotExpandableAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutNotExpandable_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new EnumClient(credential);

            var data = "red color";

            Response response = await client.PutNotExpandableAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetReferenced()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new EnumClient(credential);

            Response response = client.GetReferenced();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetReferenced_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new EnumClient(credential);

            Response response = client.GetReferenced();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetReferenced_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new EnumClient(credential);

            Response response = await client.GetReferencedAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetReferenced_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new EnumClient(credential);

            Response response = await client.GetReferencedAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutReferenced()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new EnumClient(credential);

            var data = "red color";

            Response response = client.PutReferenced(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutReferenced_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new EnumClient(credential);

            var data = "red color";

            Response response = client.PutReferenced(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutReferenced_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new EnumClient(credential);

            var data = "red color";

            Response response = await client.PutReferencedAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutReferenced_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new EnumClient(credential);

            var data = "red color";

            Response response = await client.PutReferencedAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetReferencedConstant()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new EnumClient(credential);

            Response response = client.GetReferencedConstant();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("ColorConstant").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetReferencedConstant_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new EnumClient(credential);

            Response response = client.GetReferencedConstant();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("ColorConstant").ToString());
            Console.WriteLine(result.GetProperty("field1").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetReferencedConstant_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new EnumClient(credential);

            Response response = await client.GetReferencedConstantAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("ColorConstant").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetReferencedConstant_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new EnumClient(credential);

            Response response = await client.GetReferencedConstantAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("ColorConstant").ToString());
            Console.WriteLine(result.GetProperty("field1").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutReferencedConstant()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new EnumClient(credential);

            var data = new
            {
                ColorConstant = "green-color",
            };

            Response response = client.PutReferencedConstant(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutReferencedConstant_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new EnumClient(credential);

            var data = new
            {
                ColorConstant = "green-color",
                field1 = "<field1>",
            };

            Response response = client.PutReferencedConstant(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutReferencedConstant_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new EnumClient(credential);

            var data = new
            {
                ColorConstant = "green-color",
            };

            Response response = await client.PutReferencedConstantAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutReferencedConstant_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new EnumClient(credential);

            var data = new
            {
                ColorConstant = "green-color",
                field1 = "<field1>",
            };

            Response response = await client.PutReferencedConstantAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }
    }
}
