// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using Azure.Core;
using BodyAndPath_LowLevel;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class BodayAndPathTest
    {
        [Test]
        public void BodyParameterIsLast()
        {
            ParameterInfo[] parameters = typeof(BodyAndPathClient).GetMethod("Create").GetParameters();
            Assert.AreEqual(typeof(string), parameters[0].ParameterType);
            Assert.AreEqual(typeof(RequestContent), parameters[1].ParameterType);
            Assert.AreEqual(typeof(RequestOptions), parameters[2].ParameterType);
        }

        [Test]
        public void ContentTypeParameterIsAfterBodyParameter()
        {
            ParameterInfo[] parameters = typeof(BodyAndPathClient).GetMethod("CreateStream").GetParameters();
            Assert.AreEqual(typeof(string), parameters[0].ParameterType);
            Assert.AreEqual(typeof(RequestContent), parameters[1].ParameterType);
            Assert.AreEqual(typeof(ContentType), parameters[2].ParameterType);
        }
    }
}
