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
using _Type._Dictionary;

namespace _Type._Dictionary.Samples
{
    public partial class Samples_NullableFloatValue
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNullableFloatValue_ShortVersion()
        {
            NullableFloatValue client = new DictionaryClient().GetNullableFloatValueClient(apiVersion: "1.0.0");

            Response response = client.GetNullableFloatValue(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("<key>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNullableFloatValue_ShortVersion_Async()
        {
            NullableFloatValue client = new DictionaryClient().GetNullableFloatValueClient(apiVersion: "1.0.0");

            Response response = await client.GetNullableFloatValueAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("<key>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNullableFloatValue_ShortVersion_Convenience()
        {
            NullableFloatValue client = new DictionaryClient().GetNullableFloatValueClient(apiVersion: "1.0.0");

            Response<IReadOnlyDictionary<string, float?>> response = client.GetNullableFloatValue();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNullableFloatValue_ShortVersion_Convenience_Async()
        {
            NullableFloatValue client = new DictionaryClient().GetNullableFloatValueClient(apiVersion: "1.0.0");

            Response<IReadOnlyDictionary<string, float?>> response = await client.GetNullableFloatValueAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNullableFloatValue_AllParameters()
        {
            NullableFloatValue client = new DictionaryClient().GetNullableFloatValueClient(apiVersion: "1.0.0");

            Response response = client.GetNullableFloatValue(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("<key>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNullableFloatValue_AllParameters_Async()
        {
            NullableFloatValue client = new DictionaryClient().GetNullableFloatValueClient(apiVersion: "1.0.0");

            Response response = await client.GetNullableFloatValueAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("<key>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNullableFloatValue_AllParameters_Convenience()
        {
            NullableFloatValue client = new DictionaryClient().GetNullableFloatValueClient(apiVersion: "1.0.0");

            Response<IReadOnlyDictionary<string, float?>> response = client.GetNullableFloatValue();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNullableFloatValue_AllParameters_Convenience_Async()
        {
            NullableFloatValue client = new DictionaryClient().GetNullableFloatValueClient(apiVersion: "1.0.0");

            Response<IReadOnlyDictionary<string, float?>> response = await client.GetNullableFloatValueAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_ShortVersion()
        {
            NullableFloatValue client = new DictionaryClient().GetNullableFloatValueClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                key = 123.45F,
            });
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_ShortVersion_Async()
        {
            NullableFloatValue client = new DictionaryClient().GetNullableFloatValueClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                key = 123.45F,
            });
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_ShortVersion_Convenience()
        {
            NullableFloatValue client = new DictionaryClient().GetNullableFloatValueClient(apiVersion: "1.0.0");

            Response response = client.Put(new Dictionary<string, float?>
            {
                ["key"] = 123.45F
            });
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_ShortVersion_Convenience_Async()
        {
            NullableFloatValue client = new DictionaryClient().GetNullableFloatValueClient(apiVersion: "1.0.0");

            Response response = await client.PutAsync(new Dictionary<string, float?>
            {
                ["key"] = 123.45F
            });
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters()
        {
            NullableFloatValue client = new DictionaryClient().GetNullableFloatValueClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                key = 123.45F,
            });
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Async()
        {
            NullableFloatValue client = new DictionaryClient().GetNullableFloatValueClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                key = 123.45F,
            });
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters_Convenience()
        {
            NullableFloatValue client = new DictionaryClient().GetNullableFloatValueClient(apiVersion: "1.0.0");

            Response response = client.Put(new Dictionary<string, float?>
            {
                ["key"] = 123.45F
            });
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Convenience_Async()
        {
            NullableFloatValue client = new DictionaryClient().GetNullableFloatValueClient(apiVersion: "1.0.0");

            Response response = await client.PutAsync(new Dictionary<string, float?>
            {
                ["key"] = 123.45F
            });
        }
    }
}
