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
    internal class Samples_ModelValue
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetModelValue()
        {
            var client = new DictionaryClient().GetModelValueClient("1.0.0");

            Response response = client.GetModelValue(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("<test>").GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetModelValue_AllParameters()
        {
            var client = new DictionaryClient().GetModelValueClient("1.0.0");

            Response response = client.GetModelValue(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("<test>").GetProperty("property").ToString());
            Console.WriteLine(result.GetProperty("<test>").GetProperty("children").GetProperty("<test>").GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetModelValue_Async()
        {
            var client = new DictionaryClient().GetModelValueClient("1.0.0");

            Response response = await client.GetModelValueAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("<test>").GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetModelValue_AllParameters_Async()
        {
            var client = new DictionaryClient().GetModelValueClient("1.0.0");

            Response response = await client.GetModelValueAsync(new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("<test>").GetProperty("property").ToString());
            Console.WriteLine(result.GetProperty("<test>").GetProperty("children").GetProperty("<test>").GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetModelValue_Convenience_Async()
        {
            var client = new DictionaryClient().GetModelValueClient("1.0.0");

            var result = await client.GetModelValueAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put()
        {
            var client = new DictionaryClient().GetModelValueClient("1.0.0");

            var data = new
            {
                key = new
                {
                    property = "<property>",
                },
            };

            Response response = client.Put(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters()
        {
            var client = new DictionaryClient().GetModelValueClient("1.0.0");

            var data = new
            {
                key = new
                {
                    property = "<property>",
                },
            };

            Response response = client.Put(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_Async()
        {
            var client = new DictionaryClient().GetModelValueClient("1.0.0");

            var data = new
            {
                key = new
                {
                    property = "<property>",
                },
            };

            Response response = await client.PutAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Async()
        {
            var client = new DictionaryClient().GetModelValueClient("1.0.0");

            var data = new
            {
                key = new
                {
                    property = "<property>",
                },
            };

            Response response = await client.PutAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_Convenience_Async()
        {
            var client = new DictionaryClient().GetModelValueClient("1.0.0");

            var body = new Dictionary<string, InnerModel>
            {
                ["key"] = new InnerModel("<property>")
                {
                    Children = { },
                },
            };
            var result = await client.PutAsync(body);
        }
    }
}
