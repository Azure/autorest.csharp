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
    public partial class DecimalTests : _TypePropertyValueTypesTestBase
    {
        public DecimalTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Decimal_GetDecimal_ShortVersion()
        {
            Uri endpoint = null;
            Decimal client = CreateValueTypesClient(endpoint).GetDecimalClient(apiVersion: "1.0.0");

            Response response = await client.GetDecimalAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Decimal_GetDecimal_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            Decimal client = CreateValueTypesClient(endpoint).GetDecimalClient(apiVersion: "1.0.0");

            Response<DecimalProperty> response = await client.GetDecimalAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Decimal_GetDecimal_AllParameters()
        {
            Uri endpoint = null;
            Decimal client = CreateValueTypesClient(endpoint).GetDecimalClient(apiVersion: "1.0.0");

            Response response = await client.GetDecimalAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Decimal_GetDecimal_AllParameters_Convenience()
        {
            Uri endpoint = null;
            Decimal client = CreateValueTypesClient(endpoint).GetDecimalClient(apiVersion: "1.0.0");

            Response<DecimalProperty> response = await client.GetDecimalAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Decimal_Put_ShortVersion()
        {
            Uri endpoint = null;
            Decimal client = CreateValueTypesClient(endpoint).GetDecimalClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new
            {
                property = new object(),
            });
            Response response = await client.PutAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Decimal_Put_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            Decimal client = CreateValueTypesClient(endpoint).GetDecimalClient(apiVersion: "1.0.0");

            DecimalProperty body = new DecimalProperty(default);
            Response response = await client.PutAsync(body);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Decimal_Put_AllParameters()
        {
            Uri endpoint = null;
            Decimal client = CreateValueTypesClient(endpoint).GetDecimalClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new
            {
                property = new object(),
            });
            Response response = await client.PutAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Decimal_Put_AllParameters_Convenience()
        {
            Uri endpoint = null;
            Decimal client = CreateValueTypesClient(endpoint).GetDecimalClient(apiVersion: "1.0.0");

            DecimalProperty body = new DecimalProperty(default);
            Response response = await client.PutAsync(body);
        }
    }
}
