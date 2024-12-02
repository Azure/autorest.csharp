// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core.TestFramework;

namespace _Type.Model.Empty.Tests
{
    public partial class _TypeModelEmptyTestBase : RecordedTestBase<_TypeModelEmptyTestEnvironment>
    {
        public _TypeModelEmptyTestBase(bool isAsync) : base(isAsync)
        {
        }

        protected EmptyClient CreateEmptyClient(Uri endpoint)
        {
            EmptyClientOptions options = InstrumentClientOptions(new EmptyClientOptions());
            EmptyClient client = new EmptyClient(endpoint, options);
            return InstrumentClient(client);
        }
    }
}
