using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    public class MgmtExtensionResourceTests : TestProjectTests
    {
        public MgmtExtensionResourceTests() : base("MgmtExtensionResource") { }

        [TestCase("ManagementGroupExtensions", "GetManagementGroupPolicyDefinitionResources", true)]
        [TestCase("ManagementGroupExtensions", "GetManagementGroupPolicyDefinitions", false)]
        [TestCase("SubscriptionExtensions", "GetSubscriptionPolicyDefinitionResources", true)]
        [TestCase("SubscriptionExtensions", "GetSubscriptionPolicyDefinitions", false)]
        [TestCase("ResourceGroupExtensions", "GetPolicyDefinitionResources", false)]
        [TestCase("ResourceGroupExtensions", "GetPolicyDefinitions", false)]
        [TestCase("ManagementGroupPolicyDefinitionCollection", "CreateOrUpdate", true)]
        [TestCase("ManagementGroupPolicyDefinitionCollection", "Get", true)]
        [TestCase("ManagementGroupPolicyDefinitionCollection", "CreateOrUpdateAtManagementGroup", false)]
        [TestCase("ManagementGroupPolicyDefinitionCollection", "GetAtManagementGroup", false)]
        [TestCase("ManagementGroupPolicyDefinitionCollection", "GetBuiltIn", false)]
        [TestCase("ManagementGroupPolicyDefinitionResource", "Get", true)]
        [TestCase("ManagementGroupPolicyDefinitionResource", "GetAtManagementGroup", false)]
        [TestCase("ManagementGroupPolicyDefinitionResource", "GetBuiltIn", false)]
        [TestCase("ManagementGroupPolicyDefinitionResource", "Delete", true)]
        [TestCase("ManagementGroupPolicyDefinitionResource", "DeleteAtManagementGroup", false)]
        public void ValidateExtensionResourceMethods(string className, string methodName, bool exist)
        {
            var managementGroupExtensions = Assembly.GetExecutingAssembly().GetType("MgmtExtensionResource.ManagementGroupExtensions");
            var subscriptionExtensions = Assembly.GetExecutingAssembly().GetType("MgmtExtensionResource.SubscriptionExtensions");
            var resourceGroupExtensions = Assembly.GetExecutingAssembly().GetType("MgmtExtensionResource.ResourceGroupExtensions");
            var classesToCheck = FindAllCollections().Concat(FindAllResources()).Append(managementGroupExtensions).Append(subscriptionExtensions).Append(resourceGroupExtensions);
            var classToCheck = classesToCheck.First(t => t.Name == className);
            Assert.AreEqual(exist, classToCheck.GetMethod(methodName) != null, $"can{(exist ? "not" : string.Empty)} find {className}.{methodName}");
        }
    }
}
