// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Accessibility_LowLevel;
using Azure;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Accessibility_LowLevel.Tests
{
    public partial class Accessibility_LowLevelTestBase : RecordedTestBase<Accessibility_LowLevelTestEnvironment>
    {
        public Accessibility_LowLevelTestBase(bool isAsync) : base(isAsync)
        {
        }

        protected AccessibilityClient CreateAccessibilityClient(AzureKeyCredential credential, Uri endpoint)
        {
            var options = InstrumentClientOptions(new AccessibilityClientOptions());
            var client = new AccessibilityClient(credential, endpoint, options: options);
            return InstrumentClient(client);
        }
    }
}
