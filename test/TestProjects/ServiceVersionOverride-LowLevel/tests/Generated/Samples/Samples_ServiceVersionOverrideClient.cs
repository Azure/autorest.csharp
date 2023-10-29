// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using NUnit.Framework;
using ServiceVersionOverride_LowLevel;

namespace ServiceVersionOverride_LowLevel.Samples
{
    public partial class Samples_ServiceVersionOverrideClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Operation_ShortVersion()
        {
            ServiceVersionOverrideClient client = new ServiceVersionOverrideClient();

            Response response = client.Operation("2.0");

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Operation_ShortVersion_Async()
        {
            ServiceVersionOverrideClient client = new ServiceVersionOverrideClient();

            Response response = await client.OperationAsync("2.0");

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Operation_AllParameters()
        {
            ServiceVersionOverrideClient client = new ServiceVersionOverrideClient();

            Response response = client.Operation("2.0");

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Operation_AllParameters_Async()
        {
            ServiceVersionOverrideClient client = new ServiceVersionOverrideClient();

            Response response = await client.OperationAsync("2.0");

            Console.WriteLine(response.Status);
        }
    }
}
