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
    public partial class IntLiteralTests : _TypePropertyOptionalityTestBase
    {
        public IntLiteralTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task IntLiteral_GetAll_ShortVersion()
        {
            Uri endpoint = null;
            IntLiteral client = CreateOptionalClient(endpoint).GetIntLiteralClient();

            Response response = await client.GetAllAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task IntLiteral_GetAll_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            IntLiteral client = CreateOptionalClient(endpoint).GetIntLiteralClient();

            Response<IntLiteralProperty> response = await client.GetAllAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task IntLiteral_GetAll_AllParameters()
        {
            Uri endpoint = null;
            IntLiteral client = CreateOptionalClient(endpoint).GetIntLiteralClient();

            Response response = await client.GetAllAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task IntLiteral_GetAll_AllParameters_Convenience()
        {
            Uri endpoint = null;
            IntLiteral client = CreateOptionalClient(endpoint).GetIntLiteralClient();

            Response<IntLiteralProperty> response = await client.GetAllAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task IntLiteral_GetDefault_ShortVersion()
        {
            Uri endpoint = null;
            IntLiteral client = CreateOptionalClient(endpoint).GetIntLiteralClient();

            Response response = await client.GetDefaultAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task IntLiteral_GetDefault_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            IntLiteral client = CreateOptionalClient(endpoint).GetIntLiteralClient();

            Response<IntLiteralProperty> response = await client.GetDefaultAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task IntLiteral_GetDefault_AllParameters()
        {
            Uri endpoint = null;
            IntLiteral client = CreateOptionalClient(endpoint).GetIntLiteralClient();

            Response response = await client.GetDefaultAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task IntLiteral_GetDefault_AllParameters_Convenience()
        {
            Uri endpoint = null;
            IntLiteral client = CreateOptionalClient(endpoint).GetIntLiteralClient();

            Response<IntLiteralProperty> response = await client.GetDefaultAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task IntLiteral_PutAll_ShortVersion()
        {
            Uri endpoint = null;
            IntLiteral client = CreateOptionalClient(endpoint).GetIntLiteralClient();

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutAllAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task IntLiteral_PutAll_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            IntLiteral client = CreateOptionalClient(endpoint).GetIntLiteralClient();

            IntLiteralProperty body = new IntLiteralProperty();
            Response response = await client.PutAllAsync(body);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task IntLiteral_PutAll_AllParameters()
        {
            Uri endpoint = null;
            IntLiteral client = CreateOptionalClient(endpoint).GetIntLiteralClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = 1,
            });
            Response response = await client.PutAllAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task IntLiteral_PutAll_AllParameters_Convenience()
        {
            Uri endpoint = null;
            IntLiteral client = CreateOptionalClient(endpoint).GetIntLiteralClient();

            IntLiteralProperty body = new IntLiteralProperty
            {
                Property = IntLiteralPropertyProperty._1,
            };
            Response response = await client.PutAllAsync(body);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task IntLiteral_PutDefault_ShortVersion()
        {
            Uri endpoint = null;
            IntLiteral client = CreateOptionalClient(endpoint).GetIntLiteralClient();

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutDefaultAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task IntLiteral_PutDefault_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            IntLiteral client = CreateOptionalClient(endpoint).GetIntLiteralClient();

            IntLiteralProperty body = new IntLiteralProperty();
            Response response = await client.PutDefaultAsync(body);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task IntLiteral_PutDefault_AllParameters()
        {
            Uri endpoint = null;
            IntLiteral client = CreateOptionalClient(endpoint).GetIntLiteralClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = 1,
            });
            Response response = await client.PutDefaultAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task IntLiteral_PutDefault_AllParameters_Convenience()
        {
            Uri endpoint = null;
            IntLiteral client = CreateOptionalClient(endpoint).GetIntLiteralClient();

            IntLiteralProperty body = new IntLiteralProperty
            {
                Property = IntLiteralPropertyProperty._1,
            };
            Response response = await client.PutDefaultAsync(body);
        }
    }
}
