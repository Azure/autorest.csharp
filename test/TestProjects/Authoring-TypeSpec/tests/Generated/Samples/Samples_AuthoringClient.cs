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
using Azure.Language.Authoring.Models;
using NUnit.Framework;

namespace Azure.Language.Authoring.Samples
{
    public class Samples_AuthoringClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CreateOrUpdate()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            var data = new
            {
                projectKind = "CustomSingleLabelClassification",
                storageInputContainerName = "<storageInputContainerName>",
                language = "<language>",
            };

            Response response = client.CreateOrUpdate("<projectName>", RequestContent.Create(data));

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
        public void Example_CreateOrUpdate_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            var data = new
            {
                projectKind = "CustomSingleLabelClassification",
                storageInputContainerName = "<storageInputContainerName>",
                settings = new
                {
                    key = "<String>",
                },
                multilingual = true,
                description = "<description>",
                language = "<language>",
            };

            Response response = client.CreateOrUpdate("<projectName>", RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("projectName").ToString());
            Console.WriteLine(result.GetProperty("projectKind").ToString());
            Console.WriteLine(result.GetProperty("storageInputContainerName").ToString());
            Console.WriteLine(result.GetProperty("settings").GetProperty("<test>").ToString());
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
        public async Task Example_CreateOrUpdate_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            var data = new
            {
                projectKind = "CustomSingleLabelClassification",
                storageInputContainerName = "<storageInputContainerName>",
                language = "<language>",
            };

            Response response = await client.CreateOrUpdateAsync("<projectName>", RequestContent.Create(data));

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
        public async Task Example_CreateOrUpdate_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            var data = new
            {
                projectKind = "CustomSingleLabelClassification",
                storageInputContainerName = "<storageInputContainerName>",
                settings = new
                {
                    key = "<String>",
                },
                multilingual = true,
                description = "<description>",
                language = "<language>",
            };

