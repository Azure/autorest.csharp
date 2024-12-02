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
using _Type.Property.ValueTypes.Models;

namespace _Type.Property.ValueTypes.Tests
{
    public partial class BooleanTests : _TypePropertyValueTypesTestBase
    {
        public BooleanTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Boolean_GetBoolean_ShortVersion()
        {
            Uri endpoint = null;
            Boolean client = CreateValueTypesClient(endpoint).GetBooleanClient();

            Response response = await client.GetBooleanAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Boolean_GetBoolean_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            Boolean client = CreateValueTypesClient(endpoint).GetBooleanClient();

            Response<BooleanProperty> response = await client.GetBooleanAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Boolean_GetBoolean_AllParameters()
        {
            Uri endpoint = null;
            Boolean client = CreateValueTypesClient(endpoint).GetBooleanClient();

            Response response = await client.GetBooleanAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Boolean_GetBoolean_AllParameters_Convenience()
        {
            Uri endpoint = null;
            Boolean client = CreateValueTypesClient(endpoint).GetBooleanClient();

            Response<BooleanProperty> response = await client.GetBooleanAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Boolean_Put_ShortVersion()
        {
            Uri endpoint = null;
            Boolean client = CreateValueTypesClient(endpoint).GetBooleanClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = true,
            });
            Response response = await client.PutAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Boolean_Put_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            Boolean client = CreateValueTypesClient(endpoint).GetBooleanClient();

            BooleanProperty body = new BooleanProperty(true);
            Response response = await client.PutAsync(body);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Boolean_Put_AllParameters()
        {
            Uri endpoint = null;
            Boolean client = CreateValueTypesClient(endpoint).GetBooleanClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = true,
            });
            Response response = await client.PutAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Boolean_Put_AllParameters_Convenience()
        {
            Uri endpoint = null;
            Boolean client = CreateValueTypesClient(endpoint).GetBooleanClient();

            BooleanProperty body = new BooleanProperty(true);
            Response response = await client.PutAsync(body);
        }
    }
}
