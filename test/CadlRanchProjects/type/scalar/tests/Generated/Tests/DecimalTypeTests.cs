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
using _Type.Scalar;

namespace _Type.Scalar.Tests
{
    public partial class DecimalTypeTests : _TypeScalarTestBase
    {
        public DecimalTypeTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task DecimalType_ResponseBody_ShortVersion()
        {
            Uri endpoint = null;
            DecimalType client = CreateScalarClient(endpoint).GetDecimalTypeClient(apiVersion: "1.0.0");

            Response response = await client.ResponseBodyAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task DecimalType_ResponseBody_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            DecimalType client = CreateScalarClient(endpoint).GetDecimalTypeClient(apiVersion: "1.0.0");

            Response<decimal> response = await client.ResponseBodyAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task DecimalType_ResponseBody_AllParameters()
        {
            Uri endpoint = null;
            DecimalType client = CreateScalarClient(endpoint).GetDecimalTypeClient(apiVersion: "1.0.0");

            Response response = await client.ResponseBodyAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task DecimalType_ResponseBody_AllParameters_Convenience()
        {
            Uri endpoint = null;
            DecimalType client = CreateScalarClient(endpoint).GetDecimalTypeClient(apiVersion: "1.0.0");

            Response<decimal> response = await client.ResponseBodyAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task DecimalType_RequestBody_ShortVersion()
        {
            Uri endpoint = null;
            DecimalType client = CreateScalarClient(endpoint).GetDecimalTypeClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.RequestBodyAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task DecimalType_RequestBody_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            DecimalType client = CreateScalarClient(endpoint).GetDecimalTypeClient(apiVersion: "1.0.0");

            Response response = await client.RequestBodyAsync((decimal)default);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task DecimalType_RequestBody_AllParameters()
        {
            Uri endpoint = null;
            DecimalType client = CreateScalarClient(endpoint).GetDecimalTypeClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.RequestBodyAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task DecimalType_RequestBody_AllParameters_Convenience()
        {
            Uri endpoint = null;
            DecimalType client = CreateScalarClient(endpoint).GetDecimalTypeClient(apiVersion: "1.0.0");

            Response response = await client.RequestBodyAsync((decimal)default);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task DecimalType_RequestParameter_ShortVersion()
        {
            Uri endpoint = null;
            DecimalType client = CreateScalarClient(endpoint).GetDecimalTypeClient(apiVersion: "1.0.0");

            Response response = await client.RequestParameterAsync(default);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task DecimalType_RequestParameter_AllParameters()
        {
            Uri endpoint = null;
            DecimalType client = CreateScalarClient(endpoint).GetDecimalTypeClient(apiVersion: "1.0.0");

            Response response = await client.RequestParameterAsync(default);
        }
    }
}
