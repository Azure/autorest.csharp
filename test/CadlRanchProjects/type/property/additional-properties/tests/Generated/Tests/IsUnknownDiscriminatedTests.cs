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
    public partial class IsUnknownDiscriminatedTests : _TypePropertyAdditionalPropertiesTestBase
    {
        public IsUnknownDiscriminatedTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task IsUnknownDiscriminated_GetIsUnknownDiscriminated_ShortVersion()
        {
            Uri endpoint = null;
            IsUnknownDiscriminated client = CreateAdditionalPropertiesClient(endpoint).GetIsUnknownDiscriminatedClient();

            Response response = await client.GetIsUnknownDiscriminatedAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task IsUnknownDiscriminated_GetIsUnknownDiscriminated_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            IsUnknownDiscriminated client = CreateAdditionalPropertiesClient(endpoint).GetIsUnknownDiscriminatedClient();

            Response<IsUnknownAdditionalPropertiesDiscriminated> response = await client.GetIsUnknownDiscriminatedAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task IsUnknownDiscriminated_GetIsUnknownDiscriminated_AllParameters()
        {
            Uri endpoint = null;
            IsUnknownDiscriminated client = CreateAdditionalPropertiesClient(endpoint).GetIsUnknownDiscriminatedClient();

            Response response = await client.GetIsUnknownDiscriminatedAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task IsUnknownDiscriminated_GetIsUnknownDiscriminated_AllParameters_Convenience()
        {
            Uri endpoint = null;
            IsUnknownDiscriminated client = CreateAdditionalPropertiesClient(endpoint).GetIsUnknownDiscriminatedClient();

            Response<IsUnknownAdditionalPropertiesDiscriminated> response = await client.GetIsUnknownDiscriminatedAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task IsUnknownDiscriminated_Put_ShortVersion()
        {
            Uri endpoint = null;
            IsUnknownDiscriminated client = CreateAdditionalPropertiesClient(endpoint).GetIsUnknownDiscriminatedClient();

            using RequestContent content = RequestContent.Create(new
            {
                kind = "derived",
                index = 1234,
                name = "<name>",
            });
            Response response = await client.PutAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task IsUnknownDiscriminated_Put_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            IsUnknownDiscriminated client = CreateAdditionalPropertiesClient(endpoint).GetIsUnknownDiscriminatedClient();

            IsUnknownAdditionalPropertiesDiscriminated body = new IsUnknownAdditionalPropertiesDiscriminatedDerived("<name>", 1234);
            Response response = await client.PutAsync(body);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task IsUnknownDiscriminated_Put_AllParameters()
        {
            Uri endpoint = null;
            IsUnknownDiscriminated client = CreateAdditionalPropertiesClient(endpoint).GetIsUnknownDiscriminatedClient();

            using RequestContent content = RequestContent.Create(new
            {
                kind = "derived",
                index = 1234,
                age = 123.45F,
                name = "<name>",
            });
            Response response = await client.PutAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task IsUnknownDiscriminated_Put_AllParameters_Convenience()
        {
            Uri endpoint = null;
            IsUnknownDiscriminated client = CreateAdditionalPropertiesClient(endpoint).GetIsUnknownDiscriminatedClient();

            IsUnknownAdditionalPropertiesDiscriminated body = new IsUnknownAdditionalPropertiesDiscriminatedDerived("<name>", 1234)
            {
                Age = 123.45F,
            };
            Response response = await client.PutAsync(body);
        }
    }
}
