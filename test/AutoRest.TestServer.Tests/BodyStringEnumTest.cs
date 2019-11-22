// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using body_string.Models.V100;
using body_string.Operations.V100;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class BodyStringEnumTest : TestServerTestBase
    {
        [Test]
        public async Task GetNotExpandable()
        {
            await using var server = TestServerSession.Start("string_enum_notexpandable");

            var result = EnumOperations.GetNotExpandableAsync(ClientDiagnostics, Pipeline, server.Host).GetAwaiter().GetResult();
            Assert.AreEqual(Colors.RedColor, result.Value);
        }

        [Test]
        [Ignore("serializer fails")]
        public async Task PutNotExpandable()
        {
            await using var server = TestServerSession.Start("string_enum_notexpandable");

            var result = EnumOperations.PutNotExpandableAsync(ClientDiagnostics, Pipeline, Colors.RedColor, server.Host).GetAwaiter().GetResult();
            Assert.AreEqual(200, result.Status);
        }
    }
}
