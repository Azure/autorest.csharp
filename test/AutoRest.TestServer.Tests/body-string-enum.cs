// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using body_string;
using body_string.Models.V100;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class BodyStringEnumTest : TestServerTestBase
    {
        public BodyStringEnumTest(TestServerVersion version) : base(version) { }

        [Test]
        public Task GetNotExpandable() => Test("getEnumNotExpandable", async (host, pipeline) =>
        {
            var result = await EnumOperations.GetNotExpandableAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(Colors.RedColor, result.Value);
        });

        [Test]
        public Task PutNotExpandable() => TestStatus("putEnumNotExpandable", async (host, pipeline) =>
            await EnumOperations.PutNotExpandableAsync(ClientDiagnostics, pipeline, Colors.RedColor, host));
    }
}
