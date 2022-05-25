// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Reflection;
using NUnit.Framework;
using AmbiguousMethods_LowLevel;
using FlattenedParameters;

namespace AutoRest.TestServer.Tests
{

    public class AmbiguousMethodsTests
    {
        [Test]
        public void AllParametersInAmbiguousMethodsShouldBeRequired()
        {
            var type = (typeof(AmbiguousClient));
            var dpgMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public).Where(m => m.Name.Contains("Param") &&
                m.GetParameters().Last().ParameterType.Name == "RequestContext").ToArray();

            Assert.IsTrue(dpgMethods.Count() > 0);
            Assert.IsTrue(dpgMethods.All(m => m.GetParameters().All(p => !p.IsOptional)));
        }

        [TestCase("NoParam", 0, 0)]
        [TestCase("OneOptionalParam", 0, 1)]
        [TestCase("TwoOptionalParam", 0, 2)]
        [TestCase("OneRequiredParam", 1, 0)]
        [TestCase("OneRequiredParamAndOneOptionalParam", 1, 1)]
        [TestCase("OneRequiredParamAndTwoOptionalParam", 1, 2)]
        [TestCase("TwoRequiredParam", 2, 0)]
        [TestCase("TwoRequiredParamAndOneOptionalParam", 2, 1)]
        [TestCase("TwoRequiredParamAndTwoOptionalParam", 2, 2)]
        public void AllParametersInUnambigousMethodsShouldRemainUnchanged(string methodBaseName, int requiredParamCount, int optionalParamCount)
        {
            var type = (typeof(UnambiguousClient));
            var dpgMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public).Where(m => (m.Name == methodBaseName || m.Name == $"{methodBaseName}Async") &&
                m.GetParameters().Last().ParameterType.Name == "RequestContext").ToArray();

            Assert.IsTrue(dpgMethods.Count() > 0);
            Assert.IsTrue(dpgMethods.All(m => m.GetParameters().Where(p => !p.IsOptional).Count() == requiredParamCount));
            Assert.IsTrue(dpgMethods.All(m => m.GetParameters().Where(p => p.IsOptional).Count() == optionalParamCount + 1));// tailing RequestContext
        }
    }
}
