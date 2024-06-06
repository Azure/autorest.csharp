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
    public partial class Samples_StringsOnly
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_StringsOnly_GetStringsOnly_ShortVersion()
        {
            StringsOnly client = new UnionClient().GetStringsOnlyClient();

            Response response = client.GetStringsOnly(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_StringsOnly_GetStringsOnly_ShortVersion_Async()
        {
            StringsOnly client = new UnionClient().GetStringsOnlyClient();

            Response response = await client.GetStringsOnlyAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_StringsOnly_GetStringsOnly_ShortVersion_Convenience()
        {
            StringsOnly client = new UnionClient().GetStringsOnlyClient();

            Response<GetResponse9> response = client.GetStringsOnly();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_StringsOnly_GetStringsOnly_ShortVersion_Convenience_Async()
        {
            StringsOnly client = new UnionClient().GetStringsOnlyClient();

            Response<GetResponse9> response = await client.GetStringsOnlyAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_StringsOnly_GetStringsOnly_AllParameters()
        {
            StringsOnly client = new UnionClient().GetStringsOnlyClient();

            Response response = client.GetStringsOnly(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_StringsOnly_GetStringsOnly_AllParameters_Async()
        {
            StringsOnly client = new UnionClient().GetStringsOnlyClient();

            Response response = await client.GetStringsOnlyAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_StringsOnly_GetStringsOnly_AllParameters_Convenience()
        {
            StringsOnly client = new UnionClient().GetStringsOnlyClient();

            Response<GetResponse9> response = client.GetStringsOnly();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_StringsOnly_GetStringsOnly_AllParameters_Convenience_Async()
        {
            StringsOnly client = new UnionClient().GetStringsOnlyClient();

            Response<GetResponse9> response = await client.GetStringsOnlyAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_StringsOnly_Send_ShortVersion()
        {
            StringsOnly client = new UnionClient().GetStringsOnlyClient();

            using RequestContent content = RequestContent.Create(new
            {
                prop = "a",
            });
            Response response = client.Send(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_StringsOnly_Send_ShortVersion_Async()
        {
            StringsOnly client = new UnionClient().GetStringsOnlyClient();

            using RequestContent content = RequestContent.Create(new
            {
                prop = "a",
            });
            Response response = await client.SendAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_StringsOnly_Send_ShortVersion_Convenience()
        {
            StringsOnly client = new UnionClient().GetStringsOnlyClient();

            Response response = client.Send(GetResponseProp7.A);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_StringsOnly_Send_ShortVersion_Convenience_Async()
        {
            StringsOnly client = new UnionClient().GetStringsOnlyClient();

            Response response = await client.SendAsync(GetResponseProp7.A);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_StringsOnly_Send_AllParameters()
        {
            StringsOnly client = new UnionClient().GetStringsOnlyClient();

            using RequestContent content = RequestContent.Create(new
            {
                prop = "a",
            });
            Response response = client.Send(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_StringsOnly_Send_AllParameters_Async()
        {
            StringsOnly client = new UnionClient().GetStringsOnlyClient();

            using RequestContent content = RequestContent.Create(new
            {
                prop = "a",
            });
            Response response = await client.SendAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_StringsOnly_Send_AllParameters_Convenience()
        {
            StringsOnly client = new UnionClient().GetStringsOnlyClient();

            Response response = client.Send(GetResponseProp7.A);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_StringsOnly_Send_AllParameters_Convenience_Async()
        {
            StringsOnly client = new UnionClient().GetStringsOnlyClient();

            Response response = await client.SendAsync(GetResponseProp7.A);
        }
    }
}
