// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;
using Pagination;
using Pagination.Models;

namespace Pagination.Samples
{
    public class Samples_PaginationClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetPaginationLedgerEntries()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            PaginationClient client = new PaginationClient(endpoint, credential);

            RequestContent content = RequestContent.Create(new
            {
                requiredString = "<requiredString>",
                requiredInt = 1234,
            });
            foreach (BinaryData item in client.GetPaginationLedgerEntries(content))
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetPaginationLedgerEntries_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            PaginationClient client = new PaginationClient(endpoint, credential);

            RequestContent content = RequestContent.Create(new
            {
                requiredString = "<requiredString>",
                requiredInt = 1234,
            });
            await foreach (BinaryData item in client.GetPaginationLedgerEntriesAsync(content))
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetPaginationLedgerEntries_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            PaginationClient client = new PaginationClient(endpoint, credential);

            ListLedgerEntryInputBody bodyInput = new ListLedgerEntryInputBody("<requiredString>", 1234);
            foreach (LedgerEntry item in client.GetPaginationLedgerEntries(bodyInput))
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetPaginationLedgerEntries_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            PaginationClient client = new PaginationClient(endpoint, credential);

            ListLedgerEntryInputBody bodyInput = new ListLedgerEntryInputBody("<requiredString>", 1234);
            await foreach (LedgerEntry item in client.GetPaginationLedgerEntriesAsync(bodyInput))
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetPaginationLedgerEntries_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            PaginationClient client = new PaginationClient(endpoint, credential);

            RequestContent content = RequestContent.Create(new
            {
                requiredString = "<requiredString>",
                requiredInt = 1234,
            });
            foreach (BinaryData item in client.GetPaginationLedgerEntries(content))
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetPaginationLedgerEntries_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            PaginationClient client = new PaginationClient(endpoint, credential);

            RequestContent content = RequestContent.Create(new
            {
                requiredString = "<requiredString>",
                requiredInt = 1234,
            });
            await foreach (BinaryData item in client.GetPaginationLedgerEntriesAsync(content))
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetPaginationLedgerEntries_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            PaginationClient client = new PaginationClient(endpoint, credential);

            ListLedgerEntryInputBody bodyInput = new ListLedgerEntryInputBody("<requiredString>", 1234);
            foreach (LedgerEntry item in client.GetPaginationLedgerEntries(bodyInput))
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetPaginationLedgerEntries_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            PaginationClient client = new PaginationClient(endpoint, credential);

            ListLedgerEntryInputBody bodyInput = new ListLedgerEntryInputBody("<requiredString>", 1234);
            await foreach (LedgerEntry item in client.GetPaginationLedgerEntriesAsync(bodyInput))
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetMetricDimensionValues()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            PaginationClient client = new PaginationClient(endpoint, credential);

            foreach (BinaryData item in client.GetMetricDimensionValues("<testRunId>", "<name>", "<metricNamespace>", null, null, null, null))
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetMetricDimensionValues_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            PaginationClient client = new PaginationClient(endpoint, credential);

            await foreach (BinaryData item in client.GetMetricDimensionValuesAsync("<testRunId>", "<name>", "<metricNamespace>", null, null, null, null))
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetMetricDimensionValues_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            PaginationClient client = new PaginationClient(endpoint, credential);

            foreach (DimensionValueListItem item in client.GetMetricDimensionValues("<testRunId>", "<name>", "<metricNamespace>"))
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetMetricDimensionValues_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            PaginationClient client = new PaginationClient(endpoint, credential);

            await foreach (DimensionValueListItem item in client.GetMetricDimensionValuesAsync("<testRunId>", "<name>", "<metricNamespace>"))
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetMetricDimensionValues_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            PaginationClient client = new PaginationClient(endpoint, credential);

            foreach (BinaryData item in client.GetMetricDimensionValues("<testRunId>", "<name>", "<metricNamespace>", "PT5S", "<metricName>", "<timespan>", null))
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetMetricDimensionValues_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            PaginationClient client = new PaginationClient(endpoint, credential);

            await foreach (BinaryData item in client.GetMetricDimensionValuesAsync("<testRunId>", "<name>", "<metricNamespace>", "PT5S", "<metricName>", "<timespan>", null))
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetMetricDimensionValues_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            PaginationClient client = new PaginationClient(endpoint, credential);

            foreach (DimensionValueListItem item in client.GetMetricDimensionValues("<testRunId>", "<name>", "<metricNamespace>", Interval.PT5S, "<metricName>", "<timespan>"))
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetMetricDimensionValues_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            PaginationClient client = new PaginationClient(endpoint, credential);

