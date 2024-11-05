// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using Client.Structure.Service.ClientOperationGroup.Models;
using NUnit.Framework;

namespace Client.Structure.Service.ClientOperationGroup.Samples
{
    public partial class Samples_FirstClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ClientOperationGroup_One_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            FirstClient client = new FirstClient(endpoint, default);

            Response response = client.One();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ClientOperationGroup_One_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            FirstClient client = new FirstClient(endpoint, default);

            Response response = await client.OneAsync();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ClientOperationGroup_One_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            FirstClient client = new FirstClient(endpoint, default);

            Response response = client.One();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ClientOperationGroup_One_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            FirstClient client = new FirstClient(endpoint, default);

            Response response = await client.OneAsync();

            Console.WriteLine(response.Status);
        }
    }
}
