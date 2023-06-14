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
    public class Samples_MultipleResponsesClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get200Model204NoModelDefaultError200Valid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.Get200Model204NoModelDefaultError200Valid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get200Model204NoModelDefaultError200Valid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.Get200Model204NoModelDefaultError200Valid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("statusCode").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get200Model204NoModelDefaultError200Valid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.Get200Model204NoModelDefaultError200ValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get200Model204NoModelDefaultError200Valid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.Get200Model204NoModelDefaultError200ValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("statusCode").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get200Model204NoModelDefaultError204Valid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.Get200Model204NoModelDefaultError204Valid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get200Model204NoModelDefaultError204Valid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.Get200Model204NoModelDefaultError204Valid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("statusCode").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get200Model204NoModelDefaultError204Valid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.Get200Model204NoModelDefaultError204ValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get200Model204NoModelDefaultError204Valid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.Get200Model204NoModelDefaultError204ValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("statusCode").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get200Model204NoModelDefaultError201Invalid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.Get200Model204NoModelDefaultError201Invalid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get200Model204NoModelDefaultError201Invalid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.Get200Model204NoModelDefaultError201Invalid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("statusCode").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get200Model204NoModelDefaultError201Invalid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.Get200Model204NoModelDefaultError201InvalidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get200Model204NoModelDefaultError201Invalid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.Get200Model204NoModelDefaultError201InvalidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("statusCode").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get200Model204NoModelDefaultError202None()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.Get200Model204NoModelDefaultError202None();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get200Model204NoModelDefaultError202None_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.Get200Model204NoModelDefaultError202None();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("statusCode").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get200Model204NoModelDefaultError202None_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.Get200Model204NoModelDefaultError202NoneAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get200Model204NoModelDefaultError202None_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.Get200Model204NoModelDefaultError202NoneAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("statusCode").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get200Model204NoModelDefaultError400Valid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.Get200Model204NoModelDefaultError400Valid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get200Model204NoModelDefaultError400Valid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.Get200Model204NoModelDefaultError400Valid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("statusCode").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get200Model204NoModelDefaultError400Valid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.Get200Model204NoModelDefaultError400ValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get200Model204NoModelDefaultError400Valid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.Get200Model204NoModelDefaultError400ValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("statusCode").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get200Model201ModelDefaultError200Valid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.Get200Model201ModelDefaultError200Valid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get200Model201ModelDefaultError200Valid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.Get200Model201ModelDefaultError200Valid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("statusCode").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get200Model201ModelDefaultError200Valid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.Get200Model201ModelDefaultError200ValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get200Model201ModelDefaultError200Valid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.Get200Model201ModelDefaultError200ValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("statusCode").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get200Model201ModelDefaultError201Valid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.Get200Model201ModelDefaultError201Valid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get200Model201ModelDefaultError201Valid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.Get200Model201ModelDefaultError201Valid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("statusCode").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get200Model201ModelDefaultError201Valid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.Get200Model201ModelDefaultError201ValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get200Model201ModelDefaultError201Valid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.Get200Model201ModelDefaultError201ValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("statusCode").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get200Model201ModelDefaultError400Valid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.Get200Model201ModelDefaultError400Valid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get200Model201ModelDefaultError400Valid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.Get200Model201ModelDefaultError400Valid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("statusCode").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get200Model201ModelDefaultError400Valid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.Get200Model201ModelDefaultError400ValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get200Model201ModelDefaultError400Valid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.Get200Model201ModelDefaultError400ValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("statusCode").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get200ModelA201ModelC404ModelDDefaultError200Valid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.Get200ModelA201ModelC404ModelDDefaultError200Valid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get200ModelA201ModelC404ModelDDefaultError200Valid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.Get200ModelA201ModelC404ModelDDefaultError200Valid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("statusCode").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get200ModelA201ModelC404ModelDDefaultError200Valid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.Get200ModelA201ModelC404ModelDDefaultError200ValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get200ModelA201ModelC404ModelDDefaultError200Valid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.Get200ModelA201ModelC404ModelDDefaultError200ValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("statusCode").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get200ModelA201ModelC404ModelDDefaultError201Valid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.Get200ModelA201ModelC404ModelDDefaultError201Valid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get200ModelA201ModelC404ModelDDefaultError201Valid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.Get200ModelA201ModelC404ModelDDefaultError201Valid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("statusCode").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get200ModelA201ModelC404ModelDDefaultError201Valid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.Get200ModelA201ModelC404ModelDDefaultError201ValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get200ModelA201ModelC404ModelDDefaultError201Valid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.Get200ModelA201ModelC404ModelDDefaultError201ValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("statusCode").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get200ModelA201ModelC404ModelDDefaultError404Valid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.Get200ModelA201ModelC404ModelDDefaultError404Valid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get200ModelA201ModelC404ModelDDefaultError404Valid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.Get200ModelA201ModelC404ModelDDefaultError404Valid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("statusCode").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get200ModelA201ModelC404ModelDDefaultError404Valid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.Get200ModelA201ModelC404ModelDDefaultError404ValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get200ModelA201ModelC404ModelDDefaultError404Valid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.Get200ModelA201ModelC404ModelDDefaultError404ValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("statusCode").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get200ModelA201ModelC404ModelDDefaultError400Valid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.Get200ModelA201ModelC404ModelDDefaultError400Valid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get200ModelA201ModelC404ModelDDefaultError400Valid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.Get200ModelA201ModelC404ModelDDefaultError400Valid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("statusCode").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get200ModelA201ModelC404ModelDDefaultError400Valid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.Get200ModelA201ModelC404ModelDDefaultError400ValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get200ModelA201ModelC404ModelDDefaultError400Valid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.Get200ModelA201ModelC404ModelDDefaultError400ValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("statusCode").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get202None204NoneDefaultError202None()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.Get202None204NoneDefaultError202None();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get202None204NoneDefaultError202None_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.Get202None204NoneDefaultError202None();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get202None204NoneDefaultError202None_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.Get202None204NoneDefaultError202NoneAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get202None204NoneDefaultError202None_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.Get202None204NoneDefaultError202NoneAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get202None204NoneDefaultError204None()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.Get202None204NoneDefaultError204None();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get202None204NoneDefaultError204None_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.Get202None204NoneDefaultError204None();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get202None204NoneDefaultError204None_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.Get202None204NoneDefaultError204NoneAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get202None204NoneDefaultError204None_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.Get202None204NoneDefaultError204NoneAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get202None204NoneDefaultError400Valid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.Get202None204NoneDefaultError400Valid();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get202None204NoneDefaultError400Valid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.Get202None204NoneDefaultError400Valid();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get202None204NoneDefaultError400Valid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.Get202None204NoneDefaultError400ValidAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get202None204NoneDefaultError400Valid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.Get202None204NoneDefaultError400ValidAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get202None204NoneDefaultNone202Invalid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.Get202None204NoneDefaultNone202Invalid();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get202None204NoneDefaultNone202Invalid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.Get202None204NoneDefaultNone202Invalid();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get202None204NoneDefaultNone202Invalid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.Get202None204NoneDefaultNone202InvalidAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get202None204NoneDefaultNone202Invalid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.Get202None204NoneDefaultNone202InvalidAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get202None204NoneDefaultNone204None()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.Get202None204NoneDefaultNone204None();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get202None204NoneDefaultNone204None_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.Get202None204NoneDefaultNone204None();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get202None204NoneDefaultNone204None_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.Get202None204NoneDefaultNone204NoneAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get202None204NoneDefaultNone204None_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.Get202None204NoneDefaultNone204NoneAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get202None204NoneDefaultNone400None()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.Get202None204NoneDefaultNone400None();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get202None204NoneDefaultNone400None_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.Get202None204NoneDefaultNone400None();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get202None204NoneDefaultNone400None_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.Get202None204NoneDefaultNone400NoneAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get202None204NoneDefaultNone400None_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.Get202None204NoneDefaultNone400NoneAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get202None204NoneDefaultNone400Invalid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.Get202None204NoneDefaultNone400Invalid();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get202None204NoneDefaultNone400Invalid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.Get202None204NoneDefaultNone400Invalid();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get202None204NoneDefaultNone400Invalid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.Get202None204NoneDefaultNone400InvalidAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get202None204NoneDefaultNone400Invalid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.Get202None204NoneDefaultNone400InvalidAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDefaultModelA200Valid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.GetDefaultModelA200Valid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDefaultModelA200Valid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.GetDefaultModelA200Valid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("statusCode").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDefaultModelA200Valid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.GetDefaultModelA200ValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDefaultModelA200Valid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.GetDefaultModelA200ValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("statusCode").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDefaultModelA200None()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.GetDefaultModelA200None();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDefaultModelA200None_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.GetDefaultModelA200None();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("statusCode").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDefaultModelA200None_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.GetDefaultModelA200NoneAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDefaultModelA200None_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.GetDefaultModelA200NoneAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("statusCode").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDefaultModelA400Valid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.GetDefaultModelA400Valid();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDefaultModelA400Valid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.GetDefaultModelA400Valid();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDefaultModelA400Valid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.GetDefaultModelA400ValidAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDefaultModelA400Valid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.GetDefaultModelA400ValidAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDefaultModelA400None()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.GetDefaultModelA400None();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDefaultModelA400None_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.GetDefaultModelA400None();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDefaultModelA400None_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.GetDefaultModelA400NoneAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDefaultModelA400None_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.GetDefaultModelA400NoneAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDefaultNone200Invalid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.GetDefaultNone200Invalid();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDefaultNone200Invalid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.GetDefaultNone200Invalid();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDefaultNone200Invalid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.GetDefaultNone200InvalidAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDefaultNone200Invalid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.GetDefaultNone200InvalidAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDefaultNone200None()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.GetDefaultNone200None();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDefaultNone200None_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.GetDefaultNone200None();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDefaultNone200None_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.GetDefaultNone200NoneAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDefaultNone200None_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.GetDefaultNone200NoneAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDefaultNone400Invalid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.GetDefaultNone400Invalid();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDefaultNone400Invalid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.GetDefaultNone400Invalid();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDefaultNone400Invalid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.GetDefaultNone400InvalidAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDefaultNone400Invalid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.GetDefaultNone400InvalidAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDefaultNone400None()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.GetDefaultNone400None();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDefaultNone400None_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.GetDefaultNone400None();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDefaultNone400None_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.GetDefaultNone400NoneAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDefaultNone400None_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.GetDefaultNone400NoneAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get200ModelA200None()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.Get200ModelA200None();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get200ModelA200None_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.Get200ModelA200None();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("statusCode").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get200ModelA200None_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.Get200ModelA200NoneAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get200ModelA200None_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.Get200ModelA200NoneAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("statusCode").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get200ModelA200Valid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.Get200ModelA200Valid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get200ModelA200Valid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.Get200ModelA200Valid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("statusCode").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get200ModelA200Valid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.Get200ModelA200ValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get200ModelA200Valid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.Get200ModelA200ValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("statusCode").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get200ModelA200Invalid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.Get200ModelA200Invalid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get200ModelA200Invalid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.Get200ModelA200Invalid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("statusCode").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get200ModelA200Invalid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.Get200ModelA200InvalidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get200ModelA200Invalid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.Get200ModelA200InvalidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("statusCode").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get200ModelA400None()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.Get200ModelA400None();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get200ModelA400None_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.Get200ModelA400None();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("statusCode").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get200ModelA400None_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.Get200ModelA400NoneAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get200ModelA400None_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.Get200ModelA400NoneAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("statusCode").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get200ModelA400Valid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.Get200ModelA400Valid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get200ModelA400Valid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.Get200ModelA400Valid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("statusCode").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get200ModelA400Valid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.Get200ModelA400ValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get200ModelA400Valid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.Get200ModelA400ValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("statusCode").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get200ModelA400Invalid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.Get200ModelA400Invalid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get200ModelA400Invalid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.Get200ModelA400Invalid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("statusCode").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get200ModelA400Invalid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.Get200ModelA400InvalidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get200ModelA400Invalid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.Get200ModelA400InvalidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("statusCode").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get200ModelA202Valid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.Get200ModelA202Valid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Get200ModelA202Valid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = client.Get200ModelA202Valid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("statusCode").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get200ModelA202Valid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.Get200ModelA202ValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Get200ModelA202Valid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MultipleResponsesClient(credential);

            Response response = await client.Get200ModelA202ValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("statusCode").ToString());
        }
    }
}
