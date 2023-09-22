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
using _Type._Array;

namespace _Type._Array.Tests
{
    public class UnknownValueTests : _Type_ArrayTestBase
    {
        public UnknownValueTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task GetUnknownValue_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            UnknownValue client = CreateArrayClient(endpoint).GetUnknownValueClient(apiVersion: "1.0.0");

            Response response = await client.GetUnknownValueAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        public async Task GetUnknownValue_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            UnknownValue client = CreateArrayClient(endpoint).GetUnknownValueClient(apiVersion: "1.0.0");

            Response<IReadOnlyList<BinaryData>> response = await client.GetUnknownValueAsync();
        }

        [Test]
        public async Task GetUnknownValue_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            UnknownValue client = CreateArrayClient(endpoint).GetUnknownValueClient(apiVersion: "1.0.0");

            Response response = await client.GetUnknownValueAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        public async Task GetUnknownValue_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            UnknownValue client = CreateArrayClient(endpoint).GetUnknownValueClient(apiVersion: "1.0.0");

            Response<IReadOnlyList<BinaryData>> response = await client.GetUnknownValueAsync();
        }

        [Test]
        public async Task Put_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            UnknownValue client = CreateArrayClient(endpoint).GetUnknownValueClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new List<object>()
{
new object()
});
            Response response = await client.PutAsync(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        public async Task Put_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            UnknownValue client = CreateArrayClient(endpoint).GetUnknownValueClient(apiVersion: "1.0.0");

            Response response = await client.PutAsync(new List<BinaryData>()
{
BinaryData.FromObjectAsJson(new object())
});
            Console.WriteLine(response.Status);
        }

        [Test]
        public async Task Put_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            UnknownValue client = CreateArrayClient(endpoint).GetUnknownValueClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new List<object>()
{
new object()
});
            Response response = await client.PutAsync(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        public async Task Put_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            UnknownValue client = CreateArrayClient(endpoint).GetUnknownValueClient(apiVersion: "1.0.0");

            Response response = await client.PutAsync(new List<BinaryData>()
{
BinaryData.FromObjectAsJson(new object())
});
            Console.WriteLine(response.Status);
        }
    }
}
