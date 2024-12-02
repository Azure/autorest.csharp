// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core.TestFramework;

namespace _Type._Enum.Fixed.Tests
{
    public partial class _Type_EnumFixedTestBase : RecordedTestBase<_Type_EnumFixedTestEnvironment>
    {
        public _Type_EnumFixedTestBase(bool isAsync) : base(isAsync)
        {
        }

        protected FixedClient CreateFixedClient(Uri endpoint)
        {
            FixedClientOptions options = InstrumentClientOptions(new FixedClientOptions());
            FixedClient client = new FixedClient(endpoint, options);
            return InstrumentClient(client);
        }
    }
}
