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
    public partial class IsUnknownDerivedTests : _TypePropertyAdditionalPropertiesTestBase
    {
        public IsUnknownDerivedTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task IsUnknownDerived_GetIsUnknownDerived_ShortVersion()
        {
            Uri endpoint = null;
            IsUnknownDerived client = CreateAdditionalPropertiesClient(endpoint).GetIsUnknownDerivedClient();

            Response response = await client.GetIsUnknownDerivedAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task IsUnknownDerived_GetIsUnknownDerived_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            IsUnknownDerived client = CreateAdditionalPropertiesClient(endpoint).GetIsUnknownDerivedClient();

            Response<IsUnknownAdditionalPropertiesDerived> response = await client.GetIsUnknownDerivedAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task IsUnknownDerived_GetIsUnknownDerived_AllParameters()
        {
            Uri endpoint = null;
            IsUnknownDerived client = CreateAdditionalPropertiesClient(endpoint).GetIsUnknownDerivedClient();

            Response response = await client.GetIsUnknownDerivedAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task IsUnknownDerived_GetIsUnknownDerived_AllParameters_Convenience()
        {
            Uri endpoint = null;
            IsUnknownDerived client = CreateAdditionalPropertiesClient(endpoint).GetIsUnknownDerivedClient();

            Response<IsUnknownAdditionalPropertiesDerived> response = await client.GetIsUnknownDerivedAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task IsUnknownDerived_Put_ShortVersion()
        {
            Uri endpoint = null;
            IsUnknownDerived client = CreateAdditionalPropertiesClient(endpoint).GetIsUnknownDerivedClient();

            using RequestContent content = RequestContent.Create(new
            {
                index = 1234,
                name = "<name>",
            });
            Response response = await client.PutAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task IsUnknownDerived_Put_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            IsUnknownDerived client = CreateAdditionalPropertiesClient(endpoint).GetIsUnknownDerivedClient();

            IsUnknownAdditionalPropertiesDerived body = new IsUnknownAdditionalPropertiesDerived("<name>", 1234);
            Response response = await client.PutAsync(body);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task IsUnknownDerived_Put_AllParameters()
        {
            Uri endpoint = null;
            IsUnknownDerived client = CreateAdditionalPropertiesClient(endpoint).GetIsUnknownDerivedClient();

            using RequestContent content = RequestContent.Create(new
            {
                index = 1234,
                age = 123.45F,
                name = "<name>",
            });
            Response response = await client.PutAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task IsUnknownDerived_Put_AllParameters_Convenience()
        {
            Uri endpoint = null;
            IsUnknownDerived client = CreateAdditionalPropertiesClient(endpoint).GetIsUnknownDerivedClient();

            IsUnknownAdditionalPropertiesDerived body = new IsUnknownAdditionalPropertiesDerived("<name>", 1234)
            {
                Age = 123.45F,
            };
            Response response = await client.PutAsync(body);
        }
    }
}
