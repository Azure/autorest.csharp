// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using Client.Structure.Service.Models;
using NUnit.Framework;

namespace Client.Structure.Service.Samples
{
    public partial class Samples_Qux
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Qux_Eight_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Qux client = new ServiceClient(endpoint, default).GetQuxClient();

            Response response = client.Eight();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Qux_Eight_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Qux client = new ServiceClient(endpoint, default).GetQuxClient();

            Response response = await client.EightAsync();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Qux_Eight_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Qux client = new ServiceClient(endpoint, default).GetQuxClient();

            Response response = client.Eight();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Qux_Eight_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Qux client = new ServiceClient(endpoint, default).GetQuxClient();

            Response response = await client.EightAsync();

            Console.WriteLine(response.Status);
        }
    }
}
