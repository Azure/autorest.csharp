using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    public class MgmtListMethods : TestProjectTests
    {
        public MgmtListMethods() : base("MgmtListMethods") { }

        [TestCase("TheExtensionContainer", "GetUsages", false)]
        [TestCase("TheExtensionContainer", "GetFeatures", false)]
        [TestCase("TheExtensionOperations", "GetUsages", true)]
        [TestCase("TheExtensionOperations", "GetFeatures", true)]
        [TestCase("TheExtensionFakeContainer", "GetUsages", false)]
        [TestCase("TheExtensionFakeContainer", "GetFeatures", false)]
        [TestCase("TheExtensionFakeOperations", "GetUsages", true)]
        [TestCase("TheExtensionFakeOperations", "GetFeatures", true)]
        [TestCase("SubscriptionExtensions", "GetFakes", true)]
        [TestCase("FakeContainer", "GetFakes", false)]
        [TestCase("FakeOperations", "GetFakes", false)]
        [TestCase("SubscriptionExtensions", "GetFakesByLocation", true)]
        [TestCase("FakeContainer", "GetFakesByLocation", false)]
        [TestCase("FakeOperations", "GetFakesByLocation", false)]
        [TestCase("SubscriptionExtensions", "GetAll", false)]
        [TestCase("SubFakeContainer", "GetAll", true)]
        [TestCase("SubFakeOperations", "GetAll", false)]
        [TestCase("SubscriptionExtensions", "GetAll", false)]
        [TestCase("FakeOperations", "GetAll", false)]
        [TestCase("SubscriptionExtensions", "GetBars", true)]
        [TestCase("SharedGalleryContainer", "GetAll", true)]
        [TestCase("SharedGalleryOperations", "GetAll", false)]
        public void ValidateListMethods(string className, string methodName, bool exist)
        {
            var subscriptionExtensions = Assembly.GetExecutingAssembly().GetType("MgmtListMethods.SubscriptionExtensions");
            var classesToCheck = FindAllContainers().Concat(FindAllOperations()).Append(subscriptionExtensions);
            var classToCheck = classesToCheck.First(t => t.Name == className);
            Assert.AreEqual(exist, classToCheck.GetMethod(methodName) != null, $"can{(exist ? "not" : string.Empty)} find {className}.{methodName}");
        }

        [TestCase("FakeContainer", "GetAll")]
        public void ValidateListOverloadMethods(string className, string methodName)
        {
            var classToCheck = Assembly.GetExecutingAssembly().GetType("MgmtListMethods.FakeContainer");

            var method1 = classToCheck.GetMethod(methodName, new Type[] { typeof(string), typeof(string), typeof(CancellationToken) });
            Assert.NotNull(method1);
            var method2 = classToCheck.GetMethod(methodName, new Type[] { typeof(CancellationToken) });
            Assert.NotNull(method2);
        }
    }
}
