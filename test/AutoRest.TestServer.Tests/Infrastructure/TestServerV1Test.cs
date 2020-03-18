using System;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Infrastructure
{
    public class TestServerV1Test
    {
        [Test]
        public async Task StartsAndReportsCoverage()
        {
            await using var session = TestServerSession.Start("StartsAndReportsCoverage", TestServerVersion.V1);

            var response = await session.Server.Client.PutAsync("/string/null", new ByteArrayContent(Array.Empty<byte>()));
            response.EnsureSuccessStatusCode();

            var matched = await session.Server.GetMatchedStubs("StartsAndReportsCoverage");

            CollectionAssert.Contains(matched, "putStringNull");
        }

        [Test]
        public async Task VerifiesCoverage()
        {
            var session = TestServerSession.Start("VerifiesCoverage", TestServerVersion.V1, allowUnmatched:false, "string_empty");

            await session.Server.Client.PutAsync("/string/null", new ByteArrayContent(Array.Empty<byte>()));

            Assert.ThrowsAsync<InvalidOperationException>(async () => await session.DisposeAsync());
        }

        [Test]
        public async Task NormalUsage()
        {
            await using var session = TestServerSession.Start("NormalUsage", TestServerVersion.V1, allowUnmatched:false,"putStringNull");

            var response = await session.Server.Client.PutAsync("/string/null", new ByteArrayContent(Array.Empty<byte>()));
            response.EnsureSuccessStatusCode();
        }
    }
}
