// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core.TestFramework;
using _Specs_.Azure.Core.Basic;

namespace _Specs_.Azure.Core.Basic.Tests
{
    public partial class _Specs_AzureCoreBasicTestBase : RecordedTestBase<_Specs_AzureCoreBasicTestEnvironment>
    {
        public _Specs_AzureCoreBasicTestBase(bool isAsync) : base(isAsync)
        {
        }

        protected BasicClient CreateBasicClient(Uri endpoint)
        {
            BasicClientOptions options = InstrumentClientOptions(new BasicClientOptions());
            BasicClient client = new BasicClient(endpoint, options);
            return InstrumentClient(client);
        }
    }
}
