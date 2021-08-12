using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Utilities;
using AutoRest.TestServer.Tests.Mgmt.OutputLibrary;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    [Parallelizable(ParallelScope.All)]
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
        public void ValidateNoListMethods()
        {
            foreach (var type in MyTypes())
            {
                Assert.IsNull(type.GetMethods(BindingFlags.Public).FirstOrDefault(m => m.Name.StartsWith("List")));
            }
        }

        [Test]
        public void ValidateBaseClass()
        {
            foreach (var type in FindAllResources())
            {
                var expectedBaseOperationsType = typeof(ArmResource);
                Assert.AreEqual(expectedBaseOperationsType, type.BaseType);
            }
        }

        [TestCase("GetAvailableLocations")]
        [TestCase("GetAvailableLocationsAsync")]
        public void ValidateListAvailableLocationsMethodExists(string methodName)
        {
            foreach (var type in FindAllResources())
            {
                if (IsSingletonOperation(type))
                {
                    continue;
                }

                var method = type.GetMethod(methodName);
                Assert.NotNull(method, $"{type.Name} does not implement the method.");
            }
        }

        [TestCase("Get")]
        [TestCase("GetAsync")]
        public void ValidateGetMethodExists(string methodName)
        {
            foreach (var type in FindAllResources())
            {
                if (IsSingletonOperation(type))
                {
                    continue;
                }

                MethodInfo[] methods = type.GetMethods();
                var getMethods = methods.Where(m => m.Name == methodName);
                Assert.NotNull(getMethods, $"{type.Name} does not implement the {methodName} method.");
            }
        }

        [TestCase("AddTag")]
        [TestCase("AddTagAsync")]
        public void ValidateAddTagMethod(string methodName)
        {
            foreach (var type in FindAllResources())
            {
                var resourceData = GetResourceDataByResource(type);
                if (!IsInheritFromTrackedResource(resourceData))
                {
                    continue;
                }

                var method = type.GetMethod(methodName);
                Assert.NotNull(method, $"{type.Name} does not implement the {methodName} method.");

                Assert.AreEqual(3, method.GetParameters().Length);
                var param1 = TypeAsserts.HasParameter(method, "key");
                Assert.AreEqual(typeof(string), param1.ParameterType);
                var param2 = TypeAsserts.HasParameter(method, "value");
                Assert.AreEqual(typeof(string), param2.ParameterType);
                var param3 = TypeAsserts.HasParameter(method, "cancellationToken");
                Assert.AreEqual(typeof(CancellationToken), param3.ParameterType);
            }
        }

        [TestCase("SetTags")]
        [TestCase("SetTagsAsync")]
        public void ValidateSetTagsMethod(string methodName)
        {
            foreach (var type in FindAllResources())
            {
                var resourceData = GetResourceDataByResource(type);
                if (!IsInheritFromTrackedResource(resourceData))
                {
                    continue;
                }

                var method = type.GetMethod(methodName);
                Assert.NotNull(method, $"{type.Name} does not implement the {methodName} method.");

                Assert.AreEqual(2, method.GetParameters().Length);
                var param1 = TypeAsserts.HasParameter(method, "tags");
                Assert.AreEqual(typeof(IDictionary<string, string>), param1.ParameterType);
                var param2 = TypeAsserts.HasParameter(method, "cancellationToken");
                Assert.AreEqual(typeof(CancellationToken), param2.ParameterType);
            }
        }

        [TestCase("RemoveTag")]
        [TestCase("RemoveTagAsync")]
        public void ValidateRemoveTagMethod(string methodName)
        {
            foreach (var type in FindAllResources())
            {
                var resourceData = GetResourceDataByResource(type);
                if (!IsInheritFromTrackedResource(resourceData))
                {
                    continue;
                }

                var method = type.GetMethod(methodName);
                Assert.NotNull(method, $"{type.Name} does not implement the {methodName} method.");

                Assert.AreEqual(2, method.GetParameters().Length);
                var param1 = TypeAsserts.HasParameter(method, "key");
                Assert.AreEqual(typeof(string), param1.ParameterType);
                var param2 = TypeAsserts.HasParameter(method, "cancellationToken");
                Assert.AreEqual(typeof(CancellationToken), param2.ParameterType);
            }
        }

        private Type GetResourceDataByResource(Type resourceType)
        {
            // the name of resource data is not just simply appending a `Data` after the resource name
            // we have the special cases like extension resource, in this case, we may have multiple resources with different name, but the same resource data
            // therefore here we are finding the type of the resource, and get the type of its `Data` property
            var resourceData = resourceType.GetProperty("Data")?.PropertyType;
            return resourceData;
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

            var scopeResourceContainers = new HashSet<string> { "PolicyAssignmentContainer" };
            foreach (var type in FindAllContainers())
            {
                var resourceName = type.Name.Remove(type.Name.LastIndexOf("Container"));
                ResourceType resourceType = GetContainerValidResourceType(type);
                if (resourceType.Equals(ResourceGroup.ResourceType))
                {
                    var getContainerMethod = resourceExtensions.GetMethod($"Get{resourceName}".ToPlural());
                    Assert.NotNull(getContainerMethod);
                    Assert.AreEqual(1, getContainerMethod.GetParameters().Length);
                    var param = TypeAsserts.HasParameter(getContainerMethod, "resourceGroup");
                    Assert.AreEqual(typeof(ResourceGroup), param.ParameterType);
                }
            }
        }

        public IEnumerable<Type> FindAllResources()
        {
            Type[] allTypes = Assembly.GetExecutingAssembly().GetTypes();

            foreach (Type t in allTypes)
            {
                var resourceNames = FindAllResourceNames();
                if (resourceNames.Contains(t.Name) && t.Namespace == _projectName)
                {
                    // Only [Resource] types for the specified test project are going to be tested.
                    yield return t;
                }
            }
        }

        private IEnumerable<string> FindAllResourceNames()
        {
            Type[] allTypes = Assembly.GetExecutingAssembly().GetTypes();

            foreach (Type t in allTypes)
            {
                if (t.Name.EndsWith("Data") && !t.Name.Contains("Tests") && t.Namespace == _projectName)
                {
                    // Only [Resource] types names for the specified test project are going to be tested.
                    var resourceName = t.Name.Replace("Data", string.Empty);
                    yield return resourceName;
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

        public IEnumerable<Type> FindAllContainers()
        {
            Type[] allTypes = Assembly.GetExecutingAssembly().GetTypes();

            foreach (Type t in allTypes)
            {
                if (t.Name.EndsWith("Container") && !t.Name.Contains("Tests") && t.Namespace == _projectName)
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

        private bool IsSingletonOperation(Type type)
        {
            var propertyInfo = type.GetProperty("Parent", BindingFlags.Instance | BindingFlags.Public);
            if (propertyInfo == null)
                return false;
            return type.BaseType == typeof(ArmResource) && propertyInfo.PropertyType == typeof(ArmResource);
        }

        private bool IsInheritFromTrackedResource(Type type)
        {
            return type.BaseType.Name == typeof(TrackedResource).Name;
        }

        protected Type FindSubscriptionExtensions()
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

                if (resourceType.Equals(Subscription.ResourceType))
                {
                    var methodInfo = subscriptionExtension.GetMethod($"Get{resourceName.ToPlural()}", BindingFlags.Static | BindingFlags.Public);
                    Assert.NotNull(methodInfo);
                    Assert.AreEqual(1, methodInfo.GetParameters().Length);
                    var param = TypeAsserts.HasParameter(methodInfo, "subscription");
                    Assert.AreEqual(typeof(Subscription), param.ParameterType);
                }
            }
        }

        private Type GetResourceRestOperationsType(Type containerType)
        {
            var containerObj = Activator.CreateInstance(containerType, true);
            return containerObj.GetType().GetField("_restClient", BindingFlags.NonPublic | BindingFlags.Instance).FieldType;
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

                var restOperation = GetResourceRestOperationsType(type);
                var listAllMethod = restOperation.GetMethod("ListAll");
                var listBySubscriptionMethod = restOperation.GetMethod("ListBySubscription");

                if (!resourceType.Equals(Subscription.ResourceType) &&
                   (listAllMethod != null || listBySubscriptionMethod != null))
                {
                    var listMethodInfo = subscriptionExtension.GetMethod($"List{resourceName}s", BindingFlags.Static | BindingFlags.Public);
                    Assert.NotNull(listMethodInfo);
                    Assert.True(listMethodInfo.GetParameters().Length >= 2);
                    var listParam1 = TypeAsserts.HasParameter(listMethodInfo, "subscription");
                    Assert.AreEqual(typeof(Subscription), listParam1.ParameterType);
                    var listParam2 = TypeAsserts.HasParameter(listMethodInfo, "cancellationToken");
                    Assert.AreEqual(typeof(CancellationToken), listParam2.ParameterType);

                    var listAsyncMethodInfo = subscriptionExtension.GetMethod($"List{resourceName}sAsync", BindingFlags.Static | BindingFlags.Public);
                    Assert.NotNull(listAsyncMethodInfo);
                    Assert.True(listMethodInfo.GetParameters().Length >= 2);
                    var listAsyncParam1 = TypeAsserts.HasParameter(listAsyncMethodInfo, "subscription");
                    Assert.AreEqual(typeof(Subscription), listAsyncParam1.ParameterType);
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

                var restOperation = GetResourceRestOperationsType(type);
                var listBySubscriptionMethod = restOperation.GetMethod("GetBySubscription");

                if (!resourceType.Equals(Subscription.ResourceType) &&
                    listBySubscriptionMethod != null)
                {
                    var listByNameMethodInfo = subscriptionExtension.GetMethod($"Get{resourceName}ByName", BindingFlags.Static | BindingFlags.Public);
                    Assert.NotNull(listByNameMethodInfo);
                    Assert.GreaterOrEqual(listByNameMethodInfo.GetParameters().Length, 1);
                    var listByNameParam5 = TypeAsserts.HasParameter(listByNameMethodInfo, "cancellationToken");
                    Assert.AreEqual(typeof(CancellationToken), listByNameParam5.ParameterType);

                    var listByNameAsyncMethodInfo = subscriptionExtension.GetMethod($"Get{resourceName}ByNameAsync", BindingFlags.Static | BindingFlags.Public);
                    Assert.NotNull(listByNameAsyncMethodInfo);
                    Assert.GreaterOrEqual(listByNameAsyncMethodInfo.GetParameters().Length, 1);
                    var listByNameAsyncParam5 = TypeAsserts.HasParameter(listByNameAsyncMethodInfo, "cancellationToken");
                    Assert.AreEqual(typeof(CancellationToken), listByNameAsyncParam5.ParameterType);
                }
            }
        }

        [Test]
        public void ValidateParentResourceOperation()
        {
            foreach (var operation in FindAllResources())
            {
                var operationTypeProperty = operation.GetField("ResourceType");
                ResourceType operationType = operationTypeProperty.GetValue(operation) as ResourceType;
                foreach (var container in FindAllContainers())
                {
                    ResourceType containerType = GetContainerValidResourceType(container);
                    if (containerType.Equals(operationType))
                    {
                        var name = container.Name.Remove(container.Name.LastIndexOf("Container"));
                        var method = operation.GetMethod($"Get{name.ToPlural()}");
                        Assert.NotNull(method);
                        Assert.IsTrue(method.ReturnParameter.ToString().Trim().Equals(container.Namespace + "." + container.Name));
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

            if (generatedModel.GetCustomAttributes(false).Any(a => a.GetType().Name == ReferenceClassFinder.ReferenceTypeAttributeName))
            {
                var ctors = generatedModel.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                var attrCtors = ctors.Where(c => HasInitializationAttribute(c));
                return attrCtors.FirstOrDefault();
            }

            foreach (var ctor in generatedModel.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
            {
                if (ctor.GetParameters().Length < (leastParamCtor == null ? int.MaxValue : leastParamCtor.GetParameters().Length))
                    leastParamCtor = ctor;
            }
            return leastParamCtor;
        }

        private bool HasInitializationAttribute(ConstructorInfo c)
        {
            return c.GetCustomAttributes(false).Any(c => c.GetType().Name == ReferenceClassFinder.InitializationCtorAttributeName);
        }

        protected void ValidatePublicCtor(Type model, string[] paramNames, Type[] paramTypes)
        {
            var ctors = model.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
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
