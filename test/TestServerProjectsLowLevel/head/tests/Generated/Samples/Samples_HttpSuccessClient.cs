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

namespace head_LowLevel.Samples
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
