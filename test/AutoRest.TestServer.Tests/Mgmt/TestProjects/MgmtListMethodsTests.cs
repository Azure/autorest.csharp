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
        [TestCase("ResGrpParentWithAncestorWithNonResChWithLocContainer", "GetAll", true, false)]
        [TestCase("ResGrpParentWithAncestorWithNonResChWithLocOperations", "GetAll", false, false)]
        [TestCase("ResGrpParentWithAncestorWithNonResChWithLocContainer", "GetNonResourceChild", false, false)]
        [TestCase("ResGrpParentWithAncestorWithNonResChWithLocOperations", "GetNonResourceChild", true, false)]
        [TestCase("SubscriptionExtensions", "GetResGrpParentWithAncestorWithNonResChWithLocs", true, false)]
        [TestCase("SubscriptionExtensions", "GetResGrpParentWithAncestorWithNonResChWithLocsByLocation", true, false)]

        [TestCase("ResGrpParentWithAncestorWithNonResChContainer", "GetAll", true, false)]
        [TestCase("ResGrpParentWithAncestorWithNonResChOperations", "GetAll", false, false)]
        [TestCase("ResGrpParentWithAncestorWithNonResChContainer", "GetNonResourceChild", false, false)]
        [TestCase("ResGrpParentWithAncestorWithNonResChOperations", "GetNonResourceChild", true, false)]
        [TestCase("SubscriptionExtensions", "GetResGrpParentWithAncestorWithNonResChes", true, false)]

        [TestCase("ResGrpParentWithAncestorWithLocContainer", "GetAll", true, false)]
        [TestCase("ResGrpParentWithAncestorWithLocOperations", "GetAll", false, false)]
        [TestCase("SubscriptionExtensions", "GetResGrpParentWithAncestorWithLocs", true, true)]

        [TestCase("ResGrpParentWithAncestorContainer", "GetAll", true, false)]
        [TestCase("ResGrpParentWithAncestorOperations", "GetAll", false, false)]
        [TestCase("SubscriptionExtensions", "GetResGrpParentWithAncestorWithNonResChes", true, false)]

        [TestCase("ResGrpParentWithNonResChContainer", "GetAll", true, false)]
        [TestCase("ResGrpParentWithNonResChOperations", "GetAll", false, false)]
        [TestCase("ResGrpParentWithNonResChContainer", "GetNonResourceChild", false, false)]
        [TestCase("ResGrpParentWithNonResChOperations", "GetNonResourceChild", true, false)]

        [TestCase("ResGrpParentContainer", "GetAll", true, false)]
        [TestCase("ResGrpParentOperations", "GetAll", false, false)]
        public void ValidateResourceGroupsAsAParentListMethods(string className, string methodName, bool exist, bool haveOverload)
        {
            ValidateListMethods(className, methodName, exist, haveOverload);
        }

        // Validate list methods when fake resource is a parent
        [TestCase("FakeContainer", "GetAll", true, false)]
        [TestCase("FakeOperations", "GetAll", false, false)]

        [TestCase("FakeParentWithAncestorWithNonResChWithLocContainer", "GetAll", true, false)]
        [TestCase("FakeParentWithAncestorWithNonResChWithLocOperations", "GetAll", false, false)]
        [TestCase("FakeParentWithAncestorWithNonResChWithLocContainer", "GetNonResourceChild", false, false)]
        [TestCase("FakeParentWithAncestorWithNonResChWithLocOperations", "GetNonResourceChild", true, false)]
        [TestCase("SubscriptionExtensions", "GetFakeParentWithAncestorWithNonResChWithLocs", true, true)]

        [TestCase("FakeParentWithAncestorWithNonResChContainer", "GetAll", true, false)]
        [TestCase("FakeParentWithAncestorWithNonResChOperations", "GetAll", false, false)]
        [TestCase("FakeParentWithAncestorWithNonResChContainer", "GetNonResourceChild", false, false)]
        [TestCase("FakeParentWithAncestorWithNonResChOperations", "GetNonResourceChild", true, false)]
        [TestCase("SubscriptionExtensions", "GetFakeParentWithAncestorWithNonResChes", true, false)]

        [TestCase("FakeParentWithAncestorWithLocContainer", "GetAll", true, false)]
        [TestCase("FakeParentWithAncestorWithLocOperations", "GetAll", false, false)]
        [TestCase("SubscriptionExtensions", "GetFakeParentWithAncestorWithLocs", true, true)]

        [TestCase("FakeParentWithAncestorContainer", "GetAll", true, false)]
        [TestCase("FakeParentWithAncestorOperations", "GetAll", false, false)]
        [TestCase("SubscriptionExtensions", "GetFakeParentWithAncestors", true, false)]

        [TestCase("FakeParentWithNonResChContainer", "GetAll", true, false)]
        [TestCase("FakeParentWithNonResChOperations", "GetAll", false, false)]
        [TestCase("FakeParentWithNonResChContainer", "GetNonResourceChild", false, false)]
        [TestCase("FakeParentWithNonResChOperations", "GetNonResourceChild", true, false)]

        [TestCase("FakeParentContainer", "GetAll", true, false)]
        [TestCase("FakeParentOperations", "GetAll", false, false)]

        [TestCase("SubscriptionExtensions", "UpdateQuotas", true, false)]
        public void ValidateFakesResourceAsAParentListMethods(string className, string methodName, bool exist, bool haveOverload)
        {
            ValidateListMethods(className, methodName, exist, haveOverload);
        }

        // Validate list methods when subscriptions is a parent
        [TestCase("SubParentWithNonResChWithLocContainer", "GetAll", true, false)]
        [TestCase("SubParentWithNonResChWithLocOperations", "GetAll", false, false)]
        [TestCase("SubParentWithNonResChWithLocContainer", "GetNonResourceChild", false, false)]
        [TestCase("SubParentWithNonResChWithLocOperations", "GetNonResourceChild", true, false)]

        [TestCase("SubParentWithNonResChContainer", "GetAll", true, false)]
        [TestCase("SubParentWithNonResChOperations", "GetAll", false, false)]
        [TestCase("SubParentWithNonResChContainer", "GetNonResourceChild", false, false)]
        [TestCase("SubParentWithNonResChOperations", "GetNonResourceChild", true, false)]

        [TestCase("SubParentWithLocContainer", "GetAll", true, false)]
        [TestCase("SubParentWithLocOperations", "GetAll", false, false)]

        [TestCase("SubParentWithLocContainer", "GetAll", true, false)]
        [TestCase("SubParentWithLocOperations", "GetAll", false, false)]
        public void ValidateSubscriptionsAsAParentListMethods(string className, string methodName, bool exist, bool haveOverload)
        {
            ValidateListMethods(className, methodName, exist, haveOverload);
        }

        // Validate list methods when management groups is a parent
        [TestCase("ManagementGroupContainer", "GetAll", true, false)]
        [TestCase("ManagementGroupOperations", "GetAll", false, false)]
        [TestCase("ManagementGroupContainer", "GetDescendants", false, false)]
        [TestCase("ManagementGroupOperations", "GetDescendants", true, false)]

        [TestCase("MgmtGrpParentWithNonResChWithLocContainer", "GetAll", true, false)]
        [TestCase("MgmtGrpParentWithNonResChWithLocOperations", "GetAll", false, false)]
        [TestCase("MgmtGrpParentWithNonResChWithLocContainer", "GetNonResourceChild", false, false)]
        [TestCase("MgmtGrpParentWithNonResChWithLocOperations", "GetNonResourceChild", true, false)]

        [TestCase("MgmtGrpParentWithNonResChContainer", "GetAll", true, false)]
        [TestCase("MgmtGrpParentWithNonResChOperations", "GetAll", false, false)]
        [TestCase("MgmtGrpParentWithNonResChContainer", "GetNonResourceChild", false, false)]
        [TestCase("MgmtGrpParentWithNonResChOperations", "GetNonResourceChild", true, false)]

        [TestCase("MgmtGrpParentWithLocContainer", "GetAll", true, false)]
        [TestCase("MgmtGrpParentWithLocOperations", "GetAll", false, false)]

        [TestCase("MgmtGroupParentContainer", "GetAll", true, false)]
        [TestCase("MgmtGroupParentOperations", "GetAll", false, false)]
        public void ValidateMgmtGroupsAsAParentListMethods(string className, string methodName, bool exist, bool haveOverload)
        {
            ValidateListMethods(className, methodName, exist, haveOverload);
        }

        // Validate list methods when tenant is a parent
        [TestCase("TenantParentWithNonResChWithLocContainer", "GetAll", true, false)]
        [TestCase("TenantParentWithNonResChWithLocOperations", "GetAll", false, false)]
        [TestCase("TenantParentWithNonResChWithLocContainer", "GetNonResourceChild", false, false)]
        [TestCase("TenantParentWithNonResChWithLocOperations", "GetNonResourceChild", true, false)]

        [TestCase("TenantParentWithNonResChContainer", "GetAll", true, false)]
        [TestCase("TenantParentWithNonResChOperations", "GetAll", false, false)]
        [TestCase("TenantParentWithNonResChContainer", "GetNonResourceChild", false, false)]
        [TestCase("TenantParentWithNonResChOperations", "GetNonResourceChild", true, false)]

        [TestCase("TenantParentWithLocContainer", "GetAll", true, false)]
        [TestCase("TenantParentWithLocOperations", "GetAll", false, false)]

        [TestCase("TenantParentContainer", "GetAll", true, false)]
        [TestCase("TenantParentOperations", "GetAll", false, false)]
        public void ValidateTenantAsAParentListMethods(string className, string methodName, bool exist, bool haveOverload)
        {
            ValidateListMethods(className, methodName, exist, haveOverload);
        }

        public void ValidateListMethods(string className, string methodName, bool exist, bool haveOverload)
        {
            var subscriptionExtensions = Assembly.GetExecutingAssembly().GetType("MgmtListMethods.SubscriptionExtensions");
            var classesToCheck = FindAllContainers().Concat(FindAllOperations()).Append(subscriptionExtensions);
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
    }
}
