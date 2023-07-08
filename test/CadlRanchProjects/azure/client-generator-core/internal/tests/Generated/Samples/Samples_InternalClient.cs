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
    public class Samples_InternalClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PublicOnly()
        {
            InternalClient client = new InternalClient();

            Response response = client.PublicOnly("<name>", new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PublicOnly_Async()
        {
            InternalClient client = new InternalClient();

            Response response = await client.PublicOnlyAsync("<name>", new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PublicOnly_AllParameters()
        {
            InternalClient client = new InternalClient();

            Response response = client.PublicOnly("<name>", new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PublicOnly_AllParameters_Async()
        {
            InternalClient client = new InternalClient();

            Response response = await client.PublicOnlyAsync("<name>", new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }
    }
}
