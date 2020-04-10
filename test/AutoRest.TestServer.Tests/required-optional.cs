// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;
using required_optional;

namespace AutoRest.TestServer.Tests
{
    public class RequiredOptionalTest : TestServerTestBase
    {
        public RequiredOptionalTest(TestServerVersion version) : base(version, "reqopt") { }

        private void TestDefaultNullParameter(Type clientType, string methodName, string parameterName)
        {
            var parameters = clientType.GetMethod(methodName)?.GetParameters() ?? Array.Empty<ParameterInfo>();
            var parameter = parameters.FirstOrDefault(p => p.Name == parameterName);
            Assert.NotNull(parameter);
            Assert.IsTrue(parameter.HasDefaultValue);
            Assert.Null(parameter.DefaultValue);
        }

        [Test]
        public Task OptionalArrayHeader() => Test(async (host, pipeline) =>
        {
            var result = await new ExplicitClient(ClientDiagnostics, pipeline, host).RestClient.PostOptionalArrayHeaderAsync();
            Assert.AreEqual(200, result.Status);
            TestDefaultNullParameter(typeof(ExplicitRestClient), nameof(ExplicitRestClient.PostOptionalArrayHeaderAsync), "headerParameter");
        });

        [Test]
        public Task OptionalArrayParameter() => Test(async (host, pipeline) =>
        {
            var result = await new ExplicitClient(ClientDiagnostics, pipeline, host).RestClient.PostOptionalArrayParameterAsync();
            Assert.AreEqual(200, result.Status);
            TestDefaultNullParameter(typeof(ExplicitRestClient), nameof(ExplicitRestClient.PostOptionalArrayParameterAsync), "bodyParameter");
        });

        [Test]
        public Task OptionalArrayProperty() => Test(async (host, pipeline) =>
        {
            var result = await new ExplicitClient(ClientDiagnostics, pipeline, host).RestClient.PostOptionalArrayPropertyAsync();
            Assert.AreEqual(200, result.Status);
            TestDefaultNullParameter(typeof(ExplicitRestClient), nameof(ExplicitRestClient.PostOptionalArrayPropertyAsync), "bodyParameter");
        });

        [Test]
        public Task OptionalClassParameter() => Test(async (host, pipeline) =>
        {
            var result = await new ExplicitClient(ClientDiagnostics, pipeline, host).RestClient.PostOptionalClassParameterAsync();
            Assert.AreEqual(200, result.Status);
            TestDefaultNullParameter(typeof(ExplicitRestClient), nameof(ExplicitRestClient.PostOptionalClassParameterAsync), "bodyParameter");
        });

        [Test]
        public Task OptionalClassProperty() => Test(async (host, pipeline) =>
        {
            var result = await new ExplicitClient(ClientDiagnostics, pipeline, host).RestClient.PostOptionalClassPropertyAsync();
            Assert.AreEqual(200, result.Status);
            TestDefaultNullParameter(typeof(ExplicitRestClient), nameof(ExplicitRestClient.PostOptionalClassPropertyAsync), "bodyParameter");
        });

        private void TestImplicitClientConstructor()
        {
            var constructorParameters = typeof(ImplicitRestClient).GetConstructors().FirstOrDefault(c => c.GetParameters().Any())?.GetParameters() ?? Array.Empty<ParameterInfo>();
            var pathParameter = constructorParameters.FirstOrDefault(p => p.Name == "requiredGlobalPath");
            var queryParameter = constructorParameters.FirstOrDefault(p => p.Name == "requiredGlobalQuery");
            Assert.NotNull(pathParameter);
            Assert.NotNull(queryParameter);
            Assert.IsFalse(pathParameter.HasDefaultValue);
            Assert.IsFalse(queryParameter.HasDefaultValue);
        }

        [Test]
        public Task OptionalGlobalQuery() => Test(async (host, pipeline) =>
        {
            var result = await new ImplicitClient(ClientDiagnostics, pipeline, string.Empty, string.Empty, host).RestClient.GetOptionalGlobalQueryAsync();
            Assert.AreEqual(200, result.Status);
            TestImplicitClientConstructor();
        });

