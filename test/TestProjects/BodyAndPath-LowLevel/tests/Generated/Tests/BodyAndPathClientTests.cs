// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using BodyAndPath_LowLevel;
using NUnit.Framework;

namespace BodyAndPath_LowLevel.Tests
{
    public partial class BodyAndPathClientTests : BodyAndPath_LowLevelTestBase
    {
        public BodyAndPathClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task Create_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            BodyAndPathClient client = CreateBodyAndPathClient(endpoint, credential);

            RequestContent content = RequestContent.Create(new object());
            Response response = await client.CreateAsync("<itemName>", content);
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task Create_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            BodyAndPathClient client = CreateBodyAndPathClient(endpoint, credential);

            RequestContent content = RequestContent.Create(new object());
            Response response = await client.CreateAsync("<itemName>", content);
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task CreateStream_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            BodyAndPathClient client = CreateBodyAndPathClient(endpoint, credential);

            RequestContent content = RequestContent.Create(File.OpenRead("<filePath>"));
            Response response = await client.CreateStreamAsync("<itemNameStream>", content, new ContentType("application/json"));
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task CreateStream_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            BodyAndPathClient client = CreateBodyAndPathClient(endpoint, credential);

            RequestContent content = RequestContent.Create(File.OpenRead("<filePath>"));
            Response response = await client.CreateStreamAsync("<itemNameStream>", content, new ContentType("application/json"), excluded: new string[] { "<excluded>" });
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task CreateEnum_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            BodyAndPathClient client = CreateBodyAndPathClient(endpoint, credential);

            RequestContent content = RequestContent.Create(new object());
            Response response = await client.CreateEnumAsync("current", "latest", content);
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task CreateEnum_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            BodyAndPathClient client = CreateBodyAndPathClient(endpoint, credential);

            RequestContent content = RequestContent.Create(new object());
            Response response = await client.CreateEnumAsync("current", "latest", content);
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task GetBodyAndPaths_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            BodyAndPathClient client = CreateBodyAndPathClient(endpoint, credential);

            Response response = await client.GetBodyAndPathsAsync(null);
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task GetBodyAndPaths_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            BodyAndPathClient client = CreateBodyAndPathClient(endpoint, credential);

            Response response = await client.GetBodyAndPathsAsync(null);
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task GetItems_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            BodyAndPathClient client = CreateBodyAndPathClient(endpoint, credential);

            Response response = await client.GetItemsAsync(null);
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task GetItems_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            BodyAndPathClient client = CreateBodyAndPathClient(endpoint, credential);

            Response response = await client.GetItemsAsync(null);
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task Update_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            BodyAndPathClient client = CreateBodyAndPathClient(endpoint, credential);

            RequestContent content = RequestContent.Create(new object());
            Response response = await client.UpdateAsync("<item3>", "<item2>", "value", "<item4>", content);
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task Update_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            BodyAndPathClient client = CreateBodyAndPathClient(endpoint, credential);

            RequestContent content = RequestContent.Create(new Dictionary<string, object>
            {
                ["invalid-int-name"] = 1234
            });
            Response response = await client.UpdateAsync("<item3>", "<item2>", "value", "<item4>", content, item5: "<item5>");
        }
    }
}
