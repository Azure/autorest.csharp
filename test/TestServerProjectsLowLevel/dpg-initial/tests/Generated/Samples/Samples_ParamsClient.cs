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
using dpg_initial_LowLevel;

namespace dpg_initial_LowLevel.Samples
{
    public partial class Samples_ParamsClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_HeadNoParams()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParamsClient client = new ParamsClient(credential);

            Response response = client.HeadNoParams(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_HeadNoParams_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParamsClient client = new ParamsClient(credential);

            Response response = await client.HeadNoParamsAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_HeadNoParams_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParamsClient client = new ParamsClient(credential);

            Response response = client.HeadNoParams(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_HeadNoParams_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParamsClient client = new ParamsClient(credential);

            Response response = await client.HeadNoParamsAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetRequired()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParamsClient client = new ParamsClient(credential);

            Response response = client.GetRequired("<parameter>", null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetRequired_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParamsClient client = new ParamsClient(credential);

            Response response = await client.GetRequiredAsync("<parameter>", null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetRequired_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParamsClient client = new ParamsClient(credential);

            Response response = client.GetRequired("<parameter>", null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetRequired_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParamsClient client = new ParamsClient(credential);

            Response response = await client.GetRequiredAsync("<parameter>", null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutRequiredOptional()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParamsClient client = new ParamsClient(credential);

            Response response = client.PutRequiredOptional("<requiredParam>", null, null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutRequiredOptional_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParamsClient client = new ParamsClient(credential);

            Response response = await client.PutRequiredOptionalAsync("<requiredParam>", null, null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutRequiredOptional_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParamsClient client = new ParamsClient(credential);

            Response response = client.PutRequiredOptional("<requiredParam>", "<optionalParam>", null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutRequiredOptional_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParamsClient client = new ParamsClient(credential);

            Response response = await client.PutRequiredOptionalAsync("<requiredParam>", "<optionalParam>", null);

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
            Response response = client.PostParameters(content);

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
            Response response = await client.PostParametersAsync(content);

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
            Response response = client.PostParameters(content);

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
            Response response = await client.PostParametersAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetOptional()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParamsClient client = new ParamsClient(credential);

            Response response = client.GetOptional(null, null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetOptional_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParamsClient client = new ParamsClient(credential);

            Response response = await client.GetOptionalAsync(null, null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetOptional_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParamsClient client = new ParamsClient(credential);

            Response response = client.GetOptional("<optionalParam>", null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetOptional_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            ParamsClient client = new ParamsClient(credential);

            Response response = await client.GetOptionalAsync("<optionalParam>", null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }
    }
}
