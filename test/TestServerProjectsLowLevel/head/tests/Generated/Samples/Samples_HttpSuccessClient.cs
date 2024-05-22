// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using NUnit.Framework;

namespace head_LowLevel.Samples
{
    public partial class Samples_HttpSuccessClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_httpSuccess_Head200_ShortVersion()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpSuccessClient client = new HttpSuccessClient(credential);

            Response response = client.Head200();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_httpSuccess_Head200_ShortVersion_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpSuccessClient client = new HttpSuccessClient(credential);

            Response response = await client.Head200Async();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_httpSuccess_Head200_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpSuccessClient client = new HttpSuccessClient(credential);

            Response response = client.Head200();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_httpSuccess_Head200_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpSuccessClient client = new HttpSuccessClient(credential);

            Response response = await client.Head200Async();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_httpSuccess_Head204_ShortVersion()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpSuccessClient client = new HttpSuccessClient(credential);

            Response response = client.Head204();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_httpSuccess_Head204_ShortVersion_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpSuccessClient client = new HttpSuccessClient(credential);

            Response response = await client.Head204Async();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_httpSuccess_Head204_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpSuccessClient client = new HttpSuccessClient(credential);

            Response response = client.Head204();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_httpSuccess_Head204_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpSuccessClient client = new HttpSuccessClient(credential);

            Response response = await client.Head204Async();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_httpSuccess_Head404_ShortVersion()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpSuccessClient client = new HttpSuccessClient(credential);

            Response response = client.Head404();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_httpSuccess_Head404_ShortVersion_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpSuccessClient client = new HttpSuccessClient(credential);

            Response response = await client.Head404Async();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_httpSuccess_Head404_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpSuccessClient client = new HttpSuccessClient(credential);

            Response response = client.Head404();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_httpSuccess_Head404_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HttpSuccessClient client = new HttpSuccessClient(credential);

            Response response = await client.Head404Async();

            Console.WriteLine(response.Status);
        }
    }
}
