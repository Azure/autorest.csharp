// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Infrastructure
{
    public class TestServerV2Test
    {
        [Test]
        public async Task StartsAndReportsCoverage()
        {
            await using var session = TestServerSession.Start("StartsAndReportsCoverage", TestServerVersion.V2);

            var response = await (session.Server).Client.PutAsync("/string/null", new ByteArrayContent(Array.Empty<byte>()));
            response.EnsureSuccessStatusCode();

            var unmatchedRequests = await session.Server.GetRequests();
            Assert.IsEmpty(unmatchedRequests);

            var matched = await session.Server.GetMatchedStubs("StartsAndReportsCoverage");

            CollectionAssert.AreEqual(new string[]
            {
                "string_null"
            }, matched);
        }

        [Test]
        public async Task VerifiesUnmatched()
        {
            var session = TestServerSession.Start("VerifiesUnmatched", TestServerVersion.V2);

            await (session.Server).Client.PutAsync("/string/nullaa", new ByteArrayContent(Array.Empty<byte>()));

            Assert.ThrowsAsync<InvalidOperationException>(async () => await session.DisposeAsync());
        }

        [Test]
        public async Task NormalUsage()
        {
            await using var session = TestServerSession.Start("NormalUsage", TestServerVersion.V2, allowUnmatched:false, "string_null");

            var response = await (session.Server).Client.PutAsync("/string/null", new ByteArrayContent(Array.Empty<byte>()));
            response.EnsureSuccessStatusCode();
        }
    }
}
