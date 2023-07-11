// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using NUnit.Framework;

namespace CollapseRequestCondition_LowLevel.Samples
{
    public class Samples_NonCollapseClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_IfMatchPut()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new NonCollapseClient(credential);

            var data = "<String>";

            Response response = client.IfMatchPut(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_IfMatchPut_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new NonCollapseClient(credential);

            var data = "<String>";

            Response response = client.IfMatchPut(RequestContent.Create(data), null);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_IfMatchPut_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new NonCollapseClient(credential);

            var data = "<String>";

            Response response = await client.IfMatchPutAsync(RequestContent.Create(data)).ConfigureAwait(false);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_IfMatchPut_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new NonCollapseClient(credential);

            var data = "<String>";

            Response response = await client.IfMatchPutAsync(RequestContent.Create(data), null).ConfigureAwait(false);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_IfNoneMatchPut()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new NonCollapseClient(credential);

            var data = "<String>";

            Response response = client.IfNoneMatchPut(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_IfNoneMatchPut_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new NonCollapseClient(credential);

            var data = "<String>";

            Response response = client.IfNoneMatchPut(RequestContent.Create(data), null);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_IfNoneMatchPut_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new NonCollapseClient(credential);

            var data = "<String>";

            Response response = await client.IfNoneMatchPutAsync(RequestContent.Create(data)).ConfigureAwait(false);
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_IfNoneMatchPut_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new NonCollapseClient(credential);

            var data = "<String>";

            Response response = await client.IfNoneMatchPutAsync(RequestContent.Create(data), null).ConfigureAwait(false);
            Console.WriteLine(response.Status);
        }
    }
}
