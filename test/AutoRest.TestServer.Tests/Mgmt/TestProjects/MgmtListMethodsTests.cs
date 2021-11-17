using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    public class MgmtListMethodsTests : TestProjectTests
    {
        public MgmtListMethodsTests() : base("MgmtListMethods") { }

        // Added tests based on https://microsoft-my.sharepoint.com/:x:/r/personal/micnash_microsoft_com/_layouts/15/Doc.aspx?sourcedoc=%7B181E196F-FC6E-48FB-9CE1-FF143C31B11C%7D&file=ListTestMatrix.xlsx&wdLOR=cE86BCE07-4BBA-48BB-A656-DD19A49E42B5&action=default&mobileredirect=true&share=IQFvGR4Ybvz7SJzh_xQ8MbEcAXMqmVNmXOiC_wmRJHx17jE&cid=c36f7b84-dc61-40e3-bc9d-b82a4509a6e9

        // Validate list methods when resourceGroups is a parent
        [TestCase("ResGrpParentWithAncestorWithNonResChWithLocCollection", "GetAll", true, false)]
        [TestCase("ResGrpParentWithAncestorWithNonResChWithLoc", "GetAll", false, false)]
        [TestCase("ResGrpParentWithAncestorWithNonResChWithLocCollection", "GetNonResourceChild", false, false)]
        [TestCase("ResGrpParentWithAncestorWithNonResChWithLoc", "GetNonResourceChild", true, false)]
        [TestCase("SubscriptionExtensions", "GetBySubscriptionResGrpParentWithAncestorWithNonResChWithLocs", true, false)]

        [TestCase("ResGrpParentWithAncestorWithNonResChCollection", "GetAll", true, false)]
        [TestCase("ResGrpParentWithAncestorWithNonResCh", "GetAll", false, false)]
        [TestCase("ResGrpParentWithAncestorWithNonResChCollection", "GetNonResourceChild", false, false)]
        [TestCase("ResGrpParentWithAncestorWithNonResCh", "GetNonResourceChild", true, false)]
        [TestCase("SubscriptionExtensions", "GetBySubscriptionResGrpParentWithAncestorWithNonResChesAsync", true, false)]

        [TestCase("ResGrpParentWithAncestorWithLocCollection", "GetAll", true, false)]
        [TestCase("ResGrpParentWithAncestorWithLoc", "GetAll", false, false)]
        [TestCase("SubscriptionExtensions", "GetTestResGrpParentWithAncestorWithLocs", true, false)]

        [TestCase("ResGrpParentWithAncestorCollection", "GetAll", true, false)]
        [TestCase("ResGrpParentWithAncestor", "GetAll", false, false)]

        [TestCase("ResGrpParentWithNonResChCollection", "GetAll", true, false)]
        [TestCase("ResGrpParentWithNonResCh", "GetAll", false, false)]
        [TestCase("ResGrpParentWithNonResChCollection", "GetNonResourceChild", false, false)]
        [TestCase("ResGrpParentWithNonResCh", "GetNonResourceChild", true, false)]

        [TestCase("ResGrpParentCollection", "GetAll", true, false)]
        [TestCase("ResGrpParent", "GetAll", false, false)]
        public void ValidateResourceGroupsAsAParentListMethods(string className, string methodName, bool exist, bool haveOverload)
        {
            ValidateListMethods(className, methodName, exist, haveOverload);
        }

        // Validate list methods when fake resource is a parent
        [TestCase("FakeCollection", "GetAll", true, false)]
        [TestCase("Fake", "GetAll", false, false)]

        [TestCase("FakeParentWithAncestorWithNonResChWithLocCollection", "GetAll", true, false)]
        [TestCase("FakeParentWithAncestorWithNonResChWithLoc", "GetAll", false, false)]
        [TestCase("FakeParentWithAncestorWithNonResChWithLocCollection", "GetNonResourceChild", false, false)]
        [TestCase("FakeParentWithAncestorWithNonResChWithLoc", "GetNonResourceChild", true, false)]
        [TestCase("SubscriptionExtensions", "GetBySubscriptionFakeParentWithAncestorWithNonResChWithLocs", true, false)] // TODO -- fix this name

        [TestCase("FakeParentWithAncestorWithNonResChCollection", "GetAll", true, false)]
        [TestCase("FakeParentWithAncestorWithNonResCh", "GetAll", false, false)]
        [TestCase("FakeParentWithAncestorWithNonResChCollection", "GetNonResourceChild", false, false)]
        [TestCase("FakeParentWithAncestorWithNonResCh", "GetNonResourceChild", true, false)]
        [TestCase("SubscriptionExtensions", "GetBySubscriptionFakeParentWithAncestorWithNonResChes", true, false)] // TODO -- fix this name

        [TestCase("FakeParentWithAncestorWithLocCollection", "GetAll", true, false)]
        [TestCase("FakeParentWithAncestorWithLoc", "GetAll", false, false)]
        [TestCase("SubscriptionExtensions", "GetBySubscriptionFakeParentWithAncestorWithLocs", true, false)] // TODO -- fix this name

        [TestCase("FakeParentWithAncestorCollection", "GetAll", true, false)]
        [TestCase("FakeParentWithAncestor", "GetAll", false, false)]
        [TestCase("SubscriptionExtensions", "GetBySubscriptionFakeParentWithAncestors", true, false)] // TODO -- fix this name

        [TestCase("FakeParentWithNonResChCollection", "GetAll", true, false)]
        [TestCase("FakeParentWithNonResCh", "GetAll", false, false)]
        [TestCase("FakeParentWithNonResChCollection", "GetNonResourceChild", false, false)]
        [TestCase("FakeParentWithNonResCh", "GetNonResourceChild", true, false)]

        [TestCase("FakeParentCollection", "GetAll", true, false)]
        [TestCase("FakeParent", "GetAll", false, false)]

        [TestCase("SubscriptionExtensions", "UpdateQuotas", true, false)]
        public void ValidateFakesResourceAsAParentListMethods(string className, string methodName, bool exist, bool haveOverload)
        {
            ValidateListMethods(className, methodName, exist, haveOverload);
        }

        // Validate list methods when subscriptions is a parent
        [TestCase("SubParentWithNonResChWithLocCollection", "GetAll", true, false)]
        [TestCase("SubParentWithNonResChWithLoc", "GetAll", false, false)]
        [TestCase("SubParentWithNonResChWithLocCollection", "GetNonResourceChild", false, false)]
        [TestCase("SubParentWithNonResChWithLoc", "GetNonResourceChild", true, false)]

        [TestCase("SubParentWithNonResChCollection", "GetAll", true, false)]
        [TestCase("SubParentWithNonResCh", "GetAll", false, false)]
        [TestCase("SubParentWithNonResChCollection", "GetNonResourceChild", false, false)]
        [TestCase("SubParentWithNonResCh", "GetNonResourceChild", true, false)]

        [TestCase("SubParentWithLocCollection", "GetAll", true, false)]
        [TestCase("SubParentWithLoc", "GetAll", false, false)]

        [TestCase("SubParentWithLocCollection", "GetAll", true, false)]
        [TestCase("SubParentWithLoc", "GetAll", false, false)]
        public void ValidateSubscriptionsAsAParentListMethods(string className, string methodName, bool exist, bool haveOverload)
        {
            ValidateListMethods(className, methodName, exist, haveOverload);
        }

        // Validate list methods when management groups is a parent
        [TestCase("MgmtGrpParentWithNonResChWithLocCollection", "GetAll", true, false)]
        [TestCase("MgmtGrpParentWithNonResChWithLoc", "GetAll", false, false)]
        [TestCase("MgmtGrpParentWithNonResChWithLocCollection", "GetNonResourceChild", false, false)]
        [TestCase("MgmtGrpParentWithNonResChWithLoc", "GetNonResourceChild", true, false)]

        [TestCase("MgmtGrpParentWithNonResChCollection", "GetAll", true, false)]
        [TestCase("MgmtGrpParentWithNonResCh", "GetAll", false, false)]
        [TestCase("MgmtGrpParentWithNonResChCollection", "GetNonResourceChild", false, false)]
        [TestCase("MgmtGrpParentWithNonResCh", "GetNonResourceChild", true, false)]

        [TestCase("MgmtGrpParentWithLocCollection", "GetAll", true, false)]
        [TestCase("MgmtGrpParentWithLoc", "GetAll", false, false)]

        [TestCase("MgmtGroupParentCollection", "GetAll", true, false)]
        [TestCase("MgmtGroupParent", "GetAll", false, false)]
        public void ValidateMgmtGroupsAsAParentListMethods(string className, string methodName, bool exist, bool haveOverload)
        {
            ValidateListMethods(className, methodName, exist, haveOverload);
        }

        // Validate list methods when tenant is a parent
        [TestCase("TenantParentWithNonResChWithLocCollection", "GetAll", true, false)]
        [TestCase("TenantParentWithNonResChWithLoc", "GetAll", false, false)]
        [TestCase("TenantParentWithNonResChWithLocCollection", "GetNonResourceChild", false, false)]
        [TestCase("TenantParentWithNonResChWithLoc", "GetNonResourceChild", true, false)]

        [TestCase("TenantParentWithNonResChCollection", "GetAll", true, false)]
        [TestCase("TenantParentWithNonResCh", "GetAll", false, false)]
        [TestCase("TenantParentWithNonResChCollection", "GetNonResourceChild", false, false)]
        [TestCase("TenantParentWithNonResCh", "GetNonResourceChild", true, false)]

        [TestCase("TenantParentWithLocCollection", "GetAll", true, false)]
        [TestCase("TenantParentWithLoc", "GetAll", false, false)]

        [TestCase("TenantParentCollection", "GetAll", true, false)]
        [TestCase("TenantParent", "GetAll", false, false)]
        public void ValidateTenantAsAParentListMethods(string className, string methodName, bool exist, bool haveOverload)
        {
            ValidateListMethods(className, methodName, exist, haveOverload);
        }

        public void ValidateListMethods(string className, string methodName, bool exist, bool haveOverload)
        {
            var subscriptionExtensions = Assembly.GetExecutingAssembly().GetType("MgmtListMethods.SubscriptionExtensions");
            var classesToCheck = FindAllCollections().Concat(FindAllResources()).Append(subscriptionExtensions);
            var classToCheck = classesToCheck.First(t => t.Name == className);
            if (haveOverload)
            {
                var methods = classToCheck.GetMethods().Where(m => m.Name == methodName);
                Assert.AreEqual(exist, methods != null, $"can{(exist ? "not" : string.Empty)} find {className}.{methodName}");
                Assert.Greater(methods.Count(), 1, $"Method overload not found {className}.{methodName}");
            }
            else
            {
                Assert.AreEqual(exist, classToCheck.GetMethod(methodName) != null, $"can{(exist ? "not" : string.Empty)} find {className}.{methodName}");
            }
        }

        [TestCase("FakeCollection", "GetAllAsGenericResources", true)]
        [TestCase("SubParentCollection", "GetAllAsGenericResources", true)]
        public void ValidateMethods(string className, string methodName, bool exist)
        {
            var classesToCheck = FindAllCollections();
            var classToCheck = classesToCheck.First(t => t.Name == className);
            Assert.AreEqual(exist, classToCheck.GetMethod(methodName) != null, $"can{(exist ? "not" : string.Empty)} find {className}.{methodName}");
        }
    }
}
