// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Accessibility_LowLevel_NoAuth;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;

namespace Accessibility_LowLevel_NoAuth.Tests
{
    public class AccessibilityClientTests : Accessibility_LowLevel_NoAuthTestBase
    {
        public AccessibilityClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Operation_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AccessibilityClient client = CreateAccessibilityClient(endpoint);

            RequestContent content = null;
            Response response = await client.OperationAsync(content);
        }

        [Test]
        [Ignore("Skipping this test case because this is only for scaffolding the test cases")]
        public async Task Operation_AllParameters_Async()
        {
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AccessibilityClient client = CreateAccessibilityClient(endpoint);

            RequestContent content = RequestContent.Create("<body>");
            Response response = await client.OperationAsync(content);
        }
    }
}
