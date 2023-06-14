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

namespace Authentication.Union.Samples
{
    public class Samples_UnionClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ValidKey()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new UnionClient(credential);

            Response response = client.ValidKey();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ValidKey_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new UnionClient(credential);

            Response response = client.ValidKey();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ValidKey_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new UnionClient(credential);

            Response response = await client.ValidKeyAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ValidKey_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new UnionClient(credential);

            Response response = await client.ValidKeyAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ValidToken()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new UnionClient(credential);

            Response response = client.ValidToken();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ValidToken_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new UnionClient(credential);

            Response response = client.ValidToken();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ValidToken_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new UnionClient(credential);

            Response response = await client.ValidTokenAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ValidToken_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new UnionClient(credential);

            Response response = await client.ValidTokenAsync();
            Console.WriteLine(response.Status);
        }
    }
}
