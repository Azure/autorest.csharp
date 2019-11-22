// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class TestServerTest
    {
        [Test]
        public async Task StartsAndReportsCoverage()
        {
            await using var session = TestServerSession.Start();

            var response = await session.Server.Client.PutAsync("/string/null", new ByteArrayContent(Array.Empty<byte>()));
            response.EnsureSuccessStatusCode();

            var coverage = await session.Server.GetUnmatchedRequests();
            Assert.IsEmpty(coverage);

            var matched = await session.Server.GetMatchedStubs();

            CollectionAssert.AreEqual(new string[]
            {
                "string_null"
            }, matched);
        }

        [Test]
        public async Task VerifiesUnmatched()
        {
            var server = TestServerSession.Start();

            await server.Server.Client.PutAsync("/string/nullaa", new ByteArrayContent(Array.Empty<byte>()));

            Assert.ThrowsAsync<InvalidOperationException>(async () => await server.DisposeAsync());
        }

        [Test]
        public async Task VerifiesCoverage()
        {
            var server = TestServerSession.Start("string_empty");

            await server.Server.Client.PutAsync("/string/null", new ByteArrayContent(Array.Empty<byte>()));

            Assert.ThrowsAsync<InvalidOperationException>(async () => await server.DisposeAsync());
        }

        [Test]
        public async Task NormalUsage()
        {
            await using var server = TestServerSession.Start("string_null");

            var response = await server.Server.Client.PutAsync("/string/null", new ByteArrayContent(Array.Empty<byte>()));
            response.EnsureSuccessStatusCode();
        }
    }
}
