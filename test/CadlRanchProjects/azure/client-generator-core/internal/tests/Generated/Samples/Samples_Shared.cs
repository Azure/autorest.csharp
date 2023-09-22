// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using NUnit.Framework;
using _Specs_.Azure.ClientGenerator.Core.Internal;
using _Specs_.Azure.ClientGenerator.Core.Internal.Models;

namespace _Specs_.Azure.ClientGenerator.Core.Internal.Samples
{
    internal class Samples_Shared
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Public()
        {
            Shared client = new InternalClient().GetSharedClient();

            Response response = client.Public("<name>", null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Public_Async()
        {
            Shared client = new InternalClient().GetSharedClient();

            Response response = await client.PublicAsync("<name>", null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Public_Convenience()
        {
            Shared client = new InternalClient().GetSharedClient();

            Response<SharedModel> response = client.Public("<name>");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Public_Convenience_Async()
        {
            Shared client = new InternalClient().GetSharedClient();

            Response<SharedModel> response = await client.PublicAsync("<name>");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Public_AllParameters()
        {
            Shared client = new InternalClient().GetSharedClient();

            Response response = client.Public("<name>", null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Public_AllParameters_Async()
        {
            Shared client = new InternalClient().GetSharedClient();

            Response response = await client.PublicAsync("<name>", null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Public_AllParameters_Convenience()
        {
            Shared client = new InternalClient().GetSharedClient();

            Response<SharedModel> response = client.Public("<name>");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Public_AllParameters_Convenience_Async()
        {
            Shared client = new InternalClient().GetSharedClient();

            Response<SharedModel> response = await client.PublicAsync("<name>");
        }
    }
}
