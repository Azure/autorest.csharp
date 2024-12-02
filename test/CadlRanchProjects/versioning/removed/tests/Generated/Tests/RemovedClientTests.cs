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
using Versioning.Removed.LatestVersion.Models;

namespace Versioning.Removed.LatestVersion.Tests
{
    public partial class RemovedClientTests : VersioningRemovedLatestVersionTestBase
    {
        public RemovedClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Removed_V2_ShortVersion()
        {
            Uri endpoint = new Uri("<endpoint>");
            RemovedClient client = CreateRemovedClient(endpoint, default);

            using RequestContent content = RequestContent.Create(new
            {
                prop = "<prop>",
                enumProp = "enumMemberV2",
                unionProp = "<unionProp>",
            });
            Response response = await client.V2Async(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Removed_V2_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<endpoint>");
            RemovedClient client = CreateRemovedClient(endpoint, default);

            ModelV2 body = new ModelV2("<prop>", EnumV2.EnumMemberV2, BinaryData.FromObjectAsJson("<unionProp>"));
            Response<ModelV2> response = await client.V2Async(body);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Removed_V2_AllParameters()
        {
            Uri endpoint = new Uri("<endpoint>");
            RemovedClient client = CreateRemovedClient(endpoint, default);

            using RequestContent content = RequestContent.Create(new
            {
                prop = "<prop>",
                enumProp = "enumMemberV2",
                unionProp = "<unionProp>",
            });
            Response response = await client.V2Async(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Removed_V2_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<endpoint>");
            RemovedClient client = CreateRemovedClient(endpoint, default);

            ModelV2 body = new ModelV2("<prop>", EnumV2.EnumMemberV2, BinaryData.FromObjectAsJson("<unionProp>"));
            Response<ModelV2> response = await client.V2Async(body);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Removed_ModelV3_ShortVersion()
        {
            Uri endpoint = new Uri("<endpoint>");
            RemovedClient client = CreateRemovedClient(endpoint, default);

            using RequestContent content = RequestContent.Create(new
            {
                id = "<id>",
                enumProp = "enumMemberV1",
            });
            Response response = await client.ModelV3Async(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Removed_ModelV3_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<endpoint>");
            RemovedClient client = CreateRemovedClient(endpoint, default);

            ModelV3 body = new ModelV3("<id>", EnumV3.EnumMemberV1);
            Response<ModelV3> response = await client.ModelV3Async(body);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Removed_ModelV3_AllParameters()
        {
            Uri endpoint = new Uri("<endpoint>");
            RemovedClient client = CreateRemovedClient(endpoint, default);

            using RequestContent content = RequestContent.Create(new
            {
                id = "<id>",
                enumProp = "enumMemberV1",
            });
            Response response = await client.ModelV3Async(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Removed_ModelV3_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<endpoint>");
            RemovedClient client = CreateRemovedClient(endpoint, default);

            ModelV3 body = new ModelV3("<id>", EnumV3.EnumMemberV1);
            Response<ModelV3> response = await client.ModelV3Async(body);
        }
    }
}
