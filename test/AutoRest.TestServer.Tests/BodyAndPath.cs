// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using Azure;
using Azure.Core;
using BodyAndPath;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class BodayAndPath
    {
        [Test]
        public void BodyParameterIsLast()
        {
            ParameterInfo[] parameters = typeof(BodyAndPathClient).GetMethod("Create").GetParameters();
            Assert.AreEqual(typeof(string), parameters[0].ParameterType);
            Assert.AreEqual(typeof(RequestContent), parameters[1].ParameterType);
            Assert.AreEqual(typeof(RequestOptions), parameters[2].ParameterType);
        }
    }
}
