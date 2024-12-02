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
using Versioning.Removed.OldVersion.Models;

namespace Versioning.Removed.OldVersion.Tests
{
    public partial class RemovedClientTests : VersioningRemovedOldVersionTestBase
    {
        public RemovedClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Removed_V1_ShortVersion()
        {
            Uri endpoint = new Uri("<endpoint>");
            RemovedClient client = CreateRemovedClient(endpoint, default);

            using RequestContent content = RequestContent.Create(new
            {
                prop = "<prop>",
                enumProp = "enumMember",
                unionProp = "<unionProp>",
            });
            Response response = await client.V1Async(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Removed_V1_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<endpoint>");
            RemovedClient client = CreateRemovedClient(endpoint, default);

            ModelV1 body = new ModelV1("<prop>", EnumV1.EnumMember, BinaryData.FromObjectAsJson("<unionProp>"));
            Response<ModelV1> response = await client.V1Async(body);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Removed_V1_AllParameters()
        {
            Uri endpoint = new Uri("<endpoint>");
            RemovedClient client = CreateRemovedClient(endpoint, default);

            using RequestContent content = RequestContent.Create(new
            {
                prop = "<prop>",
                enumProp = "enumMember",
                unionProp = "<unionProp>",
            });
            Response response = await client.V1Async(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Removed_V1_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<endpoint>");
            RemovedClient client = CreateRemovedClient(endpoint, default);

            ModelV1 body = new ModelV1("<prop>", EnumV1.EnumMember, BinaryData.FromObjectAsJson("<unionProp>"));
            Response<ModelV1> response = await client.V1Async(body);
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
                removedProp = "<removedProp>",
                enumProp = "enumMemberV1",
                unionProp = "<unionProp>",
            });
            Response response = await client.V2Async("<param>", content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Removed_V2_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<endpoint>");
            RemovedClient client = CreateRemovedClient(endpoint, default);

            ModelV2 body = new ModelV2("<prop>", "<removedProp>", EnumV2.EnumMemberV1, BinaryData.FromObjectAsJson("<unionProp>"));
            Response<ModelV2> response = await client.V2Async("<param>", body);
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
                removedProp = "<removedProp>",
                enumProp = "enumMemberV1",
                unionProp = "<unionProp>",
            });
            Response response = await client.V2Async("<param>", content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Removed_V2_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<endpoint>");
            RemovedClient client = CreateRemovedClient(endpoint, default);

            ModelV2 body = new ModelV2("<prop>", "<removedProp>", EnumV2.EnumMemberV1, BinaryData.FromObjectAsJson("<unionProp>"));
            Response<ModelV2> response = await client.V2Async("<param>", body);
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
