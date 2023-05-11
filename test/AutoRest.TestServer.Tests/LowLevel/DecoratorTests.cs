// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ModelsInCadl.Models;
using NUnit.Framework;
using AutoRest.TestServer.Tests.Infrastructure;
using System;
using AutoRest.CSharp.Mgmt.Decorator;
using System.Reflection;
using ModelsInCadl;
using System.Linq;

namespace AutoRest.LowLevel.Tests
{
    public class DecoratorTests
    {
        [Test]
#pragma warning disable CS0618
        public void DeprecateDataTypes([Values(
            typeof(RoundTripOptionalModel),
            typeof(FixedIntEnum),
            typeof(ExtensibleEnum)
            )] Type type)
#pragma warning restore CS0618
        {
            var attribute = type.GetCustomAttribute(typeof(ObsoleteAttribute));
            Assert.IsNotNull(attribute);
            Assert.AreEqual("deprecated for test", ((ObsoleteAttribute)attribute).Message);
        }

        [TestCase(typeof(ModelsInCadlClient), "InputToRoundTripReadOnly")]
        public void DeprecatedOperations(Type client, string operationBaseName)
        {
            var methods = client.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            Assert.AreEqual(4, methods.Where(m =>
            {
                if (m.Name == operationBaseName || m.Name == (operationBaseName + "Async"))
                {

                    var attribute = m.GetCustomAttribute(typeof(ObsoleteAttribute));
                    if (attribute is ObsoleteAttribute obsoleteAttribute)
                    {
                        if (obsoleteAttribute.Message == "deprecated for test")
                        {
                            return true;
                        }
                    };
                }
                return false;
            }).Count());
        }
    }
}
