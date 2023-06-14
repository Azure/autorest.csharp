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
using NUnit.Framework;

namespace dpg_initial_LowLevel.Samples
{
    public class Samples_ParamsClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_HeadNoParams()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ParamsClient(credential);

            Response response = client.HeadNoParams();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_HeadNoParams_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ParamsClient(credential);

            Response response = client.HeadNoParams();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_HeadNoParams_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ParamsClient(credential);

            Response response = await client.HeadNoParamsAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_HeadNoParams_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ParamsClient(credential);

            Response response = await client.HeadNoParamsAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetRequired()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ParamsClient(credential);

            Response response = client.GetRequired("<parameter>");

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetRequired_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ParamsClient(credential);

            Response response = client.GetRequired("<parameter>");

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetRequired_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ParamsClient(credential);

            Response response = await client.GetRequiredAsync("<parameter>");

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetRequired_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ParamsClient(credential);

            Response response = await client.GetRequiredAsync("<parameter>");

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutRequiredOptional()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ParamsClient(credential);

            Response response = client.PutRequiredOptional("<requiredParam>");

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutRequiredOptional_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ParamsClient(credential);

            Response response = client.PutRequiredOptional("<requiredParam>", "<optionalParam>");

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutRequiredOptional_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ParamsClient(credential);

            Response response = await client.PutRequiredOptionalAsync("<requiredParam>");

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutRequiredOptional_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ParamsClient(credential);

            Response response = await client.PutRequiredOptionalAsync("<requiredParam>", "<optionalParam>");

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PostParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ParamsClient(credential);

            var data = new
            {
                url = "<url>",
            };

            Response response = client.PostParameters(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PostParameters_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ParamsClient(credential);

            var data = new
            {
                url = "<url>",
            };

            Response response = client.PostParameters(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PostParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ParamsClient(credential);

            var data = new
            {
                url = "<url>",
            };

            Response response = await client.PostParametersAsync(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PostParameters_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ParamsClient(credential);

            var data = new
            {
                url = "<url>",
            };

            Response response = await client.PostParametersAsync(RequestContent.Create(data));

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetOptional()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ParamsClient(credential);

            Response response = client.GetOptional();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetOptional_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ParamsClient(credential);

            Response response = client.GetOptional("<optionalParam>");

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetOptional_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ParamsClient(credential);

            Response response = await client.GetOptionalAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetOptional_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ParamsClient(credential);

            Response response = await client.GetOptionalAsync("<optionalParam>");

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }
    }
}
