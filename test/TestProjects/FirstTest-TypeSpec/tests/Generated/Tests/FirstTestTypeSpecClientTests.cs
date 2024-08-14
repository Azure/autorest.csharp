// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using FirstTestTypeSpec.Models;
using NUnit.Framework;

namespace FirstTestTypeSpec.Tests
{
    public partial class FirstTestTypeSpecClientTests : FirstTestTypeSpecTestBase
    {
        public FirstTestTypeSpecClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task FirstTestTypeSpec_TopAction_ForTestTopAction()
        {
            Uri endpoint = new Uri("<endpoint>");
            AzureKeyCredential credential = null;
            FirstTestTypeSpecClient client = CreateFirstTestTypeSpecClient(endpoint, credential);

            Response response = await client.TopActionAsync(DateTimeOffset.Parse("2024-05-06T12:20-12Z"), null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task FirstTestTypeSpec_TopAction_ForTestTopAction_Convenience()
        {
            Uri endpoint = new Uri("<endpoint>");
            AzureKeyCredential credential = null;
            FirstTestTypeSpecClient client = CreateFirstTestTypeSpecClient(endpoint, credential);

            Response<Thing> response = await client.TopActionAsync(DateTimeOffset.Parse("2024-05-06T12:20-12Z"));
        }
    }
}
