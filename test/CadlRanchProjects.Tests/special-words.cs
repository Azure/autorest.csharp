using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using NUnit.Framework;
using SpecialWords;
using SpecialWords.Models;

namespace CadlRanchProjects.Tests
{
    public class SpecialWordsTests : CadlRanchTestBase
    {
        [Test]
        public Task SpecialWords_Operation_for() => Test(async (host) =>
        {
            Response response = await new SpecialWordsClient(host, null).GetOperationClient().ForAsync();
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task SpecialWords_Parameter_getWithIf() => Test(async (host) =>
        {
            Response response = await new SpecialWordsClient(host, null).GetParameterClient().GetWithIfAsync("weekend");
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task SpecialWords_Parameter_getWithFilter() => Test(async (host) =>
        {
            Response response = await new SpecialWordsClient(host, null).GetParameterClient().GetWithFilterAsync("abc*.");
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task SpecialWords_Model_get() => Test(async (host) =>
        {
            var response = await new SpecialWordsClient(host, null).GetModelClient().GetModelValueAsync();
            Assert.AreEqual("derived", (response.Value as DerivedModel).ModelKind);
            Assert.AreEqual("my.name", (response.Value as DerivedModel).DerivedName);
            Assert.AreEqual("value", (response.Value as DerivedModel).For);
        });

        [Test]
        public Task SpecialWords_Model_put() => Test(async (host) =>
        {
            var response = await new SpecialWordsClient(host, null).GetModelClient().PutAsync(new DerivedModel("derived", "my.name", "value"));
            Assert.AreEqual(204, response.Status);
        });
    }
}
