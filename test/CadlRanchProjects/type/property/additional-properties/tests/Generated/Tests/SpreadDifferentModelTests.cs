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
using _Type.Property.AdditionalProperties.Models;

namespace _Type.Property.AdditionalProperties.Tests
{
    public partial class SpreadDifferentModelTests : _TypePropertyAdditionalPropertiesTestBase
    {
        public SpreadDifferentModelTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task SpreadDifferentModel_GetSpreadDifferentModel_ShortVersion()
        {
            Uri endpoint = null;
            SpreadDifferentModel client = CreateAdditionalPropertiesClient(endpoint).GetSpreadDifferentModelClient();

            Response response = await client.GetSpreadDifferentModelAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task SpreadDifferentModel_GetSpreadDifferentModel_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            SpreadDifferentModel client = CreateAdditionalPropertiesClient(endpoint).GetSpreadDifferentModelClient();

            Response<DifferentSpreadModelRecord> response = await client.GetSpreadDifferentModelAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task SpreadDifferentModel_GetSpreadDifferentModel_AllParameters()
        {
            Uri endpoint = null;
            SpreadDifferentModel client = CreateAdditionalPropertiesClient(endpoint).GetSpreadDifferentModelClient();

            Response response = await client.GetSpreadDifferentModelAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task SpreadDifferentModel_GetSpreadDifferentModel_AllParameters_Convenience()
        {
            Uri endpoint = null;
            SpreadDifferentModel client = CreateAdditionalPropertiesClient(endpoint).GetSpreadDifferentModelClient();

            Response<DifferentSpreadModelRecord> response = await client.GetSpreadDifferentModelAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task SpreadDifferentModel_Put_ShortVersion()
        {
            Uri endpoint = null;
            SpreadDifferentModel client = CreateAdditionalPropertiesClient(endpoint).GetSpreadDifferentModelClient();

            using RequestContent content = RequestContent.Create(new
            {
                knownProp = "<knownProp>",
            });
            Response response = await client.PutAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task SpreadDifferentModel_Put_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            SpreadDifferentModel client = CreateAdditionalPropertiesClient(endpoint).GetSpreadDifferentModelClient();

            DifferentSpreadModelRecord body = new DifferentSpreadModelRecord("<knownProp>");
            Response response = await client.PutAsync(body);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task SpreadDifferentModel_Put_AllParameters()
        {
            Uri endpoint = null;
            SpreadDifferentModel client = CreateAdditionalPropertiesClient(endpoint).GetSpreadDifferentModelClient();

            using RequestContent content = RequestContent.Create(new
            {
                knownProp = "<knownProp>",
            });
            Response response = await client.PutAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task SpreadDifferentModel_Put_AllParameters_Convenience()
        {
            Uri endpoint = null;
            SpreadDifferentModel client = CreateAdditionalPropertiesClient(endpoint).GetSpreadDifferentModelClient();

            DifferentSpreadModelRecord body = new DifferentSpreadModelRecord("<knownProp>");
            Response response = await client.PutAsync(body);
        }
    }
}
