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
using lro_LowLevel;

namespace lro_LowLevel.Samples
{
    public class Samples_LROsCustomHeaderClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutAsyncRetrySucceeded()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            LROsCustomHeaderClient client = new LROsCustomHeaderClient(credential);

            RequestContent content = null;
            Operation<BinaryData> operation = client.PutAsyncRetrySucceeded(WaitUntil.Completed, content);
            BinaryData responseData = operation.Value;

            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutAsyncRetrySucceeded_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            LROsCustomHeaderClient client = new LROsCustomHeaderClient(credential);

            RequestContent content = RequestContent.Create(new Dictionary<string, object>()
            {
                ["properties"] = new Dictionary<string, object>()
                {
                    ["provisioningState"] = "<provisioningState>",
                },
                ["tags"] = new Dictionary<string, object>()
                {
                    ["key"] = "<tags>",
                },
                ["location"] = "<location>",
            });
            Operation<BinaryData> operation = client.PutAsyncRetrySucceeded(WaitUntil.Completed, content);
            BinaryData responseData = operation.Value;

            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.GetProperty("properties").GetProperty("provisioningState").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("provisioningStateValues").ToString());
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("type").ToString());
            Console.WriteLine(result.GetProperty("tags").GetProperty("<key>").ToString());
            Console.WriteLine(result.GetProperty("location").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutAsyncRetrySucceeded_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            LROsCustomHeaderClient client = new LROsCustomHeaderClient(credential);

            RequestContent content = null;
            Operation<BinaryData> operation = await client.PutAsyncRetrySucceededAsync(WaitUntil.Completed, content);
            BinaryData responseData = operation.Value;

            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutAsyncRetrySucceeded_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            LROsCustomHeaderClient client = new LROsCustomHeaderClient(credential);

            RequestContent content = RequestContent.Create(new Dictionary<string, object>()
            {
                ["properties"] = new Dictionary<string, object>()
                {
                    ["provisioningState"] = "<provisioningState>",
                },
                ["tags"] = new Dictionary<string, object>()
                {
                    ["key"] = "<tags>",
                },
                ["location"] = "<location>",
            });
            Operation<BinaryData> operation = await client.PutAsyncRetrySucceededAsync(WaitUntil.Completed, content);
            BinaryData responseData = operation.Value;

            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.GetProperty("properties").GetProperty("provisioningState").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("provisioningStateValues").ToString());
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("type").ToString());
            Console.WriteLine(result.GetProperty("tags").GetProperty("<key>").ToString());
            Console.WriteLine(result.GetProperty("location").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put201CreatingSucceeded200()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            LROsCustomHeaderClient client = new LROsCustomHeaderClient(credential);

            RequestContent content = null;
            Operation<BinaryData> operation = client.Put201CreatingSucceeded200(WaitUntil.Completed, content);
            BinaryData responseData = operation.Value;

            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put201CreatingSucceeded200_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            LROsCustomHeaderClient client = new LROsCustomHeaderClient(credential);

            RequestContent content = RequestContent.Create(new Dictionary<string, object>()
            {
                ["properties"] = new Dictionary<string, object>()
                {
                    ["provisioningState"] = "<provisioningState>",
                },
                ["tags"] = new Dictionary<string, object>()
                {
                    ["key"] = "<tags>",
                },
                ["location"] = "<location>",
            });
            Operation<BinaryData> operation = client.Put201CreatingSucceeded200(WaitUntil.Completed, content);
            BinaryData responseData = operation.Value;

            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.GetProperty("properties").GetProperty("provisioningState").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("provisioningStateValues").ToString());
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("type").ToString());
            Console.WriteLine(result.GetProperty("tags").GetProperty("<key>").ToString());
            Console.WriteLine(result.GetProperty("location").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put201CreatingSucceeded200_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            LROsCustomHeaderClient client = new LROsCustomHeaderClient(credential);

            RequestContent content = null;
            Operation<BinaryData> operation = await client.Put201CreatingSucceeded200Async(WaitUntil.Completed, content);
            BinaryData responseData = operation.Value;

            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put201CreatingSucceeded200_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            LROsCustomHeaderClient client = new LROsCustomHeaderClient(credential);

            RequestContent content = RequestContent.Create(new Dictionary<string, object>()
            {
                ["properties"] = new Dictionary<string, object>()
                {
                    ["provisioningState"] = "<provisioningState>",
                },
                ["tags"] = new Dictionary<string, object>()
                {
                    ["key"] = "<tags>",
                },
                ["location"] = "<location>",
            });
            Operation<BinaryData> operation = await client.Put201CreatingSucceeded200Async(WaitUntil.Completed, content);
            BinaryData responseData = operation.Value;

            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.GetProperty("properties").GetProperty("provisioningState").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("provisioningStateValues").ToString());
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("type").ToString());
            Console.WriteLine(result.GetProperty("tags").GetProperty("<key>").ToString());
            Console.WriteLine(result.GetProperty("location").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Post202Retry200()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            LROsCustomHeaderClient client = new LROsCustomHeaderClient(credential);

            RequestContent content = null;
            Operation operation = client.Post202Retry200(WaitUntil.Completed, content);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Post202Retry200_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            LROsCustomHeaderClient client = new LROsCustomHeaderClient(credential);

            RequestContent content = RequestContent.Create(new Dictionary<string, object>()
            {
                ["properties"] = new Dictionary<string, object>()
                {
                    ["provisioningState"] = "<provisioningState>",
                },
                ["tags"] = new Dictionary<string, object>()
                {
                    ["key"] = "<tags>",
                },
                ["location"] = "<location>",
            });
            Operation operation = client.Post202Retry200(WaitUntil.Completed, content);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Post202Retry200_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            LROsCustomHeaderClient client = new LROsCustomHeaderClient(credential);

            RequestContent content = null;
            Operation operation = await client.Post202Retry200Async(WaitUntil.Completed, content);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Post202Retry200_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            LROsCustomHeaderClient client = new LROsCustomHeaderClient(credential);

            RequestContent content = RequestContent.Create(new Dictionary<string, object>()
            {
                ["properties"] = new Dictionary<string, object>()
                {
                    ["provisioningState"] = "<provisioningState>",
                },
                ["tags"] = new Dictionary<string, object>()
                {
                    ["key"] = "<tags>",
                },
                ["location"] = "<location>",
            });
            Operation operation = await client.Post202Retry200Async(WaitUntil.Completed, content);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PostAsyncRetrySucceeded()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            LROsCustomHeaderClient client = new LROsCustomHeaderClient(credential);

            RequestContent content = null;
            Operation operation = client.PostAsyncRetrySucceeded(WaitUntil.Completed, content);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PostAsyncRetrySucceeded_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            LROsCustomHeaderClient client = new LROsCustomHeaderClient(credential);

            RequestContent content = RequestContent.Create(new Dictionary<string, object>()
            {
                ["properties"] = new Dictionary<string, object>()
                {
                    ["provisioningState"] = "<provisioningState>",
                },
                ["tags"] = new Dictionary<string, object>()
                {
                    ["key"] = "<tags>",
                },
                ["location"] = "<location>",
            });
            Operation operation = client.PostAsyncRetrySucceeded(WaitUntil.Completed, content);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PostAsyncRetrySucceeded_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            LROsCustomHeaderClient client = new LROsCustomHeaderClient(credential);

            RequestContent content = null;
            Operation operation = await client.PostAsyncRetrySucceededAsync(WaitUntil.Completed, content);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PostAsyncRetrySucceeded_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            LROsCustomHeaderClient client = new LROsCustomHeaderClient(credential);

            RequestContent content = RequestContent.Create(new Dictionary<string, object>()
            {
                ["properties"] = new Dictionary<string, object>()
                {
                    ["provisioningState"] = "<provisioningState>",
                },
                ["tags"] = new Dictionary<string, object>()
                {
                    ["key"] = "<tags>",
                },
                ["location"] = "<location>",
            });
            Operation operation = await client.PostAsyncRetrySucceededAsync(WaitUntil.Completed, content);
        }
    }
}
