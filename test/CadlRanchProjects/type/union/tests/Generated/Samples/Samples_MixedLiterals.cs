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
    public partial class Samples_MixedLiterals
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_MixedLiterals_GetMixedLiteral_ShortVersion()
        {
            MixedLiterals client = new UnionClient().GetMixedLiteralsClient();

            Response response = client.GetMixedLiteral(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result.GetProperty("prop").GetProperty("stringLiteral").ToString());
            Console.WriteLine(result.GetProperty("prop").GetProperty("intLiteral").ToString());
            Console.WriteLine(result.GetProperty("prop").GetProperty("floatLiteral").ToString());
            Console.WriteLine(result.GetProperty("prop").GetProperty("booleanLiteral").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_MixedLiterals_GetMixedLiteral_ShortVersion_Async()
        {
            MixedLiterals client = new UnionClient().GetMixedLiteralsClient();

            Response response = await client.GetMixedLiteralAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result.GetProperty("prop").GetProperty("stringLiteral").ToString());
            Console.WriteLine(result.GetProperty("prop").GetProperty("intLiteral").ToString());
            Console.WriteLine(result.GetProperty("prop").GetProperty("floatLiteral").ToString());
            Console.WriteLine(result.GetProperty("prop").GetProperty("booleanLiteral").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_MixedLiterals_GetMixedLiteral_ShortVersion_Convenience()
        {
            MixedLiterals client = new UnionClient().GetMixedLiteralsClient();

            Response<GetResponse1> response = client.GetMixedLiteral();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_MixedLiterals_GetMixedLiteral_ShortVersion_Convenience_Async()
        {
            MixedLiterals client = new UnionClient().GetMixedLiteralsClient();

            Response<GetResponse1> response = await client.GetMixedLiteralAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_MixedLiterals_GetMixedLiteral_AllParameters()
        {
            MixedLiterals client = new UnionClient().GetMixedLiteralsClient();

            Response response = client.GetMixedLiteral(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result.GetProperty("prop").GetProperty("stringLiteral").ToString());
            Console.WriteLine(result.GetProperty("prop").GetProperty("intLiteral").ToString());
            Console.WriteLine(result.GetProperty("prop").GetProperty("floatLiteral").ToString());
            Console.WriteLine(result.GetProperty("prop").GetProperty("booleanLiteral").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_MixedLiterals_GetMixedLiteral_AllParameters_Async()
        {
            MixedLiterals client = new UnionClient().GetMixedLiteralsClient();

            Response response = await client.GetMixedLiteralAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result.GetProperty("prop").GetProperty("stringLiteral").ToString());
            Console.WriteLine(result.GetProperty("prop").GetProperty("intLiteral").ToString());
            Console.WriteLine(result.GetProperty("prop").GetProperty("floatLiteral").ToString());
            Console.WriteLine(result.GetProperty("prop").GetProperty("booleanLiteral").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_MixedLiterals_GetMixedLiteral_AllParameters_Convenience()
        {
            MixedLiterals client = new UnionClient().GetMixedLiteralsClient();

            Response<GetResponse1> response = client.GetMixedLiteral();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_MixedLiterals_GetMixedLiteral_AllParameters_Convenience_Async()
        {
            MixedLiterals client = new UnionClient().GetMixedLiteralsClient();

            Response<GetResponse1> response = await client.GetMixedLiteralAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_MixedLiterals_Send_ShortVersion()
        {
            MixedLiterals client = new UnionClient().GetMixedLiteralsClient();

            using RequestContent content = RequestContent.Create(new
            {
                prop = new
                {
                    stringLiteral = "a",
                    intLiteral = "a",
                    floatLiteral = "a",
                    booleanLiteral = "a",
                },
            });
            Response response = client.Send(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_MixedLiterals_Send_ShortVersion_Async()
        {
            MixedLiterals client = new UnionClient().GetMixedLiteralsClient();

            using RequestContent content = RequestContent.Create(new
            {
                prop = new
                {
                    stringLiteral = "a",
                    intLiteral = "a",
                    floatLiteral = "a",
                    booleanLiteral = "a",
                },
            });
            Response response = await client.SendAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_MixedLiterals_Send_ShortVersion_Convenience()
        {
            MixedLiterals client = new UnionClient().GetMixedLiteralsClient();

            MixedLiteralsCases prop = new MixedLiteralsCases(BinaryData.FromObjectAsJson("a"), BinaryData.FromObjectAsJson("a"), BinaryData.FromObjectAsJson("a"), BinaryData.FromObjectAsJson("a"));
            Response response = client.Send(prop);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_MixedLiterals_Send_ShortVersion_Convenience_Async()
        {
            MixedLiterals client = new UnionClient().GetMixedLiteralsClient();

            MixedLiteralsCases prop = new MixedLiteralsCases(BinaryData.FromObjectAsJson("a"), BinaryData.FromObjectAsJson("a"), BinaryData.FromObjectAsJson("a"), BinaryData.FromObjectAsJson("a"));
            Response response = await client.SendAsync(prop);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_MixedLiterals_Send_AllParameters()
        {
            MixedLiterals client = new UnionClient().GetMixedLiteralsClient();

            using RequestContent content = RequestContent.Create(new
            {
                prop = new
                {
                    stringLiteral = "a",
                    intLiteral = "a",
                    floatLiteral = "a",
                    booleanLiteral = "a",
                },
            });
            Response response = client.Send(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_MixedLiterals_Send_AllParameters_Async()
        {
            MixedLiterals client = new UnionClient().GetMixedLiteralsClient();

            using RequestContent content = RequestContent.Create(new
            {
                prop = new
                {
                    stringLiteral = "a",
                    intLiteral = "a",
                    floatLiteral = "a",
                    booleanLiteral = "a",
                },
            });
            Response response = await client.SendAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_MixedLiterals_Send_AllParameters_Convenience()
        {
            MixedLiterals client = new UnionClient().GetMixedLiteralsClient();

            MixedLiteralsCases prop = new MixedLiteralsCases(BinaryData.FromObjectAsJson("a"), BinaryData.FromObjectAsJson("a"), BinaryData.FromObjectAsJson("a"), BinaryData.FromObjectAsJson("a"));
            Response response = client.Send(prop);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_MixedLiterals_Send_AllParameters_Convenience_Async()
        {
            MixedLiterals client = new UnionClient().GetMixedLiteralsClient();

            MixedLiteralsCases prop = new MixedLiteralsCases(BinaryData.FromObjectAsJson("a"), BinaryData.FromObjectAsJson("a"), BinaryData.FromObjectAsJson("a"), BinaryData.FromObjectAsJson("a"));
            Response response = await client.SendAsync(prop);
        }
    }
}
