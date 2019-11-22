using System;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Identity;
using body_complex.Models.V20160229;
using body_complex.Operations.V20160229;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class BodyComplexTest
    {
        [Test]
        public async Task GetValid()
        {
            await using var server = TestServerSession.Start("complex_basic_valid");

            var clientDiagnostics = new ClientDiagnostics(new TestOptions());
            var pipeline = HttpPipelineBuilder.Build(new TestOptions());
            var result = BasicOperations.GetValidAsync(clientDiagnostics, pipeline, server.Host).GetAwaiter().GetResult();
            Assert.AreEqual("abc", result.Value.Name);
            Assert.AreEqual(2, result.Value.Id);
            Assert.AreEqual(CMYKColors.YELLOW, result.Value.Color);
        }

        [Test]
        [Ignore("Needs media type, and still failing after that")]
        public async Task PutValid()
        {
            await using var server = TestServerSession.Start(true);

            var clientDiagnostics = new ClientDiagnostics(new TestOptions());
            var pipeline = HttpPipelineBuilder.Build(new TestOptions());
            var basic = new Basic
            {
                Name = "abc",
                Id = 2,
                Color = CMYKColors.YELLOW
            };
            var result = BasicOperations.PutValidAsync(clientDiagnostics, pipeline, basic, server.Host).GetAwaiter().GetResult();
            Assert.AreEqual(200, result.Status);
        }
    }
}
