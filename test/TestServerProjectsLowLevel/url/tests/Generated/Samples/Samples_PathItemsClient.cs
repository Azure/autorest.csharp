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

namespace url_LowLevel.Samples
{
    public class Samples_PathItemsClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetAllWithValues()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathItemsClient("<globalStringPath>", credential);

            Response response = client.GetAllWithValues("<pathItemStringPath>", "<localStringPath>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetAllWithValues_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathItemsClient("<globalStringPath>", credential);

            Response response = client.GetAllWithValues("<pathItemStringPath>", "<localStringPath>", "<pathItemStringQuery>", "<localStringQuery>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetAllWithValues_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathItemsClient("<globalStringPath>", credential);

            Response response = await client.GetAllWithValuesAsync("<pathItemStringPath>", "<localStringPath>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetAllWithValues_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathItemsClient("<globalStringPath>", credential);

            Response response = await client.GetAllWithValuesAsync("<pathItemStringPath>", "<localStringPath>", "<pathItemStringQuery>", "<localStringQuery>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetGlobalQueryNull()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathItemsClient("<globalStringPath>", credential);

            Response response = client.GetGlobalQueryNull("<pathItemStringPath>", "<localStringPath>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetGlobalQueryNull_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathItemsClient("<globalStringPath>", credential);

            Response response = client.GetGlobalQueryNull("<pathItemStringPath>", "<localStringPath>", "<pathItemStringQuery>", "<localStringQuery>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetGlobalQueryNull_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathItemsClient("<globalStringPath>", credential);

            Response response = await client.GetGlobalQueryNullAsync("<pathItemStringPath>", "<localStringPath>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetGlobalQueryNull_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathItemsClient("<globalStringPath>", credential);

            Response response = await client.GetGlobalQueryNullAsync("<pathItemStringPath>", "<localStringPath>", "<pathItemStringQuery>", "<localStringQuery>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetGlobalAndLocalQueryNull()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathItemsClient("<globalStringPath>", credential);

            Response response = client.GetGlobalAndLocalQueryNull("<pathItemStringPath>", "<localStringPath>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetGlobalAndLocalQueryNull_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathItemsClient("<globalStringPath>", credential);

            Response response = client.GetGlobalAndLocalQueryNull("<pathItemStringPath>", "<localStringPath>", "<pathItemStringQuery>", "<localStringQuery>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetGlobalAndLocalQueryNull_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathItemsClient("<globalStringPath>", credential);

            Response response = await client.GetGlobalAndLocalQueryNullAsync("<pathItemStringPath>", "<localStringPath>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetGlobalAndLocalQueryNull_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathItemsClient("<globalStringPath>", credential);

            Response response = await client.GetGlobalAndLocalQueryNullAsync("<pathItemStringPath>", "<localStringPath>", "<pathItemStringQuery>", "<localStringQuery>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetLocalPathItemQueryNull()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathItemsClient("<globalStringPath>", credential);

            Response response = client.GetLocalPathItemQueryNull("<pathItemStringPath>", "<localStringPath>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetLocalPathItemQueryNull_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathItemsClient("<globalStringPath>", credential);

            Response response = client.GetLocalPathItemQueryNull("<pathItemStringPath>", "<localStringPath>", "<pathItemStringQuery>", "<localStringQuery>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetLocalPathItemQueryNull_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathItemsClient("<globalStringPath>", credential);

            Response response = await client.GetLocalPathItemQueryNullAsync("<pathItemStringPath>", "<localStringPath>");
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetLocalPathItemQueryNull_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PathItemsClient("<globalStringPath>", credential);

            Response response = await client.GetLocalPathItemQueryNullAsync("<pathItemStringPath>", "<localStringPath>", "<pathItemStringQuery>", "<localStringQuery>");
            Console.WriteLine(response.Status);
        }
    }
}
