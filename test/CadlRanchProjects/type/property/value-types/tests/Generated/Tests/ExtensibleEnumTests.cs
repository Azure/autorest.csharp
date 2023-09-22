// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;
using _Type.Property.ValueTypes;
using _Type.Property.ValueTypes.Models;

namespace _Type.Property.ValueTypes.Tests
{
    public class ExtensibleEnumTests : _TypePropertyValueTypesTestBase
    {
        public ExtensibleEnumTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task GetExtensibleEnum_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ExtensibleEnum client = CreateValueTypesClient(endpoint).GetExtensibleEnumClient(apiVersion: "1.0.0");

            Response response = await client.GetExtensibleEnumAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        public async Task GetExtensibleEnum_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ExtensibleEnum client = CreateValueTypesClient(endpoint).GetExtensibleEnumClient(apiVersion: "1.0.0");

            Response<ExtensibleEnumProperty> response = await client.GetExtensibleEnumAsync();
        }

        [Test]
        public async Task GetExtensibleEnum_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ExtensibleEnum client = CreateValueTypesClient(endpoint).GetExtensibleEnumClient(apiVersion: "1.0.0");

            Response response = await client.GetExtensibleEnumAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property").ToString());
        }

        [Test]
        public async Task GetExtensibleEnum_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ExtensibleEnum client = CreateValueTypesClient(endpoint).GetExtensibleEnumClient(apiVersion: "1.0.0");

            Response<ExtensibleEnumProperty> response = await client.GetExtensibleEnumAsync();
        }

        [Test]
        public async Task Put_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ExtensibleEnum client = CreateValueTypesClient(endpoint).GetExtensibleEnumClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                property = "ValueOne",
            });
            Response response = await client.PutAsync(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        public async Task Put_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ExtensibleEnum client = CreateValueTypesClient(endpoint).GetExtensibleEnumClient(apiVersion: "1.0.0");

            ExtensibleEnumProperty body = new ExtensibleEnumProperty(InnerEnum.ValueOne);
            Response response = await client.PutAsync(body);
            Console.WriteLine(response.Status);
        }

        [Test]
        public async Task Put_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ExtensibleEnum client = CreateValueTypesClient(endpoint).GetExtensibleEnumClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                property = "ValueOne",
            });
            Response response = await client.PutAsync(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        public async Task Put_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            ExtensibleEnum client = CreateValueTypesClient(endpoint).GetExtensibleEnumClient(apiVersion: "1.0.0");

            ExtensibleEnumProperty body = new ExtensibleEnumProperty(InnerEnum.ValueOne);
            Response response = await client.PutAsync(body);
            Console.WriteLine(response.Status);
        }
    }
}
