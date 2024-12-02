// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;
using Azure.Core.TestFramework;

namespace Authentication.OAuth2.Tests
{
    public partial class AuthenticationOAuth2TestBase : RecordedTestBase<AuthenticationOAuth2TestEnvironment>
    {
        public AuthenticationOAuth2TestBase(bool isAsync) : base(isAsync)
        {
        }

        protected OAuth2Client CreateOAuth2Client(Uri endpoint, TokenCredential credential)
        {
            OAuth2ClientOptions options = InstrumentClientOptions(new OAuth2ClientOptions());
            OAuth2Client client = new OAuth2Client(endpoint, credential, options);
            return InstrumentClient(client);
        }
    }
}
