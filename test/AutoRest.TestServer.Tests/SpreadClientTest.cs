// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using Azure.Core;
using NUnit.Framework;
using Spread;
using Spread.Models;

namespace AutoRest.TestServer.Tests
{
    public class SpreadClientTest
    {
        [Test]
        public void SpreadModelMethod()
        {
            var expected = new[]
            {
                (typeof(Thing), "thing")
            };
            ValidateConvenienceMethod(typeof(SpreadClient), "SpreadModel", expected);
        }

        [Test]
        public void SpreadAliasMethod()
        {
            var expected = new[]
            {
                (typeof(string), "name"),
                (typeof(int), "age")
            };
            ValidateConvenienceMethod(typeof(SpreadClient), "SpreadAlias", expected);
        }

        [Test]
        public void SpreadMultiTargetAliasMethod()
        {
            var expected = new[]
            {
                (typeof(string), "id"),
                (typeof(int), "top"),
                (typeof(string), "name"),
                (typeof(int), "age")
            };
            ValidateConvenienceMethod(typeof(SpreadClient), "SpreadMultiTargetAlias", expected);
        }

        [Test]
        public void SpreadAliasWithModelMethod()
        {
            var expected = new[]
            {
                (typeof(string), "id"),
                (typeof(int), "top"),
                (typeof(Thing), "thing")
            };
            ValidateConvenienceMethod(typeof(SpreadClient), "SpreadAliasWithModel", expected);
        }

        [Test]
        public void SpreadAliasWithSpreadAliasMethod()
        {
            var expected = new[]
            {
                (typeof(string), "id"),
                (typeof(int), "top"),
                (typeof(string), "name"),
                (typeof(int), "age")
            };
            ValidateConvenienceMethod(typeof(SpreadClient), "SpreadAliasWithSpreadAlias", expected);
        }

        [Test]
        public void SpreadAliasWithOptionalPropsMethod()
        {
            var expected = new[]
            {
                (typeof(string), "id"),
                (typeof(int), "top"),
                (typeof(string), "name"),
                (typeof(string), "color"),
                (typeof(int?), "age"),
                (typeof(IEnumerable<int>), "items"),
                (typeof(IEnumerable<string>), "elements")
            };
            ValidateConvenienceMethod(typeof(SpreadClient), "SpreadAliasWithOptionalProps", expected);
        }

        private static void ValidateConvenienceMethod(Type clientType, string methodName, IEnumerable<(Type ParameterType, string Name)> expected)
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

        private static void ValidateConvenienceMethodParameters(MethodInfo method, IEnumerable<(Type ParameterType, string Name)> expected)
        {
            if (IsProtocolMethod(method))
                return;
            var parameters = method.GetParameters().Where(p => !p.ParameterType.Equals(typeof(CancellationToken)));
            var parameterTypes = parameters.Select(p => p.ParameterType);
            var parameterNames = parameters.Select(p => p.Name);
            var expectedTypes = expected.Select(p => p.ParameterType);
            var expectedNames = expected.Select(p => p.Name);

            CollectionAssert.AreEquivalent(expectedTypes, parameterTypes);
            CollectionAssert.AreEquivalent(expectedNames, parameterNames);
        }

        private static bool IsProtocolMethod(MethodInfo method)
            => method.GetParameters().Any(parameter => parameter.ParameterType.Equals(typeof(RequestContent)));
    }
}
