// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

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

namespace Authentication.Http.Custom.Samples
{
    public class Samples_CustomClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Valid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new CustomClient(credential);

            Response response = client.Valid();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Valid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new CustomClient(credential);

            Response response = client.Valid();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Valid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new CustomClient(credential);

            Response response = await client.ValidAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Valid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new CustomClient(credential);

            Response response = await client.ValidAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Invalid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new CustomClient(credential);

            Response response = client.Invalid();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Invalid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new CustomClient(credential);

            Response response = client.Invalid();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Invalid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new CustomClient(credential);

            Response response = await client.InvalidAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Invalid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new CustomClient(credential);

            Response response = await client.InvalidAsync();
            Console.WriteLine(response.Status);
        }
    }
}
