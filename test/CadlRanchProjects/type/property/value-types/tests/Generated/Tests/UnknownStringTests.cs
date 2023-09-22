// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;
using _Type.Property.ValueTypes;
using _Type.Property.ValueTypes.Models;

namespace _Type.Property.ValueTypes.Tests
{
    public class UnknownStringTests : _TypePropertyValueTypesTestBase
    {
        public UnknownStringTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task GetUnknownString_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            UnknownString client = CreateValueTypesClient(endpoint).GetUnknownStringClient(apiVersion: "1.0.0");

            Response response = await client.GetUnknownStringAsync(null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task GetUnknownString_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            UnknownString client = CreateValueTypesClient(endpoint).GetUnknownStringClient(apiVersion: "1.0.0");

            Response<UnknownStringProperty> response = await client.GetUnknownStringAsync();
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task GetUnknownString_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            UnknownString client = CreateValueTypesClient(endpoint).GetUnknownStringClient(apiVersion: "1.0.0");

            Response response = await client.GetUnknownStringAsync(null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task GetUnknownString_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            UnknownString client = CreateValueTypesClient(endpoint).GetUnknownStringClient(apiVersion: "1.0.0");

            Response<UnknownStringProperty> response = await client.GetUnknownStringAsync();
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Put_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            UnknownString client = CreateValueTypesClient(endpoint).GetUnknownStringClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                property = new object(),
            });
            Response response = await client.PutAsync(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Put_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            UnknownString client = CreateValueTypesClient(endpoint).GetUnknownStringClient(apiVersion: "1.0.0");

            UnknownStringProperty body = new UnknownStringProperty(BinaryData.FromObjectAsJson(new object()));
            Response response = await client.PutAsync(body);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Put_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            UnknownString client = CreateValueTypesClient(endpoint).GetUnknownStringClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                property = new object(),
            });
            Response response = await client.PutAsync(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Put_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            UnknownString client = CreateValueTypesClient(endpoint).GetUnknownStringClient(apiVersion: "1.0.0");

            UnknownStringProperty body = new UnknownStringProperty(BinaryData.FromObjectAsJson(new object()));
            Response response = await client.PutAsync(body);
        }
    }
}
