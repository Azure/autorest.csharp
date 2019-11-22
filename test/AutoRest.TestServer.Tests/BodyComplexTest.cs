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
            var result = BasicOperations.GetValidAsync(clientDiagnostics, pipeline, host: server.Client.BaseAddress.ToString().TrimEnd('/')).GetAwaiter().GetResult();
            Assert.AreEqual(result.Value.Name, "abc");
            Assert.AreEqual(result.Value.Id, 2);
            Assert.AreEqual(result.Value.Color, CMYKColors.YELLOW);
        }
    }
}
