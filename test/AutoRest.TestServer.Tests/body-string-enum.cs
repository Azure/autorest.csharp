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
        [Test]
        public Task GetNotExpandable() => Test("string_enum_notexpandable", async host =>
        {
            var result = await EnumOperations.GetNotExpandableAsync(ClientDiagnostics, Pipeline, host);
            Assert.AreEqual(Colors.RedColor, result.Value);
        });

        [Test]
        public Task PutNotExpandable() => TestStatus("string_enum_notexpandable", async host =>
            await EnumOperations.PutNotExpandableAsync(ClientDiagnostics, Pipeline, Colors.RedColor, host));
    }
}
