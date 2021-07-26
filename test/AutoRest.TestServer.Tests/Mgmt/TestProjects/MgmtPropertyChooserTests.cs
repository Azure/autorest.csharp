using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Azure.ResourceManager.Resources.Models;
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

        [TestCase]
        public void ValidateIdentityWithRenamedProperty()
        {
            var resourceOpreations = Assembly.GetExecutingAssembly().GetType("MgmtPropertyChooser.IdentityWithRenamedProperty");
            var properties = resourceOpreations.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var principalIdProperty = properties[0];
            Assert.NotNull(principalIdProperty);
            Assert.AreEqual("TestPrincipalId", principalIdProperty.Name);
            Assert.AreEqual(typeof(string), principalIdProperty.PropertyType);

            var tenantIdProperty = properties[1];
            Assert.NotNull(tenantIdProperty);
            Assert.AreEqual("TenantId", tenantIdProperty.Name);
            Assert.AreEqual(typeof(string), tenantIdProperty.PropertyType);

            var userAssignedProperty = properties[3];
            Assert.NotNull(userAssignedProperty);
            Assert.AreEqual("UserAssignedIdentities", userAssignedProperty.Name);
            Assert.AreEqual(typeof(IDictionary<string, Components135Hp51SchemasIdentitywithrenamedpropertyPropertiesUserassignedidentitiesAdditionalproperties>), userAssignedProperty.PropertyType);
        }

        [TestCase]
        public void ValidateIdentityWithRenamedPropertyNotReplaced()
        {
            var resourceOpreations = Assembly.GetExecutingAssembly().GetType("MgmtPropertyChooser.VirtualMachineData");
            var properties = resourceOpreations.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            Assert.IsTrue(properties.Any(p => p.Name == "IdentityWithRenamedProperty"));
            Assert.IsTrue(properties.Any(p => p.PropertyType == typeof(IdentityWithRenamedProperty)));
        }

        [TestCase]
        public void ValidateIdentityWithDifferentPropertyType()
        {
            var resourceOpreations = Assembly.GetExecutingAssembly().GetType("MgmtPropertyChooser.IdentityWithDifferentPropertyType");
            var properties = resourceOpreations.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var principalIdProperty = properties[0];
            Assert.NotNull(principalIdProperty);
            Assert.AreEqual("PrincipalId", principalIdProperty.Name);
            Assert.AreEqual(typeof(string), principalIdProperty.PropertyType);

            var tenantIdProperty = properties[1];
            Assert.NotNull(tenantIdProperty);
            Assert.AreEqual("TenantId", tenantIdProperty.Name);
            Assert.AreEqual(typeof(int?), tenantIdProperty.PropertyType);

            var userAssignedProperty = properties[3];
            Assert.NotNull(userAssignedProperty);
            Assert.AreEqual("UserAssignedIdentities", userAssignedProperty.Name);
            Assert.AreEqual(typeof(IDictionary<string, ComponentsTq4QocSchemasIdentitywithdifferentpropertytypePropertiesUserassignedidentitiesAdditionalproperties>), userAssignedProperty.PropertyType);
        }

        [TestCase]
        public void ValidateIdentityWithDifferentPropertyTypeNotReplaced()
        {
            var resourceOpreations = Assembly.GetExecutingAssembly().GetType("MgmtPropertyChooser.VirtualMachineData");
            var properties = resourceOpreations.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            Assert.IsTrue(properties.Any(p => p.Name == "IdentityWithDifferentPropertyType"));
            Assert.IsTrue(properties.Any(p => p.PropertyType == typeof(IdentityWithDifferentPropertyType)));
        }

        [TestCase]
        public void ValidateIdentityWithNoUserIdentity()
        {
            var resourceOpreations = Assembly.GetExecutingAssembly().GetType("MgmtPropertyChooser.IdentityWithNoUserIdentity");
            var properties = resourceOpreations.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var principalIdProperty = properties[0];
            Assert.NotNull(principalIdProperty);
            Assert.AreEqual("PrincipalId", principalIdProperty.Name);
            Assert.AreEqual(typeof(string), principalIdProperty.PropertyType);

            var tenantIdProperty = properties[1];
            Assert.NotNull(tenantIdProperty);
            Assert.AreEqual("TenantId", tenantIdProperty.Name);
            Assert.AreEqual(typeof(string), tenantIdProperty.PropertyType);

            Assert.IsFalse(properties.Any(p => p.Name == "UserAssignedIdentities"));
        }

        [TestCase]
        public void ValidateIdentityWithNoUserIdentityNotReplaced()
        {
            var resourceOpreations = Assembly.GetExecutingAssembly().GetType("MgmtPropertyChooser.VirtualMachineData");
            var properties = resourceOpreations.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            Assert.IsTrue(properties.Any(p => p.Name == "IdentityWithNoUserIdentity"));
            Assert.IsTrue(properties.Any(p => p.PropertyType == typeof(IdentityWithNoUserIdentity)));
        }

        [TestCase]
        public void ValidateIdentityWithNoSystemIdentity()
        {
            var resourceOpreations = Assembly.GetExecutingAssembly().GetType("MgmtPropertyChooser.IdentityWithNoSystemIdentity");
            var properties = resourceOpreations.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            Assert.IsFalse(properties.Any(p => p.Name == "PrincipalId"));
            Assert.IsFalse(properties.Any(p => p.Name == "TenantId"));

            var userAssignedProperty = properties[1];
            Assert.NotNull(userAssignedProperty);
            Assert.AreEqual("UserAssignedIdentities", userAssignedProperty.Name);
            Assert.AreEqual(typeof(IDictionary<string, ComponentsX9YfnoSchemasIdentitywithnosystemidentityPropertiesUserassignedidentitiesAdditionalproperties>), userAssignedProperty.PropertyType);
        }

        [TestCase]
        public void ValidateIdentityWithNoSystemIdentityNotReplaced()
        {
            var resourceOpreations = Assembly.GetExecutingAssembly().GetType("MgmtPropertyChooser.VirtualMachineData");
            var properties = resourceOpreations.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            Assert.IsTrue(properties.Any(p => p.Name == "IdentityWithNoSystemIdentity"));
            Assert.IsTrue(properties.Any(p => p.PropertyType == typeof(IdentityWithNoSystemIdentity)));
        }
    }
}
