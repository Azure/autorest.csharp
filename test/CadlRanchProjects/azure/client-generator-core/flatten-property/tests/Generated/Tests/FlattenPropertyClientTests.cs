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
using _Specs_.Azure.ClientGenerator.Core.FlattenProperty.Models;

namespace _Specs_.Azure.ClientGenerator.Core.FlattenProperty.Tests
{
    public partial class FlattenPropertyClientTests : _Specs_AzureClientGeneratorCoreFlattenPropertyTestBase
    {
        public FlattenPropertyClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task FlattenProperty_PutFlattenModel_ShortVersion()
        {
            Uri endpoint = null;
            FlattenPropertyClient client = CreateFlattenPropertyClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
                description = "<description>",
                age = 1234,
            });
            Response response = await client.PutFlattenModelAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task FlattenProperty_PutFlattenModel_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            FlattenPropertyClient client = CreateFlattenPropertyClient(endpoint);

            FlattenModel input = new FlattenModel("<name>", "<description>", 1234);
            Response<FlattenModel> response = await client.PutFlattenModelAsync(input);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task FlattenProperty_PutFlattenModel_AllParameters()
        {
            Uri endpoint = null;
            FlattenPropertyClient client = CreateFlattenPropertyClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
                description = "<description>",
                age = 1234,
            });
            Response response = await client.PutFlattenModelAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task FlattenProperty_PutFlattenModel_AllParameters_Convenience()
        {
            Uri endpoint = null;
            FlattenPropertyClient client = CreateFlattenPropertyClient(endpoint);

            FlattenModel input = new FlattenModel("<name>", "<description>", 1234);
            Response<FlattenModel> response = await client.PutFlattenModelAsync(input);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task FlattenProperty_PutNestedFlattenModel_ShortVersion()
        {
            Uri endpoint = null;
            FlattenPropertyClient client = CreateFlattenPropertyClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
                summary = "<summary>",
                description = "<description>",
                age = 1234,
            });
            Response response = await client.PutNestedFlattenModelAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task FlattenProperty_PutNestedFlattenModel_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            FlattenPropertyClient client = CreateFlattenPropertyClient(endpoint);

            NestedFlattenModel input = new NestedFlattenModel("<name>", "<summary>", "<description>", 1234);
            Response<NestedFlattenModel> response = await client.PutNestedFlattenModelAsync(input);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task FlattenProperty_PutNestedFlattenModel_AllParameters()
        {
            Uri endpoint = null;
            FlattenPropertyClient client = CreateFlattenPropertyClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                name = "<name>",
                summary = "<summary>",
                description = "<description>",
                age = 1234,
            });
            Response response = await client.PutNestedFlattenModelAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task FlattenProperty_PutNestedFlattenModel_AllParameters_Convenience()
        {
            Uri endpoint = null;
            FlattenPropertyClient client = CreateFlattenPropertyClient(endpoint);

            NestedFlattenModel input = new NestedFlattenModel("<name>", "<summary>", "<description>", 1234);
            Response<NestedFlattenModel> response = await client.PutNestedFlattenModelAsync(input);
        }
    }
}
