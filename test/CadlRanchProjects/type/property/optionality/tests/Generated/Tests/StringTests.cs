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
using _Type.Property.Optionality;
using _Type.Property.Optionality.Models;

namespace _Type.Property.Optionality.Tests
{
    public class StringTests : _TypePropertyOptionalityTestBase
    {
        public StringTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task GetAll_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            String client = CreateOptionalClient(endpoint).GetStringClient(apiVersion: "1.0.0");

            Response response = await client.GetAllAsync(null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task GetAll_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            String client = CreateOptionalClient(endpoint).GetStringClient(apiVersion: "1.0.0");

            Response<StringProperty> response = await client.GetAllAsync();
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task GetAll_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            String client = CreateOptionalClient(endpoint).GetStringClient(apiVersion: "1.0.0");

            Response response = await client.GetAllAsync(null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task GetAll_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            String client = CreateOptionalClient(endpoint).GetStringClient(apiVersion: "1.0.0");

            Response<StringProperty> response = await client.GetAllAsync();
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task GetDefault_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            String client = CreateOptionalClient(endpoint).GetStringClient(apiVersion: "1.0.0");

            Response response = await client.GetDefaultAsync(null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task GetDefault_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            String client = CreateOptionalClient(endpoint).GetStringClient(apiVersion: "1.0.0");

            Response<StringProperty> response = await client.GetDefaultAsync();
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task GetDefault_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            String client = CreateOptionalClient(endpoint).GetStringClient(apiVersion: "1.0.0");

            Response response = await client.GetDefaultAsync(null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task GetDefault_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            String client = CreateOptionalClient(endpoint).GetStringClient(apiVersion: "1.0.0");

            Response<StringProperty> response = await client.GetDefaultAsync();
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task PutAll_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            String client = CreateOptionalClient(endpoint).GetStringClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutAllAsync(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task PutAll_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            String client = CreateOptionalClient(endpoint).GetStringClient(apiVersion: "1.0.0");

            StringProperty body = new StringProperty();
            Response response = await client.PutAllAsync(body);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task PutAll_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            String client = CreateOptionalClient(endpoint).GetStringClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                property = "<property>",
            });
            Response response = await client.PutAllAsync(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task PutAll_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            String client = CreateOptionalClient(endpoint).GetStringClient(apiVersion: "1.0.0");

            StringProperty body = new StringProperty()
            {
                Property = "<property>",
            };
            Response response = await client.PutAllAsync(body);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task PutDefault_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            String client = CreateOptionalClient(endpoint).GetStringClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutDefaultAsync(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task PutDefault_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            String client = CreateOptionalClient(endpoint).GetStringClient(apiVersion: "1.0.0");

            StringProperty body = new StringProperty();
            Response response = await client.PutDefaultAsync(body);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task PutDefault_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            String client = CreateOptionalClient(endpoint).GetStringClient(apiVersion: "1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                property = "<property>",
            });
            Response response = await client.PutDefaultAsync(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task PutDefault_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            String client = CreateOptionalClient(endpoint).GetStringClient(apiVersion: "1.0.0");

            StringProperty body = new StringProperty()
            {
                Property = "<property>",
            };
            Response response = await client.PutDefaultAsync(body);
        }
    }
}
