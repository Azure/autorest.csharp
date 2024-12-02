// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using NUnit.Framework;
using _Specs_.Azure.ClientGenerator.Core.Access.Models;

namespace _Specs_.Azure.ClientGenerator.Core.Access.Tests
{
    public partial class SharedModelInOperationTests : _Specs_AzureClientGeneratorCoreAccessTestBase
    {
        public SharedModelInOperationTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task SharedModelInOperation_Public_ShortVersion()
        {
            Uri endpoint = null;
            SharedModelInOperation client = CreateAccessClient(endpoint).GetSharedModelInOperationClient();

            Response response = await client.PublicAsync("<name>", null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task SharedModelInOperation_Public_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            SharedModelInOperation client = CreateAccessClient(endpoint).GetSharedModelInOperationClient();

            Response<SharedModel> response = await client.PublicAsync("<name>");
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task SharedModelInOperation_Public_AllParameters()
        {
            Uri endpoint = null;
            SharedModelInOperation client = CreateAccessClient(endpoint).GetSharedModelInOperationClient();

            Response response = await client.PublicAsync("<name>", null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task SharedModelInOperation_Public_AllParameters_Convenience()
        {
            Uri endpoint = null;
            SharedModelInOperation client = CreateAccessClient(endpoint).GetSharedModelInOperationClient();

            Response<SharedModel> response = await client.PublicAsync("<name>");
        }
    }
}
