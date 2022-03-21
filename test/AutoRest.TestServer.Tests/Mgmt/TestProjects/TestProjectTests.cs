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
        public void VerifyNoSingleWordsThatShouldBeReplaced()
        {
            var singlesToReplace = typeof(CommonSingleWordModels).GetField("_schemasToChange", BindingFlags.Static | BindingFlags.NonPublic).GetValue(null) as HashSet<string>;
            foreach (var type in MyTypes())
            {
                Assert.IsFalse(singlesToReplace.Contains(type.Name));
            }
        }

        [Test]
        public void PropertiesEndingInUriShouldBeUriType()
        {
            foreach (var type in MyTypes())
            {
                foreach (var property in type.GetProperties())
                {
                    if (property.Name.EndsWith("Uri"))
                        Assert.AreEqual(typeof(Uri), property.PropertyType);
                }
            }
        }

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
                VerifyMethodReturnType(resource, resource, "Get");
                var resourceData = GetResourceDataByResource(resource);
                if (typeof(TrackedResourceData).IsAssignableFrom(resourceData))
                {
                    VerifyMethodReturnType(resource, resource, "AddTag");
                    VerifyMethodReturnType(resource, resource, "SetTags");
                    VerifyMethodReturnType(resource, resource, "RemoveTag");
                }
                var updateMethod = resource.GetMethod("Update");
                if (updateMethod is not null)
                {
                    VerifyMethodReturnType(resource, resource, "Update");
                }
            }

            foreach (var collection in FindAllCollections())
            {
                var resource = GetResourceFromCollection(collection);
                Assert.NotNull(resource);
                VerifyMethodReturnType(collection, resource, "Get");
                VerifyMethodReturnType(collection, resource, "GetIfExists");

                if (!ListExceptionCollections.Contains(collection))
                    VerifyMethodReturnType(collection, resource, collection.GetMethods().First(m => m.Name == "GetAll" && !m.GetParameters().Any(p => !p.IsOptional)));

                if (collection.GetMethod("CreateOrUpdate") is not null)
                    VerifyMethodReturnType(collection, resource, "CreateOrUpdate");
            }
        }

        private void VerifyMethodReturnType(Type type, Type expectedType, string methodName)
        {
            var method = type.GetMethod(methodName);
            Assert.NotNull(method, $"Method {methodName} was not found on {type.Name}");
            VerifyMethodReturnType(type, expectedType, method);
        }

        private static void VerifyMethodReturnType(Type type, Type expectedType, MethodInfo method)
        {
            Assert.IsTrue(method.ReturnType.IsGenericType);
            var genericArgument = method.ReturnType.GetGenericArguments()[0];
            Assert.AreEqual(expectedType, genericArgument, $"Return type did not match for {type.Name}.{method.Name}");
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
                var mockCtor = type.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic).Where(c => c.IsFamily && c.GetParameters().Length == 0).FirstOrDefault();
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

            var resourceExtensions = FindExtensionClass();
            var resourceCollections = FindAllCollections();

            if (resourceExtensions == null)
            {
                Assert.IsTrue(resourceCollections.Any(), $"The extension class is not found while there are{resourceCollections.Count()} resource collections");
            }

            foreach (var type in resourceCollections)
            {
                var resourceName = type.Name.Remove(type.Name.LastIndexOf("Collection"));
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier("/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575/resourceGroups/myRg");
                if (IsParent(type, resourceIdentifier))
                {
                    var getCollectionMethods = resourceExtensions.GetMethods()
                        .Where(m => m.Name == $"Get{resourceName.ResourceNameToPlural()}")
                        .Where(m => ParameterMatch(m.GetParameters(), new[] {typeof(ResourceGroup)}));
                    Assert.AreEqual(1, getCollectionMethods.Count());
                }
            }
        }

        protected static bool ParameterMatch(ParameterInfo[] methodParameters, Type[] parameterTypes)
        {
            if (parameterTypes.Length > methodParameters.Length)
                return false;
            for (int i = 0; i < parameterTypes.Length; i++)
            {
                if (methodParameters[i].ParameterType != parameterTypes[i])
                    return false;
            }

            return true;
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
            return type.BaseType.Name == typeof(TrackedResourceData).Name;
        }

        /// <summary>
        /// Returns the extension class. We should only have one or none.
        /// Return null if there is none.
        /// </summary>
        /// <returns></returns>
        protected Type? FindExtensionClass()
        {
            // CLR does not have a concept of "static class". CLR will treat static class as both abstract and sealed.
            // therefore using this to find all the static class (which are the extension classes)
            var extensionClasses = MyTypes().Where(type => type.IsAbstract && type.IsSealed && type.IsPublic);
            Assert.LessOrEqual(extensionClasses.Count(), 1);

            return extensionClasses.FirstOrDefault();
        }

        [Test]
        public void ValidateSubscriptionExtensionsGetResourceCollection()
        {
            if (_projectName.Equals("") || _projectName.Equals("ReferenceTypes")) // arm-core is true for ReferenceTypes and it has no SubscriptionExtension.
            {
                return;
            }

            var resourceExtensions = FindExtensionClass();
            var resourceCollections = FindAllCollections();

            if (resourceExtensions == null)
            {
                Assert.IsTrue(resourceCollections.Any(), $"The extension class is not found while there are{resourceCollections.Count()} resource collections");
            }

            foreach (Type type in resourceCollections)
            {
                var resourceName = type.Name.Remove(type.Name.LastIndexOf("Collection"));
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier("/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575");
                if (IsParent(type, resourceIdentifier))
                {
                    var methodInfos = resourceExtensions.GetMethods(BindingFlags.Static | BindingFlags.Public).Where(m => m.Name == $"Get{resourceName.ResourceNameToPlural()}" && m.ReturnType.Name == type.Name);
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

            var resourceExtensions = FindExtensionClass();
            var resourceCollections = FindAllCollections();

            if (resourceExtensions == null)
            {
                Assert.IsTrue(resourceCollections.Any(), $"The extension class is not found while there are{resourceCollections.Count()} resource collections");
            }

            foreach (Type type in resourceCollections)
            {
                var resourceName = type.Name.Remove(type.Name.LastIndexOf("Collection"));
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier("/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575");

                var restOperations = GetResourceRestOperationsTypes(type);
                var listAllMethod = restOperations.SelectMany(operation => operation.GetMethods(BindingFlags.Instance | BindingFlags.Public).Where(m => m.Name == "ListAll" || m.Name == "ListBySubscription"));

                if (IsParent(type, resourceIdentifier) && listAllMethod.Any())
                {
                    var listMethodInfos = resourceExtensions.GetMethods(BindingFlags.Static | BindingFlags.Public).Where(m => m.Name == $"Get{resourceName.ResourceNameToPlural()}" && m.GetParameters().Length >= 2);
                    Assert.AreEqual(listMethodInfos.Count(), 1);
                    var listMethodInfo = listMethodInfos.First();
                    var listParam1 = TypeAsserts.HasParameter(listMethodInfo, "subscription");
                    Assert.AreEqual(typeof(Subscription), listParam1.ParameterType);
                    var listParam2 = TypeAsserts.HasParameter(listMethodInfo, "cancellationToken");
                    Assert.AreEqual(typeof(CancellationToken), listParam2.ParameterType);

                    var listAsyncMethodInfos = resourceExtensions.GetMethods(BindingFlags.Static | BindingFlags.Public).Where(m => m.Name == $"Get{resourceName.ResourceNameToPlural()}Async" && m.GetParameters().Length >= 2);
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

        private bool IsParent(Type collection, ResourceIdentifier resourceIdentifier)
        {
            var validateMethod = collection.GetMethod("ValidateResourceId", BindingFlags.NonPublic | BindingFlags.Static);
            if (validateMethod == null)
                return false;
            try
            {
                validateMethod.Invoke(null, new object[] { resourceIdentifier });
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

        [Test]
        public void ValidateExtensionMethods()
        {
            var extensionType = FindExtensionClass();
            // get all the public methods on the static class (we do not have to add the static flag because it must be all static
            var publicMethodsOfExtensionTypes = extensionType?.GetMethods(BindingFlags.Public | BindingFlags.Static) ?? Enumerable.Empty<MethodInfo>();
            var publicMethodNamesOfExtensionTypes = publicMethodsOfExtensionTypes.Select(m => m.Name).ToArray();
            // now we find all the extension clients
            var extensionClientTypes = MyTypes().Where(type => extensionClientNames.Contains(type.Name));
            // get all the public methods on the extension client class
            var publicMethodsOfExtensionClientTypes = extensionClientTypes.SelectMany(
                type => GetMethodDefinedByMyself(type));

            // validate the extension class should have everything defined in the extension client class
            foreach (var method in publicMethodsOfExtensionClientTypes)
            {
                // validate we have this method
                var candidates = publicMethodsOfExtensionTypes.Where(m => m.Name.Equals(method.Name));
                Assert.IsTrue(candidates.Any(), $"Method {method.Name} is defined in extension client class {method.DeclaringType} but not found in extension class");
                var expectedParameters = method.GetParameters();
                bool matches = false;
                foreach (var candidate in candidates)
                {
                    var parameters = candidate.GetParameters().Skip(1).ToArray(); // skip the first since it is the instance we are extending on
                    matches |= ValidateParameters(expectedParameters, parameters);
                }
                Assert.IsTrue(matches, $"Method {method.Name} is defined in extension client class {method.DeclaringType} but not found in extension class with all the same parameters");
            }
        }

        private static IEnumerable<MethodInfo> GetMethodDefinedByMyself(Type type)
        {
            return type.GetMethods(BindingFlags.Public | BindingFlags.Instance).Where(m => m.DeclaringType == type);
        }

        private static bool ValidateParameters(ParameterInfo[] expected, ParameterInfo[] parameters)
        {
            if (expected.Length != parameters.Length)
                return false;
            for (int i = 0; i < expected.Length; i++)
            {
                if (expected[i].Name != parameters[i].Name || expected[i].ParameterType != parameters[i].ParameterType)
                    return false;
            }

            return true;
        }

        private static readonly string[] extensionClientNames = new[] { "SubscriptionExtensionClient", "ResourceGroupExtensionClient", "ManagementGroupExtensionClient", "TenantExtensionClient", "ArmResourceExtensionClient" };
    }
}
