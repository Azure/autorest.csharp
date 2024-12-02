// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core.TestFramework;

namespace AuthoringTypeSpec.Tests
{
    public partial class AuthoringTypeSpecTestBase : RecordedTestBase<AuthoringTypeSpecTestEnvironment>
    {
        public AuthoringTypeSpecTestBase(bool isAsync) : base(isAsync)
        {
        }

        protected AuthoringTypeSpecClient CreateAuthoringTypeSpecClient(Uri endpoint)
        {
            AuthoringTypeSpecClientOptions options = InstrumentClientOptions(new AuthoringTypeSpecClientOptions());
            AuthoringTypeSpecClient client = new AuthoringTypeSpecClient(endpoint, options);
            return InstrumentClient(client);
        }
    }
}
