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
    public partial class UnionStringLiteralTests : _TypePropertyValueTypesTestBase
    {
        public UnionStringLiteralTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task UnionStringLiteral_GetUnionStringLiteral_ShortVersion()
        {
            Uri endpoint = null;
            UnionStringLiteral client = CreateValueTypesClient(endpoint).GetUnionStringLiteralClient();

            Response response = await client.GetUnionStringLiteralAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task UnionStringLiteral_GetUnionStringLiteral_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            UnionStringLiteral client = CreateValueTypesClient(endpoint).GetUnionStringLiteralClient();

            Response<UnionStringLiteralProperty> response = await client.GetUnionStringLiteralAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task UnionStringLiteral_GetUnionStringLiteral_AllParameters()
        {
            Uri endpoint = null;
            UnionStringLiteral client = CreateValueTypesClient(endpoint).GetUnionStringLiteralClient();

            Response response = await client.GetUnionStringLiteralAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task UnionStringLiteral_GetUnionStringLiteral_AllParameters_Convenience()
        {
            Uri endpoint = null;
            UnionStringLiteral client = CreateValueTypesClient(endpoint).GetUnionStringLiteralClient();

            Response<UnionStringLiteralProperty> response = await client.GetUnionStringLiteralAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task UnionStringLiteral_Put_ShortVersion()
        {
            Uri endpoint = null;
            UnionStringLiteral client = CreateValueTypesClient(endpoint).GetUnionStringLiteralClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = "hello",
            });
            Response response = await client.PutAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task UnionStringLiteral_Put_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            UnionStringLiteral client = CreateValueTypesClient(endpoint).GetUnionStringLiteralClient();

            UnionStringLiteralProperty body = new UnionStringLiteralProperty(UnionStringLiteralPropertyProperty.Hello);
            Response response = await client.PutAsync(body);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task UnionStringLiteral_Put_AllParameters()
        {
            Uri endpoint = null;
            UnionStringLiteral client = CreateValueTypesClient(endpoint).GetUnionStringLiteralClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = "hello",
            });
            Response response = await client.PutAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task UnionStringLiteral_Put_AllParameters_Convenience()
        {
            Uri endpoint = null;
            UnionStringLiteral client = CreateValueTypesClient(endpoint).GetUnionStringLiteralClient();

            UnionStringLiteralProperty body = new UnionStringLiteralProperty(UnionStringLiteralPropertyProperty.Hello);
            Response response = await client.PutAsync(body);
        }
    }
}
