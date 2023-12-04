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
using _Type.Property.Optionality;
using _Type.Property.Optionality.Models;

namespace _Type.Property.Optionality.Tests
{
    public partial class UnionIntLiteralTests : _TypePropertyOptionalityTestBase
    {
        public UnionIntLiteralTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task UnionIntLiteral_GetAll_ShortVersion()
        {
            Uri endpoint = null;
            UnionIntLiteral client = CreateOptionalClient(endpoint).GetUnionIntLiteralClient(apiVersion: "1.0.0");

            Response response = await client.GetAllAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task UnionIntLiteral_GetAll_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            UnionIntLiteral client = CreateOptionalClient(endpoint).GetUnionIntLiteralClient(apiVersion: "1.0.0");

            Response<UnionIntLiteralProperty> response = await client.GetAllAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task UnionIntLiteral_GetAll_AllParameters()
        {
            Uri endpoint = null;
            UnionIntLiteral client = CreateOptionalClient(endpoint).GetUnionIntLiteralClient(apiVersion: "1.0.0");

            Response response = await client.GetAllAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task UnionIntLiteral_GetAll_AllParameters_Convenience()
        {
            Uri endpoint = null;
            UnionIntLiteral client = CreateOptionalClient(endpoint).GetUnionIntLiteralClient(apiVersion: "1.0.0");

            Response<UnionIntLiteralProperty> response = await client.GetAllAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task UnionIntLiteral_GetDefault_ShortVersion()
        {
            Uri endpoint = null;
            UnionIntLiteral client = CreateOptionalClient(endpoint).GetUnionIntLiteralClient(apiVersion: "1.0.0");

            Response response = await client.GetDefaultAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task UnionIntLiteral_GetDefault_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            UnionIntLiteral client = CreateOptionalClient(endpoint).GetUnionIntLiteralClient(apiVersion: "1.0.0");

            Response<UnionIntLiteralProperty> response = await client.GetDefaultAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task UnionIntLiteral_GetDefault_AllParameters()
        {
            Uri endpoint = null;
            UnionIntLiteral client = CreateOptionalClient(endpoint).GetUnionIntLiteralClient(apiVersion: "1.0.0");

            Response response = await client.GetDefaultAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task UnionIntLiteral_GetDefault_AllParameters_Convenience()
        {
            Uri endpoint = null;
            UnionIntLiteral client = CreateOptionalClient(endpoint).GetUnionIntLiteralClient(apiVersion: "1.0.0");

            Response<UnionIntLiteralProperty> response = await client.GetDefaultAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task UnionIntLiteral_PutAll_ShortVersion()
        {
            Uri endpoint = null;
            UnionIntLiteral client = CreateOptionalClient(endpoint).GetUnionIntLiteralClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutAllAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task UnionIntLiteral_PutAll_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            UnionIntLiteral client = CreateOptionalClient(endpoint).GetUnionIntLiteralClient(apiVersion: "1.0.0");

            UnionIntLiteralProperty body = new UnionIntLiteralProperty();
            Response response = await client.PutAllAsync(body);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task UnionIntLiteral_PutAll_AllParameters()
        {
            Uri endpoint = null;
            UnionIntLiteral client = CreateOptionalClient(endpoint).GetUnionIntLiteralClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new
            {
                property = 1,
            });
            Response response = await client.PutAllAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task UnionIntLiteral_PutAll_AllParameters_Convenience()
        {
            Uri endpoint = null;
            UnionIntLiteral client = CreateOptionalClient(endpoint).GetUnionIntLiteralClient(apiVersion: "1.0.0");

            UnionIntLiteralProperty body = new UnionIntLiteralProperty
            {
                Property = BinaryData.FromObjectAsJson(1),
            };
            Response response = await client.PutAllAsync(body);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task UnionIntLiteral_PutDefault_ShortVersion()
        {
            Uri endpoint = null;
            UnionIntLiteral client = CreateOptionalClient(endpoint).GetUnionIntLiteralClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutDefaultAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task UnionIntLiteral_PutDefault_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            UnionIntLiteral client = CreateOptionalClient(endpoint).GetUnionIntLiteralClient(apiVersion: "1.0.0");

            UnionIntLiteralProperty body = new UnionIntLiteralProperty();
            Response response = await client.PutDefaultAsync(body);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task UnionIntLiteral_PutDefault_AllParameters()
        {
            Uri endpoint = null;
            UnionIntLiteral client = CreateOptionalClient(endpoint).GetUnionIntLiteralClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new
            {
                property = 1,
            });
            Response response = await client.PutDefaultAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task UnionIntLiteral_PutDefault_AllParameters_Convenience()
        {
            Uri endpoint = null;
            UnionIntLiteral client = CreateOptionalClient(endpoint).GetUnionIntLiteralClient(apiVersion: "1.0.0");

            UnionIntLiteralProperty body = new UnionIntLiteralProperty
            {
                Property = BinaryData.FromObjectAsJson(1),
            };
            Response response = await client.PutDefaultAsync(body);
        }
    }
}
