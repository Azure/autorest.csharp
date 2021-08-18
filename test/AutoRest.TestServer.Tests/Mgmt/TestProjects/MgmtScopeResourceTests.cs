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
        [TestCase("PolicyAssignmentContainer", "CreateOrUpdate", true)]
        [TestCase("PolicyAssignmentContainer", "Get", true)]
        [TestCase("PolicyAssignmentContainer", "GetAll", true)]
        [TestCase("PolicyAssignmentContainer", "Delete", true)]
        [TestCase("PolicyAssignmentContainer", "GetForResourceGroup", false)]
        [TestCase("PolicyAssignmentContainer", "GetForResource", false)]
        [TestCase("PolicyAssignmentContainer", "GetForManagementGroup", false)]
        [TestCase("PolicyAssignment", "Get", true)]
        [TestCase("PolicyAssignment", "Delete", true)]
        [TestCase("DeploymentExtendedContainer", "CreateOrUpdate", true)]
        [TestCase("DeploymentExtendedContainer", "Get", true)]
        [TestCase("DeploymentExtendedContainer", "GetAll", true)]
        [TestCase("DeploymentExtendedContainer", "Delete", true)]
        [TestCase("DeploymentExtended", "WhatIf", true)]
        [TestCase("DeploymentExtended", "WhatIfAtTenantScope", false)]
        [TestCase("DeploymentExtended", "WhatIfAtSubscriptionScope", false)]
        [TestCase("DeploymentExtended", "WhatIfAtManagementGroupScope", false)]
        [TestCase("DeploymentOperationContainer", "Get", true)]
        [TestCase("DeploymentOperationContainer", "GetAll", true)]
        [TestCase("DeploymentOperationContainer", "Delete", false)]
        [TestCase("DeploymentOperation", "Get", true)]
        [TestCase("ResourceLinkContainer", "CreateOrUpdate", true)]
        [TestCase("ResourceLinkContainer", "Get", true)]
        [TestCase("ResourceLinkContainer", "GetAll", true)]
        [TestCase("ResourceLinkContainer", "Delete", true)]
        [TestCase("ResourceLink", "Get", true)]
        [TestCase("ResourceLink", "Delete", true)]
        public void ValidateScopeResourceMethods(string className, string methodName, bool exist)
        {
            var managementGroupExtensions = Assembly.GetExecutingAssembly().GetType("MgmtScopeResource.ManagementGroupExtensions");
            var subscriptionExtensions = Assembly.GetExecutingAssembly().GetType("MgmtScopeResource.SubscriptionExtensions");
            var resourceGroupExtensions = Assembly.GetExecutingAssembly().GetType("MgmtScopeResource.ResourceGroupExtensions");
            var classesToCheck = FindAllContainers().Concat(FindAllResources()).Append(managementGroupExtensions).Append(subscriptionExtensions).Append(resourceGroupExtensions);
            var classToCheck = classesToCheck.First(t => t.Name == className);
            Assert.AreEqual(exist, classToCheck.GetMethod(methodName) != null, $"can{(exist ? "not" : string.Empty)} find {className}.{methodName}");
        }

    }
}
