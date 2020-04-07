// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;
using required_optional;

namespace AutoRest.TestServer.Tests
{
    public class RequiredOptionalTest : TestServerTestBase
    {
        public RequiredOptionalTest(TestServerVersion version) : base(version, "reqopt") { }

        [Test]
        public Task OptionalArrayHeader() => TestStatus(async (host, pipeline) => await new ExplicitClient(ClientDiagnostics, pipeline, host).RestClient.PostOptionalArrayHeaderAsync());

        [Test]
        public Task OptionalArrayParameter() => TestStatus(async (host, pipeline) => await new ExplicitClient(ClientDiagnostics, pipeline, host).RestClient.PostOptionalArrayParameterAsync());

        [Test]
        public Task OptionalArrayProperty() => TestStatus(async (host, pipeline) => await new ExplicitClient(ClientDiagnostics, pipeline, host).RestClient.PostOptionalArrayPropertyAsync());

        [Test]
        public Task OptionalClassParameter() => TestStatus(async (host, pipeline) => await new ExplicitClient(ClientDiagnostics, pipeline, host).RestClient.PostOptionalClassParameterAsync());

        [Test]
        public Task OptionalClassProperty() => TestStatus(async (host, pipeline) => await new ExplicitClient(ClientDiagnostics, pipeline, host).RestClient.PostOptionalClassPropertyAsync());

        [Test]
        public Task OptionalGlobalQuery() => TestStatus(async (host, pipeline) => await new ImplicitClient(ClientDiagnostics, pipeline, string.Empty, string.Empty, host).RestClient.GetOptionalGlobalQueryAsync());

        [Test]
        public Task OptionalImplicitBody() => TestStatus(async (host, pipeline) => await new ImplicitClient(ClientDiagnostics, pipeline, string.Empty, string.Empty, host).RestClient.PutOptionalBodyAsync());

        [Test]
        public Task OptionalImplicitHeader() => TestStatus(async (host, pipeline) => await new ImplicitClient(ClientDiagnostics, pipeline, string.Empty, string.Empty, host).RestClient.PutOptionalHeaderAsync());

        [Test]
        public Task OptionalImplicitQuery() => TestStatus(async (host, pipeline) => await new ImplicitClient(ClientDiagnostics, pipeline, string.Empty, string.Empty, host).RestClient.PutOptionalQueryAsync());

        [Test]
        public Task OptionalIntegerHeader() => TestStatus(async (host, pipeline) => await new ExplicitClient(ClientDiagnostics, pipeline, host).RestClient.PostOptionalIntegerHeaderAsync());

        [Test]
        public Task OptionalIntegerParameter() => TestStatus(async (host, pipeline) => await new ExplicitClient(ClientDiagnostics, pipeline, host).RestClient.PostOptionalIntegerParameterAsync());

        [Test]
        public Task OptionalIntegerProperty() => TestStatus(async (host, pipeline) => await new ExplicitClient(ClientDiagnostics, pipeline, host).RestClient.PostOptionalIntegerPropertyAsync());

        [Test]
        public Task OptionalStringHeader() => TestStatus(async (host, pipeline) => await new ExplicitClient(ClientDiagnostics, pipeline, host).RestClient.PostOptionalStringHeaderAsync());

        [Test]
        public Task OptionalStringParameter() => TestStatus(async (host, pipeline) => await new ExplicitClient(ClientDiagnostics, pipeline, host).RestClient.PostOptionalStringParameterAsync());

        [Test]
        public Task OptionalStringProperty() => TestStatus(async (host, pipeline) => await new ExplicitClient(ClientDiagnostics, pipeline, host).RestClient.PostOptionalStringPropertyAsync());
    }
}
