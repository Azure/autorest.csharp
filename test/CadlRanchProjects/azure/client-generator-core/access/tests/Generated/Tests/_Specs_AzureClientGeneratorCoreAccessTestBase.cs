// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core.TestFramework;
using Azure.Identity;
using _Specs_.Azure.ClientGenerator.Core.Access;

namespace _Specs_.Azure.ClientGenerator.Core.Access.Tests
{
    public partial class _Specs_AzureClientGeneratorCoreAccessTestBase : RecordedTestBase<_Specs_AzureClientGeneratorCoreAccessTestEnvironment>
    {
        public _Specs_AzureClientGeneratorCoreAccessTestBase(bool isAsync) : base(isAsync)
        {
        }

        protected AccessClient CreateAccessClient(Uri endpoint)
        {
            var options = InstrumentClientOptions(new AccessClientOptions());
            var client = new AccessClient(endpoint, options: options);
            return InstrumentClient(client);
        }
    }
}
