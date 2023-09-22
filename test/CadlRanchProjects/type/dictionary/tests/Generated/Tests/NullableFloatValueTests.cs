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

namespace _Type._Dictionary.Tests
{
    public class NullableFloatValueTests : _Type_DictionaryTestBase
    {
        public NullableFloatValueTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task GetNullableFloatValue_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            NullableFloatValue client = CreateDictionaryClient(endpoint).GetNullableFloatValueClient(apiVersion: "1.0.0");

            Response response = await client.GetNullableFloatValueAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("<key>").ToString());
        }

        [Test]
        public async Task GetNullableFloatValue_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            NullableFloatValue client = CreateDictionaryClient(endpoint).GetNullableFloatValueClient(apiVersion: "1.0.0");

            Response<IReadOnlyDictionary<string, float?>> response = await client.GetNullableFloatValueAsync();
        }

        [Test]
        public async Task GetNullableFloatValue_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            NullableFloatValue client = CreateDictionaryClient(endpoint).GetNullableFloatValueClient(apiVersion: "1.0.0");

            Response response = await client.GetNullableFloatValueAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("<key>").ToString());
        }

        [Test]
        public async Task GetNullableFloatValue_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            NullableFloatValue client = CreateDictionaryClient(endpoint).GetNullableFloatValueClient(apiVersion: "1.0.0");

            Response<IReadOnlyDictionary<string, float?>> response = await client.GetNullableFloatValueAsync();
        }

        [Test]
        public async Task Put_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            NullableFloatValue client = CreateDictionaryClient(endpoint).GetNullableFloatValueClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                key = 123.45F,
            });
            Response response = await client.PutAsync(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        public async Task Put_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            NullableFloatValue client = CreateDictionaryClient(endpoint).GetNullableFloatValueClient(apiVersion: "1.0.0");

            Response response = await client.PutAsync(new Dictionary<string, float?>()
            {
                ["key"] = 123.45F,
            });
            Console.WriteLine(response.Status);
        }

        [Test]
        public async Task Put_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            NullableFloatValue client = CreateDictionaryClient(endpoint).GetNullableFloatValueClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                key = 123.45F,
            });
            Response response = await client.PutAsync(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        public async Task Put_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            NullableFloatValue client = CreateDictionaryClient(endpoint).GetNullableFloatValueClient(apiVersion: "1.0.0");

            Response response = await client.PutAsync(new Dictionary<string, float?>()
            {
                ["key"] = 123.45F,
            });
            Console.WriteLine(response.Status);
        }
    }
}
