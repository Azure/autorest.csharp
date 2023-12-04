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
using _Type.Union;
using _Type.Union.Models;

namespace _Type.Union.Tests
{
    public partial class ModelsOnlyTests : _TypeUnionTestBase
    {
        public ModelsOnlyTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ModelsOnly_GetModelsOnly_ShortVersion()
        {
            Uri endpoint = null;
            ModelsOnly client = CreateUnionClient(endpoint).GetModelsOnlyClient(apiVersion: "1.0.0");

            Response response = await client.GetModelsOnlyAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ModelsOnly_GetModelsOnly_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            ModelsOnly client = CreateUnionClient(endpoint).GetModelsOnlyClient(apiVersion: "1.0.0");

            Response<object> response = await client.GetModelsOnlyAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ModelsOnly_GetModelsOnly_AllParameters()
        {
            Uri endpoint = null;
            ModelsOnly client = CreateUnionClient(endpoint).GetModelsOnlyClient(apiVersion: "1.0.0");

            Response response = await client.GetModelsOnlyAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ModelsOnly_GetModelsOnly_AllParameters_Convenience()
        {
            Uri endpoint = null;
            ModelsOnly client = CreateUnionClient(endpoint).GetModelsOnlyClient(apiVersion: "1.0.0");

            Response<object> response = await client.GetModelsOnlyAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ModelsOnly_Send_ShortVersion()
        {
            Uri endpoint = null;
            ModelsOnly client = CreateUnionClient(endpoint).GetModelsOnlyClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new
            {
                prop = "a",
            });
            Response response = await client.SendAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ModelsOnly_Send_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            ModelsOnly client = CreateUnionClient(endpoint).GetModelsOnlyClient(apiVersion: "1.0.0");

            Response response = await client.SendAsync(SendRequestProp.A);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ModelsOnly_Send_AllParameters()
        {
            Uri endpoint = null;
            ModelsOnly client = CreateUnionClient(endpoint).GetModelsOnlyClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new
            {
                prop = "a",
            });
            Response response = await client.SendAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ModelsOnly_Send_AllParameters_Convenience()
        {
            Uri endpoint = null;
            ModelsOnly client = CreateUnionClient(endpoint).GetModelsOnlyClient(apiVersion: "1.0.0");

            Response response = await client.SendAsync(SendRequestProp.A);
        }
    }
}
