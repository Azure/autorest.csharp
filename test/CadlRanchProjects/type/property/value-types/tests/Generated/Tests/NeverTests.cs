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
using _Type.Property.ValueTypes;
using _Type.Property.ValueTypes.Models;

namespace _Type.Property.ValueTypes.Tests
{
    public partial class NeverTests : _TypePropertyValueTypesTestBase
    {
        public NeverTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Never_GetNever_ShortVersion()
        {
            Uri endpoint = null;
            Never client = CreateValueTypesClient(endpoint).GetNeverClient(apiVersion: "1.0.0");

            Response response = await client.GetNeverAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Never_GetNever_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            Never client = CreateValueTypesClient(endpoint).GetNeverClient(apiVersion: "1.0.0");

            Response<NeverProperty> response = await client.GetNeverAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Never_GetNever_AllParameters()
        {
            Uri endpoint = null;
            Never client = CreateValueTypesClient(endpoint).GetNeverClient(apiVersion: "1.0.0");

            Response response = await client.GetNeverAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Never_GetNever_AllParameters_Convenience()
        {
            Uri endpoint = null;
            Never client = CreateValueTypesClient(endpoint).GetNeverClient(apiVersion: "1.0.0");

            Response<NeverProperty> response = await client.GetNeverAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Never_Put_ShortVersion()
        {
            Uri endpoint = null;
            Never client = CreateValueTypesClient(endpoint).GetNeverClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Never_Put_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            Never client = CreateValueTypesClient(endpoint).GetNeverClient(apiVersion: "1.0.0");

            NeverProperty body = new NeverProperty();
            Response response = await client.PutAsync(body);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Never_Put_AllParameters()
        {
            Uri endpoint = null;
            Never client = CreateValueTypesClient(endpoint).GetNeverClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Never_Put_AllParameters_Convenience()
        {
            Uri endpoint = null;
            Never client = CreateValueTypesClient(endpoint).GetNeverClient(apiVersion: "1.0.0");

            NeverProperty body = new NeverProperty();
            Response response = await client.PutAsync(body);
        }
    }
}
