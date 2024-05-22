// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using NUnit.Framework;

namespace SubClients_LowLevel.Tests
{
    public partial class RootClientTests : SubClients_LowLevelTestBase
    {
        public RootClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Root_GetCachedParameter_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            RootClient client = CreateRootClient(endpoint, "<CachedParameter>", credential);

            Response response = await client.GetCachedParameterAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Root_GetCachedParameter_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            RootClient client = CreateRootClient(endpoint, "<CachedParameter>", credential);

            Response response = await client.GetCachedParameterAsync(null);
        }
    }
}
