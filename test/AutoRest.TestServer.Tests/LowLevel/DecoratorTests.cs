// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Reflection;
using ModelsTypeSpec;
using ModelsTypeSpec.Models;
using NUnit.Framework;

namespace AutoRest.LowLevel.Tests
{
    public class DecoratorTests
    {
        [Test]
#pragma warning disable CS0618
        public void DeprecateDataTypes([Values(
            typeof(FixedIntEnum),
            typeof(ExtensibleEnum)
            )] Type type)
#pragma warning restore CS0618
        {
            var attribute = type.GetCustomAttribute(typeof(ObsoleteAttribute));
            Assert.IsNotNull(attribute);
            Assert.AreEqual("deprecated for test", ((ObsoleteAttribute)attribute).Message);
        }
    }
}
