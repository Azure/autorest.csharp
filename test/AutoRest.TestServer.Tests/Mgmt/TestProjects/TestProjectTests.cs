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

        [Ignore("TODO ADO item 1111")]
        [Test]
        public void ValidateResourceGroupExtensions()
        {
            if (_projectName.Equals(""))
            {
                return;
            }
            Type[] allTypes = Assembly.GetExecutingAssembly().GetTypes();

            Type resourceExtensions = allTypes.FirstOrDefault(t => t.Name == "ResourceGroupExtensions" && t.Namespace == _projectName);
            Assert.NotNull(resourceExtensions);

            var resourceType = ResourceGroupOperations.ResourceType;
            foreach (var type in FindAllContainers())
            {
                var obj = Activator.CreateInstance(resourceExtensions.Assembly.FullName, type.Name, true,
                    BindingFlags.CreateInstance | BindingFlags.NonPublic, null, null, CultureInfo.CurrentCulture, null);
                var validResourceType = obj.GetType().GetProperty("ValidResourceType").GetValue(obj) as string;
                if (resourceType.Equals(validResourceType))
                {
                    var getContainerMethod = resourceExtensions.GetMethod($"Get{type.Name.Substring(0, type.Name.IndexOf("Container"))}s");
                    Assert.NotNull(getContainerMethod);
                }
                else
                {
                    var getContainerMethod = resourceExtensions.GetMethod($"Get{type.Name.Substring(0, type.Name.IndexOf("Container"))}s");
                    Assert.IsNull(getContainerMethod);
                }
            }
        }

        private IEnumerable<Type> FindAllContainers()
        {
            Type[] allTypes = Assembly.GetExecutingAssembly().GetTypes();

            foreach (Type t in allTypes)
            {
                if (t.Name.Contains("Containers") && !t.Name.Contains("Tests") && t.Namespace == _projectName)
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
    }
}
