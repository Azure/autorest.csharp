// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure;
using Azure.Core.TestFramework;
using Azure.Identity;
using header_LowLevel;

namespace header_LowLevel.Tests
{
    public partial class header_LowLevelTestBase : RecordedTestBase<header_LowLevelTestEnvironment>
    {
        public header_LowLevelTestBase(bool isAsync) : base(isAsync)
        {
        }

        protected HeaderClient CreateHeaderClient(AzureKeyCredential credential, Uri endpoint)
        {
            var options = InstrumentClientOptions(new HeaderClientOptions());
            var client = new HeaderClient(credential, endpoint, options: options);
            return InstrumentClient(client);
        }
    }
}
