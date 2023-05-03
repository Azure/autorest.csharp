// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.IO;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.Identity;
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
        public void Example_Export()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            Response response = client.Export("<projectName>", "<projectFileVersion>");
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
        public void Example_GetProjects()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            foreach (var data in client.GetProjects())
            {
                JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
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
        public void Example_GetDeployments()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            foreach (var data in client.GetDeployments("<projectName>"))
            {
                JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
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
        public void Example_GetSupportedLanguages()
        {
            var endpoint = new Uri("<https://my-service.azure.com>");
            var client = new AuthoringClient(endpoint);

            foreach (var data in client.GetSupportedLanguages())
            {
                JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
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

            foreach (var data in client.GetTrainingConfigVersions())
            {
                JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("trainingConfigVersionStr").ToString());
                Console.WriteLine(result.GetProperty("modelExpirationDate").ToString());
            }
        }
    }
}
