// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using FirstTestTypeSpec;
using NUnit.Framework;

namespace FirstTestTypeSpec.Tests
{
    public partial class DemoTests : FirstTestTypeSpecTestBase
    {
        public DemoTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Demo_SayHi_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = null;
            Demo client = CreateFirstTestTypeSpecClient(endpoint, credential).GetHelloClient().GetDemoClient();

            Response response = await client.SayHiAsync("<headParameter>", "<queryParameter>", null, null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Demo_SayHi_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = null;
            Demo client = CreateFirstTestTypeSpecClient(endpoint, credential).GetHelloClient().GetDemoClient();

            Response response = await client.SayHiAsync("<headParameter>", "<queryParameter>", "<optionalQuery>", null);
        }
    }
}
