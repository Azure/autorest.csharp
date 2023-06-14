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

namespace url_multi_collectionFormat_LowLevel.Samples
{
    public class Samples_QueriesClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ArrayStringMultiNull()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.ArrayStringMultiNull();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ArrayStringMultiNull_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.ArrayStringMultiNull(new string[] { "<arrayQuery>" });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ArrayStringMultiNull_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.ArrayStringMultiNullAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ArrayStringMultiNull_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.ArrayStringMultiNullAsync(new string[] { "<arrayQuery>" });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ArrayStringMultiEmpty()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.ArrayStringMultiEmpty();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ArrayStringMultiEmpty_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.ArrayStringMultiEmpty(new string[] { "<arrayQuery>" });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ArrayStringMultiEmpty_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.ArrayStringMultiEmptyAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ArrayStringMultiEmpty_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.ArrayStringMultiEmptyAsync(new string[] { "<arrayQuery>" });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ArrayStringMultiValid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.ArrayStringMultiValid();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ArrayStringMultiValid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = client.ArrayStringMultiValid(new string[] { "<arrayQuery>" });
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ArrayStringMultiValid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.ArrayStringMultiValidAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ArrayStringMultiValid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new QueriesClient(credential);

            Response response = await client.ArrayStringMultiValidAsync(new string[] { "<arrayQuery>" });
            Console.WriteLine(response.Status);
        }
    }
}
