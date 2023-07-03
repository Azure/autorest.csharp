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
using _Type._Dictionary;
using _Type._Dictionary.Models;

namespace _Type._Dictionary.Samples
{
    internal class Samples_DurationValue
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDurationValue()
        {
            DurationValue client = new DictionaryClient().GetDurationValueClient("1.0.0");

            Response response = client.GetDurationValue(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("<test>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDurationValue_AllParameters()
        {
            DurationValue client = new DictionaryClient().GetDurationValueClient("1.0.0");

            Response response = client.GetDurationValue(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("<test>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDurationValue_Async()
        {
            DurationValue client = new DictionaryClient().GetDurationValueClient("1.0.0");

            Response response = await client.GetDurationValueAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("<test>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDurationValue_AllParameters_Async()
        {
            DurationValue client = new DictionaryClient().GetDurationValueClient("1.0.0");

            Response response = await client.GetDurationValueAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("<test>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDurationValue_Convenience_Async()
        {
            var client = new DictionaryClient().GetDurationValueClient("1.0.0");

            var result = await client.GetDurationValueAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put()
        {
            DurationValue client = new DictionaryClient().GetDurationValueClient("1.0.0");

            var data = new
            {
                key = "PT1H23M45S"
            };

            Response response = client.Put(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters()
        {
            DurationValue client = new DictionaryClient().GetDurationValueClient("1.0.0");

            var data = new
            {
                key = "PT1H23M45S"
            };

            Response response = client.Put(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_Async()
        {
            DurationValue client = new DictionaryClient().GetDurationValueClient("1.0.0");

            var data = new
            {
                key = "PT1H23M45S"
            };

            Response response = await client.PutAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Async()
        {
            DurationValue client = new DictionaryClient().GetDurationValueClient("1.0.0");

            var data = new
            {
                key = "PT1H23M45S"
            };

            Response response = await client.PutAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_Convenience_Async()
        {
            var client = new DictionaryClient().GetDurationValueClient("1.0.0");

            var body = new Dictionary<string, TimeSpan>
            {
                ["key"] = new TimeSpan(1, 2, 3),
            };
            var result = await client.PutAsync(body);
        }
    }
}
