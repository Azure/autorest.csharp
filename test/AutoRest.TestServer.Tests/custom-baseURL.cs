// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading.Tasks;
using custom_baseUrl;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class custom_baseURL : TestServerTestBase
    {
        [Test]
        public Task GetEmpty() => TestStatus("customuri", async (host, pipeline) =>
            await PathsOperations.GetEmptyAsync(ClientDiagnostics, pipeline, string.Empty, host.Replace("http://", string.Empty)));
    }
}
