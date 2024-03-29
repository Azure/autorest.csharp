// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure;
using Azure.Core.TestFramework;
using custom_baseUrl_paging_LowLevel;

namespace custom_baseUrl_paging_LowLevel.Tests
{
    public partial class custom_baseUrl_paging_LowLevelTestBase : RecordedTestBase<custom_baseUrl_paging_LowLevelTestEnvironment>
    {
        public custom_baseUrl_paging_LowLevelTestBase(bool isAsync) : base(isAsync)
        {
        }

        protected PagingClient CreatePagingClient(string host, AzureKeyCredential credential)
        {
            PagingClientOptions options = InstrumentClientOptions(new PagingClientOptions());
            PagingClient client = new PagingClient(host, credential, options);
            return InstrumentClient(client);
        }
    }
}
