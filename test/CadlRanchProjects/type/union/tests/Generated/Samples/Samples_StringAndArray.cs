// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;
using _Type.Union.Models;

namespace _Type.Union.Samples
{
    public partial class Samples_StringAndArray
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_StringAndArray_GetStringAndArray_ShortVersion()
        {
            StringAndArray client = new UnionClient().GetStringAndArrayClient();

            Response response = client.GetStringAndArray(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").GetProperty("string").ToString());
            Console.WriteLine(result.GetProperty("prop").GetProperty("array").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_StringAndArray_GetStringAndArray_ShortVersion_Async()
        {
            StringAndArray client = new UnionClient().GetStringAndArrayClient();

            Response response = await client.GetStringAndArrayAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").GetProperty("string").ToString());
            Console.WriteLine(result.GetProperty("prop").GetProperty("array").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_StringAndArray_GetStringAndArray_ShortVersion_Convenience()
        {
            StringAndArray client = new UnionClient().GetStringAndArrayClient();

            Response<GetResponse2> response = client.GetStringAndArray();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_StringAndArray_GetStringAndArray_ShortVersion_Convenience_Async()
        {
            StringAndArray client = new UnionClient().GetStringAndArrayClient();

            Response<GetResponse2> response = await client.GetStringAndArrayAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_StringAndArray_GetStringAndArray_AllParameters()
        {
            StringAndArray client = new UnionClient().GetStringAndArrayClient();

            Response response = client.GetStringAndArray(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").GetProperty("string").ToString());
            Console.WriteLine(result.GetProperty("prop").GetProperty("array").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_StringAndArray_GetStringAndArray_AllParameters_Async()
        {
            StringAndArray client = new UnionClient().GetStringAndArrayClient();

            Response response = await client.GetStringAndArrayAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").GetProperty("string").ToString());
            Console.WriteLine(result.GetProperty("prop").GetProperty("array").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_StringAndArray_GetStringAndArray_AllParameters_Convenience()
        {
            StringAndArray client = new UnionClient().GetStringAndArrayClient();

            Response<GetResponse2> response = client.GetStringAndArray();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_StringAndArray_GetStringAndArray_AllParameters_Convenience_Async()
        {
            StringAndArray client = new UnionClient().GetStringAndArrayClient();

            Response<GetResponse2> response = await client.GetStringAndArrayAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_StringAndArray_Send_ShortVersion()
        {
            StringAndArray client = new UnionClient().GetStringAndArrayClient();

            using RequestContent content = RequestContent.Create(new
            {
                prop = new Dictionary<string, object>
                {
                    ["string"] = "<string>",
                    ["array"] = "<array>"
                },
            });
            Response response = client.Send(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_StringAndArray_Send_ShortVersion_Async()
        {
            StringAndArray client = new UnionClient().GetStringAndArrayClient();

            using RequestContent content = RequestContent.Create(new
            {
                prop = new Dictionary<string, object>
                {
                    ["string"] = "<string>",
                    ["array"] = "<array>"
                },
            });
            Response response = await client.SendAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_StringAndArray_Send_ShortVersion_Convenience()
        {
            StringAndArray client = new UnionClient().GetStringAndArrayClient();

            StringAndArrayCases prop = new StringAndArrayCases(BinaryData.FromObjectAsJson("<string>"), BinaryData.FromObjectAsJson("<array>"));
            Response response = client.Send(prop);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_StringAndArray_Send_ShortVersion_Convenience_Async()
        {
            StringAndArray client = new UnionClient().GetStringAndArrayClient();

            StringAndArrayCases prop = new StringAndArrayCases(BinaryData.FromObjectAsJson("<string>"), BinaryData.FromObjectAsJson("<array>"));
            Response response = await client.SendAsync(prop);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_StringAndArray_Send_AllParameters()
        {
            StringAndArray client = new UnionClient().GetStringAndArrayClient();

            using RequestContent content = RequestContent.Create(new
            {
                prop = new Dictionary<string, object>
                {
                    ["string"] = "<string>",
                    ["array"] = "<array>"
                },
            });
            Response response = client.Send(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_StringAndArray_Send_AllParameters_Async()
        {
            StringAndArray client = new UnionClient().GetStringAndArrayClient();

            using RequestContent content = RequestContent.Create(new
            {
                prop = new Dictionary<string, object>
                {
                    ["string"] = "<string>",
                    ["array"] = "<array>"
                },
            });
            Response response = await client.SendAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_StringAndArray_Send_AllParameters_Convenience()
        {
            StringAndArray client = new UnionClient().GetStringAndArrayClient();

            StringAndArrayCases prop = new StringAndArrayCases(BinaryData.FromObjectAsJson("<string>"), BinaryData.FromObjectAsJson("<array>"));
            Response response = client.Send(prop);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_StringAndArray_Send_AllParameters_Convenience_Async()
        {
            StringAndArray client = new UnionClient().GetStringAndArrayClient();

            StringAndArrayCases prop = new StringAndArrayCases(BinaryData.FromObjectAsJson("<string>"), BinaryData.FromObjectAsJson("<array>"));
            Response response = await client.SendAsync(prop);
        }
    }
}
