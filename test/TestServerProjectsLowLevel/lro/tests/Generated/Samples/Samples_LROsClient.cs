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
    public class Samples_LROsClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put200Succeeded()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new { };

            var operation = client.Put200Succeeded(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put200Succeeded_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

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

            var operation = client.Put200Succeeded(WaitUntil.Completed, RequestContent.Create(data));

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
        public async Task Example_Put200Succeeded_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new { };

            var operation = await client.Put200SucceededAsync(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put200Succeeded_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

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

            var operation = await client.Put200SucceededAsync(WaitUntil.Completed, RequestContent.Create(data));

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
        public void Example_Patch200SucceededIgnoreHeaders()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new { };

            var operation = client.Patch200SucceededIgnoreHeaders(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Patch200SucceededIgnoreHeaders_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

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

            var operation = client.Patch200SucceededIgnoreHeaders(WaitUntil.Completed, RequestContent.Create(data));

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
        public async Task Example_Patch200SucceededIgnoreHeaders_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new { };

            var operation = await client.Patch200SucceededIgnoreHeadersAsync(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Patch200SucceededIgnoreHeaders_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

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

            var operation = await client.Patch200SucceededIgnoreHeadersAsync(WaitUntil.Completed, RequestContent.Create(data));

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
        public void Example_Patch201RetryWithAsyncHeader()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new { };

            var operation = client.Patch201RetryWithAsyncHeader(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Patch201RetryWithAsyncHeader_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

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

            var operation = client.Patch201RetryWithAsyncHeader(WaitUntil.Completed, RequestContent.Create(data));

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
        public async Task Example_Patch201RetryWithAsyncHeader_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new { };

            var operation = await client.Patch201RetryWithAsyncHeaderAsync(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Patch201RetryWithAsyncHeader_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

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

            var operation = await client.Patch201RetryWithAsyncHeaderAsync(WaitUntil.Completed, RequestContent.Create(data));

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
        public void Example_Patch202RetryWithAsyncAndLocationHeader()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new { };

            var operation = client.Patch202RetryWithAsyncAndLocationHeader(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Patch202RetryWithAsyncAndLocationHeader_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

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

            var operation = client.Patch202RetryWithAsyncAndLocationHeader(WaitUntil.Completed, RequestContent.Create(data));

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
        public async Task Example_Patch202RetryWithAsyncAndLocationHeader_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new { };

            var operation = await client.Patch202RetryWithAsyncAndLocationHeaderAsync(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Patch202RetryWithAsyncAndLocationHeader_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

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

            var operation = await client.Patch202RetryWithAsyncAndLocationHeaderAsync(WaitUntil.Completed, RequestContent.Create(data));

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
        public void Example_Put201Succeeded()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new { };

            var operation = client.Put201Succeeded(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put201Succeeded_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

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

            var operation = client.Put201Succeeded(WaitUntil.Completed, RequestContent.Create(data));

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
        public async Task Example_Put201Succeeded_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new { };

            var operation = await client.Put201SucceededAsync(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put201Succeeded_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

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

            var operation = await client.Put201SucceededAsync(WaitUntil.Completed, RequestContent.Create(data));

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
        public void Example_Post202List()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = client.Post202List(WaitUntil.Completed);

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Post202List_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = client.Post202List(WaitUntil.Completed);

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result[0].GetProperty("properties").GetProperty("provisioningState").ToString());
            Console.WriteLine(result[0].GetProperty("properties").GetProperty("provisioningStateValues").ToString());
            Console.WriteLine(result[0].GetProperty("id").ToString());
            Console.WriteLine(result[0].GetProperty("type").ToString());
            Console.WriteLine(result[0].GetProperty("tags").GetProperty("<test>").ToString());
            Console.WriteLine(result[0].GetProperty("location").ToString());
            Console.WriteLine(result[0].GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Post202List_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = await client.Post202ListAsync(WaitUntil.Completed);

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Post202List_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = await client.Post202ListAsync(WaitUntil.Completed);

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result[0].GetProperty("properties").GetProperty("provisioningState").ToString());
            Console.WriteLine(result[0].GetProperty("properties").GetProperty("provisioningStateValues").ToString());
            Console.WriteLine(result[0].GetProperty("id").ToString());
            Console.WriteLine(result[0].GetProperty("type").ToString());
            Console.WriteLine(result[0].GetProperty("tags").GetProperty("<test>").ToString());
            Console.WriteLine(result[0].GetProperty("location").ToString());
            Console.WriteLine(result[0].GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put200SucceededNoState()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new { };

            var operation = client.Put200SucceededNoState(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put200SucceededNoState_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

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

            var operation = client.Put200SucceededNoState(WaitUntil.Completed, RequestContent.Create(data));

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
        public async Task Example_Put200SucceededNoState_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new { };

            var operation = await client.Put200SucceededNoStateAsync(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put200SucceededNoState_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

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

            var operation = await client.Put200SucceededNoStateAsync(WaitUntil.Completed, RequestContent.Create(data));

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
        public void Example_Put202Retry200()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new { };

            var operation = client.Put202Retry200(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put202Retry200_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

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

            var operation = client.Put202Retry200(WaitUntil.Completed, RequestContent.Create(data));

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
        public async Task Example_Put202Retry200_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new { };

            var operation = await client.Put202Retry200Async(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put202Retry200_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

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

            var operation = await client.Put202Retry200Async(WaitUntil.Completed, RequestContent.Create(data));

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
            var client = new LROsClient(credential);

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
            var client = new LROsClient(credential);

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
            var client = new LROsClient(credential);

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
            var client = new LROsClient(credential);

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
        public void Example_Put200UpdatingSucceeded204()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new { };

            var operation = client.Put200UpdatingSucceeded204(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put200UpdatingSucceeded204_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

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

            var operation = client.Put200UpdatingSucceeded204(WaitUntil.Completed, RequestContent.Create(data));

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
        public async Task Example_Put200UpdatingSucceeded204_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new { };

            var operation = await client.Put200UpdatingSucceeded204Async(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put200UpdatingSucceeded204_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

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

            var operation = await client.Put200UpdatingSucceeded204Async(WaitUntil.Completed, RequestContent.Create(data));

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
        public void Example_Put201CreatingFailed200()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new { };

            var operation = client.Put201CreatingFailed200(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put201CreatingFailed200_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

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

            var operation = client.Put201CreatingFailed200(WaitUntil.Completed, RequestContent.Create(data));

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
        public async Task Example_Put201CreatingFailed200_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new { };

            var operation = await client.Put201CreatingFailed200Async(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put201CreatingFailed200_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

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

            var operation = await client.Put201CreatingFailed200Async(WaitUntil.Completed, RequestContent.Create(data));

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
        public void Example_Put200Acceptedcanceled200()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new { };

            var operation = client.Put200Acceptedcanceled200(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put200Acceptedcanceled200_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

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

            var operation = client.Put200Acceptedcanceled200(WaitUntil.Completed, RequestContent.Create(data));

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
        public async Task Example_Put200Acceptedcanceled200_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new { };

            var operation = await client.Put200Acceptedcanceled200Async(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put200Acceptedcanceled200_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

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

            var operation = await client.Put200Acceptedcanceled200Async(WaitUntil.Completed, RequestContent.Create(data));

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
        public void Example_PutNoHeaderInRetry()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new { };

            var operation = client.PutNoHeaderInRetry(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutNoHeaderInRetry_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

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

            var operation = client.PutNoHeaderInRetry(WaitUntil.Completed, RequestContent.Create(data));

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
        public async Task Example_PutNoHeaderInRetry_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new { };

            var operation = await client.PutNoHeaderInRetryAsync(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutNoHeaderInRetry_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

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

            var operation = await client.PutNoHeaderInRetryAsync(WaitUntil.Completed, RequestContent.Create(data));

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
        public void Example_PutAsyncRetrySucceeded()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

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
            var client = new LROsClient(credential);

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
            var client = new LROsClient(credential);

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
            var client = new LROsClient(credential);

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
        public void Example_PutAsyncNoRetrySucceeded()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new { };

            var operation = client.PutAsyncNoRetrySucceeded(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutAsyncNoRetrySucceeded_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

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

            var operation = client.PutAsyncNoRetrySucceeded(WaitUntil.Completed, RequestContent.Create(data));

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
        public async Task Example_PutAsyncNoRetrySucceeded_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new { };

            var operation = await client.PutAsyncNoRetrySucceededAsync(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutAsyncNoRetrySucceeded_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

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

            var operation = await client.PutAsyncNoRetrySucceededAsync(WaitUntil.Completed, RequestContent.Create(data));

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
        public void Example_PutAsyncRetryFailed()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new { };

            var operation = client.PutAsyncRetryFailed(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutAsyncRetryFailed_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

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

            var operation = client.PutAsyncRetryFailed(WaitUntil.Completed, RequestContent.Create(data));

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
        public async Task Example_PutAsyncRetryFailed_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new { };

            var operation = await client.PutAsyncRetryFailedAsync(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutAsyncRetryFailed_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

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

            var operation = await client.PutAsyncRetryFailedAsync(WaitUntil.Completed, RequestContent.Create(data));

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
        public void Example_PutAsyncNoRetrycanceled()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new { };

            var operation = client.PutAsyncNoRetrycanceled(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutAsyncNoRetrycanceled_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

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

            var operation = client.PutAsyncNoRetrycanceled(WaitUntil.Completed, RequestContent.Create(data));

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
        public async Task Example_PutAsyncNoRetrycanceled_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new { };

            var operation = await client.PutAsyncNoRetrycanceledAsync(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutAsyncNoRetrycanceled_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

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

            var operation = await client.PutAsyncNoRetrycanceledAsync(WaitUntil.Completed, RequestContent.Create(data));

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
        public void Example_PutAsyncNoHeaderInRetry()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new { };

            var operation = client.PutAsyncNoHeaderInRetry(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutAsyncNoHeaderInRetry_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

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

            var operation = client.PutAsyncNoHeaderInRetry(WaitUntil.Completed, RequestContent.Create(data));

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
        public async Task Example_PutAsyncNoHeaderInRetry_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new { };

            var operation = await client.PutAsyncNoHeaderInRetryAsync(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutAsyncNoHeaderInRetry_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

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

            var operation = await client.PutAsyncNoHeaderInRetryAsync(WaitUntil.Completed, RequestContent.Create(data));

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
        public void Example_PutNonResource()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new { };

            var operation = client.PutNonResource(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutNonResource_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new
            {
                name = "<name>",
                id = "<id>",
            };

            var operation = client.PutNonResource(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutNonResource_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new { };

            var operation = await client.PutNonResourceAsync(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutNonResource_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new
            {
                name = "<name>",
                id = "<id>",
            };

            var operation = await client.PutNonResourceAsync(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutAsyncNonResource()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new { };

            var operation = client.PutAsyncNonResource(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutAsyncNonResource_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new
            {
                name = "<name>",
                id = "<id>",
            };

            var operation = client.PutAsyncNonResource(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutAsyncNonResource_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new { };

            var operation = await client.PutAsyncNonResourceAsync(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutAsyncNonResource_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new
            {
                name = "<name>",
                id = "<id>",
            };

            var operation = await client.PutAsyncNonResourceAsync(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutSubResource()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new { };

            var operation = client.PutSubResource(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutSubResource_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new
            {
                properties = new
                {
                    provisioningState = "<provisioningState>",
                },
            };

            var operation = client.PutSubResource(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.GetProperty("properties").GetProperty("provisioningState").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("provisioningStateValues").ToString());
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutSubResource_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new { };

            var operation = await client.PutSubResourceAsync(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutSubResource_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new
            {
                properties = new
                {
                    provisioningState = "<provisioningState>",
                },
            };

            var operation = await client.PutSubResourceAsync(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.GetProperty("properties").GetProperty("provisioningState").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("provisioningStateValues").ToString());
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutAsyncSubResource()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new { };

            var operation = client.PutAsyncSubResource(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutAsyncSubResource_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new
            {
                properties = new
                {
                    provisioningState = "<provisioningState>",
                },
            };

            var operation = client.PutAsyncSubResource(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.GetProperty("properties").GetProperty("provisioningState").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("provisioningStateValues").ToString());
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutAsyncSubResource_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new { };

            var operation = await client.PutAsyncSubResourceAsync(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutAsyncSubResource_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new
            {
                properties = new
                {
                    provisioningState = "<provisioningState>",
                },
            };

            var operation = await client.PutAsyncSubResourceAsync(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.GetProperty("properties").GetProperty("provisioningState").ToString());
            Console.WriteLine(result.GetProperty("properties").GetProperty("provisioningStateValues").ToString());
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DeleteProvisioning202Accepted200Succeeded()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = client.DeleteProvisioning202Accepted200Succeeded(WaitUntil.Completed);

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DeleteProvisioning202Accepted200Succeeded_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = client.DeleteProvisioning202Accepted200Succeeded(WaitUntil.Completed);

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
        public async Task Example_DeleteProvisioning202Accepted200Succeeded_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = await client.DeleteProvisioning202Accepted200SucceededAsync(WaitUntil.Completed);

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DeleteProvisioning202Accepted200Succeeded_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = await client.DeleteProvisioning202Accepted200SucceededAsync(WaitUntil.Completed);

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
        public void Example_DeleteProvisioning202DeletingFailed200()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = client.DeleteProvisioning202DeletingFailed200(WaitUntil.Completed);

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DeleteProvisioning202DeletingFailed200_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = client.DeleteProvisioning202DeletingFailed200(WaitUntil.Completed);

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
        public async Task Example_DeleteProvisioning202DeletingFailed200_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = await client.DeleteProvisioning202DeletingFailed200Async(WaitUntil.Completed);

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DeleteProvisioning202DeletingFailed200_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = await client.DeleteProvisioning202DeletingFailed200Async(WaitUntil.Completed);

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
        public void Example_DeleteProvisioning202Deletingcanceled200()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = client.DeleteProvisioning202Deletingcanceled200(WaitUntil.Completed);

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DeleteProvisioning202Deletingcanceled200_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = client.DeleteProvisioning202Deletingcanceled200(WaitUntil.Completed);

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
        public async Task Example_DeleteProvisioning202Deletingcanceled200_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = await client.DeleteProvisioning202Deletingcanceled200Async(WaitUntil.Completed);

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DeleteProvisioning202Deletingcanceled200_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = await client.DeleteProvisioning202Deletingcanceled200Async(WaitUntil.Completed);

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
        public void Example_Delete204Succeeded()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = client.Delete204Succeeded(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Delete204Succeeded_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = client.Delete204Succeeded(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Delete204Succeeded_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = await client.Delete204SucceededAsync(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Delete204Succeeded_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = await client.Delete204SucceededAsync(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Delete202Retry200()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = client.Delete202Retry200(WaitUntil.Completed);

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Delete202Retry200_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = client.Delete202Retry200(WaitUntil.Completed);

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
        public async Task Example_Delete202Retry200_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = await client.Delete202Retry200Async(WaitUntil.Completed);

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Delete202Retry200_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = await client.Delete202Retry200Async(WaitUntil.Completed);

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
        public void Example_Delete202NoRetry204()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = client.Delete202NoRetry204(WaitUntil.Completed);

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Delete202NoRetry204_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = client.Delete202NoRetry204(WaitUntil.Completed);

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
        public async Task Example_Delete202NoRetry204_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = await client.Delete202NoRetry204Async(WaitUntil.Completed);

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Delete202NoRetry204_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = await client.Delete202NoRetry204Async(WaitUntil.Completed);

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
        public void Example_DeleteNoHeaderInRetry()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = client.DeleteNoHeaderInRetry(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DeleteNoHeaderInRetry_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = client.DeleteNoHeaderInRetry(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DeleteNoHeaderInRetry_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = await client.DeleteNoHeaderInRetryAsync(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DeleteNoHeaderInRetry_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = await client.DeleteNoHeaderInRetryAsync(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DeleteAsyncNoHeaderInRetry()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = client.DeleteAsyncNoHeaderInRetry(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DeleteAsyncNoHeaderInRetry_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = client.DeleteAsyncNoHeaderInRetry(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DeleteAsyncNoHeaderInRetry_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = await client.DeleteAsyncNoHeaderInRetryAsync(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DeleteAsyncNoHeaderInRetry_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = await client.DeleteAsyncNoHeaderInRetryAsync(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DeleteAsyncRetrySucceeded()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = client.DeleteAsyncRetrySucceeded(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DeleteAsyncRetrySucceeded_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = client.DeleteAsyncRetrySucceeded(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DeleteAsyncRetrySucceeded_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = await client.DeleteAsyncRetrySucceededAsync(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DeleteAsyncRetrySucceeded_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = await client.DeleteAsyncRetrySucceededAsync(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DeleteAsyncNoRetrySucceeded()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = client.DeleteAsyncNoRetrySucceeded(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DeleteAsyncNoRetrySucceeded_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = client.DeleteAsyncNoRetrySucceeded(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DeleteAsyncNoRetrySucceeded_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = await client.DeleteAsyncNoRetrySucceededAsync(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DeleteAsyncNoRetrySucceeded_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = await client.DeleteAsyncNoRetrySucceededAsync(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DeleteAsyncRetryFailed()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = client.DeleteAsyncRetryFailed(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DeleteAsyncRetryFailed_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = client.DeleteAsyncRetryFailed(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DeleteAsyncRetryFailed_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = await client.DeleteAsyncRetryFailedAsync(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DeleteAsyncRetryFailed_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = await client.DeleteAsyncRetryFailedAsync(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DeleteAsyncRetrycanceled()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = client.DeleteAsyncRetrycanceled(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DeleteAsyncRetrycanceled_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = client.DeleteAsyncRetrycanceled(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DeleteAsyncRetrycanceled_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = await client.DeleteAsyncRetrycanceledAsync(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DeleteAsyncRetrycanceled_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = await client.DeleteAsyncRetrycanceledAsync(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Post200WithPayload()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = client.Post200WithPayload(WaitUntil.Completed);

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Post200WithPayload_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = client.Post200WithPayload(WaitUntil.Completed);

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Post200WithPayload_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = await client.Post200WithPayloadAsync(WaitUntil.Completed);

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Post200WithPayload_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = await client.Post200WithPayloadAsync(WaitUntil.Completed);

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Post202Retry200()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new { };

            var operation = client.Post202Retry200(WaitUntil.Completed, RequestContent.Create(data));

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Post202Retry200_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

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
            var client = new LROsClient(credential);

            var data = new { };

            var operation = await client.Post202Retry200Async(WaitUntil.Completed, RequestContent.Create(data));

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Post202Retry200_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

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
        public void Example_Post202NoRetry204()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new { };

            var operation = client.Post202NoRetry204(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Post202NoRetry204_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

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

            var operation = client.Post202NoRetry204(WaitUntil.Completed, RequestContent.Create(data));

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
        public async Task Example_Post202NoRetry204_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new { };

            var operation = await client.Post202NoRetry204Async(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Post202NoRetry204_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

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

            var operation = await client.Post202NoRetry204Async(WaitUntil.Completed, RequestContent.Create(data));

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
        public void Example_PostDoubleHeadersFinalLocationGet()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = client.PostDoubleHeadersFinalLocationGet(WaitUntil.Completed);

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PostDoubleHeadersFinalLocationGet_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = client.PostDoubleHeadersFinalLocationGet(WaitUntil.Completed);

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
        public async Task Example_PostDoubleHeadersFinalLocationGet_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = await client.PostDoubleHeadersFinalLocationGetAsync(WaitUntil.Completed);

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PostDoubleHeadersFinalLocationGet_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = await client.PostDoubleHeadersFinalLocationGetAsync(WaitUntil.Completed);

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
        public void Example_PostDoubleHeadersFinalAzureHeaderGet()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = client.PostDoubleHeadersFinalAzureHeaderGet(WaitUntil.Completed);

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PostDoubleHeadersFinalAzureHeaderGet_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = client.PostDoubleHeadersFinalAzureHeaderGet(WaitUntil.Completed);

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
        public async Task Example_PostDoubleHeadersFinalAzureHeaderGet_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = await client.PostDoubleHeadersFinalAzureHeaderGetAsync(WaitUntil.Completed);

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PostDoubleHeadersFinalAzureHeaderGet_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = await client.PostDoubleHeadersFinalAzureHeaderGetAsync(WaitUntil.Completed);

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
        public void Example_PostDoubleHeadersFinalAzureHeaderGetDefault()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = client.PostDoubleHeadersFinalAzureHeaderGetDefault(WaitUntil.Completed);

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PostDoubleHeadersFinalAzureHeaderGetDefault_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = client.PostDoubleHeadersFinalAzureHeaderGetDefault(WaitUntil.Completed);

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
        public async Task Example_PostDoubleHeadersFinalAzureHeaderGetDefault_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = await client.PostDoubleHeadersFinalAzureHeaderGetDefaultAsync(WaitUntil.Completed);

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PostDoubleHeadersFinalAzureHeaderGetDefault_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var operation = await client.PostDoubleHeadersFinalAzureHeaderGetDefaultAsync(WaitUntil.Completed);

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
        public void Example_PostAsyncRetrySucceeded()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new { };

            var operation = client.PostAsyncRetrySucceeded(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PostAsyncRetrySucceeded_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

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
        public async Task Example_PostAsyncRetrySucceeded_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new { };

            var operation = await client.PostAsyncRetrySucceededAsync(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PostAsyncRetrySucceeded_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

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
        public void Example_PostAsyncNoRetrySucceeded()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new { };

            var operation = client.PostAsyncNoRetrySucceeded(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PostAsyncNoRetrySucceeded_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

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

            var operation = client.PostAsyncNoRetrySucceeded(WaitUntil.Completed, RequestContent.Create(data));

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
        public async Task Example_PostAsyncNoRetrySucceeded_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new { };

            var operation = await client.PostAsyncNoRetrySucceededAsync(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PostAsyncNoRetrySucceeded_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

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

            var operation = await client.PostAsyncNoRetrySucceededAsync(WaitUntil.Completed, RequestContent.Create(data));

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
        public void Example_PostAsyncRetryFailed()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new { };

            var operation = client.PostAsyncRetryFailed(WaitUntil.Completed, RequestContent.Create(data));

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PostAsyncRetryFailed_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

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

            var operation = client.PostAsyncRetryFailed(WaitUntil.Completed, RequestContent.Create(data));

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PostAsyncRetryFailed_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new { };

            var operation = await client.PostAsyncRetryFailedAsync(WaitUntil.Completed, RequestContent.Create(data));

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PostAsyncRetryFailed_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

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

            var operation = await client.PostAsyncRetryFailedAsync(WaitUntil.Completed, RequestContent.Create(data));

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PostAsyncRetrycanceled()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new { };

            var operation = client.PostAsyncRetrycanceled(WaitUntil.Completed, RequestContent.Create(data));

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PostAsyncRetrycanceled_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

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

            var operation = client.PostAsyncRetrycanceled(WaitUntil.Completed, RequestContent.Create(data));

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PostAsyncRetrycanceled_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

            var data = new { };

            var operation = await client.PostAsyncRetrycanceledAsync(WaitUntil.Completed, RequestContent.Create(data));

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PostAsyncRetrycanceled_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LROsClient(credential);

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

            var operation = await client.PostAsyncRetrycanceledAsync(WaitUntil.Completed, RequestContent.Create(data));

            Console.WriteLine(operation.GetRawResponse().Status);
        }
    }
}
