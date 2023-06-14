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

namespace paging_LowLevel.Samples
{
    public class Samples_PagingClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNoItemNamePages()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var item in client.GetNoItemNamePages())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNoItemNamePages_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var item in client.GetNoItemNamePages())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("properties").GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("properties").GetProperty("name").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNoItemNamePages_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            await foreach (var item in client.GetNoItemNamePagesAsync())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNoItemNamePages_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            await foreach (var item in client.GetNoItemNamePagesAsync())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("properties").GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("properties").GetProperty("name").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNullNextLinkNamePages()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var item in client.GetNullNextLinkNamePages())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNullNextLinkNamePages_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var item in client.GetNullNextLinkNamePages())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("properties").GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("properties").GetProperty("name").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNullNextLinkNamePages_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            await foreach (var item in client.GetNullNextLinkNamePagesAsync())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNullNextLinkNamePages_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            await foreach (var item in client.GetNullNextLinkNamePagesAsync())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("properties").GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("properties").GetProperty("name").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetSinglePages()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var item in client.GetSinglePages())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetSinglePages_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var item in client.GetSinglePages())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("properties").GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("properties").GetProperty("name").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetSinglePages_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            await foreach (var item in client.GetSinglePagesAsync())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetSinglePages_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            await foreach (var item in client.GetSinglePagesAsync())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("properties").GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("properties").GetProperty("name").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_FirstResponseEmpty()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var item in client.FirstResponseEmpty())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_FirstResponseEmpty_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var item in client.FirstResponseEmpty())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("properties").GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("properties").GetProperty("name").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_FirstResponseEmpty_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            await foreach (var item in client.FirstResponseEmptyAsync())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_FirstResponseEmpty_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            await foreach (var item in client.FirstResponseEmptyAsync())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("properties").GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("properties").GetProperty("name").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetMultiplePages()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var item in client.GetMultiplePages())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetMultiplePages_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var item in client.GetMultiplePages("<clientRequestId>", 1234, 1234))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("properties").GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("properties").GetProperty("name").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetMultiplePages_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            await foreach (var item in client.GetMultiplePagesAsync())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetMultiplePages_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            await foreach (var item in client.GetMultiplePagesAsync("<clientRequestId>", 1234, 1234))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("properties").GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("properties").GetProperty("name").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetWithQueryParams()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var item in client.GetWithQueryParams(1234))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetWithQueryParams_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var item in client.GetWithQueryParams(1234))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("properties").GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("properties").GetProperty("name").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetWithQueryParams_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            await foreach (var item in client.GetWithQueryParamsAsync(1234))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetWithQueryParams_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            await foreach (var item in client.GetWithQueryParamsAsync(1234))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("properties").GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("properties").GetProperty("name").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DuplicateParams()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var item in client.DuplicateParams())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DuplicateParams_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var item in client.DuplicateParams("<filter>"))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("properties").GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("properties").GetProperty("name").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DuplicateParams_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            await foreach (var item in client.DuplicateParamsAsync())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DuplicateParams_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            await foreach (var item in client.DuplicateParamsAsync("<filter>"))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("properties").GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("properties").GetProperty("name").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_NextOperationWithQueryParams()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var item in client.NextOperationWithQueryParams())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_NextOperationWithQueryParams_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var item in client.NextOperationWithQueryParams())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("properties").GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("properties").GetProperty("name").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_NextOperationWithQueryParams_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            await foreach (var item in client.NextOperationWithQueryParamsAsync())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_NextOperationWithQueryParams_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            await foreach (var item in client.NextOperationWithQueryParamsAsync())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("properties").GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("properties").GetProperty("name").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetOdataMultiplePages()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var item in client.GetOdataMultiplePages())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetOdataMultiplePages_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var item in client.GetOdataMultiplePages("<clientRequestId>", 1234, 1234))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("properties").GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("properties").GetProperty("name").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetOdataMultiplePages_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            await foreach (var item in client.GetOdataMultiplePagesAsync())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetOdataMultiplePages_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            await foreach (var item in client.GetOdataMultiplePagesAsync("<clientRequestId>", 1234, 1234))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("properties").GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("properties").GetProperty("name").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetMultiplePagesWithOffset()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var item in client.GetMultiplePagesWithOffset(1234))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetMultiplePagesWithOffset_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var item in client.GetMultiplePagesWithOffset(1234, "<clientRequestId>", 1234, 1234))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("properties").GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("properties").GetProperty("name").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetMultiplePagesWithOffset_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            await foreach (var item in client.GetMultiplePagesWithOffsetAsync(1234))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetMultiplePagesWithOffset_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            await foreach (var item in client.GetMultiplePagesWithOffsetAsync(1234, "<clientRequestId>", 1234, 1234))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("properties").GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("properties").GetProperty("name").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetMultiplePagesRetryFirst()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var item in client.GetMultiplePagesRetryFirst())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetMultiplePagesRetryFirst_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var item in client.GetMultiplePagesRetryFirst())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("properties").GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("properties").GetProperty("name").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetMultiplePagesRetryFirst_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            await foreach (var item in client.GetMultiplePagesRetryFirstAsync())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetMultiplePagesRetryFirst_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            await foreach (var item in client.GetMultiplePagesRetryFirstAsync())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("properties").GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("properties").GetProperty("name").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetMultiplePagesRetrySecond()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var item in client.GetMultiplePagesRetrySecond())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetMultiplePagesRetrySecond_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var item in client.GetMultiplePagesRetrySecond())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("properties").GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("properties").GetProperty("name").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetMultiplePagesRetrySecond_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            await foreach (var item in client.GetMultiplePagesRetrySecondAsync())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetMultiplePagesRetrySecond_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            await foreach (var item in client.GetMultiplePagesRetrySecondAsync())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("properties").GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("properties").GetProperty("name").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetSinglePagesFailure()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var item in client.GetSinglePagesFailure())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetSinglePagesFailure_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var item in client.GetSinglePagesFailure())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("properties").GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("properties").GetProperty("name").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetSinglePagesFailure_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            await foreach (var item in client.GetSinglePagesFailureAsync())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetSinglePagesFailure_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            await foreach (var item in client.GetSinglePagesFailureAsync())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("properties").GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("properties").GetProperty("name").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetMultiplePagesFailure()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var item in client.GetMultiplePagesFailure())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetMultiplePagesFailure_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var item in client.GetMultiplePagesFailure())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("properties").GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("properties").GetProperty("name").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetMultiplePagesFailure_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            await foreach (var item in client.GetMultiplePagesFailureAsync())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetMultiplePagesFailure_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            await foreach (var item in client.GetMultiplePagesFailureAsync())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("properties").GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("properties").GetProperty("name").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetMultiplePagesFailureUri()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var item in client.GetMultiplePagesFailureUri())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetMultiplePagesFailureUri_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var item in client.GetMultiplePagesFailureUri())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("properties").GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("properties").GetProperty("name").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetMultiplePagesFailureUri_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            await foreach (var item in client.GetMultiplePagesFailureUriAsync())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetMultiplePagesFailureUri_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            await foreach (var item in client.GetMultiplePagesFailureUriAsync())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("properties").GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("properties").GetProperty("name").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetMultiplePagesFragmentNextLink()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var item in client.GetMultiplePagesFragmentNextLink("<tenant>", "<apiVersion>"))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetMultiplePagesFragmentNextLink_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var item in client.GetMultiplePagesFragmentNextLink("<tenant>", "<apiVersion>"))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("properties").GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("properties").GetProperty("name").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetMultiplePagesFragmentNextLink_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            await foreach (var item in client.GetMultiplePagesFragmentNextLinkAsync("<tenant>", "<apiVersion>"))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetMultiplePagesFragmentNextLink_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            await foreach (var item in client.GetMultiplePagesFragmentNextLinkAsync("<tenant>", "<apiVersion>"))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("properties").GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("properties").GetProperty("name").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetMultiplePagesFragmentWithGroupingNextLink()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var item in client.GetMultiplePagesFragmentWithGroupingNextLink("<tenant>", "<apiVersion>"))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetMultiplePagesFragmentWithGroupingNextLink_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var item in client.GetMultiplePagesFragmentWithGroupingNextLink("<tenant>", "<apiVersion>"))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("properties").GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("properties").GetProperty("name").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetMultiplePagesFragmentWithGroupingNextLink_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            await foreach (var item in client.GetMultiplePagesFragmentWithGroupingNextLinkAsync("<tenant>", "<apiVersion>"))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetMultiplePagesFragmentWithGroupingNextLink_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            await foreach (var item in client.GetMultiplePagesFragmentWithGroupingNextLinkAsync("<tenant>", "<apiVersion>"))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("properties").GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("properties").GetProperty("name").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_NextFragment()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var item in client.NextFragment("<tenant>", "<nextLink>", "<apiVersion>"))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_NextFragment_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var item in client.NextFragment("<tenant>", "<nextLink>", "<apiVersion>"))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("properties").GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("properties").GetProperty("name").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_NextFragment_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            await foreach (var item in client.NextFragmentAsync("<tenant>", "<nextLink>", "<apiVersion>"))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_NextFragment_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            await foreach (var item in client.NextFragmentAsync("<tenant>", "<nextLink>", "<apiVersion>"))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("properties").GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("properties").GetProperty("name").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_NextFragmentWithGrouping()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var item in client.NextFragmentWithGrouping("<tenant>", "<nextLink>", "<apiVersion>"))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_NextFragmentWithGrouping_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var item in client.NextFragmentWithGrouping("<tenant>", "<nextLink>", "<apiVersion>"))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("properties").GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("properties").GetProperty("name").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_NextFragmentWithGrouping_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            await foreach (var item in client.NextFragmentWithGroupingAsync("<tenant>", "<nextLink>", "<apiVersion>"))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_NextFragmentWithGrouping_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            await foreach (var item in client.NextFragmentWithGroupingAsync("<tenant>", "<nextLink>", "<apiVersion>"))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("properties").GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("properties").GetProperty("name").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetPagingModelWithItemNameWithXMSClientName()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var item in client.GetPagingModelWithItemNameWithXMSClientName())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetPagingModelWithItemNameWithXMSClientName_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var item in client.GetPagingModelWithItemNameWithXMSClientName())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("properties").GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("properties").GetProperty("name").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetPagingModelWithItemNameWithXMSClientName_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            await foreach (var item in client.GetPagingModelWithItemNameWithXMSClientNameAsync())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetPagingModelWithItemNameWithXMSClientName_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            await foreach (var item in client.GetPagingModelWithItemNameWithXMSClientNameAsync())
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("properties").GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("properties").GetProperty("name").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetMultiplePagesLRO()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            var operation = client.GetMultiplePagesLRO(WaitUntil.Completed);

            foreach (var item in operation.Value)
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetMultiplePagesLRO_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            var operation = client.GetMultiplePagesLRO(WaitUntil.Completed, "<clientRequestId>", 1234, 1234);

            foreach (var item in operation.Value)
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("properties").GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("properties").GetProperty("name").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetMultiplePagesLRO_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            var operation = await client.GetMultiplePagesLROAsync(WaitUntil.Completed);

            await foreach (var item in operation.Value)
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetMultiplePagesLRO_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            var operation = await client.GetMultiplePagesLROAsync(WaitUntil.Completed, "<clientRequestId>", 1234, 1234);

            await foreach (var item in operation.Value)
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("properties").GetProperty("id").ToString());
                Console.WriteLine(result.GetProperty("properties").GetProperty("name").ToString());
            }
        }
    }
}
