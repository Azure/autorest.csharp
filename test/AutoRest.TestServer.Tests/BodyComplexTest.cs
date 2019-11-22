// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using body_complex.Models.V20160229;
using body_complex.Operations.V20160229;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class BodyComplexTest: TestServerTestBase
    {
        [Test]
        public async Task GetValid()
        {
            await using var server = TestServerSession.Start("complex_basic_valid");

            var result = BasicOperations.GetValidAsync(ClientDiagnostics, Pipeline, server.Host).GetAwaiter().GetResult();
            Assert.AreEqual("abc", result.Value.Name);
            Assert.AreEqual(2, result.Value.Id);
            Assert.AreEqual(CMYKColors.YELLOW, result.Value.Color);
        }

        [Test]
        [Ignore("Needs media type, and still failing after that")]
        public async Task PutValid()
        {
            await using var server = TestServerSession.Start(true);

            var basic = new Basic
            {
                Name = "abc",
                Id = 2,
                Color = CMYKColors.YELLOW
            };
            var result = BasicOperations.PutValidAsync(ClientDiagnostics, Pipeline, basic, server.Host).GetAwaiter().GetResult();
            Assert.AreEqual(200, result.Status);
        }
    }
}
