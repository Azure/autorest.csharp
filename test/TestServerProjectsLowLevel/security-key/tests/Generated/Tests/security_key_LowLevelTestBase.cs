// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure;
using Azure.Core.TestFramework;
using security_key_LowLevel;

namespace security_key_LowLevel.Tests
{
    public partial class security_key_LowLevelTestBase : RecordedTestBase<security_key_LowLevelTestEnvironment>
    {
        public security_key_LowLevelTestBase(bool isAsync) : base(isAsync)
        {
        }

        protected AutorestSecurityKeyClient CreateAutorestSecurityKeyClient(Uri endpoint, AzureKeyCredential credential)
        {
            AutorestSecurityKeyClientOptions options = InstrumentClientOptions(new AutorestSecurityKeyClientOptions());
            AutorestSecurityKeyClient client = new AutorestSecurityKeyClient(endpoint, credential, options);
            return InstrumentClient(client);
        }
    }
}
