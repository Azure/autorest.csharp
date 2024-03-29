// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure;
using Azure.Core.TestFramework;

namespace ResourceClients_LowLevel.Tests
{
    public partial class ResourceClients_LowLevelTestBase : RecordedTestBase<ResourceClients_LowLevelTestEnvironment>
    {
        public ResourceClients_LowLevelTestBase(bool isAsync) : base(isAsync)
        {
        }

        protected ResourceServiceClient CreateResourceServiceClient(Uri endpoint, AzureKeyCredential credential)
        {
            ResourceServiceClientOptions options = InstrumentClientOptions(new ResourceServiceClientOptions());
            ResourceServiceClient client = new ResourceServiceClient(endpoint, credential, options);
            return InstrumentClient(client);
        }
    }
}
