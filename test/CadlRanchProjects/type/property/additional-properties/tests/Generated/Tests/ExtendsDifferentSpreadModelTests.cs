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
    public partial class ExtendsDifferentSpreadModelTests : _TypePropertyAdditionalPropertiesTestBase
    {
        public ExtendsDifferentSpreadModelTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ExtendsDifferentSpreadModel_GetExtendsDifferentSpreadModel_ShortVersion()
        {
            Uri endpoint = null;
            ExtendsDifferentSpreadModel client = CreateAdditionalPropertiesClient(endpoint).GetExtendsDifferentSpreadModelClient();

            Response response = await client.GetExtendsDifferentSpreadModelAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ExtendsDifferentSpreadModel_GetExtendsDifferentSpreadModel_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            ExtendsDifferentSpreadModel client = CreateAdditionalPropertiesClient(endpoint).GetExtendsDifferentSpreadModelClient();

            Response<DifferentSpreadModelDerived> response = await client.GetExtendsDifferentSpreadModelAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ExtendsDifferentSpreadModel_GetExtendsDifferentSpreadModel_AllParameters()
        {
            Uri endpoint = null;
            ExtendsDifferentSpreadModel client = CreateAdditionalPropertiesClient(endpoint).GetExtendsDifferentSpreadModelClient();

            Response response = await client.GetExtendsDifferentSpreadModelAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ExtendsDifferentSpreadModel_GetExtendsDifferentSpreadModel_AllParameters_Convenience()
        {
            Uri endpoint = null;
            ExtendsDifferentSpreadModel client = CreateAdditionalPropertiesClient(endpoint).GetExtendsDifferentSpreadModelClient();

            Response<DifferentSpreadModelDerived> response = await client.GetExtendsDifferentSpreadModelAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ExtendsDifferentSpreadModel_Put_ShortVersion()
        {
            Uri endpoint = null;
            ExtendsDifferentSpreadModel client = CreateAdditionalPropertiesClient(endpoint).GetExtendsDifferentSpreadModelClient();

            using RequestContent content = RequestContent.Create(new
            {
                derivedProp = new
                {
                    state = "<state>",
                },
                knownProp = "<knownProp>",
            });
            Response response = await client.PutAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ExtendsDifferentSpreadModel_Put_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            ExtendsDifferentSpreadModel client = CreateAdditionalPropertiesClient(endpoint).GetExtendsDifferentSpreadModelClient();

            DifferentSpreadModelDerived body = new DifferentSpreadModelDerived("<knownProp>", new ModelForRecord("<state>"));
            Response response = await client.PutAsync(body);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ExtendsDifferentSpreadModel_Put_AllParameters()
        {
            Uri endpoint = null;
            ExtendsDifferentSpreadModel client = CreateAdditionalPropertiesClient(endpoint).GetExtendsDifferentSpreadModelClient();

            using RequestContent content = RequestContent.Create(new
            {
                derivedProp = new
                {
                    state = "<state>",
                },
                knownProp = "<knownProp>",
            });
            Response response = await client.PutAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ExtendsDifferentSpreadModel_Put_AllParameters_Convenience()
        {
            Uri endpoint = null;
            ExtendsDifferentSpreadModel client = CreateAdditionalPropertiesClient(endpoint).GetExtendsDifferentSpreadModelClient();

            DifferentSpreadModelDerived body = new DifferentSpreadModelDerived("<knownProp>", new ModelForRecord("<state>"));
            Response response = await client.PutAsync(body);
        }
    }
}
