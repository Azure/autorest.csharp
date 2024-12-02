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

namespace security_aad_LowLevel.Tests
{
    public partial class AutorestSecurityAadClientTests : security_aad_LowLevelTestBase
    {
        public AutorestSecurityAadClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Head_ShortVersion()
        {
            Uri endpoint = null;
            TokenCredential credential = new DefaultAzureCredential();
            AutorestSecurityAadClient client = CreateAutorestSecurityAadClient(endpoint, credential);

            Response response = await client.HeadAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Head_AllParameters()
        {
            Uri endpoint = null;
            TokenCredential credential = new DefaultAzureCredential();
            AutorestSecurityAadClient client = CreateAutorestSecurityAadClient(endpoint, credential);

            Response response = await client.HeadAsync();
        }
    }
}
