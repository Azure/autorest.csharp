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

namespace PaginationParams_LowLevel.Tests
{
    public partial class PaginationParamsClientTests : PaginationParams_LowLevelTestBase
    {
        public PaginationParamsClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task PaginationParams_GetPaginationParams_ShortVersion()
        {
            Uri endpoint = null;
            TokenCredential credential = new DefaultAzureCredential();
            PaginationParamsClient client = CreatePaginationParamsClient(endpoint, credential);

            await foreach (BinaryData item in client.GetPaginationParamsAsync(null, null, null, null))
            {
            }
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task PaginationParams_GetPaginationParams_AllParameters()
        {
            Uri endpoint = null;
            TokenCredential credential = new DefaultAzureCredential();
            PaginationParamsClient client = CreatePaginationParamsClient(endpoint, credential);

            await foreach (BinaryData item in client.GetPaginationParamsAsync(1234, 1234, 1234, null))
            {
            }
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task PaginationParams_Get2s_ShortVersion()
        {
            Uri endpoint = null;
            TokenCredential credential = new DefaultAzureCredential();
            PaginationParamsClient client = CreatePaginationParamsClient(endpoint, credential);

            await foreach (BinaryData item in client.Get2sAsync(null, null, null, null))
            {
            }
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task PaginationParams_Get2s_AllParameters()
        {
            Uri endpoint = null;
            TokenCredential credential = new DefaultAzureCredential();
            PaginationParamsClient client = CreatePaginationParamsClient(endpoint, credential);

            await foreach (BinaryData item in client.Get2sAsync(1234, 1234, 1234L, null))
            {
            }
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task PaginationParams_Get3s_ShortVersion()
        {
            Uri endpoint = null;
            TokenCredential credential = new DefaultAzureCredential();
            PaginationParamsClient client = CreatePaginationParamsClient(endpoint, credential);

            await foreach (BinaryData item in client.Get3sAsync(null, null, null, null))
            {
            }
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task PaginationParams_Get3s_AllParameters()
        {
            Uri endpoint = null;
            TokenCredential credential = new DefaultAzureCredential();
            PaginationParamsClient client = CreatePaginationParamsClient(endpoint, credential);

            await foreach (BinaryData item in client.Get3sAsync(1234, 1234, 1234, null))
            {
            }
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task PaginationParams_Get4s_ShortVersion()
        {
            Uri endpoint = null;
            TokenCredential credential = new DefaultAzureCredential();
            PaginationParamsClient client = CreatePaginationParamsClient(endpoint, credential);

            await foreach (BinaryData item in client.Get4sAsync(null, null, null, null))
            {
            }
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task PaginationParams_Get4s_AllParameters()
        {
            Uri endpoint = null;
            TokenCredential credential = new DefaultAzureCredential();
            PaginationParamsClient client = CreatePaginationParamsClient(endpoint, credential);

            await foreach (BinaryData item in client.Get4sAsync(1234, 1234, 123.45F, null))
            {
            }
        }
    }
}
