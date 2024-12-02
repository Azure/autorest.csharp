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
    public partial class UnknownArrayTests : _TypePropertyValueTypesTestBase
    {
        public UnknownArrayTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task UnknownArray_GetUnknownArray_ShortVersion()
        {
            Uri endpoint = null;
            UnknownArray client = CreateValueTypesClient(endpoint).GetUnknownArrayClient();

            Response response = await client.GetUnknownArrayAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task UnknownArray_GetUnknownArray_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            UnknownArray client = CreateValueTypesClient(endpoint).GetUnknownArrayClient();

            Response<UnknownArrayProperty> response = await client.GetUnknownArrayAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task UnknownArray_GetUnknownArray_AllParameters()
        {
            Uri endpoint = null;
            UnknownArray client = CreateValueTypesClient(endpoint).GetUnknownArrayClient();

            Response response = await client.GetUnknownArrayAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task UnknownArray_GetUnknownArray_AllParameters_Convenience()
        {
            Uri endpoint = null;
            UnknownArray client = CreateValueTypesClient(endpoint).GetUnknownArrayClient();

            Response<UnknownArrayProperty> response = await client.GetUnknownArrayAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task UnknownArray_Put_ShortVersion()
        {
            Uri endpoint = null;
            UnknownArray client = CreateValueTypesClient(endpoint).GetUnknownArrayClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = new object(),
            });
            Response response = await client.PutAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task UnknownArray_Put_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            UnknownArray client = CreateValueTypesClient(endpoint).GetUnknownArrayClient();

            UnknownArrayProperty body = new UnknownArrayProperty(BinaryData.FromObjectAsJson(new object()));
            Response response = await client.PutAsync(body);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task UnknownArray_Put_AllParameters()
        {
            Uri endpoint = null;
            UnknownArray client = CreateValueTypesClient(endpoint).GetUnknownArrayClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = new object(),
            });
            Response response = await client.PutAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task UnknownArray_Put_AllParameters_Convenience()
        {
            Uri endpoint = null;
            UnknownArray client = CreateValueTypesClient(endpoint).GetUnknownArrayClient();

            UnknownArrayProperty body = new UnknownArrayProperty(BinaryData.FromObjectAsJson(new object()));
            Response response = await client.PutAsync(body);
        }
    }
}
