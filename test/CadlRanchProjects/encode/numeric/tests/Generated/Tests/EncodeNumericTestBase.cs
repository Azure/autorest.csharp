// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core.TestFramework;

namespace Encode.Numeric.Tests
{
    public partial class EncodeNumericTestBase : RecordedTestBase<EncodeNumericTestEnvironment>
    {
        public EncodeNumericTestBase(bool isAsync) : base(isAsync)
        {
        }

        protected NumericClient CreateNumericClient(Uri endpoint)
        {
            NumericClientOptions options = InstrumentClientOptions(new NumericClientOptions());
            NumericClient client = new NumericClient(endpoint, options);
            return InstrumentClient(client);
        }
    }
}
