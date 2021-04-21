using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Azure.ResourceManager.Core;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    public class TestProjectTests
    {
        private string _projectName;

        public TestProjectTests() : this("")
        {
        }

        public TestProjectTests(string projectName)
        {
            _projectName = projectName;
        }

        protected IEnumerable<Type> MyTypes()
        {
            foreach (var type in GetType().Assembly.GetTypes())
            {
                if (type.Namespace == _projectName)
                    yield return type;
            }
        }

        protected Type? GetType(string name) => MyTypes().FirstOrDefault(t => t.Name == name);

        [Test]
        public void ValidateBaseClass()
        {
            foreach (var type in FindAllOperations())
            {
                Assert.AreEqual(typeof(ResourceOperationsBase), type.BaseType.BaseType);
            }
        }

        [TestCase("ListAvailableLocations")]
        [TestCase("ListAvailableLocationsAsync")]
        public void ValidateMethodExists(string methodName)
        {
            foreach (var type in FindAllOperations())
            {
                var method = type.GetMethod(methodName);
                Assert.NotNull(method, $"{type.Name} does not implement the method.");
            }
        }

        [Test]
        public void ValidateResourceGroupExtensions()
        {
            Type[] allTypes = Assembly.GetExecutingAssembly().GetTypes();

            Type resourceExtensions = allTypes.FirstOrDefault(t => t.Name == "ResourceGroupExtensions" && t.Namespace == _projectName);
            Assert.NotNull(resourceExtensions);

            foreach (var type in FindAllContainers())
            {
                var resourceName = type.Name.Remove(type.Name.LastIndexOf("Container"));

                var containerObj = Activator.CreateInstance(type, true);
                var validResourceTypeProperty = containerObj.GetType().GetProperty("ValidResourceType", BindingFlags.NonPublic | BindingFlags.Instance);
                ResourceType resourceType = validResourceTypeProperty.GetValue(containerObj) as ResourceType;
                if (resourceType.Equals(ResourceGroupOperations.ResourceType))
                {
                    var getContainerMethod = resourceExtensions.GetMethod($"Get{resourceName}s");
                    Assert.NotNull(getContainerMethod);
                }
                else
                {
                    var getContainerMethod = resourceExtensions.GetMethod($"Get{resourceName}s");
                    Assert.IsNull(getContainerMethod);
                }
            }
        }

        private IEnumerable<Type> FindAllContainers()
        {
            Type[] allTypes = Assembly.GetExecutingAssembly().GetTypes();

            foreach (Type t in allTypes)
            {
                if (t.Name.Contains("Container") && !t.Name.Contains("Tests") && t.Namespace == _projectName)
                {
                    yield return t;
                }
            }
        }

        private IEnumerable<Type> FindAllOperations()
        {
            Type[] allTypes = Assembly.GetExecutingAssembly().GetTypes();

            foreach (Type t in allTypes)
            {
                if (t.Name.Contains("Operations") && !t.Name.Contains("RestOperations") && !t.Name.Contains("Tests") && t.Namespace == _projectName)
                {
                    // Only [Resource]Operations types for the specified test project are going to be tested.
                    yield return t;
                }
            }
        }

        [TestCase("ValidResourceType")]
        public void ValidateContainerPropertyExists(string propertyName)
        {
            foreach (var type in FindAllContainers())
            {
                var propertyInfo = type.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.NonPublic);
                Assert.NotNull(propertyInfo, $"Property '{type.Name}' is not found");
                Assert.AreEqual(typeof(ResourceType), propertyInfo.PropertyType);
            }
        }
    }
}
