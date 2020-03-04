﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class custom_baseURL : TestServerTestBase
    {
        public custom_baseURL(TestServerVersion version) : base(version, "customUri") { }

        [Test]
        public Task CustomBaseUri() => TestStatus(async (host, pipeline) =>
            await new custom_baseUrl.PathsClient(ClientDiagnostics, pipeline, host.Replace("http://", string.Empty)).GetEmptyAsync( string.Empty));

        [Test]
        public Task CustomBaseUriMoreOptions() => TestStatus(async (host, pipeline) =>
            await new custom_baseUrl_more_options.PathsClient(ClientDiagnostics, pipeline, "test12", dnsSuffix: host).GetEmptyAsync( string.Empty, string.Empty, "key1",  "v1"));
    }
}
