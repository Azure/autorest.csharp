// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core.TestFramework;
using Azure.Identity;
using ServiceVersionOverride_LowLevel;

namespace ServiceVersionOverride_LowLevel.Tests
{
    public partial class ServiceVersionOverride_LowLevelTestBase : RecordedTestBase<ServiceVersionOverride_LowLevelTestEnvironment>
    {
        public ServiceVersionOverride_LowLevelTestBase(bool isAsync) : base(isAsync)
        {
        }

        protected ServiceVersionOverrideClient CreateServiceVersionOverrideClient(Uri endpoint)
        {
            var options = InstrumentClientOptions(new ServiceVersionOverrideClientOptions());
            var client = new ServiceVersionOverrideClient(endpoint, options: options);
            return InstrumentClient(client);
        }
    }
}
