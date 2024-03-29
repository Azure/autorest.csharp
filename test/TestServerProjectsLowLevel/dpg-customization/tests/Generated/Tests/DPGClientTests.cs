// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;
using dpg_customization_LowLevel;

namespace dpg_customization_LowLevel.Tests
{
    public partial class DPGClientTests : dpg_customization_LowLevelTestBase
    {
        public DPGClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetModel_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DPGClient client = CreateDPGClient(endpoint, credential);

            Response response = await client.GetModelAsync("<mode>", null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetModel_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DPGClient client = CreateDPGClient(endpoint, credential);

            Response response = await client.GetModelAsync("<mode>", null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task PostModel_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DPGClient client = CreateDPGClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new
            {
                hello = "<hello>",
            });
            Response response = await client.PostModelAsync("<mode>", content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task PostModel_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DPGClient client = CreateDPGClient(endpoint, credential);

            using RequestContent content = RequestContent.Create(new
            {
                hello = "<hello>",
            });
            Response response = await client.PostModelAsync("<mode>", content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetPages_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DPGClient client = CreateDPGClient(endpoint, credential);

            await foreach (BinaryData item in client.GetPagesAsync("<mode>", null))
            {
            }
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetPages_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DPGClient client = CreateDPGClient(endpoint, credential);

            await foreach (BinaryData item in client.GetPagesAsync("<mode>", null))
            {
            }
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Lro_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DPGClient client = CreateDPGClient(endpoint, credential);

            Operation<BinaryData> operation = await client.LroAsync(WaitUntil.Completed, "<mode>", null);
            BinaryData responseData = operation.Value;
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Lro_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            DPGClient client = CreateDPGClient(endpoint, credential);

            Operation<BinaryData> operation = await client.LroAsync(WaitUntil.Completed, "<mode>", null);
            BinaryData responseData = operation.Value;
        }
    }
}
