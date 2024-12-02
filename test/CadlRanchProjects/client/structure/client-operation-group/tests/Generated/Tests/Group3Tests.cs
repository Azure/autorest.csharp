// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using Client.Structure.Service.ClientOperationGroup.Models;
using NUnit.Framework;

namespace Client.Structure.Service.ClientOperationGroup.Tests
{
    public partial class Group3Tests : ClientStructureServiceClientOperationGroupTestBase
    {
        public Group3Tests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Group3_Two_ShortVersion()
        {
            Uri endpoint = new Uri("<endpoint>");
            Group3 client = CreateFirstClient(endpoint, default).GetGroup3Client();

            Response response = await client.TwoAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Group3_Two_AllParameters()
        {
            Uri endpoint = new Uri("<endpoint>");
            Group3 client = CreateFirstClient(endpoint, default).GetGroup3Client();

            Response response = await client.TwoAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Group3_Three_ShortVersion()
        {
            Uri endpoint = new Uri("<endpoint>");
            Group3 client = CreateFirstClient(endpoint, default).GetGroup3Client();

            Response response = await client.ThreeAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Group3_Three_AllParameters()
        {
            Uri endpoint = new Uri("<endpoint>");
            Group3 client = CreateFirstClient(endpoint, default).GetGroup3Client();

            Response response = await client.ThreeAsync();
        }
    }
}
