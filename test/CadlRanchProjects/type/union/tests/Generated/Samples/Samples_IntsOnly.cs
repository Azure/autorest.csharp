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
using _Type.Union.Models;

namespace _Type.Union.Samples
{
    public partial class Samples_IntsOnly
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_IntsOnly_GetIntsOnly_ShortVersion()
        {
            IntsOnly client = new UnionClient().GetIntsOnlyClient();

            Response response = client.GetIntsOnly(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_IntsOnly_GetIntsOnly_ShortVersion_Async()
        {
            IntsOnly client = new UnionClient().GetIntsOnlyClient();

            Response response = await client.GetIntsOnlyAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_IntsOnly_GetIntsOnly_ShortVersion_Convenience()
        {
            IntsOnly client = new UnionClient().GetIntsOnlyClient();

            Response<GetResponse3> response = client.GetIntsOnly();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_IntsOnly_GetIntsOnly_ShortVersion_Convenience_Async()
        {
            IntsOnly client = new UnionClient().GetIntsOnlyClient();

            Response<GetResponse3> response = await client.GetIntsOnlyAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_IntsOnly_GetIntsOnly_AllParameters()
        {
            IntsOnly client = new UnionClient().GetIntsOnlyClient();

            Response response = client.GetIntsOnly(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_IntsOnly_GetIntsOnly_AllParameters_Async()
        {
            IntsOnly client = new UnionClient().GetIntsOnlyClient();

            Response response = await client.GetIntsOnlyAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_IntsOnly_GetIntsOnly_AllParameters_Convenience()
        {
            IntsOnly client = new UnionClient().GetIntsOnlyClient();

            Response<GetResponse3> response = client.GetIntsOnly();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_IntsOnly_GetIntsOnly_AllParameters_Convenience_Async()
        {
            IntsOnly client = new UnionClient().GetIntsOnlyClient();

            Response<GetResponse3> response = await client.GetIntsOnlyAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_IntsOnly_Send_ShortVersion()
        {
            IntsOnly client = new UnionClient().GetIntsOnlyClient();

            using RequestContent content = RequestContent.Create(new
            {
                prop = 1,
            });
            Response response = client.Send(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_IntsOnly_Send_ShortVersion_Async()
        {
            IntsOnly client = new UnionClient().GetIntsOnlyClient();

            using RequestContent content = RequestContent.Create(new
            {
                prop = 1,
            });
            Response response = await client.SendAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_IntsOnly_Send_ShortVersion_Convenience()
        {
            IntsOnly client = new UnionClient().GetIntsOnlyClient();

            Response response = client.Send(GetResponseProp2._1);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_IntsOnly_Send_ShortVersion_Convenience_Async()
        {
            IntsOnly client = new UnionClient().GetIntsOnlyClient();

            Response response = await client.SendAsync(GetResponseProp2._1);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_IntsOnly_Send_AllParameters()
        {
            IntsOnly client = new UnionClient().GetIntsOnlyClient();

            using RequestContent content = RequestContent.Create(new
            {
                prop = 1,
            });
            Response response = client.Send(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_IntsOnly_Send_AllParameters_Async()
        {
            IntsOnly client = new UnionClient().GetIntsOnlyClient();

            using RequestContent content = RequestContent.Create(new
            {
                prop = 1,
            });
            Response response = await client.SendAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_IntsOnly_Send_AllParameters_Convenience()
        {
            IntsOnly client = new UnionClient().GetIntsOnlyClient();

            Response response = client.Send(GetResponseProp2._1);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_IntsOnly_Send_AllParameters_Convenience_Async()
        {
            IntsOnly client = new UnionClient().GetIntsOnlyClient();

            Response response = await client.SendAsync(GetResponseProp2._1);
        }
    }
}
