// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Identity;
using NUnit.Framework;

namespace AuthoringTypeSpec.Tests
{
    public partial class GlobalTests : AuthoringTypeSpecTestBase
    {
        public GlobalTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Global_GetSupportedLanguages_ShortVersion()
        {
            Uri endpoint = new Uri("<endpoint>");
            Global client = CreateAuthoringTypeSpecClient(endpoint).GetGlobalClient(apiVersion: "2022-05-15-preview");

            await foreach (BinaryData item in client.GetSupportedLanguagesAsync())
            {
            }
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Global_GetSupportedLanguages_AllParameters()
        {
            Uri endpoint = new Uri("<endpoint>");
            Global client = CreateAuthoringTypeSpecClient(endpoint).GetGlobalClient(apiVersion: "2022-05-15-preview");

            await foreach (BinaryData item in client.GetSupportedLanguagesAsync(maxCount: 1234, skip: 1234, maxpagesize: 1234))
            {
            }
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Global_GetTrainingConfigVersions_ShortVersion()
        {
            Uri endpoint = new Uri("<endpoint>");
            Global client = CreateAuthoringTypeSpecClient(endpoint).GetGlobalClient(apiVersion: "2022-05-15-preview");

            await foreach (BinaryData item in client.GetTrainingConfigVersionsAsync())
            {
            }
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Global_GetTrainingConfigVersions_AllParameters()
        {
            Uri endpoint = new Uri("<endpoint>");
            Global client = CreateAuthoringTypeSpecClient(endpoint).GetGlobalClient(apiVersion: "2022-05-15-preview");

            await foreach (BinaryData item in client.GetTrainingConfigVersionsAsync(maxCount: 1234, skip: 1234, maxpagesize: 1234))
            {
            }
        }
    }
}
