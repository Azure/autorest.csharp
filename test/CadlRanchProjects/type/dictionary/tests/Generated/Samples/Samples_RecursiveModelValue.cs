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
using _Type._Dictionary.Models;

namespace _Type._Dictionary.Samples
{
    public partial class Samples_RecursiveModelValue
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_RecursiveModelValue_GetRecursiveModelValue_ShortVersion()
        {
            RecursiveModelValue client = new DictionaryClient().GetRecursiveModelValueClient();

            Response response = client.GetRecursiveModelValue(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("key").GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_RecursiveModelValue_GetRecursiveModelValue_ShortVersion_Async()
        {
            RecursiveModelValue client = new DictionaryClient().GetRecursiveModelValueClient();

            Response response = await client.GetRecursiveModelValueAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("key").GetProperty("property").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_RecursiveModelValue_GetRecursiveModelValue_ShortVersion_Convenience()
        {
            RecursiveModelValue client = new DictionaryClient().GetRecursiveModelValueClient();

            Response<IReadOnlyDictionary<string, InnerModel>> response = client.GetRecursiveModelValue();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_RecursiveModelValue_GetRecursiveModelValue_ShortVersion_Convenience_Async()
        {
            RecursiveModelValue client = new DictionaryClient().GetRecursiveModelValueClient();

            Response<IReadOnlyDictionary<string, InnerModel>> response = await client.GetRecursiveModelValueAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_RecursiveModelValue_GetRecursiveModelValue_AllParameters()
        {
            RecursiveModelValue client = new DictionaryClient().GetRecursiveModelValueClient();

            Response response = client.GetRecursiveModelValue(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("key").GetProperty("property").ToString());
            Console.WriteLine(result.GetProperty("key").GetProperty("children").GetProperty("key").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_RecursiveModelValue_GetRecursiveModelValue_AllParameters_Async()
        {
            RecursiveModelValue client = new DictionaryClient().GetRecursiveModelValueClient();

            Response response = await client.GetRecursiveModelValueAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("key").GetProperty("property").ToString());
            Console.WriteLine(result.GetProperty("key").GetProperty("children").GetProperty("key").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_RecursiveModelValue_GetRecursiveModelValue_AllParameters_Convenience()
        {
            RecursiveModelValue client = new DictionaryClient().GetRecursiveModelValueClient();

            Response<IReadOnlyDictionary<string, InnerModel>> response = client.GetRecursiveModelValue();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_RecursiveModelValue_GetRecursiveModelValue_AllParameters_Convenience_Async()
        {
            RecursiveModelValue client = new DictionaryClient().GetRecursiveModelValueClient();

            Response<IReadOnlyDictionary<string, InnerModel>> response = await client.GetRecursiveModelValueAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_RecursiveModelValue_Put_ShortVersion()
        {
            RecursiveModelValue client = new DictionaryClient().GetRecursiveModelValueClient();

            using RequestContent content = RequestContent.Create(new
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
        public async Task Example_RecursiveModelValue_Put_ShortVersion_Async()
        {
            RecursiveModelValue client = new DictionaryClient().GetRecursiveModelValueClient();

            using RequestContent content = RequestContent.Create(new
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
        public void Example_RecursiveModelValue_Put_ShortVersion_Convenience()
        {
            RecursiveModelValue client = new DictionaryClient().GetRecursiveModelValueClient();

            Response response = client.Put(new Dictionary<string, InnerModel>
            {
                ["key"] = new InnerModel("<property>")
            });
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_RecursiveModelValue_Put_ShortVersion_Convenience_Async()
        {
            RecursiveModelValue client = new DictionaryClient().GetRecursiveModelValueClient();

            Response response = await client.PutAsync(new Dictionary<string, InnerModel>
            {
                ["key"] = new InnerModel("<property>")
            });
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_RecursiveModelValue_Put_AllParameters()
        {
            RecursiveModelValue client = new DictionaryClient().GetRecursiveModelValueClient();

            using RequestContent content = RequestContent.Create(new
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
        public async Task Example_RecursiveModelValue_Put_AllParameters_Async()
        {
            RecursiveModelValue client = new DictionaryClient().GetRecursiveModelValueClient();

            using RequestContent content = RequestContent.Create(new
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
        public void Example_RecursiveModelValue_Put_AllParameters_Convenience()
        {
            RecursiveModelValue client = new DictionaryClient().GetRecursiveModelValueClient();

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
        public async Task Example_RecursiveModelValue_Put_AllParameters_Convenience_Async()
        {
            RecursiveModelValue client = new DictionaryClient().GetRecursiveModelValueClient();

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
