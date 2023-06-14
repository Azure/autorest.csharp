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
using _Specs_.Azure.ClientGenerator.Core.Internal.Models;

namespace _Specs_.Azure.ClientGenerator.Core.Internal.Samples
{
    public class Samples_InternalClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PublicOnly()
        {
            var client = new InternalClient();

            Response response = client.PublicOnly("<name>", new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PublicOnly_AllParameters()
        {
            var client = new InternalClient();

            Response response = client.PublicOnly("<name>", new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PublicOnly_Async()
        {
            var client = new InternalClient();

            Response response = await client.PublicOnlyAsync("<name>", new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PublicOnly_AllParameters_Async()
        {
            var client = new InternalClient();

            Response response = await client.PublicOnlyAsync("<name>", new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PublicOnly_Convenience_Async()
        {
            var client = new InternalClient();

            var result = await client.PublicOnlyAsync("<name>");
        }
    }
}
