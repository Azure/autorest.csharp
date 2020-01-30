// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using httpInfrastructure;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class HttpInfrastructureTests : TestServerTestBase
    {
        public HttpInfrastructureTests(TestServerVersion version) : base(version, "httpResponses") { }

        [Test]
        public Task HttpClientFailure400Delete() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync<RequestFailedException>(async () => await new HttpClientFailureOperations(ClientDiagnostics, pipeline, host).Delete400Async());
        });

        [Test]
        public Task HttpClientFailure400Get() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync<RequestFailedException>(async () => await new HttpClientFailureOperations(ClientDiagnostics, pipeline, host).Get400Async());
        });

        [Test]
        public Task HttpClientFailure400Head() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync<RequestFailedException>(async () => await new HttpClientFailureOperations(ClientDiagnostics, pipeline, host).Head400Async());
        });

        [Test]
        public Task HttpClientFailure400Options() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync<RequestFailedException>(async () => await new HttpClientFailureOperations(ClientDiagnostics, pipeline, host).Options400Async());
        }, true);

        [Test]
        public Task HttpClientFailure400Patch() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync<RequestFailedException>(async () => await new HttpClientFailureOperations(ClientDiagnostics, pipeline, host).Patch400Async());
        });

        [Test]
        public Task HttpClientFailure400Post() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync<RequestFailedException>(async () => await new HttpClientFailureOperations(ClientDiagnostics, pipeline, host).Post400Async());
        });

        [Test]
        public Task HttpClientFailure400Put() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync<RequestFailedException>(async () => await new HttpClientFailureOperations(ClientDiagnostics, pipeline, host).Put400Async());
        });

        [Test]
        public Task HttpClientFailure401Head() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync<RequestFailedException>(async () => await new HttpClientFailureOperations(ClientDiagnostics, pipeline, host).Head401Async());
        });

        [Test]
        public Task HttpClientFailure402Get() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync<RequestFailedException>(async () => await new HttpClientFailureOperations(ClientDiagnostics, pipeline, host).Get402Async());
        });

        [Test]
        public Task HttpClientFailure403Get() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync<RequestFailedException>(async () => await new HttpClientFailureOperations(ClientDiagnostics, pipeline, host).Get403Async());
        });

        [Test]
        public Task HttpClientFailure403Options() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync<RequestFailedException>(async () => await new HttpClientFailureOperations(ClientDiagnostics, pipeline, host).Options403Async());
        }, true);

        [Test]
        public Task HttpClientFailure404Put() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync<RequestFailedException>(async () => await new HttpClientFailureOperations(ClientDiagnostics, pipeline, host).Put404Async());
        });

        [Test]
        public Task HttpClientFailure405Patch() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync<RequestFailedException>(async () => await new HttpClientFailureOperations(ClientDiagnostics, pipeline, host).Patch405Async());
        });

        [Test]
        public Task HttpClientFailure406Post() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync<RequestFailedException>(async () => await new HttpClientFailureOperations(ClientDiagnostics, pipeline, host).Post406Async());
        });

        [Test]
        public Task HttpClientFailure407Delete() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync<RequestFailedException>(async () => await new HttpClientFailureOperations(ClientDiagnostics, pipeline, host).Delete407Async());
        });

        [Test]
        public Task HttpClientFailure409Put() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync<RequestFailedException>(async () => await new HttpClientFailureOperations(ClientDiagnostics, pipeline, host).Put409Async());
        });

        [Test]
        public Task HttpClientFailure410Head() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync<RequestFailedException>(async () => await new HttpClientFailureOperations(ClientDiagnostics, pipeline, host).Head410Async());
        });

        [Test]
        public Task HttpClientFailure411Get() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync<RequestFailedException>(async () => await new HttpClientFailureOperations(ClientDiagnostics, pipeline, host).Get411Async());
        });

        [Test]
        public Task HttpClientFailure412Get() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync<RequestFailedException>(async () => await new HttpClientFailureOperations(ClientDiagnostics, pipeline, host).Get412Async());
        });

        [Test]
        public Task HttpClientFailure412Options() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync<RequestFailedException>(async () => await new HttpClientFailureOperations(ClientDiagnostics, pipeline, host).Options412Async());
        }, true);

        [Test]
        public Task HttpClientFailure413Put() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync<RequestFailedException>(async () => await new HttpClientFailureOperations(ClientDiagnostics, pipeline, host).Put413Async());
        });

        [Test]
        public Task HttpClientFailure414Patch() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync<RequestFailedException>(async () => await new HttpClientFailureOperations(ClientDiagnostics, pipeline, host).Patch414Async());
        });

        [Test]
        public Task HttpClientFailure415Post() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync<RequestFailedException>(async () => await new HttpClientFailureOperations(ClientDiagnostics, pipeline, host).Post415Async());
        });

        [Test]
        public Task HttpClientFailure416Get() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync<RequestFailedException>(async () => await new HttpClientFailureOperations(ClientDiagnostics, pipeline, host).Get416Async());
        });

        [Test]
        public Task HttpClientFailure417Delete() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync<RequestFailedException>(async () => await new HttpClientFailureOperations(ClientDiagnostics, pipeline, host).Delete417Async());
        });

        [Test]
        public Task HttpClientFailure429Head() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync<RequestFailedException>(async () => await new HttpClientFailureOperations(ClientDiagnostics, pipeline, host).Head429Async());
        });

        [Test]
        public Task HttpRedirect300Get() => TestStatus(async (host, pipeline) =>
            await new HttpRedirectsOperations(ClientDiagnostics, pipeline, host).Get300Async());

        [Test]
        public Task HttpRedirect300Head() => TestStatus(async (host, pipeline) =>
            await new HttpRedirectsOperations(ClientDiagnostics, pipeline, host).Head300Async());

        [Test]
        public Task HttpRedirect301Get() => TestStatus(async (host, pipeline) =>
            await new HttpRedirectsOperations(ClientDiagnostics, pipeline, host).Get301Async());

        [Test]
        public Task HttpRedirect301Put() => Test(async (host, pipeline) =>
        {
            var result = await new HttpRedirectsOperations(ClientDiagnostics, pipeline, host).Put301Async();
            Assert.AreEqual("/http/failure/500", result.Headers.Location);
        });

        [Test]
        public Task HttpRedirect302Get() => TestStatus(async (host, pipeline) =>
            await new HttpRedirectsOperations(ClientDiagnostics, pipeline, host).Get302Async());

        [Test]
        public Task HttpRedirect302Head() => TestStatus(async (host, pipeline) =>
            await new HttpRedirectsOperations(ClientDiagnostics, pipeline, host).Head302Async());

        [Test]
        public Task HttpRedirect302Patch() => Test(async (host, pipeline) =>
        {
            var result = await new HttpRedirectsOperations(ClientDiagnostics, pipeline, host).Patch302Async();
            Assert.AreEqual("/http/failure/500", result.Headers.Location);
        });

        [Test]
        public Task HttpRedirect303Post() => TestStatus(async (host, pipeline) =>
            await new HttpRedirectsOperations(ClientDiagnostics, pipeline, host).Post303Async());

        [Test]
        public Task HttpRedirect307Delete() => TestStatus(async (host, pipeline) =>
            await new HttpRedirectsOperations(ClientDiagnostics, pipeline, host).Delete307Async());

        [Test]
        public Task HttpRedirect307Get() => TestStatus(async (host, pipeline) =>
            await new HttpRedirectsOperations(ClientDiagnostics, pipeline, host).Get307Async());

        [Test]
        public Task HttpRedirect307Head() => TestStatus(async (host, pipeline) =>
            await new HttpRedirectsOperations(ClientDiagnostics, pipeline, host).Head307Async());

        [Test]
        public Task HttpRedirect307Options() => TestStatus(async (host, pipeline) =>
            await new HttpRedirectsOperations(ClientDiagnostics, pipeline, host).Options307Async());

        [Test]
        public Task HttpRedirect307Patch() => TestStatus(async (host, pipeline) =>
            await new HttpRedirectsOperations(ClientDiagnostics, pipeline, host).Patch307Async());

        [Test]
        public Task HttpRedirect307Post() => TestStatus(async (host, pipeline) =>
            await new HttpRedirectsOperations(ClientDiagnostics, pipeline, host).Post307Async());

        [Test]
        public Task HttpRedirect307Put() => TestStatus(async (host, pipeline) =>
            await new HttpRedirectsOperations(ClientDiagnostics, pipeline, host).Put307Async());

        [Test]
        public Task HttpRetry408Head() => TestStatus(async (host, pipeline) =>
            await new HttpRetryOperations(ClientDiagnostics, pipeline, host).Head408Async());

        [Test]
        public Task HttpRetry500Patch() => TestStatus(async (host, pipeline) =>
            await new HttpRetryOperations(ClientDiagnostics, pipeline, host).Patch500Async());

        [Test]
        public Task HttpRetry500Put() => TestStatus(async (host, pipeline) =>
            await new HttpRetryOperations(ClientDiagnostics, pipeline, host).Put500Async());

        [Test]
        public Task HttpRetry502Get() => TestStatus(async (host, pipeline) =>
            await new HttpRetryOperations(ClientDiagnostics, pipeline, host).Get502Async());

        [Test]
        public Task HttpRetry502Options() => Test(async (host, pipeline) =>
        {
            var result = await new HttpRetryOperations(ClientDiagnostics, pipeline, host).Options502Async();
            Assert.AreEqual(true, result.Value);
        });

        [Test]
        public Task HttpRetry503Delete() => TestStatus(async (host, pipeline) =>
            await new HttpRetryOperations(ClientDiagnostics, pipeline, host).Delete503Async());

        [Test]
        public Task HttpRetry503Post() => TestStatus(async (host, pipeline) =>
            await new HttpRetryOperations(ClientDiagnostics, pipeline, host).Post503Async());

        [Test]
        public Task HttpRetry504Patch() => TestStatus(async (host, pipeline) =>
            await new HttpRetryOperations(ClientDiagnostics, pipeline, host).Patch504Async());

        [Test]
        public Task HttpRetry504Put() => TestStatus(async (host, pipeline) =>
            await new HttpRetryOperations(ClientDiagnostics, pipeline, host).Put504Async());

        [Test]
        public Task HttpServerFailure501Get() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync<RequestFailedException>(async () => await new HttpServerFailureOperations(ClientDiagnostics, pipeline, host).Get501Async());
        });

        [Test]
        public Task HttpServerFailure501Head() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync<RequestFailedException>(async () => await new HttpServerFailureOperations(ClientDiagnostics, pipeline, host).Head501Async());
        });

        [Test]
        public Task HttpServerFailure505Delete() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync<RequestFailedException>(async () => await new HttpServerFailureOperations(ClientDiagnostics, pipeline, host).Delete505Async());
        });

        [Test]
        public Task HttpServerFailure505Post() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync<RequestFailedException>(async () => await new HttpServerFailureOperations(ClientDiagnostics, pipeline, host).Post505Async());
        });

        [Test]
        public Task HttpSuccess200Delete() => TestStatus(async (host, pipeline) =>
            await new HttpSuccessOperations(ClientDiagnostics, pipeline, host).Delete200Async());

        [Test]
        public Task HttpSuccess200Get() => Test(async (host, pipeline) =>
        {
            var result = await new HttpSuccessOperations(ClientDiagnostics, pipeline, host).Get200Async();
            Assert.AreEqual(true, result.Value);
        });

        [Test]
        public Task HttpSuccess200Head() => TestStatus(async (host, pipeline) =>
            await new HttpSuccessOperations(ClientDiagnostics, pipeline, host).Head200Async());

        [Test]
        public Task HttpSuccess200Options() => Test(async (host, pipeline) =>
        {
            var result = await new HttpSuccessOperations(ClientDiagnostics, pipeline, host).Options200Async();
            Assert.AreEqual(true, result.Value);
        }, true);

        [Test]
        public Task HttpSuccess200Patch() => TestStatus(async (host, pipeline) =>
            await new HttpSuccessOperations(ClientDiagnostics, pipeline, host).Patch200Async());

        [Test]
        public Task HttpSuccess200Post() => TestStatus(async (host, pipeline) =>
            await new HttpSuccessOperations(ClientDiagnostics, pipeline, host).Post200Async());

        [Test]
        public Task HttpSuccess200Put() => TestStatus(async (host, pipeline) =>
            await new HttpSuccessOperations(ClientDiagnostics, pipeline, host).Put200Async());

        [Test]
        public Task HttpSuccess201Post() => TestStatus(async (host, pipeline) =>
            await new HttpSuccessOperations(ClientDiagnostics, pipeline, host).Post201Async());

        [Test]
        public Task HttpSuccess201Put() => TestStatus(async (host, pipeline) =>
            await new HttpSuccessOperations(ClientDiagnostics, pipeline, host).Put201Async());

        [Test]
        public Task HttpSuccess202Delete() => TestStatus(async (host, pipeline) =>
            await new HttpSuccessOperations(ClientDiagnostics, pipeline, host).Delete202Async());

        [Test]
        public Task HttpSuccess202Patch() => TestStatus(async (host, pipeline) =>
            await new HttpSuccessOperations(ClientDiagnostics, pipeline, host).Patch202Async());

        [Test]
        public Task HttpSuccess202Post() => TestStatus(async (host, pipeline) =>
            await new HttpSuccessOperations(ClientDiagnostics, pipeline, host).Post202Async());

        [Test]
        public Task HttpSuccess202Put() => TestStatus(async (host, pipeline) =>
            await new HttpSuccessOperations(ClientDiagnostics, pipeline, host).Put202Async());

        [Test]
        public Task HttpSuccess204Delete() => TestStatus(async (host, pipeline) =>
            await new HttpSuccessOperations(ClientDiagnostics, pipeline, host).Delete204Async());

        [Test]
        public Task HttpSuccess204Head() => TestStatus(async (host, pipeline) =>
            await new HttpSuccessOperations(ClientDiagnostics, pipeline, host).Head204Async());

        [Test]
        public Task HttpSuccess204Patch() => TestStatus(async (host, pipeline) =>
            await new HttpSuccessOperations(ClientDiagnostics, pipeline, host).Patch204Async());

        [Test]
        public Task HttpSuccess204Post() => TestStatus(async (host, pipeline) =>
            await new HttpSuccessOperations(ClientDiagnostics, pipeline, host).Post204Async());

        [Test]
        public Task HttpSuccess204Put() => TestStatus(async (host, pipeline) =>
            await new HttpSuccessOperations(ClientDiagnostics, pipeline, host).Put204Async());

        [Test]
        public Task HttpSuccess404Head() => Test(async (host, pipeline) =>
        {
            var result = await new HttpSuccessOperations(ClientDiagnostics, pipeline, host).Head404Async();
            Assert.AreEqual(404, result.Status);
        });

        [Test]
        public Task ResponsesScenarioA200MatchingModel() => Test(async (host, pipeline) =>
        {
            var result = await new MultipleResponsesOperations(ClientDiagnostics, pipeline, host).Get200Model204NoModelDefaultError200ValidAsync();
            Assert.AreEqual("200", result.Value.StatusCode);
        });

        [Test]
        public Task ResponsesScenarioA201DefaultNoModel() => Test(async (host, pipeline) =>
        {
            var result = await new MultipleResponsesOperations(ClientDiagnostics, pipeline, host).Get200Model204NoModelDefaultError204ValidAsync();
            Assert.AreEqual("200", result.Value.StatusCode);
        });

        [Test]
        public Task ResponsesScenarioA202DefaultNoModel() => Test(async (host, pipeline) =>
        {
            var result = await new MultipleResponsesOperations(ClientDiagnostics, pipeline, host).Get200Model204NoModelDefaultError202NoneAsync();
            Assert.AreEqual("202", result.Value.StatusCode);
        });

        [Test]
        public Task ResponsesScenarioA204MatchingNoModel() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task ResponsesScenarioA400DefaultModel() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task ResponsesScenarioB200MatchingModel() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task ResponsesScenarioB201MatchingModel() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task ResponsesScenarioB400DefaultModel() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task ResponsesScenarioC200MatchingModel() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task ResponsesScenarioC201MatchingModel() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task ResponsesScenarioC400DefaultModel() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task ResponsesScenarioC404MatchingModel() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task ResponsesScenarioD202MatchingNoModel() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task ResponsesScenarioD204MatchingNoModel() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task ResponsesScenarioD400DefaultModel() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task ResponsesScenarioE202MatchingInvalid() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task ResponsesScenarioE204MatchingNoModel() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task ResponsesScenarioE400DefaultInvalid() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task ResponsesScenarioE400DefaultNoModel() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task ResponsesScenarioEmptyErrorBody() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task ResponsesScenarioF200DefaultModel() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task ResponsesScenarioF200DefaultNone() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task ResponsesScenarioF400DefaultModel() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task ResponsesScenarioF400DefaultNone() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task ResponsesScenarioG200DefaultInvalid() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task ResponsesScenarioG200DefaultNoModel() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task ResponsesScenarioG400DefaultInvalid() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task ResponsesScenarioG400DefaultNoModel() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task ResponsesScenarioH200MatchingInvalid() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task ResponsesScenarioH200MatchingModel() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task ResponsesScenarioH200MatchingNone() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task ResponsesScenarioH202NonMatchingModel() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task ResponsesScenarioH400NonMatchingInvalid() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task ResponsesScenarioH400NonMatchingModel() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task ResponsesScenarioH400NonMatchingNone() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task ResponsesScenarioNoModelEmptyBody() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task ResponsesScenarioNoModelErrorBody() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });
    }
}
