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
using _Type._Dictionary.Models;

namespace _Type._Dictionary.Samples
{
    public class Samples_ModelValue
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetModelValue()
        {
            ModelValue client = new DictionaryClient().GetModelValueClient("1.0.0");

            Response response = client.GetModelValue(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("<key>").GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetModelValue_Async()
        {
            ModelValue client = new DictionaryClient().GetModelValueClient("1.0.0");

            Response response = await client.GetModelValueAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("<key>").GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetModelValue_Convenience()
        {
            ModelValue client = new DictionaryClient().GetModelValueClient("1.0.0");

            Response<IReadOnlyDictionary<string, InnerModel>> response = client.GetModelValue();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetModelValue_Convenience_Async()
        {
            ModelValue client = new DictionaryClient().GetModelValueClient("1.0.0");

            Response<IReadOnlyDictionary<string, InnerModel>> response = await client.GetModelValueAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetModelValue_AllParameters()
        {
            ModelValue client = new DictionaryClient().GetModelValueClient("1.0.0");

            Response response = client.GetModelValue(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("<key>").GetProperty("property").ToString());
            Console.WriteLine(result.GetProperty("<key>").GetProperty("children").GetProperty("<key>").GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetModelValue_AllParameters_Async()
        {
            ModelValue client = new DictionaryClient().GetModelValueClient("1.0.0");

            Response response = await client.GetModelValueAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("<key>").GetProperty("property").ToString());
            Console.WriteLine(result.GetProperty("<key>").GetProperty("children").GetProperty("<key>").GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetModelValue_AllParameters_Convenience()
        {
            ModelValue client = new DictionaryClient().GetModelValueClient("1.0.0");

            Response<IReadOnlyDictionary<string, InnerModel>> response = client.GetModelValue();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetModelValue_AllParameters_Convenience_Async()
        {
            ModelValue client = new DictionaryClient().GetModelValueClient("1.0.0");

            Response<IReadOnlyDictionary<string, InnerModel>> response = await client.GetModelValueAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put()
        {
            ModelValue client = new DictionaryClient().GetModelValueClient("1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                key = new
                {
                    property = "<property>",
                },
            });
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_Async()
        {
            ModelValue client = new DictionaryClient().GetModelValueClient("1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                key = new
                {
                    property = "<property>",
                },
            });
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_Convenience()
        {
            ModelValue client = new DictionaryClient().GetModelValueClient("1.0.0");

            Response response = client.Put(new Dictionary<string, InnerModel>
            {
                ["key"] = new InnerModel("<property>")
            });
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_Convenience_Async()
        {
            ModelValue client = new DictionaryClient().GetModelValueClient("1.0.0");

            Response response = await client.PutAsync(new Dictionary<string, InnerModel>
            {
                ["key"] = new InnerModel("<property>")
            });
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters()
        {
            ModelValue client = new DictionaryClient().GetModelValueClient("1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                key = new
                {
                    property = "<property>",
                    children = new { },
                },
            });
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Async()
        {
            ModelValue client = new DictionaryClient().GetModelValueClient("1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                key = new
                {
                    property = "<property>",
                    children = new { },
                },
            });
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters_Convenience()
        {
            ModelValue client = new DictionaryClient().GetModelValueClient("1.0.0");

            Response response = client.Put(new Dictionary<string, InnerModel>
            {
                ["key"] = new InnerModel("<property>")
                {
                    Children =
{
["key"] = default
},
                }
            });
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Convenience_Async()
        {
            ModelValue client = new DictionaryClient().GetModelValueClient("1.0.0");

            Response response = await client.PutAsync(new Dictionary<string, InnerModel>
            {
                ["key"] = new InnerModel("<property>")
                {
                    Children =
{
["key"] = default
},
                }
            });
        }
    }
}
