using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    public class MgmtScopeResourceTests : TestProjectTests
    {
        public MgmtScopeResourceTests() : base("MgmtScopeResource") { }

        [TestCase("ManagementGroupExtensions", "GetPolicyAssignments", true)]
        [TestCase("SubscriptionExtensions", "GetPolicyAssignments", true)]
        [TestCase("ResourceGroupExtensions", "GetPolicyAssignments", true)]
        [TestCase("PolicyAssignmentCollection", "CreateOrUpdate", true)]
        [TestCase("PolicyAssignmentCollection", "Get", true)]
        [TestCase("PolicyAssignmentCollection", "GetAll", true)]
        [TestCase("PolicyAssignmentCollection", "GetForResourceGroup", false)]
        [TestCase("PolicyAssignmentCollection", "GetForResource", false)]
        [TestCase("PolicyAssignmentCollection", "GetForManagementGroup", false)]
        [TestCase("PolicyAssignmentCollection", "GetAllAsGenericResources", false)]
        [TestCase("PolicyAssignment", "Get", true)]
        [TestCase("PolicyAssignment", "Delete", true)]
        [TestCase("DeploymentExtendedCollection", "CreateOrUpdate", true)]
        [TestCase("DeploymentExtendedCollection", "Get", true)]
        [TestCase("DeploymentExtendedCollection", "GetAll", true)]
        [TestCase("DeploymentExtendedCollection", "GetAllAsGenericResources", false)]
        [TestCase("DeploymentExtended", "WhatIf", true)]
        [TestCase("DeploymentExtended", "WhatIfAtTenantScope", false)]
        [TestCase("DeploymentExtended", "WhatIfAtSubscriptionScope", false)]
        [TestCase("DeploymentExtended", "WhatIfAtManagementGroupScope", false)]
        [TestCase("DeploymentOperationCollection", "Get", true)]
        [TestCase("DeploymentOperationCollection", "GetAll", true)]
        [TestCase("DeploymentOperationCollection", "GetAllAsGenericResources", false)]
        [TestCase("DeploymentOperation", "Get", true)]
        [TestCase("ResourceLinkCollection", "CreateOrUpdate", true)]
        [TestCase("ResourceLinkCollection", "Get", true)]
        [TestCase("ResourceLinkCollection", "GetAll", true)]
        [TestCase("ResourceLinkCollection", "GetAllAsGenericResources", false)]
        [TestCase("ResourceLink", "Get", true)]
        [TestCase("ResourceLink", "Delete", true)]
        public void ValidateScopeResourceMethods(string className, string methodName, bool exist)
        {
            var managementGroupExtensions = Assembly.GetExecutingAssembly().GetType("MgmtScopeResource.ManagementGroupExtensions");
            var subscriptionExtensions = Assembly.GetExecutingAssembly().GetType("MgmtScopeResource.SubscriptionExtensions");
            var resourceGroupExtensions = Assembly.GetExecutingAssembly().GetType("MgmtScopeResource.ResourceGroupExtensions");
            var classesToCheck = FindAllCollections().Concat(FindAllResources()).Append(managementGroupExtensions).Append(subscriptionExtensions).Append(resourceGroupExtensions);
            var classToCheck = classesToCheck.First(t => t.Name == className);
            Assert.AreEqual(exist, classToCheck.GetMethod(methodName) != null, $"can{(exist ? "not" : string.Empty)} find {className}.{methodName}");
        }

    }
}
