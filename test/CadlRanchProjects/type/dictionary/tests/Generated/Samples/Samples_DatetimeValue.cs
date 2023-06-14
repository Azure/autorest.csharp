// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
    internal class Samples_DatetimeValue
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDatetimeValue()
        {
            var client = new DictionaryClient().GetDatetimeValueClient("1.0.0");

            Response response = client.GetDatetimeValue(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("<test>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDatetimeValue_AllParameters()
        {
            var client = new DictionaryClient().GetDatetimeValueClient("1.0.0");

            Response response = client.GetDatetimeValue(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("<test>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDatetimeValue_Async()
        {
            var client = new DictionaryClient().GetDatetimeValueClient("1.0.0");

            Response response = await client.GetDatetimeValueAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("<test>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDatetimeValue_AllParameters_Async()
        {
            var client = new DictionaryClient().GetDatetimeValueClient("1.0.0");

            Response response = await client.GetDatetimeValueAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("<test>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDatetimeValue_Convenience_Async()
        {
            var client = new DictionaryClient().GetDatetimeValueClient("1.0.0");

            var result = await client.GetDatetimeValueAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put()
        {
            var client = new DictionaryClient().GetDatetimeValueClient("1.0.0");

            var data = new
            {
                key = "2022-05-10T14:57:31.2311892-04:00",
            };

            Response response = client.Put(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters()
        {
            var client = new DictionaryClient().GetDatetimeValueClient("1.0.0");

            var data = new
            {
                key = "2022-05-10T14:57:31.2311892-04:00",
            };

            Response response = client.Put(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_Async()
        {
            var client = new DictionaryClient().GetDatetimeValueClient("1.0.0");

            var data = new
            {
                key = "2022-05-10T14:57:31.2311892-04:00",
            };

            Response response = await client.PutAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Async()
        {
            var client = new DictionaryClient().GetDatetimeValueClient("1.0.0");

            var data = new
            {
                key = "2022-05-10T14:57:31.2311892-04:00",
            };

            Response response = await client.PutAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_Convenience_Async()
        {
            var client = new DictionaryClient().GetDatetimeValueClient("1.0.0");

            var body = new Dictionary<string, DateTimeOffset>
            {
                ["key"] = DateTimeOffset.UtcNow,
            };
            var result = await client.PutAsync(body);
        }
    }
}
