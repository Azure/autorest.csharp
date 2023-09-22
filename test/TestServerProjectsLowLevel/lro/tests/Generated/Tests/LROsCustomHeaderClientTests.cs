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
using lro_LowLevel;

namespace lro_LowLevel.Tests
{
    public class LROsCustomHeaderClientTests : lro_LowLevelTestBase
    {
        public LROsCustomHeaderClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task PutAsyncRetrySucceeded_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            LROsCustomHeaderClient client = CreateLROsCustomHeaderClient(credential, endpoint);

            RequestContent content = null;
            Operation<BinaryData> operation = await client.PutAsyncRetrySucceededAsync(WaitUntil.Completed, content);
            BinaryData responseData = operation.Value;
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task PutAsyncRetrySucceeded_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            LROsCustomHeaderClient client = CreateLROsCustomHeaderClient(credential, endpoint);

            RequestContent content = RequestContent.Create(new
            {
                properties = new
                {
                    provisioningState = "<provisioningState>",
                },
                tags = new
                {
                    key = "<tags>",
                },
                location = "<location>",
            });
            Operation<BinaryData> operation = await client.PutAsyncRetrySucceededAsync(WaitUntil.Completed, content);
            BinaryData responseData = operation.Value;
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Put201CreatingSucceeded200_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            LROsCustomHeaderClient client = CreateLROsCustomHeaderClient(credential, endpoint);

            RequestContent content = null;
            Operation<BinaryData> operation = await client.Put201CreatingSucceeded200Async(WaitUntil.Completed, content);
            BinaryData responseData = operation.Value;
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Put201CreatingSucceeded200_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            LROsCustomHeaderClient client = CreateLROsCustomHeaderClient(credential, endpoint);

            RequestContent content = RequestContent.Create(new
            {
                properties = new
                {
                    provisioningState = "<provisioningState>",
                },
                tags = new
                {
                    key = "<tags>",
                },
                location = "<location>",
            });
            Operation<BinaryData> operation = await client.Put201CreatingSucceeded200Async(WaitUntil.Completed, content);
            BinaryData responseData = operation.Value;
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Post202Retry200_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            LROsCustomHeaderClient client = CreateLROsCustomHeaderClient(credential, endpoint);

            RequestContent content = null;
            Operation operation = await client.Post202Retry200Async(WaitUntil.Completed, content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Post202Retry200_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            LROsCustomHeaderClient client = CreateLROsCustomHeaderClient(credential, endpoint);

            RequestContent content = RequestContent.Create(new
            {
                properties = new
                {
                    provisioningState = "<provisioningState>",
                },
                tags = new
                {
                    key = "<tags>",
                },
                location = "<location>",
            });
            Operation operation = await client.Post202Retry200Async(WaitUntil.Completed, content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task PostAsyncRetrySucceeded_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            LROsCustomHeaderClient client = CreateLROsCustomHeaderClient(credential, endpoint);

            RequestContent content = null;
            Operation operation = await client.PostAsyncRetrySucceededAsync(WaitUntil.Completed, content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task PostAsyncRetrySucceeded_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            LROsCustomHeaderClient client = CreateLROsCustomHeaderClient(credential, endpoint);

            RequestContent content = RequestContent.Create(new
            {
                properties = new
                {
                    provisioningState = "<provisioningState>",
                },
                tags = new
                {
                    key = "<tags>",
                },
                location = "<location>",
            });
            Operation operation = await client.PostAsyncRetrySucceededAsync(WaitUntil.Completed, content);
        }
    }
}
