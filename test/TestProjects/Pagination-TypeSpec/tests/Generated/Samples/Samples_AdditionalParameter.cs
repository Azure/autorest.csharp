// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;
using Pagination;
using Pagination.Models;

namespace Pagination.Samples
{
    public partial class Samples_AdditionalParameter
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DimensionValueListItem_GetMetricDimensionValues_ShortVersion()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            AdditionalParameter client = new PaginationClient(endpoint, credential).GetAdditionalParameterClient();

            foreach (BinaryData item in client.GetMetricDimensionValues("<testRunId>", "<name>", "<metricNamespace>", null, null, null, null))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("value")[0].ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DimensionValueListItem_GetMetricDimensionValues_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            AdditionalParameter client = new PaginationClient(endpoint, credential).GetAdditionalParameterClient();

            await foreach (BinaryData item in client.GetMetricDimensionValuesAsync("<testRunId>", "<name>", "<metricNamespace>", null, null, null, null))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("value")[0].ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DimensionValueListItem_GetMetricDimensionValues_ShortVersion_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            AdditionalParameter client = new PaginationClient(endpoint, credential).GetAdditionalParameterClient();

            foreach (DimensionValueListItem item in client.GetMetricDimensionValues("<testRunId>", "<name>", "<metricNamespace>"))
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DimensionValueListItem_GetMetricDimensionValues_ShortVersion_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            AdditionalParameter client = new PaginationClient(endpoint, credential).GetAdditionalParameterClient();

            await foreach (DimensionValueListItem item in client.GetMetricDimensionValuesAsync("<testRunId>", "<name>", "<metricNamespace>"))
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DimensionValueListItem_GetMetricDimensionValues_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            AdditionalParameter client = new PaginationClient(endpoint, credential).GetAdditionalParameterClient();

            foreach (BinaryData item in client.GetMetricDimensionValues("<testRunId>", "<name>", "<metricNamespace>", "PT5S", "<metricName>", "<timespan>", null))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("value")[0].ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DimensionValueListItem_GetMetricDimensionValues_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            AdditionalParameter client = new PaginationClient(endpoint, credential).GetAdditionalParameterClient();

            await foreach (BinaryData item in client.GetMetricDimensionValuesAsync("<testRunId>", "<name>", "<metricNamespace>", "PT5S", "<metricName>", "<timespan>", null))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("value")[0].ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DimensionValueListItem_GetMetricDimensionValues_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            AdditionalParameter client = new PaginationClient(endpoint, credential).GetAdditionalParameterClient();

            foreach (DimensionValueListItem item in client.GetMetricDimensionValues("<testRunId>", "<name>", "<metricNamespace>", interval: Interval.PT5S, metricName: "<metricName>", timespan: "<timespan>"))
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DimensionValueListItem_GetMetricDimensionValues_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            AdditionalParameter client = new PaginationClient(endpoint, credential).GetAdditionalParameterClient();

            await foreach (DimensionValueListItem item in client.GetMetricDimensionValuesAsync("<testRunId>", "<name>", "<metricNamespace>", interval: Interval.PT5S, metricName: "<metricName>", timespan: "<timespan>"))
            {
            }
        }
    }
}
