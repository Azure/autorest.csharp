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
    public partial class GammaTests : ClientAndOperationGroupTestBase
    {
        public GammaTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Gamma_Four_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Gamma client = CreateClientAndOperationGroupClient(endpoint).GetGammaClient();

            Response response = await client.FourAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Gamma_Four_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Gamma client = CreateClientAndOperationGroupClient(endpoint).GetGammaClient();

            Response response = await client.FourAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Gamma_Five_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Gamma client = CreateClientAndOperationGroupClient(endpoint).GetGammaClient();

            Response response = await client.FiveAsync(null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Gamma_Five_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Gamma client = CreateClientAndOperationGroupClient(endpoint).GetGammaClient();

            Response response = await client.FiveAsync(null);
        }
    }
}
