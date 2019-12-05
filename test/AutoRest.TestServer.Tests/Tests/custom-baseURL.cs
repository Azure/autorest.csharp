// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading.Tasks;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class custom_baseURL : TestServerTestBase
    {
        public custom_baseURL(TestServerVersion version) : base(version, "customUri") { }

        [Test]
        public Task CustomBaseUri() => TestStatus(async (host, pipeline) =>
            await custom_baseUrl.PathsOperations.GetEmptyAsync(ClientDiagnostics, pipeline, string.Empty, host.Replace("http://", string.Empty)));

        [Test]
        public Task CustomBaseUriMoreOptions() => TestStatus(async (host, pipeline) =>
            await global::custom_baseUrl_more_options.PathsOperations.GetEmptyAsync(ClientDiagnostics, pipeline, vault: host, string.Empty, "key1", "test12", "v1", dnsSuffix: string.Empty));
    }
}
