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
using NUnit.Framework;
using _Specs_.Azure.Example.Basic.Models;

namespace _Specs_.Azure.Example.Basic.Samples
{
    public partial class Samples_AzureExampleClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_AzureExampleClient_BasicAction_BasicAction()
        {
            AzureExampleClient client = new AzureExampleClient();

            using RequestContent content = RequestContent.Create(new
            {
                stringProperty = "text",
                modelProperty = new
                {
                    int32Property = 1,
                    float32Property = 1.5F,
                    enumProperty = "EnumValue1",
                },
                arrayProperty = new object[]
            {
"item"
            },
                recordProperty = new
                {
                    record = "value",
                },
            });
            Response response = client.BasicAction("query", "header", content);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result.GetProperty("stringProperty").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_AzureExampleClient_BasicAction_BasicAction_Async()
        {
            AzureExampleClient client = new AzureExampleClient();

            using RequestContent content = RequestContent.Create(new
            {
                stringProperty = "text",
                modelProperty = new
                {
                    int32Property = 1,
                    float32Property = 1.5F,
                    enumProperty = "EnumValue1",
                },
                arrayProperty = new object[]
            {
"item"
            },
                recordProperty = new
                {
                    record = "value",
                },
            });
            Response response = await client.BasicActionAsync("query", "header", content);

            JsonElement result = JsonDocument.Parse(response.ContentStream, new JsonDocumentOptions { MaxDepth = 256 }).RootElement;
            Console.WriteLine(result.GetProperty("stringProperty").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_AzureExampleClient_BasicAction_BasicAction_Convenience()
        {
            AzureExampleClient client = new AzureExampleClient();

            ActionRequest body = new ActionRequest("text")
            {
                ModelProperty = new Model
                {
                    Int32Property = 1,
                    Float32Property = 1.5F,
                    EnumProperty = Models.Enum.EnumValue1,
                },
                ArrayProperty = { "item" },
                RecordProperty =
{
["record"] = "value"
},
            };
            Response<ActionResponse> response = client.BasicAction("query", "header", body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_AzureExampleClient_BasicAction_BasicAction_Convenience_Async()
        {
            AzureExampleClient client = new AzureExampleClient();

            ActionRequest body = new ActionRequest("text")
            {
                ModelProperty = new Model
                {
                    Int32Property = 1,
                    Float32Property = 1.5F,
                    EnumProperty = Models.Enum.EnumValue1,
                },
                ArrayProperty = { "item" },
                RecordProperty =
{
["record"] = "value"
},
            };
            Response<ActionResponse> response = await client.BasicActionAsync("query", "header", body);
        }
    }
}
