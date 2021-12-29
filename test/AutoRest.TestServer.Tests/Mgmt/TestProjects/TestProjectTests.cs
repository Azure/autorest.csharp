﻿using System;
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
using Azure;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    [Parallelizable(ParallelScope.All)]
    public class TestProjectTests
    {
        private string _projectName;
        private string? _subFolder;

        public TestProjectTests() : this("")
        {
        }

        public TestProjectTests(string projectName, string subFolder = null)
        {
            _projectName = projectName;
            _subFolder = subFolder;
        }

        protected HashSet<string> ListExceptions = new HashSet<string>();

        protected virtual IEnumerable<Type> MyTypes()
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

            Type resourceExtensions = FindResourceGroupExtensions();
            Assert.NotNull(resourceExtensions);

            foreach (var type in FindAllCollections())
            {
                var resourceName = type.Name.Remove(type.Name.LastIndexOf("Collection"));
                ResourceType resourceType = GetCollectionValidResourceType(type);
                if (resourceType.Equals(ResourceGroup.ResourceType))
                {
                    var getCollectionMethod = resourceExtensions.GetMethod($"Get{resourceName}".ToPlural());
                    Assert.NotNull(getCollectionMethod);
                    Assert.AreEqual(1, getCollectionMethod.GetParameters().Length);
                    var param = TypeAsserts.HasParameter(getCollectionMethod, "resourceGroup");
                    Assert.AreEqual(typeof(ResourceGroup), param.ParameterType);
                }
            }
        }

        public IEnumerable<Type> FindAllResources()
        {
            Type[] allTypes = Assembly.GetExecutingAssembly().GetTypes();

            foreach (Type t in allTypes)
            {
                if (t.BaseType.FullName == typeof(ArmResource).FullName && !t.Name.Contains("Tests") && t.Namespace == _projectName)
                {
                    yield return t;
                }
            }
        }

        [TestCase("ValidResourceType")]
        public void ValidateCollectionPropertyExists(string propertyName)
        {
            foreach (var type in FindAllCollections())
            {
                var propertyInfo = type.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.NonPublic);
                Assert.NotNull(propertyInfo, $"Property '{type.Name}' is not found");
                Assert.AreEqual(typeof(ResourceType), propertyInfo.PropertyType);
            }
        }

        public IEnumerable<Type> FindAllCollections()
        {
            Type[] allTypes = Assembly.GetExecutingAssembly().GetTypes();

            foreach (Type t in allTypes)
            {
                if (t.BaseType.FullName == typeof(ArmCollection).FullName && !t.Name.Contains("Tests") && t.Namespace == _projectName)
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

        protected Type FindResourceGroupExtensions()
        {
            Type[] allTypes = Assembly.GetExecutingAssembly().GetTypes();
            return allTypes.FirstOrDefault(t => t.Name == "ResourceGroupExtensions" && !t.Name.Contains("Tests") && t.Namespace == _projectName);
        }

        protected Type FindSubscriptionExtensions()
        {
            Type[] allTypes = Assembly.GetExecutingAssembly().GetTypes();
            return allTypes.FirstOrDefault(t => t.Name == "SubscriptionExtensions" && !t.Name.Contains("Tests") && t.Namespace == _projectName);
        }

        private ResourceType GetCollectionValidResourceType(Type collectionType)
        {
            var collectionObj = Activator.CreateInstance(collectionType, true);
            var validResourceTypeProperty = collectionObj.GetType().GetProperty("ValidResourceType", BindingFlags.NonPublic | BindingFlags.Instance);
            ResourceType resourceType = validResourceTypeProperty.GetValue(collectionObj) as ResourceType;
            return resourceType;
        }

        [Test]
        public void ValidateSubscriptionExtensionsGetResourceCollection()
        {
            if (_projectName.Equals(""))
            {
                return;
            }

            Type subscriptionExtension = FindSubscriptionExtensions();
            Assert.NotNull(subscriptionExtension);

            foreach (Type type in FindAllCollections())
            {
                var resourceName = type.Name.Remove(type.Name.LastIndexOf("Collection"));
                ResourceType resourceType = GetCollectionValidResourceType(type);

                if (resourceType.Equals(Subscription.ResourceType))
                {
                    var methodInfo = subscriptionExtension.GetMethod($"Get{resourceName.ToPlural()}", BindingFlags.Static | BindingFlags.Public);
                    Assert.NotNull(methodInfo);
                    var param = TypeAsserts.HasParameter(methodInfo, "subscription");
                    Assert.AreEqual(typeof(Subscription), param.ParameterType);
                }
            }
        }

        private IEnumerable<Type> GetResourceRestOperationsTypes(Type collectionType)
        {
            var collectionObj = Activator.CreateInstance(collectionType, true);
            return collectionObj.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Where(f => f.Name.EndsWith("RestClient") || f.Name == "_restClient").Select(f => f.FieldType);
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

            foreach (Type type in FindAllCollections())
            {
                var resourceName = type.Name.Remove(type.Name.LastIndexOf("Collection"));
                ResourceType resourceType = GetCollectionValidResourceType(type);

                var restOperations = GetResourceRestOperationsTypes(type);
                var listAllMethod = restOperations.SelectMany(operation => operation.GetMethods(BindingFlags.Instance | BindingFlags.Public).Where(m => m.Name == "ListAll" || m.Name == "ListBySubscription"));

                if (resourceType.Equals(Subscription.ResourceType) &&
                   listAllMethod.Any())
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

            foreach (Type type in FindAllCollections())
            {
                var resourceName = type.Name.Remove(type.Name.LastIndexOf("Collection"));
                ResourceType resourceType = GetCollectionValidResourceType(type);

                var restOperations = GetResourceRestOperationsTypes(type);
                var listBySubscriptionMethod = restOperations.SelectMany(operation => operation.GetMethods(BindingFlags.Instance | BindingFlags.Public).Where(m => m.Name == "GetBySubscription"));

                if (!resourceType.Equals(Subscription.ResourceType) &&
                    listBySubscriptionMethod.Any())
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
                foreach (var collection in FindAllCollections())
                {
                    ResourceType collectionType = GetCollectionValidResourceType(collection);
                    if (collectionType.Equals(operationType))
                    {
                        var name = collection.Name.Remove(collection.Name.LastIndexOf("Collection"));
                        var method = operation.GetMethod($"Get{name.ToPlural()}");
                        Assert.NotNull(method);
                        Assert.IsTrue(method.ReturnParameter.ToString().Trim().Equals(collection.Namespace + "." + collection.Name));
                        Assert.IsTrue(method.GetParameters().Count() == 0);
                    }
                }
            }
        }

        [Test]
        public async Task ValidateRequiredParamsInCtor()
        {
            if (_projectName.Equals("") || _projectName.Equals("ReferenceTypes"))
            {
                return;
            }

            var output = await OutputLibraryTestBase.Generate(_projectName, _subFolder);
            var library = output.Context.Library;
            foreach (var mgmtObject in library.Models.OfType<MgmtObjectType>())
            {
                if (ReferenceTypePropertyChooser.GetExactMatch(mgmtObject, output.Context) == null)
                {
                    ValidateModelRequiredCtorParams(mgmtObject.ObjectSchema);
                }
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
            if (generatedModel == null)
                return; //for some reason we are losing the cache during generation to know which models were removed
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

        protected void ValidateMethodExist(string fullClassName, string methodName, params string[] argTypes)
        {
            var classToCheck = Assembly.GetExecutingAssembly().GetType(fullClassName);
            var methods = classToCheck.GetMethods().Where(m => m.Name == methodName);
            Assert.Greater(methods.Count(), 0, $"Can't find method {fullClassName}.{methodName}!");

            for (int i = 0; i < argTypes.Length; i++)
            {
                methods = methods.Where(x =>
                {
                    var parameters = x.GetParameters();
                    return parameters[i].ParameterType.Name == argTypes[i];
                });
                Assert.Greater(methods.Count(), 0, $"The {i + 1}nd parameter of {fullClassName}.{methodName}() is not of type {argTypes[i]}!");
            }
        }
    }
}
