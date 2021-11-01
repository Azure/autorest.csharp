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
            Assert.AreEqual(typeof(RequestContext), parameters[2].ParameterType);
        }

        [Test]
        public void ContentTypeParameterIsAfterBodyParameter()
        {
            ParameterInfo[] parameters = typeof(BodyAndPathClient).GetMethod("CreateStream").GetParameters();
            Assert.AreEqual(typeof(string), parameters[0].ParameterType);
            Assert.AreEqual(typeof(RequestContent), parameters[1].ParameterType);
            Assert.AreEqual(typeof(ContentType), parameters[2].ParameterType);
        }

        [Test]
        public void ListMethodsRenamed()
        {
            MethodInfo? m1 = typeof(BodyAndPathClient).GetMethod("GetBodyAndPaths");
            MethodInfo? m2 = typeof(BodyAndPathClient).GetMethod("GetBodyAndPathsAsync");
            MethodInfo? m3 = typeof(BodyAndPathClient).GetMethod("GetItems");
            MethodInfo? m4 = typeof(BodyAndPathClient).GetMethod("GetItemsAsync");
            MethodInfo? m5 = typeof(BodyAndPathClient).GetMethod("List");
            MethodInfo? m6 = typeof(BodyAndPathClient).GetMethod("ListItems");
            Assert.IsNotNull(m1);
            Assert.IsNotNull(m2);
            Assert.IsNotNull(m3);
            Assert.IsNotNull(m4);
            Assert.IsNull(m5);
            Assert.IsNull(m6);
        }
    }
}
