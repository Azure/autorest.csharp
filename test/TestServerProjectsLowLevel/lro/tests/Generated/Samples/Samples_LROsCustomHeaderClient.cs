// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;

namespace lro_LowLevel.Samples
{
    public class Samples_LROsCustomHeaderClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutAsyncRetrySucceeded()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsCustomHeaderClient(credential);

            var data = new { };

            var operation = client.PutAsyncRetrySucceeded(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutAsyncRetrySucceeded_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsCustomHeaderClient(credential);

            var data = new
            {
                properties = new
                {
                    provisioningState = "<provisioningState>",
                },
                tags = new
                {
                    key = "<String>",
                },
                location = "<location>",
            };

            var operation = client.PutAsyncRetrySucceeded(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.GetProperty("properties").GetProperty("provisioningState").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("provisioningStateValues").ToString());
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("type").ToString());
            Console.WriteLine(result.GetProperty("tags").GetProperty("<test>").ToString());
            Console.WriteLine(result.GetProperty("location").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutAsyncRetrySucceeded_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsCustomHeaderClient(credential);

            var data = new { };

            var operation = await client.PutAsyncRetrySucceededAsync(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutAsyncRetrySucceeded_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsCustomHeaderClient(credential);

            var data = new
            {
                properties = new
                {
                    provisioningState = "<provisioningState>",
                },
                tags = new
                {
                    key = "<String>",
                },
                location = "<location>",
            };

            var operation = await client.PutAsyncRetrySucceededAsync(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.GetProperty("properties").GetProperty("provisioningState").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("provisioningStateValues").ToString());
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("type").ToString());
            Console.WriteLine(result.GetProperty("tags").GetProperty("<test>").ToString());
            Console.WriteLine(result.GetProperty("location").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put201CreatingSucceeded200()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsCustomHeaderClient(credential);

            var data = new { };

            var operation = client.Put201CreatingSucceeded200(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put201CreatingSucceeded200_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsCustomHeaderClient(credential);

            var data = new
            {
                properties = new
                {
                    provisioningState = "<provisioningState>",
                },
                tags = new
                {
                    key = "<String>",
                },
                location = "<location>",
            };

            var operation = client.Put201CreatingSucceeded200(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.GetProperty("properties").GetProperty("provisioningState").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("provisioningStateValues").ToString());
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("type").ToString());
            Console.WriteLine(result.GetProperty("tags").GetProperty("<test>").ToString());
            Console.WriteLine(result.GetProperty("location").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put201CreatingSucceeded200_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsCustomHeaderClient(credential);

            var data = new { };

            var operation = await client.Put201CreatingSucceeded200Async(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put201CreatingSucceeded200_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsCustomHeaderClient(credential);

            var data = new
            {
                properties = new
                {
                    provisioningState = "<provisioningState>",
                },
                tags = new
                {
                    key = "<String>",
                },
                location = "<location>",
            };

            var operation = await client.Put201CreatingSucceeded200Async(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.GetProperty("properties").GetProperty("provisioningState").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("provisioningStateValues").ToString());
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("type").ToString());
            Console.WriteLine(result.GetProperty("tags").GetProperty("<test>").ToString());
            Console.WriteLine(result.GetProperty("location").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Post202Retry200()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsCustomHeaderClient(credential);

            var data = new { };

            var operation = client.Post202Retry200(WaitUntil.Completed, RequestContent.Create(data));

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Post202Retry200_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsCustomHeaderClient(credential);

            var data = new
            {
                properties = new
                {
                    provisioningState = "<provisioningState>",
                },
                tags = new
                {
                    key = "<String>",
                },
                location = "<location>",
            };

            var operation = client.Post202Retry200(WaitUntil.Completed, RequestContent.Create(data));

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Post202Retry200_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsCustomHeaderClient(credential);

            var data = new { };

            var operation = await client.Post202Retry200Async(WaitUntil.Completed, RequestContent.Create(data));

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Post202Retry200_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsCustomHeaderClient(credential);

            var data = new
            {
                properties = new
                {
                    provisioningState = "<provisioningState>",
                },
                tags = new
                {
                    key = "<String>",
                },
                location = "<location>",
            };

            var operation = await client.Post202Retry200Async(WaitUntil.Completed, RequestContent.Create(data));

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PostAsyncRetrySucceeded()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsCustomHeaderClient(credential);

            var data = new { };

            var operation = client.PostAsyncRetrySucceeded(WaitUntil.Completed, RequestContent.Create(data));

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PostAsyncRetrySucceeded_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsCustomHeaderClient(credential);

            var data = new
            {
                properties = new
                {
                    provisioningState = "<provisioningState>",
                },
                tags = new
                {
                    key = "<String>",
                },
                location = "<location>",
            };

            var operation = client.PostAsyncRetrySucceeded(WaitUntil.Completed, RequestContent.Create(data));

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PostAsyncRetrySucceeded_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsCustomHeaderClient(credential);

            var data = new { };

            var operation = await client.PostAsyncRetrySucceededAsync(WaitUntil.Completed, RequestContent.Create(data));

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PostAsyncRetrySucceeded_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsCustomHeaderClient(credential);

            var data = new
            {
                properties = new
                {
                    provisioningState = "<provisioningState>",
                },
                tags = new
                {
                    key = "<String>",
                },
                location = "<location>",
            };

            var operation = await client.PostAsyncRetrySucceededAsync(WaitUntil.Completed, RequestContent.Create(data));

            Console.WriteLine(operation.GetRawResponse().Status);
        }
    }
}
