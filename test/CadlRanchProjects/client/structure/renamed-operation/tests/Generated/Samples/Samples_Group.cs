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
    public partial class Samples_Group
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Group_RenamedTwo_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Group client = new RenamedOperationClient(endpoint, "<client>").GetGroupClient();

            Response response = client.RenamedTwo();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Group_RenamedTwo_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Group client = new RenamedOperationClient(endpoint, "<client>").GetGroupClient();

            Response response = await client.RenamedTwoAsync();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Group_RenamedTwo_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Group client = new RenamedOperationClient(endpoint, "<client>").GetGroupClient();

            Response response = client.RenamedTwo();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Group_RenamedTwo_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Group client = new RenamedOperationClient(endpoint, "<client>").GetGroupClient();

            Response response = await client.RenamedTwoAsync();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Group_RenamedFour_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Group client = new RenamedOperationClient(endpoint, "<client>").GetGroupClient();

            Response response = client.RenamedFour();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Group_RenamedFour_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Group client = new RenamedOperationClient(endpoint, "<client>").GetGroupClient();

            Response response = await client.RenamedFourAsync();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Group_RenamedFour_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Group client = new RenamedOperationClient(endpoint, "<client>").GetGroupClient();

            Response response = client.RenamedFour();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Group_RenamedFour_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Group client = new RenamedOperationClient(endpoint, "<client>").GetGroupClient();

            Response response = await client.RenamedFourAsync();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Group_RenamedSix_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Group client = new RenamedOperationClient(endpoint, "<client>").GetGroupClient();

            Response response = client.RenamedSix();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Group_RenamedSix_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Group client = new RenamedOperationClient(endpoint, "<client>").GetGroupClient();

            Response response = await client.RenamedSixAsync();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Group_RenamedSix_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Group client = new RenamedOperationClient(endpoint, "<client>").GetGroupClient();

            Response response = client.RenamedSix();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Group_RenamedSix_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Group client = new RenamedOperationClient(endpoint, "<client>").GetGroupClient();

            Response response = await client.RenamedSixAsync();

            Console.WriteLine(response.Status);
        }
    }
}
