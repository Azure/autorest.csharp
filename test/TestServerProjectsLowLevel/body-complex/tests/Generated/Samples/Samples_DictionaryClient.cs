// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;
using body_complex_LowLevel;

namespace body_complex_LowLevel.Samples
{
    public class Samples_DictionaryClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetValid()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DictionaryClient client = new DictionaryClient(credential);

            Response response = client.GetValid(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetValid_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DictionaryClient client = new DictionaryClient(credential);

            Response response = await client.GetValidAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetValid_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DictionaryClient client = new DictionaryClient(credential);

            Response response = client.GetValid(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("defaultProgram").GetProperty("<key>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetValid_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DictionaryClient client = new DictionaryClient(credential);

            Response response = await client.GetValidAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("defaultProgram").GetProperty("<key>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutValid()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DictionaryClient client = new DictionaryClient(credential);

            RequestContent content = RequestContent.Create(new object());
            Response response = client.PutValid(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutValid_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DictionaryClient client = new DictionaryClient(credential);

            RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutValidAsync(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutValid_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DictionaryClient client = new DictionaryClient(credential);

            RequestContent content = RequestContent.Create(new
            {
                defaultProgram = new
                {
                    key = "<defaultProgram>",
                },
            });
            Response response = client.PutValid(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutValid_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DictionaryClient client = new DictionaryClient(credential);

            RequestContent content = RequestContent.Create(new
            {
                defaultProgram = new
                {
                    key = "<defaultProgram>",
                },
            });
            Response response = await client.PutValidAsync(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetEmpty()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DictionaryClient client = new DictionaryClient(credential);

            Response response = client.GetEmpty(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetEmpty_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DictionaryClient client = new DictionaryClient(credential);

            Response response = await client.GetEmptyAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetEmpty_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DictionaryClient client = new DictionaryClient(credential);

            Response response = client.GetEmpty(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("defaultProgram").GetProperty("<key>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetEmpty_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DictionaryClient client = new DictionaryClient(credential);

            Response response = await client.GetEmptyAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("defaultProgram").GetProperty("<key>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutEmpty()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DictionaryClient client = new DictionaryClient(credential);

            RequestContent content = RequestContent.Create(new object());
            Response response = client.PutEmpty(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutEmpty_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DictionaryClient client = new DictionaryClient(credential);

            RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutEmptyAsync(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutEmpty_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DictionaryClient client = new DictionaryClient(credential);

            RequestContent content = RequestContent.Create(new
            {
                defaultProgram = new
                {
                    key = "<defaultProgram>",
                },
            });
            Response response = client.PutEmpty(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutEmpty_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DictionaryClient client = new DictionaryClient(credential);

            RequestContent content = RequestContent.Create(new
            {
                defaultProgram = new
                {
                    key = "<defaultProgram>",
                },
            });
            Response response = await client.PutEmptyAsync(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNull()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DictionaryClient client = new DictionaryClient(credential);

            Response response = client.GetNull(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNull_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DictionaryClient client = new DictionaryClient(credential);

            Response response = await client.GetNullAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNull_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DictionaryClient client = new DictionaryClient(credential);

            Response response = client.GetNull(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("defaultProgram").GetProperty("<key>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNull_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DictionaryClient client = new DictionaryClient(credential);

            Response response = await client.GetNullAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("defaultProgram").GetProperty("<key>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNotProvided()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DictionaryClient client = new DictionaryClient(credential);

            Response response = client.GetNotProvided(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNotProvided_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DictionaryClient client = new DictionaryClient(credential);

            Response response = await client.GetNotProvidedAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNotProvided_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DictionaryClient client = new DictionaryClient(credential);

            Response response = client.GetNotProvided(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("defaultProgram").GetProperty("<key>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNotProvided_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DictionaryClient client = new DictionaryClient(credential);

            Response response = await client.GetNotProvidedAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("defaultProgram").GetProperty("<key>").ToString());
        }
    }
}
