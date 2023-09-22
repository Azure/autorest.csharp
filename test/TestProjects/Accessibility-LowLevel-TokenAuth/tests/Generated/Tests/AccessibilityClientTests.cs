// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Accessibility_LowLevel_TokenAuth;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;

namespace Accessibility_LowLevel_TokenAuth.Tests
{
    public class AccessibilityClientTests : Accessibility_LowLevel_TokenAuthTestBase
    {
        public AccessibilityClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task Operation_Async()
        {
            TokenCredential credential = new DefaultAzureCredential();
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AccessibilityClient client = CreateAccessibilityClient(credential, endpoint);

            RequestContent content = null;
            Response response = await client.OperationAsync(content);
            Console.WriteLine(response.Status);
        }

        [Test]
        public async Task Operation_AllParameters_Async()
        {
            TokenCredential credential = new DefaultAzureCredential();
            Uri endpoint = new Uri("<https://my-service.azure.com>");
            AccessibilityClient client = CreateAccessibilityClient(credential, endpoint);

            RequestContent content = RequestContent.Create("<body>");
            Response response = await client.OperationAsync(content);
            Console.WriteLine(response.Status);
        }
    }
}
