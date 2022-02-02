using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
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
        public void ArmClientParameterShouldBeClient()
        {
            foreach (var resource in FindAllResources())
            {
                ValidateConstructorsForArmClientParameter(resource);
            }
            foreach (var collection in FindAllCollections())
            {
                ValidateConstructorsForArmClientParameter(collection);
            }
            foreach (var extensionClient in FindAllExtensionClients())
            {
                ValidateConstructorsForArmClientParameter(extensionClient);
            }
            foreach (var extension in FindAllExtensions())
            {
                foreach (var method in extension.GetMethods(BindingFlags.Public | BindingFlags.Static))
                {
                    ValidateArmClientParameter($"{extension.Name}.{method.Name}", method.GetParameters());
                }
            }
        }

        private void ValidateConstructorsForArmClientParameter(Type type)
        {
            foreach (var ctor in type.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
            {
                ValidateArmClientParameter($"{type.Name}.Ctor", ctor.GetParameters());
            }
        }

        private void ValidateArmClientParameter(string methodName, ParameterInfo[] parameters)
        {
            var armClientParam = parameters.FirstOrDefault(p => p.ParameterType == typeof(ArmClient));
            if (armClientParam is null)
                return;

            Assert.AreEqual("client", armClientParam.Name, $"Expected 'client' for ArmClient parameter in {methodName}({string.Join(',', parameters.Select(p => $"{p.ParameterType.Name} {p.Name}").ToArray())})");
        }

        [Test]
        public void GetShouldMatchResource()
        {
            foreach (var resource in FindAllResources())
            {
                var responseType = typeof(Response<>).MakeGenericType(resource);
                VerifyMethodReturnType(resource, responseType, "Get");
                var resourceData = GetResourceDataByResource(resource);
                if (typeof(TrackedResource).IsAssignableFrom(resourceData))
                {
                    VerifyMethodReturnType(resource, responseType, "AddTag");
                    VerifyMethodReturnType(resource, responseType, "SetTags");
                    VerifyMethodReturnType(resource, responseType, "RemoveTag");
                }
                var updateMethod = resource.GetMethod("Update");
                if (updateMethod is not null)
                {
                    if (updateMethod.ReturnType.IsGenericType)
                    {
                        VerifyMethodReturnType(resource, responseType, "Update");
                    }
                    else
                    {
                        VerifyMethodReturnType(resource, typeof(Operation<>).MakeGenericType(resource), "Update", true);
                    }
                }
            }

            foreach (var collection in FindAllCollections())
            {
                var resource = GetResourceFromCollection(collection);
                Assert.NotNull(resource);
                var responseType = typeof(Response<>).MakeGenericType(resource);
                var pagingType = typeof(Pageable<>).MakeGenericType(resource);
                var lroType = typeof(Operation<>).MakeGenericType(resource);
                VerifyMethodReturnType(collection, responseType, "Get");
                VerifyMethodReturnType(collection, responseType, "GetIfExists");

                if (!ListExceptionCollections.Contains(collection))
                    VerifyMethodReturnType(collection, pagingType, collection.GetMethods().First(m => m.Name == "GetAll" && !m.GetParameters().Any(p => !p.IsOptional)));

                if (collection.GetMethod("CreateOrUpdate") is not null)
                    VerifyMethodReturnType(collection, lroType, "CreateOrUpdate", true);
            }
        }

        private void VerifyMethodReturnType(Type collection, Type expectedType, string methodName, bool useIsAssignableFrom = false)
        {
            var method = collection.GetMethod(methodName);
            Assert.NotNull(method, $"Method {methodName} was not found on {collection.Name}");
            VerifyMethodReturnType(collection, expectedType, method, useIsAssignableFrom);
        }

        private static void VerifyMethodReturnType(Type collection, Type expectedType, MethodInfo method, bool useIsAssignableFrom = false)
        {
            if (useIsAssignableFrom)
            {
                Assert.IsTrue(expectedType.IsAssignableFrom(method.ReturnType), $"Return type did not match for {collection.Name}.{method.Name}");
            }
            else
            {
                Assert.AreEqual(expectedType, method.ReturnType, $"Return type did not match for {collection.Name}.{method.Name}");
            }
        }

        private Type? GetResourceFromCollection(Type collection) => MyTypes().FirstOrDefault(t => t.Name == GetResourceNameFromCollectionName(collection.Name));
        private string GetResourceNameFromCollectionName(string collectionName) => collectionName.Substring(0, collectionName.IndexOf("Collection"));

        protected virtual HashSet<Type> ListExceptionCollections { get; } = new HashSet<Type>();
        [Test]
        public void IEnumerableShouldMatchResource()
        {
            foreach (var collection in FindAllCollections())
            {
                if (ListExceptionCollections.Contains(collection))
                    continue;

                var interfaces = collection.GetInterfaces();
                Assert.AreEqual(3, interfaces.Length, $"For {collection.Name} expected IEnumerable<T>, IEnumerable, and IAsyncEnumerable<T>, found {string.Join(',', interfaces.Select(i => i.Name).ToArray())}");
                foreach (var interFace in interfaces)
                {
                    if (!interFace.IsGenericType)
                        continue;
                    var genericArg = interFace.GetGenericArguments().FirstOrDefault();
                    Assert.NotNull(genericArg, $"{interFace.Name} did not have a type argument for {collection.Name}");
                    Assert.AreEqual(GetResourceNameFromCollectionName(collection.Name), genericArg.Name);
                }
            }
        }

        [Test]
        public void ValidatePublicMethodsAreVirtual()
        {
            foreach (var type in FindAllResources())
            {
                ValidatePublicMethods(type);
            }
            foreach (var type in FindAllCollections())
            {
                ValidatePublicMethods(type);
            }
            foreach (var type in FindAllExtensionClients())
            {
                ValidatePublicMethods(type);
            }
        }

        private void ValidatePublicMethods(Type type)
        {
            if (!type.IsPublic)
                return;
            foreach (var method in type.GetMethods(BindingFlags.Instance | BindingFlags.Public))
            {
                if (method.DeclaringType != type)
                    continue;

                Assert.IsTrue(method.IsVirtual, $"{method.Name} was not virtual but was public on {type.Name}");
            }
        }

        [Test]
        public void AllClientsShouldHaveMockingCtor()
        {
            foreach (var type in FindAllResources())
            {
                var mockCtor = type.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic).Where(c=>c.IsFamily && c.GetParameters().Length == 0).FirstOrDefault();
                Assert.IsNotNull(mockCtor);
            }
            foreach (var type in FindAllCollections())
            {
                var mockCtor = type.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic).Where(c => c.IsFamily && c.GetParameters().Length == 0).FirstOrDefault();
                Assert.IsNotNull(mockCtor);
            }
            foreach (var type in FindAllExtensionClients())
            {
                var mockCtor = type.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic).Where(c => c.IsFamily && c.GetParameters().Length == 0).FirstOrDefault();
                Assert.IsNotNull(mockCtor);
            }
        }

        [Test]
        public void ValidateReturnTypesInPublicExtension()
        {
            foreach (var type in MyTypes().Where(t => t.Name.EndsWith("Extensions")))
            {
                foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.ReturnType.IsSubclassOf(typeof(Task))))
                {
                    var typeArg = method.ReturnType.GenericTypeArguments.FirstOrDefault();
                    if (typeArg.IsSubclassOf(typeof(Operation)))
                        continue; //skip LROs

                    Assert.IsNotNull(typeArg);
                    if (typeArg.IsGenericType)
                    {
                        Assert.AreEqual(typeof(Response<>), typeArg.GetGenericTypeDefinition());
                    }
                    else
                    {
                        Assert.AreEqual(typeof(Response), typeArg);
                    }
                }
            }
        }

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

                Assert.AreEqual(3, method.GetParameters().Length, $"{type.Name}.{method.Name} had more parameters than expected. Only expected 3 but got {{{string.Join(',', method.GetParameters().Select(p => p.Name))}}}");
                var param1 = TypeAsserts.HasParameter(method, "key");
                Assert.AreEqual(typeof(string), param1.ParameterType);
                var param2 = TypeAsserts.HasParameter(method, "value");
                Assert.AreEqual(typeof(string), param2.ParameterType);
                var param3 = TypeAsserts.HasParameter(method, "cancellationToken");
                Assert.AreEqual(typeof(CancellationToken), param3.ParameterType);
            }
        }

        [Test]
        public void ValidateExtensionClient()
        {
            foreach (var extensionClient in FindAllExtensionClients())
            {
                Assert.IsFalse(extensionClient.IsPublic);
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
            if (_projectName.Equals("") || _projectName.Equals("ReferenceTypes")) // arm-core is true for ReferenceTypes and it has no ResourceGroupExtension.
            {
                return;
            }

            Type resourceExtensions = FindResourceGroupExtensions();
            Assert.NotNull(resourceExtensions);

            foreach (var type in FindAllCollections())
            {
                var resourceName = type.Name.Remove(type.Name.LastIndexOf("Collection"));
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier("/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575/resourceGroups/myRg");
                if (IsParent(type, resourceIdentifier))
                {
                    var getCollectionMethod = resourceExtensions.GetMethod($"Get{resourceName}".ToPlural());
                    Assert.NotNull(getCollectionMethod);
                    Assert.AreEqual(1, getCollectionMethod.GetParameters().Length);
                    var param = TypeAsserts.HasParameter(getCollectionMethod, "resourceGroup");
                    Assert.AreEqual(typeof(ResourceGroup), param.ParameterType);
                }
            }
        }

        public IEnumerable<Type> FindAllExtensionClients()
        {
            Type[] allTypes = Assembly.GetExecutingAssembly().GetTypes();

            foreach (Type t in allTypes)
            {
                if (t.Name.EndsWith("ExtensionClient"))
                {
                    yield return t;
                }
            }
        }

        public IEnumerable<Type> FindAllExtensions()
        {
            Type[] allTypes = Assembly.GetExecutingAssembly().GetTypes();

            foreach (Type t in allTypes)
            {
                if (t.Name.EndsWith("Extensions"))
                {
                    yield return t;
                }
            }
        }

        public IEnumerable<Type> FindAllResources()
        {
            Type[] allTypes = Assembly.GetExecutingAssembly().GetTypes();

            foreach (Type t in allTypes)
            {
                if (t.BaseType.FullName == typeof(ArmResource).FullName &&
                    !t.Name.Contains("Tests") &&
                    t.Namespace == _projectName &&
                    !t.Name.EndsWith("ExtensionClient"))
                {
                    yield return t;
                }
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

        [Test]
        public void ValidateSubscriptionExtensionsGetResourceCollection()
        {
            if (_projectName.Equals("") || _projectName.Equals("ReferenceTypes")) // arm-core is true for ReferenceTypes and it has no SubscriptionExtension.
            {
                return;
            }

            Type subscriptionExtension = FindSubscriptionExtensions();
            Assert.NotNull(subscriptionExtension);

            foreach (Type type in FindAllCollections())
            {
                var resourceName = type.Name.Remove(type.Name.LastIndexOf("Collection"));
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier("/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575");
                if (IsParent(type, resourceIdentifier))
                {
                    var methodInfos = subscriptionExtension.GetMethods(BindingFlags.Static | BindingFlags.Public).Where(m => m.Name == $"Get{resourceName.ResourceNameToPlural()}" && m.ReturnType.Name == type.Name);
                    Assert.AreEqual(methodInfos.Count(), 1);
                    var param = TypeAsserts.HasParameter(methodInfos.First(), "subscription");
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
            if (_projectName.Equals("") || _projectName.Equals("ReferenceTypes")) // arm-core is true for ReferenceTypes and it has no SubscriptionExtension.
            {
                return;
            }

            Type subscriptionExtension = FindSubscriptionExtensions();
            Assert.NotNull(subscriptionExtension);

            foreach (Type type in FindAllCollections())
            {
                var resourceName = type.Name.Remove(type.Name.LastIndexOf("Collection"));
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier("/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575");

                var restOperations = GetResourceRestOperationsTypes(type);
                var listAllMethod = restOperations.SelectMany(operation => operation.GetMethods(BindingFlags.Instance | BindingFlags.Public).Where(m => m.Name == "ListAll" || m.Name == "ListBySubscription"));

                if (IsParent(type, resourceIdentifier) && listAllMethod.Any())
                {
                    var listMethodInfos = subscriptionExtension.GetMethods(BindingFlags.Static | BindingFlags.Public).Where(m => m.Name == $"Get{resourceName.ResourceNameToPlural()}" && m.GetParameters().Length >= 2);
                    Assert.AreEqual(listMethodInfos.Count(), 1);
                    var listMethodInfo = listMethodInfos.First();
                    var listParam1 = TypeAsserts.HasParameter(listMethodInfo, "subscription");
                    Assert.AreEqual(typeof(Subscription), listParam1.ParameterType);
                    var listParam2 = TypeAsserts.HasParameter(listMethodInfo, "cancellationToken");
                    Assert.AreEqual(typeof(CancellationToken), listParam2.ParameterType);

                    var listAsyncMethodInfos = subscriptionExtension.GetMethods(BindingFlags.Static | BindingFlags.Public).Where(m => m.Name == $"Get{resourceName.ResourceNameToPlural()}Async" && m.GetParameters().Length >= 2);
                    Assert.AreEqual(listMethodInfos.Count(), 1);
                    var listAsyncMethodInfo = listAsyncMethodInfos.First();
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
            if (_projectName.Equals("") || _projectName.Equals("ReferenceTypes")) // arm-core is true for ReferenceTypes and it has no SubscriptionExtension.
            {
                return;
            }

            Type subscriptionExtension = FindSubscriptionExtensions();
            Assert.NotNull(subscriptionExtension);

            foreach (Type type in FindAllCollections())
            {
                var resourceName = type.Name.Remove(type.Name.LastIndexOf("Collection"));
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier("/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575");

                var restOperations = GetResourceRestOperationsTypes(type);
                var listBySubscriptionMethod = restOperations.SelectMany(operation => operation.GetMethods(BindingFlags.Instance | BindingFlags.Public).Where(m => m.Name == "GetBySubscription"));

                if (!IsParent(type, resourceIdentifier) && listBySubscriptionMethod.Any())
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
                ResourceType operationType = (ResourceType)operationTypeProperty.GetValue(operation);
                ResourceIdentifier resourceIdentifier = GetSampleResourceId(operation);
                foreach (var collection in FindAllCollections())
                {
                    if (IsParent(collection, resourceIdentifier))
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

        private bool DoesCollectionAcceptAll(Type collection)
        {
            throw new NotImplementedException();
        }

        private bool IsParent(Type collection, ResourceIdentifier resourceIdentifier)
        {
            var validateMethod = collection.GetMethod("ValidateResourceId", BindingFlags.NonPublic | BindingFlags.Static);
            if (validateMethod == null)
                return false;
            try
            {
                validateMethod.Invoke(null, new object[] {resourceIdentifier});
                return true;
            }
            catch
            {
                return false;
            }
        }

        private ResourceIdentifier GetSampleResourceId(Type operation)
        {
            var createIdMethod = operation.GetMethod("CreateResourceIdentifier", BindingFlags.Static | BindingFlags.Public);
            List<string> keys = new List<string>();
            foreach (var p in createIdMethod.GetParameters())
            {
                keys.Add(GetSampleKey(p.Name));
            }
            return createIdMethod.Invoke(null, keys.ToArray()) as ResourceIdentifier;
        }

        private static string GetSampleKey(string paramName) => paramName switch
        {
            "subscriptionId" => Guid.Empty.ToString(),
            "scope" => "/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575/resourceGroups/myrg/providers/Microsoft.Something/somethings/mySomething",
            "linkId" => "/providers/Microsoft.Resources/links/myLink",
            _ => paramName
        };

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
