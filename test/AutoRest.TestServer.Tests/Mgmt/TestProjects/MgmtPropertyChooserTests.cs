using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Azure.ResourceManager.Resources.Models;
using MgmtPropertyChooser;
using MgmtPropertyChooser.Models;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    public class MgmtPropertyChooserTests : TestProjectTests
    {
        public MgmtPropertyChooserTests() : base("MgmtPropertyChooser") { }

        [TestCase]
        public void ValidateModelUsingUserIdentities()
        {
            var resourceOpreations = Assembly.GetExecutingAssembly().GetType("MgmtPropertyChooser.Models.IdentityWithDifferentPropertyType");
            var properties = resourceOpreations.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var userAssignedProperty = properties[3];
            Assert.NotNull(userAssignedProperty);
            Assert.AreEqual("UserAssignedIdentities", userAssignedProperty.Name);
            Assert.AreEqual(typeof(IDictionary<string, UserAssignedIdentity>), userAssignedProperty.PropertyType);

            var keyType = userAssignedProperty.PropertyType.GetGenericArguments()[0];
            Assert.AreEqual(typeof(string), keyType);
            var valueType = userAssignedProperty.PropertyType.GetGenericArguments()[1];
            Assert.AreEqual(typeof(UserAssignedIdentity), valueType);

            var valueProperties = valueType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var principalIdProperty = valueProperties[1];
            Assert.NotNull(principalIdProperty);
            Assert.AreEqual("PrincipalId", principalIdProperty.Name);
            Assert.AreEqual(typeof(Guid), principalIdProperty.PropertyType);

            var clientIdProperty = valueProperties[0];
            Assert.NotNull(clientIdProperty);
            Assert.AreEqual("ClientId", clientIdProperty.Name);
            Assert.AreEqual(typeof(Guid), clientIdProperty.PropertyType);
        }

        [TestCase]
        public void ValidateModelUsingErrorResponse()
        {
            var cloudErrorModel = Assembly.GetExecutingAssembly().GetType("MgmtPropertyChooser.Models.CloudError");
            var properties = cloudErrorModel.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var errorResponseModel = Assembly.GetExecutingAssembly().GetType("MgmtPropertyChooser.Models.ErrorResponse");
            Assert.Null(errorResponseModel);
            var errorProperty = properties[0];
            Assert.NotNull(errorProperty);
            Assert.AreEqual("Error", errorProperty.Name);
            Assert.AreEqual(typeof(ErrorResponse), errorProperty.PropertyType);

            var errorResponseWithAnotherNameModel = Assembly.GetExecutingAssembly().GetType("MgmtPropertyChooser.Models.ErrorResponseWithAnotherName");
            Assert.Null(errorResponseWithAnotherNameModel);
            var anotherErrorProperty = properties[1];
            Assert.NotNull(anotherErrorProperty);
            Assert.AreEqual("AnotherError", anotherErrorProperty.Name);
            Assert.AreEqual(typeof(ErrorResponse), anotherErrorProperty.PropertyType);
        }

        [TestCase]
        public void ValidatePropertyReplacement()
        {
            var resourceOpreations = Assembly.GetExecutingAssembly().GetType("MgmtPropertyChooser.VirtualMachineData");
            var properties = resourceOpreations.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            // VirtualMachineIdentity is replaced by ResourceIdentity, property name is unchanged, still called Identity.
            Assert.IsFalse(properties.Any(p => p.Name == "ResourceIdentity"));
            Assert.IsTrue(properties.Any(p => p.Name == "Identity"));
            Assert.IsTrue(properties.Any(p => p.PropertyType == typeof(ResourceIdentity)));
            // VirtualMachineIdentity is not generated
            var virtualMachineIdentityModel = Assembly.GetExecutingAssembly().GetType("MgmtPropertyChooser.Models.VirtualMachineIdentity");
            Assert.Null(virtualMachineIdentityModel);
        }

        [TestCase]
        public void ValidateIdentityWithRenamedProperty()
        {
            var resourceOpreations = Assembly.GetExecutingAssembly().GetType("MgmtPropertyChooser.Models.IdentityWithRenamedProperty");
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
            Assert.AreEqual(typeof(IDictionary<string, UserAssignedIdentity>), userAssignedProperty.PropertyType);
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
            var resourceOpreations = Assembly.GetExecutingAssembly().GetType("MgmtPropertyChooser.Models.IdentityWithDifferentPropertyType");
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
            Assert.AreEqual(typeof(IDictionary<string, UserAssignedIdentity>), userAssignedProperty.PropertyType);
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
            var resourceOpreations = Assembly.GetExecutingAssembly().GetType("MgmtPropertyChooser.Models.IdentityWithNoUserIdentity");
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
            var resourceOpreations = Assembly.GetExecutingAssembly().GetType("MgmtPropertyChooser.Models.IdentityWithNoSystemIdentity");
            var properties = resourceOpreations.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            Assert.IsFalse(properties.Any(p => p.Name == "PrincipalId"));
            Assert.IsFalse(properties.Any(p => p.Name == "TenantId"));

            var userAssignedProperty = properties[1];
            Assert.NotNull(userAssignedProperty);
            Assert.AreEqual("UserAssignedIdentities", userAssignedProperty.Name);
            Assert.AreEqual(typeof(IDictionary<string, UserAssignedIdentity>), userAssignedProperty.PropertyType);
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
