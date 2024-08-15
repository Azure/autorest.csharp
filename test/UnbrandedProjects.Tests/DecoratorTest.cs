// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using OpenAI;
using OpenAI.Models;

namespace UnbrandedProjects.Tests
{

    public class DecoratorTest
    {
        [Test]
#pragma warning disable CS0618
        public void DeprecateDataTypes([Values(
            typeof(FineTune)
            )] Type type)
#pragma warning restore CS0618
        {
            var attribute = type.GetCustomAttribute(typeof(ObsoleteAttribute));
            Assert.IsNotNull(attribute);
            Assert.AreEqual("deprecated", ((ObsoleteAttribute)attribute).Message);
        }

        [TestCase(typeof(Edits), "Create")]
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
                        if (obsoleteAttribute.Message == "deprecated")
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
