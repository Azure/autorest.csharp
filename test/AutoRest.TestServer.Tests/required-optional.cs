// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using NUnit.Framework;
using required_optional;
using required_optional.Models;

namespace AutoRest.TestServer.Tests
{
    public class RequiredOptionalTest : TestServerTestBase
    {
        private void TestDefaultNullParameter(Type clientType, string methodName, string parameterName)
        {
            var parameters = clientType.GetMethod(methodName)?.GetParameters() ?? Array.Empty<ParameterInfo>();
            var parameter = parameters.FirstOrDefault(p => p.Name == parameterName);
            Assert.NotNull(parameter);
            Assert.IsTrue(parameter.HasDefaultValue);
            Assert.Null(parameter.DefaultValue);
        }

        private void TestNotDefaultParameter(Type clientType, string methodName, string parameterName)
        {
            var parameters = clientType.GetMethod(methodName)?.GetParameters() ?? Array.Empty<ParameterInfo>();
            var parameter = parameters.FirstOrDefault(p => p.Name == parameterName);
            Assert.NotNull(parameter);
            Assert.IsFalse(parameter.HasDefaultValue);
        }

        [Test]
        public Task OptionalArrayHeader() => Test(async (host, pipeline) =>
        {
            var result = await GetClient<ExplicitClient>(pipeline, host).PostOptionalArrayHeaderAsync();
            Assert.AreEqual(200, result.Status);
            TestDefaultNullParameter(FindType(typeof(ExplicitClient).Assembly, "ExplicitRestClient"), "PostOptionalArrayHeaderAsync", "headerParameter");
        });

        [Test]
        public Task RequiredArrayHeader() => Test((host, pipeline) =>
        {
            var value = Enumerable.Empty<string>();
            Assert.ThrowsAsync<RequestFailedException>(async () => await GetClient<ExplicitClient>(pipeline, host).PostRequiredArrayHeaderAsync(value));
            TestNotDefaultParameter(FindType(typeof(ExplicitClient).Assembly, "ExplicitRestClient"), "PostRequiredArrayHeaderAsync", "headerParameter");
        }, ignoreScenario: true);

        [Test]
        public Task OptionalArrayParameter() => Test(async (host, pipeline) =>
        {
            var result = await GetClient<ExplicitClient>(pipeline, host).PostOptionalArrayParameterAsync();
            Assert.AreEqual(200, result.Status);
            TestDefaultNullParameter(FindType(typeof(ExplicitClient).Assembly, "ExplicitRestClient"), "PostOptionalArrayParameterAsync", "bodyParameter");
        });

        [Test]
        public Task RequiredArrayParameter() => Test((host, pipeline) =>
        {
            var value = Enumerable.Empty<string>();
            Assert.ThrowsAsync<RequestFailedException>(async () => await GetClient<ExplicitClient>(pipeline, host).PostRequiredArrayParameterAsync(value));
            TestNotDefaultParameter(FindType(typeof(ExplicitClient).Assembly, "ExplicitRestClient"), "PostRequiredArrayParameterAsync", "bodyParameter");
        }, ignoreScenario: true);

        [Test]
        public Task OptionalArrayProperty() => Test(async (host, pipeline) =>
        {
            var result = await GetClient<ExplicitClient>(pipeline, host).PostOptionalArrayPropertyAsync();
            Assert.AreEqual(200, result.Status);
            TestDefaultNullParameter(FindType(typeof(ExplicitClient).Assembly, "ExplicitRestClient"), "PostOptionalArrayPropertyAsync", "bodyParameter");
        });

        [Test]
        public Task RequiredArrayProperty() => Test((host, pipeline) =>
        {
            var value = new ArrayWrapper(Enumerable.Empty<string>());
            Assert.ThrowsAsync<RequestFailedException>(async () => await GetClient<ExplicitClient>(pipeline, host).PostRequiredArrayPropertyAsync(value));
            TestNotDefaultParameter(FindType(typeof(ExplicitClient).Assembly, "ExplicitRestClient"), "PostRequiredArrayPropertyAsync", "bodyParameter");
        }, ignoreScenario: true);

        [Test]
        public Task OptionalClassParameter() => Test(async (host, pipeline) =>
        {
            var result = await GetClient<ExplicitClient>(pipeline, host).PostOptionalClassParameterAsync();
            Assert.AreEqual(200, result.Status);
            TestDefaultNullParameter(FindType(typeof(ExplicitClient).Assembly, "ExplicitRestClient"), "PostOptionalClassParameterAsync", "bodyParameter");
        });

        [Test]
        public Task RequiredClassParameter() => Test((host, pipeline) =>
        {
            var value = new Product(0)
            {
                Name = string.Empty
            };
            Assert.ThrowsAsync<RequestFailedException>(async () => await GetClient<ExplicitClient>(pipeline, host).PostRequiredClassParameterAsync(value));
            TestNotDefaultParameter(FindType(typeof(ExplicitClient).Assembly, "ExplicitRestClient"), "PostRequiredClassParameterAsync", "bodyParameter");
        }, ignoreScenario: true);

