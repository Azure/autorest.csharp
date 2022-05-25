﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Azure.ResourceManager.Resources;
using MgmtPropertyBag.Models;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    public class MgmtPropertyBagTests : TestProjectTests
    {
        public MgmtPropertyBagTests() : base("MgmtPropertyBag") { }

        [TestCase("MgmtPropertyBagExtensions", "GetWithSubscriptionBars", true, typeof(SubscriptionResource), typeof(BarGetWithSubscriptionOptions))]
        [TestCase("MgmtPropertyBagExtensions", "GetFoos", true, typeof(ResourceGroupResource), typeof(FooGetFoosOptions))]
        [TestCase("MgmtPropertyBagExtensions", "GetBars", true, typeof(ResourceGroupResource), typeof(string))]
        public void ValidatePropertyBag(string className, string methodName, bool exist, params Type[] parameterTypes)
        {
            var classesToCheck = FindAllCollections().Concat(FindAllResources()).Append(FindExtensionClass());
            var classToCheck = classesToCheck.First(t => t.Name == className);
            var methods = classToCheck.GetMethods().Where(t => t.Name == methodName).Where(m => ParameterMatch(m.GetParameters(), parameterTypes));
            Assert.AreEqual(exist, methods.Any(), $"can{(exist ? "not" : string.Empty)} find {className}.{methodName} with parameters {string.Join(", ", (IEnumerable<Type>)parameterTypes)}");
        }
    }
}
