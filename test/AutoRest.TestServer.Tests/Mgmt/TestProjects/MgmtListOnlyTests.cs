using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    public class MgmtListOnlyTests : TestProjectTests
    {
        public MgmtListOnlyTests() : base("MgmtListOnly") { }

        // list-only + parent is resource -> extra method on [Parent]Operations
        // list-only + parent is not resource -> extra method on [armclient/sub/rg]Extensions

        [TestCase("AvailabilitySetOperations", "ListAvailabilitySetChild", true)]
        public void ValidateExtraMethodInParentOperations(string operation, string methodName, bool isExists)
        {
            var parentOperations = FindAllOperations().First(o => o.Name == operation);
            Assert.AreEqual(isExists, parentOperations.GetMethod(methodName) != null, $"Could not find {operation}.{methodName}. Found: {string.Join(", ", parentOperations.GetMethods().Select(m => m.Name))}");
        }

        [TestCase("ListAvailabilitySetFeatureAsync", true)]
        public void ValidateExtraMethodInExtensionClasses(string methodName, bool isExists)
        {
            var subscriptionExtension = GetSubscriptionExtensions();
            Assert.NotNull(subscriptionExtension);
            Assert.AreEqual(isExists, subscriptionExtension.GetMethod(methodName) != null, $"Could not find SubscriptionExtensions.{methodName}. Found: {string.Join(", ", subscriptionExtension.GetMethods().Select(m => m.Name))}");
        }
    }
}
