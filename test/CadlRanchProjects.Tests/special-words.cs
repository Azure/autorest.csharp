using System;
using System.Reflection;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using NUnit.Framework;
using SpecialWords;

namespace CadlRanchProjects.Tests
{
    public class SpecialWordsTests : CadlRanchTestBase
    {
        [Test]
        public Task SpecialWords_Operations_for() => Test(async (host) =>
        {
            Response response = await new SpecialWordsClient(host, null).GetOperationsClient().ForAsync();
            NUnit.Framework.Assert.AreEqual(204, response.Status);
        });

        [TestCase("AndAsync")]
        [TestCase("AsAsync")]
        [TestCase("AssertAsync")]
        [TestCase("AsyncAsync")]
        [TestCase("AwaitAsync")]
        [TestCase("BreakAsync")]
        [TestCase("ClassAsync")]
        [TestCase("ConstructorAsync")]
        [TestCase("ContinueAsync")]
        [TestCase("DefAsync")]
        [TestCase("DelAsync")]
        [TestCase("ElifAsync")]
        [TestCase("ElseAsync")]
        [TestCase("ExceptAsync")]
        [TestCase("ExecAsync")]
        [TestCase("FinallyAsync")]
        [TestCase("ForAsync")]
        [TestCase("FromAsync")]
        [TestCase("GlobalAsync")]
        [TestCase("IfAsync")]
        [TestCase("ImportAsync")]
        [TestCase("InAsync")]
        [TestCase("IsAsync")]
        [TestCase("LambdaAsync")]
        [TestCase("NotAsync")]
        [TestCase("OrAsync")]
        [TestCase("PassAsync")]
        [TestCase("RaiseAsync")]
        [TestCase("ReturnAsync")]
        [TestCase("TryAsync")]
        [TestCase("WhileAsync")]
        [TestCase("WithAsync")]
        [TestCase("YieldAsync")]
        public Task SpecialWords_Operation(string methodName) => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            Response response = await (Task<Response>)typeof(Operations).GetMethod(methodName).Invoke(client, new object[] { new RequestContext() });
            NUnit.Framework.Assert.AreEqual(204, response.Status);
        });

        [TestCase("WithAndAsync", "and")]
        public Task SpecialWords_Parameters(string methodName, string parameterName) => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            Response response = await (Task<Response>)typeof(Operations).GetMethod(methodName).Invoke(client, new object[] { "and", new RequestContext() });
            NUnit.Framework.Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task SpecialWords_Parameter_getWithFilter() => Test(async (host) =>
        {
            Response response = await new SpecialWordsClient(host, null).GetParametersClient().WithIfAsync("abc*.");
            NUnit.Framework.Assert.AreEqual(204, response.Status);
        });
        /*
        [Test]
        public Task SpecialWords_Model_get() => Test(async (host) =>
        {
            var response = await new SpecialWordsClient(host, null).GetModelsClient().GetModelValueAsync();
            NUnit.Framework.Assert.AreEqual("derived", (response.Value as DerivedModel).ModelKind);
            NUnit.Framework.Assert.AreEqual("my.name", (response.Value as DerivedModel).DerivedName);
            NUnit.Framework.Assert.AreEqual("value", (response.Value as DerivedModel).For);
        });

        [Test]
        public Task SpecialWords_Model_put() => Test(async (host) =>
        {
            var response = await new SpecialWordsClient(host, null).GetModelClient().PutAsync(new DerivedModel("derived", "my.name", "value"));
            NUnit.Framework.Assert.AreEqual(204, response.Status);
        });
        */
    }
}
