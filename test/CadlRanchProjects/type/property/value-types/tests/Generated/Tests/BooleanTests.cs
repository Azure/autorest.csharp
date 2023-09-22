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
    public class BooleanTests : _TypePropertyValueTypesTestBase
    {
        public BooleanTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task GetBoolean_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Boolean client = CreateValueTypesClient(endpoint).GetBooleanClient(apiVersion: "1.0.0");

            Response response = await client.GetBooleanAsync(null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task GetBoolean_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Boolean client = CreateValueTypesClient(endpoint).GetBooleanClient(apiVersion: "1.0.0");

            Response<BooleanProperty> response = await client.GetBooleanAsync();
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task GetBoolean_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Boolean client = CreateValueTypesClient(endpoint).GetBooleanClient(apiVersion: "1.0.0");

            Response response = await client.GetBooleanAsync(null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task GetBoolean_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Boolean client = CreateValueTypesClient(endpoint).GetBooleanClient(apiVersion: "1.0.0");

            Response<BooleanProperty> response = await client.GetBooleanAsync();
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Put_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Boolean client = CreateValueTypesClient(endpoint).GetBooleanClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                property = true,
            });
            Response response = await client.PutAsync(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Put_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Boolean client = CreateValueTypesClient(endpoint).GetBooleanClient(apiVersion: "1.0.0");

            BooleanProperty body = new BooleanProperty(true);
            Response response = await client.PutAsync(body);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Put_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Boolean client = CreateValueTypesClient(endpoint).GetBooleanClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                property = true,
            });
            Response response = await client.PutAsync(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Put_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Boolean client = CreateValueTypesClient(endpoint).GetBooleanClient(apiVersion: "1.0.0");

            BooleanProperty body = new BooleanProperty(true);
            Response response = await client.PutAsync(body);
        }
    }
}
