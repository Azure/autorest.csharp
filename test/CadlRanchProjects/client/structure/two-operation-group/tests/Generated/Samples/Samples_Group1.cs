// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using Client.Structure.Service.TwoOperationGroup.Models;
using NUnit.Framework;

namespace Client.Structure.Service.TwoOperationGroup.Samples
{
    public partial class Samples_Group1
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Group1_One_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Group1 client = new TwoOperationGroupClient(endpoint).GetGroup1Client(ClientType.Default);

            Response response = client.One();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Group1_One_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Group1 client = new TwoOperationGroupClient(endpoint).GetGroup1Client(ClientType.Default);

            Response response = await client.OneAsync();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Group1_One_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Group1 client = new TwoOperationGroupClient(endpoint).GetGroup1Client(ClientType.Default);

            Response response = client.One();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Group1_One_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Group1 client = new TwoOperationGroupClient(endpoint).GetGroup1Client(ClientType.Default);

            Response response = await client.OneAsync();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Group1_Three_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Group1 client = new TwoOperationGroupClient(endpoint).GetGroup1Client(ClientType.Default);

            Response response = client.Three();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Group1_Three_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Group1 client = new TwoOperationGroupClient(endpoint).GetGroup1Client(ClientType.Default);

            Response response = await client.ThreeAsync();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Group1_Three_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Group1 client = new TwoOperationGroupClient(endpoint).GetGroup1Client(ClientType.Default);

            Response response = client.Three();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Group1_Three_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Group1 client = new TwoOperationGroupClient(endpoint).GetGroup1Client(ClientType.Default);

            Response response = await client.ThreeAsync();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Group1_Four_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Group1 client = new TwoOperationGroupClient(endpoint).GetGroup1Client(ClientType.Default);

            Response response = client.Four();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Group1_Four_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Group1 client = new TwoOperationGroupClient(endpoint).GetGroup1Client(ClientType.Default);

            Response response = await client.FourAsync();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Group1_Four_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Group1 client = new TwoOperationGroupClient(endpoint).GetGroup1Client(ClientType.Default);

            Response response = client.Four();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Group1_Four_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Group1 client = new TwoOperationGroupClient(endpoint).GetGroup1Client(ClientType.Default);

            Response response = await client.FourAsync();

            Console.WriteLine(response.Status);
        }
    }
}
