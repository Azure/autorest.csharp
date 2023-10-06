// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;
using SecurityDefinition_LowLevel;

namespace SecurityDefinition_LowLevel.Samples
{
    public partial class Samples_SecurityDefinitionClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Operation_ShortVersion()
        {
            Uri endpoint = new Uri("<endpoint>");
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("SecurityDefinitionClient_KEY"));
            SecurityDefinitionClient client = new SecurityDefinitionClient(endpoint, credential);

            RequestContent content = RequestContent.Create(new object());
            Response response = client.Operation(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Operation_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("SecurityDefinitionClient_KEY"));
            SecurityDefinitionClient client = new SecurityDefinitionClient(endpoint, credential);

            RequestContent content = RequestContent.Create(new object());
            Response response = await client.OperationAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Operation_AllParameters()
        {
            Uri endpoint = new Uri("<endpoint>");
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("SecurityDefinitionClient_KEY"));
            SecurityDefinitionClient client = new SecurityDefinitionClient(endpoint, credential);

            RequestContent content = RequestContent.Create(new
            {
                Code = "<Code>",
                Status = "<Status>",
            });
            Response response = client.Operation(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Operation_AllParameters_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("SecurityDefinitionClient_KEY"));
            SecurityDefinitionClient client = new SecurityDefinitionClient(endpoint, credential);

            RequestContent content = RequestContent.Create(new
            {
                Code = "<Code>",
                Status = "<Status>",
            });
            Response response = await client.OperationAsync(content);

            Console.WriteLine(response.Status);
        }
    }
}
