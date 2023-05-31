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
using Parameters_LowLevel.Models;
using AutoRest.CSharp.Utilities;

namespace AutoRest.LowLevel.Tests
{
    public class ParameterTests
    {
        [TestCase(typeof(ParametersLowlevelClient), "OptionalPathParameters", new Type[] { typeof(int), typeof(int), typeof(string), typeof(RequestContext) }, new string[] { "id", "skip", "name", "context" }, new bool[] { false, false, true, true })]
        [TestCase(typeof(ParametersLowlevelClient), "OptionalPathParametersWithMixedSequence", new Type[] { typeof(int), typeof(string), typeof(int), typeof(RequestContext) }, new string[] { "id", "name", "skip", "context" }, new bool[] { false, true, true, true })]
        [TestCase(typeof(ParametersLowlevelClient), "OptionalPathBodyParametersWithMixedSequence", new Type[] { typeof(string), typeof(int), typeof(RequestContent), typeof(int), typeof(int), typeof(int), typeof(RequestContext) }, new string[] { "name", "skip", "content", "id", "top", "max", "context" }, new bool[] { false, false, false, true, true, true, true })]
        [TestCase(typeof(ParametersLowlevelClient), "GroupParametersWithRequiredBody", new Type[] { typeof(GroupParametersWithRequiredBodyOptions), typeof(RequestContext) }, new string[] { "options", "context" }, new bool[] { false, true })]
        [TestCase(typeof(ParametersLowlevelClient), "GroupParametersWithOptionalBody", new Type[] { typeof(GroupParametersWithOptionalBodyOptions), typeof(RequestContext) }, new string[] { "options", "context" }, new bool[] { false, true })]
        [TestCase(typeof(ParametersCadlClient), "Operation", new Type[] { typeof(int), typeof(int), typeof(CancellationToken) }, new string[] { "start", "end", "cancellationToken" }, new bool[] { false, true, true })]
        [TestCase(typeof(ParametersCadlClient), "Operation", new Type[] { typeof(int), typeof(int), typeof(RequestContext) }, new string[] { "start", "end", "context" }, new bool[] { false, false, false })]
        [TestCase(typeof(ParametersCadlClient), "Operation2", new Type[] { typeof(int), typeof(int), typeof(CancellationToken) }, new string[] { "end", "start", "cancellationToken" }, new bool[] { false, true, true })]
        [TestCase(typeof(ParametersCadlClient), "Operation2", new Type[] { typeof(int), typeof(int), typeof(RequestContext) }, new string[] { "end", "start", "context" }, new bool[] { false, false, false })]
        public void OptionalParameterAtEnd(Type type, string methodName, Type[] types, string[] parameterNames, bool[] isOptional)
        {
            var method = type.GetMethod(methodName, types);
            Assert.AreEqual(parameterNames, method.GetParameters().Select(p => p.Name).ToArray());
            Assert.AreEqual(isOptional, method.GetParameters().Select(p => p.HasDefaultValue).ToArray());
        }

        [TestCase(typeof(GroupParametersWithRequiredBodyOptions), new string[] { "Name", "Skip", "Content" }, new string[] { "Id", "Top", "Max" })]
        [TestCase(typeof(GroupParametersWithOptionalBodyOptions), new string[] { "Name", "Skip" }, new string[] { "Content", "Id", "Top", "Max" })]
        public void PropertyBag(Type propertyBagType, string[] requiredPropertyNames, string[] optionalPropertyNames)
        {
            var properties = propertyBagType.GetProperties();

            Assert.AreEqual(properties.Length, requiredPropertyNames.Length + optionalPropertyNames.Length);

            var constructorParameters = propertyBagType.GetConstructors()[0].GetParameters().Select(p => p.Name);
            CollectionAssert.AreEqual(constructorParameters, requiredPropertyNames.Select(n => n.FirstCharToLowerCase()));

            foreach (var name in requiredPropertyNames)
            {
                Assert.IsNotNull(propertyBagType.GetProperty(name));
            }
            foreach (var name in optionalPropertyNames)
            {
                Assert.IsNotNull(propertyBagType.GetProperty(name));
            }
        }
    }
}
