// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core.TestFramework;

namespace Server.Path.SingleHeadAsBoolean.Tests
{
    public partial class ServerPathSingleHeadAsBooleanTestBase : RecordedTestBase<ServerPathSingleHeadAsBooleanTestEnvironment>
    {
        public ServerPathSingleHeadAsBooleanTestBase(bool isAsync) : base(isAsync)
        {
        }

        protected SingleClient CreateSingleClient(Uri endpoint)
        {
            SingleClientOptions options = InstrumentClientOptions(new SingleClientOptions());
            SingleClient client = new SingleClient(endpoint, options);
            return InstrumentClient(client);
        }
    }
}
