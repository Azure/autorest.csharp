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
using httpInfrastructure_LowLevel;

namespace httpInfrastructure_LowLevel.Samples
{
    public partial class Samples_HttpSuccessClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Head200_ShortVersion()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            Response response = client.Head200();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Head200_ShortVersion_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            Response response = await client.Head200Async();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Head200_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            Response response = client.Head200();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Head200_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            Response response = await client.Head200Async();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get200_ShortVersion()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            Response response = client.Get200(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get200_ShortVersion_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            Response response = await client.Get200Async(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get200_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            Response response = client.Get200(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get200_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            Response response = await client.Get200Async(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Options200_ShortVersion()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            Response response = client.Options200(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Options200_ShortVersion_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            Response response = await client.Options200Async(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Options200_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            Response response = client.Options200(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Options200_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            Response response = await client.Options200Async(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put200_ShortVersion()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = null;
            Response response = client.Put200(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put200_ShortVersion_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = null;
            Response response = await client.Put200Async(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put200_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = RequestContent.Create("true");
            Response response = client.Put200(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put200_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = RequestContent.Create("true");
            Response response = await client.Put200Async(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Patch200_ShortVersion()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = null;
            Response response = client.Patch200(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Patch200_ShortVersion_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = null;
            Response response = await client.Patch200Async(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Patch200_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = RequestContent.Create("true");
            Response response = client.Patch200(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Patch200_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = RequestContent.Create("true");
            Response response = await client.Patch200Async(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Post200_ShortVersion()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = null;
            Response response = client.Post200(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Post200_ShortVersion_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = null;
            Response response = await client.Post200Async(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Post200_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = RequestContent.Create("true");
            Response response = client.Post200(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Post200_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = RequestContent.Create("true");
            Response response = await client.Post200Async(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Delete200_ShortVersion()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = null;
            Response response = client.Delete200(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Delete200_ShortVersion_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = null;
            Response response = await client.Delete200Async(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Delete200_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = RequestContent.Create("true");
            Response response = client.Delete200(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Delete200_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = RequestContent.Create("true");
            Response response = await client.Delete200Async(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put201_ShortVersion()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = null;
            Response response = client.Put201(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put201_ShortVersion_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = null;
            Response response = await client.Put201Async(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put201_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = RequestContent.Create("true");
            Response response = client.Put201(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put201_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = RequestContent.Create("true");
            Response response = await client.Put201Async(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Post201_ShortVersion()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = null;
            Response response = client.Post201(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Post201_ShortVersion_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = null;
            Response response = await client.Post201Async(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Post201_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = RequestContent.Create("true");
            Response response = client.Post201(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Post201_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = RequestContent.Create("true");
            Response response = await client.Post201Async(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put202_ShortVersion()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = null;
            Response response = client.Put202(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put202_ShortVersion_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = null;
            Response response = await client.Put202Async(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put202_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = RequestContent.Create("true");
            Response response = client.Put202(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put202_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = RequestContent.Create("true");
            Response response = await client.Put202Async(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Patch202_ShortVersion()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = null;
            Response response = client.Patch202(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Patch202_ShortVersion_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = null;
            Response response = await client.Patch202Async(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Patch202_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = RequestContent.Create("true");
            Response response = client.Patch202(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Patch202_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = RequestContent.Create("true");
            Response response = await client.Patch202Async(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Post202_ShortVersion()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = null;
            Response response = client.Post202(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Post202_ShortVersion_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = null;
            Response response = await client.Post202Async(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Post202_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = RequestContent.Create("true");
            Response response = client.Post202(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Post202_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = RequestContent.Create("true");
            Response response = await client.Post202Async(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Delete202_ShortVersion()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = null;
            Response response = client.Delete202(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Delete202_ShortVersion_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = null;
            Response response = await client.Delete202Async(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Delete202_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = RequestContent.Create("true");
            Response response = client.Delete202(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Delete202_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = RequestContent.Create("true");
            Response response = await client.Delete202Async(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Head204_ShortVersion()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            Response response = client.Head204();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Head204_ShortVersion_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            Response response = await client.Head204Async();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Head204_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            Response response = client.Head204();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Head204_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            Response response = await client.Head204Async();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put204_ShortVersion()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = null;
            Response response = client.Put204(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put204_ShortVersion_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = null;
            Response response = await client.Put204Async(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put204_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = RequestContent.Create("true");
            Response response = client.Put204(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put204_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = RequestContent.Create("true");
            Response response = await client.Put204Async(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Patch204_ShortVersion()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = null;
            Response response = client.Patch204(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Patch204_ShortVersion_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = null;
            Response response = await client.Patch204Async(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Patch204_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = RequestContent.Create("true");
            Response response = client.Patch204(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Patch204_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = RequestContent.Create("true");
            Response response = await client.Patch204Async(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Post204_ShortVersion()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = null;
            Response response = client.Post204(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Post204_ShortVersion_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = null;
            Response response = await client.Post204Async(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Post204_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = RequestContent.Create("true");
            Response response = client.Post204(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Post204_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = RequestContent.Create("true");
            Response response = await client.Post204Async(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Delete204_ShortVersion()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = null;
            Response response = client.Delete204(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Delete204_ShortVersion_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = null;
            Response response = await client.Delete204Async(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Delete204_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = RequestContent.Create("true");
            Response response = client.Delete204(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Delete204_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            RequestContent content = RequestContent.Create("true");
            Response response = await client.Delete204Async(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Head404_ShortVersion()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            Response response = client.Head404();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Head404_ShortVersion_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            Response response = await client.Head404Async();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Head404_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            Response response = client.Head404();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Head404_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("HttpSuccessClient_KEY"));
            HttpSuccessClient client = new HttpSuccessClient(credential);

            Response response = await client.Head404Async();

            Console.WriteLine(response.Status);
        }
    }
}
