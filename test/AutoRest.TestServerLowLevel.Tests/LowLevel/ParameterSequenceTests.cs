// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using Parameters_LowLevel;
using NUnit.Framework;

namespace AutoRest.LowLevel.Tests
{
    public class ParameterSequenceTests
    {
        [TestCase("OptionalParameters", new string[] { "id", "skip", "name", "context" }, new bool[] { false, false, true, true})]
        [TestCase("OptionalParametersWithMixedSequence", new string[] { "id", "name", "skip", "context" }, new bool[] { false, true, true, true})]
        public void OptionalParameterAtEnd(string methodName, string[] parameterNames)
        {
            var method = typeof(ParametersLowlevelClient).GetMethod(methodName);
            Assert.AreEqual(parameterNames, method.GetParameters().Select(p => p.Name).ToArray());
            method.GetParameters().Select(p => p.HasDefaultValue).ToArray();
        }
    }
}
