// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using azure_special_properties;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class AzureSpecialPropertiesTest : TestServerTestBase
    {
        public AzureSpecialPropertiesTest(TestServerVersion version) : base(version, "azureSpecials") { }

        [Test]
        public Task AzureApiVersionMethodGlobalNotProvidedValid() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task AzureApiVersionMethodGlobalValid() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task AzureApiVersionMethodLocalNull() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task AzureApiVersionMethodLocalValid() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task AzureApiVersionPathGlobalValid() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task AzureApiVersionPathLocalValid() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task AzureApiVersionSwaggerGlobalValid() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task AzureApiVersionSwaggerLocalValid() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task AzureMethodPathUrlEncoding() => TestStatus(async (host, pipeline) =>
        {
            var value = "path1/path2/path3";
            return await new SkipUrlEncodingClient(ClientDiagnostics, pipeline, host).RestClient.GetMethodPathValidAsync(value);
        });

        [Test]
        public Task AzureMethodQueryUrlEncoding() => TestStatus(async (host, pipeline) =>
        {
            var value = "value1&q2=value2&q3=value3";
            return await new SkipUrlEncodingClient(ClientDiagnostics, pipeline, host).RestClient.GetMethodQueryValidAsync(value);
        });

        [Test]
        public Task AzureMethodQueryUrlEncodingNull() => TestStatus(async (host, pipeline) => await new SkipUrlEncodingClient(ClientDiagnostics, pipeline, host).RestClient.GetMethodQueryNullAsync());

        [Test]
        public Task AzureODataFilter() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task AzurePathPathUrlEncoding() => TestStatus(async (host, pipeline) =>
        {
            var value = "path1/path2/path3";
            return await new SkipUrlEncodingClient(ClientDiagnostics, pipeline, host).RestClient.GetPathValidAsync(value);
        });

        [Test]
        public Task AzurePathQueryUrlEncoding() => TestStatus(async (host, pipeline) =>
        {
            var value = "value1&q2=value2&q3=value3";
            return await new SkipUrlEncodingClient(ClientDiagnostics, pipeline, host).RestClient.GetPathQueryValidAsync(value);
        });

        [Test]
        public Task AzureRequestClientIdInError() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task AzureSubscriptionMethodGlobalNotProvidedValid() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task AzureSubscriptionMethodGlobalValid() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task AzureSubscriptionMethodLocalValid() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task AzureSubscriptionPathGlobalValid() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task AzureSubscriptionPathLocalValid() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task AzureSubscriptionSwaggerGlobalValid() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task AzureSubscriptionSwaggerLocalValid() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task AzureSwaggerPathUrlEncoding() => TestStatus(async (host, pipeline) => await new SkipUrlEncodingClient(ClientDiagnostics, pipeline, host).RestClient.GetSwaggerPathValidAsync());

        [Test]
        public Task AzureSwaggerQueryUrlEncoding() => TestStatus(async (host, pipeline) => await new SkipUrlEncodingClient(ClientDiagnostics, pipeline, host).RestClient.GetSwaggerQueryValidAsync());

        [Test]
        public Task AzureXmsCustomNamedRequestId() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task AzureXmsCustomNamedRequestIdParameterGroup() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task AzureXmsRequestClientIdNull() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task AzureXmsRequestClientOverwrite() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });

        [Test]
        public Task AzureXmsRequestClientOverwriteViaParameter() => TestStatus(async (host, pipeline) => { await Task.FromException(new Exception()); return null; });
    }
}
