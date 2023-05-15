// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;
using _Type._Dictionary.Models;

namespace _Type._Dictionary.Samples
{
    internal class Samples_BooleanValue
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetBooleanValue()
        {
            var client = new DictionaryClient().GetBooleanValueClient("1.0.0");

            Response response = client.GetBooleanValue(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("<test>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetBooleanValue_AllParameters()
        {
            var client = new DictionaryClient().GetBooleanValueClient("1.0.0");

            Response response = client.GetBooleanValue(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("<test>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetBooleanValue_Async()
        {
            var client = new DictionaryClient().GetBooleanValueClient("1.0.0");

            Response response = await client.GetBooleanValueAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("<test>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetBooleanValue_AllParameters_Async()
        {
            var client = new DictionaryClient().GetBooleanValueClient("1.0.0");

            Response response = await client.GetBooleanValueAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("<test>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetBooleanValue_Convenience_Async()
        {
            var client = new DictionaryClient().GetBooleanValueClient("1.0.0");

            var result = await client.GetBooleanValueAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put()
        {
            var client = new DictionaryClient().GetBooleanValueClient("1.0.0");

            var data = new
            {
                key = true,
            };

            Response response = client.Put(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters()
        {
            var client = new DictionaryClient().GetBooleanValueClient("1.0.0");

            var data = new
            {
                key = true,
            };

            Response response = client.Put(RequestContent.Create(data), new RequestContext());
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_Async()
        {
            var client = new DictionaryClient().GetBooleanValueClient("1.0.0");

            var data = new
            {
                key = true,
            };

            Response response = await client.PutAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Async()
        {
            var client = new DictionaryClient().GetBooleanValueClient("1.0.0");

            var data = new
            {
                key = true,
            };

            Response response = await client.PutAsync(RequestContent.Create(data), new RequestContext());
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_Convenience_Async()
        {
            var client = new DictionaryClient().GetBooleanValueClient("1.0.0");

            var body = new Dictionary<string, bool>
            {
                ["key"] = true,
            };
            var result = await client.PutAsync(body);
        }
    }
}
