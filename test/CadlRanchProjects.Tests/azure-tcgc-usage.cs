using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using _Specs_.Azure.ClientGenerator.Core.Usage;
using _Specs_.Azure.ClientGenerator.Core.Usage.Models;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;

namespace CadlRanchProjects.Tests
{
    public class AzureTcgcUsageTests : CadlRanchTestBase
    {
        [Test]
        public Task Azure_ClientGenerator_Core_Usage_ModelInOperation() => Test(async (host) =>
        {
            var response1 = await new UsageClient(host, null).GetModelInOperationClient().InputToInputOutputAsync(new InputModel("Madge"));
            Assert.AreEqual(204, response1.Status);

            var response2 = await new UsageClient(host, null).GetModelInOperationClient().OutputToInputOutputAsync();
            Assert.AreEqual("Madge", response2.Value.Name);

            var response3 = await new UsageClient(host, null).GetModelInOperationClient().ModelInReadOnlyPropertyAsync(new RoundTripModel());
            Assert.AreEqual("Madge", response3.Value.Result.Name);

            Assert.IsNotNull(typeof(InputModel).GetMethod("FromResponse", BindingFlags.Static | BindingFlags.NonPublic));
            Assert.IsNotNull(typeof(InputModel).GetMethod("ToRequestContent", BindingFlags.Instance | BindingFlags.NonPublic));

            Assert.IsNotNull(typeof(OutputModel).GetMethod("FromResponse", BindingFlags.Static | BindingFlags.NonPublic));
            Assert.IsNotNull(typeof(OutputModel).GetMethod("ToRequestContent", BindingFlags.Instance | BindingFlags.NonPublic));

            Assert.IsNotNull(typeof(RoundTripModel).GetMethod("FromResponse", BindingFlags.Static | BindingFlags.NonPublic));
            Assert.IsNotNull(typeof(RoundTripModel).GetMethod("ToRequestContent", BindingFlags.Instance | BindingFlags.NonPublic));
        });
    }
}
