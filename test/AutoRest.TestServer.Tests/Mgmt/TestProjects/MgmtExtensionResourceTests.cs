using System;
using System.Linq;
using MgmtExpandResourceTypes.Models;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    public class MgmtExtensionResourceTests : TestProjectTests
    {
        public MgmtExtensionResourceTests() : base("MgmtExtensionResource") { }

        [TestCase("MgmtExtensionResourceExtensions", "GetManagementGroupPolicyDefinitions", true)]
        [TestCase("MgmtExtensionResourceExtensions", "GetSubscriptionPolicyDefinitions", true)]
        [TestCase("MgmtExtensionResourceExtensions", "GetPolicyDefinitions", false)]
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
            var classesToCheck = FindAllCollections().Concat(FindAllResources()).Append(FindExtensionClass());
            var classToCheck = classesToCheck.First(t => t.Name == className);
            Assert.AreEqual(exist, classToCheck.GetMethod(methodName) != null, $"can{(exist ? "not" : string.Empty)} find {className}.{methodName}");
        }

        [TestCase(typeof(MachineType), new string[] { "One", "Two", "Four" }, new int[] { 1, 2, 4 })]
        [TestCase(typeof(StorageType), new string[] { "StandardLRS", "StandardZRS", "StandardGRS" }, new int[] { 1, 2, 3 })]
        public void ValidateIntEnumValues(Type enumType, string[] expectedNames, int[] expectedValues)
        {
            var names = Enum.GetNames(enumType);
            Assert.AreEqual(expectedNames, names);

            for (int i = 0; i < expectedNames.Length; i++)
            {
                Assert.AreEqual(expectedValues[i], (int)Enum.Parse(enumType, expectedNames[i]));
            }
        }
    }
}
