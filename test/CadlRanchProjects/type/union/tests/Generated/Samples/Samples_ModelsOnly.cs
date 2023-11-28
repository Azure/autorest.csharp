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
    public partial class Samples_ModelsOnly
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ModelsOnly_GetModelsOnly_ShortVersion()
        {
            ModelsOnly client = new UnionClient().GetModelsOnlyClient(apiVersion: "1.0.0");

            Response response = client.GetModelsOnly(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ModelsOnly_GetModelsOnly_ShortVersion_Async()
        {
            ModelsOnly client = new UnionClient().GetModelsOnlyClient(apiVersion: "1.0.0");

            Response response = await client.GetModelsOnlyAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ModelsOnly_GetModelsOnly_ShortVersion_Convenience()
        {
            ModelsOnly client = new UnionClient().GetModelsOnlyClient(apiVersion: "1.0.0");

            Response<object> response = client.GetModelsOnly();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ModelsOnly_GetModelsOnly_ShortVersion_Convenience_Async()
        {
            ModelsOnly client = new UnionClient().GetModelsOnlyClient(apiVersion: "1.0.0");

            Response<object> response = await client.GetModelsOnlyAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ModelsOnly_GetModelsOnly_AllParameters()
        {
            ModelsOnly client = new UnionClient().GetModelsOnlyClient(apiVersion: "1.0.0");

            Response response = client.GetModelsOnly(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ModelsOnly_GetModelsOnly_AllParameters_Async()
        {
            ModelsOnly client = new UnionClient().GetModelsOnlyClient(apiVersion: "1.0.0");

            Response response = await client.GetModelsOnlyAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ModelsOnly_GetModelsOnly_AllParameters_Convenience()
        {
            ModelsOnly client = new UnionClient().GetModelsOnlyClient(apiVersion: "1.0.0");

            Response<object> response = client.GetModelsOnly();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ModelsOnly_GetModelsOnly_AllParameters_Convenience_Async()
        {
            ModelsOnly client = new UnionClient().GetModelsOnlyClient(apiVersion: "1.0.0");

            Response<object> response = await client.GetModelsOnlyAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ModelsOnly_Send_ShortVersion()
        {
            ModelsOnly client = new UnionClient().GetModelsOnlyClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new
            {
                prop = "a",
            });
            Response response = client.Send(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ModelsOnly_Send_ShortVersion_Async()
        {
            ModelsOnly client = new UnionClient().GetModelsOnlyClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new
            {
                prop = "a",
            });
            Response response = await client.SendAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ModelsOnly_Send_ShortVersion_Convenience()
        {
            ModelsOnly client = new UnionClient().GetModelsOnlyClient(apiVersion: "1.0.0");

            Response response = client.Send(SendRequestProp.A);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ModelsOnly_Send_ShortVersion_Convenience_Async()
        {
            ModelsOnly client = new UnionClient().GetModelsOnlyClient(apiVersion: "1.0.0");

            Response response = await client.SendAsync(SendRequestProp.A);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ModelsOnly_Send_AllParameters()
        {
            ModelsOnly client = new UnionClient().GetModelsOnlyClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new
            {
                prop = "a",
            });
            Response response = client.Send(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ModelsOnly_Send_AllParameters_Async()
        {
            ModelsOnly client = new UnionClient().GetModelsOnlyClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new
            {
                prop = "a",
            });
            Response response = await client.SendAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ModelsOnly_Send_AllParameters_Convenience()
        {
            ModelsOnly client = new UnionClient().GetModelsOnlyClient(apiVersion: "1.0.0");

            Response response = client.Send(SendRequestProp.A);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ModelsOnly_Send_AllParameters_Convenience_Async()
        {
            ModelsOnly client = new UnionClient().GetModelsOnlyClient(apiVersion: "1.0.0");

            Response response = await client.SendAsync(SendRequestProp.A);
        }
    }
}
