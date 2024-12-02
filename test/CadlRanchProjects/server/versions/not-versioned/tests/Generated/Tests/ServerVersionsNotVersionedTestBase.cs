// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core.TestFramework;

namespace Server.Versions.NotVersioned.Tests
{
    public partial class ServerVersionsNotVersionedTestBase : RecordedTestBase<ServerVersionsNotVersionedTestEnvironment>
    {
        public ServerVersionsNotVersionedTestBase(bool isAsync) : base(isAsync)
        {
        }

        protected NotVersionedClient CreateNotVersionedClient(Uri endpoint)
        {
            NotVersionedClientOptions options = InstrumentClientOptions(new NotVersionedClientOptions());
            NotVersionedClient client = new NotVersionedClient(endpoint, options);
            return InstrumentClient(client);
        }
    }
}
