// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using System.Linq;
using NUnit.Framework;
using Spread;
using System;

namespace AutoRest.TestServer.Tests
{
    public class SpreadClientTest
    {
        [Test]
        public void SpreadModelMethod()
        {
            var methods = typeof(SpreadClient).GetMethods();
            var spreadMethods = methods.Where(m => m.Name.Equals("SpreadModel"));
            foreach (var method in spreadMethods)
            {
                var parameters = method.GetParameters();
                Assert.AreEqual(2, parameters.Length);
                if (parameters[0].ParameterType.Name.Equals("RequestContent"))
                    continue;
                Assert.AreEqual("Thing", parameters[0].ParameterType.Name);
            }

            var spreadAsyncMethods = methods.Where(m => m.Name.Equals("SpreadModelAsync"));
            foreach (var method in spreadAsyncMethods)
            {
                var parameters = method.GetParameters();
                Assert.AreEqual(2, parameters.Length);
                if (parameters[0].ParameterType.Name.Equals("RequestContent"))
                    continue;
                Assert.AreEqual("Thing", parameters[0].ParameterType.Name);
            }
        }

        [Test]
        public void SpreadAliasMethod()
        {
            var methods = typeof(SpreadClient).GetMethods();
            var spreadMethods = methods.Where(m => m.Name.Equals("SpreadAlias"));
            foreach (var method in spreadMethods)
            {
                var parameters = method.GetParameters();
                Assert.GreaterOrEqual(parameters.Length, 2);
                if (parameters[0].ParameterType.Name.Equals("RequestContent"))
                    continue;
                Assert.AreEqual("String", parameters[0].ParameterType.Name);
                Assert.AreEqual("name", parameters[0].Name);
                Assert.AreEqual("Int32", parameters[1].ParameterType.Name);
                Assert.AreEqual("age", parameters[1].Name);
            }

            var spreadAsyncMethods = methods.Where(m => m.Name.Equals("SpreadAliasAsync"));
            foreach (var method in spreadAsyncMethods)
            {
                var parameters = method.GetParameters();
                Assert.GreaterOrEqual(parameters.Length, 2);
                if (parameters[0].ParameterType.Name.Equals("RequestContent"))
                    continue;
                Assert.AreEqual("String", parameters[0].ParameterType.Name);
                Assert.AreEqual("name", parameters[0].Name);
                Assert.AreEqual("Int32", parameters[1].ParameterType.Name);
                Assert.AreEqual("age", parameters[1].Name);
            }
        }
        [Test]
        public void SpreadMultiTargetAliasMethod()
        {
            var methods = typeof(SpreadClient).GetMethods();
            var spreadMethods = methods.Where(m => m.Name.Equals("SpreadMultiTargetAlias"));
            foreach (var method in spreadMethods)
            {
                var parameters = method.GetParameters();
                Assert.GreaterOrEqual(parameters.Length, 4);
                if (parameters[2].ParameterType.Name.Equals("RequestContent"))
                    continue;
                Assert.AreEqual("String", parameters[0].ParameterType.Name);
                Assert.AreEqual("id", parameters[0].Name);
                Assert.AreEqual("Int32", parameters[1].ParameterType.Name);
                Assert.AreEqual("top", parameters[1].Name);
                Assert.AreEqual("String", parameters[2].ParameterType.Name);
                Assert.AreEqual("name", parameters[2].Name);
                Assert.AreEqual("Int32", parameters[3].ParameterType.Name);
                Assert.AreEqual("age", parameters[3].Name);
            }

            var spreadAsyncMethods = methods.Where(m => m.Name.Equals("SpreadMultiTargetAliasAsync"));
            foreach (var method in spreadAsyncMethods)
            {
                var parameters = method.GetParameters();
                Assert.GreaterOrEqual(parameters.Length, 4);
                if (parameters[2].ParameterType.Name.Equals("RequestContent"))
                    continue;
                Assert.AreEqual("String", parameters[0].ParameterType.Name);
                Assert.AreEqual("id", parameters[0].Name);
                Assert.AreEqual("Int32", parameters[1].ParameterType.Name);
                Assert.AreEqual("top", parameters[1].Name);
                Assert.AreEqual("String", parameters[2].ParameterType.Name);
                Assert.AreEqual("name", parameters[2].Name);
                Assert.AreEqual("Int32", parameters[3].ParameterType.Name);
                Assert.AreEqual("age", parameters[3].Name);
            }
        }

        [Test]
        public void SpreadAliasWithModelMethod()
        {
            var methods = typeof(SpreadClient).GetMethods();
            var spreadMethods = methods.Where(m => m.Name.Equals("SpreadAliasWithModel"));
            foreach (var method in spreadMethods)
            {
                var parameters = method.GetParameters();
                Assert.AreEqual(parameters.Length, 4);
                if (parameters[2].ParameterType.Name.Equals("RequestContent"))
                    continue;
                Assert.AreEqual("String", parameters[0].ParameterType.Name);
                Assert.AreEqual("id", parameters[0].Name);
                Assert.AreEqual("Int32", parameters[1].ParameterType.Name);
                Assert.AreEqual("top", parameters[1].Name);
                Assert.AreEqual("Thing", parameters[2].ParameterType.Name);
            }

            var spreadAsyncMethods = methods.Where(m => m.Name.Equals("SpreadAliasWithModelAsync"));
            foreach (var method in spreadAsyncMethods)
            {
                var parameters = method.GetParameters();
                Assert.GreaterOrEqual(parameters.Length, 4);
                if (parameters[2].ParameterType.Name.Equals("RequestContent"))
                    continue;
                Assert.AreEqual("String", parameters[0].ParameterType.Name);
                Assert.AreEqual("id", parameters[0].Name);
                Assert.AreEqual("Int32", parameters[1].ParameterType.Name);
                Assert.AreEqual("top", parameters[1].Name);
                Assert.AreEqual("Thing", parameters[2].ParameterType.Name);
            }
        }
    }
}
