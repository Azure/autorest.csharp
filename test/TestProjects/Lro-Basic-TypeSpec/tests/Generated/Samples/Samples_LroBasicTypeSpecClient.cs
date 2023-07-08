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
using LroBasicTypeSpec;
using NUnit.Framework;

namespace LroBasicTypeSpec.Samples
{
    public class Samples_LroBasicTypeSpecClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CreateProject()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            LroBasicTypeSpecClient client = new LroBasicTypeSpecClient(endpoint);

            RequestContent content = RequestContent.Create(new Dictionary<string, object>()
            {
                ["description"] = "<description>",
                ["name"] = "<name>",
            });
            Operation operation = client.CreateProject(WaitUntil.Completed, content);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CreateProject_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            LroBasicTypeSpecClient client = new LroBasicTypeSpecClient(endpoint);

            RequestContent content = RequestContent.Create(new Dictionary<string, object>()
            {
                ["description"] = "<description>",
                ["name"] = "<name>",
            });
            Operation operation = await client.CreateProjectAsync(WaitUntil.Completed, content);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CreateProject_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            LroBasicTypeSpecClient client = new LroBasicTypeSpecClient(endpoint);

            RequestContent content = RequestContent.Create(new Dictionary<string, object>()
            {
                ["description"] = "<description>",
                ["name"] = "<name>",
            });
            Operation operation = client.CreateProject(WaitUntil.Completed, content);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CreateProject_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            LroBasicTypeSpecClient client = new LroBasicTypeSpecClient(endpoint);

            RequestContent content = RequestContent.Create(new Dictionary<string, object>()
            {
                ["description"] = "<description>",
                ["name"] = "<name>",
            });
            Operation operation = await client.CreateProjectAsync(WaitUntil.Completed, content);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UpdateProject()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            LroBasicTypeSpecClient client = new LroBasicTypeSpecClient(endpoint);

            RequestContent content = RequestContent.Create(new Dictionary<string, object>()
            {
                ["description"] = "<description>",
                ["name"] = "<name>",
            });
            Operation<BinaryData> operation = client.UpdateProject(WaitUntil.Completed, "<id>", content);
            BinaryData responseData = operation.Value;

            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UpdateProject_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            LroBasicTypeSpecClient client = new LroBasicTypeSpecClient(endpoint);

            RequestContent content = RequestContent.Create(new Dictionary<string, object>()
            {
                ["description"] = "<description>",
                ["name"] = "<name>",
            });
            Operation<BinaryData> operation = await client.UpdateProjectAsync(WaitUntil.Completed, "<id>", content);
            BinaryData responseData = operation.Value;

            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UpdateProject_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            LroBasicTypeSpecClient client = new LroBasicTypeSpecClient(endpoint);

            RequestContent content = RequestContent.Create(new Dictionary<string, object>()
            {
                ["description"] = "<description>",
                ["name"] = "<name>",
            });
            Operation<BinaryData> operation = client.UpdateProject(WaitUntil.Completed, "<id>", content);
            BinaryData responseData = operation.Value;

            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("description").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UpdateProject_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            LroBasicTypeSpecClient client = new LroBasicTypeSpecClient(endpoint);

            RequestContent content = RequestContent.Create(new Dictionary<string, object>()
            {
                ["description"] = "<description>",
                ["name"] = "<name>",
            });
            Operation<BinaryData> operation = await client.UpdateProjectAsync(WaitUntil.Completed, "<id>", content);
            BinaryData responseData = operation.Value;

            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("description").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CreateThing()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            LroBasicTypeSpecClient client = new LroBasicTypeSpecClient(endpoint);

            RequestContent content = RequestContent.Create(new Dictionary<string, object>()
            {
                ["name"] = "<name>",
            });
            Operation<BinaryData> operation = client.CreateThing(WaitUntil.Completed, content);
            BinaryData responseData = operation.Value;

            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CreateThing_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            LroBasicTypeSpecClient client = new LroBasicTypeSpecClient(endpoint);

            RequestContent content = RequestContent.Create(new Dictionary<string, object>()
            {
                ["name"] = "<name>",
            });
            Operation<BinaryData> operation = await client.CreateThingAsync(WaitUntil.Completed, content);
            BinaryData responseData = operation.Value;

            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CreateThing_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            LroBasicTypeSpecClient client = new LroBasicTypeSpecClient(endpoint);

            RequestContent content = RequestContent.Create(new Dictionary<string, object>()
            {
                ["name"] = "<name>",
            });
            Operation<BinaryData> operation = client.CreateThing(WaitUntil.Completed, content);
            BinaryData responseData = operation.Value;

            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CreateThing_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            LroBasicTypeSpecClient client = new LroBasicTypeSpecClient(endpoint);

            RequestContent content = RequestContent.Create(new Dictionary<string, object>()
            {
                ["name"] = "<name>",
            });
            Operation<BinaryData> operation = await client.CreateThingAsync(WaitUntil.Completed, content);
            BinaryData responseData = operation.Value;

            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }
    }
}
