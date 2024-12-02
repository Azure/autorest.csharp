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
    public partial class IsStringTests : _TypePropertyAdditionalPropertiesTestBase
    {
        public IsStringTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task IsString_GetIsString_ShortVersion()
        {
            Uri endpoint = null;
            IsString client = CreateAdditionalPropertiesClient(endpoint).GetIsStringClient();

            Response response = await client.GetIsStringAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task IsString_GetIsString_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            IsString client = CreateAdditionalPropertiesClient(endpoint).GetIsStringClient();

            Response<IsStringAdditionalProperties> response = await client.GetIsStringAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task IsString_GetIsString_AllParameters()
        {
            Uri endpoint = null;
            IsString client = CreateAdditionalPropertiesClient(endpoint).GetIsStringClient();

            Response response = await client.GetIsStringAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task IsString_GetIsString_AllParameters_Convenience()
        {
            Uri endpoint = null;
            IsString client = CreateAdditionalPropertiesClient(endpoint).GetIsStringClient();

            Response<IsStringAdditionalProperties> response = await client.GetIsStringAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task IsString_Put_ShortVersion()
        {
            Uri endpoint = null;
            IsString client = CreateAdditionalPropertiesClient(endpoint).GetIsStringClient();

            using RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
            });
            Response response = await client.PutAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task IsString_Put_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            IsString client = CreateAdditionalPropertiesClient(endpoint).GetIsStringClient();

            IsStringAdditionalProperties body = new IsStringAdditionalProperties("<name>");
            Response response = await client.PutAsync(body);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task IsString_Put_AllParameters()
        {
            Uri endpoint = null;
            IsString client = CreateAdditionalPropertiesClient(endpoint).GetIsStringClient();

            using RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
            });
            Response response = await client.PutAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task IsString_Put_AllParameters_Convenience()
        {
            Uri endpoint = null;
            IsString client = CreateAdditionalPropertiesClient(endpoint).GetIsStringClient();

            IsStringAdditionalProperties body = new IsStringAdditionalProperties("<name>");
            Response response = await client.PutAsync(body);
        }
    }
}
