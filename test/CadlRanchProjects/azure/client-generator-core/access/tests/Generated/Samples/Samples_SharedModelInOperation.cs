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
using _Specs_.Azure.ClientGenerator.Core.Access.Models;

namespace _Specs_.Azure.ClientGenerator.Core.Access.Samples
{
    public partial class Samples_SharedModelInOperation
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SharedModelInOperation_Public_ShortVersion()
        {
            SharedModelInOperation client = new AccessClient().GetSharedModelInOperationClient();

            Response response = client.Public("<name>", null);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SharedModelInOperation_Public_ShortVersion_Async()
        {
            SharedModelInOperation client = new AccessClient().GetSharedModelInOperationClient();

            Response response = await client.PublicAsync("<name>", null);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SharedModelInOperation_Public_ShortVersion_Convenience()
        {
            SharedModelInOperation client = new AccessClient().GetSharedModelInOperationClient();

            Response<SharedModel> response = client.Public("<name>");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SharedModelInOperation_Public_ShortVersion_Convenience_Async()
        {
            SharedModelInOperation client = new AccessClient().GetSharedModelInOperationClient();

            Response<SharedModel> response = await client.PublicAsync("<name>");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SharedModelInOperation_Public_AllParameters()
        {
            SharedModelInOperation client = new AccessClient().GetSharedModelInOperationClient();

            Response response = client.Public("<name>", null);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SharedModelInOperation_Public_AllParameters_Async()
        {
            SharedModelInOperation client = new AccessClient().GetSharedModelInOperationClient();

            Response response = await client.PublicAsync("<name>", null);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SharedModelInOperation_Public_AllParameters_Convenience()
        {
            SharedModelInOperation client = new AccessClient().GetSharedModelInOperationClient();

            Response<SharedModel> response = client.Public("<name>");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SharedModelInOperation_Public_AllParameters_Convenience_Async()
        {
            SharedModelInOperation client = new AccessClient().GetSharedModelInOperationClient();

            Response<SharedModel> response = await client.PublicAsync("<name>");
        }
    }
}
