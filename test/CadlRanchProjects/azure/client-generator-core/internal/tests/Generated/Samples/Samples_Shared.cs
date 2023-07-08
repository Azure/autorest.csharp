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

namespace _Specs_.Azure.ClientGenerator.Core.Internal.Samples
{
    internal class Samples_Shared
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Public()
        {
            Shared client = new InternalClient().GetSharedClient();

            Response response = client.Public("<name>", new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Public_Async()
        {
            Shared client = new InternalClient().GetSharedClient();

            Response response = await client.PublicAsync("<name>", new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Public_AllParameters()
        {
            Shared client = new InternalClient().GetSharedClient();

            Response response = client.Public("<name>", new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Public_AllParameters_Async()
        {
            Shared client = new InternalClient().GetSharedClient();

            Response response = await client.PublicAsync("<name>", new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }
    }
}
