using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Identity;
using BodyString.Operations.V100;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class BodyStringTest
    {
        [Test]
        public async Task GetMbcs()
        {
            await using var server = TestServerSession.Start("string_mbcs");

            var clientDiagnostics = new ClientDiagnostics(new DefaultAzureCredentialOptions());
            var pipeline = HttpPipelineBuilder.Build(new DefaultAzureCredentialOptions());
            var result = StringOperations.GetMbcsAsync(clientDiagnostics, pipeline, server.Client.BaseAddress.ToString().TrimEnd('/')).GetAwaiter().GetResult();
            Assert.AreEqual("啊齄丂狛狜隣郎隣兀﨩ˊ〞〡￤℡㈱‐ー﹡﹢﹫、〓ⅰⅹ⒈€㈠㈩ⅠⅫ！￣ぁんァヶΑ︴АЯаяāɡㄅㄩ─╋︵﹄︻︱︳︴ⅰⅹɑɡ〇〾⿻⺁䜣€", result.Value);
        }

        [Test]
        public async Task PutMbcs()
        {
            await using var server = TestServerSession.Start(true);

            var clientDiagnostics = new ClientDiagnostics(new DefaultAzureCredentialOptions());
            var pipeline = HttpPipelineBuilder.Build(new DefaultAzureCredentialOptions());
            var result = StringOperations.PutMbcsAsync(clientDiagnostics, pipeline, server.Client.BaseAddress.ToString().TrimEnd('/')).GetAwaiter().GetResult();
            Assert.AreEqual(200, result.Status);
        }
    }
}
