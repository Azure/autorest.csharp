// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using FirstTestTypeSpec;
using FirstTestTypeSpec.Models;
using NUnit.Framework;

namespace FirstTestTypeSpec.Tests
{
    public partial class GlossaryTests : FirstTestTypeSpecTestBase
    {
        public GlossaryTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Glossary_DoSomething_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = null;
            Glossary client = CreateFirstTestTypeSpecClient(endpoint, credential).GetGlossaryClient();

            Response response = await client.DoSomethingAsync("<id>", "<h1>", null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Glossary_DoSomething_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = null;
            Glossary client = CreateFirstTestTypeSpecClient(endpoint, credential).GetGlossaryClient();

            Response<Thing> response = await client.DoSomethingAsync("<id>", "<h1>");
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Glossary_DoSomething_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = null;
            Glossary client = CreateFirstTestTypeSpecClient(endpoint, credential).GetGlossaryClient();

            Response response = await client.DoSomethingAsync("<id>", "<h1>", null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Glossary_DoSomething_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = null;
            Glossary client = CreateFirstTestTypeSpecClient(endpoint, credential).GetGlossaryClient();

            Response<Thing> response = await client.DoSomethingAsync("<id>", "<h1>");
        }
    }
}
