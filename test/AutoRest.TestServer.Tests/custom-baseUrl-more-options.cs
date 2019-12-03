// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading.Tasks;
using custom_baseUrl_more_options;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class custom_baseUrl_more_options : TestServerTestBase
    {
        [Test]
        public Task GetEmpty() => TestStatus("customuri_test12_key1", async (host, pipeline) =>
            await PathsOperations.GetEmptyAsync(ClientDiagnostics, pipeline, vault: host, string.Empty, "key1", "test12", "v1", dnsSuffix: string.Empty));
    }
}
