// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text.Json;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class AppendOrReplaceApiVersionTests
    {
        [TestCase("/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/testRG-416/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testRi-6086", "https://management.azure.com/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRG-416/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testRi-6086?api-version=2021-09-30-PREVIEW", "/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/testRG-416/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testRi-6086?api-version=2021-09-30-PREVIEW")]
        [TestCase("/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/testRG-416/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testRi-6086?api-version=2021-10-30-PREVIEW", "https://management.azure.com/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRG-416/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testRi-6086?api-version=2021-09-30-PREVIEW", "/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/testRG-416/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testRi-6086?api-version=2021-09-30-PREVIEW")]
        [TestCase("https://management.azure.com/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/testRG-416/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testRi-6086", "https://management.azure.com/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRG-416/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testRi-6086?api-version=2021-09-30-PREVIEW", "https://management.azure.com/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/testRG-416/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testRi-6086?api-version=2021-09-30-PREVIEW")]
        [TestCase("https://management.azure.com/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/testRG-416/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testRi-6086?api-version=2021-10-30-PREVIEW", "https://management.azure.com/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRG-416/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testRi-6086?api-version=2021-09-30-PREVIEW", "https://management.azure.com/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/testRG-416/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testRi-6086?api-version=2021-09-30-PREVIEW")]
        [TestCase("xyz.com?api-version=2021-10-01&a=b", "https://abc.com?api-version=2021-11-01", "xyz.com?api-version=2021-11-01&a=b")]
        public void TestEqualAfterConvertingToUtc(string uriToProcess, string startRequestUriStr, string expectedUri)
        {
            Uri startRequestUri = new Uri(startRequestUriStr);
            string resultUri = NextLinkOperationImplementation.AppendOrReplaceApiVersion(uriToProcess, startRequestUri);
            Assert.AreEqual(resultUri, expectedUri);
        }
    }
}
