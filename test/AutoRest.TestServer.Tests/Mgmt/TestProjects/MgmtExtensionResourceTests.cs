﻿using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    public class MgmtExtensionResourceTests : TestProjectTests
    {
        public MgmtExtensionResourceTests() : base("MgmtExtensionResource") { }

        [TestCase("ManagementGroupExtensions", "GetPolicyDefinitionContainer", true)]
        [TestCase("SubscriptionExtensions", "GetPolicyDefinitionContainer", true)]
        [TestCase("ResourceGroupExtensions", "GetPolicyDefinitionContainer", false)]
        [TestCase("PolicyDefinitionContainer", "CreateOrUpdate", true)]
        [TestCase("PolicyDefinitionContainer", "Get", true)]
        [TestCase("PolicyDefinitionContainer", "CreateOrUpdateAtManagementGroup", false)]
        [TestCase("PolicyDefinitionContainer", "GetAtManagementGroup", false)]
        [TestCase("PolicyDefinitionContainer", "GetBuiltIn", false)]
        [TestCase("PolicyDefinitionOperations", "Get", true)]
        [TestCase("PolicyDefinitionOperations", "GetAtManagementGroup", false)]
        [TestCase("PolicyDefinitionOperations", "GetBuiltIn", false)]
        [TestCase("PolicyDefinitionOperations", "Delete", true)]
        [TestCase("PolicyDefinitionOperations", "DeleteAtManagementGroup", false)]
        public void ValidateExtensionResourceMethods(string className, string methodName, bool exist)
        {
            var managementGroupExtensions = Assembly.GetExecutingAssembly().GetType("MgmtExtensionResource.ManagementGroupExtensions");
            var subscriptionExtensions = Assembly.GetExecutingAssembly().GetType("MgmtExtensionResource.SubscriptionExtensions");
            var resourceGroupExtensions = Assembly.GetExecutingAssembly().GetType("MgmtExtensionResource.ResourceGroupExtensions");
            var classesToCheck = FindAllContainers().Concat(FindAllOperations()).Append(managementGroupExtensions).Append(subscriptionExtensions).Append(resourceGroupExtensions);
            var classToCheck = classesToCheck.First(t => t.Name == className);
            Assert.AreEqual(exist, classToCheck.GetMethod(methodName) != null, $"can{(exist ? "not" : string.Empty)} find {className}.{methodName}");
        }

    }
}
