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
using Parameters.BodyOptionality;
using Parameters.BodyOptionality.Models;

namespace Parameters.BodyOptionality.Tests
{
    public class BodyOptionalityClientTests : ParametersBodyOptionalityTestBase
    {
        public BodyOptionalityClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task RequiredExplicit_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            BodyOptionalityClient client = CreateBodyOptionalityClient(endpoint);

            RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
            });
            Response response = await client.RequiredExplicitAsync(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task RequiredExplicit_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            BodyOptionalityClient client = CreateBodyOptionalityClient(endpoint);

            BodyModel body = new BodyModel("<name>");
            Response response = await client.RequiredExplicitAsync(body);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task RequiredExplicit_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            BodyOptionalityClient client = CreateBodyOptionalityClient(endpoint);

            RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
            });
            Response response = await client.RequiredExplicitAsync(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task RequiredExplicit_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            BodyOptionalityClient client = CreateBodyOptionalityClient(endpoint);

            BodyModel body = new BodyModel("<name>");
            Response response = await client.RequiredExplicitAsync(body);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task RequiredImplicit_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            BodyOptionalityClient client = CreateBodyOptionalityClient(endpoint);

            RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
            });
            Response response = await client.RequiredImplicitAsync(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task RequiredImplicit_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            BodyOptionalityClient client = CreateBodyOptionalityClient(endpoint);

            BodyModel bodyModel = new BodyModel("<name>");
            Response response = await client.RequiredImplicitAsync(bodyModel);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task RequiredImplicit_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            BodyOptionalityClient client = CreateBodyOptionalityClient(endpoint);

            RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
            });
            Response response = await client.RequiredImplicitAsync(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task RequiredImplicit_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            BodyOptionalityClient client = CreateBodyOptionalityClient(endpoint);

            BodyModel bodyModel = new BodyModel("<name>");
            Response response = await client.RequiredImplicitAsync(bodyModel);
        }
    }
}