        [Test]
        public Task OptionalClassProperty() => Test(async (host, pipeline) =>
        {
            var result = await GetClient<ExplicitClient>(pipeline, host).PostOptionalClassPropertyAsync();
            Assert.AreEqual(200, result.Status);
            TestDefaultNullParameter(FindType(typeof(ExplicitClient).Assembly, "ExplicitRestClient"), "PostOptionalClassPropertyAsync", "bodyParameter");
        });

        [Test]
        public Task RequiredClassProperty() => Test((host, pipeline) =>
        {
            var value = new ClassWrapper(new Product(0)
            {
                Name = string.Empty
            });
            Assert.ThrowsAsync<RequestFailedException>(async () => await GetClient<ExplicitClient>(pipeline, host).PostRequiredClassPropertyAsync(value));
            TestNotDefaultParameter(FindType(typeof(ExplicitClient).Assembly, "ExplicitRestClient"), "PostRequiredClassPropertyAsync", "bodyParameter");
        }, ignoreScenario: true);

        private void TestImplicitClientConstructor()
        {
            var constructorParameters = FindType(typeof(ExplicitClient).Assembly, "ImplicitRestClient").GetConstructors().FirstOrDefault(c => c.GetParameters().Any())?.GetParameters() ?? Array.Empty<ParameterInfo>();
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
            var result = await GetClient<ImplicitClient>(pipeline, string.Empty, string.Empty, host).GetOptionalGlobalQueryAsync();
            Assert.AreEqual(200, result.Status);
            TestImplicitClientConstructor();
        });

