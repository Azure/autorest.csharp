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
    public partial class Samples_Float32Value
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetFloat32Value()
        {
            Float32Value client = new DictionaryClient().GetFloat32ValueClient(apiVersion: "1.0.0");

            Response response = client.GetFloat32Value(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("<key>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetFloat32Value_Async()
        {
            Float32Value client = new DictionaryClient().GetFloat32ValueClient(apiVersion: "1.0.0");

            Response response = await client.GetFloat32ValueAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("<key>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetFloat32Value_Convenience()
        {
            Float32Value client = new DictionaryClient().GetFloat32ValueClient(apiVersion: "1.0.0");

            Response<IReadOnlyDictionary<string, float>> response = client.GetFloat32Value();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetFloat32Value_Convenience_Async()
        {
            Float32Value client = new DictionaryClient().GetFloat32ValueClient(apiVersion: "1.0.0");

            Response<IReadOnlyDictionary<string, float>> response = await client.GetFloat32ValueAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetFloat32Value_AllParameters()
        {
            Float32Value client = new DictionaryClient().GetFloat32ValueClient(apiVersion: "1.0.0");

            Response response = client.GetFloat32Value(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("<key>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetFloat32Value_AllParameters_Async()
        {
            Float32Value client = new DictionaryClient().GetFloat32ValueClient(apiVersion: "1.0.0");

            Response response = await client.GetFloat32ValueAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("<key>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetFloat32Value_AllParameters_Convenience()
        {
            Float32Value client = new DictionaryClient().GetFloat32ValueClient(apiVersion: "1.0.0");

            Response<IReadOnlyDictionary<string, float>> response = client.GetFloat32Value();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetFloat32Value_AllParameters_Convenience_Async()
        {
            Float32Value client = new DictionaryClient().GetFloat32ValueClient(apiVersion: "1.0.0");

            Response<IReadOnlyDictionary<string, float>> response = await client.GetFloat32ValueAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put()
        {
            Float32Value client = new DictionaryClient().GetFloat32ValueClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                key = 123.45F,
            });
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_Async()
        {
            Float32Value client = new DictionaryClient().GetFloat32ValueClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                key = 123.45F,
            });
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_Convenience()
        {
            Float32Value client = new DictionaryClient().GetFloat32ValueClient(apiVersion: "1.0.0");

            Response response = client.Put(new Dictionary<string, float>
            {
                ["key"] = 123.45F
            });
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_Convenience_Async()
        {
            Float32Value client = new DictionaryClient().GetFloat32ValueClient(apiVersion: "1.0.0");

            Response response = await client.PutAsync(new Dictionary<string, float>
            {
                ["key"] = 123.45F
            });
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put_AllParameters()
        {
            Float32Value client = new DictionaryClient().GetFloat32ValueClient(apiVersion: "1.0.0");

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
            Float32Value client = new DictionaryClient().GetFloat32ValueClient(apiVersion: "1.0.0");

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
            Float32Value client = new DictionaryClient().GetFloat32ValueClient(apiVersion: "1.0.0");

            Response response = client.Put(new Dictionary<string, float>
            {
                ["key"] = 123.45F
            });
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put_AllParameters_Convenience_Async()
        {
            Float32Value client = new DictionaryClient().GetFloat32ValueClient(apiVersion: "1.0.0");

            Response response = await client.PutAsync(new Dictionary<string, float>
            {
                ["key"] = 123.45F
            });
        }
    }
}
