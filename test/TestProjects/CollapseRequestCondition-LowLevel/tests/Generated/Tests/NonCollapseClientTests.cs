// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using CollapseRequestCondition_LowLevel;
using NUnit.Framework;

namespace CollapseRequestCondition_LowLevel.Tests
{
    public class NonCollapseClientTests : CollapseRequestCondition_LowLevelTestBase
    {
        public NonCollapseClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task IfMatchPut_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            NonCollapseClient client = CreateNonCollapseClient(endpoint, credential);

            RequestContent content = null;
            Response response = await client.IfMatchPutAsync(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task IfMatchPut_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            NonCollapseClient client = CreateNonCollapseClient(endpoint, credential);

            RequestContent content = RequestContent.Create("<body>");
            Response response = await client.IfMatchPutAsync(content, ifMatch: new ETag("<ifMatch>"));
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task IfNoneMatchPut_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            NonCollapseClient client = CreateNonCollapseClient(endpoint, credential);

            RequestContent content = null;
            Response response = await client.IfNoneMatchPutAsync(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task IfNoneMatchPut_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            NonCollapseClient client = CreateNonCollapseClient(endpoint, credential);

            RequestContent content = RequestContent.Create("<body>");
            Response response = await client.IfNoneMatchPutAsync(content, ifNoneMatch: new ETag("<ifNoneMatch>"));
        }
    }
}
