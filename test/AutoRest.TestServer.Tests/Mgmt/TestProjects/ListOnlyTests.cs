using System;
using System.Linq;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    public class ListOnlyTests : TestProjectTests
    {
        public ListOnlyTests() : base("MgmtListOnly") { }

        // list-only + parent is resource -> extra method on [Parent]Operations
        // list-only + parent is not resource -> extra method on [armclient/sub/rg]Extensions

        [TestCase("AvailabilitySetOperations", "ListAvailabilitySetChild", true)]
        public void ValidateExtraMethodInParentOperations(string operation, string methodName, bool isExists)
        {
            Type parentOperations = FindAllOperations().First(o => o.Name == operation);
            Assert.AreEqual(isExists, parentOperations.GetMethod(methodName) != null, $"Could not find {operation}.{methodName}. Found: {string.Join(", ", parentOperations.GetMethods().Select(m => m.Name))}");
        }

        public void ValidateExtraMethodInExtensionClasses()
        {
        }
    }
}
