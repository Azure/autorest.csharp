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
using _Specs_.Azure.ClientGenerator.Core.Access;
using _Specs_.Azure.ClientGenerator.Core.Access.Models;

namespace _Specs_.Azure.ClientGenerator.Core.Access.Samples
{
    public partial class Samples_SharedModelInOperation
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Public_ShortVersion()
        {
            SharedModelInOperation client = new AccessClient().GetSharedModelInOperationClient(apiVersion: "1.0.0");

            Response response = client.Public("<name>", null);

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Public_ShortVersion_Async()
        {
            SharedModelInOperation client = new AccessClient().GetSharedModelInOperationClient(apiVersion: "1.0.0");

            Response response = await client.PublicAsync("<name>", null);

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Public_ShortVersion_Convenience()
        {
            SharedModelInOperation client = new AccessClient().GetSharedModelInOperationClient(apiVersion: "1.0.0");

            Response<SharedModel> response = client.Public("<name>");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Public_ShortVersion_Convenience_Async()
        {
            SharedModelInOperation client = new AccessClient().GetSharedModelInOperationClient(apiVersion: "1.0.0");

            Response<SharedModel> response = await client.PublicAsync("<name>");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Public_AllParameters()
        {
            SharedModelInOperation client = new AccessClient().GetSharedModelInOperationClient(apiVersion: "1.0.0");

            Response response = client.Public("<name>", null);

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Public_AllParameters_Async()
        {
            SharedModelInOperation client = new AccessClient().GetSharedModelInOperationClient(apiVersion: "1.0.0");

            Response response = await client.PublicAsync("<name>", null);

            JsonElement element = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(element.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Public_AllParameters_Convenience()
        {
            SharedModelInOperation client = new AccessClient().GetSharedModelInOperationClient(apiVersion: "1.0.0");

            Response<SharedModel> response = client.Public("<name>");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Public_AllParameters_Convenience_Async()
        {
            SharedModelInOperation client = new AccessClient().GetSharedModelInOperationClient(apiVersion: "1.0.0");

            Response<SharedModel> response = await client.PublicAsync("<name>");
        }
    }
}
