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
    public class Samples_HttpRetryClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Head408()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpRetryClient(credential);

            Response response = client.Head408();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Head408_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpRetryClient(credential);

            Response response = client.Head408();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Head408_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpRetryClient(credential);

            Response response = await client.Head408Async();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Head408_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpRetryClient(credential);

            Response response = await client.Head408Async();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put500()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpRetryClient(credential);

            var data = true;

            Response response = client.Put500(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put500_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpRetryClient(credential);

            var data = true;

            Response response = client.Put500(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put500_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpRetryClient(credential);

            var data = true;

            Response response = await client.Put500Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put500_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpRetryClient(credential);

            var data = true;

            Response response = await client.Put500Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Patch500()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpRetryClient(credential);

            var data = true;

            Response response = client.Patch500(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Patch500_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpRetryClient(credential);

            var data = true;

            Response response = client.Patch500(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Patch500_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpRetryClient(credential);

            var data = true;

            Response response = await client.Patch500Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Patch500_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpRetryClient(credential);

            var data = true;

            Response response = await client.Patch500Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get502()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpRetryClient(credential);

            Response response = client.Get502();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get502_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpRetryClient(credential);

            Response response = client.Get502();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get502_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpRetryClient(credential);

            Response response = await client.Get502Async();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get502_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpRetryClient(credential);

            Response response = await client.Get502Async();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Options502()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpRetryClient(credential);

            Response response = client.Options502();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Options502_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpRetryClient(credential);

            Response response = client.Options502();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Options502_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpRetryClient(credential);

            Response response = await client.Options502Async();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Options502_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpRetryClient(credential);

            Response response = await client.Options502Async();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Post503()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpRetryClient(credential);

            var data = true;

            Response response = client.Post503(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Post503_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpRetryClient(credential);

            var data = true;

            Response response = client.Post503(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Post503_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpRetryClient(credential);

            var data = true;

            Response response = await client.Post503Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Post503_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpRetryClient(credential);

            var data = true;

            Response response = await client.Post503Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Delete503()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpRetryClient(credential);

            var data = true;

            Response response = client.Delete503(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Delete503_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpRetryClient(credential);

            var data = true;

            Response response = client.Delete503(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Delete503_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpRetryClient(credential);

            var data = true;

            Response response = await client.Delete503Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Delete503_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpRetryClient(credential);

            var data = true;

            Response response = await client.Delete503Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put504()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpRetryClient(credential);

            var data = true;

            Response response = client.Put504(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put504_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpRetryClient(credential);

            var data = true;

            Response response = client.Put504(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put504_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpRetryClient(credential);

            var data = true;

            Response response = await client.Put504Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put504_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpRetryClient(credential);

            var data = true;

            Response response = await client.Put504Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Patch504()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpRetryClient(credential);

            var data = true;

            Response response = client.Patch504(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Patch504_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpRetryClient(credential);

            var data = true;

            Response response = client.Patch504(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Patch504_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpRetryClient(credential);

            var data = true;

            Response response = await client.Patch504Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Patch504_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpRetryClient(credential);

            var data = true;

            Response response = await client.Patch504Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }
    }
}
