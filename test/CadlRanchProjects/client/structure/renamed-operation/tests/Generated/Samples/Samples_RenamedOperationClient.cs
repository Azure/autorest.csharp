// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using NUnit.Framework;

namespace Client.Structure.Service.rename.operation.Samples
{
    public partial class Samples_RenamedOperationClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_RenamedOperation_RenamedOne_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            RenamedOperationClient client = new RenamedOperationClient(endpoint, "default");

            Response response = client.RenamedOne();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_RenamedOperation_RenamedOne_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            RenamedOperationClient client = new RenamedOperationClient(endpoint, "default");

            Response response = await client.RenamedOneAsync();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_RenamedOperation_RenamedOne_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            RenamedOperationClient client = new RenamedOperationClient(endpoint, "default");

            Response response = client.RenamedOne();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_RenamedOperation_RenamedOne_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            RenamedOperationClient client = new RenamedOperationClient(endpoint, "default");

            Response response = await client.RenamedOneAsync();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_RenamedOperation_RenamedThree_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            RenamedOperationClient client = new RenamedOperationClient(endpoint, "default");

            Response response = client.RenamedThree();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_RenamedOperation_RenamedThree_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            RenamedOperationClient client = new RenamedOperationClient(endpoint, "default");

            Response response = await client.RenamedThreeAsync();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_RenamedOperation_RenamedThree_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            RenamedOperationClient client = new RenamedOperationClient(endpoint, "default");

            Response response = client.RenamedThree();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_RenamedOperation_RenamedThree_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            RenamedOperationClient client = new RenamedOperationClient(endpoint, "default");

            Response response = await client.RenamedThreeAsync();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_RenamedOperation_RenamedFive_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            RenamedOperationClient client = new RenamedOperationClient(endpoint, "default");

            Response response = client.RenamedFive();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_RenamedOperation_RenamedFive_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            RenamedOperationClient client = new RenamedOperationClient(endpoint, "default");

            Response response = await client.RenamedFiveAsync();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_RenamedOperation_RenamedFive_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            RenamedOperationClient client = new RenamedOperationClient(endpoint, "default");

            Response response = client.RenamedFive();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_RenamedOperation_RenamedFive_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            RenamedOperationClient client = new RenamedOperationClient(endpoint, "default");

            Response response = await client.RenamedFiveAsync();

            Console.WriteLine(response.Status);
        }
    }
}
