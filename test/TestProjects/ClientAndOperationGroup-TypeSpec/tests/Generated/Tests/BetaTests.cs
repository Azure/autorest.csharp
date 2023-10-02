// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using ClientAndOperationGroup;
using NUnit.Framework;

namespace ClientAndOperationGroup.Tests
{
    public partial class BetaTests : ClientAndOperationGroupTestBase
    {
        public BetaTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task Two_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Beta client = CreateClientAndOperationGroupClient(endpoint).GetBetaClient();

            Response response = await client.TwoAsync(null);
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task Two_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Beta client = CreateClientAndOperationGroupClient(endpoint).GetBetaClient();

            Response response = await client.TwoAsync(null);
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task Three_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Beta client = CreateClientAndOperationGroupClient(endpoint).GetBetaClient();

            Response response = await client.ThreeAsync(null);
        }

        [Test]
        [Ignore("Only validating compilation of test scaffoldings")]
        public async Task Three_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Beta client = CreateClientAndOperationGroupClient(endpoint).GetBetaClient();

            Response response = await client.ThreeAsync(null);
        }
    }
}
