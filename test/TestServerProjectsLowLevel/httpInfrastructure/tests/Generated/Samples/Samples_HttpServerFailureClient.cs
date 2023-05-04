// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.IO;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;

namespace httpInfrastructure_LowLevel.Samples
{
    public class Samples_HttpServerFailureClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Head501()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpServerFailureClient(credential);

            Response response = client.Head501();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Head501_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpServerFailureClient(credential);

            Response response = client.Head501(new RequestContext());
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async void Example_Head501_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpServerFailureClient(credential);

            Response response = await client.Head501Async();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async void Example_Head501_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpServerFailureClient(credential);

            Response response = await client.Head501Async(new RequestContext());
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get501()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpServerFailureClient(credential);

            Response response = client.Get501();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get501_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpServerFailureClient(credential);

            Response response = client.Get501(new RequestContext());
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async void Example_Get501_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpServerFailureClient(credential);

            Response response = await client.Get501Async();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async void Example_Get501_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpServerFailureClient(credential);

            Response response = await client.Get501Async(new RequestContext());
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Post505()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpServerFailureClient(credential);

            var data = true;

            Response response = client.Post505(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Post505_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpServerFailureClient(credential);

            var data = true;

            Response response = client.Post505(RequestContent.Create(data), new RequestContext());
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async void Example_Post505_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpServerFailureClient(credential);

            var data = true;

            Response response = await client.Post505Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async void Example_Post505_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpServerFailureClient(credential);

            var data = true;

            Response response = await client.Post505Async(RequestContent.Create(data), new RequestContext());
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Delete505()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpServerFailureClient(credential);

            var data = true;

            Response response = client.Delete505(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Delete505_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpServerFailureClient(credential);

            var data = true;

            Response response = client.Delete505(RequestContent.Create(data), new RequestContext());
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async void Example_Delete505_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpServerFailureClient(credential);

            var data = true;

            Response response = await client.Delete505Async(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async void Example_Delete505_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpServerFailureClient(credential);

            var data = true;

            Response response = await client.Delete505Async(RequestContent.Create(data), new RequestContext());
            Console.WriteLine(response.Status);
        }
    }
}
