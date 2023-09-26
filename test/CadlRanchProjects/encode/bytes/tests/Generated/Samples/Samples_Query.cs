// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using Encode.Bytes;
using NUnit.Framework;

namespace Encode.Bytes.Samples
{
    public class Samples_Query
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Default()
        {
            Query client = new BytesClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = client.Default(BinaryData.FromObjectAsJson(new object()));

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Default_Async()
        {
            Query client = new BytesClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = await client.DefaultAsync(BinaryData.FromObjectAsJson(new object()));

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Default_AllParameters()
        {
            Query client = new BytesClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = client.Default(BinaryData.FromObjectAsJson(new object()));

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Default_AllParameters_Async()
        {
            Query client = new BytesClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = await client.DefaultAsync(BinaryData.FromObjectAsJson(new object()));

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Base64()
        {
            Query client = new BytesClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = client.Base64(BinaryData.FromObjectAsJson(new object()));

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Base64_Async()
        {
            Query client = new BytesClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = await client.Base64Async(BinaryData.FromObjectAsJson(new object()));

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Base64_AllParameters()
        {
            Query client = new BytesClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = client.Base64(BinaryData.FromObjectAsJson(new object()));

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Base64_AllParameters_Async()
        {
            Query client = new BytesClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = await client.Base64Async(BinaryData.FromObjectAsJson(new object()));

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Base64url()
        {
            Query client = new BytesClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = client.Base64url(BinaryData.FromObjectAsJson(new object()));

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Base64url_Async()
        {
            Query client = new BytesClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = await client.Base64urlAsync(BinaryData.FromObjectAsJson(new object()));

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Base64url_AllParameters()
        {
            Query client = new BytesClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = client.Base64url(BinaryData.FromObjectAsJson(new object()));

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Base64url_AllParameters_Async()
        {
            Query client = new BytesClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = await client.Base64urlAsync(BinaryData.FromObjectAsJson(new object()));

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Base64urlArray()
        {
            Query client = new BytesClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = client.Base64urlArray(new BinaryData[]
            {
BinaryData.FromObjectAsJson(new object())
            });

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Base64urlArray_Async()
        {
            Query client = new BytesClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = await client.Base64urlArrayAsync(new BinaryData[]
            {
BinaryData.FromObjectAsJson(new object())
            });

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Base64urlArray_AllParameters()
        {
            Query client = new BytesClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = client.Base64urlArray(new BinaryData[]
            {
BinaryData.FromObjectAsJson(new object())
            });

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Base64urlArray_AllParameters_Async()
        {
            Query client = new BytesClient().GetQueryClient(apiVersion: "1.0.0");

            Response response = await client.Base64urlArrayAsync(new BinaryData[]
            {
BinaryData.FromObjectAsJson(new object())
            });

            Console.WriteLine(response.Status);
        }
    }
}
