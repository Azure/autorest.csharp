// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.NewProject.TypeSpec.Tests
{
    public partial class HelloDemoTests : NewProjectTypeSpecTestBase
    {
        public HelloDemoTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Demo_SayHi_ShortVersion()
        {
            Uri endpoint = new Uri("<endpoint>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HelloDemo client = CreateNewProjectTypeSpecClient(endpoint, credential).GetHelloClient().GetHelloDemoClient();

            Response response = await client.SayHiAsync("<headParameter>", "<queryParameter>", null, null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Demo_SayHi_AllParameters()
        {
            Uri endpoint = new Uri("<endpoint>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            HelloDemo client = CreateNewProjectTypeSpecClient(endpoint, credential).GetHelloClient().GetHelloDemoClient();

            Response response = await client.SayHiAsync("<headParameter>", "<queryParameter>", "<optionalQuery>", null);
        }
    }
}
