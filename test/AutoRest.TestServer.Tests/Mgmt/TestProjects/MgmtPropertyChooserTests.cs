using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Azure.ResourceManager.Core;
using MgmtPropertyChooser;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    public class MgmtPropertyChooserTests : TestProjectTests
    {
        public MgmtPropertyChooserTests() : base("MgmtPropertyChooser") { }

        [TestCase]
        public void ValidateModelUsingSystemIdentities()
        {
            var resourceOpreations = Assembly.GetExecutingAssembly().GetType("MgmtPropertyChooser.VirtualMachineIdentity");
            var properties = resourceOpreations.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var principalIdProperty = properties[0];
            Assert.NotNull(principalIdProperty);
            Assert.AreEqual("PrincipalId", principalIdProperty.Name);
            Assert.AreEqual(typeof(string), principalIdProperty.PropertyType);

            var tenantIdProperty = properties[1];
            Assert.NotNull(tenantIdProperty);
            Assert.AreEqual("TenantId", tenantIdProperty.Name);
            Assert.AreEqual(typeof(string), tenantIdProperty.PropertyType);
        }

        [TestCase]
        public void ValidateModelUsingUserIdentities()
        {
            var resourceOpreations = Assembly.GetExecutingAssembly().GetType("MgmtPropertyChooser.VirtualMachineIdentity");
            var properties = resourceOpreations.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var userAssignedProperty = properties[3];
            Assert.NotNull(userAssignedProperty);
            Assert.AreEqual("UserAssignedIdentities", userAssignedProperty.Name);
            Assert.AreEqual(typeof(IDictionary<string, Components1H8M3EpSchemasVirtualmachineidentityPropertiesUserassignedidentitiesAdditionalproperties>), userAssignedProperty.PropertyType);

            var keyType = userAssignedProperty.PropertyType.GetGenericArguments()[0];
            Assert.AreEqual(typeof(string), keyType);
            var valueType = userAssignedProperty.PropertyType.GetGenericArguments()[1];
            Assert.AreEqual(typeof(Components1H8M3EpSchemasVirtualmachineidentityPropertiesUserassignedidentitiesAdditionalproperties), valueType);

            var valueProperties = valueType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var principalIdProperty = valueProperties[0];
            Assert.NotNull(principalIdProperty);
            Assert.AreEqual("PrincipalId", principalIdProperty.Name);
            Assert.AreEqual(typeof(string), principalIdProperty.PropertyType);

            var clientIdProperty = valueProperties[1];
            Assert.NotNull(clientIdProperty);
            Assert.AreEqual("ClientId", clientIdProperty.Name);
            Assert.AreEqual(typeof(string), clientIdProperty.PropertyType);
        }

        [TestCase]
        public void ValidatePropertyReplacement()
        {
            var resourceOpreations = Assembly.GetExecutingAssembly().GetType("MgmtPropertyChooser.VirtualMachineData");
            var properties = resourceOpreations.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            Assert.IsFalse(properties.Any(p => p.Name == "VirtualMachineIdentity"));
            Assert.IsFalse(properties.Any(p => p.PropertyType == typeof(VirtualMachineIdentity)));

            Assert.IsTrue(properties.Any(p => p.Name == "ResourceIdentity"));
            Assert.IsTrue(properties.Any(p => p.PropertyType == typeof(ResourceIdentity)));
        }
    }
}
