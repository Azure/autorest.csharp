// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Authentication.Http.Custom;
using Azure;
using Azure.Identity;
using NUnit.Framework;

namespace Authentication.Http.Custom.Tests
{
    public partial class CustomClientTests : AuthenticationHttpCustomTestBase
    {
        public CustomClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Custom_Valid_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            CustomClient client = CreateCustomClient(endpoint, credential);

            Response response = await client.ValidAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Custom_Valid_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            CustomClient client = CreateCustomClient(endpoint, credential);

            Response response = await client.ValidAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Custom_Invalid_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            CustomClient client = CreateCustomClient(endpoint, credential);

            Response response = await client.InvalidAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Custom_Invalid_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            CustomClient client = CreateCustomClient(endpoint, credential);

            Response response = await client.InvalidAsync();
        }
    }
}
