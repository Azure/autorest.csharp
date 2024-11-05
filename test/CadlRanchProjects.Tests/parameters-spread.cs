using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using Azure.Core;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Parameters.Spread;
using Parameters.Spread.Models;
using _Type.Model.Visibility.Models;

namespace CadlRanchProjects.Tests
{
    public class ParametersSpreadTests : CadlRanchTestBase
    {
        [Test]
        public Task Parameters_Spread_Model_spreadAsRequestBody() => Test(async (host) =>
        {
            Response response = await new SpreadClient(host, null).GetModelClient().SpreadAsRequestBodyAsync("foo");
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Parameters_Spread_Model_spreadCompositeRequest() => Test(async (host) =>
        {
            Response response = await new SpreadClient(host, null).GetModelClient().SpreadCompositeRequestAsync("foo", "bar", new BodyParameter("foo"));
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Parameters_Spread_Model_spreadCompositeRequestMix() => Test(async (host) =>
        {
            Response response = await new SpreadClient(host, null).GetModelClient().SpreadCompositeRequestMixAsync("foo", "bar", "foo");
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Parameters_Spread_Model_spreadCompositeRequestOnlyWithBody() => Test(async (host) =>
        {
            Response response = await new SpreadClient(host, null).GetModelClient().SpreadCompositeRequestOnlyWithBodyAsync(new BodyParameter("foo"));
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Parameters_Spread_Model_spreadCompositeRequestOnlyWithoutBody() => Test(async (host) =>
        {
            Response response = await new SpreadClient(host, null).GetModelClient().SpreadCompositeRequestWithoutBodyAsync("foo", "bar");
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Parameters_Spread_Alias_spreadAsRequestBody() => Test(async (host) =>
        {
            Response response = await new SpreadClient(host, null).GetAliasClient().SpreadAsRequestBodyAsync("foo");
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Parameters_Spread_Alias_spreadAsRequestParameter() => Test(async (host) =>
        {
            Response response = await new SpreadClient(host, null).GetAliasClient().SpreadAsRequestParameterAsync("1", "bar", "foo");
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Parameters_Spread_Alias_spreadWithMultipleParameters() => Test(async (host) =>
        {
            Response response = await new SpreadClient(host, null).GetAliasClient().SpreadWithMultipleParametersAsync("1", "bar", "foo", new[] { 1, 2 }, 1, new[] {"foo", "bar"});
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Parameters_Spread_Alias_spreadWithModel() => Test(async (host) =>
        {
            Response response = await new SpreadClient(host, null).GetAliasClient().SpreadParameterWithInnerModelAsync("1", "bar", "foo");
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Parameters_Spread_Alias_spreadAliasinAlias() => Test(async (host) =>
        {
            Response response = await new SpreadClient(host, null).GetAliasClient().SpreadParameterWithInnerAliasAsync("1", "bar", "foo", 1);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public void SpreadAsRequestBodyInModel()
        {
            var expected = new[]
            {
                (typeof(string), "name", true),
            };
            ValidateConvenienceMethod(typeof(Model), "SpreadAsRequestBody", expected);
        }

        [Test]
        public void SpreadAsRequestBodyInAlias()
        {
            var expected = new[]
            {
                (typeof(string), "name", true),
            };
            ValidateConvenienceMethod(typeof(Alias), "SpreadAsRequestBody", expected);
        }

        [Test]
        public void SpreadParameterWithInnerModel()
        {
            var expected = new[]
            {
                (typeof(string), "id", true),
                (typeof(string), "xMsTestHeader", true),
                (typeof(string), "name", true),
            };
            ValidateConvenienceMethod(typeof(Alias), "SpreadParameterWithInnerModel", expected);
        }

        [Test]
        public void SpreadParameterWithInnerAlias()
        {
            var expected = new[]
            {
                (typeof(string), "id", true),
                (typeof(string), "xMsTestHeader", true),
                (typeof(string), "name", true),
                (typeof(int), "age", true)
            };
            ValidateConvenienceMethod(typeof(Alias), "SpreadParameterWithInnerAlias", expected);
        }

        private static void ValidateConvenienceMethod(Type clientType, string methodName, IEnumerable<(Type ParameterType, string Name, bool IsRequired)> expected)
        {
            var methods = FindMethods(clientType, methodName);

            foreach (var method in methods)
            {
                ValidateConvenienceMethodParameters(method, expected);
            }
        }

        private static IEnumerable<MethodInfo> FindMethods(Type clientType, string methodName)
        {
            var asyncMethodName = $"{methodName}Async";
            var methods = clientType.GetMethods();

            return methods.Where(m => m.Name.Equals(methodName) || m.Name.Equals(asyncMethodName));
        }

        private static void ValidateConvenienceMethodParameters(MethodInfo method, IEnumerable<(Type ParameterType, string Name, bool IsRequired)> expected)
        {
            if (IsProtocolMethod(method))
                return;
            var parameters = method.GetParameters().Where(p => !p.ParameterType.Equals(typeof(CancellationToken)));
            var parameterTypes = parameters.Select(p => p.ParameterType);
            var parameterNames = parameters.Select(p => p.Name);
            var parameterRequiredness = parameters.Select(p => !p.IsOptional);
            var expectedTypes = expected.Select(p => p.ParameterType);
            var expectedNames = expected.Select(p => p.Name);
            var expectedRequiredness = expected.Select(p => p.IsRequired);

            CollectionAssert.AreEqual(expectedTypes, parameterTypes);
            CollectionAssert.AreEqual(expectedNames, parameterNames);
            CollectionAssert.AreEqual(expectedRequiredness, parameterRequiredness);
        }

        private static bool IsProtocolMethod(MethodInfo method)
            => method.GetParameters().Any(parameter => parameter.ParameterType.Equals(typeof(RequestContent)));
    }
}
