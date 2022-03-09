using System.Linq;
using System.Reflection;
using NUnit.Framework;
using System.Collections.Generic;
using MgmtScopeResource;
using System;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    public class MgmtScopeResourceTests : TestProjectTests
    {
        public MgmtScopeResourceTests() : base("MgmtScopeResource") { }

        protected override HashSet<Type> ListExceptionCollections { get; } = new HashSet<Type>() { typeof(ResourceLinkCollection) };

        [TestCase("ManagementGroupExtensions", "GetPolicyAssignments", false)]
        [TestCase("SubscriptionExtensions", "GetPolicyAssignments", false)]
        [TestCase("ResourceGroupExtensions", "GetPolicyAssignments", false)]
        [TestCase("ManagementGroupExtensions", "GetDeploymentExtendeds", true)]
        [TestCase("SubscriptionExtensions", "GetDeploymentExtendeds", true)]
        [TestCase("ResourceGroupExtensions", "GetDeploymentExtendeds", true)]
        [TestCase("ArmResourceExtensions", "GetFakePolicyAssignments", true)]
        [TestCase("ArmResourceExtensions", "GetDeploymentExtendeds", false)]
        [TestCase("FakePolicyAssignmentCollection", "CreateOrUpdate", true)]
        [TestCase("FakePolicyAssignmentCollection", "Get", true)]
        [TestCase("FakePolicyAssignmentCollection", "GetAll", true)]
        [TestCase("FakePolicyAssignmentCollection", "GetForResourceGroup", false)]
        [TestCase("FakePolicyAssignmentCollection", "GetForResource", false)]
        [TestCase("FakePolicyAssignmentCollection", "GetForManagementGroup", false)]
        [TestCase("FakePolicyAssignmentCollection", "GetAllAsGenericResources", false)]
        [TestCase("FakePolicyAssignment", "Get", true)]
        [TestCase("FakePolicyAssignment", "Delete", true)]
        [TestCase("DeploymentExtendedCollection", "CreateOrUpdate", true)]
        [TestCase("DeploymentExtendedCollection", "Get", true)]
        [TestCase("DeploymentExtendedCollection", "GetAll", true)]
        [TestCase("DeploymentExtendedCollection", "GetAllAsGenericResources", false)]
        [TestCase("DeploymentExtended", "WhatIf", true)]
        [TestCase("DeploymentExtended", "WhatIfAtTenantScope", false)]
        [TestCase("DeploymentExtended", "WhatIfAtSubscriptionScope", false)]
        [TestCase("DeploymentExtended", "WhatIfAtManagementGroupScope", false)]
        [TestCase("ResourceLinkCollection", "CreateOrUpdate", true)]
        [TestCase("ResourceLinkCollection", "Get", true)]
        //[TestCase("ResourceLinkCollection", "GetAll", true)] // TODO -- restore this when this is fixed
        [TestCase("ResourceLinkCollection", "GetAllAsGenericResources", false)]
        [TestCase("ResourceLink", "Get", true)]
        [TestCase("ResourceLink", "Delete", true)]
        public void ValidateScopeResourceMethods(string className, string methodName, bool exist)
        {
            var managementGroupExtensions = Assembly.GetExecutingAssembly().GetType("MgmtScopeResource.ManagementGroupExtensions");
            var subscriptionExtensions = Assembly.GetExecutingAssembly().GetType("MgmtScopeResource.SubscriptionExtensions");
            var resourceGroupExtensions = Assembly.GetExecutingAssembly().GetType("MgmtScopeResource.ResourceGroupExtensions");
            var armResourceExtensions = Assembly.GetExecutingAssembly().GetType("MgmtScopeResource.ArmResourceExtensions");
            var classesToCheck = FindAllCollections().Concat(FindAllResources()).Append(managementGroupExtensions).Append(subscriptionExtensions).Append(resourceGroupExtensions).Append(armResourceExtensions);
            var classToCheck = classesToCheck.First(t => t.Name == className);
            Assert.AreEqual(exist, classToCheck.GetMethod(methodName) != null, $"can{(exist ? "not" : string.Empty)} find {className}.{methodName}");
        }

    }
}
