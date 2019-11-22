using System;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Identity;
using BodyComplex.Models.V20160229;
using BodyComplex.Operations.V20160229;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class BodyComplexTest
    {
        [Test]
        public async Task GetValid()
        {
            await using var server = TestServerSession.Start("complex_basic_valid");

            var clientDiagnostics = new ClientDiagnostics(new DefaultAzureCredentialOptions());
            var pipeline = HttpPipelineBuilder.Build(new DefaultAzureCredentialOptions());
            var result = BasicOperations.GetValidAsync(clientDiagnostics, pipeline, server.Client.BaseAddress.ToString().TrimEnd('/')).GetAwaiter().GetResult();
            Assert.AreEqual("abc", result.Value.Name);
            Assert.AreEqual(2, result.Value.Id);
            Assert.AreEqual(CMYKColors.YELLOW, result.Value.Color);
        }

        [Test]
        public async Task PutValid()
        {
            await using var server = TestServerSession.Start("complex_basic_valid");

            var clientDiagnostics = new ClientDiagnostics(new DefaultAzureCredentialOptions());
            var pipeline = HttpPipelineBuilder.Build(new DefaultAzureCredentialOptions());
            var basic = new Basic
            {
                Name = "abc",
                Id = 2,
                Color = CMYKColors.Magenta
            };
            var result = BasicOperations.PutValidAsync(clientDiagnostics, pipeline, basic, server.Client.BaseAddress.ToString().TrimEnd('/')).GetAwaiter().GetResult();
            Assert.AreEqual(200, result.Status);
        }
    }
}
