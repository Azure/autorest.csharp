// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using NUnit.Framework;
using SpecialHeaders.ClientRequestId;

namespace SpecialHeaders.ClientRequestId.Samples
{
    public class Samples_ClientRequestIdClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetClientRequestId()
        {
            ClientRequestIdClient client = new ClientRequestIdClient();

            Response response = client.GetClientRequestId();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetClientRequestId_AllParameters()
        {
            ClientRequestIdClient client = new ClientRequestIdClient();

            Response response = client.GetClientRequestId();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetClientRequestId_Async()
        {
            ClientRequestIdClient client = new ClientRequestIdClient();

            Response response = await client.GetClientRequestIdAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetClientRequestId_AllParameters_Async()
        {
            ClientRequestIdClient client = new ClientRequestIdClient();

            Response response = await client.GetClientRequestIdAsync();
            Console.WriteLine(response.Status);
        }
    }
}
