using System.Linq;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    public class MgmtListOnlyTests : TestProjectTests
    {
        public MgmtListOnlyTests() : base("MgmtListOnly") { }

        // list-only + parent is resource -> extra method on [Parent]Operations
        // list-only + parent is not resource -> extra method on [armclient/sub/rg]Extensions

        [TestCase("FakeOperations", "ListFakeBars", true)]
        [TestCase("FakeOperations", "CreateOrUpdateChildWithPost", true)]
        public void ValidateExtraMethodInParentOperations(string operation, string methodName, bool exist)
        {
            var parentOperations = FindAllOperations().First(o => o.Name == operation);
            Assert.AreEqual(exist, parentOperations.GetMethod(methodName) != null, $"Could not find {operation}.{methodName}. Found: {string.Join(", ", parentOperations.GetMethods().Select(m => m.Name))}");
        }

        [TestCase("ListFakeFeaturesAsync", true)]
        [TestCase("ListFakeNonPageableFeaturesAsync", true)]
        public void ValidateExtraMethodInExtensionClasses(string methodName, bool exist)
        {
            var subscriptionExtension = FindSubscriptionExtensions();
            Assert.NotNull(subscriptionExtension);
            Assert.AreEqual(exist, subscriptionExtension.GetMethod(methodName) != null, $"Could not find SubscriptionExtensions.{methodName}. Found: {string.Join(", ", subscriptionExtension.GetMethods().Select(m => m.Name))}");
        }

        /// <summary>
        /// When the operation group is non-resource but also not list-only, e.g. it has a POST method,
        /// if in configuration it is marked as non-resource,
        /// its methods should be generated to its parent.
        /// </summary>
        [TestCase("ListApiKeys", true)]
        [TestCase("ListApiKeysAsync", true)]
        public void ValidateNonResourceButNotListOnly(string methodName, bool exist)
        {
            ValidateExtraMethodInExtensionClasses(methodName, exist);
        }
    }
}
