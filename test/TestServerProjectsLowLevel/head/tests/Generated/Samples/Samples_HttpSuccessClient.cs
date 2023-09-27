// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using NUnit.Framework;
using head_LowLevel;

namespace head_LowLevel.Samples
{
    public partial class Samples_HttpSuccessClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Head200()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpSuccessClient client = new HttpSuccessClient(credential);

            Response response = client.Head200();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Head200_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpSuccessClient client = new HttpSuccessClient(credential);

            Response response = await client.Head200Async();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Head200_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpSuccessClient client = new HttpSuccessClient(credential);

            Response response = client.Head200();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Head200_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpSuccessClient client = new HttpSuccessClient(credential);

            Response response = await client.Head200Async();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Head204()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpSuccessClient client = new HttpSuccessClient(credential);

            Response response = client.Head204();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Head204_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpSuccessClient client = new HttpSuccessClient(credential);

            Response response = await client.Head204Async();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Head204_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpSuccessClient client = new HttpSuccessClient(credential);

            Response response = client.Head204();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Head204_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpSuccessClient client = new HttpSuccessClient(credential);

            Response response = await client.Head204Async();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Head404()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpSuccessClient client = new HttpSuccessClient(credential);

            Response response = client.Head404();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Head404_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpSuccessClient client = new HttpSuccessClient(credential);

            Response response = await client.Head404Async();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Head404_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpSuccessClient client = new HttpSuccessClient(credential);

            Response response = client.Head404();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Head404_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpSuccessClient client = new HttpSuccessClient(credential);

            Response response = await client.Head404Async();

            Console.WriteLine(response.Status);
        }
    }
}
