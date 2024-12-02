// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core.TestFramework;

namespace _Type.Property.AdditionalProperties.Tests
{
    public partial class _TypePropertyAdditionalPropertiesTestBase : RecordedTestBase<_TypePropertyAdditionalPropertiesTestEnvironment>
    {
        public _TypePropertyAdditionalPropertiesTestBase(bool isAsync) : base(isAsync)
        {
        }

        protected AdditionalPropertiesClient CreateAdditionalPropertiesClient(Uri endpoint)
        {
            AdditionalPropertiesClientOptions options = InstrumentClientOptions(new AdditionalPropertiesClientOptions());
            AdditionalPropertiesClient client = new AdditionalPropertiesClient(endpoint, options);
            return InstrumentClient(client);
        }
    }
}
