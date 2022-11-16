using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Azure;
using Azure.ResourceManager.Resources;
using MgmtPropertyBag;
using MgmtPropertyBag.Models;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    public class MgmtPropertyBagTests : TestProjectTests
    {
        public MgmtPropertyBagTests() : base("MgmtPropertyBag") { }

        [TestCase("MgmtPropertyBagExtensions", "GetFoos", true, typeof(SubscriptionResource), typeof(string), typeof(int?))]
        [TestCase("MgmtPropertyBagExtensions", "GetBars", true, typeof(SubscriptionResource), typeof(string), typeof(int?))]
        [TestCase("FooCollection", "CreateOrUpdate", true, typeof(WaitUntil), typeof(string), typeof(FooData), typeof(FooCreateOrUpdateOptions))]
        [TestCase("FooCollection", "Get", true, typeof(string), typeof(FooGetOptions))]
        [TestCase("FooCollection", "GetAll", true, typeof(FooGetAllOptions))]
        [TestCase("FooResource", "Get", true, typeof(FooGetOptions))]
        [TestCase("FooResource", "Update", true, typeof(WaitUntil), typeof(FooData), typeof(FooCreateOrUpdateOptions))]
        [TestCase("FooResource", "Reconnect", true, typeof(FooReconnectTestOptions), typeof(FooData))]
        [TestCase("BarCollection", "CreateOrUpdate", true, typeof(WaitUntil), typeof(string), typeof(BarCreateOrUpdateOptions), typeof(BarData))]
        [TestCase("BarCollection", "Get", true, typeof(string), typeof(BarGetOptions))]
        [TestCase("BarCollection", "GetAll", true, typeof(BarGetAllOptions))]
        [TestCase("BarResource", "Get", true, typeof(BarGetOptions))]
        [TestCase("BarResource", "Update", true, typeof(WaitUntil), typeof(BarCreateOrUpdateOptions), typeof(BarData))]
        public void ValidatePropertyBag(string className, string methodName, bool exist, params Type[] parameterTypes)
        {
            var classesToCheck = FindAllCollections().Concat(FindAllResources()).Append(FindExtensionClass());
            var classToCheck = classesToCheck.First(t => t.Name == className);
            var methods = classToCheck.GetMethods().Where(t => t.Name == methodName).Where(m => ParameterMatch(m.GetParameters(), parameterTypes));
            Assert.AreEqual(exist, methods.Any(), $"can{(exist ? "not" : string.Empty)} find {className}.{methodName} with parameters {string.Join(", ", (IEnumerable<Type>)parameterTypes)}");
        }
    }
}
