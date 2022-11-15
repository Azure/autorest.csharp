// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Parameters_LowLevel;
using ParametersCadl;
using NUnit.Framework;

namespace AutoRest.LowLevel.Tests
{
    public class ParameterSequenceTests
    {
        [TestCase(typeof(ParametersLowlevelClient), "OptionalPathParameters", new string[] { "id", "skip", "name", "context" }, new bool[] { false, false, true, true})]
        [TestCase(typeof(ParametersLowlevelClient),"OptionalPathParametersWithMixedSequence", new string[] { "id", "name", "skip", "context" }, new bool[] { false, true, true, true})]
        [TestCase(typeof(ParametersLowlevelClient),"OptionalPathBodyParametersWithMixedSequence", new string[] { "name", "skip", "content", "id", "top", "max", "context" }, new bool[] { false, false, false, true, true, true, true})]
        [TestCase(typeof(ParametersCadlClient),"OperationValue", new string[] { "start", "end", "cancellationToken" }, new bool[] { false, true, true})]
        [TestCase(typeof(ParametersCadlClient),"Operation", new string[] { "start", "end", "context" }, new bool[] { false, true, true})]
        [TestCase(typeof(ParametersCadlClient),"Operation2Value", new string[] { "end", "start", "cancellationToken" }, new bool[] { false, true, true})]
        [TestCase(typeof(ParametersCadlClient),"Operation2", new string[] { "end", "start", "context" }, new bool[] { false, true, true})]
        public void OptionalParameterAtEnd(Type type, string methodName, string[] parameterNames, bool[] isOptional)
        {
            var method = type.GetMethod(methodName);
            Assert.AreEqual(parameterNames, method.GetParameters().Select(p => p.Name).ToArray());
            Assert.AreEqual(isOptional, method.GetParameters().Select(p => p.HasDefaultValue).ToArray());
        }
    }
}
