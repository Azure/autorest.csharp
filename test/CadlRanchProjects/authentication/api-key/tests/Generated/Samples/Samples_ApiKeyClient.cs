// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Authentication.ApiKey;
using Azure;
using Azure.Identity;
using NUnit.Framework;

namespace Authentication.ApiKey.Samples
{
    public class Samples_ApiKeyClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Valid()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ApiKeyClient client = new ApiKeyClient(credential);

            Response response = client.Valid();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Valid_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ApiKeyClient client = new ApiKeyClient(credential);

            Response response = await client.ValidAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Valid_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ApiKeyClient client = new ApiKeyClient(credential);

            Response response = client.Valid();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Valid_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ApiKeyClient client = new ApiKeyClient(credential);

            Response response = await client.ValidAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Invalid()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ApiKeyClient client = new ApiKeyClient(credential);

            Response response = client.Invalid();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Invalid_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ApiKeyClient client = new ApiKeyClient(credential);

            Response response = await client.InvalidAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Invalid_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ApiKeyClient client = new ApiKeyClient(credential);

            Response response = client.Invalid();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Invalid_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ApiKeyClient client = new ApiKeyClient(credential);

            Response response = await client.InvalidAsync();
            Console.WriteLine(response.Status);
        }
    }
}
