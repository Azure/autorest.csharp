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
using dpg_update1_LowLevel;

namespace dpg_update1_LowLevel.Samples
{
    public class Samples_ParamsClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_HeadNoParams()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParamsClient client = new ParamsClient(credential);

            Response response = client.HeadNoParams(null, null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_HeadNoParams_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParamsClient client = new ParamsClient(credential);

            Response response = client.HeadNoParams("<newParameter>", null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_HeadNoParams_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParamsClient client = new ParamsClient(credential);

            Response response = await client.HeadNoParamsAsync(null, null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_HeadNoParams_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParamsClient client = new ParamsClient(credential);

            Response response = await client.HeadNoParamsAsync("<newParameter>", null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetRequired()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParamsClient client = new ParamsClient(credential);

            Response response = client.GetRequired("<parameter>", null, null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetRequired_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParamsClient client = new ParamsClient(credential);

            Response response = client.GetRequired("<parameter>", "<newParameter>", null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetRequired_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParamsClient client = new ParamsClient(credential);

            Response response = await client.GetRequiredAsync("<parameter>", null, null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetRequired_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParamsClient client = new ParamsClient(credential);

            Response response = await client.GetRequiredAsync("<parameter>", "<newParameter>", null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutRequiredOptional()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParamsClient client = new ParamsClient(credential);

            Response response = client.PutRequiredOptional("<requiredParam>", null, null, null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutRequiredOptional_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParamsClient client = new ParamsClient(credential);

            Response response = client.PutRequiredOptional("<requiredParam>", "<optionalParam>", "<newParameter>", null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutRequiredOptional_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParamsClient client = new ParamsClient(credential);

            Response response = await client.PutRequiredOptionalAsync("<requiredParam>", null, null, null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutRequiredOptional_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParamsClient client = new ParamsClient(credential);

            Response response = await client.PutRequiredOptionalAsync("<requiredParam>", "<optionalParam>", "<newParameter>", null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PostParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParamsClient client = new ParamsClient(credential);

            RequestContent content = RequestContent.Create(new
            {
                url = "<url>",
            });
            Response response = client.PostParameters(content, new ContentType("application/json"));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PostParameters_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParamsClient client = new ParamsClient(credential);

            RequestContent content = RequestContent.Create(new
            {
                url = "<url>",
            });
            Response response = client.PostParameters(content, new ContentType("application/json"));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PostParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParamsClient client = new ParamsClient(credential);

            RequestContent content = RequestContent.Create(new
            {
                url = "<url>",
            });
            Response response = await client.PostParametersAsync(content, new ContentType("application/json"));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PostParameters_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParamsClient client = new ParamsClient(credential);

            RequestContent content = RequestContent.Create(new
            {
                url = "<url>",
            });
            Response response = await client.PostParametersAsync(content, new ContentType("application/json"));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DeleteParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParamsClient client = new ParamsClient(credential);

            Response response = client.DeleteParameters();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DeleteParameters_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParamsClient client = new ParamsClient(credential);

            Response response = client.DeleteParameters();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DeleteParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParamsClient client = new ParamsClient(credential);

            Response response = await client.DeleteParametersAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DeleteParameters_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParamsClient client = new ParamsClient(credential);

            Response response = await client.DeleteParametersAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetOptional()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParamsClient client = new ParamsClient(credential);

            Response response = client.GetOptional(null, null, null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetOptional_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParamsClient client = new ParamsClient(credential);

            Response response = client.GetOptional("<optionalParam>", "<newParameter>", null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetOptional_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParamsClient client = new ParamsClient(credential);

            Response response = await client.GetOptionalAsync(null, null, null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetOptional_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParamsClient client = new ParamsClient(credential);

            Response response = await client.GetOptionalAsync("<optionalParam>", "<newParameter>", null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNewOperation()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParamsClient client = new ParamsClient(credential);

            Response response = client.GetNewOperation(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNewOperation_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParamsClient client = new ParamsClient(credential);

            Response response = client.GetNewOperation(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNewOperation_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParamsClient client = new ParamsClient(credential);

            Response response = await client.GetNewOperationAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNewOperation_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParamsClient client = new ParamsClient(credential);

            Response response = await client.GetNewOperationAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }
    }
}