        [Test]
        public Task RequiredGlobalQuery() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync<RequestFailedException>(async () => await GetClient<ImplicitClient>(pipeline, string.Empty, string.Empty, host).GetRequiredGlobalQueryAsync());
            TestImplicitClientConstructor();
        }, ignoreScenario: true);

        [Test]
        public Task OptionalImplicitBody() => Test(async (host, pipeline) =>
        {
            var result = await GetClient<ImplicitClient>(pipeline, string.Empty, string.Empty, host).PutOptionalBodyAsync();
            Assert.AreEqual(200, result.Status);
            TestImplicitClientConstructor();
            TestDefaultNullParameter(FindType(typeof(ImplicitClient).Assembly, "ImplicitRestClient"), "PutOptionalBodyAsync", "bodyParameter");
        });

        [Test]
        public Task OptionalImplicitHeader() => Test(async (host, pipeline) =>
        {
            var result = await GetClient<ImplicitClient>(pipeline, string.Empty, string.Empty, host).PutOptionalHeaderAsync();
            Assert.AreEqual(200, result.Status);
            TestImplicitClientConstructor();
            TestDefaultNullParameter(FindType(typeof(ImplicitClient).Assembly, "ImplicitRestClient"), "PutOptionalHeaderAsync", "queryParameter");
        });

        [Test]
        public Task OptionalImplicitQuery() => Test(async (host, pipeline) =>
        {
            var result = await GetClient<ImplicitClient>(pipeline, string.Empty, string.Empty, host).PutOptionalQueryAsync();
            Assert.AreEqual(200, result.Status);
            TestImplicitClientConstructor();
            TestDefaultNullParameter(FindType(typeof(ImplicitClient).Assembly, "ImplicitRestClient"), "PutOptionalQueryAsync", "queryParameter");
        });

        [Test]
        public Task RequiredPath() => Test((host, pipeline) =>
        {
            var value = string.Empty;
            Assert.ThrowsAsync<RequestFailedException>(async () => await GetClient<ImplicitClient>(pipeline, string.Empty, string.Empty, host).GetRequiredPathAsync(value));
            TestImplicitClientConstructor();
            TestNotDefaultParameter(FindType(typeof(ImplicitClient).Assembly, "ImplicitRestClient"), "GetRequiredPathAsync", "pathParameter");
        }, ignoreScenario: true);

        [Test]
        public Task RequiredGlobalPath() => Test((host, pipeline) =>
        {
            Assert.ThrowsAsync<RequestFailedException>(async () => await GetClient<ImplicitClient>(pipeline, string.Empty, string.Empty, host).GetRequiredGlobalPathAsync());
            TestImplicitClientConstructor();
        }, ignoreScenario: true);

        [Test]
        public Task OptionalIntegerHeader() => Test(async (host, pipeline) =>
        {
            var result = await GetClient<ExplicitClient>(pipeline, host).PostOptionalIntegerHeaderAsync();
            Assert.AreEqual(200, result.Status);
            TestDefaultNullParameter(FindType(typeof(ExplicitClient).Assembly, "ExplicitRestClient"), "PostOptionalIntegerHeaderAsync", "headerParameter");
        });

        [Test]
        public Task RequiredIntegerHeader() => Test((host, pipeline) =>
        {
            var value = 0;
            Assert.ThrowsAsync<RequestFailedException>(async () => await GetClient<ExplicitClient>(pipeline, host).PostRequiredIntegerHeaderAsync(value));
            TestNotDefaultParameter(FindType(typeof(ExplicitClient).Assembly, "ExplicitRestClient"), "PostRequiredIntegerHeaderAsync", "headerParameter");
        }, ignoreScenario: true);

        [Test]
        public Task OptionalIntegerParameter() => Test(async (host, pipeline) =>
        {
            var result = await GetClient<ExplicitClient>(pipeline, host).PostOptionalIntegerParameterAsync();
            Assert.AreEqual(200, result.Status);
            TestDefaultNullParameter(FindType(typeof(ExplicitClient).Assembly, "ExplicitRestClient"), "PostOptionalIntegerParameterAsync", "bodyParameter");
        });

        [Test]
        public Task RequiredIntegerParameter() => Test((host, pipeline) =>
        {
            var value = 0;
            Assert.ThrowsAsync<RequestFailedException>(async () => await GetClient<ExplicitClient>(pipeline, host).PostRequiredIntegerParameterAsync(value));
            TestNotDefaultParameter(FindType(typeof(ExplicitClient).Assembly, "ExplicitRestClient"), "PostRequiredIntegerParameterAsync", "bodyParameter");
        }, ignoreScenario: true);

        [Test]
        public Task OptionalIntegerProperty() => Test(async (host, pipeline) =>
        {
            var result = await GetClient<ExplicitClient>(pipeline, host).PostOptionalIntegerPropertyAsync();
            Assert.AreEqual(200, result.Status);
            TestDefaultNullParameter(FindType(typeof(ExplicitClient).Assembly, "ExplicitRestClient"), "PostOptionalIntegerPropertyAsync", "bodyParameter");
        });

        [Test]
        public Task RequiredIntegerProperty() => Test((host, pipeline) =>
        {
            var value = new IntWrapper(0);
            Assert.ThrowsAsync<RequestFailedException>(async () => await GetClient<ExplicitClient>(pipeline, host).PostRequiredIntegerPropertyAsync(value));
            TestNotDefaultParameter(FindType(typeof(ExplicitClient).Assembly, "ExplicitRestClient"), "PostRequiredIntegerPropertyAsync", "bodyParameter");
        }, ignoreScenario: true);

        [Test]
        public Task OptionalStringHeader() => Test(async (host, pipeline) =>
        {
            var result = await GetClient<ExplicitClient>(pipeline, host).PostOptionalStringHeaderAsync();
            Assert.AreEqual(200, result.Status);
            TestDefaultNullParameter(FindType(typeof(ExplicitClient).Assembly, "ExplicitRestClient"), "PostOptionalStringHeaderAsync", "bodyParameter");
        });

        [Test]
        public Task RequiredStringHeader() => Test((host, pipeline) =>
        {
            var value = string.Empty;
            Assert.ThrowsAsync<RequestFailedException>(async () => await GetClient<ExplicitClient>(pipeline, host).PostRequiredStringHeaderAsync(value));
            TestNotDefaultParameter(FindType(typeof(ExplicitClient).Assembly, "ExplicitRestClient"), "PostRequiredStringHeaderAsync", "headerParameter");
        }, ignoreScenario: true);

        [Test]
        public Task OptionalStringParameter() => Test(async (host, pipeline) =>
        {
            var result = await GetClient<ExplicitClient>(pipeline, host).PostOptionalStringParameterAsync();
            Assert.AreEqual(200, result.Status);
            TestDefaultNullParameter(FindType(typeof(ExplicitClient).Assembly, "ExplicitRestClient"), "PostOptionalStringParameterAsync", "bodyParameter");
        });

        [Test]
        public Task RequiredStringParameter() => Test((host, pipeline) =>
        {
            var value = string.Empty;
            Assert.ThrowsAsync<RequestFailedException>(async () => await GetClient<ExplicitClient>(pipeline, host).PostRequiredStringParameterAsync(value));
            TestNotDefaultParameter(FindType(typeof(ExplicitClient).Assembly, "ExplicitRestClient"), "PostRequiredStringParameterAsync", "bodyParameter");
        }, ignoreScenario: true);

        [Test]
        public Task OptionalStringProperty() => Test(async (host, pipeline) =>
        {
            var result = await GetClient<ExplicitClient>(pipeline, host).PostOptionalStringPropertyAsync();
            Assert.AreEqual(200, result.Status);
            TestDefaultNullParameter(FindType(typeof(ExplicitClient).Assembly, "ExplicitRestClient"), "PostOptionalStringPropertyAsync", "bodyParameter");
        });

        [Test]
        public Task RequiredStringProperty() => Test((host, pipeline) =>
        {
            var value = new StringWrapper(string.Empty);
            Assert.ThrowsAsync<RequestFailedException>(async () => await GetClient<ExplicitClient>(pipeline, host).PostRequiredStringPropertyAsync(value));
            TestNotDefaultParameter(FindType(typeof(ExplicitClient).Assembly, "ExplicitRestClient"), "PostRequiredStringPropertyAsync", "bodyParameter");
        }, ignoreScenario: true);
    }
}
