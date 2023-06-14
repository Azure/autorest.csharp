// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;

namespace CollapseRequestCondition_LowLevel.Samples
{
    public class Samples_MatchConditionCollapseClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CollapseGetWithHead()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MatchConditionCollapseClient(credential);

            Response response = client.CollapseGetWithHead();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CollapseGetWithHead_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MatchConditionCollapseClient(credential);

            Response response = client.CollapseGetWithHead("<otherHeader>", new MatchConditions { IfMatch = new ETag("<YOUR_ETAG>") });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CollapseGetWithHead_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MatchConditionCollapseClient(credential);

            Response response = await client.CollapseGetWithHeadAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CollapseGetWithHead_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MatchConditionCollapseClient(credential);

            Response response = await client.CollapseGetWithHeadAsync("<otherHeader>", new MatchConditions { IfMatch = new ETag("<YOUR_ETAG>") });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CollapsePut()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MatchConditionCollapseClient(credential);

            var data = "<String>";

            Response response = client.CollapsePut(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CollapsePut_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MatchConditionCollapseClient(credential);

            var data = "<String>";

            Response response = client.CollapsePut(RequestContent.Create(data), new MatchConditions { IfMatch = new ETag("<YOUR_ETAG>") });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CollapsePut_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MatchConditionCollapseClient(credential);

            var data = "<String>";

            Response response = await client.CollapsePutAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CollapsePut_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MatchConditionCollapseClient(credential);

            var data = "<String>";

            Response response = await client.CollapsePutAsync(RequestContent.Create(data), new MatchConditions { IfMatch = new ETag("<YOUR_ETAG>") });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CollapseGet()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MatchConditionCollapseClient(credential);

            Response response = client.CollapseGet();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CollapseGet_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MatchConditionCollapseClient(credential);

            Response response = client.CollapseGet(new MatchConditions { IfMatch = new ETag("<YOUR_ETAG>") });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CollapseGet_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MatchConditionCollapseClient(credential);

            Response response = await client.CollapseGetAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CollapseGet_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new MatchConditionCollapseClient(credential);

            Response response = await client.CollapseGetAsync(new MatchConditions { IfMatch = new ETag("<YOUR_ETAG>") });
            Console.WriteLine(response.Status);
        }
    }
}
