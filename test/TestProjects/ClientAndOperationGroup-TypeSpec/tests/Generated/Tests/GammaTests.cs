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
    public class GammaTests : ClientAndOperationGroupTestBase
    {
        public GammaTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Four_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Gamma client = CreateClientAndOperationGroupClient(endpoint).GetGammaClient();

            Response response = await client.FourAsync(null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Four_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Gamma client = CreateClientAndOperationGroupClient(endpoint).GetGammaClient();

            Response response = await client.FourAsync(null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Five_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Gamma client = CreateClientAndOperationGroupClient(endpoint).GetGammaClient();

            Response response = await client.FiveAsync(null);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Five_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Gamma client = CreateClientAndOperationGroupClient(endpoint).GetGammaClient();

            Response response = await client.FiveAsync(null);
        }
    }
}
