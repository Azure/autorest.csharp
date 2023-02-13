using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Azure;
using Azure.ResourceManager.Resources;
using Humanizer;
using MgmtPropertyBag;
using MgmtPropertyBag.Models;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    public class MgmtPropertyBagTests : TestProjectTests
    {
        public MgmtPropertyBagTests() : base("MgmtPropertyBag") { }

        [TestCase("MgmtPropertyBagExtensions", "GetFoos", true, typeof(SubscriptionResource), typeof(string), typeof(int?))]
        [TestCase("MgmtPropertyBagExtensions", "GetBars", true, typeof(SubscriptionResource), typeof(ETag?), typeof(int?))]
        [TestCase("FooCollection", "CreateOrUpdate", true, typeof(WaitUntil), typeof(string), typeof(FooData), typeof(string), typeof(int?), typeof(string))]
        [TestCase("FooCollection", "Get", true, typeof(FooCollectionGetOptions))]
        [TestCase("FooCollection", "GetAll", true, typeof(FooCollectionGetAllOptions))]
        [TestCase("FooResource", "Get", true, typeof(string), typeof(int?), typeof(string), typeof(ETag?), typeof(int?))]
        [TestCase("FooResource", "Update", true, typeof(FooPatch))]
        [TestCase("FooResource", "Reconnect", true, typeof(FooReconnectTestOptions))]
        [TestCase("BarCollection", "CreateOrUpdate", true, typeof(WaitUntil), typeof(string), typeof(BarData), typeof(string), typeof(int?), typeof(ETag?))]
        [TestCase("BarCollection", "Get", true, typeof(BarCollectionGetOptions))]
        [TestCase("BarCollection", "GetAll", true, typeof(BarCollectionGetAllOptions))]
        [TestCase("BarResource", "Get", true, typeof(string), typeof(string), typeof(int?), typeof(string), typeof(int?))]
        [TestCase("BarResource", "Update", true, typeof(WaitUntil), typeof(BarData), typeof(string), typeof(int?), typeof(ETag?))]
        public void ValidatePropertyBag(string className, string methodName, bool exist, params Type[] parameterTypes)
        {
            var classesToCheck = FindAllCollections().Concat(FindAllResources()).Append(FindExtensionClass());
            var classToCheck = classesToCheck.First(t => t.Name == className);
            var methods = classToCheck.GetMethods().Where(t => t.Name == methodName).Where(m => ParameterMatch(m.GetParameters(), parameterTypes));
            Assert.AreEqual(exist, methods.Any(), $"can{(exist ? "not" : string.Empty)} find {className}.{methodName} with parameters {string.Join(", ", (IEnumerable<Type>)parameterTypes)}");
        }
    }
}
