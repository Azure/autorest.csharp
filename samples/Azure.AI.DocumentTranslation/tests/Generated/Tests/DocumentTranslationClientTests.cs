// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.AI.DocumentTranslation;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.AI.DocumentTranslation.Tests
{
    public partial class DocumentTranslationClientTests : AIDocumentTranslationTestBase
    {
        public DocumentTranslationClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task GetDocumentStatus_ShortVersion()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DocumentTranslationClient client = CreateDocumentTranslationClient("<Endpoint>", credential);

            Response response = await client.GetDocumentStatusAsync(Guid.Parse("73f411fe-4f43-4b4b-9cbd-6828d8f4cf9a"), Guid.Parse("73f411fe-4f43-4b4b-9cbd-6828d8f4cf9a"));
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task GetDocumentStatus_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DocumentTranslationClient client = CreateDocumentTranslationClient("<Endpoint>", credential);

            Response response = await client.GetDocumentStatusAsync(Guid.Parse("73f411fe-4f43-4b4b-9cbd-6828d8f4cf9a"), Guid.Parse("73f411fe-4f43-4b4b-9cbd-6828d8f4cf9a"));
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task GetTranslationStatus_ShortVersion()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DocumentTranslationClient client = CreateDocumentTranslationClient("<Endpoint>", credential);

            Response response = await client.GetTranslationStatusAsync(Guid.Parse("73f411fe-4f43-4b4b-9cbd-6828d8f4cf9a"));
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task GetTranslationStatus_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DocumentTranslationClient client = CreateDocumentTranslationClient("<Endpoint>", credential);

            Response response = await client.GetTranslationStatusAsync(Guid.Parse("73f411fe-4f43-4b4b-9cbd-6828d8f4cf9a"));
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task CancelTranslation_ShortVersion()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DocumentTranslationClient client = CreateDocumentTranslationClient("<Endpoint>", credential);

            Response response = await client.CancelTranslationAsync(Guid.Parse("73f411fe-4f43-4b4b-9cbd-6828d8f4cf9a"));
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task CancelTranslation_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DocumentTranslationClient client = CreateDocumentTranslationClient("<Endpoint>", credential);

            Response response = await client.CancelTranslationAsync(Guid.Parse("73f411fe-4f43-4b4b-9cbd-6828d8f4cf9a"));
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task GetSupportedDocumentFormats_ShortVersion()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DocumentTranslationClient client = CreateDocumentTranslationClient("<Endpoint>", credential);

            Response response = await client.GetSupportedDocumentFormatsAsync();
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task GetSupportedDocumentFormats_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DocumentTranslationClient client = CreateDocumentTranslationClient("<Endpoint>", credential);

            Response response = await client.GetSupportedDocumentFormatsAsync();
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task GetSupportedGlossaryFormats_ShortVersion()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DocumentTranslationClient client = CreateDocumentTranslationClient("<Endpoint>", credential);

            Response response = await client.GetSupportedGlossaryFormatsAsync();
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task GetSupportedGlossaryFormats_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DocumentTranslationClient client = CreateDocumentTranslationClient("<Endpoint>", credential);

            Response response = await client.GetSupportedGlossaryFormatsAsync();
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task GetSupportedStorageSources_ShortVersion()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DocumentTranslationClient client = CreateDocumentTranslationClient("<Endpoint>", credential);

            Response response = await client.GetSupportedStorageSourcesAsync();
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task GetSupportedStorageSources_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DocumentTranslationClient client = CreateDocumentTranslationClient("<Endpoint>", credential);

            Response response = await client.GetSupportedStorageSourcesAsync();
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task GetTranslationsStatus_ShortVersion()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DocumentTranslationClient client = CreateDocumentTranslationClient("<Endpoint>", credential);

            await foreach (BinaryData item in client.GetTranslationsStatusAsync())
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task GetTranslationsStatus_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DocumentTranslationClient client = CreateDocumentTranslationClient("<Endpoint>", credential);

            await foreach (BinaryData item in client.GetTranslationsStatusAsync(top: 1234, skip: 1234, maxpagesize: 1234, ids: new Guid[] { Guid.Parse("73f411fe-4f43-4b4b-9cbd-6828d8f4cf9a") }, statuses: new string[] { "<statuses>" }, createdDateTimeUtcStart: DateTimeOffset.Parse("2022-05-10T18:57:31.2311892Z"), createdDateTimeUtcEnd: DateTimeOffset.Parse("2022-05-10T18:57:31.2311892Z"), orderBy: new string[] { "<orderBy>" }))
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task GetDocumentsStatus_ShortVersion()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DocumentTranslationClient client = CreateDocumentTranslationClient("<Endpoint>", credential);

            await foreach (BinaryData item in client.GetDocumentsStatusAsync(Guid.Parse("73f411fe-4f43-4b4b-9cbd-6828d8f4cf9a")))
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task GetDocumentsStatus_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DocumentTranslationClient client = CreateDocumentTranslationClient("<Endpoint>", credential);

            await foreach (BinaryData item in client.GetDocumentsStatusAsync(Guid.Parse("73f411fe-4f43-4b4b-9cbd-6828d8f4cf9a"), top: 1234, skip: 1234, maxpagesize: 1234, ids: new Guid[] { Guid.Parse("73f411fe-4f43-4b4b-9cbd-6828d8f4cf9a") }, statuses: new string[] { "<statuses>" }, createdDateTimeUtcStart: DateTimeOffset.Parse("2022-05-10T18:57:31.2311892Z"), createdDateTimeUtcEnd: DateTimeOffset.Parse("2022-05-10T18:57:31.2311892Z"), orderBy: new string[] { "<orderBy>" }))
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task StartTranslation_ShortVersion()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DocumentTranslationClient client = CreateDocumentTranslationClient("<Endpoint>", credential);

            RequestContent content = RequestContent.Create(new
            {
                inputs = new object[]
            {
new
{
source = new
{
sourceUrl = "<sourceUrl>",
},
targets = new object[]
{
new
{
targetUrl = "<targetUrl>",
language = "<language>",
}
},
}
            },
            });
            Operation operation = await client.StartTranslationAsync(WaitUntil.Completed, content, new ContentType("application/json"));
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task StartTranslation_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DocumentTranslationClient client = CreateDocumentTranslationClient("<Endpoint>", credential);

            RequestContent content = RequestContent.Create(new
            {
                inputs = new object[]
            {
new
{
source = new
{
sourceUrl = "<sourceUrl>",
filter = new
{
prefix = "<prefix>",
suffix = "<suffix>",
},
language = "<language>",
storageSource = "AzureBlob",
},
targets = new object[]
{
new
{
targetUrl = "<targetUrl>",
category = "<category>",
language = "<language>",
glossaries = new object[]
{
new
{
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
            });
            Operation operation = await client.StartTranslationAsync(WaitUntil.Completed, content, new ContentType("application/json"));
        }
    }
}
