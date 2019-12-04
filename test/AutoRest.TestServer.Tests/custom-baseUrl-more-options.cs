// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading.Tasks;
using custom_baseUrl_more_options;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class custom_baseUrl_more_options : TestServerTestBase
    {
        public custom_baseUrl_more_options(TestServerVersion version) : base(version) { }

        [Test]
        public Task GetEmpty() => TestStatus("CustomBaseUriMoreOptions", async (host, pipeline) =>
            await PathsOperations.GetEmptyAsync(ClientDiagnostics, pipeline, vault: host, string.Empty, "key1", "test12", "v1", dnsSuffix: string.Empty));
    }
}
