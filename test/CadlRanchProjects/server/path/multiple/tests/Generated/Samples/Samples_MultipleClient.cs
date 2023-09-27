// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using NUnit.Framework;
using Server.Path.Multiple;

namespace Server.Path.Multiple.Samples
{
    public partial class Samples_MultipleClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_NoOperationParams()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            MultipleClient client = new MultipleClient(endpoint);

            Response response = client.NoOperationParams();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_NoOperationParams_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            MultipleClient client = new MultipleClient(endpoint);

            Response response = await client.NoOperationParamsAsync();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_NoOperationParams_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            MultipleClient client = new MultipleClient(endpoint);

            Response response = client.NoOperationParams();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_NoOperationParams_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            MultipleClient client = new MultipleClient(endpoint);

            Response response = await client.NoOperationParamsAsync();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_WithOperationPathParam()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            MultipleClient client = new MultipleClient(endpoint);

            Response response = client.WithOperationPathParam("<keyword>");

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_WithOperationPathParam_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            MultipleClient client = new MultipleClient(endpoint);

            Response response = await client.WithOperationPathParamAsync("<keyword>");

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_WithOperationPathParam_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            MultipleClient client = new MultipleClient(endpoint);

            Response response = client.WithOperationPathParam("<keyword>");

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_WithOperationPathParam_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            MultipleClient client = new MultipleClient(endpoint);

            Response response = await client.WithOperationPathParamAsync("<keyword>");

            Console.WriteLine(response.Status);
        }
    }
}
