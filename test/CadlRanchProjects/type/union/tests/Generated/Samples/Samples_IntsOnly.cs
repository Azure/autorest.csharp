// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;
using _Type.Union;
using _Type.Union.Models;

namespace _Type.Union.Samples
{
    public partial class Samples_IntsOnly
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetIntsOnly_ShortVersion()
        {
            IntsOnly client = new UnionClient().GetIntsOnlyClient(apiVersion: "1.0.0");

            Response response = client.GetIntsOnly(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetIntsOnly_ShortVersion_Async()
        {
            IntsOnly client = new UnionClient().GetIntsOnlyClient(apiVersion: "1.0.0");

            Response response = await client.GetIntsOnlyAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetIntsOnly_ShortVersion_Convenience()
        {
            IntsOnly client = new UnionClient().GetIntsOnlyClient(apiVersion: "1.0.0");

            Response<object> response = client.GetIntsOnly();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetIntsOnly_ShortVersion_Convenience_Async()
        {
            IntsOnly client = new UnionClient().GetIntsOnlyClient(apiVersion: "1.0.0");

            Response<object> response = await client.GetIntsOnlyAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetIntsOnly_AllParameters()
        {
            IntsOnly client = new UnionClient().GetIntsOnlyClient(apiVersion: "1.0.0");

            Response response = client.GetIntsOnly(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetIntsOnly_AllParameters_Async()
        {
            IntsOnly client = new UnionClient().GetIntsOnlyClient(apiVersion: "1.0.0");

            Response response = await client.GetIntsOnlyAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetIntsOnly_AllParameters_Convenience()
        {
            IntsOnly client = new UnionClient().GetIntsOnlyClient(apiVersion: "1.0.0");

            Response<object> response = client.GetIntsOnly();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetIntsOnly_AllParameters_Convenience_Async()
        {
            IntsOnly client = new UnionClient().GetIntsOnlyClient(apiVersion: "1.0.0");

            Response<object> response = await client.GetIntsOnlyAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Send_ShortVersion()
        {
            IntsOnly client = new UnionClient().GetIntsOnlyClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new
            {
                prop = "a",
            });
            Response response = client.Send(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Send_ShortVersion_Async()
        {
            IntsOnly client = new UnionClient().GetIntsOnlyClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new
            {
                prop = "a",
            });
            Response response = await client.SendAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Send_ShortVersion_Convenience()
        {
            IntsOnly client = new UnionClient().GetIntsOnlyClient(apiVersion: "1.0.0");

            Response response = client.Send(SendRequestProp.A);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Send_ShortVersion_Convenience_Async()
        {
            IntsOnly client = new UnionClient().GetIntsOnlyClient(apiVersion: "1.0.0");

            Response response = await client.SendAsync(SendRequestProp.A);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Send_AllParameters()
        {
            IntsOnly client = new UnionClient().GetIntsOnlyClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new
            {
                prop = "a",
            });
            Response response = client.Send(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Send_AllParameters_Async()
        {
            IntsOnly client = new UnionClient().GetIntsOnlyClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new
            {
                prop = "a",
            });
            Response response = await client.SendAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Send_AllParameters_Convenience()
        {
            IntsOnly client = new UnionClient().GetIntsOnlyClient(apiVersion: "1.0.0");

            Response response = client.Send(SendRequestProp.A);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Send_AllParameters_Convenience_Async()
        {
            IntsOnly client = new UnionClient().GetIntsOnlyClient(apiVersion: "1.0.0");

            Response response = await client.SendAsync(SendRequestProp.A);
        }
    }
}
