// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure;
using Azure.Core.TestFramework;
using body_string_LowLevel;

namespace body_string_LowLevel.Tests
{
    public partial class body_string_LowLevelTestBase : RecordedTestBase<body_string_LowLevelTestEnvironment>
    {
        public body_string_LowLevelTestBase(bool isAsync) : base(isAsync)
        {
        }

        protected StringClient CreateStringClient(Uri endpoint, AzureKeyCredential credential)
        {
            AutoRestSwaggerBATServiceClientOptions options = InstrumentClientOptions(new AutoRestSwaggerBATServiceClientOptions());
            StringClient client = new StringClient(endpoint, credential, options);
            return InstrumentClient(client);
        }

        protected EnumClient CreateEnumClient(Uri endpoint, AzureKeyCredential credential)
        {
            AutoRestSwaggerBATServiceClientOptions options = InstrumentClientOptions(new AutoRestSwaggerBATServiceClientOptions());
            EnumClient client = new EnumClient(endpoint, credential, options);
            return InstrumentClient(client);
        }
    }
}
