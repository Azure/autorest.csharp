// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using MultipleMediaTypes;
using MultipleMediaTypes.Models;
using NUnit.Framework;

namespace MultipleMediaTypes.Tests
{
    public class MultipleMediaTypesClientTests : MultipleMediaTypesTestBase
    {
        public MultipleMediaTypesClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task OneBinaryBodyTwoContentTypes_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            MultipleMediaTypesClient client = CreateMultipleMediaTypesClient(endpoint);

            RequestContent content = RequestContent.Create(new object());
            Response response = await client.OneBinaryBodyTwoContentTypesAsync(content, new ContentType("application/json"));
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task OneBinaryBodyTwoContentTypes_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            MultipleMediaTypesClient client = CreateMultipleMediaTypesClient(endpoint);

            Response response = await client.OneBinaryBodyTwoContentTypesAsync(BinaryData.FromObjectAsJson(new object()), new ContentType("application/json"));
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task OneBinaryBodyTwoContentTypes_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            MultipleMediaTypesClient client = CreateMultipleMediaTypesClient(endpoint);

            RequestContent content = RequestContent.Create(new object());
            Response response = await client.OneBinaryBodyTwoContentTypesAsync(content, new ContentType("application/json"));
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task OneBinaryBodyTwoContentTypes_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            MultipleMediaTypesClient client = CreateMultipleMediaTypesClient(endpoint);

            Response response = await client.OneBinaryBodyTwoContentTypesAsync(BinaryData.FromObjectAsJson(new object()), new ContentType("application/json"));
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task OneStringBodyThreeContentTypes_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            MultipleMediaTypesClient client = CreateMultipleMediaTypesClient(endpoint);

            RequestContent content = RequestContent.Create("<body>");
            Response response = await client.OneStringBodyThreeContentTypesAsync(content, new ContentType("application/json"));
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task OneStringBodyThreeContentTypes_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            MultipleMediaTypesClient client = CreateMultipleMediaTypesClient(endpoint);

            Response response = await client.OneStringBodyThreeContentTypesAsync("<body>", new ContentType("application/json"));
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task OneStringBodyThreeContentTypes_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            MultipleMediaTypesClient client = CreateMultipleMediaTypesClient(endpoint);

            RequestContent content = RequestContent.Create("<body>");
            Response response = await client.OneStringBodyThreeContentTypesAsync(content, new ContentType("application/json"));
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task OneStringBodyThreeContentTypes_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            MultipleMediaTypesClient client = CreateMultipleMediaTypesClient(endpoint);

            Response response = await client.OneStringBodyThreeContentTypesAsync("<body>", new ContentType("application/json"));
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task OneModelBodyOneContentType_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            MultipleMediaTypesClient client = CreateMultipleMediaTypesClient(endpoint);

            RequestContent content = RequestContent.Create(new
            {
                id = "<id>",
            });
            Response response = await client.OneModelBodyOneContentTypeAsync(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task OneModelBodyOneContentType_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            MultipleMediaTypesClient client = CreateMultipleMediaTypesClient(endpoint);

            Body body = new Body("<id>");
            Response response = await client.OneModelBodyOneContentTypeAsync(body);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task OneModelBodyOneContentType_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            MultipleMediaTypesClient client = CreateMultipleMediaTypesClient(endpoint);

            RequestContent content = RequestContent.Create(new
            {
                id = "<id>",
            });
            Response response = await client.OneModelBodyOneContentTypeAsync(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task OneModelBodyOneContentType_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            MultipleMediaTypesClient client = CreateMultipleMediaTypesClient(endpoint);

            Body body = new Body("<id>");
            Response response = await client.OneModelBodyOneContentTypeAsync(body);
        }
    }
}
