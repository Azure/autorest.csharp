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

namespace Authentication.OAuth2.Samples
{
    public class Samples_OAuth2Client
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Valid()
        {
            var credential = new DefaultAzureCredential();
            var client = new OAuth2Client(credential);

            Response response = client.Valid();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Valid_AllParameters()
        {
            var credential = new DefaultAzureCredential();
            var client = new OAuth2Client(credential);

            Response response = client.Valid();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Valid_Async()
        {
            var credential = new DefaultAzureCredential();
            var client = new OAuth2Client(credential);

            Response response = await client.ValidAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Valid_AllParameters_Async()
        {
            var credential = new DefaultAzureCredential();
            var client = new OAuth2Client(credential);

            Response response = await client.ValidAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Invalid()
        {
            var credential = new DefaultAzureCredential();
            var client = new OAuth2Client(credential);

            Response response = client.Invalid();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Invalid_AllParameters()
        {
            var credential = new DefaultAzureCredential();
            var client = new OAuth2Client(credential);

            Response response = client.Invalid();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Invalid_Async()
        {
            var credential = new DefaultAzureCredential();
            var client = new OAuth2Client(credential);

            Response response = await client.InvalidAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Invalid_AllParameters_Async()
        {
            var credential = new DefaultAzureCredential();
            var client = new OAuth2Client(credential);

            Response response = await client.InvalidAsync();
            Console.WriteLine(response.Status);
        }
    }
}