        [Test]
        public Task OptionalImplicitBody() => Test(async (host, pipeline) =>
        {
            var result = await new ImplicitClient(ClientDiagnostics, pipeline, string.Empty, string.Empty, host).RestClient.PutOptionalBodyAsync();
            Assert.AreEqual(200, result.Status);
            TestImplicitClientConstructor();
            TestDefaultNullParameter(typeof(ImplicitRestClient), nameof(ImplicitRestClient.PutOptionalBodyAsync), "bodyParameter");
        });

        [Test]
        public Task OptionalImplicitHeader() => Test(async (host, pipeline) =>
        {
            var result = await new ImplicitClient(ClientDiagnostics, pipeline, string.Empty, string.Empty, host).RestClient.PutOptionalHeaderAsync();
            Assert.AreEqual(200, result.Status);
            TestImplicitClientConstructor();
            TestDefaultNullParameter(typeof(ImplicitRestClient), nameof(ImplicitRestClient.PutOptionalHeaderAsync), "queryParameter");
        });

        [Test]
        public Task OptionalImplicitQuery() => Test(async (host, pipeline) =>
        {
            var result = await new ImplicitClient(ClientDiagnostics, pipeline, string.Empty, string.Empty, host).RestClient.PutOptionalQueryAsync();
            Assert.AreEqual(200, result.Status);
            TestImplicitClientConstructor();
            TestDefaultNullParameter(typeof(ImplicitRestClient), nameof(ImplicitRestClient.PutOptionalQueryAsync), "queryParameter");
        });

        [Test]
        public Task OptionalIntegerHeader() => Test(async (host, pipeline) =>
        {
            var result = await new ExplicitClient(ClientDiagnostics, pipeline, host).RestClient.PostOptionalIntegerHeaderAsync();
            Assert.AreEqual(200, result.Status);
            TestDefaultNullParameter(typeof(ExplicitRestClient), nameof(ExplicitRestClient.PostOptionalIntegerHeaderAsync), "headerParameter");
        });

        [Test]
        public Task OptionalIntegerParameter() => Test(async (host, pipeline) =>
        {
            var result = await new ExplicitClient(ClientDiagnostics, pipeline, host).RestClient.PostOptionalIntegerParameterAsync();
            Assert.AreEqual(200, result.Status);
            TestDefaultNullParameter(typeof(ExplicitRestClient), nameof(ExplicitRestClient.PostOptionalIntegerParameterAsync), "bodyParameter");
        });

        [Test]
        public Task OptionalIntegerProperty() => Test(async (host, pipeline) =>
        {
            var result = await new ExplicitClient(ClientDiagnostics, pipeline, host).RestClient.PostOptionalIntegerPropertyAsync();
            Assert.AreEqual(200, result.Status);
            TestDefaultNullParameter(typeof(ExplicitRestClient), nameof(ExplicitRestClient.PostOptionalIntegerPropertyAsync), "bodyParameter");
        });

        [Test]
        public Task OptionalStringHeader() => Test(async (host, pipeline) =>
        {
            var result = await new ExplicitClient(ClientDiagnostics, pipeline, host).RestClient.PostOptionalStringHeaderAsync();
            Assert.AreEqual(200, result.Status);
            TestDefaultNullParameter(typeof(ExplicitRestClient), nameof(ExplicitRestClient.PostOptionalStringHeaderAsync), "bodyParameter");
        });

        [Test]
        public Task OptionalStringParameter() => Test(async (host, pipeline) =>
        {
            var result = await new ExplicitClient(ClientDiagnostics, pipeline, host).RestClient.PostOptionalStringParameterAsync();
            Assert.AreEqual(200, result.Status);
            TestDefaultNullParameter(typeof(ExplicitRestClient), nameof(ExplicitRestClient.PostOptionalStringParameterAsync), "bodyParameter");
        });

        [Test]
        public Task OptionalStringProperty() => Test(async (host, pipeline) =>
        {
            var result = await new ExplicitClient(ClientDiagnostics, pipeline, host).RestClient.PostOptionalStringPropertyAsync();
            Assert.AreEqual(200, result.Status);
            TestDefaultNullParameter(typeof(ExplicitRestClient), nameof(ExplicitRestClient.PostOptionalStringParameterAsync), "bodyParameter");
        });
    }
}
