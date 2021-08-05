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
        [TestCase("PolicyAssignmentContainer", "GetForResourceGroup", false)]
        [TestCase("PolicyAssignmentContainer", "GetForResource", false)]
        [TestCase("PolicyAssignmentContainer", "GetForManagementGroup", false)]
        [TestCase("PolicyAssignmentOperations", "Get", true)]
        [TestCase("PolicyAssignmentOperations", "Delete", true)]
        [TestCase("DeploymentExtendedContainer", "CreateOrUpdate", true)]
        [TestCase("DeploymentExtendedContainer", "Get", true)]
        [TestCase("DeploymentExtendedContainer", "GetAll", true)]
        [TestCase("DeploymentExtendedOperations", "WhatIf", true)]
        [TestCase("DeploymentExtendedOperations", "WhatIfAtTenantScope", false)]
        [TestCase("DeploymentExtendedOperations", "WhatIfAtSubscriptionScope", false)]
        [TestCase("DeploymentExtendedOperations", "WhatIfAtManagementGroupScope", false)]
        [TestCase("DeploymentOperationContainer", "Get", true)]
        [TestCase("DeploymentOperationContainer", "GetAll", true)]
        [TestCase("DeploymentOperationOperations", "Get", true)]
        public void ValidateScopeResourceMethods(string className, string methodName, bool exist)
        {
            var managementGroupExtensions = Assembly.GetExecutingAssembly().GetType("MgmtScopeResource.ManagementGroupExtensions");
            var subscriptionExtensions = Assembly.GetExecutingAssembly().GetType("MgmtScopeResource.SubscriptionExtensions");
            var resourceGroupExtensions = Assembly.GetExecutingAssembly().GetType("MgmtScopeResource.ResourceGroupExtensions");
            var classesToCheck = FindAllContainers().Concat(FindAllOperations()).Append(managementGroupExtensions).Append(subscriptionExtensions).Append(resourceGroupExtensions);
            var classToCheck = classesToCheck.First(t => t.Name == className);
            Assert.AreEqual(exist, classToCheck.GetMethod(methodName) != null, $"can{(exist ? "not" : string.Empty)} find {className}.{methodName}");
        }

    }
}
