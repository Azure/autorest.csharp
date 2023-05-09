// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

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
    public class Samples_RequestConditionCollapseClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CollapsePut()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new RequestConditionCollapseClient(credential);

            var data = "<String>";

            Response response = client.CollapsePut(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CollapsePut_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new RequestConditionCollapseClient(credential);

            var data = "<String>";

            Response response = client.CollapsePut(RequestContent.Create(data), null, new RequestContext());
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CollapsePut_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new RequestConditionCollapseClient(credential);

            var data = "<String>";

            Response response = await client.CollapsePutAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CollapsePut_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new RequestConditionCollapseClient(credential);

            var data = "<String>";

            Response response = await client.CollapsePutAsync(RequestContent.Create(data), null, new RequestContext());
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CollapseGet()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new RequestConditionCollapseClient(credential);

            Response response = client.CollapseGet();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CollapseGet_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new RequestConditionCollapseClient(credential);

            Response response = client.CollapseGet(null, new RequestContext());
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CollapseGet_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new RequestConditionCollapseClient(credential);

            Response response = await client.CollapseGetAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CollapseGet_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new RequestConditionCollapseClient(credential);

            Response response = await client.CollapseGetAsync(null, new RequestContext());
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_MissIfNoneMatchGet()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new RequestConditionCollapseClient(credential);

            Response response = client.MissIfNoneMatchGet();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_MissIfNoneMatchGet_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new RequestConditionCollapseClient(credential);

            Response response = client.MissIfNoneMatchGet(null, new RequestContext());
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_MissIfNoneMatchGet_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new RequestConditionCollapseClient(credential);

            Response response = await client.MissIfNoneMatchGetAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_MissIfNoneMatchGet_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new RequestConditionCollapseClient(credential);

            Response response = await client.MissIfNoneMatchGetAsync(null, new RequestContext());
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_MissIfMatchGet()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new RequestConditionCollapseClient(credential);

            Response response = client.MissIfMatchGet();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_MissIfMatchGet_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new RequestConditionCollapseClient(credential);

            Response response = client.MissIfMatchGet(null, new RequestContext());
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_MissIfMatchGet_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new RequestConditionCollapseClient(credential);

            Response response = await client.MissIfMatchGetAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_MissIfMatchGet_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new RequestConditionCollapseClient(credential);

            Response response = await client.MissIfMatchGetAsync(null, new RequestContext());
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_MissIfModifiedSinceGet()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new RequestConditionCollapseClient(credential);

            Response response = client.MissIfModifiedSinceGet();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_MissIfModifiedSinceGet_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new RequestConditionCollapseClient(credential);

            Response response = client.MissIfModifiedSinceGet(null, new RequestContext());
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_MissIfModifiedSinceGet_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new RequestConditionCollapseClient(credential);

            Response response = await client.MissIfModifiedSinceGetAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_MissIfModifiedSinceGet_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new RequestConditionCollapseClient(credential);

            Response response = await client.MissIfModifiedSinceGetAsync(null, new RequestContext());
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_MissIfUnmodifiedSinceGet()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new RequestConditionCollapseClient(credential);

            Response response = client.MissIfUnmodifiedSinceGet();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_MissIfUnmodifiedSinceGet_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new RequestConditionCollapseClient(credential);

            Response response = client.MissIfUnmodifiedSinceGet(null, new RequestContext());
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_MissIfUnmodifiedSinceGet_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new RequestConditionCollapseClient(credential);

            Response response = await client.MissIfUnmodifiedSinceGetAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_MissIfUnmodifiedSinceGet_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new RequestConditionCollapseClient(credential);

            Response response = await client.MissIfUnmodifiedSinceGetAsync(null, new RequestContext());
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_MissIfMatchIfNoneMatchGet()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new RequestConditionCollapseClient(credential);

            Response response = client.MissIfMatchIfNoneMatchGet();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_MissIfMatchIfNoneMatchGet_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new RequestConditionCollapseClient(credential);

            Response response = client.MissIfMatchIfNoneMatchGet(null, new RequestContext());
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_MissIfMatchIfNoneMatchGet_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new RequestConditionCollapseClient(credential);

            Response response = await client.MissIfMatchIfNoneMatchGetAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_MissIfMatchIfNoneMatchGet_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new RequestConditionCollapseClient(credential);

            Response response = await client.MissIfMatchIfNoneMatchGetAsync(null, new RequestContext());
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_IfModifiedSinceGet()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new RequestConditionCollapseClient(credential);

            Response response = client.IfModifiedSinceGet();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_IfModifiedSinceGet_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new RequestConditionCollapseClient(credential);

            Response response = client.IfModifiedSinceGet(null, new RequestContext());
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_IfModifiedSinceGet_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new RequestConditionCollapseClient(credential);

            Response response = await client.IfModifiedSinceGetAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_IfModifiedSinceGet_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new RequestConditionCollapseClient(credential);

            Response response = await client.IfModifiedSinceGetAsync(null, new RequestContext());
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_IfUnmodifiedSinceGet()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new RequestConditionCollapseClient(credential);

            Response response = client.IfUnmodifiedSinceGet();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_IfUnmodifiedSinceGet_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new RequestConditionCollapseClient(credential);

            Response response = client.IfUnmodifiedSinceGet(null, new RequestContext());
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_IfUnmodifiedSinceGet_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new RequestConditionCollapseClient(credential);

            Response response = await client.IfUnmodifiedSinceGetAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_IfUnmodifiedSinceGet_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new RequestConditionCollapseClient(credential);

            Response response = await client.IfUnmodifiedSinceGetAsync(null, new RequestContext());
            Console.WriteLine(response.Status);
        }
    }
}
