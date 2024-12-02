// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core.TestFramework;
using Versioning.Removed.BetaVersion.Models;

namespace Versioning.Removed.BetaVersion.Tests
{
    public partial class VersioningRemovedBetaVersionTestBase : RecordedTestBase<VersioningRemovedBetaVersionTestEnvironment>
    {
        public VersioningRemovedBetaVersionTestBase(bool isAsync) : base(isAsync)
        {
        }

        protected RemovedClient CreateRemovedClient(Uri endpoint, Versions version)
        {
            RemovedClientOptions options = InstrumentClientOptions(new RemovedClientOptions());
            RemovedClient client = new RemovedClient(endpoint, version, options);
            return InstrumentClient(client);
        }
    }
}
