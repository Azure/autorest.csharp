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
using _Type.Union.Models;

namespace _Type.Union.Tests
{
    public partial class FloatsOnlyTests : _TypeUnionTestBase
    {
        public FloatsOnlyTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task FloatsOnly_GetFloatsOnly_ShortVersion()
        {
            Uri endpoint = null;
            FloatsOnly client = CreateUnionClient(endpoint).GetFloatsOnlyClient();

            Response response = await client.GetFloatsOnlyAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task FloatsOnly_GetFloatsOnly_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            FloatsOnly client = CreateUnionClient(endpoint).GetFloatsOnlyClient();

            Response<GetResponse5> response = await client.GetFloatsOnlyAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task FloatsOnly_GetFloatsOnly_AllParameters()
        {
            Uri endpoint = null;
            FloatsOnly client = CreateUnionClient(endpoint).GetFloatsOnlyClient();

            Response response = await client.GetFloatsOnlyAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task FloatsOnly_GetFloatsOnly_AllParameters_Convenience()
        {
            Uri endpoint = null;
            FloatsOnly client = CreateUnionClient(endpoint).GetFloatsOnlyClient();

            Response<GetResponse5> response = await client.GetFloatsOnlyAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task FloatsOnly_Send_ShortVersion()
        {
            Uri endpoint = null;
            FloatsOnly client = CreateUnionClient(endpoint).GetFloatsOnlyClient();

            using RequestContent content = RequestContent.Create(new
            {
                prop = 1.1F,
            });
            Response response = await client.SendAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task FloatsOnly_Send_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            FloatsOnly client = CreateUnionClient(endpoint).GetFloatsOnlyClient();

            Response response = await client.SendAsync(GetResponseProp1._11);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task FloatsOnly_Send_AllParameters()
        {
            Uri endpoint = null;
            FloatsOnly client = CreateUnionClient(endpoint).GetFloatsOnlyClient();

            using RequestContent content = RequestContent.Create(new
            {
                prop = 1.1F,
            });
            Response response = await client.SendAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task FloatsOnly_Send_AllParameters_Convenience()
        {
            Uri endpoint = null;
            FloatsOnly client = CreateUnionClient(endpoint).GetFloatsOnlyClient();

            Response response = await client.SendAsync(GetResponseProp1._11);
        }
    }
}
