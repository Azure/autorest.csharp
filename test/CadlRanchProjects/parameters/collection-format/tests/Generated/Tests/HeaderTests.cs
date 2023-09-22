// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using NUnit.Framework;
using Parameters.CollectionFormat;

namespace Parameters.CollectionFormat.Tests
{
    public class HeaderTests : ParametersCollectionFormatTestBase
    {
        public HeaderTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Csv_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Header client = CreateCollectionFormatClient(endpoint).GetHeaderClient(apiVersion: "1.0.0");

            Response response = await client.CsvAsync(new List<string>()
{
"<colors>"
});
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Csv_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            Header client = CreateCollectionFormatClient(endpoint).GetHeaderClient(apiVersion: "1.0.0");

            Response response = await client.CsvAsync(new List<string>()
{
"<colors>"
});
        }
    }
}
