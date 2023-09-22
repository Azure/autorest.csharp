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
using _Type._Dictionary.Models;

namespace _Type._Dictionary.Tests
{
    public class RecursiveModelValueTests : _Type_DictionaryTestBase
    {
        public RecursiveModelValueTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task GetRecursiveModelValue_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            RecursiveModelValue client = CreateDictionaryClient(endpoint).GetRecursiveModelValueClient(apiVersion: "1.0.0");

            Response response = await client.GetRecursiveModelValueAsync(null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task GetRecursiveModelValue_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            RecursiveModelValue client = CreateDictionaryClient(endpoint).GetRecursiveModelValueClient(apiVersion: "1.0.0");

            Response<IReadOnlyDictionary<string, InnerModel>> response = await client.GetRecursiveModelValueAsync();
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task GetRecursiveModelValue_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            RecursiveModelValue client = CreateDictionaryClient(endpoint).GetRecursiveModelValueClient(apiVersion: "1.0.0");

            Response response = await client.GetRecursiveModelValueAsync(null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task GetRecursiveModelValue_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            RecursiveModelValue client = CreateDictionaryClient(endpoint).GetRecursiveModelValueClient(apiVersion: "1.0.0");

            Response<IReadOnlyDictionary<string, InnerModel>> response = await client.GetRecursiveModelValueAsync();
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Put_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            RecursiveModelValue client = CreateDictionaryClient(endpoint).GetRecursiveModelValueClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                key = new
                {
                    property = "<property>",
                },
            });
            Response response = await client.PutAsync(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Put_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            RecursiveModelValue client = CreateDictionaryClient(endpoint).GetRecursiveModelValueClient(apiVersion: "1.0.0");

            Response response = await client.PutAsync(new Dictionary<string, InnerModel>()
            {
                ["key"] = new InnerModel("<property>"),
            });
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Put_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            RecursiveModelValue client = CreateDictionaryClient(endpoint).GetRecursiveModelValueClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                key = new
                {
                    property = "<property>",
                    children = new
                    {
                    },
                },
            });
            Response response = await client.PutAsync(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Put_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            RecursiveModelValue client = CreateDictionaryClient(endpoint).GetRecursiveModelValueClient(apiVersion: "1.0.0");

            Response response = await client.PutAsync(new Dictionary<string, InnerModel>()
            {
                ["key"] = new InnerModel("<property>")
                {
                    Children =
{
["key"] = null,
},
                },
            });
        }
    }
}
