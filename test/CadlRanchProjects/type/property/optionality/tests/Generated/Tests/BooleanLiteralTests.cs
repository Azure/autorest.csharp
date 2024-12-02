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
using _Type.Property.Optionality.Models;

namespace _Type.Property.Optionality.Tests
{
    public partial class BooleanLiteralTests : _TypePropertyOptionalityTestBase
    {
        public BooleanLiteralTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task BooleanLiteral_GetAll_ShortVersion()
        {
            Uri endpoint = null;
            BooleanLiteral client = CreateOptionalClient(endpoint).GetBooleanLiteralClient();

            Response response = await client.GetAllAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task BooleanLiteral_GetAll_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            BooleanLiteral client = CreateOptionalClient(endpoint).GetBooleanLiteralClient();

            Response<BooleanLiteralProperty> response = await client.GetAllAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task BooleanLiteral_GetAll_AllParameters()
        {
            Uri endpoint = null;
            BooleanLiteral client = CreateOptionalClient(endpoint).GetBooleanLiteralClient();

            Response response = await client.GetAllAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task BooleanLiteral_GetAll_AllParameters_Convenience()
        {
            Uri endpoint = null;
            BooleanLiteral client = CreateOptionalClient(endpoint).GetBooleanLiteralClient();

            Response<BooleanLiteralProperty> response = await client.GetAllAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task BooleanLiteral_GetDefault_ShortVersion()
        {
            Uri endpoint = null;
            BooleanLiteral client = CreateOptionalClient(endpoint).GetBooleanLiteralClient();

            Response response = await client.GetDefaultAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task BooleanLiteral_GetDefault_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            BooleanLiteral client = CreateOptionalClient(endpoint).GetBooleanLiteralClient();

            Response<BooleanLiteralProperty> response = await client.GetDefaultAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task BooleanLiteral_GetDefault_AllParameters()
        {
            Uri endpoint = null;
            BooleanLiteral client = CreateOptionalClient(endpoint).GetBooleanLiteralClient();

            Response response = await client.GetDefaultAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task BooleanLiteral_GetDefault_AllParameters_Convenience()
        {
            Uri endpoint = null;
            BooleanLiteral client = CreateOptionalClient(endpoint).GetBooleanLiteralClient();

            Response<BooleanLiteralProperty> response = await client.GetDefaultAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task BooleanLiteral_PutAll_ShortVersion()
        {
            Uri endpoint = null;
            BooleanLiteral client = CreateOptionalClient(endpoint).GetBooleanLiteralClient();

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutAllAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task BooleanLiteral_PutAll_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            BooleanLiteral client = CreateOptionalClient(endpoint).GetBooleanLiteralClient();

            BooleanLiteralProperty body = new BooleanLiteralProperty();
            Response response = await client.PutAllAsync(body);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task BooleanLiteral_PutAll_AllParameters()
        {
            Uri endpoint = null;
            BooleanLiteral client = CreateOptionalClient(endpoint).GetBooleanLiteralClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = true,
            });
            Response response = await client.PutAllAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task BooleanLiteral_PutAll_AllParameters_Convenience()
        {
            Uri endpoint = null;
            BooleanLiteral client = CreateOptionalClient(endpoint).GetBooleanLiteralClient();

            BooleanLiteralProperty body = new BooleanLiteralProperty
            {
                Property = true,
            };
            Response response = await client.PutAllAsync(body);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task BooleanLiteral_PutDefault_ShortVersion()
        {
            Uri endpoint = null;
            BooleanLiteral client = CreateOptionalClient(endpoint).GetBooleanLiteralClient();

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutDefaultAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task BooleanLiteral_PutDefault_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            BooleanLiteral client = CreateOptionalClient(endpoint).GetBooleanLiteralClient();

            BooleanLiteralProperty body = new BooleanLiteralProperty();
            Response response = await client.PutDefaultAsync(body);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task BooleanLiteral_PutDefault_AllParameters()
        {
            Uri endpoint = null;
            BooleanLiteral client = CreateOptionalClient(endpoint).GetBooleanLiteralClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = true,
            });
            Response response = await client.PutDefaultAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task BooleanLiteral_PutDefault_AllParameters_Convenience()
        {
            Uri endpoint = null;
            BooleanLiteral client = CreateOptionalClient(endpoint).GetBooleanLiteralClient();

            BooleanLiteralProperty body = new BooleanLiteralProperty
            {
                Property = true,
            };
            Response response = await client.PutDefaultAsync(body);
        }
    }
}
