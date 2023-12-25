// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using NUnit.Framework;
using RenameGetList;

namespace RenameGetList.Samples
{
    public partial class Samples_RenameGetListClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetProject_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            RenameGetListClient client = new RenameGetListClient(endpoint);

            Response response = client.GetProject("<projectName>", null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("projectName").ToString());
            Console.WriteLine(result.GetProperty("projectKind").ToString());
            Console.WriteLine(result.GetProperty("storageInputContainerName").ToString());
            Console.WriteLine(result.GetProperty("language").ToString());
            Console.WriteLine(result.GetProperty("createdDateTime").ToString());
            Console.WriteLine(result.GetProperty("lastModifiedDateTime").ToString());
            Console.WriteLine(result.GetProperty("lastTrainedDateTime").ToString());
            Console.WriteLine(result.GetProperty("lastDeployedDateTime").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetProject_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            RenameGetListClient client = new RenameGetListClient(endpoint);

            Response response = await client.GetProjectAsync("<projectName>", null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("projectName").ToString());
            Console.WriteLine(result.GetProperty("projectKind").ToString());
            Console.WriteLine(result.GetProperty("storageInputContainerName").ToString());
            Console.WriteLine(result.GetProperty("language").ToString());
            Console.WriteLine(result.GetProperty("createdDateTime").ToString());
            Console.WriteLine(result.GetProperty("lastModifiedDateTime").ToString());
            Console.WriteLine(result.GetProperty("lastTrainedDateTime").ToString());
            Console.WriteLine(result.GetProperty("lastDeployedDateTime").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetProject_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            RenameGetListClient client = new RenameGetListClient(endpoint);

            Response response = client.GetProject("<projectName>", null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("projectName").ToString());
            Console.WriteLine(result.GetProperty("projectKind").ToString());
            Console.WriteLine(result.GetProperty("storageInputContainerName").ToString());
            Console.WriteLine(result.GetProperty("settings").GetProperty("<key>").ToString());
            Console.WriteLine(result.GetProperty("multilingual").ToString());
            Console.WriteLine(result.GetProperty("description").ToString());
            Console.WriteLine(result.GetProperty("language").ToString());
            Console.WriteLine(result.GetProperty("createdDateTime").ToString());
            Console.WriteLine(result.GetProperty("lastModifiedDateTime").ToString());
            Console.WriteLine(result.GetProperty("lastTrainedDateTime").ToString());
            Console.WriteLine(result.GetProperty("lastDeployedDateTime").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetProject_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            RenameGetListClient client = new RenameGetListClient(endpoint);

            Response response = await client.GetProjectAsync("<projectName>", null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("projectName").ToString());
            Console.WriteLine(result.GetProperty("projectKind").ToString());
            Console.WriteLine(result.GetProperty("storageInputContainerName").ToString());
            Console.WriteLine(result.GetProperty("settings").GetProperty("<key>").ToString());
            Console.WriteLine(result.GetProperty("multilingual").ToString());
            Console.WriteLine(result.GetProperty("description").ToString());
            Console.WriteLine(result.GetProperty("language").ToString());
            Console.WriteLine(result.GetProperty("createdDateTime").ToString());
            Console.WriteLine(result.GetProperty("lastModifiedDateTime").ToString());
            Console.WriteLine(result.GetProperty("lastTrainedDateTime").ToString());
            Console.WriteLine(result.GetProperty("lastDeployedDateTime").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDeployment_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            RenameGetListClient client = new RenameGetListClient(endpoint);

            Response response = client.GetDeployment("<projectName>", "<deploymentName>", null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDeployment_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            RenameGetListClient client = new RenameGetListClient(endpoint);

            Response response = await client.GetDeploymentAsync("<projectName>", "<deploymentName>", null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDeployment_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            RenameGetListClient client = new RenameGetListClient(endpoint);

            Response response = client.GetDeployment("<projectName>", "<deploymentName>", null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDeployment_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            RenameGetListClient client = new RenameGetListClient(endpoint);

            Response response = await client.GetDeploymentAsync("<projectName>", "<deploymentName>", null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetProjects_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            RenameGetListClient client = new RenameGetListClient(endpoint);

            foreach (BinaryData item in client.GetProjects(null))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("projectName").ToString());
                Console.WriteLine(result.GetProperty("projectKind").ToString());
                Console.WriteLine(result.GetProperty("storageInputContainerName").ToString());
                Console.WriteLine(result.GetProperty("language").ToString());
                Console.WriteLine(result.GetProperty("createdDateTime").ToString());
                Console.WriteLine(result.GetProperty("lastModifiedDateTime").ToString());
                Console.WriteLine(result.GetProperty("lastTrainedDateTime").ToString());
                Console.WriteLine(result.GetProperty("lastDeployedDateTime").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetProjects_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            RenameGetListClient client = new RenameGetListClient(endpoint);

            await foreach (BinaryData item in client.GetProjectsAsync(null))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("projectName").ToString());
                Console.WriteLine(result.GetProperty("projectKind").ToString());
                Console.WriteLine(result.GetProperty("storageInputContainerName").ToString());
                Console.WriteLine(result.GetProperty("language").ToString());
                Console.WriteLine(result.GetProperty("createdDateTime").ToString());
                Console.WriteLine(result.GetProperty("lastModifiedDateTime").ToString());
                Console.WriteLine(result.GetProperty("lastTrainedDateTime").ToString());
                Console.WriteLine(result.GetProperty("lastDeployedDateTime").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetProjects_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            RenameGetListClient client = new RenameGetListClient(endpoint);

            foreach (BinaryData item in client.GetProjects(null))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("projectName").ToString());
                Console.WriteLine(result.GetProperty("projectKind").ToString());
                Console.WriteLine(result.GetProperty("storageInputContainerName").ToString());
                Console.WriteLine(result.GetProperty("settings").GetProperty("<key>").ToString());
                Console.WriteLine(result.GetProperty("multilingual").ToString());
                Console.WriteLine(result.GetProperty("description").ToString());
                Console.WriteLine(result.GetProperty("language").ToString());
                Console.WriteLine(result.GetProperty("createdDateTime").ToString());
                Console.WriteLine(result.GetProperty("lastModifiedDateTime").ToString());
                Console.WriteLine(result.GetProperty("lastTrainedDateTime").ToString());
                Console.WriteLine(result.GetProperty("lastDeployedDateTime").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetProjects_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            RenameGetListClient client = new RenameGetListClient(endpoint);

            await foreach (BinaryData item in client.GetProjectsAsync(null))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("projectName").ToString());
                Console.WriteLine(result.GetProperty("projectKind").ToString());
                Console.WriteLine(result.GetProperty("storageInputContainerName").ToString());
                Console.WriteLine(result.GetProperty("settings").GetProperty("<key>").ToString());
                Console.WriteLine(result.GetProperty("multilingual").ToString());
                Console.WriteLine(result.GetProperty("description").ToString());
                Console.WriteLine(result.GetProperty("language").ToString());
                Console.WriteLine(result.GetProperty("createdDateTime").ToString());
                Console.WriteLine(result.GetProperty("lastModifiedDateTime").ToString());
                Console.WriteLine(result.GetProperty("lastTrainedDateTime").ToString());
                Console.WriteLine(result.GetProperty("lastDeployedDateTime").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDeployments_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            RenameGetListClient client = new RenameGetListClient(endpoint);

            foreach (BinaryData item in client.GetDeployments("<projectName>", null))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("name").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDeployments_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            RenameGetListClient client = new RenameGetListClient(endpoint);

            await foreach (BinaryData item in client.GetDeploymentsAsync("<projectName>", null))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("name").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDeployments_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            RenameGetListClient client = new RenameGetListClient(endpoint);

            foreach (BinaryData item in client.GetDeployments("<projectName>", null))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("name").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDeployments_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            RenameGetListClient client = new RenameGetListClient(endpoint);

            await foreach (BinaryData item in client.GetDeploymentsAsync("<projectName>", null))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("name").ToString());
            }
        }
    }
}