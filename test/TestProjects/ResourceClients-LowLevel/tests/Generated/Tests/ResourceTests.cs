// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using NUnit.Framework;
using ResourceClients_LowLevel;

namespace ResourceClients_LowLevel.Tests
{
    public partial class ResourceTests : ResourceClients_LowLevelTestBase
    {
        public ResourceTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetItem_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Resource client = CreateResourceServiceClient(endpoint, credential).GetResourceGroup("<GroupId>").GetResource("<ItemId>");

            Response response = await client.GetItemAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task GetItem_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Resource client = CreateResourceServiceClient(endpoint, credential).GetResourceGroup("<GroupId>").GetResource("<ItemId>");

            Response response = await client.GetItemAsync(null);
        }
    }
}
