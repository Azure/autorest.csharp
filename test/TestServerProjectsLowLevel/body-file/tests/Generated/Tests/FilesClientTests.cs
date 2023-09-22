// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using NUnit.Framework;
using body_file_LowLevel;

namespace body_file_LowLevel.Tests
{
    public class FilesClientTests : body_file_LowLevelTestBase
    {
        public FilesClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task GetFile_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            FilesClient client = CreateFilesClient(credential, endpoint);

            Response response = await client.GetFileAsync(null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task GetFile_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            FilesClient client = CreateFilesClient(credential, endpoint);

            Response response = await client.GetFileAsync(null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task GetFileLarge_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            FilesClient client = CreateFilesClient(credential, endpoint);

            Response response = await client.GetFileLargeAsync(null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task GetFileLarge_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            FilesClient client = CreateFilesClient(credential, endpoint);

            Response response = await client.GetFileLargeAsync(null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task GetEmptyFile_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            FilesClient client = CreateFilesClient(credential, endpoint);

            Response response = await client.GetEmptyFileAsync(null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task GetEmptyFile_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            FilesClient client = CreateFilesClient(credential, endpoint);

            Response response = await client.GetEmptyFileAsync(null);
        }
    }
}
