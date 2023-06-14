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

namespace Server.Path.Multiple.Samples
{
    public class Samples_MultipleClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_NoOperationParams()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new MultipleClient(endpoint);

            Response response = client.NoOperationParams();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_NoOperationParams_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new MultipleClient(endpoint);

            Response response = client.NoOperationParams();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_NoOperationParams_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new MultipleClient(endpoint);

            Response response = await client.NoOperationParamsAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_NoOperationParams_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new MultipleClient(endpoint);

            Response response = await client.NoOperationParamsAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_WithOperationPathParam()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new MultipleClient(endpoint);

            Response response = client.WithOperationPathParam("<keyword>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_WithOperationPathParam_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new MultipleClient(endpoint);

            Response response = client.WithOperationPathParam("<keyword>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_WithOperationPathParam_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new MultipleClient(endpoint);

            Response response = await client.WithOperationPathParamAsync("<keyword>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_WithOperationPathParam_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new MultipleClient(endpoint);

            Response response = await client.WithOperationPathParamAsync("<keyword>");
            Console.WriteLine(response.Status);
        }
    }
}
