// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core.TestFramework;
using Azure.Identity;
using _Type.Union;

namespace _Type.Union.Tests
{
    public partial class _TypeUnionTestBase : RecordedTestBase<_TypeUnionTestEnvironment>
    {
        public _TypeUnionTestBase(bool isAsync) : base(isAsync)
        {
        }

        protected UnionClient CreateUnionClient(Uri endpoint)
        {
            var options = InstrumentClientOptions(new UnionClientOptions());
            var client = new UnionClient(endpoint, options: options);
            return InstrumentClient(client);
        }
    }
}
