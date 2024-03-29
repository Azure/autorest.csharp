// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure;
using Azure.Core.TestFramework;
using media_types_LowLevel;

namespace media_types_LowLevel.Tests
{
    public partial class media_types_LowLevelTestBase : RecordedTestBase<media_types_LowLevelTestEnvironment>
    {
        public media_types_LowLevelTestBase(bool isAsync) : base(isAsync)
        {
        }

        protected MediaTypesClient CreateMediaTypesClient(Uri endpoint, AzureKeyCredential credential)
        {
            MediaTypesClientOptions options = InstrumentClientOptions(new MediaTypesClientOptions());
            MediaTypesClient client = new MediaTypesClient(endpoint, credential, options);
            return InstrumentClient(client);
        }
    }
}
