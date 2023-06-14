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
    public class Samples_LrosaDsClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutNonRetry400()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var data = new { };

            var operation = client.PutNonRetry400(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutNonRetry400_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

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

            var operation = client.PutNonRetry400(WaitUntil.Completed, RequestContent.Create(data));

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
        public async Task Example_PutNonRetry400_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var data = new { };

            var operation = await client.PutNonRetry400Async(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutNonRetry400_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

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

            var operation = await client.PutNonRetry400Async(WaitUntil.Completed, RequestContent.Create(data));

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
        public void Example_PutNonRetry201Creating400()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var data = new { };

            var operation = client.PutNonRetry201Creating400(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutNonRetry201Creating400_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

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

            var operation = client.PutNonRetry201Creating400(WaitUntil.Completed, RequestContent.Create(data));

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
        public async Task Example_PutNonRetry201Creating400_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var data = new { };

            var operation = await client.PutNonRetry201Creating400Async(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutNonRetry201Creating400_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

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

            var operation = await client.PutNonRetry201Creating400Async(WaitUntil.Completed, RequestContent.Create(data));

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
        public void Example_PutNonRetry201Creating400InvalidJson()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var data = new { };

            var operation = client.PutNonRetry201Creating400InvalidJson(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutNonRetry201Creating400InvalidJson_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

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

            var operation = client.PutNonRetry201Creating400InvalidJson(WaitUntil.Completed, RequestContent.Create(data));

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
        public async Task Example_PutNonRetry201Creating400InvalidJson_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var data = new { };

            var operation = await client.PutNonRetry201Creating400InvalidJsonAsync(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutNonRetry201Creating400InvalidJson_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

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

            var operation = await client.PutNonRetry201Creating400InvalidJsonAsync(WaitUntil.Completed, RequestContent.Create(data));

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
        public void Example_PutAsyncRelativeRetry400()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var data = new { };

            var operation = client.PutAsyncRelativeRetry400(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutAsyncRelativeRetry400_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

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

            var operation = client.PutAsyncRelativeRetry400(WaitUntil.Completed, RequestContent.Create(data));

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
        public async Task Example_PutAsyncRelativeRetry400_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var data = new { };

            var operation = await client.PutAsyncRelativeRetry400Async(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutAsyncRelativeRetry400_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

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

            var operation = await client.PutAsyncRelativeRetry400Async(WaitUntil.Completed, RequestContent.Create(data));

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
        public void Example_DeleteNonRetry400()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var operation = client.DeleteNonRetry400(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DeleteNonRetry400_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var operation = client.DeleteNonRetry400(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DeleteNonRetry400_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var operation = await client.DeleteNonRetry400Async(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DeleteNonRetry400_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var operation = await client.DeleteNonRetry400Async(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Delete202NonRetry400()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var operation = client.Delete202NonRetry400(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Delete202NonRetry400_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var operation = client.Delete202NonRetry400(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Delete202NonRetry400_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var operation = await client.Delete202NonRetry400Async(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Delete202NonRetry400_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var operation = await client.Delete202NonRetry400Async(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DeleteAsyncRelativeRetry400()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var operation = client.DeleteAsyncRelativeRetry400(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DeleteAsyncRelativeRetry400_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var operation = client.DeleteAsyncRelativeRetry400(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DeleteAsyncRelativeRetry400_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var operation = await client.DeleteAsyncRelativeRetry400Async(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DeleteAsyncRelativeRetry400_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var operation = await client.DeleteAsyncRelativeRetry400Async(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PostNonRetry400()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var data = new { };

            var operation = client.PostNonRetry400(WaitUntil.Completed, RequestContent.Create(data));

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PostNonRetry400_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

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

            var operation = client.PostNonRetry400(WaitUntil.Completed, RequestContent.Create(data));

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PostNonRetry400_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var data = new { };

            var operation = await client.PostNonRetry400Async(WaitUntil.Completed, RequestContent.Create(data));

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PostNonRetry400_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

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

            var operation = await client.PostNonRetry400Async(WaitUntil.Completed, RequestContent.Create(data));

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Post202NonRetry400()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var data = new { };

            var operation = client.Post202NonRetry400(WaitUntil.Completed, RequestContent.Create(data));

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Post202NonRetry400_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

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

            var operation = client.Post202NonRetry400(WaitUntil.Completed, RequestContent.Create(data));

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Post202NonRetry400_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var data = new { };

            var operation = await client.Post202NonRetry400Async(WaitUntil.Completed, RequestContent.Create(data));

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Post202NonRetry400_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

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

            var operation = await client.Post202NonRetry400Async(WaitUntil.Completed, RequestContent.Create(data));

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PostAsyncRelativeRetry400()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var data = new { };

            var operation = client.PostAsyncRelativeRetry400(WaitUntil.Completed, RequestContent.Create(data));

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PostAsyncRelativeRetry400_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

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

            var operation = client.PostAsyncRelativeRetry400(WaitUntil.Completed, RequestContent.Create(data));

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PostAsyncRelativeRetry400_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var data = new { };

            var operation = await client.PostAsyncRelativeRetry400Async(WaitUntil.Completed, RequestContent.Create(data));

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PostAsyncRelativeRetry400_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

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

            var operation = await client.PostAsyncRelativeRetry400Async(WaitUntil.Completed, RequestContent.Create(data));

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutError201NoProvisioningStatePayload()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var data = new { };

            var operation = client.PutError201NoProvisioningStatePayload(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutError201NoProvisioningStatePayload_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

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

            var operation = client.PutError201NoProvisioningStatePayload(WaitUntil.Completed, RequestContent.Create(data));

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
        public async Task Example_PutError201NoProvisioningStatePayload_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var data = new { };

            var operation = await client.PutError201NoProvisioningStatePayloadAsync(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutError201NoProvisioningStatePayload_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

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

            var operation = await client.PutError201NoProvisioningStatePayloadAsync(WaitUntil.Completed, RequestContent.Create(data));

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
        public void Example_PutAsyncRelativeRetryNoStatus()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var data = new { };

            var operation = client.PutAsyncRelativeRetryNoStatus(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutAsyncRelativeRetryNoStatus_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

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

            var operation = client.PutAsyncRelativeRetryNoStatus(WaitUntil.Completed, RequestContent.Create(data));

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
        public async Task Example_PutAsyncRelativeRetryNoStatus_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var data = new { };

            var operation = await client.PutAsyncRelativeRetryNoStatusAsync(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutAsyncRelativeRetryNoStatus_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

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

            var operation = await client.PutAsyncRelativeRetryNoStatusAsync(WaitUntil.Completed, RequestContent.Create(data));

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
        public void Example_PutAsyncRelativeRetryNoStatusPayload()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var data = new { };

            var operation = client.PutAsyncRelativeRetryNoStatusPayload(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutAsyncRelativeRetryNoStatusPayload_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

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

            var operation = client.PutAsyncRelativeRetryNoStatusPayload(WaitUntil.Completed, RequestContent.Create(data));

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
        public async Task Example_PutAsyncRelativeRetryNoStatusPayload_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var data = new { };

            var operation = await client.PutAsyncRelativeRetryNoStatusPayloadAsync(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutAsyncRelativeRetryNoStatusPayload_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

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

            var operation = await client.PutAsyncRelativeRetryNoStatusPayloadAsync(WaitUntil.Completed, RequestContent.Create(data));

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
            var client = new LrosaDsClient(credential);

            var operation = client.Delete204Succeeded(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Delete204Succeeded_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var operation = client.Delete204Succeeded(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Delete204Succeeded_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var operation = await client.Delete204SucceededAsync(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Delete204Succeeded_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var operation = await client.Delete204SucceededAsync(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DeleteAsyncRelativeRetryNoStatus()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var operation = client.DeleteAsyncRelativeRetryNoStatus(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DeleteAsyncRelativeRetryNoStatus_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var operation = client.DeleteAsyncRelativeRetryNoStatus(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DeleteAsyncRelativeRetryNoStatus_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var operation = await client.DeleteAsyncRelativeRetryNoStatusAsync(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DeleteAsyncRelativeRetryNoStatus_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var operation = await client.DeleteAsyncRelativeRetryNoStatusAsync(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Post202NoLocation()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var data = new { };

            var operation = client.Post202NoLocation(WaitUntil.Completed, RequestContent.Create(data));

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Post202NoLocation_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

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

            var operation = client.Post202NoLocation(WaitUntil.Completed, RequestContent.Create(data));

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Post202NoLocation_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var data = new { };

            var operation = await client.Post202NoLocationAsync(WaitUntil.Completed, RequestContent.Create(data));

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Post202NoLocation_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

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

            var operation = await client.Post202NoLocationAsync(WaitUntil.Completed, RequestContent.Create(data));

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PostAsyncRelativeRetryNoPayload()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var data = new { };

            var operation = client.PostAsyncRelativeRetryNoPayload(WaitUntil.Completed, RequestContent.Create(data));

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PostAsyncRelativeRetryNoPayload_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

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

            var operation = client.PostAsyncRelativeRetryNoPayload(WaitUntil.Completed, RequestContent.Create(data));

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PostAsyncRelativeRetryNoPayload_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var data = new { };

            var operation = await client.PostAsyncRelativeRetryNoPayloadAsync(WaitUntil.Completed, RequestContent.Create(data));

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PostAsyncRelativeRetryNoPayload_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

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

            var operation = await client.PostAsyncRelativeRetryNoPayloadAsync(WaitUntil.Completed, RequestContent.Create(data));

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put200InvalidJson()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var data = new { };

            var operation = client.Put200InvalidJson(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Put200InvalidJson_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

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

            var operation = client.Put200InvalidJson(WaitUntil.Completed, RequestContent.Create(data));

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
        public async Task Example_Put200InvalidJson_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var data = new { };

            var operation = await client.Put200InvalidJsonAsync(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Put200InvalidJson_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

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

            var operation = await client.Put200InvalidJsonAsync(WaitUntil.Completed, RequestContent.Create(data));

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
        public void Example_PutAsyncRelativeRetryInvalidHeader()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var data = new { };

            var operation = client.PutAsyncRelativeRetryInvalidHeader(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutAsyncRelativeRetryInvalidHeader_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

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

            var operation = client.PutAsyncRelativeRetryInvalidHeader(WaitUntil.Completed, RequestContent.Create(data));

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
        public async Task Example_PutAsyncRelativeRetryInvalidHeader_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var data = new { };

            var operation = await client.PutAsyncRelativeRetryInvalidHeaderAsync(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutAsyncRelativeRetryInvalidHeader_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

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

            var operation = await client.PutAsyncRelativeRetryInvalidHeaderAsync(WaitUntil.Completed, RequestContent.Create(data));

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
        public void Example_PutAsyncRelativeRetryInvalidJsonPolling()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var data = new { };

            var operation = client.PutAsyncRelativeRetryInvalidJsonPolling(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutAsyncRelativeRetryInvalidJsonPolling_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

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

            var operation = client.PutAsyncRelativeRetryInvalidJsonPolling(WaitUntil.Completed, RequestContent.Create(data));

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
        public async Task Example_PutAsyncRelativeRetryInvalidJsonPolling_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var data = new { };

            var operation = await client.PutAsyncRelativeRetryInvalidJsonPollingAsync(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutAsyncRelativeRetryInvalidJsonPolling_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

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

            var operation = await client.PutAsyncRelativeRetryInvalidJsonPollingAsync(WaitUntil.Completed, RequestContent.Create(data));

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
        public void Example_Delete202RetryInvalidHeader()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var operation = client.Delete202RetryInvalidHeader(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Delete202RetryInvalidHeader_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var operation = client.Delete202RetryInvalidHeader(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Delete202RetryInvalidHeader_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var operation = await client.Delete202RetryInvalidHeaderAsync(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Delete202RetryInvalidHeader_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var operation = await client.Delete202RetryInvalidHeaderAsync(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DeleteAsyncRelativeRetryInvalidHeader()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var operation = client.DeleteAsyncRelativeRetryInvalidHeader(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DeleteAsyncRelativeRetryInvalidHeader_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var operation = client.DeleteAsyncRelativeRetryInvalidHeader(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DeleteAsyncRelativeRetryInvalidHeader_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var operation = await client.DeleteAsyncRelativeRetryInvalidHeaderAsync(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DeleteAsyncRelativeRetryInvalidHeader_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var operation = await client.DeleteAsyncRelativeRetryInvalidHeaderAsync(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DeleteAsyncRelativeRetryInvalidJsonPolling()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var operation = client.DeleteAsyncRelativeRetryInvalidJsonPolling(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DeleteAsyncRelativeRetryInvalidJsonPolling_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var operation = client.DeleteAsyncRelativeRetryInvalidJsonPolling(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DeleteAsyncRelativeRetryInvalidJsonPolling_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var operation = await client.DeleteAsyncRelativeRetryInvalidJsonPollingAsync(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DeleteAsyncRelativeRetryInvalidJsonPolling_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var operation = await client.DeleteAsyncRelativeRetryInvalidJsonPollingAsync(WaitUntil.Completed);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Post202RetryInvalidHeader()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var data = new { };

            var operation = client.Post202RetryInvalidHeader(WaitUntil.Completed, RequestContent.Create(data));

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Post202RetryInvalidHeader_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

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

            var operation = client.Post202RetryInvalidHeader(WaitUntil.Completed, RequestContent.Create(data));

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Post202RetryInvalidHeader_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var data = new { };

            var operation = await client.Post202RetryInvalidHeaderAsync(WaitUntil.Completed, RequestContent.Create(data));

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Post202RetryInvalidHeader_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

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

            var operation = await client.Post202RetryInvalidHeaderAsync(WaitUntil.Completed, RequestContent.Create(data));

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PostAsyncRelativeRetryInvalidHeader()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var data = new { };

            var operation = client.PostAsyncRelativeRetryInvalidHeader(WaitUntil.Completed, RequestContent.Create(data));

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PostAsyncRelativeRetryInvalidHeader_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

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

            var operation = client.PostAsyncRelativeRetryInvalidHeader(WaitUntil.Completed, RequestContent.Create(data));

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PostAsyncRelativeRetryInvalidHeader_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var data = new { };

            var operation = await client.PostAsyncRelativeRetryInvalidHeaderAsync(WaitUntil.Completed, RequestContent.Create(data));

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PostAsyncRelativeRetryInvalidHeader_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

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

            var operation = await client.PostAsyncRelativeRetryInvalidHeaderAsync(WaitUntil.Completed, RequestContent.Create(data));

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PostAsyncRelativeRetryInvalidJsonPolling()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var data = new { };

            var operation = client.PostAsyncRelativeRetryInvalidJsonPolling(WaitUntil.Completed, RequestContent.Create(data));

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PostAsyncRelativeRetryInvalidJsonPolling_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

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

            var operation = client.PostAsyncRelativeRetryInvalidJsonPolling(WaitUntil.Completed, RequestContent.Create(data));

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PostAsyncRelativeRetryInvalidJsonPolling_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

            var data = new { };

            var operation = await client.PostAsyncRelativeRetryInvalidJsonPollingAsync(WaitUntil.Completed, RequestContent.Create(data));

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PostAsyncRelativeRetryInvalidJsonPolling_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new LrosaDsClient(credential);

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

            var operation = await client.PostAsyncRelativeRetryInvalidJsonPollingAsync(WaitUntil.Completed, RequestContent.Create(data));

            Console.WriteLine(operation.GetRawResponse().Status);
        }
    }
}
