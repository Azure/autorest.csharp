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
    public partial class Samples_BooleanValue
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetBooleanValue_ShortVersion()
        {
            BooleanValue client = new DictionaryClient().GetBooleanValueClient();

            Response response = client.GetBooleanValue(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("<key>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetBooleanValue_ShortVersion_Async()
        {
            BooleanValue client = new DictionaryClient().GetBooleanValueClient();

            Response response = await client.GetBooleanValueAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("<key>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetBooleanValue_ShortVersion_Convenience()
        {
            BooleanValue client = new DictionaryClient().GetBooleanValueClient();

            Response<IReadOnlyDictionary<string, bool>> response = client.GetBooleanValue();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetBooleanValue_ShortVersion_Convenience_Async()
        {
            BooleanValue client = new DictionaryClient().GetBooleanValueClient();

            Response<IReadOnlyDictionary<string, bool>> response = await client.GetBooleanValueAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetBooleanValue_AllParameters()
        {
            BooleanValue client = new DictionaryClient().GetBooleanValueClient();

            Response response = client.GetBooleanValue(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("<key>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetBooleanValue_AllParameters_Async()
        {
            BooleanValue client = new DictionaryClient().GetBooleanValueClient();

            Response response = await client.GetBooleanValueAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("<key>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetBooleanValue_AllParameters_Convenience()
        {
            BooleanValue client = new DictionaryClient().GetBooleanValueClient();

            Response<IReadOnlyDictionary<string, bool>> response = client.GetBooleanValue();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetBooleanValue_AllParameters_Convenience_Async()
        {
            BooleanValue client = new DictionaryClient().GetBooleanValueClient();

            Response<IReadOnlyDictionary<string, bool>> response = await client.GetBooleanValueAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_ShortVersion()
        {
            BooleanValue client = new DictionaryClient().GetBooleanValueClient();

            using RequestContent content = RequestContent.Create(new
            {
                key = true,
            });
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_ShortVersion_Async()
        {
            BooleanValue client = new DictionaryClient().GetBooleanValueClient();

            using RequestContent content = RequestContent.Create(new
            {
                key = true,
            });
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_ShortVersion_Convenience()
        {
            BooleanValue client = new DictionaryClient().GetBooleanValueClient();

            Response response = client.Put(new Dictionary<string, bool>
            {
                ["key"] = true
            });
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_ShortVersion_Convenience_Async()
        {
            BooleanValue client = new DictionaryClient().GetBooleanValueClient();

            Response response = await client.PutAsync(new Dictionary<string, bool>
            {
                ["key"] = true
            });
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters()
        {
            BooleanValue client = new DictionaryClient().GetBooleanValueClient();

            using RequestContent content = RequestContent.Create(new
            {
                key = true,
            });
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Async()
        {
            BooleanValue client = new DictionaryClient().GetBooleanValueClient();

            using RequestContent content = RequestContent.Create(new
            {
                key = true,
            });
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters_Convenience()
        {
            BooleanValue client = new DictionaryClient().GetBooleanValueClient();

            Response response = client.Put(new Dictionary<string, bool>
            {
                ["key"] = true
            });
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Convenience_Async()
        {
            BooleanValue client = new DictionaryClient().GetBooleanValueClient();

            Response response = await client.PutAsync(new Dictionary<string, bool>
            {
                ["key"] = true
            });
        }
    }
}
