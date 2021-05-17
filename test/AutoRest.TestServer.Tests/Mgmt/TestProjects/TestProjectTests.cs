using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.TestServer.Tests.Mgmt.OutputLibrary;
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
                if (type.Namespace == _projectName || type.Namespace == _projectName + ".Models")
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
            if (_projectName.Equals(""))
            {
                return;
            }

            Type[] allTypes = Assembly.GetExecutingAssembly().GetTypes();
            Type resourceExtensions = allTypes.FirstOrDefault(t => t.Name == "ResourceGroupExtensions" && t.Namespace == _projectName);
            Assert.NotNull(resourceExtensions);

            foreach (var type in FindAllContainers())
            {
                var resourceName = type.Name.Remove(type.Name.LastIndexOf("Container"));
                ResourceType resourceType = GetContainerValidResourceType(type);
                if (resourceType.Equals(ResourceGroupOperations.ResourceType))
                {
                    var getContainerMethod = resourceExtensions.GetMethod($"Get{resourceName}s");
                    Assert.NotNull(getContainerMethod);
                    Assert.AreEqual(1, getContainerMethod.GetParameters().Length);
                    var param = TypeAsserts.HasParameter(getContainerMethod, "resourceGroup");
                    Assert.AreEqual(typeof(ResourceGroupOperations), param.ParameterType);
                }
                else
                {
                    var getContainerMethod = resourceExtensions.GetMethod($"Get{resourceName}s");
                    Assert.IsNull(getContainerMethod);
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

        private IEnumerable<Type> FindAllRestOperations()
        {
            Type[] allTypes = Assembly.GetExecutingAssembly().GetTypes();

            foreach (Type t in allTypes)
            {
                if (t.Name.Contains("RestOperations") && !t.Name.Contains("Tests") && t.Namespace == _projectName)
                {
                    yield return t;
                }
            }
        }

        private Type FindSubscriptionExtensions()
        {
            Type[] allTypes = Assembly.GetExecutingAssembly().GetTypes();
            return allTypes.FirstOrDefault(t => t.Name == "SubscriptionExtensions" && !t.Name.Contains("Tests") && t.Namespace == _projectName);
        }

        private ResourceType GetContainerValidResourceType(Type containerType)
        {
            var containerObj = Activator.CreateInstance(containerType, true);
            var validResourceTypeProperty = containerObj.GetType().GetProperty("ValidResourceType", BindingFlags.NonPublic | BindingFlags.Instance);
            ResourceType resourceType = validResourceTypeProperty.GetValue(containerObj) as ResourceType;
            return resourceType;
        }

        [Test]
        public void ValidateSubscriptionExtensionsGetResourceContainer()
        {
            if (_projectName.Equals(""))
            {
                return;
            }

            Type subscriptionExtension = FindSubscriptionExtensions();
            Assert.NotNull(subscriptionExtension);

            foreach (Type type in FindAllContainers())
            {
                var resourceName = type.Name.Remove(type.Name.LastIndexOf("Container"));
                ResourceType resourceType = GetContainerValidResourceType(type);

                if (resourceType.Equals(SubscriptionOperations.ResourceType))
                {
                    var methodInfo = subscriptionExtension.GetMethod($"Get{resourceName}Container", BindingFlags.Static | BindingFlags.Public);
                    Assert.NotNull(methodInfo);
                    Assert.AreEqual(1, methodInfo.GetParameters().Length);
                    var param = TypeAsserts.HasParameter(methodInfo, "subscription");
                    Assert.AreEqual(typeof(SubscriptionOperations), param.ParameterType);
                }
            }
        }

        private Type GetResourceRestOperationsType(string resourceName)
        {
            // TODO: After the container class implemented, remove the hard coded rest operation class name and use this code to get the rest operation property from the container class.
            // var containerObj = Activator.CreateInstance(containerType, true);
            // var restOperationsType = containerObj.GetType().GetProperty("RestOperations", BindingFlags.NonPublic | BindingFlags.Instance).PropertyType;
            // return FindAllRestOperations().Where(t => t.Name == "{restOperationsType.Name}").Single();
            return FindAllRestOperations().Where(t => Regex.IsMatch(t.Name, $"{resourceName}\\S?RestOperations")).Single();
        }

        [Test]
        public void ValidateSubscriptionExtensionsListResource()
        {
            if (_projectName.Equals(""))
            {
                return;
            }

            Type subscriptionExtension = FindSubscriptionExtensions();
            Assert.NotNull(subscriptionExtension);

            foreach (Type type in FindAllContainers())
            {
                var resourceName = type.Name.Remove(type.Name.LastIndexOf("Container"));
                ResourceType resourceType = GetContainerValidResourceType(type);

                // TODO: Remove this if condition after the container class implementation is done to get the rest operation property
                if (_projectName == "ResourceRename")
                    return;

                var restOperation = GetResourceRestOperationsType(resourceName);
                var listAllMethod = restOperation.GetMethod("ListAll");
                var listBySubscriptionMethod = restOperation.GetMethod("ListBySubscription");

                if (!resourceType.Equals(SubscriptionOperations.ResourceType) &&
                   (listAllMethod != null || listBySubscriptionMethod != null))
                {
                    var listMethodInfo = subscriptionExtension.GetMethod($"List{resourceName}", BindingFlags.Static | BindingFlags.Public);
                    Assert.NotNull(listMethodInfo);
                    Assert.AreEqual(2, listMethodInfo.GetParameters().Length);
                    var listParam1 = TypeAsserts.HasParameter(listMethodInfo, "subscription");
                    Assert.AreEqual(typeof(SubscriptionOperations), listParam1.ParameterType);
                    var listParam2 = TypeAsserts.HasParameter(listMethodInfo, "cancellationToken");
                    Assert.AreEqual(typeof(CancellationToken), listParam2.ParameterType);

                    var listAsyncMethodInfo = subscriptionExtension.GetMethod($"List{resourceName}Async", BindingFlags.Static | BindingFlags.Public);
                    Assert.NotNull(listAsyncMethodInfo);
                    Assert.AreEqual(2, listAsyncMethodInfo.GetParameters().Length);
                    var listAsyncParam1 = TypeAsserts.HasParameter(listAsyncMethodInfo, "subscription");
                    Assert.AreEqual(typeof(SubscriptionOperations), listAsyncParam1.ParameterType);
                    var listAsyncParam2 = TypeAsserts.HasParameter(listAsyncMethodInfo, "cancellationToken");
                    Assert.AreEqual(typeof(CancellationToken), listAsyncParam2.ParameterType);
                }
            }
        }

        [Test]
        public void ValidateSubscriptionExtensionsListResourceByName()
        {
            if (_projectName.Equals(""))
            {
                return;
            }

            Type subscriptionExtension = FindSubscriptionExtensions();
            Assert.NotNull(subscriptionExtension);

            foreach (Type type in FindAllContainers())
            {
                var resourceName = type.Name.Remove(type.Name.LastIndexOf("Container"));
                ResourceType resourceType = GetContainerValidResourceType(type);

                // TODO: Remove this if condition after the container class implementation is done to get the rest operation property
                if (_projectName == "ResourceRename")
                    return;

                var restOperation = GetResourceRestOperationsType(resourceName);
                var listAllMethod = restOperation.GetMethod("ListAll");
                var listBySubscriptionMethod = restOperation.GetMethod("ListBySubscription");

                if (!resourceType.Equals(SubscriptionOperations.ResourceType) &&
                   (listAllMethod != null || listBySubscriptionMethod != null))
                {
                    var listByNameMethodInfo = subscriptionExtension.GetMethod($"List{resourceName}ByName", BindingFlags.Static | BindingFlags.Public);
                    Assert.NotNull(listByNameMethodInfo);
                    Assert.AreEqual(4, listByNameMethodInfo.GetParameters().Length);
                    var listByNameParam1 = TypeAsserts.HasParameter(listByNameMethodInfo, "subscription");
                    Assert.AreEqual(typeof(SubscriptionOperations), listByNameParam1.ParameterType);
                    var listByNameParam2 = TypeAsserts.HasParameter(listByNameMethodInfo, "filter");
                    Assert.AreEqual(typeof(string), listByNameParam2.ParameterType);
                    var listByNameParam3 = TypeAsserts.HasParameter(listByNameMethodInfo, "top");
                    Assert.AreEqual(typeof(int?), listByNameParam3.ParameterType);
                    var listByNameParam4 = TypeAsserts.HasParameter(listByNameMethodInfo, "cancellationToken");
                    Assert.AreEqual(typeof(CancellationToken), listByNameParam4.ParameterType);

                    var listByNameAsyncMethodInfo = subscriptionExtension.GetMethod($"List{resourceName}ByNameAsync", BindingFlags.Static | BindingFlags.Public);
                    Assert.NotNull(listByNameAsyncMethodInfo);
                    Assert.AreEqual(4, listByNameAsyncMethodInfo.GetParameters().Length);
                    var listByNameAsyncParam1 = TypeAsserts.HasParameter(listByNameAsyncMethodInfo, "subscription");
                    Assert.AreEqual(typeof(SubscriptionOperations), listByNameAsyncParam1.ParameterType);
                    var listByNameAsyncParam2 = TypeAsserts.HasParameter(listByNameAsyncMethodInfo, "filter");
                    Assert.AreEqual(typeof(string), listByNameAsyncParam2.ParameterType);
                    var listByNameAsyncParam3 = TypeAsserts.HasParameter(listByNameAsyncMethodInfo, "top");
                    Assert.AreEqual(typeof(int?), listByNameAsyncParam3.ParameterType);
                    var listByNameAsyncParam4 = TypeAsserts.HasParameter(listByNameAsyncMethodInfo, "cancellationToken");
                    Assert.AreEqual(typeof(CancellationToken), listByNameAsyncParam4.ParameterType);
                }
            }
        }

        [Test]
        public void ValidateParentResourceOperation()
        {
            foreach (var operation in FindAllOperations())
            {
                var operationTypeProperty = operation.GetField("ResourceType");
                ResourceType operationType = operationTypeProperty.GetValue(operation) as ResourceType;
                foreach (var container in FindAllContainers())
                {
                    ResourceType containerType = GetContainerValidResourceType(container);
                    if (containerType.Equals(operationType))
                    {
                        var method = operation.GetMethod($"Get{container.Name.Remove(container.Name.LastIndexOf("Container"))}");
                        Assert.NotNull(method);
                        Assert.IsTrue(method.ReturnParameter.ToString().Trim().Equals(container.Namespace+"."+container.Name));
                        Assert.IsTrue(method.GetParameters().Count() == 0);
                    }
                }
            }
        }

        [Test]
        public async Task ValidateRequiredParamsInCtor()
        {
            if (_projectName.Equals(""))
            {
                return;
            }

            var output = await OutputLibraryTestBase.Generate(_projectName);
            var library = output.Context.Library;
            foreach (var mgmtObject in library.Models.OfType<MgmtObjectType>())
            {
                ValidateModelRequiredCtorParams(mgmtObject.ObjectSchema);
            }
            foreach (var resourceData in library.ResourceData)
            {
                ValidateModelRequiredCtorParams(resourceData.ObjectSchema);
            }
        }

        private void ValidateModelRequiredCtorParams(ObjectSchema objectSchema)
        {
            var requiredParams = objectSchema.Properties.Where(p => p.Schema is not ConstantSchema && p.Required.HasValue && p.Required.Value);

            Type generatedModel = GetType(objectSchema.Name + "Data") ?? GetType(objectSchema.Name);
            Assert.NotNull(generatedModel, $"Generated type not found for {objectSchema.Name}");
            ConstructorInfo leastParamCtor = GetLeastParamCtor(generatedModel);
            ConstructorInfo baseLeastParamCtor = GetLeastParamCtor(generatedModel.BaseType);
            var fullRequiredParams = requiredParams.Select(p => p.SerializedName).Concat(baseLeastParamCtor?.GetParameters().Select(p => p.Name)).Distinct();
            Assert.NotNull(leastParamCtor, $"Ctor not found for {objectSchema.Name}");
            Assert.AreEqual(fullRequiredParams.Count(), leastParamCtor.GetParameters().Length, $"{objectSchema.Name} had a mismatch in required ctor params");
            foreach (var param in fullRequiredParams)
            {
                Assert.NotNull(leastParamCtor.GetParameters().FirstOrDefault(p => string.Equals(p.Name, param, StringComparison.InvariantCultureIgnoreCase)), $"{param} was not found in {objectSchema.Name}'s ctor");
            }
        }

        private ConstructorInfo GetLeastParamCtor(Type generatedModel)
        {
            ConstructorInfo leastParamCtor = null;

            if (generatedModel == null)
                return leastParamCtor;

            foreach (var ctor in generatedModel.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
            {
                if (ctor.GetParameters().Length < (leastParamCtor == null ? int.MaxValue : leastParamCtor.GetParameters().Length))
                    leastParamCtor = ctor;
            }
            return leastParamCtor;
        }

        protected void ValidatePublicCtor(Type model, string[] paramNames, Type[] paramTypes)
        {
            var ctors = model.GetConstructors(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            Assert.AreEqual(1, ctors.Length);
            var ctor = ctors.First();
            var parameters = ctor.GetParameters();
            for (int i = 0; i < parameters.Length; i++)
            {
                Assert.AreEqual(paramNames[i], parameters[i].Name);
                Assert.AreEqual(paramTypes[i], parameters[i].ParameterType);
            }
        }
    }
}
