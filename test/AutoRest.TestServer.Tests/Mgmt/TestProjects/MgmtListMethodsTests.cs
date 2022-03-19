using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    public class MgmtListMethodsTests : TestProjectTests
    {
        public MgmtListMethodsTests() : base("MgmtListMethods") { }

        // Added tests based on https://microsoft-my.sharepoint.com/:x:/r/personal/micnash_microsoft_com/_layouts/15/Doc.aspx?sourcedoc=%7B181E196F-FC6E-48FB-9CE1-FF143C31B11C%7D&file=ListTestMatrix.xlsx&wdLOR=cE86BCE07-4BBA-48BB-A656-DD19A49E42B5&action=default&mobileredirect=true&share=IQFvGR4Ybvz7SJzh_xQ8MbEcAXMqmVNmXOiC_wmRJHx17jE&cid=c36f7b84-dc61-40e3-bc9d-b82a4509a6e9

        // Validate list methods when resourceGroups is a parent
        [TestCase("ResGrpParentWithAncestorWithNonResChWithLocCollection", "GetAll", true)]
        [TestCase("ResGrpParentWithAncestorWithNonResChWithLoc", "GetAll", false)]
        [TestCase("ResGrpParentWithAncestorWithNonResChWithLocCollection", "GetNonResourceChild", false)]
        [TestCase("ResGrpParentWithAncestorWithNonResChWithLoc", "GetNonResourceChild", true)]
        [TestCase("MgmtListMethodsExtensions", "GetResGrpParentWithAncestorWithNonResChWithLocs", true, typeof(Subscription))]
        [TestCase("MgmtListMethodsExtensions", "GetResGrpParentWithAncestorWithNonResChWithLocs", true, typeof(ResourceGroup))]

        [TestCase("ResGrpParentWithAncestorWithNonResChCollection", "GetAll", true)]
        [TestCase("ResGrpParentWithAncestorWithNonResCh", "GetAll", false)]
        [TestCase("ResGrpParentWithAncestorWithNonResChCollection", "GetNonResourceChild", false)]
        [TestCase("ResGrpParentWithAncestorWithNonResCh", "GetNonResourceChild", true)]
        [TestCase("MgmtListMethodsExtensions", "GetResGrpParentWithAncestorWithNonResChes", true, typeof(Subscription))]
        [TestCase("MgmtListMethodsExtensions", "GetResGrpParentWithAncestorWithNonResChes", true, typeof(ResourceGroup))]

        [TestCase("ResGrpParentWithAncestorWithLocCollection", "GetAll", true)]
        [TestCase("ResGrpParentWithAncestorWithLoc", "GetAll", false)]
        [TestCase("MgmtListMethodsExtensions", "GetResGrpParentWithAncestorWithLocs", true, typeof(Subscription))]
        [TestCase("MgmtListMethodsExtensions", "GetResGrpParentWithAncestorWithLocs", true, typeof(ResourceGroup))]

        [TestCase("ResGrpParentWithAncestorCollection", "GetAll", true)]
        [TestCase("ResGrpParentWithAncestor", "GetAll", false)]

        [TestCase("ResGrpParentWithNonResChCollection", "GetAll", true)]
        [TestCase("ResGrpParentWithNonResCh", "GetAll", false)]
        [TestCase("ResGrpParentWithNonResChCollection", "GetNonResourceChild", false)]
        [TestCase("ResGrpParentWithNonResCh", "GetNonResourceChild", true)]

        [TestCase("ResGrpParentCollection", "GetAll", true)]
        [TestCase("ResGrpParent", "GetAll", false)]
        public void ValidateResourceGroupsAsAParentListMethods(string className, string methodName, bool exist, params Type[] parameterTypes)
        {
            ValidateListMethods(className, methodName, exist, parameterTypes);
        }

        // Validate list methods when fake resource is a parent
        [TestCase("FakeCollection", "GetAll", true)]
        [TestCase("Fake", "GetAll", false)]

        [TestCase("FakeParentWithAncestorWithNonResChWithLocCollection", "GetAll", true)]
        [TestCase("FakeParentWithAncestorWithNonResChWithLoc", "GetAll", false)]
        [TestCase("FakeParentWithAncestorWithNonResChWithLocCollection", "GetNonResourceChild", false)]
        [TestCase("FakeParentWithAncestorWithNonResChWithLoc", "GetNonResourceChild", true)]
        [TestCase("MgmtListMethodsExtensions", "GetFakeParentWithAncestorWithNonResourceChWithLoc", true, typeof(Subscription))]
        [TestCase("MgmtListMethodsExtensions", "GetFakeParentWithAncestorWithNonResourceChWithLoc", false, typeof(ResourceGroup))]

        [TestCase("FakeParentWithAncestorWithNonResChCollection", "GetAll", true)]
        [TestCase("FakeParentWithAncestorWithNonResCh", "GetAll", false)]
        [TestCase("FakeParentWithAncestorWithNonResChCollection", "GetNonResourceChild", false)]
        [TestCase("FakeParentWithAncestorWithNonResCh", "GetNonResourceChild", true)]
        [TestCase("MgmtListMethodsExtensions", "GetFakeParentWithAncestorWithNonResChes", true, typeof(Subscription))]
        [TestCase("MgmtListMethodsExtensions", "GetFakeParentWithAncestorWithNonResChes", false, typeof(ResourceGroup))]

        [TestCase("FakeParentWithAncestorWithLocCollection", "GetAll", true)]
        [TestCase("FakeParentWithAncestorWithLoc", "GetAll", false)]
        [TestCase("MgmtListMethodsExtensions", "GetFakeParentWithAncestorWithLocs", true, typeof(Subscription))]
        [TestCase("MgmtListMethodsExtensions", "GetFakeParentWithAncestorWithLocs", false, typeof(ResourceGroup))]

        [TestCase("FakeParentWithAncestorCollection", "GetAll", true)]
        [TestCase("FakeParentWithAncestor", "GetAll", false)]
        [TestCase("MgmtListMethodsExtensions", "GetFakeParentWithAncestors", true, typeof(Subscription))]
        [TestCase("MgmtListMethodsExtensions", "GetFakeParentWithAncestors", false, typeof(ResourceGroup))]

        [TestCase("FakeParentWithNonResChCollection", "GetAll", true)]
        [TestCase("FakeParentWithNonResCh", "GetAll", false)]
        [TestCase("FakeParentWithNonResChCollection", "GetNonResourceChild", false)]
        [TestCase("FakeParentWithNonResCh", "GetNonResourceChild", true)]

        [TestCase("FakeParentCollection", "GetAll", true)]
        [TestCase("FakeParent", "GetAll", false)]

        [TestCase("MgmtListMethodsExtensions", "UpdateQuotas", true, typeof(Subscription))]
        [TestCase("MgmtListMethodsExtensions", "UpdateQuotas", false, typeof(ResourceGroup))]
        public void ValidateFakesResourceAsAParentListMethods(string className, string methodName, bool exist, params Type[] parameterTypes)
        {
            ValidateListMethods(className, methodName, exist, parameterTypes);
        }

        // Validate list methods when subscriptions is a parent
        [TestCase("SubParentWithNonResChWithLocCollection", "GetAll", true)]
        [TestCase("SubParentWithNonResChWithLoc", "GetAll", false)]
        [TestCase("SubParentWithNonResChWithLocCollection", "GetNonResourceChild", false)]
        [TestCase("SubParentWithNonResChWithLoc", "GetNonResourceChild", true)]

        [TestCase("SubParentWithNonResChCollection", "GetAll", true)]
        [TestCase("SubParentWithNonResCh", "GetAll", false)]
        [TestCase("SubParentWithNonResChCollection", "GetNonResourceChild", false)]
        [TestCase("SubParentWithNonResCh", "GetNonResourceChild", true)]

        [TestCase("SubParentWithLocCollection", "GetAll", true)]
        [TestCase("SubParentWithLoc", "GetAll", false)]

        [TestCase("SubParentWithLocCollection", "GetAll", true)]
        [TestCase("SubParentWithLoc", "GetAll", false)]
        public void ValidateSubscriptionsAsAParentListMethods(string className, string methodName, bool exist)
        {
            ValidateListMethods(className, methodName, exist);
        }

        // Validate list methods when management groups is a parent
        [TestCase("MgmtGrpParentWithNonResChWithLocCollection", "GetAll", true)]
        [TestCase("MgmtGrpParentWithNonResChWithLoc", "GetAll", false)]
        [TestCase("MgmtGrpParentWithNonResChWithLocCollection", "GetNonResourceChild", false)]
        [TestCase("MgmtGrpParentWithNonResChWithLoc", "GetNonResourceChild", true)]

        [TestCase("MgmtGrpParentWithNonResChCollection", "GetAll", true)]
        [TestCase("MgmtGrpParentWithNonResCh", "GetAll", false)]
        [TestCase("MgmtGrpParentWithNonResChCollection", "GetNonResourceChild", false)]
        [TestCase("MgmtGrpParentWithNonResCh", "GetNonResourceChild", true)]

        [TestCase("MgmtGrpParentWithLocCollection", "GetAll", true)]
        [TestCase("MgmtGrpParentWithLoc", "GetAll", false)]

        [TestCase("MgmtGroupParentCollection", "GetAll", true)]
        [TestCase("MgmtGroupParent", "GetAll", false)]
        public void ValidateMgmtGroupsAsAParentListMethods(string className, string methodName, bool exist)
        {
            ValidateListMethods(className, methodName, exist);
        }

        // Validate list methods when tenant is a parent
        [TestCase("TenantParentWithNonResChWithLocCollection", "GetAll", true)]
        [TestCase("TenantParentWithNonResChWithLoc", "GetAll", false)]
        [TestCase("TenantParentWithNonResChWithLocCollection", "GetNonResourceChild", false)]
        [TestCase("TenantParentWithNonResChWithLoc", "GetNonResourceChild", true)]

        [TestCase("TenantParentWithNonResChCollection", "GetAll", true)]
        [TestCase("TenantParentWithNonResCh", "GetAll", false)]
        [TestCase("TenantParentWithNonResChCollection", "GetNonResourceChild", false)]
        [TestCase("TenantParentWithNonResCh", "GetNonResourceChild", true)]

        [TestCase("TenantParentWithLocCollection", "GetAll", true)]
        [TestCase("TenantParentWithLoc", "GetAll", false)]

        [TestCase("TenantParentCollection", "GetAll", true)]
        [TestCase("TenantParent", "GetAll", false)]
        public void ValidateTenantAsAParentListMethods(string className, string methodName, bool exist)
        {
            ValidateListMethods(className, methodName, exist);
        }

        public void ValidateListMethods(string className, string methodName, bool exist, params Type[] parameterTypes)
        {
            var classesToCheck = FindAllCollections().Concat(FindAllResources()).Append(FindExtensionClass());
            var classToCheck = classesToCheck.First(t => t.Name == className);
            var methods = classToCheck.GetMethods().Where(t => t.Name == methodName).Where(m => ParameterMatch(m.GetParameters(), parameterTypes));
            Assert.AreEqual(exist, methods.Any(), $"can{(exist ? "not" : string.Empty)} find {className}.{methodName} with parameters {string.Join(", ", (IEnumerable<Type>)parameterTypes)}");
        }
    }
}
