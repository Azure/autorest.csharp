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
    public partial class CollectionsByteTests : _TypePropertyOptionalityTestBase
    {
        public CollectionsByteTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task CollectionsByte_GetAll_ShortVersion()
        {
            Uri endpoint = null;
            CollectionsByte client = CreateOptionalClient(endpoint).GetCollectionsByteClient(apiVersion: "1.0.0");

            Response response = await client.GetAllAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task CollectionsByte_GetAll_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            CollectionsByte client = CreateOptionalClient(endpoint).GetCollectionsByteClient(apiVersion: "1.0.0");

            Response<CollectionsByteProperty> response = await client.GetAllAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task CollectionsByte_GetAll_AllParameters()
        {
            Uri endpoint = null;
            CollectionsByte client = CreateOptionalClient(endpoint).GetCollectionsByteClient(apiVersion: "1.0.0");

            Response response = await client.GetAllAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task CollectionsByte_GetAll_AllParameters_Convenience()
        {
            Uri endpoint = null;
            CollectionsByte client = CreateOptionalClient(endpoint).GetCollectionsByteClient(apiVersion: "1.0.0");

            Response<CollectionsByteProperty> response = await client.GetAllAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task CollectionsByte_GetDefault_ShortVersion()
        {
            Uri endpoint = null;
            CollectionsByte client = CreateOptionalClient(endpoint).GetCollectionsByteClient(apiVersion: "1.0.0");

            Response response = await client.GetDefaultAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task CollectionsByte_GetDefault_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            CollectionsByte client = CreateOptionalClient(endpoint).GetCollectionsByteClient(apiVersion: "1.0.0");

            Response<CollectionsByteProperty> response = await client.GetDefaultAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task CollectionsByte_GetDefault_AllParameters()
        {
            Uri endpoint = null;
            CollectionsByte client = CreateOptionalClient(endpoint).GetCollectionsByteClient(apiVersion: "1.0.0");

            Response response = await client.GetDefaultAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task CollectionsByte_GetDefault_AllParameters_Convenience()
        {
            Uri endpoint = null;
            CollectionsByte client = CreateOptionalClient(endpoint).GetCollectionsByteClient(apiVersion: "1.0.0");

            Response<CollectionsByteProperty> response = await client.GetDefaultAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task CollectionsByte_PutAll_ShortVersion()
        {
            Uri endpoint = null;
            CollectionsByte client = CreateOptionalClient(endpoint).GetCollectionsByteClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutAllAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task CollectionsByte_PutAll_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            CollectionsByte client = CreateOptionalClient(endpoint).GetCollectionsByteClient(apiVersion: "1.0.0");

            CollectionsByteProperty body = new CollectionsByteProperty();
            Response response = await client.PutAllAsync(body);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task CollectionsByte_PutAll_AllParameters()
        {
            Uri endpoint = null;
            CollectionsByte client = CreateOptionalClient(endpoint).GetCollectionsByteClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new
            {
                property = new object[]
            {
new object()
            },
            });
            Response response = await client.PutAllAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task CollectionsByte_PutAll_AllParameters_Convenience()
        {
            Uri endpoint = null;
            CollectionsByte client = CreateOptionalClient(endpoint).GetCollectionsByteClient(apiVersion: "1.0.0");

            CollectionsByteProperty body = new CollectionsByteProperty
            {
                Property = { BinaryData.FromObjectAsJson(new object()) },
            };
            Response response = await client.PutAllAsync(body);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task CollectionsByte_PutDefault_ShortVersion()
        {
            Uri endpoint = null;
            CollectionsByte client = CreateOptionalClient(endpoint).GetCollectionsByteClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutDefaultAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task CollectionsByte_PutDefault_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            CollectionsByte client = CreateOptionalClient(endpoint).GetCollectionsByteClient(apiVersion: "1.0.0");

            CollectionsByteProperty body = new CollectionsByteProperty();
            Response response = await client.PutDefaultAsync(body);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task CollectionsByte_PutDefault_AllParameters()
        {
            Uri endpoint = null;
            CollectionsByte client = CreateOptionalClient(endpoint).GetCollectionsByteClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new
            {
                property = new object[]
            {
new object()
            },
            });
            Response response = await client.PutDefaultAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task CollectionsByte_PutDefault_AllParameters_Convenience()
        {
            Uri endpoint = null;
            CollectionsByte client = CreateOptionalClient(endpoint).GetCollectionsByteClient(apiVersion: "1.0.0");

            CollectionsByteProperty body = new CollectionsByteProperty
            {
                Property = { BinaryData.FromObjectAsJson(new object()) },
            };
            Response response = await client.PutDefaultAsync(body);
        }
    }
}
