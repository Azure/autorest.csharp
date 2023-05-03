// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
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

            foreach (var data in client.GetNoItemNamePages())
            {
                JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNullNextLinkNamePages()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var data in client.GetNullNextLinkNamePages())
            {
                JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetSinglePages()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var data in client.GetSinglePages())
            {
                JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_FirstResponseEmpty()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var data in client.FirstResponseEmpty())
            {
                JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetMultiplePages()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var data in client.GetMultiplePages())
            {
                JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetWithQueryParams()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var data in client.GetWithQueryParams(1234))
            {
                JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DuplicateParams()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var data in client.DuplicateParams())
            {
                JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_NextOperationWithQueryParams()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var data in client.NextOperationWithQueryParams())
            {
                JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetOdataMultiplePages()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var data in client.GetOdataMultiplePages())
            {
                JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetMultiplePagesWithOffset()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var data in client.GetMultiplePagesWithOffset(1234))
            {
                JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetMultiplePagesRetryFirst()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var data in client.GetMultiplePagesRetryFirst())
            {
                JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetMultiplePagesRetrySecond()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var data in client.GetMultiplePagesRetrySecond())
            {
                JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetSinglePagesFailure()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var data in client.GetSinglePagesFailure())
            {
                JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetMultiplePagesFailure()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var data in client.GetMultiplePagesFailure())
            {
                JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetMultiplePagesFailureUri()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var data in client.GetMultiplePagesFailureUri())
            {
                JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetMultiplePagesFragmentNextLink()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var data in client.GetMultiplePagesFragmentNextLink("<tenant>", "<apiVersion>"))
            {
                JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetMultiplePagesFragmentWithGroupingNextLink()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var data in client.GetMultiplePagesFragmentWithGroupingNextLink("<tenant>", "<apiVersion>"))
            {
                JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_NextFragment()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var data in client.NextFragment("<tenant>", "<nextLink>", "<apiVersion>"))
            {
                JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_NextFragmentWithGrouping()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var data in client.NextFragmentWithGrouping("<tenant>", "<nextLink>", "<apiVersion>"))
            {
                JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetPagingModelWithItemNameWithXMSClientName()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            foreach (var data in client.GetPagingModelWithItemNameWithXMSClientName())
            {
                JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetMultiplePagesLRO()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new PagingClient(credential);

            var operation = client.GetMultiplePagesLRO(WaitUntil.Completed);

            foreach (var data in operation.Value)
            {
                JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }
    }
}