            await foreach (DimensionValueListItem item in client.GetMetricDimensionValuesAsync("<testRunId>", "<name>", "<metricNamespace>", Interval.PT5S, "<metricName>", "<timespan>"))
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetLedgerEntries()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            PaginationClient client = new PaginationClient(endpoint, credential);

            foreach (BinaryData item in client.GetLedgerEntries(null))
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetLedgerEntries_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            PaginationClient client = new PaginationClient(endpoint, credential);

            await foreach (BinaryData item in client.GetLedgerEntriesAsync(null))
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetLedgerEntries_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            PaginationClient client = new PaginationClient(endpoint, credential);

            foreach (LedgerEntry item in client.GetLedgerEntries())
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetLedgerEntries_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            PaginationClient client = new PaginationClient(endpoint, credential);

            await foreach (LedgerEntry item in client.GetLedgerEntriesAsync())
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetLedgerEntries_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            PaginationClient client = new PaginationClient(endpoint, credential);

            foreach (BinaryData item in client.GetLedgerEntries(null))
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetLedgerEntries_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            PaginationClient client = new PaginationClient(endpoint, credential);

            await foreach (BinaryData item in client.GetLedgerEntriesAsync(null))
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetLedgerEntries_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            PaginationClient client = new PaginationClient(endpoint, credential);

            foreach (LedgerEntry item in client.GetLedgerEntries())
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetLedgerEntries_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            PaginationClient client = new PaginationClient(endpoint, credential);

            await foreach (LedgerEntry item in client.GetLedgerEntriesAsync())
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetTextBlocklists()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            PaginationClient client = new PaginationClient(endpoint, credential);

            foreach (BinaryData item in client.GetTextBlocklists(null))
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetTextBlocklists_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            PaginationClient client = new PaginationClient(endpoint, credential);

            await foreach (BinaryData item in client.GetTextBlocklistsAsync(null))
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetTextBlocklists_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            PaginationClient client = new PaginationClient(endpoint, credential);

            foreach (TextBlocklist item in client.GetTextBlocklists())
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetTextBlocklists_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            PaginationClient client = new PaginationClient(endpoint, credential);

            await foreach (TextBlocklist item in client.GetTextBlocklistsAsync())
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetTextBlocklists_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            PaginationClient client = new PaginationClient(endpoint, credential);

            foreach (BinaryData item in client.GetTextBlocklists(null))
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetTextBlocklists_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            PaginationClient client = new PaginationClient(endpoint, credential);

            await foreach (BinaryData item in client.GetTextBlocklistsAsync(null))
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetTextBlocklists_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            PaginationClient client = new PaginationClient(endpoint, credential);

            foreach (TextBlocklist item in client.GetTextBlocklists())
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetTextBlocklists_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            PaginationClient client = new PaginationClient(endpoint, credential);

            await foreach (TextBlocklist item in client.GetTextBlocklistsAsync())
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetTextBlocklistItems()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            PaginationClient client = new PaginationClient(endpoint, credential);

            foreach (BinaryData item in client.GetTextBlocklistItems("<blocklistName>", null, null, null, null))
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetTextBlocklistItems_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            PaginationClient client = new PaginationClient(endpoint, credential);

            await foreach (BinaryData item in client.GetTextBlocklistItemsAsync("<blocklistName>", null, null, null, null))
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetTextBlocklistItems_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            PaginationClient client = new PaginationClient(endpoint, credential);

            foreach (TextBlockItem item in client.GetTextBlocklistItems("<blocklistName>"))
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetTextBlocklistItems_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            PaginationClient client = new PaginationClient(endpoint, credential);

            await foreach (TextBlockItem item in client.GetTextBlocklistItemsAsync("<blocklistName>"))
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetTextBlocklistItems_AllParameters()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            PaginationClient client = new PaginationClient(endpoint, credential);

            foreach (BinaryData item in client.GetTextBlocklistItems("<blocklistName>", 1234, 1234, 1234, null))
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetTextBlocklistItems_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            PaginationClient client = new PaginationClient(endpoint, credential);

            await foreach (BinaryData item in client.GetTextBlocklistItemsAsync("<blocklistName>", 1234, 1234, 1234, null))
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetTextBlocklistItems_AllParameters_Convenience()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            PaginationClient client = new PaginationClient(endpoint, credential);

            foreach (TextBlockItem item in client.GetTextBlocklistItems("<blocklistName>", 1234, 1234, 1234))
            {
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetTextBlocklistItems_AllParameters_Convenience_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            TokenCredential credential = new DefaultAzureCredential();
            PaginationClient client = new PaginationClient(endpoint, credential);

            await foreach (TextBlockItem item in client.GetTextBlocklistItemsAsync("<blocklistName>", 1234, 1234, 1234))
            {
            }
        }
    }
}