            Response response = await client.CreateOrUpdateAsync("<projectName>", RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("projectName").ToString());
            Console.WriteLine(result.GetProperty("projectKind").ToString());
            Console.WriteLine(result.GetProperty("storageInputContainerName").ToString());
            Console.WriteLine(result.GetProperty("settings").GetProperty("<test>").ToString());
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
        public void Example_GetProject()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            Response response = client.GetProject("<projectName>");

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
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            Response response = client.GetProject("<projectName>");

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("projectName").ToString());
            Console.WriteLine(result.GetProperty("projectKind").ToString());
            Console.WriteLine(result.GetProperty("storageInputContainerName").ToString());
            Console.WriteLine(result.GetProperty("settings").GetProperty("<test>").ToString());
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
        public async Task Example_GetProject_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            Response response = await client.GetProjectAsync("<projectName>");

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
        public async Task Example_GetProject_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            Response response = await client.GetProjectAsync("<projectName>");

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("projectName").ToString());
            Console.WriteLine(result.GetProperty("projectKind").ToString());
            Console.WriteLine(result.GetProperty("storageInputContainerName").ToString());
            Console.WriteLine(result.GetProperty("settings").GetProperty("<test>").ToString());
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
        public void Example_Delete()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            Response response = client.Delete("<projectName>");

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
        public void Example_Delete_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            Response response = client.Delete("<projectName>");

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("projectName").ToString());
            Console.WriteLine(result.GetProperty("projectKind").ToString());
            Console.WriteLine(result.GetProperty("storageInputContainerName").ToString());
            Console.WriteLine(result.GetProperty("settings").GetProperty("<test>").ToString());
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
        public async Task Example_Delete_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            Response response = await client.DeleteAsync("<projectName>");

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
        public async Task Example_Delete_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            Response response = await client.DeleteAsync("<projectName>");

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("projectName").ToString());
            Console.WriteLine(result.GetProperty("projectKind").ToString());
            Console.WriteLine(result.GetProperty("storageInputContainerName").ToString());
            Console.WriteLine(result.GetProperty("settings").GetProperty("<test>").ToString());
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
        public void Example_Export()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            Response response = client.Export("<projectName>", "<projectFileVersion>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Export_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            Response response = client.Export("<projectName>", "<projectFileVersion>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Export_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            Response response = await client.ExportAsync("<projectName>", "<projectFileVersion>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Export_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            Response response = await client.ExportAsync("<projectName>", "<projectFileVersion>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Importx()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            Response response = client.Importx("<projectName>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Importx_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            Response response = client.Importx("<projectName>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Importx_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            Response response = await client.ImportxAsync("<projectName>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Importx_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            Response response = await client.ImportxAsync("<projectName>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Train()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            var data = new
            {
                modelLabel = "<modelLabel>",
            };

            Response response = client.Train("<projectName>", RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Train_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            var data = new
            {
                modelLabel = "<modelLabel>",
            };

            Response response = client.Train("<projectName>", RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Train_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            var data = new
            {
                modelLabel = "<modelLabel>",
            };

            Response response = await client.TrainAsync("<projectName>", RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Train_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            var data = new
            {
                modelLabel = "<modelLabel>",
            };

            Response response = await client.TrainAsync("<projectName>", RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDeployment()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            Response response = client.GetDeployment("<projectName>", "<deploymentName>");

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDeployment_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            Response response = client.GetDeployment("<projectName>", "<deploymentName>");

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDeployment_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            Response response = await client.GetDeploymentAsync("<projectName>", "<deploymentName>");

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDeployment_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            Response response = await client.GetDeploymentAsync("<projectName>", "<deploymentName>");

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DeployProject()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            var data = new { };

            Response response = client.DeployProject("<projectName>", "<deploymentName>", RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DeployProject_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            var data = new { };

            Response response = client.DeployProject("<projectName>", "<deploymentName>", RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DeployProject_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            var data = new { };

            Response response = await client.DeployProjectAsync("<projectName>", "<deploymentName>", RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DeployProject_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            var data = new { };

            Response response = await client.DeployProjectAsync("<projectName>", "<deploymentName>", RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DeleteDeployment()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            Response response = client.DeleteDeployment("<projectName>", "<deploymentName>");

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DeleteDeployment_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            Response response = client.DeleteDeployment("<projectName>", "<deploymentName>");

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DeleteDeployment_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            Response response = await client.DeleteDeploymentAsync("<projectName>", "<deploymentName>");

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DeleteDeployment_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            Response response = await client.DeleteDeploymentAsync("<projectName>", "<deploymentName>");

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("name").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SwapDeployments()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            var data = new
            {
                firstDeploymentName = "<firstDeploymentName>",
                secondDeploymentName = "<secondDeploymentName>",
            };

            Response response = client.SwapDeployments("<projectName>", RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_SwapDeployments_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            var data = new
            {
                firstDeploymentName = "<firstDeploymentName>",
                secondDeploymentName = "<secondDeploymentName>",
            };

            Response response = client.SwapDeployments("<projectName>", RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SwapDeployments_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            var data = new
            {
                firstDeploymentName = "<firstDeploymentName>",
                secondDeploymentName = "<secondDeploymentName>",
            };

            Response response = await client.SwapDeploymentsAsync("<projectName>", RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_SwapDeployments_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            var data = new
            {
                firstDeploymentName = "<firstDeploymentName>",
                secondDeploymentName = "<secondDeploymentName>",
            };

            Response response = await client.SwapDeploymentsAsync("<projectName>", RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDeploymentStatus()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            Response response = client.GetDeploymentStatus("<projectName>", "<deploymentName>", "<jobId>", new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("jobId").ToString());
            Console.WriteLine(result.GetProperty("createdDateTime").ToString());
            Console.WriteLine(result.GetProperty("lastUpdatedDateTime").ToString());
            Console.WriteLine(result.GetProperty("expirationDateTime").ToString());
            Console.WriteLine(result.GetProperty("status").ToString());
            Console.WriteLine(result.GetProperty("warnings")[0].GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("warnings")[0].GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("errors").GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("errors").GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDeploymentStatus_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            Response response = client.GetDeploymentStatus("<projectName>", "<deploymentName>", "<jobId>", new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("jobId").ToString());
            Console.WriteLine(result.GetProperty("createdDateTime").ToString());
            Console.WriteLine(result.GetProperty("lastUpdatedDateTime").ToString());
            Console.WriteLine(result.GetProperty("expirationDateTime").ToString());
            Console.WriteLine(result.GetProperty("status").ToString());
            Console.WriteLine(result.GetProperty("warnings")[0].GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("warnings")[0].GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("errors").GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("errors").GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("errors").GetProperty("target").ToString());
            Console.WriteLine(result.GetProperty("errors").GetProperty("innererror").GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDeploymentStatus_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            Response response = await client.GetDeploymentStatusAsync("<projectName>", "<deploymentName>", "<jobId>", new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("jobId").ToString());
            Console.WriteLine(result.GetProperty("createdDateTime").ToString());
            Console.WriteLine(result.GetProperty("lastUpdatedDateTime").ToString());
            Console.WriteLine(result.GetProperty("expirationDateTime").ToString());
            Console.WriteLine(result.GetProperty("status").ToString());
            Console.WriteLine(result.GetProperty("warnings")[0].GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("warnings")[0].GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("errors").GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("errors").GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDeploymentStatus_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            Response response = await client.GetDeploymentStatusAsync("<projectName>", "<deploymentName>", "<jobId>", new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("jobId").ToString());
            Console.WriteLine(result.GetProperty("createdDateTime").ToString());
            Console.WriteLine(result.GetProperty("lastUpdatedDateTime").ToString());
            Console.WriteLine(result.GetProperty("expirationDateTime").ToString());
            Console.WriteLine(result.GetProperty("status").ToString());
            Console.WriteLine(result.GetProperty("warnings")[0].GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("warnings")[0].GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("errors").GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("errors").GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("errors").GetProperty("target").ToString());
            Console.WriteLine(result.GetProperty("errors").GetProperty("innererror").GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDeploymentStatus_Convenience_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            var result = await client.GetDeploymentStatusAsync("<projectName>", "<deploymentName>", "<jobId>");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetSwapDeploymentsStatus()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            Response response = client.GetSwapDeploymentsStatus("<projectName>", "<deploymentName>", "<jobId>", new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("jobId").ToString());
            Console.WriteLine(result.GetProperty("createdDateTime").ToString());
            Console.WriteLine(result.GetProperty("lastUpdatedDateTime").ToString());
            Console.WriteLine(result.GetProperty("expirationDateTime").ToString());
            Console.WriteLine(result.GetProperty("status").ToString());
            Console.WriteLine(result.GetProperty("warnings")[0].GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("warnings")[0].GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("errors").GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("errors").GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetSwapDeploymentsStatus_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            Response response = client.GetSwapDeploymentsStatus("<projectName>", "<deploymentName>", "<jobId>", new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("jobId").ToString());
            Console.WriteLine(result.GetProperty("createdDateTime").ToString());
            Console.WriteLine(result.GetProperty("lastUpdatedDateTime").ToString());
            Console.WriteLine(result.GetProperty("expirationDateTime").ToString());
            Console.WriteLine(result.GetProperty("status").ToString());
            Console.WriteLine(result.GetProperty("warnings")[0].GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("warnings")[0].GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("errors").GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("errors").GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("errors").GetProperty("target").ToString());
            Console.WriteLine(result.GetProperty("errors").GetProperty("innererror").GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetSwapDeploymentsStatus_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            Response response = await client.GetSwapDeploymentsStatusAsync("<projectName>", "<deploymentName>", "<jobId>", new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("jobId").ToString());
            Console.WriteLine(result.GetProperty("createdDateTime").ToString());
            Console.WriteLine(result.GetProperty("lastUpdatedDateTime").ToString());
            Console.WriteLine(result.GetProperty("expirationDateTime").ToString());
            Console.WriteLine(result.GetProperty("status").ToString());
            Console.WriteLine(result.GetProperty("warnings")[0].GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("warnings")[0].GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("errors").GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("errors").GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetSwapDeploymentsStatus_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            Response response = await client.GetSwapDeploymentsStatusAsync("<projectName>", "<deploymentName>", "<jobId>", new RequestContext());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("jobId").ToString());
            Console.WriteLine(result.GetProperty("createdDateTime").ToString());
            Console.WriteLine(result.GetProperty("lastUpdatedDateTime").ToString());
            Console.WriteLine(result.GetProperty("expirationDateTime").ToString());
            Console.WriteLine(result.GetProperty("status").ToString());
            Console.WriteLine(result.GetProperty("warnings")[0].GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("warnings")[0].GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("errors").GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("errors").GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("errors").GetProperty("target").ToString());
            Console.WriteLine(result.GetProperty("errors").GetProperty("innererror").GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetSwapDeploymentsStatus_Convenience_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            var result = await client.GetSwapDeploymentsStatusAsync("<projectName>", "<deploymentName>", "<jobId>");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetProjects()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            foreach (var item in client.GetProjects())
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
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            foreach (var item in client.GetProjects())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("projectName").ToString());
                Console.WriteLine(result.GetProperty("projectKind").ToString());
                Console.WriteLine(result.GetProperty("storageInputContainerName").ToString());
                Console.WriteLine(result.GetProperty("settings").GetProperty("<test>").ToString());
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
        public async Task Example_GetProjects_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            await foreach (var item in client.GetProjectsAsync())
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
        public async Task Example_GetProjects_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            await foreach (var item in client.GetProjectsAsync())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("projectName").ToString());
                Console.WriteLine(result.GetProperty("projectKind").ToString());
                Console.WriteLine(result.GetProperty("storageInputContainerName").ToString());
                Console.WriteLine(result.GetProperty("settings").GetProperty("<test>").ToString());
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
        public void Example_GetDeployments()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            foreach (var item in client.GetDeployments("<projectName>"))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("name").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDeployments_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            foreach (var item in client.GetDeployments("<projectName>"))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("name").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDeployments_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            await foreach (var item in client.GetDeploymentsAsync("<projectName>"))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("name").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDeployments_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            await foreach (var item in client.GetDeploymentsAsync("<projectName>"))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("name").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetSupportedLanguages()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            foreach (var item in client.GetSupportedLanguages())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("languageName").ToString());
                Console.WriteLine(result.GetProperty("languageCode").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetSupportedLanguages_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            foreach (var item in client.GetSupportedLanguages(1234, 1234, 1234))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("languageName").ToString());
                Console.WriteLine(result.GetProperty("languageCode").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetSupportedLanguages_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            await foreach (var item in client.GetSupportedLanguagesAsync())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("languageName").ToString());
                Console.WriteLine(result.GetProperty("languageCode").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetSupportedLanguages_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            await foreach (var item in client.GetSupportedLanguagesAsync(1234, 1234, 1234))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("languageName").ToString());
                Console.WriteLine(result.GetProperty("languageCode").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetTrainingConfigVersions()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            foreach (var item in client.GetTrainingConfigVersions())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("trainingConfigVersionStr").ToString());
                Console.WriteLine(result.GetProperty("modelExpirationDate").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetTrainingConfigVersions_AllParameters()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            foreach (var item in client.GetTrainingConfigVersions(1234, 1234, 1234))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("trainingConfigVersionStr").ToString());
                Console.WriteLine(result.GetProperty("modelExpirationDate").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetTrainingConfigVersions_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            await foreach (var item in client.GetTrainingConfigVersionsAsync())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("trainingConfigVersionStr").ToString());
                Console.WriteLine(result.GetProperty("modelExpirationDate").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetTrainingConfigVersions_AllParameters_Async()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            await foreach (var item in client.GetTrainingConfigVersionsAsync(1234, 1234, 1234))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("trainingConfigVersionStr").ToString());
                Console.WriteLine(result.GetProperty("modelExpirationDate").ToString());
            }
        }
    }
}
