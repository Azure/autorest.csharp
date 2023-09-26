// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using ClientAndOperationGroup;
using NUnit.Framework;

namespace ClientAndOperationGroup.Samples
{
    public class Samples_ClientAndOperationGroupClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Zero()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ClientAndOperationGroupClient client = new ClientAndOperationGroupClient(endpoint);

            Response response = client.Zero(null);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Zero_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ClientAndOperationGroupClient client = new ClientAndOperationGroupClient(endpoint);

            Response response = await client.ZeroAsync(null);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Zero_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ClientAndOperationGroupClient client = new ClientAndOperationGroupClient(endpoint);

            Response response = client.Zero(null);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Zero_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ClientAndOperationGroupClient client = new ClientAndOperationGroupClient(endpoint);

            Response response = await client.ZeroAsync(null);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_One()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ClientAndOperationGroupClient client = new ClientAndOperationGroupClient(endpoint);

            Response response = client.One(null);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_One_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ClientAndOperationGroupClient client = new ClientAndOperationGroupClient(endpoint);

            Response response = await client.OneAsync(null);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_One_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ClientAndOperationGroupClient client = new ClientAndOperationGroupClient(endpoint);

            Response response = client.One(null);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_One_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ClientAndOperationGroupClient client = new ClientAndOperationGroupClient(endpoint);

            Response response = await client.OneAsync(null);
        }
    }
}
