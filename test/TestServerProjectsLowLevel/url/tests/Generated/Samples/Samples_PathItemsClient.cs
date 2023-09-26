// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using NUnit.Framework;
using url_LowLevel;

namespace url_LowLevel.Samples
{
    public class Samples_PathItemsClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetAllWithValues()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PathItemsClient client = new PathItemsClient("<GlobalStringPath>", credential);

            Response response = client.GetAllWithValues("<pathItemStringPath>", "<localStringPath>");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetAllWithValues_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PathItemsClient client = new PathItemsClient("<GlobalStringPath>", credential);

            Response response = await client.GetAllWithValuesAsync("<pathItemStringPath>", "<localStringPath>");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetAllWithValues_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PathItemsClient client = new PathItemsClient("<GlobalStringPath>", credential);

            Response response = client.GetAllWithValues("<pathItemStringPath>", "<localStringPath>", "<pathItemStringQuery>", "<localStringQuery>");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetAllWithValues_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PathItemsClient client = new PathItemsClient("<GlobalStringPath>", credential);

            Response response = await client.GetAllWithValuesAsync("<pathItemStringPath>", "<localStringPath>", "<pathItemStringQuery>", "<localStringQuery>");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetGlobalQueryNull()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PathItemsClient client = new PathItemsClient("<GlobalStringPath>", credential);

            Response response = client.GetGlobalQueryNull("<pathItemStringPath>", "<localStringPath>");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetGlobalQueryNull_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PathItemsClient client = new PathItemsClient("<GlobalStringPath>", credential);

            Response response = await client.GetGlobalQueryNullAsync("<pathItemStringPath>", "<localStringPath>");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetGlobalQueryNull_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PathItemsClient client = new PathItemsClient("<GlobalStringPath>", credential);

            Response response = client.GetGlobalQueryNull("<pathItemStringPath>", "<localStringPath>", "<pathItemStringQuery>", "<localStringQuery>");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetGlobalQueryNull_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PathItemsClient client = new PathItemsClient("<GlobalStringPath>", credential);

            Response response = await client.GetGlobalQueryNullAsync("<pathItemStringPath>", "<localStringPath>", "<pathItemStringQuery>", "<localStringQuery>");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetGlobalAndLocalQueryNull()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PathItemsClient client = new PathItemsClient("<GlobalStringPath>", credential);

            Response response = client.GetGlobalAndLocalQueryNull("<pathItemStringPath>", "<localStringPath>");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetGlobalAndLocalQueryNull_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PathItemsClient client = new PathItemsClient("<GlobalStringPath>", credential);

            Response response = await client.GetGlobalAndLocalQueryNullAsync("<pathItemStringPath>", "<localStringPath>");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetGlobalAndLocalQueryNull_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PathItemsClient client = new PathItemsClient("<GlobalStringPath>", credential);

            Response response = client.GetGlobalAndLocalQueryNull("<pathItemStringPath>", "<localStringPath>", "<pathItemStringQuery>", "<localStringQuery>");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetGlobalAndLocalQueryNull_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PathItemsClient client = new PathItemsClient("<GlobalStringPath>", credential);

            Response response = await client.GetGlobalAndLocalQueryNullAsync("<pathItemStringPath>", "<localStringPath>", "<pathItemStringQuery>", "<localStringQuery>");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetLocalPathItemQueryNull()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PathItemsClient client = new PathItemsClient("<GlobalStringPath>", credential);

            Response response = client.GetLocalPathItemQueryNull("<pathItemStringPath>", "<localStringPath>");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetLocalPathItemQueryNull_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PathItemsClient client = new PathItemsClient("<GlobalStringPath>", credential);

            Response response = await client.GetLocalPathItemQueryNullAsync("<pathItemStringPath>", "<localStringPath>");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetLocalPathItemQueryNull_AllParameters()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PathItemsClient client = new PathItemsClient("<GlobalStringPath>", credential);

            Response response = client.GetLocalPathItemQueryNull("<pathItemStringPath>", "<localStringPath>", "<pathItemStringQuery>", "<localStringQuery>");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetLocalPathItemQueryNull_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            PathItemsClient client = new PathItemsClient("<GlobalStringPath>", credential);

            Response response = await client.GetLocalPathItemQueryNullAsync("<pathItemStringPath>", "<localStringPath>", "<pathItemStringQuery>", "<localStringQuery>");
        }
    }
}
