// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using NUnit.Framework;
using url_multi_collectionFormat_LowLevel;

namespace url_multi_collectionFormat_LowLevel.Tests
{
    public class QueriesClientTests : url_multi_collectionFormat_LowLevelTestBase
    {
        public QueriesClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task ArrayStringMultiNull_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            QueriesClient client = CreateQueriesClient(credential, endpoint);

            Response response = await client.ArrayStringMultiNullAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        public async Task ArrayStringMultiNull_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            QueriesClient client = CreateQueriesClient(credential, endpoint);

            Response response = await client.ArrayStringMultiNullAsync(arrayQuery: new List<string>()
{
"<arrayQuery>"
});
            Console.WriteLine(response.Status);
        }

        [Test]
        public async Task ArrayStringMultiEmpty_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            QueriesClient client = CreateQueriesClient(credential, endpoint);

            Response response = await client.ArrayStringMultiEmptyAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        public async Task ArrayStringMultiEmpty_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            QueriesClient client = CreateQueriesClient(credential, endpoint);

            Response response = await client.ArrayStringMultiEmptyAsync(arrayQuery: new List<string>()
{
"<arrayQuery>"
});
            Console.WriteLine(response.Status);
        }

        [Test]
        public async Task ArrayStringMultiValid_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            QueriesClient client = CreateQueriesClient(credential, endpoint);

            Response response = await client.ArrayStringMultiValidAsync();
            Console.WriteLine(response.Status);
        }

        [Test]
        public async Task ArrayStringMultiValid_AllParameters_Async()
        {
            AzureKeyCredential credential = new AzureKeyCredential("<key>");
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            QueriesClient client = CreateQueriesClient(credential, endpoint);

            Response response = await client.ArrayStringMultiValidAsync(arrayQuery: new List<string>()
{
"<arrayQuery>"
});
            Console.WriteLine(response.Status);
        }
    }
}
