// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Parameters_LowLevel;
using ParametersCadl;
using NUnit.Framework;
using Azure.Core;
using Azure;
using System.Threading;
using System.Reflection;

namespace AutoRest.LowLevel.Tests
{
    public class ParameterSequenceTests
    {
        [TestCase(typeof(ParametersLowlevelClient), "OptionalPathParameters", new Type[] { typeof(int), typeof(string), typeof(int), typeof(RequestContext) }, new string[] { "id", "name", "skip", "context" }, new bool[] { false, false, false, true })]
        [TestCase(typeof(ParametersLowlevelClient), "OptionalPathParametersWithMixedSequence", new Type[] { typeof(int), typeof(string), typeof(int), typeof(RequestContext) }, new string[] { "id", "name", "skip", "context" }, new bool[] { false, false, false, true })]
        [TestCase(typeof(ParametersLowlevelClient), "OptionalPathBodyParametersWithMixedSequence", new Type[] { typeof(int), typeof(string), typeof(int), typeof(int), typeof(RequestContent), typeof(int), typeof(RequestContext) }, new string[] { "id", "name", "skip", "max", "content", "top", "context" }, new bool[] { false, false, false, false, false, true, true })]
        public void OptionalParameterAtEnd(Type type, string methodName, Type[] types, string[] parameterNames, bool[] isOptional)
        {
            var method = type.GetMethod(methodName, types);
            Assert.AreEqual(parameterNames, method.GetParameters().Select(p => p.Name).ToArray());
            Assert.AreEqual(isOptional, method.GetParameters().Select(p => p.HasDefaultValue).ToArray());
        }

        [Test]
        public void RepeatabilityHeadersNotInMethodSignature()
        {
            foreach (var m in typeof(ParametersLowlevelClient).GetMethods(BindingFlags.Public | BindingFlags.Instance).Where(m => m.Name.StartsWith("RepeatableAction")))
            {
                Assert.False(m.GetParameters().Any(p => p.Name == "repeatabilityRequestId" || p.Name == "repeatabilityFirstSent"));
            }
        }
    }
}
