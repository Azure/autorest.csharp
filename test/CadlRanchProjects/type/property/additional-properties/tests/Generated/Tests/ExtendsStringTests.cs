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
    public partial class ExtendsStringTests : _TypePropertyAdditionalPropertiesTestBase
    {
        public ExtendsStringTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ExtendsString_GetExtendsString_ShortVersion()
        {
            Uri endpoint = null;
            ExtendsString client = CreateAdditionalPropertiesClient(endpoint).GetExtendsStringClient();

            Response response = await client.GetExtendsStringAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ExtendsString_GetExtendsString_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            ExtendsString client = CreateAdditionalPropertiesClient(endpoint).GetExtendsStringClient();

            Response<ExtendsStringAdditionalProperties> response = await client.GetExtendsStringAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ExtendsString_GetExtendsString_AllParameters()
        {
            Uri endpoint = null;
            ExtendsString client = CreateAdditionalPropertiesClient(endpoint).GetExtendsStringClient();

            Response response = await client.GetExtendsStringAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ExtendsString_GetExtendsString_AllParameters_Convenience()
        {
            Uri endpoint = null;
            ExtendsString client = CreateAdditionalPropertiesClient(endpoint).GetExtendsStringClient();

            Response<ExtendsStringAdditionalProperties> response = await client.GetExtendsStringAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ExtendsString_Put_ShortVersion()
        {
            Uri endpoint = null;
            ExtendsString client = CreateAdditionalPropertiesClient(endpoint).GetExtendsStringClient();

            using RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
            });
            Response response = await client.PutAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ExtendsString_Put_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            ExtendsString client = CreateAdditionalPropertiesClient(endpoint).GetExtendsStringClient();

            ExtendsStringAdditionalProperties body = new ExtendsStringAdditionalProperties("<name>");
            Response response = await client.PutAsync(body);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ExtendsString_Put_AllParameters()
        {
            Uri endpoint = null;
            ExtendsString client = CreateAdditionalPropertiesClient(endpoint).GetExtendsStringClient();

            using RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
            });
            Response response = await client.PutAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task ExtendsString_Put_AllParameters_Convenience()
        {
            Uri endpoint = null;
            ExtendsString client = CreateAdditionalPropertiesClient(endpoint).GetExtendsStringClient();

            ExtendsStringAdditionalProperties body = new ExtendsStringAdditionalProperties("<name>");
            Response response = await client.PutAsync(body);
        }
    }
}
