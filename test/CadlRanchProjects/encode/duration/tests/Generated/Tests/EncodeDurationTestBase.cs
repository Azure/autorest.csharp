// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core.TestFramework;
using Azure.Identity;
using Encode.Duration;

namespace Encode.Duration.Tests
{
    public partial class EncodeDurationTestBase : RecordedTestBase<EncodeDurationTestEnvironment>
    {
        public EncodeDurationTestBase(bool isAsync) : base(isAsync)
        {
        }

        protected DurationClient CreateDurationClient(Uri endpoint)
        {
            var options = InstrumentClientOptions(new DurationClientOptions());
            var client = new DurationClient(endpoint, options: options);
            return InstrumentClient(client);
        }
    }
}
