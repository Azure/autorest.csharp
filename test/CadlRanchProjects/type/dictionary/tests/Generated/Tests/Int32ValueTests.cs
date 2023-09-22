// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;
using _Type._Dictionary;

namespace _Type._Dictionary.Tests
{
    public class Int32ValueTests : _Type_DictionaryTestBase
    {
        public Int32ValueTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task GetInt32Value_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Int32Value client = CreateDictionaryClient(endpoint).GetInt32ValueClient(apiVersion: "1.0.0");

            Response response = await client.GetInt32ValueAsync(null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task GetInt32Value_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Int32Value client = CreateDictionaryClient(endpoint).GetInt32ValueClient(apiVersion: "1.0.0");

            Response<IReadOnlyDictionary<string, int>> response = await client.GetInt32ValueAsync();
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task GetInt32Value_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Int32Value client = CreateDictionaryClient(endpoint).GetInt32ValueClient(apiVersion: "1.0.0");

            Response response = await client.GetInt32ValueAsync(null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task GetInt32Value_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Int32Value client = CreateDictionaryClient(endpoint).GetInt32ValueClient(apiVersion: "1.0.0");

            Response<IReadOnlyDictionary<string, int>> response = await client.GetInt32ValueAsync();
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Put_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Int32Value client = CreateDictionaryClient(endpoint).GetInt32ValueClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                key = 1234,
            });
            Response response = await client.PutAsync(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Put_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Int32Value client = CreateDictionaryClient(endpoint).GetInt32ValueClient(apiVersion: "1.0.0");

            Response response = await client.PutAsync(new Dictionary<string, int>()
            {
                ["key"] = 1234,
            });
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Put_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Int32Value client = CreateDictionaryClient(endpoint).GetInt32ValueClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                key = 1234,
            });
            Response response = await client.PutAsync(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Put_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Int32Value client = CreateDictionaryClient(endpoint).GetInt32ValueClient(apiVersion: "1.0.0");

            Response response = await client.PutAsync(new Dictionary<string, int>()
            {
                ["key"] = 1234,
            });
        }
    }
}
