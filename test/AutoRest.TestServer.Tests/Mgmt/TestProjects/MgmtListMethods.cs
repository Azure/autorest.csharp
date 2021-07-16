using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    public class MgmtListMethods : TestProjectTests
    {
        public MgmtListMethods() : base("MgmtListMethods") { }

        [TestCase("TheExtensionContainer", "ListUsages", false)]
        [TestCase("TheExtensionContainer", "ListFeatures", false)]
        [TestCase("TheExtensionOperations", "ListUsages", true)]
        [TestCase("TheExtensionOperations", "ListFeatures", true)]
        [TestCase("TheExtensionFakeContainer", "ListUsages", false)]
        [TestCase("TheExtensionFakeContainer", "ListFeatures", false)]
        [TestCase("TheExtensionFakeOperations", "ListUsages", true)]
        [TestCase("TheExtensionFakeOperations", "ListFeatures", true)]
        [TestCase("SubscriptionExtensions", "ListFakes", true)]
        [TestCase("FakeContainer", "ListFakes", false)]
        [TestCase("FakeOperations", "ListFakes", false)]
        public void ValidateListOfNonResourceMethod(string className, string methodName, bool exist)
        {
            var subscriptionExtensions = Assembly.GetExecutingAssembly().GetType("MgmtListMethods.SubscriptionExtensions");
            var classesToCheck = FindAllContainers().Concat(FindAllOperations()).Append(subscriptionExtensions);
            var classToCheck = classesToCheck.First(t => t.Name == className);
            Assert.AreEqual(exist, classToCheck.GetMethod(methodName) != null, $"can{(exist ? "not" : string.Empty)} find {className}.{methodName}");
        }
    }
}
