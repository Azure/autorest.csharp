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
    public partial class LROsCustomHeaderClientTests : lro_LowLevelTestBase
    {
        public LROsCustomHeaderClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task PutAsyncRetrySucceeded_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            LROsCustomHeaderClient client = CreateLROsCustomHeaderClient(endpoint, credential);

            using RequestContent content = null;
            Operation<BinaryData> operation = await client.PutAsyncRetrySucceededAsync(WaitUntil.Completed, content);
            BinaryData responseData = operation.Value;
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task PutAsyncRetrySucceeded_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            LROsCustomHeaderClient client = CreateLROsCustomHeaderClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new
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
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Put201CreatingSucceeded200_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            LROsCustomHeaderClient client = CreateLROsCustomHeaderClient(endpoint, credential);

            using RequestContent content = null;
            Operation<BinaryData> operation = await client.Put201CreatingSucceeded200Async(WaitUntil.Completed, content);
            BinaryData responseData = operation.Value;
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Put201CreatingSucceeded200_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            LROsCustomHeaderClient client = CreateLROsCustomHeaderClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new
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
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Post202Retry200_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            LROsCustomHeaderClient client = CreateLROsCustomHeaderClient(endpoint, credential);

            using RequestContent content = null;
            Operation operation = await client.Post202Retry200Async(WaitUntil.Completed, content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Post202Retry200_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            LROsCustomHeaderClient client = CreateLROsCustomHeaderClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new
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
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task PostAsyncRetrySucceeded_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            LROsCustomHeaderClient client = CreateLROsCustomHeaderClient(endpoint, credential);

            using RequestContent content = null;
            Operation operation = await client.PostAsyncRetrySucceededAsync(WaitUntil.Completed, content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task PostAsyncRetrySucceeded_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            LROsCustomHeaderClient client = CreateLROsCustomHeaderClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new
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
