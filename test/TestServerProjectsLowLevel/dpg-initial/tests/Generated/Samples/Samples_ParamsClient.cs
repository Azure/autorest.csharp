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
        public void Example_GetOptional()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ParamsClient(credential);

            Response response = client.GetOptional();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }
    }
}
