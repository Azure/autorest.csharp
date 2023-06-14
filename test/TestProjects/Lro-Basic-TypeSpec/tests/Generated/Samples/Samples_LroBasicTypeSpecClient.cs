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
using LroBasicTypeSpec.Models;
using NUnit.Framework;

namespace LroBasicTypeSpec.Samples
{
    public class Samples_LroBasicTypeSpecClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CreateProject()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new LroBasicTypeSpecClient(endpoint);

            var data = new { };

            var operation = client.CreateProject(WaitUntil.Completed, RequestContent.Create(data));

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CreateProject_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new LroBasicTypeSpecClient(endpoint);

            var data = new
            {
                description = "<description>",
                name = "<name>",
            };

            var operation = client.CreateProject(WaitUntil.Completed, RequestContent.Create(data));

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CreateProject_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new LroBasicTypeSpecClient(endpoint);

            var data = new { };

            var operation = await client.CreateProjectAsync(WaitUntil.Completed, RequestContent.Create(data));

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CreateProject_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new LroBasicTypeSpecClient(endpoint);

            var data = new
            {
                description = "<description>",
                name = "<name>",
            };

            var operation = await client.CreateProjectAsync(WaitUntil.Completed, RequestContent.Create(data));

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CreateProject_Convenience_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new LroBasicTypeSpecClient(endpoint);

            var resource = new Project()
            {
                Description = "<Description>",
                Name = "<Name>",
            };
            var operation = await client.CreateProjectAsync(WaitUntil.Completed, resource);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UpdateProject()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new LroBasicTypeSpecClient(endpoint);

            var data = new { };

            var operation = client.UpdateProject(WaitUntil.Completed, "<id>", RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UpdateProject_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new LroBasicTypeSpecClient(endpoint);

            var data = new
            {
                description = "<description>",
                name = "<name>",
            };

            var operation = client.UpdateProject(WaitUntil.Completed, "<id>", RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("description").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UpdateProject_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new LroBasicTypeSpecClient(endpoint);

            var data = new { };

            var operation = await client.UpdateProjectAsync(WaitUntil.Completed, "<id>", RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UpdateProject_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new LroBasicTypeSpecClient(endpoint);

            var data = new
            {
                description = "<description>",
                name = "<name>",
            };

            var operation = await client.UpdateProjectAsync(WaitUntil.Completed, "<id>", RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("description").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UpdateProject_Convenience_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new LroBasicTypeSpecClient(endpoint);

            var resource = new Project()
            {
                Description = "<Description>",
                Name = "<Name>",
            };
            var operation = await client.UpdateProjectAsync(WaitUntil.Completed, "<id>", resource);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CreateThing()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new LroBasicTypeSpecClient(endpoint);

            var data = new
            {
                name = "<name>",
            };

            var operation = client.CreateThing(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CreateThing_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new LroBasicTypeSpecClient(endpoint);

            var data = new
            {
                name = "<name>",
            };

            var operation = client.CreateThing(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CreateThing_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new LroBasicTypeSpecClient(endpoint);

            var data = new
            {
                name = "<name>",
            };

            var operation = await client.CreateThingAsync(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CreateThing_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new LroBasicTypeSpecClient(endpoint);

            var data = new
            {
                name = "<name>",
            };

            var operation = await client.CreateThingAsync(WaitUntil.Completed, RequestContent.Create(data));

            BinaryData responseData = operation.Value;
            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CreateThing_Convenience_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new LroBasicTypeSpecClient(endpoint);

            var thing = new Thing("<name>");
            var operation = await client.CreateThingAsync(WaitUntil.Completed, thing);
        }
    }
}
