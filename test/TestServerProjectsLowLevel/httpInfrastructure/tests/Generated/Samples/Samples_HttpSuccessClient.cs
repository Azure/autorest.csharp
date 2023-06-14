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

namespace httpInfrastructure_LowLevel.Samples
{
    public class Samples_HttpSuccessClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Head200()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            Response response = client.Head200();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Head200_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            Response response = client.Head200();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Head200_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            Response response = await client.Head200Async();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Head200_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            Response response = await client.Head200Async();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get200()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            Response response = client.Get200();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get200_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            Response response = client.Get200();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get200_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            Response response = await client.Get200Async();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get200_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            Response response = await client.Get200Async();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Options200()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            Response response = client.Options200();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Options200_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            Response response = client.Options200();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Options200_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            Response response = await client.Options200Async();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Options200_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            Response response = await client.Options200Async();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put200()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = client.Put200(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put200_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = client.Put200(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put200_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = await client.Put200Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put200_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = await client.Put200Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Patch200()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = client.Patch200(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Patch200_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = client.Patch200(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Patch200_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = await client.Patch200Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Patch200_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = await client.Patch200Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Post200()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = client.Post200(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Post200_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = client.Post200(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Post200_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = await client.Post200Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Post200_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = await client.Post200Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Delete200()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = client.Delete200(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Delete200_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = client.Delete200(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Delete200_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = await client.Delete200Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Delete200_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = await client.Delete200Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put201()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = client.Put201(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put201_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = client.Put201(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put201_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = await client.Put201Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put201_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = await client.Put201Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Post201()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = client.Post201(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Post201_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = client.Post201(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Post201_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = await client.Post201Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Post201_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = await client.Post201Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put202()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = client.Put202(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put202_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = client.Put202(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put202_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = await client.Put202Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put202_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = await client.Put202Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Patch202()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = client.Patch202(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Patch202_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = client.Patch202(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Patch202_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = await client.Patch202Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Patch202_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = await client.Patch202Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Post202()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = client.Post202(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Post202_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = client.Post202(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Post202_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = await client.Post202Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Post202_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = await client.Post202Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Delete202()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = client.Delete202(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Delete202_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = client.Delete202(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Delete202_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = await client.Delete202Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Delete202_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = await client.Delete202Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Head204()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            Response response = client.Head204();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Head204_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            Response response = client.Head204();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Head204_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            Response response = await client.Head204Async();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Head204_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            Response response = await client.Head204Async();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put204()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = client.Put204(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put204_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = client.Put204(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put204_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = await client.Put204Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put204_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = await client.Put204Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Patch204()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = client.Patch204(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Patch204_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = client.Patch204(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Patch204_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = await client.Patch204Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Patch204_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = await client.Patch204Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Post204()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = client.Post204(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Post204_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = client.Post204(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Post204_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = await client.Post204Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Post204_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = await client.Post204Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Delete204()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = client.Delete204(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Delete204_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = client.Delete204(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Delete204_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = await client.Delete204Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Delete204_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            var data = true;

            Response response = await client.Delete204Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Head404()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            Response response = client.Head404();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Head404_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            Response response = client.Head404();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Head404_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            Response response = await client.Head404Async();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Head404_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpSuccessClient(credential);

            Response response = await client.Head404Async();
            Console.WriteLine(response.Status);
        }
    }
}
