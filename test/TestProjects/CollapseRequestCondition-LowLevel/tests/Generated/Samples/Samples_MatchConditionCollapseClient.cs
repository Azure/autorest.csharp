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

namespace CollapseRequestCondition_LowLevel.Samples
{
    public partial class Samples_MatchConditionCollapseClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CollapseGetWithHead_ShortVersion()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            MatchConditionCollapseClient client = new MatchConditionCollapseClient(credential);

            Response response = client.CollapseGetWithHead();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CollapseGetWithHead_ShortVersion_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            MatchConditionCollapseClient client = new MatchConditionCollapseClient(credential);

            Response response = await client.CollapseGetWithHeadAsync();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CollapseGetWithHead_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            MatchConditionCollapseClient client = new MatchConditionCollapseClient(credential);

            Response response = client.CollapseGetWithHead(otherHeader: "<otherHeader>", matchConditions: null);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CollapseGetWithHead_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            MatchConditionCollapseClient client = new MatchConditionCollapseClient(credential);

            Response response = await client.CollapseGetWithHeadAsync(otherHeader: "<otherHeader>", matchConditions: null);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CollapsePut_ShortVersion()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            MatchConditionCollapseClient client = new MatchConditionCollapseClient(credential);

            RequestContent content = null;
            Response response = client.CollapsePut(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CollapsePut_ShortVersion_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            MatchConditionCollapseClient client = new MatchConditionCollapseClient(credential);

            RequestContent content = null;
            Response response = await client.CollapsePutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CollapsePut_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            MatchConditionCollapseClient client = new MatchConditionCollapseClient(credential);

            RequestContent content = RequestContent.Create("<body>");
            Response response = client.CollapsePut(content, matchConditions: null);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CollapsePut_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            MatchConditionCollapseClient client = new MatchConditionCollapseClient(credential);

            RequestContent content = RequestContent.Create("<body>");
            Response response = await client.CollapsePutAsync(content, matchConditions: null);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CollapseGet_ShortVersion()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            MatchConditionCollapseClient client = new MatchConditionCollapseClient(credential);

            Response response = client.CollapseGet();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CollapseGet_ShortVersion_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            MatchConditionCollapseClient client = new MatchConditionCollapseClient(credential);

            Response response = await client.CollapseGetAsync();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CollapseGet_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            MatchConditionCollapseClient client = new MatchConditionCollapseClient(credential);

            Response response = client.CollapseGet(matchConditions: null);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CollapseGet_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            MatchConditionCollapseClient client = new MatchConditionCollapseClient(credential);

            Response response = await client.CollapseGetAsync(matchConditions: null);

            Console.WriteLine(response.Status);
        }
    }
}
