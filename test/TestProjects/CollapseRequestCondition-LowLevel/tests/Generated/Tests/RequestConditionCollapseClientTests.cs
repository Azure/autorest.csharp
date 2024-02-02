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
    public partial class RequestConditionCollapseClientTests : CollapseRequestCondition_LowLevelTestBase
    {
        public RequestConditionCollapseClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task CollapsePut_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            RequestConditionCollapseClient client = CreateRequestConditionCollapseClient(endpoint, credential);

            using RequestContent content = null;
            Response response = await client.CollapsePutAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task CollapsePut_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            RequestConditionCollapseClient client = CreateRequestConditionCollapseClient(endpoint, credential);

            using RequestContent content = RequestContent.Create("<body>");
            Response response = await client.CollapsePutAsync(content, requestConditions: null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task CollapseGet_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            RequestConditionCollapseClient client = CreateRequestConditionCollapseClient(endpoint, credential);

            Response response = await client.CollapseGetAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task CollapseGet_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            RequestConditionCollapseClient client = CreateRequestConditionCollapseClient(endpoint, credential);

            Response response = await client.CollapseGetAsync(requestConditions: null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task MissIfNoneMatchGet_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            RequestConditionCollapseClient client = CreateRequestConditionCollapseClient(endpoint, credential);

            Response response = await client.MissIfNoneMatchGetAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task MissIfNoneMatchGet_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            RequestConditionCollapseClient client = CreateRequestConditionCollapseClient(endpoint, credential);

            Response response = await client.MissIfNoneMatchGetAsync(requestConditions: null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task MissIfMatchGet_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            RequestConditionCollapseClient client = CreateRequestConditionCollapseClient(endpoint, credential);

            Response response = await client.MissIfMatchGetAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task MissIfMatchGet_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            RequestConditionCollapseClient client = CreateRequestConditionCollapseClient(endpoint, credential);

            Response response = await client.MissIfMatchGetAsync(requestConditions: null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task MissIfModifiedSinceGet_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            RequestConditionCollapseClient client = CreateRequestConditionCollapseClient(endpoint, credential);

            Response response = await client.MissIfModifiedSinceGetAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task MissIfModifiedSinceGet_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            RequestConditionCollapseClient client = CreateRequestConditionCollapseClient(endpoint, credential);

            Response response = await client.MissIfModifiedSinceGetAsync(requestConditions: null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task MissIfUnmodifiedSinceGet_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            RequestConditionCollapseClient client = CreateRequestConditionCollapseClient(endpoint, credential);

            Response response = await client.MissIfUnmodifiedSinceGetAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task MissIfUnmodifiedSinceGet_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            RequestConditionCollapseClient client = CreateRequestConditionCollapseClient(endpoint, credential);

            Response response = await client.MissIfUnmodifiedSinceGetAsync(requestConditions: null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task MissIfMatchIfNoneMatchGet_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            RequestConditionCollapseClient client = CreateRequestConditionCollapseClient(endpoint, credential);

            Response response = await client.MissIfMatchIfNoneMatchGetAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task MissIfMatchIfNoneMatchGet_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            RequestConditionCollapseClient client = CreateRequestConditionCollapseClient(endpoint, credential);

            Response response = await client.MissIfMatchIfNoneMatchGetAsync(requestConditions: null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task IfModifiedSinceGet_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            RequestConditionCollapseClient client = CreateRequestConditionCollapseClient(endpoint, credential);

            Response response = await client.IfModifiedSinceGetAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task IfModifiedSinceGet_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            RequestConditionCollapseClient client = CreateRequestConditionCollapseClient(endpoint, credential);

            Response response = await client.IfModifiedSinceGetAsync(requestConditions: null);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task IfUnmodifiedSinceGet_ShortVersion()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            RequestConditionCollapseClient client = CreateRequestConditionCollapseClient(endpoint, credential);

            Response response = await client.IfUnmodifiedSinceGetAsync();
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task IfUnmodifiedSinceGet_AllParameters()
        {
            Uri endpoint = null;
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            RequestConditionCollapseClient client = CreateRequestConditionCollapseClient(endpoint, credential);

            Response response = await client.IfUnmodifiedSinceGetAsync(requestConditions: null);
        }
    }
}
