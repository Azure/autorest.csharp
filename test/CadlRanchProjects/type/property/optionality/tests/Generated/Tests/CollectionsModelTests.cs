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
    public partial class CollectionsModelTests : _TypePropertyOptionalityTestBase
    {
        public CollectionsModelTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task CollectionsModel_GetAll_ShortVersion()
        {
            Uri endpoint = null;
            CollectionsModel client = CreateOptionalClient(endpoint).GetCollectionsModelClient(apiVersion: "1.0.0");

            Response response = await client.GetAllAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task CollectionsModel_GetAll_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            CollectionsModel client = CreateOptionalClient(endpoint).GetCollectionsModelClient(apiVersion: "1.0.0");

            Response<CollectionsModelProperty> response = await client.GetAllAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task CollectionsModel_GetAll_AllParameters()
        {
            Uri endpoint = null;
            CollectionsModel client = CreateOptionalClient(endpoint).GetCollectionsModelClient(apiVersion: "1.0.0");

            Response response = await client.GetAllAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task CollectionsModel_GetAll_AllParameters_Convenience()
        {
            Uri endpoint = null;
            CollectionsModel client = CreateOptionalClient(endpoint).GetCollectionsModelClient(apiVersion: "1.0.0");

            Response<CollectionsModelProperty> response = await client.GetAllAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task CollectionsModel_GetDefault_ShortVersion()
        {
            Uri endpoint = null;
            CollectionsModel client = CreateOptionalClient(endpoint).GetCollectionsModelClient(apiVersion: "1.0.0");

            Response response = await client.GetDefaultAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task CollectionsModel_GetDefault_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            CollectionsModel client = CreateOptionalClient(endpoint).GetCollectionsModelClient(apiVersion: "1.0.0");

            Response<CollectionsModelProperty> response = await client.GetDefaultAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task CollectionsModel_GetDefault_AllParameters()
        {
            Uri endpoint = null;
            CollectionsModel client = CreateOptionalClient(endpoint).GetCollectionsModelClient(apiVersion: "1.0.0");

            Response response = await client.GetDefaultAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task CollectionsModel_GetDefault_AllParameters_Convenience()
        {
            Uri endpoint = null;
            CollectionsModel client = CreateOptionalClient(endpoint).GetCollectionsModelClient(apiVersion: "1.0.0");

            Response<CollectionsModelProperty> response = await client.GetDefaultAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task CollectionsModel_PutAll_ShortVersion()
        {
            Uri endpoint = null;
            CollectionsModel client = CreateOptionalClient(endpoint).GetCollectionsModelClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutAllAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task CollectionsModel_PutAll_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            CollectionsModel client = CreateOptionalClient(endpoint).GetCollectionsModelClient(apiVersion: "1.0.0");

            CollectionsModelProperty body = new CollectionsModelProperty();
            Response response = await client.PutAllAsync(body);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task CollectionsModel_PutAll_AllParameters()
        {
            Uri endpoint = null;
            CollectionsModel client = CreateOptionalClient(endpoint).GetCollectionsModelClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new
            {
                property = new object[]
            {
new
{
property = "<property>",
}
            },
            });
            Response response = await client.PutAllAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task CollectionsModel_PutAll_AllParameters_Convenience()
        {
            Uri endpoint = null;
            CollectionsModel client = CreateOptionalClient(endpoint).GetCollectionsModelClient(apiVersion: "1.0.0");

            CollectionsModelProperty body = new CollectionsModelProperty
            {
                Property = {new StringProperty
{
Property = "<property>",
}},
            };
            Response response = await client.PutAllAsync(body);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task CollectionsModel_PutDefault_ShortVersion()
        {
            Uri endpoint = null;
            CollectionsModel client = CreateOptionalClient(endpoint).GetCollectionsModelClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutDefaultAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task CollectionsModel_PutDefault_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            CollectionsModel client = CreateOptionalClient(endpoint).GetCollectionsModelClient(apiVersion: "1.0.0");

            CollectionsModelProperty body = new CollectionsModelProperty();
            Response response = await client.PutDefaultAsync(body);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task CollectionsModel_PutDefault_AllParameters()
        {
            Uri endpoint = null;
            CollectionsModel client = CreateOptionalClient(endpoint).GetCollectionsModelClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new
            {
                property = new object[]
            {
new
{
property = "<property>",
}
            },
            });
            Response response = await client.PutDefaultAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task CollectionsModel_PutDefault_AllParameters_Convenience()
        {
            Uri endpoint = null;
            CollectionsModel client = CreateOptionalClient(endpoint).GetCollectionsModelClient(apiVersion: "1.0.0");

            CollectionsModelProperty body = new CollectionsModelProperty
            {
                Property = {new StringProperty
{
Property = "<property>",
}},
            };
            Response response = await client.PutDefaultAsync(body);
        }
    }
}
