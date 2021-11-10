using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    public class MgmtExtensionResourceTests : TestProjectTests
    {
        public MgmtExtensionResourceTests() : base("MgmtExtensionResource") { }

        [TestCase("ManagementGroupExtensions", "GetPolicyDefinitions", true)]
        [TestCase("SubscriptionExtensions", "GetPolicyDefinitions", true)]
        [TestCase("ResourceGroupExtensions", "GetPolicyDefinitions", false)]
        [TestCase("PolicyDefinitionCollection", "CreateOrUpdate", true)]
        [TestCase("PolicyDefinitionCollection", "Get", true)]
        [TestCase("PolicyDefinitionCollection", "CreateOrUpdateAtManagementGroup", false)]
        [TestCase("PolicyDefinitionCollection", "GetAtManagementGroup", false)]
        [TestCase("PolicyDefinitionCollection", "GetBuiltIn", false)]
        [TestCase("PolicyDefinition", "Get", true)]
        [TestCase("PolicyDefinition", "GetAtManagementGroup", false)]
        [TestCase("PolicyDefinition", "GetBuiltIn", false)]
        [TestCase("PolicyDefinition", "Delete", true)]
        [TestCase("PolicyDefinition", "DeleteAtManagementGroup", false)]
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
