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

namespace httpInfrastructure_LowLevel.Samples
{
    public class Samples_HttpFailureClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetEmptyError()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpFailureClient(credential);

            Response response = client.GetEmptyError();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetEmptyError_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpFailureClient(credential);

            Response response = client.GetEmptyError();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetEmptyError_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpFailureClient(credential);

            Response response = await client.GetEmptyErrorAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetEmptyError_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpFailureClient(credential);

            Response response = await client.GetEmptyErrorAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNoModelError()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpFailureClient(credential);

            Response response = client.GetNoModelError();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNoModelError_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpFailureClient(credential);

            Response response = client.GetNoModelError();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNoModelError_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpFailureClient(credential);

            Response response = await client.GetNoModelErrorAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNoModelError_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpFailureClient(credential);

            Response response = await client.GetNoModelErrorAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNoModelEmpty()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpFailureClient(credential);

            Response response = client.GetNoModelEmpty();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNoModelEmpty_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpFailureClient(credential);

            Response response = client.GetNoModelEmpty();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNoModelEmpty_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpFailureClient(credential);

            Response response = await client.GetNoModelEmptyAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNoModelEmpty_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new HttpFailureClient(credential);

            Response response = await client.GetNoModelEmptyAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }
    }
}
