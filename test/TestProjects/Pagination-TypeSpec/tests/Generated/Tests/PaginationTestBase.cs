// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;
using Azure.Core.TestFramework;
using Pagination;

namespace Pagination.Tests
{
    public partial class PaginationTestBase : RecordedTestBase<PaginationTestEnvironment>
    {
        public PaginationTestBase(bool isAsync) : base(isAsync)
        {
        }

        protected PaginationClient CreatePaginationClient(Uri endpoint, TokenCredential credential)
        {
            PaginationClientOptions options = InstrumentClientOptions(new PaginationClientOptions());
            PaginationClient client = new PaginationClient(endpoint, credential, options);
            return InstrumentClient(client);
        }
    }
}
