// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Authentication.Http.Custom;
using Azure;
using Azure.Identity;
using NUnit.Framework;

namespace Authentication.Http.Custom.Samples
{
    public partial class Samples_CustomClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Valid_ShortVersion()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            CustomClient client = new CustomClient(credential);

            Response response = client.Valid();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Valid_ShortVersion_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            CustomClient client = new CustomClient(credential);

            Response response = await client.ValidAsync();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Valid_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            CustomClient client = new CustomClient(credential);

            Response response = client.Valid();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Valid_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            CustomClient client = new CustomClient(credential);

            Response response = await client.ValidAsync();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Invalid_ShortVersion()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            CustomClient client = new CustomClient(credential);

            Response response = client.Invalid();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Invalid_ShortVersion_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            CustomClient client = new CustomClient(credential);

            Response response = await client.InvalidAsync();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Invalid_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            CustomClient client = new CustomClient(credential);

            Response response = client.Invalid();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Invalid_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            CustomClient client = new CustomClient(credential);

            Response response = await client.InvalidAsync();

            Console.WriteLine(response.Status);
        }
    }
}
