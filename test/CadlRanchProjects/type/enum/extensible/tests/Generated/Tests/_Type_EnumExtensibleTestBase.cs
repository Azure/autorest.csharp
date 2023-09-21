// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core.TestFramework;
using Azure.Identity;
using _Type._Enum.Extensible;

namespace _Type._Enum.Extensible.Tests
{
    public partial class _Type_EnumExtensibleTestBase : RecordedTestBase<_Type_EnumExtensibleTestEnvironment>
    {
        public _Type_EnumExtensibleTestBase(bool isAsync) : base(isAsync)
        {
        }

        protected ExtensibleClient CreateExtensibleClient(Uri endpoint)
        {
            var options = InstrumentClientOptions(new ExtensibleClientOptions());
            var client = new ExtensibleClient(endpoint, options: options);
            return InstrumentClient(client);
        }
    }
}
