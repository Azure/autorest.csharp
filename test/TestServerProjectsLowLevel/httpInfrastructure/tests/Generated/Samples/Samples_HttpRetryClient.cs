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
    public partial class Samples_HttpRetryClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Head408()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpRetryClient client = new HttpRetryClient(credential);

            Response response = client.Head408();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Head408_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpRetryClient client = new HttpRetryClient(credential);

            Response response = await client.Head408Async();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Head408_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpRetryClient client = new HttpRetryClient(credential);

            Response response = client.Head408();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Head408_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpRetryClient client = new HttpRetryClient(credential);

            Response response = await client.Head408Async();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put500()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpRetryClient client = new HttpRetryClient(credential);

            RequestContent content = null;
            Response response = client.Put500(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put500_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpRetryClient client = new HttpRetryClient(credential);

            RequestContent content = null;
            Response response = await client.Put500Async(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put500_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpRetryClient client = new HttpRetryClient(credential);

            RequestContent content = RequestContent.Create("true");
            Response response = client.Put500(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put500_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpRetryClient client = new HttpRetryClient(credential);

            RequestContent content = RequestContent.Create("true");
            Response response = await client.Put500Async(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Patch500()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpRetryClient client = new HttpRetryClient(credential);

            RequestContent content = null;
            Response response = client.Patch500(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Patch500_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpRetryClient client = new HttpRetryClient(credential);

            RequestContent content = null;
            Response response = await client.Patch500Async(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Patch500_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpRetryClient client = new HttpRetryClient(credential);

            RequestContent content = RequestContent.Create("true");
            Response response = client.Patch500(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Patch500_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpRetryClient client = new HttpRetryClient(credential);

            RequestContent content = RequestContent.Create("true");
            Response response = await client.Patch500Async(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get502()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpRetryClient client = new HttpRetryClient(credential);

            Response response = client.Get502();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get502_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpRetryClient client = new HttpRetryClient(credential);

            Response response = await client.Get502Async();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get502_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpRetryClient client = new HttpRetryClient(credential);

            Response response = client.Get502();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get502_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpRetryClient client = new HttpRetryClient(credential);

            Response response = await client.Get502Async();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Options502()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpRetryClient client = new HttpRetryClient(credential);

            Response response = client.Options502(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Options502_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpRetryClient client = new HttpRetryClient(credential);

            Response response = await client.Options502Async(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Options502_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpRetryClient client = new HttpRetryClient(credential);

            Response response = client.Options502(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Options502_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpRetryClient client = new HttpRetryClient(credential);

            Response response = await client.Options502Async(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Post503()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpRetryClient client = new HttpRetryClient(credential);

            RequestContent content = null;
            Response response = client.Post503(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Post503_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpRetryClient client = new HttpRetryClient(credential);

            RequestContent content = null;
            Response response = await client.Post503Async(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Post503_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpRetryClient client = new HttpRetryClient(credential);

            RequestContent content = RequestContent.Create("true");
            Response response = client.Post503(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Post503_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpRetryClient client = new HttpRetryClient(credential);

            RequestContent content = RequestContent.Create("true");
            Response response = await client.Post503Async(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Delete503()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpRetryClient client = new HttpRetryClient(credential);

            RequestContent content = null;
            Response response = client.Delete503(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Delete503_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpRetryClient client = new HttpRetryClient(credential);

            RequestContent content = null;
            Response response = await client.Delete503Async(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Delete503_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpRetryClient client = new HttpRetryClient(credential);

            RequestContent content = RequestContent.Create("true");
            Response response = client.Delete503(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Delete503_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpRetryClient client = new HttpRetryClient(credential);

            RequestContent content = RequestContent.Create("true");
            Response response = await client.Delete503Async(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put504()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpRetryClient client = new HttpRetryClient(credential);

            RequestContent content = null;
            Response response = client.Put504(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put504_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpRetryClient client = new HttpRetryClient(credential);

            RequestContent content = null;
            Response response = await client.Put504Async(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put504_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpRetryClient client = new HttpRetryClient(credential);

            RequestContent content = RequestContent.Create("true");
            Response response = client.Put504(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put504_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpRetryClient client = new HttpRetryClient(credential);

            RequestContent content = RequestContent.Create("true");
            Response response = await client.Put504Async(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Patch504()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpRetryClient client = new HttpRetryClient(credential);

            RequestContent content = null;
            Response response = client.Patch504(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Patch504_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpRetryClient client = new HttpRetryClient(credential);

            RequestContent content = null;
            Response response = await client.Patch504Async(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Patch504_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpRetryClient client = new HttpRetryClient(credential);

            RequestContent content = RequestContent.Create("true");
            Response response = client.Patch504(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Patch504_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpRetryClient client = new HttpRetryClient(credential);

            RequestContent content = RequestContent.Create("true");
            Response response = await client.Patch504Async(content);

            Console.WriteLine(response.Status);
        }
    }
}
