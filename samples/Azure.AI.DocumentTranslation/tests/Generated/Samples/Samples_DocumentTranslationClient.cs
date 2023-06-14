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

namespace Azure.AI.DocumentTranslation.Samples
{
    public class Samples_DocumentTranslationClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDocumentStatus()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new DocumentTranslationClient("<https://my-service.azure.com>", credential);

            Response response = client.GetDocumentStatus(Guid.NewGuid(), Guid.NewGuid());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("sourcePath").ToString());
            Console.WriteLine(result.GetProperty("createdDateTimeUtc").ToString());
            Console.WriteLine(result.GetProperty("lastActionDateTimeUtc").ToString());
            Console.WriteLine(result.GetProperty("status").ToString());
            Console.WriteLine(result.GetProperty("to").ToString());
            Console.WriteLine(result.GetProperty("progress").ToString());
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDocumentStatus_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new DocumentTranslationClient("<https://my-service.azure.com>", credential);

            Response response = client.GetDocumentStatus(Guid.NewGuid(), Guid.NewGuid());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("path").ToString());
            Console.WriteLine(result.GetProperty("sourcePath").ToString());
            Console.WriteLine(result.GetProperty("createdDateTimeUtc").ToString());
            Console.WriteLine(result.GetProperty("lastActionDateTimeUtc").ToString());
            Console.WriteLine(result.GetProperty("status").ToString());
            Console.WriteLine(result.GetProperty("to").ToString());
            Console.WriteLine(result.GetProperty("error").GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("error").GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("error").GetProperty("target").ToString());
            Console.WriteLine(result.GetProperty("error").GetProperty("innerError").GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("error").GetProperty("innerError").GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("error").GetProperty("innerError").GetProperty("target").ToString());
            Console.WriteLine(result.GetProperty("progress").ToString());
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("characterCharged").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDocumentStatus_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new DocumentTranslationClient("<https://my-service.azure.com>", credential);

            Response response = await client.GetDocumentStatusAsync(Guid.NewGuid(), Guid.NewGuid());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("sourcePath").ToString());
            Console.WriteLine(result.GetProperty("createdDateTimeUtc").ToString());
            Console.WriteLine(result.GetProperty("lastActionDateTimeUtc").ToString());
            Console.WriteLine(result.GetProperty("status").ToString());
            Console.WriteLine(result.GetProperty("to").ToString());
            Console.WriteLine(result.GetProperty("progress").ToString());
            Console.WriteLine(result.GetProperty("id").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDocumentStatus_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new DocumentTranslationClient("<https://my-service.azure.com>", credential);

            Response response = await client.GetDocumentStatusAsync(Guid.NewGuid(), Guid.NewGuid());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("path").ToString());
            Console.WriteLine(result.GetProperty("sourcePath").ToString());
            Console.WriteLine(result.GetProperty("createdDateTimeUtc").ToString());
            Console.WriteLine(result.GetProperty("lastActionDateTimeUtc").ToString());
            Console.WriteLine(result.GetProperty("status").ToString());
            Console.WriteLine(result.GetProperty("to").ToString());
            Console.WriteLine(result.GetProperty("error").GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("error").GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("error").GetProperty("target").ToString());
            Console.WriteLine(result.GetProperty("error").GetProperty("innerError").GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("error").GetProperty("innerError").GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("error").GetProperty("innerError").GetProperty("target").ToString());
            Console.WriteLine(result.GetProperty("progress").ToString());
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("characterCharged").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetTranslationStatus()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new DocumentTranslationClient("<https://my-service.azure.com>", credential);

            Response response = client.GetTranslationStatus(Guid.NewGuid());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("createdDateTimeUtc").ToString());
            Console.WriteLine(result.GetProperty("lastActionDateTimeUtc").ToString());
            Console.WriteLine(result.GetProperty("status").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("total").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("failed").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("success").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("inProgress").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("notYetStarted").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("cancelled").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("totalCharacterCharged").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetTranslationStatus_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new DocumentTranslationClient("<https://my-service.azure.com>", credential);

            Response response = client.GetTranslationStatus(Guid.NewGuid());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("createdDateTimeUtc").ToString());
            Console.WriteLine(result.GetProperty("lastActionDateTimeUtc").ToString());
            Console.WriteLine(result.GetProperty("status").ToString());
            Console.WriteLine(result.GetProperty("error").GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("error").GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("error").GetProperty("target").ToString());
            Console.WriteLine(result.GetProperty("error").GetProperty("innerError").GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("error").GetProperty("innerError").GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("error").GetProperty("innerError").GetProperty("target").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("total").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("failed").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("success").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("inProgress").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("notYetStarted").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("cancelled").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("totalCharacterCharged").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetTranslationStatus_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new DocumentTranslationClient("<https://my-service.azure.com>", credential);

            Response response = await client.GetTranslationStatusAsync(Guid.NewGuid());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("createdDateTimeUtc").ToString());
            Console.WriteLine(result.GetProperty("lastActionDateTimeUtc").ToString());
            Console.WriteLine(result.GetProperty("status").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("total").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("failed").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("success").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("inProgress").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("notYetStarted").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("cancelled").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("totalCharacterCharged").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetTranslationStatus_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new DocumentTranslationClient("<https://my-service.azure.com>", credential);

            Response response = await client.GetTranslationStatusAsync(Guid.NewGuid());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("createdDateTimeUtc").ToString());
            Console.WriteLine(result.GetProperty("lastActionDateTimeUtc").ToString());
            Console.WriteLine(result.GetProperty("status").ToString());
            Console.WriteLine(result.GetProperty("error").GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("error").GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("error").GetProperty("target").ToString());
            Console.WriteLine(result.GetProperty("error").GetProperty("innerError").GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("error").GetProperty("innerError").GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("error").GetProperty("innerError").GetProperty("target").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("total").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("failed").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("success").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("inProgress").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("notYetStarted").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("cancelled").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("totalCharacterCharged").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CancelTranslation()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new DocumentTranslationClient("<https://my-service.azure.com>", credential);

            Response response = client.CancelTranslation(Guid.NewGuid());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("createdDateTimeUtc").ToString());
            Console.WriteLine(result.GetProperty("lastActionDateTimeUtc").ToString());
            Console.WriteLine(result.GetProperty("status").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("total").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("failed").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("success").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("inProgress").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("notYetStarted").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("cancelled").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("totalCharacterCharged").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CancelTranslation_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new DocumentTranslationClient("<https://my-service.azure.com>", credential);

            Response response = client.CancelTranslation(Guid.NewGuid());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("createdDateTimeUtc").ToString());
            Console.WriteLine(result.GetProperty("lastActionDateTimeUtc").ToString());
            Console.WriteLine(result.GetProperty("status").ToString());
            Console.WriteLine(result.GetProperty("error").GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("error").GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("error").GetProperty("target").ToString());
            Console.WriteLine(result.GetProperty("error").GetProperty("innerError").GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("error").GetProperty("innerError").GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("error").GetProperty("innerError").GetProperty("target").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("total").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("failed").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("success").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("inProgress").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("notYetStarted").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("cancelled").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("totalCharacterCharged").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CancelTranslation_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new DocumentTranslationClient("<https://my-service.azure.com>", credential);

            Response response = await client.CancelTranslationAsync(Guid.NewGuid());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("createdDateTimeUtc").ToString());
            Console.WriteLine(result.GetProperty("lastActionDateTimeUtc").ToString());
            Console.WriteLine(result.GetProperty("status").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("total").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("failed").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("success").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("inProgress").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("notYetStarted").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("cancelled").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("totalCharacterCharged").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CancelTranslation_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new DocumentTranslationClient("<https://my-service.azure.com>", credential);

            Response response = await client.CancelTranslationAsync(Guid.NewGuid());

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("id").ToString());
            Console.WriteLine(result.GetProperty("createdDateTimeUtc").ToString());
            Console.WriteLine(result.GetProperty("lastActionDateTimeUtc").ToString());
            Console.WriteLine(result.GetProperty("status").ToString());
            Console.WriteLine(result.GetProperty("error").GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("error").GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("error").GetProperty("target").ToString());
            Console.WriteLine(result.GetProperty("error").GetProperty("innerError").GetProperty("code").ToString());
            Console.WriteLine(result.GetProperty("error").GetProperty("innerError").GetProperty("message").ToString());
            Console.WriteLine(result.GetProperty("error").GetProperty("innerError").GetProperty("target").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("total").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("failed").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("success").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("inProgress").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("notYetStarted").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("cancelled").ToString());
            Console.WriteLine(result.GetProperty("summary").GetProperty("totalCharacterCharged").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetSupportedDocumentFormats()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new DocumentTranslationClient("<https://my-service.azure.com>", credential);

            Response response = client.GetSupportedDocumentFormats();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("format").ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("fileExtensions")[0].ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("contentTypes")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetSupportedDocumentFormats_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new DocumentTranslationClient("<https://my-service.azure.com>", credential);

            Response response = client.GetSupportedDocumentFormats();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("format").ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("fileExtensions")[0].ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("contentTypes")[0].ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("defaultVersion").ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("versions")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetSupportedDocumentFormats_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new DocumentTranslationClient("<https://my-service.azure.com>", credential);

            Response response = await client.GetSupportedDocumentFormatsAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("format").ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("fileExtensions")[0].ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("contentTypes")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetSupportedDocumentFormats_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new DocumentTranslationClient("<https://my-service.azure.com>", credential);

            Response response = await client.GetSupportedDocumentFormatsAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("format").ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("fileExtensions")[0].ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("contentTypes")[0].ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("defaultVersion").ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("versions")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetSupportedGlossaryFormats()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new DocumentTranslationClient("<https://my-service.azure.com>", credential);

            Response response = client.GetSupportedGlossaryFormats();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("format").ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("fileExtensions")[0].ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("contentTypes")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetSupportedGlossaryFormats_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new DocumentTranslationClient("<https://my-service.azure.com>", credential);

            Response response = client.GetSupportedGlossaryFormats();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("format").ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("fileExtensions")[0].ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("contentTypes")[0].ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("defaultVersion").ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("versions")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetSupportedGlossaryFormats_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new DocumentTranslationClient("<https://my-service.azure.com>", credential);

            Response response = await client.GetSupportedGlossaryFormatsAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("format").ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("fileExtensions")[0].ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("contentTypes")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetSupportedGlossaryFormats_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new DocumentTranslationClient("<https://my-service.azure.com>", credential);

            Response response = await client.GetSupportedGlossaryFormatsAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("format").ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("fileExtensions")[0].ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("contentTypes")[0].ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("defaultVersion").ToString());
            Console.WriteLine(result.GetProperty("value")[0].GetProperty("versions")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetSupportedStorageSources()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new DocumentTranslationClient("<https://my-service.azure.com>", credential);

            Response response = client.GetSupportedStorageSources();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetSupportedStorageSources_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new DocumentTranslationClient("<https://my-service.azure.com>", credential);

            Response response = client.GetSupportedStorageSources();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetSupportedStorageSources_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new DocumentTranslationClient("<https://my-service.azure.com>", credential);

            Response response = await client.GetSupportedStorageSourcesAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetSupportedStorageSources_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new DocumentTranslationClient("<https://my-service.azure.com>", credential);

            Response response = await client.GetSupportedStorageSourcesAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("value")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetTranslationsStatus()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new DocumentTranslationClient("<https://my-service.azure.com>", credential);

            foreach (var item in client.GetTranslationsStatus())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("createdDateTimeUtc").ToString());
                Console.WriteLine(result.GetProperty("lastActionDateTimeUtc").ToString());
                Console.WriteLine(result.GetProperty("status").ToString());
                Console.WriteLine(result.GetProperty("summary").GetProperty("total").ToString());
                Console.WriteLine(result.GetProperty("summary").GetProperty("failed").ToString());
                Console.WriteLine(result.GetProperty("summary").GetProperty("success").ToString());
                Console.WriteLine(result.GetProperty("summary").GetProperty("inProgress").ToString());
                Console.WriteLine(result.GetProperty("summary").GetProperty("notYetStarted").ToString());
                Console.WriteLine(result.GetProperty("summary").GetProperty("cancelled").ToString());
                Console.WriteLine(result.GetProperty("summary").GetProperty("totalCharacterCharged").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetTranslationsStatus_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new DocumentTranslationClient("<https://my-service.azure.com>", credential);

            foreach (var item in client.GetTranslationsStatus(1234, 1234, 1234, new Guid[] { Guid.NewGuid() }, new string[] { "<statuses>" }, DateTimeOffset.UtcNow, DateTimeOffset.UtcNow, new string[] { "<orderBy>" }))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("createdDateTimeUtc").ToString());
                Console.WriteLine(result.GetProperty("lastActionDateTimeUtc").ToString());
                Console.WriteLine(result.GetProperty("status").ToString());
                Console.WriteLine(result.GetProperty("error").GetProperty("code").ToString());
                Console.WriteLine(result.GetProperty("error").GetProperty("message").ToString());
                Console.WriteLine(result.GetProperty("error").GetProperty("target").ToString());
                Console.WriteLine(result.GetProperty("error").GetProperty("innerError").GetProperty("code").ToString());
                Console.WriteLine(result.GetProperty("error").GetProperty("innerError").GetProperty("message").ToString());
                Console.WriteLine(result.GetProperty("error").GetProperty("innerError").GetProperty("target").ToString());
                Console.WriteLine(result.GetProperty("summary").GetProperty("total").ToString());
                Console.WriteLine(result.GetProperty("summary").GetProperty("failed").ToString());
                Console.WriteLine(result.GetProperty("summary").GetProperty("success").ToString());
                Console.WriteLine(result.GetProperty("summary").GetProperty("inProgress").ToString());
                Console.WriteLine(result.GetProperty("summary").GetProperty("notYetStarted").ToString());
                Console.WriteLine(result.GetProperty("summary").GetProperty("cancelled").ToString());
                Console.WriteLine(result.GetProperty("summary").GetProperty("totalCharacterCharged").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetTranslationsStatus_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new DocumentTranslationClient("<https://my-service.azure.com>", credential);

            await foreach (var item in client.GetTranslationsStatusAsync())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("createdDateTimeUtc").ToString());
                Console.WriteLine(result.GetProperty("lastActionDateTimeUtc").ToString());
                Console.WriteLine(result.GetProperty("status").ToString());
                Console.WriteLine(result.GetProperty("summary").GetProperty("total").ToString());
                Console.WriteLine(result.GetProperty("summary").GetProperty("failed").ToString());
                Console.WriteLine(result.GetProperty("summary").GetProperty("success").ToString());
                Console.WriteLine(result.GetProperty("summary").GetProperty("inProgress").ToString());
                Console.WriteLine(result.GetProperty("summary").GetProperty("notYetStarted").ToString());
                Console.WriteLine(result.GetProperty("summary").GetProperty("cancelled").ToString());
                Console.WriteLine(result.GetProperty("summary").GetProperty("totalCharacterCharged").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetTranslationsStatus_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new DocumentTranslationClient("<https://my-service.azure.com>", credential);

            await foreach (var item in client.GetTranslationsStatusAsync(1234, 1234, 1234, new Guid[] { Guid.NewGuid() }, new string[] { "<statuses>" }, DateTimeOffset.UtcNow, DateTimeOffset.UtcNow, new string[] { "<orderBy>" }))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("createdDateTimeUtc").ToString());
                Console.WriteLine(result.GetProperty("lastActionDateTimeUtc").ToString());
                Console.WriteLine(result.GetProperty("status").ToString());
                Console.WriteLine(result.GetProperty("error").GetProperty("code").ToString());
                Console.WriteLine(result.GetProperty("error").GetProperty("message").ToString());
                Console.WriteLine(result.GetProperty("error").GetProperty("target").ToString());
                Console.WriteLine(result.GetProperty("error").GetProperty("innerError").GetProperty("code").ToString());
                Console.WriteLine(result.GetProperty("error").GetProperty("innerError").GetProperty("message").ToString());
                Console.WriteLine(result.GetProperty("error").GetProperty("innerError").GetProperty("target").ToString());
                Console.WriteLine(result.GetProperty("summary").GetProperty("total").ToString());
                Console.WriteLine(result.GetProperty("summary").GetProperty("failed").ToString());
                Console.WriteLine(result.GetProperty("summary").GetProperty("success").ToString());
                Console.WriteLine(result.GetProperty("summary").GetProperty("inProgress").ToString());
                Console.WriteLine(result.GetProperty("summary").GetProperty("notYetStarted").ToString());
                Console.WriteLine(result.GetProperty("summary").GetProperty("cancelled").ToString());
                Console.WriteLine(result.GetProperty("summary").GetProperty("totalCharacterCharged").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDocumentsStatus()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new DocumentTranslationClient("<https://my-service.azure.com>", credential);

            foreach (var item in client.GetDocumentsStatus(Guid.NewGuid()))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("sourcePath").ToString());
                Console.WriteLine(result.GetProperty("createdDateTimeUtc").ToString());
                Console.WriteLine(result.GetProperty("lastActionDateTimeUtc").ToString());
                Console.WriteLine(result.GetProperty("status").ToString());
                Console.WriteLine(result.GetProperty("to").ToString());
                Console.WriteLine(result.GetProperty("progress").ToString());
                Console.WriteLine(result.GetProperty("id").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDocumentsStatus_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new DocumentTranslationClient("<https://my-service.azure.com>", credential);

            foreach (var item in client.GetDocumentsStatus(Guid.NewGuid(), 1234, 1234, 1234, new Guid[] { Guid.NewGuid() }, new string[] { "<statuses>" }, DateTimeOffset.UtcNow, DateTimeOffset.UtcNow, new string[] { "<orderBy>" }))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("path").ToString());
                Console.WriteLine(result.GetProperty("sourcePath").ToString());
                Console.WriteLine(result.GetProperty("createdDateTimeUtc").ToString());
                Console.WriteLine(result.GetProperty("lastActionDateTimeUtc").ToString());
                Console.WriteLine(result.GetProperty("status").ToString());
                Console.WriteLine(result.GetProperty("to").ToString());
                Console.WriteLine(result.GetProperty("error").GetProperty("code").ToString());
                Console.WriteLine(result.GetProperty("error").GetProperty("message").ToString());
                Console.WriteLine(result.GetProperty("error").GetProperty("target").ToString());
                Console.WriteLine(result.GetProperty("error").GetProperty("innerError").GetProperty("code").ToString());
                Console.WriteLine(result.GetProperty("error").GetProperty("innerError").GetProperty("message").ToString());
                Console.WriteLine(result.GetProperty("error").GetProperty("innerError").GetProperty("target").ToString());
                Console.WriteLine(result.GetProperty("progress").ToString());
                Console.WriteLine(result.GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("characterCharged").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDocumentsStatus_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new DocumentTranslationClient("<https://my-service.azure.com>", credential);

            await foreach (var item in client.GetDocumentsStatusAsync(Guid.NewGuid()))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("sourcePath").ToString());
                Console.WriteLine(result.GetProperty("createdDateTimeUtc").ToString());
                Console.WriteLine(result.GetProperty("lastActionDateTimeUtc").ToString());
                Console.WriteLine(result.GetProperty("status").ToString());
                Console.WriteLine(result.GetProperty("to").ToString());
                Console.WriteLine(result.GetProperty("progress").ToString());
                Console.WriteLine(result.GetProperty("id").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDocumentsStatus_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new DocumentTranslationClient("<https://my-service.azure.com>", credential);

            await foreach (var item in client.GetDocumentsStatusAsync(Guid.NewGuid(), 1234, 1234, 1234, new Guid[] { Guid.NewGuid() }, new string[] { "<statuses>" }, DateTimeOffset.UtcNow, DateTimeOffset.UtcNow, new string[] { "<orderBy>" }))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("path").ToString());
                Console.WriteLine(result.GetProperty("sourcePath").ToString());
                Console.WriteLine(result.GetProperty("createdDateTimeUtc").ToString());
                Console.WriteLine(result.GetProperty("lastActionDateTimeUtc").ToString());
                Console.WriteLine(result.GetProperty("status").ToString());
                Console.WriteLine(result.GetProperty("to").ToString());
                Console.WriteLine(result.GetProperty("error").GetProperty("code").ToString());
                Console.WriteLine(result.GetProperty("error").GetProperty("message").ToString());
                Console.WriteLine(result.GetProperty("error").GetProperty("target").ToString());
                Console.WriteLine(result.GetProperty("error").GetProperty("innerError").GetProperty("code").ToString());
                Console.WriteLine(result.GetProperty("error").GetProperty("innerError").GetProperty("message").ToString());
                Console.WriteLine(result.GetProperty("error").GetProperty("innerError").GetProperty("target").ToString());
                Console.WriteLine(result.GetProperty("progress").ToString());
                Console.WriteLine(result.GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("characterCharged").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_StartTranslation()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new DocumentTranslationClient("<https://my-service.azure.com>", credential);

            var data = new
            {
                inputs = new[] {
        new {
            source = new {
                sourceUrl = "<sourceUrl>",
            },
            targets = new[] {
                new {
                    targetUrl = "<targetUrl>",
                    language = "<language>",
                }
            },
        }
    },
            };

            var operation = client.StartTranslation(WaitUntil.Completed, RequestContent.Create(data), ContentType.ApplicationOctetStream);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_StartTranslation_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new DocumentTranslationClient("<https://my-service.azure.com>", credential);

            var data = new
            {
                inputs = new[] {
        new {
            source = new {
                sourceUrl = "<sourceUrl>",
                filter = new {
                    prefix = "<prefix>",
                    suffix = "<suffix>",
                },
                language = "<language>",
                storageSource = "AzureBlob",
            },
            targets = new[] {
                new {
                    targetUrl = "<targetUrl>",
                    category = "<category>",
                    language = "<language>",
                    glossaries = new[] {
                        new {
                            glossaryUrl = "<glossaryUrl>",
                            format = "<format>",
                            version = "<version>",
                            storageSource = "AzureBlob",
                        }
                    },
                    storageSource = "AzureBlob",
                }
            },
            storageType = "Folder",
        }
    },
            };

            var operation = client.StartTranslation(WaitUntil.Completed, RequestContent.Create(data), ContentType.ApplicationOctetStream);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_StartTranslation_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new DocumentTranslationClient("<https://my-service.azure.com>", credential);

            var data = new
            {
                inputs = new[] {
        new {
            source = new {
                sourceUrl = "<sourceUrl>",
            },
            targets = new[] {
                new {
                    targetUrl = "<targetUrl>",
                    language = "<language>",
                }
            },
        }
    },
            };

            var operation = await client.StartTranslationAsync(WaitUntil.Completed, RequestContent.Create(data), ContentType.ApplicationOctetStream);

            Console.WriteLine(operation.GetRawResponse().Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_StartTranslation_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new DocumentTranslationClient("<https://my-service.azure.com>", credential);

            var data = new
            {
                inputs = new[] {
        new {
            source = new {
                sourceUrl = "<sourceUrl>",
                filter = new {
                    prefix = "<prefix>",
                    suffix = "<suffix>",
                },
                language = "<language>",
                storageSource = "AzureBlob",
            },
            targets = new[] {
                new {
                    targetUrl = "<targetUrl>",
                    category = "<category>",
                    language = "<language>",
                    glossaries = new[] {
                        new {
                            glossaryUrl = "<glossaryUrl>",
                            format = "<format>",
                            version = "<version>",
                            storageSource = "AzureBlob",
                        }
                    },
                    storageSource = "AzureBlob",
                }
            },
            storageType = "Folder",
        }
    },
            };

            var operation = await client.StartTranslationAsync(WaitUntil.Completed, RequestContent.Create(data), ContentType.ApplicationOctetStream);

            Console.WriteLine(operation.GetRawResponse().Status);
        }
    }
}
