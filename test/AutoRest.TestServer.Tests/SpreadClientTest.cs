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
    }
}
