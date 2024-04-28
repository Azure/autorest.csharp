using System;
using System.ClientModel;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using NUnit.Framework;
using Scm.SpecialWords;
using Scm.SpecialWords.Models;

namespace CadlRanchProjectsNonAzure.Tests
{
    public class SpecialWordsTests : CadlRanchNonAzureTestBase
    {
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
            var response = await (Task<ClientResult>)typeof(Operations).GetMethod(methodName).Invoke(client, new object[] { new System.ClientModel.Primitives.RequestOptions() });
            NUnit.Framework.Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [TestCase("WithAndAsync")]
        [TestCase("WithAndAsync")]
        [TestCase("WithAsAsync")]
        [TestCase("WithAssertAsync")]
        [TestCase("WithAsyncAsync")]
        [TestCase("WithAwaitAsync")]
        [TestCase("WithBreakAsync")]
        [TestCase("WithClassAsync")]
        [TestCase("WithConstructorAsync")]
        [TestCase("WithContinueAsync")]
        [TestCase("WithDefAsync")]
        [TestCase("WithDelAsync")]
        [TestCase("WithElifAsync")]
        [TestCase("WithElseAsync")]
        [TestCase("WithExceptAsync")]
        [TestCase("WithExecAsync")]
        [TestCase("WithFinallyAsync")]
        [TestCase("WithForAsync")]
        [TestCase("WithFromAsync")]
        [TestCase("WithGlobalAsync")]
        [TestCase("WithIfAsync")]
        [TestCase("WithImportAsync")]
        [TestCase("WithInAsync")]
        [TestCase("WithIsAsync")]
        [TestCase("WithLambdaAsync")]
        [TestCase("WithNotAsync")]
        [TestCase("WithOrAsync")]
        [TestCase("WithPassAsync")]
        [TestCase("WithRaiseAsync")]
        [TestCase("WithReturnAsync")]
        [TestCase("WithTryAsync")]
        [TestCase("WithWhileAsync")]
        [TestCase("WithWithAsync")]
        [TestCase("WithYieldAsync")]
        [TestCase("WithCancellationTokenAsync")]
        public Task SpecialWords_Parameters(string methodName) => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await (Task<ClientResult>)typeof(Parameters).GetMethod(methodName).Invoke(client, new Object[] { "ok", new System.ClientModel.Primitives.RequestOptions() });
            NUnit.Framework.Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task SpecialWords_ModelProperties_SameAsModelAsync() => Test(async (host) =>
        {
            SameAsModel body = new SameAsModel("ok");
            var response = await new SpecialWordsClient(host, null).GetModelPropertiesClient().SameAsModelAsync(body);
            NUnit.Framework.Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        public static object[] ModelsOpsClientCases =
        {
            new object[] { new And("ok"), "WithAndAsync" },
            new object[] { new As("ok"), "WithAsAsync" },
            new object[] { new Scm.SpecialWords.Models.Assert("ok"), "WithAssertAsync" },
            new object[] { new Async("ok"), "WithAsyncAsync" },
            new object[] { new Await("ok"), "WithAwaitAsync" },
            new object[] { new Break("ok"), "WithBreakAsync" },
            new object[] { new Class("ok"), "WithClassAsync" },
            new object[] { new Constructor("ok"), "WithConstructorAsync" },
            new object[] { new Continue("ok"), "WithContinueAsync" },
            new object[] { new Def("ok"), "WithDefAsync" },
            new object[] { new Del("ok"), "WithDelAsync" },
            new object[] { new Elif("ok"), "WithElifAsync" },
            new object[] { new Else("ok"), "WithElseAsync" },
            new object[] { new Except("ok"), "WithExceptAsync" },
            new object[] { new Exec("ok"), "WithExecAsync" },
            new object[] { new Finally("ok"), "WithFinallyAsync" },
            new object[] { new For("ok"), "WithForAsync" },
            new object[] { new From("ok"), "WithFromAsync" },
            new object[] { new Global("ok"), "WithGlobalAsync" },
            new object[] { new If("ok"), "WithIfAsync" },
            new object[] { new Import("ok"), "WithImportAsync" },
            new object[] { new In("ok"), "WithInAsync" },
            new object[] { new Scm.SpecialWords.Models.Is("ok"), "WithIsAsync" },
            new object[] { new Lambda("ok"), "WithLambdaAsync" },
            new object[] { new Not("ok"), "WithNotAsync" },
            new object[] { new Or("ok"), "WithOrAsync" },
            new object[] { new Pass("ok"), "WithPassAsync" },
            new object[] { new Raise("ok"), "WithRaiseAsync" },
            new object[] { new Return("ok"), "WithReturnAsync" },
            new object[] { new Try("ok"), "WithTryAsync" },
            new object[] { new While("ok"), "WithWhileAsync" },
            new object[] { new With("ok"), "WithWithAsync" },
            new object[] { new Yield("ok"), "WithYieldAsync" },
    };
        [TestCaseSource(nameof(ModelsOpsClientCases))]
        public Task SpecialWords_Models<T>(T body, string methodName) => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetModelsOpsClient();
            var response = await (Task<ClientResult>)typeof(Scm.SpecialWords.ModelsOps).GetMethod(methodName, new Type[] {typeof(T)}).Invoke(client, new Object[] { body});
            NUnit.Framework.Assert.AreEqual(204, response.GetRawResponse().Status);
        });
    }
}
