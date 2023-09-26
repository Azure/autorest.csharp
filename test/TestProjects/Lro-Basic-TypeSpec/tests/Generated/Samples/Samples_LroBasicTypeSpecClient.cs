// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using LroBasicTypeSpec;
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
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            LroBasicTypeSpecClient client = new LroBasicTypeSpecClient(endpoint);

            RequestContent content = RequestContent.Create(new object());
            Operation operation = client.CreateProject(WaitUntil.Completed, content);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CreateProject_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            LroBasicTypeSpecClient client = new LroBasicTypeSpecClient(endpoint);

            RequestContent content = RequestContent.Create(new object());
            Operation operation = await client.CreateProjectAsync(WaitUntil.Completed, content);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CreateProject_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            LroBasicTypeSpecClient client = new LroBasicTypeSpecClient(endpoint);

            Project resource = new Project();
            Operation operation = client.CreateProject(WaitUntil.Completed, resource);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CreateProject_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            LroBasicTypeSpecClient client = new LroBasicTypeSpecClient(endpoint);

            Project resource = new Project();
            Operation operation = await client.CreateProjectAsync(WaitUntil.Completed, resource);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CreateProject_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            LroBasicTypeSpecClient client = new LroBasicTypeSpecClient(endpoint);

            RequestContent content = RequestContent.Create(new
            {
                description = "<description>",
                name = "<name>",
            });
            Operation operation = client.CreateProject(WaitUntil.Completed, content);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CreateProject_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            LroBasicTypeSpecClient client = new LroBasicTypeSpecClient(endpoint);

            RequestContent content = RequestContent.Create(new
            {
                description = "<description>",
                name = "<name>",
            });
            Operation operation = await client.CreateProjectAsync(WaitUntil.Completed, content);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CreateProject_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            LroBasicTypeSpecClient client = new LroBasicTypeSpecClient(endpoint);

            Project resource = new Project
            {
                Description = "<description>",
                Name = "<name>",
            };
            Operation operation = client.CreateProject(WaitUntil.Completed, resource);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CreateProject_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            LroBasicTypeSpecClient client = new LroBasicTypeSpecClient(endpoint);

            Project resource = new Project
            {
                Description = "<description>",
                Name = "<name>",
            };
            Operation operation = await client.CreateProjectAsync(WaitUntil.Completed, resource);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UpdateProject()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            LroBasicTypeSpecClient client = new LroBasicTypeSpecClient(endpoint);

            RequestContent content = RequestContent.Create(new object());
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

            RequestContent content = RequestContent.Create(new object());
            Operation<BinaryData> operation = await client.UpdateProjectAsync(WaitUntil.Completed, "<id>", content);
            BinaryData responseData = operation.Value;

            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UpdateProject_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            LroBasicTypeSpecClient client = new LroBasicTypeSpecClient(endpoint);

            Project resource = new Project();
            Operation<Project> operation = client.UpdateProject(WaitUntil.Completed, "<id>", resource);
            Project responseData = operation.Value;
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UpdateProject_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            LroBasicTypeSpecClient client = new LroBasicTypeSpecClient(endpoint);

            Project resource = new Project();
            Operation<Project> operation = await client.UpdateProjectAsync(WaitUntil.Completed, "<id>", resource);
            Project responseData = operation.Value;
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_UpdateProject_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            LroBasicTypeSpecClient client = new LroBasicTypeSpecClient(endpoint);

            RequestContent content = RequestContent.Create(new
            {
                description = "<description>",
                name = "<name>",
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

            RequestContent content = RequestContent.Create(new
            {
                description = "<description>",
                name = "<name>",
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
        public void Example_UpdateProject_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            LroBasicTypeSpecClient client = new LroBasicTypeSpecClient(endpoint);

            Project resource = new Project
            {
                Description = "<description>",
                Name = "<name>",
            };
            Operation<Project> operation = client.UpdateProject(WaitUntil.Completed, "<id>", resource);
            Project responseData = operation.Value;
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_UpdateProject_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            LroBasicTypeSpecClient client = new LroBasicTypeSpecClient(endpoint);

            Project resource = new Project
            {
                Description = "<description>",
                Name = "<name>",
            };
            Operation<Project> operation = await client.UpdateProjectAsync(WaitUntil.Completed, "<id>", resource);
            Project responseData = operation.Value;
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CreateThing()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            LroBasicTypeSpecClient client = new LroBasicTypeSpecClient(endpoint);

            RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
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

            RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
            });
            Operation<BinaryData> operation = await client.CreateThingAsync(WaitUntil.Completed, content);
            BinaryData responseData = operation.Value;

            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CreateThing_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            LroBasicTypeSpecClient client = new LroBasicTypeSpecClient(endpoint);

            Thing thing = new Thing("<name>");
            Operation<Thing> operation = client.CreateThing(WaitUntil.Completed, thing);
            Thing responseData = operation.Value;
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CreateThing_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            LroBasicTypeSpecClient client = new LroBasicTypeSpecClient(endpoint);

            Thing thing = new Thing("<name>");
            Operation<Thing> operation = await client.CreateThingAsync(WaitUntil.Completed, thing);
            Thing responseData = operation.Value;
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CreateThing_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            LroBasicTypeSpecClient client = new LroBasicTypeSpecClient(endpoint);

            RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
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

            RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
            });
            Operation<BinaryData> operation = await client.CreateThingAsync(WaitUntil.Completed, content);
            BinaryData responseData = operation.Value;

            JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CreateThing_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            LroBasicTypeSpecClient client = new LroBasicTypeSpecClient(endpoint);

            Thing thing = new Thing("<name>");
            Operation<Thing> operation = client.CreateThing(WaitUntil.Completed, thing);
            Thing responseData = operation.Value;
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CreateThing_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            LroBasicTypeSpecClient client = new LroBasicTypeSpecClient(endpoint);

            Thing thing = new Thing("<name>");
            Operation<Thing> operation = await client.CreateThingAsync(WaitUntil.Completed, thing);
            Thing responseData = operation.Value;
        }
    }
}
