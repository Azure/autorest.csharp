// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using NUnit.Framework;
using Server.Path.Single;

namespace Server.Path.Single.Samples
{
    public partial class Samples_SingleClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Single_MyOp_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SingleClient client = new SingleClient(endpoint);

            Response response = client.MyOp();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Single_MyOp_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SingleClient client = new SingleClient(endpoint);

            Response response = await client.MyOpAsync();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Single_MyOp_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SingleClient client = new SingleClient(endpoint);

            Response response = client.MyOp();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Single_MyOp_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            SingleClient client = new SingleClient(endpoint);

            Response response = await client.MyOpAsync();

            Console.WriteLine(response.Status);
        }
    }
}
