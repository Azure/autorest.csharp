// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Mgmt.AutoRest
{
    internal class MgmtOutputLibrary : OutputLibrary
    {
        private BuildContext<MgmtOutputLibrary> _context;
        private CodeModel _codeModel;
        private MgmtConfiguration _mgmtConfiguration;

        /// <summary>
        /// This is a map from raw request path to the corresponding <see cref="MgmtRestClient"/>
        /// The type of values is a HashSet of <see cref="MgmtRestClient"/>, because we might get the case that multiple operation groups might share the same request path
        /// </summary>
        private Dictionary<string, HashSet<MgmtRestClient>>? _rawRequestPathToRestClient;

        /// <summary>
        /// This is a map from raw request path to the corresponding <see cref="ResourceData"/>
        /// This must be initialized before other maps
        /// </summary>
        private IDictionary<string, ResourceData>? _rawRequestPathToResourceData;

        /// <summary>
        /// This is a map from request path to the <see cref="ResourceObjectAssociation"/> which consists from <see cref="ResourceTypeSegment"/>, <see cref="Output.ResourceData"/>, <see cref="Resource"/> and <see cref="ResouColl"/>
        /// </summary>
        private Dictionary<RequestPath, ResourceObjectAssociation>? _requestPathToResources;

        /// <summary>
        /// This is a map from resource name to a list of <see cref="OperationSet"/>
        /// considering of the extension resources, one resource name might correspond to multiple operation sets
        /// This must be initialized before other maps
        /// </summary>
        private Dictionary<string, HashSet<OperationSet>> _resourceDataSchemaNameToOperationSets;

        private Dictionary<Schema, TypeProvider>? _resourceModels;
        private Dictionary<string, TypeProvider> _nameToTypeProvider;
        private IEnumerable<Schema> _allSchemas;

        private Dictionary<string, string> _mergedOperations;

        /// <summary>
        /// This is a map from raw request path to their corresponding <see cref="OperationSet"/>,
        /// which is a collection of the operations with the same raw request path
        /// </summary>
        private Dictionary<string, OperationSet> _rawRequestPathToOperationSets;

        /// <summary>
        /// This is a map from <see cref="OperationGroup"/> to the list of raw request path of its operations
        /// </summary>
        private Dictionary<OperationGroup, IEnumerable<string>> _operationGroupToRequestPaths;

        public MgmtOutputLibrary(CodeModel codeModel, BuildContext<MgmtOutputLibrary> context)
        {
            OmitOperationGroups.RemoveOperationGroups(codeModel, context);
            _context = context;
            _mgmtConfiguration = context.Configuration.MgmtConfiguration;
            UpdateSubscriptionIdForAllResource(codeModel);
            _codeModel = codeModel;
            _operationGroupToRequestPaths = new Dictionary<OperationGroup, IEnumerable<string>>();
            _rawRequestPathToOperationSets = new Dictionary<string, OperationSet>();
            _resourceDataSchemaNameToOperationSets = new Dictionary<string, HashSet<OperationSet>>();
            _nameToTypeProvider = new Dictionary<string, TypeProvider>();
            _mergedOperations = _mgmtConfiguration.MergeOperations.SelectMany(kv => kv.Value.Select(v => (FullOperationName: v, MethodName: kv.Key))).ToDictionary(kv => kv.FullOperationName, kv => kv.MethodName);
            _allSchemas = _codeModel.Schemas.Choices.Cast<Schema>()
                .Concat(_codeModel.Schemas.SealedChoices)
                .Concat(_codeModel.Schemas.Objects)
                .Concat(_codeModel.Schemas.Groups);

            // We can only manipulate objects from the code model, not RestClientMethod
            ReorderOperationParameters();

            // Categorize the operation group with their operation paths
            CategorizeOperationGroups();

            // Decorate the operation sets to see if it corresponds to a resource
            DecorateOperationSets();
        }

        private void UpdateSubscriptionIdForAllResource(CodeModel codeModel)
        {
            bool setSubParam = false;
            foreach (var operationGroup in codeModel.OperationGroups)
            {
                foreach (var op in operationGroup.Operations)
                {
                    foreach (var p in op.Parameters)
                    {
                        //updater the first subscriptionId to be 'method'
                        if (!setSubParam && p.Language.Default.Name.Equals("subscriptionId", StringComparison.OrdinalIgnoreCase))
                        {
                            setSubParam = true;
                            p.Implementation = ImplementationLocation.Method;
                        }
                        //updater the first subscriptionId to be 'method'
                        if (p.Language.Default.Name.Equals("apiVersion", StringComparison.OrdinalIgnoreCase))
                        {
                            p.Implementation = ImplementationLocation.Client;
                        }
                    }
                }
            }
        }

        // Initialize ResourceData, Models and resource manager common types
        private void InitializeModels()
        {
            _models = new Dictionary<Schema, TypeProvider>();
            _resourceModels = new Dictionary<Schema, TypeProvider>();

            // first, construct models and resource data models
            foreach (var schema in _allSchemas)
            {
                if (_resourceDataSchemaNameToOperationSets.ContainsKey(schema.Name))
                {
                    var model = BuildResourceModel(schema);
                    _resourceModels.Add(schema, model);
                    _nameToTypeProvider.Add(schema.Name, model); // TODO: ADO #5829 create new dictionary that allows look-up with multiple key types to eliminate duplicate dictionaries
                }
                else
                {
                    var model = BuildModel(schema);
                    _models.Add(schema, model);
                    _nameToTypeProvider.Add(schema.Name, model);
                }

            }

            // second, collect any model which can be replaced as whole (not as a property or as a base class)
            var replacedTypes = new List<MgmtObjectType>();
            foreach (var schema in _codeModel.Schemas.Objects)
            {
                TypeProvider? type;

                if (_models.TryGetValue(schema, out type) || _resourceModels.TryGetValue(schema, out type))
                {
                    if (type is MgmtObjectType mgmtObjectType)
                    {
                        var csharpType = TypeReferenceTypeChooser.GetExactMatch(mgmtObjectType);
                        if (csharpType != null)
                        {
                            // re-construct the model with replaced csharp type (e.g. the type in Resource Manager)
                            switch (mgmtObjectType)
                            {
                                case ResourceData resourceData:
                                    replacedTypes.Add(new ResourceData(schema, _context, csharpType.Name, csharpType.Namespace));
                                    break;
                                case MgmtReferenceType referenceType:
                                    replacedTypes.Add(new MgmtReferenceType(schema, _context, csharpType.Name, csharpType.Namespace));
                                    break;
                                default:
                                    replacedTypes.Add(new MgmtObjectType(schema, _context, csharpType.Name, csharpType.Namespace));
                                    break;
                            }
                        }
                    }
                }
            }

            // third, update the entries in cache maps with the new model instances
            foreach (var replacedType in replacedTypes)
            {
                var schema = replacedType.ObjectSchema;
                var name = schema.Name;

                _nameToTypeProvider[name] = replacedType;

                if (replacedType is ResourceData replacedResourceData)
                {
                    _resourceModels[schema] = replacedType;
                }
                else
                {
                    _models[schema] = replacedType;
                }
            }
        }

        private IEnumerable<OperationSet>? _resourceOperationSets;

        public IEnumerable<OperationSet> ResourceOperationSets => _resourceOperationSets ??= _resourceDataSchemaNameToOperationSets.SelectMany(pair => pair.Value);

        /// <summary>
        /// Returns the full list of the operation sets in this swagger
        /// </summary>
        public IEnumerable<OperationSet> OperationSets => _rawRequestPathToOperationSets.Values;

        public OperationSet GetOperationSet(string requestPath)
        {
            return _rawRequestPathToOperationSets[requestPath];
        }

        public RestClientMethod GetRestClientMethod(Operation operation) => EnsureRestClientMethods()[operation];

        public IDictionary<RestClientMethod, PagingMethod> PagingMethods => EnsurePagingMethods();


        private IDictionary<RestClientMethod, PagingMethod>? _pagingMethods;
        private IDictionary<RestClientMethod, PagingMethod> EnsurePagingMethods()
        {
            if (_pagingMethods != null)
                return _pagingMethods;

            _pagingMethods = new Dictionary<RestClientMethod, PagingMethod>();
            var placeholder = new TypeDeclarationOptions("Placeholder", "Placeholder", "public", false, true);
            foreach (var restClient in RestClients)
            {
                var methods = ClientBuilder.BuildPagingMethods(restClient.OperationGroup, restClient, placeholder);
                foreach (var method in methods)
                {
                    _pagingMethods.Add(method.Method, method);
                }
            }

            return _pagingMethods;
        }

        private IDictionary<Operation, RestClientMethod>? _restClientMethods;
        private IDictionary<Operation, RestClientMethod> EnsureRestClientMethods()
        {
            if (_restClientMethods != null)
                return _restClientMethods;

            _restClientMethods = new Dictionary<Operation, RestClientMethod>();
            foreach (var restClient in RestClients)
            {
                foreach (var restClientMethod in restClient.Methods)
                {
                    // skip all internal methods
                    if (restClientMethod.Accessibility != "public")
                        continue;
                    _restClientMethods.Add(restClientMethod.Operation, restClientMethod);
                }
            }

            return _restClientMethods;
        }

        public ArmClientExtensions ArmClientExtensions => EnsureArmClientExtensions();

        public TenantExtensions TenantExtensions => EnsureTenantExtensions();

        public SubscriptionExtensions SubscriptionExtensions => EnsureSubscriptionExtensions();

        private MgmtExtensions? _subscriptionExtensionClient;
        public MgmtExtensions SubscriptionExtensionsClient => EnsureExtensionsClient(ref _subscriptionExtensionClient, "Subscription", RequestPath.Subscription);

        private MgmtExtensions? _resourceGroupExtensionClient;
        public MgmtExtensions ResourceGroupExtensionsClient => EnsureExtensionsClient(ref _resourceGroupExtensionClient, "ResourceGroup", RequestPath.ResourceGroup);

        private MgmtExtensions? _tenantExtensionClient;
        public MgmtExtensions TenantExtensionsClient => EnsureExtensionsClient(ref _tenantExtensionClient, "Tenant", RequestPath.Tenant);

        private MgmtExtensions? _managementGroupExtensionClient;
        public MgmtExtensions ManagementGroupExtensionsClient => EnsureExtensionsClient(ref _managementGroupExtensionClient, "ManagementGroup", RequestPath.ManagementGroup);

        public ResourceGroupExtensions ResourceGroupExtensions => EnsureResourceGroupExtensions();

        public ManagementGroupExtensions ManagementGroupExtensions => EnsureManagementExtensions();

        public ArmResourceExtensions ArmResourceExtensions => EnsureArmResourceExtensions();

        private ResourceGroupExtensions? _resourceGroupsExtensions;
        private ResourceGroupExtensions EnsureResourceGroupExtensions()
        {
            if (_resourceGroupsExtensions != null)
                return _resourceGroupsExtensions;

            // accumulate all the operations of resource group extensions
            _resourceGroupsExtensions = new ResourceGroupExtensions(GetChildOperations(RequestPath.ResourceGroup), _context);
            return _resourceGroupsExtensions;
        }

        private SubscriptionExtensions? _subscriptionExtensions;
        private SubscriptionExtensions EnsureSubscriptionExtensions()
        {
            if (_subscriptionExtensions != null)
                return _subscriptionExtensions;

            // accumulate all the operations of subscription extensions
            _subscriptionExtensions = new SubscriptionExtensions(GetChildOperations(RequestPath.Subscription), _context);
            return _subscriptionExtensions;
        }

        private MgmtExtensions EnsureExtensionsClient(ref MgmtExtensions? extensionField, string typePrefix, RequestPath path)
        {
            if (extensionField != null)
                return extensionField;

            extensionField = new MgmtExtensions(GetChildOperations(path), typePrefix, _context, $"{typePrefix}ExtensionClient", path);
            return extensionField;
        }


        private ManagementGroupExtensions? _managementGroupExtensions;
        private ManagementGroupExtensions EnsureManagementExtensions()
        {
            if (_managementGroupExtensions != null)
                return _managementGroupExtensions;

            // accumulate all the operations of subscription extensions
            _managementGroupExtensions = new ManagementGroupExtensions(GetChildOperations(RequestPath.ManagementGroup), _context);
            return _managementGroupExtensions;
        }

        private TenantExtensions? _tenantExtensions;
        private TenantExtensions EnsureTenantExtensions()
        {
            if (_tenantExtensions != null)
                return _tenantExtensions;

            _tenantExtensions = new TenantExtensions(GetChildOperations(RequestPath.Tenant), _context);
            return _tenantExtensions;
        }

        private ArmClientExtensions? _armClientExtensions;
        private ArmClientExtensions EnsureArmClientExtensions()
        {
            if (_armClientExtensions != null)
                return _armClientExtensions;

            _armClientExtensions = new ArmClientExtensions(GetChildOperations(RequestPath.Tenant), _context);
            return _armClientExtensions;
        }

        private ArmResourceExtensions? _armResourceExtensions;
        private ArmResourceExtensions EnsureArmResourceExtensions()
        {
            if (_armResourceExtensions != null)
                return _armResourceExtensions;

            _armResourceExtensions = new ArmResourceExtensions(Enumerable.Empty<Operation>(), _context);
            return _armResourceExtensions;
        }

        private IEnumerable<ResourceData>? _resourceDatas;
        public IEnumerable<ResourceData> ResourceData => _resourceDatas ??= EnsureRequestPathToResourceData().Values.Distinct();

        private IEnumerable<MgmtRestClient>? _restClients;
        public IEnumerable<MgmtRestClient> RestClients => _restClients ??= EnsureRestClients().Values.SelectMany(v => v).Distinct();

        private IEnumerable<Resource>? _armResources;
        public IEnumerable<Resource> ArmResources => _armResources ??= EnsureRequestPathToResourcesMap().Values.Select(bag => bag.Resource).Distinct();

        private IEnumerable<ResourceCollection>? _resourceCollections;
        public IEnumerable<ResourceCollection> ResourceCollections => _resourceCollections ??= EnsureRequestPathToResourcesMap().Values.Select(bag => bag.ResourceCollection).WhereNotNull().Distinct();

        public IEnumerable<MgmtLongRunningOperation> LongRunningOperations
        {
            get
            {
                // TODO -- refactor so that in the future we no longer need to iterate everything to ensure they are initialized
                // force initialization on resources, collections, etc
                foreach (var resource in ArmResources)
                {
                    _ = resource.ClientOperations;
                }
                foreach (var collection in ResourceCollections)
                {
                    _ = collection.ClientOperations;
                }
                _ = ResourceGroupExtensions.ClientOperations;
                _ = SubscriptionExtensions.ClientOperations;
                _ = ManagementGroupExtensions.ClientOperations;
                _ = TenantExtensions.ClientOperations;
                return _mgmtLongRunningOperations.Values;
            }
        }

        public IEnumerable<NonLongRunningOperation> NonLongRunningOperations
        {
            get
            {
                // TODO -- refactor so that in the future we no longer need to iterate everything to ensure they are initialized
                // force initialization on resources, collections, etc
                foreach (var resource in ArmResources)
                {
                    _ = resource.ClientOperations;
                }
                foreach (var collection in ResourceCollections)
                {
                    _ = collection.ClientOperations;
                }
                _ = ResourceGroupExtensions.ClientOperations;
                _ = SubscriptionExtensions.ClientOperations;
                _ = ManagementGroupExtensions.ClientOperations;
                _ = TenantExtensions.ClientOperations;
                return _mgmtNonLongRunningOperations.Values;
            }
        }

        private Dictionary<Schema, TypeProvider>? _models;

        public Dictionary<Schema, TypeProvider> ResourceSchemaMap
        {
            get
            {
                if (_resourceModels == null)
                    InitializeModels();
                return _resourceModels!;
            }
        }

        internal Dictionary<Schema, TypeProvider> SchemaMap
        {
            get
            {
                if (_models == null)
                    InitializeModels();
                return _models!;
            }
        }

        public IEnumerable<TypeProvider> Models => GetModels();

        private IEnumerable<TypeProvider> GetModels()
        {
            var models = SchemaMap.Values;

            //force inheritance evaluation on resourceData
            foreach (var resourceData in ResourceData)
            {
                var temp = resourceData.Inherits;
                var propTemp = resourceData.Properties;
            }

            //force inheritance evaluation on models
            foreach (var typeProvider in models)
            {
                if (typeProvider is ObjectType objType)
                {
                    var temp = objType.Inherits;
                    //force property reference type evaluation on MgmtObjectType
                    if (typeProvider is MgmtObjectType mgmtObjectType)
                    {
                        var propTemp = mgmtObjectType.Properties;
                    }
                }
            }

            return models;
        }

        public IEnumerable<TypeProvider> ReferenceTypes => SchemaMap.Values.Where(v => v is MgmtReferenceType);

        public ResourceData GetResourceData(string requestPath)
        {
            if (TryGetResourceData(requestPath, out var resourceData))
                return resourceData;

            throw new InvalidOperationException($"Request path {requestPath} does not correspond to a ResourceData");
        }

        public bool TryGetMethodForMergedOperation(string operationFullName, [MaybeNullWhen(false)] out string methodName) => _mergedOperations.TryGetValue(operationFullName, out methodName);

        public bool TryGetResourceData(string requestPath, [MaybeNullWhen(false)] out ResourceData resourceData)
        {
            return EnsureRequestPathToResourceData().TryGetValue(requestPath, out resourceData);
        }

        public Resource GetArmResource(RequestPath requestPath)
        {
            if (TryGetArmResource(requestPath, out var resource))
                return resource;

            throw new InvalidOperationException($"Cannot get Resource corresponding to {requestPath}");
        }

        public bool TryGetArmResource(RequestPath requestPath, [MaybeNullWhen(false)] out Resource resource)
        {
            resource = null;
            if (EnsureRequestPathToResourcesMap().TryGetValue(requestPath, out var bag))
            {
                resource = bag.Resource;
                return true;
            }

            return false;
        }

        public ResourceCollection? GetResourceCollection(RequestPath requestPath)
        {
            if (TryGetResourceCollection(requestPath, out var collection))
                return collection;

            throw new InvalidOperationException($"Cannot get ResourceCollection corresponding to {requestPath}");
        }

        public bool TryGetResourceCollection(RequestPath requestPath, out ResourceCollection? collection)
        {
            collection = null;
            if (EnsureRequestPathToResourcesMap().TryGetValue(requestPath, out var bag))
            {
                collection = bag.ResourceCollection;
                return true;
            }

            return false;
        }

        public MgmtRestClient GetRestClient(Operation operation)
        {
            var requestPath = operation.GetHttpPath();
            if (TryGetRestClients(requestPath, out var restClients))
            {
                // return the first client that contains this operation
                return restClients.Single(client => client.OperationGroup.Operations.Contains(operation));
            }

            throw new InvalidOperationException($"Cannot find MgmtRestClient corresponding to {requestPath} with method {operation.GetHttpMethod()}");
        }

        public bool TryGetRestClients(string requestPath, [MaybeNullWhen(false)] out HashSet<MgmtRestClient> restClients)
        {
            return EnsureRestClients().TryGetValue(requestPath, out restClients);
        }

        internal MgmtLongRunningOperation GetLongRunningOperation(CSharpType type) => _mgmtLongRunningOperations[type.Name];

        internal NonLongRunningOperation GetNonLongRunningOperation(CSharpType type) => _mgmtNonLongRunningOperations[type.Name];

        private Dictionary<string, HashSet<MgmtRestClient>> EnsureRestClients()
        {
            if (_rawRequestPathToRestClient != null)
            {
                return _rawRequestPathToRestClient;
            }

            _rawRequestPathToRestClient = new Dictionary<string, HashSet<MgmtRestClient>>();
            foreach (var operationGroup in _codeModel.OperationGroups)
            {
                var restClient = new MgmtRestClient(operationGroup, _context);
                foreach (var requestPath in _operationGroupToRequestPaths[operationGroup])
                {
                    if (_rawRequestPathToRestClient.TryGetValue(requestPath, out var set))
                        set.Add(restClient);
                    else
                        _rawRequestPathToRestClient.Add(requestPath, new HashSet<MgmtRestClient> { restClient });
                }
            }

            return _rawRequestPathToRestClient;
        }

        private Dictionary<RequestPath, ResourceObjectAssociation> EnsureRequestPathToResourcesMap()
        {
            if (_requestPathToResources != null)
                return _requestPathToResources;

            _requestPathToResources = new Dictionary<RequestPath, ResourceObjectAssociation>();

            foreach ((var resourceName, var operationSets) in _resourceDataSchemaNameToOperationSets)
            {
                var resourceOperationsList = FindResourceToChildOperationsMap(operationSets);
                foreach (var resourceOperations in resourceOperationsList)
                {
                    // ensure this set of OperationSets are either all singletons, or none of them is singleton
                    Debug.Assert(resourceOperations.Keys.All(operationSet => operationSet.IsSingletonResource(_context))
                        || resourceOperations.Keys.All(operationSet => !operationSet.IsSingletonResource(_context)));
                    var isSingleton = resourceOperations.Keys.Any(operationSet => operationSet.IsSingletonResource(_context));
                    // get the corresponding resource data
                    var originalResourcePaths = resourceOperations.Keys.Select(operationSet => operationSet.GetRequestPath(_context));
                    var resourceDatas = originalResourcePaths.Select(path => GetResourceData(path)).Distinct();
                    if (resourceDatas.Count() != 1)
                        throw new InvalidOperationException($"{resourceDatas.Count()} ResourceData instances were found corresponding to the resource (RequestPath: [{string.Join(", ", originalResourcePaths)}]), please double confirm and separate them into different resources");
                    var resourceData = resourceDatas.Single();
                    // we calculate the resource type of the resource
                    var resourcePaths = originalResourcePaths.Select(path => path.Expand(_mgmtConfiguration)).Distinct(new RequestPathCollectionEqualityComparer()).Single();
                    foreach (var resourcePath in resourcePaths)
                    {
                        var resourceType = resourcePath.GetResourceType(_mgmtConfiguration);
                        var resource = new Resource(resourceOperations, resourceName, resourceType, resourceData, _context);
                        var collection = isSingleton ? null : new ResourceCollection(resourceOperations, resource, _context);
                        resource.ResourceCollection = collection;

                        _requestPathToResources.Add(resourcePath, new ResourceObjectAssociation(resourceType, resourceData, resource, collection));
                    }
                }
            }

            return _requestPathToResources;
        }

        private struct RequestPathCollectionEqualityComparer : IEqualityComparer<IEnumerable<RequestPath>>
        {
            public bool Equals([AllowNull] IEnumerable<RequestPath> x, [AllowNull] IEnumerable<RequestPath> y)
            {
                if (x == null && y == null)
                    return true;
                if (x == null || y == null)
                    return false;
                return x.SequenceEqual(y);
            }

            public int GetHashCode([DisallowNull] IEnumerable<RequestPath> obj)
            {
                return obj.GetHashCode();
            }
        }

        private IEnumerable<Dictionary<OperationSet, IEnumerable<Operation>>> FindResourceToChildOperationsMap(IEnumerable<OperationSet> resourceOperationSets)
        {
            var operations = new List<Tuple<OperationSet, IEnumerable<Operation>>>();

            foreach (var resourceOperationSet in resourceOperationSets)
            {
                // all the child operations with the parent of current request path
                operations.Add(new Tuple<OperationSet, IEnumerable<Operation>>(resourceOperationSet, GetChildOperations(resourceOperationSet.RequestPath)));
            }

            // TODO -- we need to categrize the above list to see if some of the resources have the operation list and we can combine them.
            // now by default we will never combine any of them
            return operations.Select(tuple => new Dictionary<OperationSet, IEnumerable<Operation>> { { tuple.Item1, tuple.Item2 } });
        }

        public IEnumerable<Operation> GetChildOperations(string requestPath)
        {
            if (EnsureResourceChildOperations().TryGetValue(requestPath, out var operations))
                return operations;

            return Enumerable.Empty<Operation>();
        }

        private Dictionary<string, HashSet<Operation>>? _childOperations;
        private Dictionary<string, HashSet<Operation>> EnsureResourceChildOperations()
        {
            if (_childOperations != null)
                return _childOperations;

            _childOperations = new Dictionary<string, HashSet<Operation>>();
            foreach ((var requestPath, var operationSet) in _rawRequestPathToOperationSets)
            {
                if (operationSet.IsResource(_mgmtConfiguration))
                    continue;
                foreach (var operation in operationSet)
                {
                    var parentRequestPath = operation.ParentRequestPath(_context);
                    if (_childOperations.TryGetValue(parentRequestPath, out var list))
                        list.Add(operation);
                    else
                        _childOperations.Add(parentRequestPath, new HashSet<Operation> { operation });
                }
            }

            return _childOperations;
        }

        private IDictionary<string, ResourceData> EnsureRequestPathToResourceData()
        {
            if (_rawRequestPathToResourceData != null)
            {
                return _rawRequestPathToResourceData;
            }

            _rawRequestPathToResourceData = new Dictionary<string, ResourceData>();
            foreach (var entry in ResourceSchemaMap)
            {
                var schema = entry.Key;
                if (_resourceDataSchemaNameToOperationSets.TryGetValue(schema.Name, out var operationSets))
                {
                    // we are iterating over the ResourceSchemaMap, the value can only be [ResourceData]s
                    var resourceData = (ResourceData)entry.Value;
                    foreach (var operationSet in operationSets)
                    {
                        if (!_rawRequestPathToResourceData.ContainsKey(operationSet.RequestPath))
                        {
                            _rawRequestPathToResourceData.Add(operationSet.RequestPath, resourceData);
                        }
                    }
                }
            }

            return _rawRequestPathToResourceData;
        }

        private Dictionary<string, MgmtLongRunningOperation> _mgmtLongRunningOperations = new();

        public MgmtLongRunningOperation AddLongRunningOperation(Operation operation, Resource? resource, string lroName)
        {
            if (_mgmtLongRunningOperations.TryGetValue(lroName, out var longRunningOperation))
                return longRunningOperation;

            longRunningOperation = new MgmtLongRunningOperation(operation, operation.FindLongRunningOperationInfo(_context), resource, lroName, _context);
            _mgmtLongRunningOperations.Add(lroName, longRunningOperation);
            return longRunningOperation;
        }

        private Dictionary<string, NonLongRunningOperation> _mgmtNonLongRunningOperations = new();

        public NonLongRunningOperation AddNonLongRunningOperation(Operation operation, Resource? resource, string nonLroName)
        {
            if (_mgmtNonLongRunningOperations.TryGetValue(nonLroName, out var nonLongRunningOperation))
                return nonLongRunningOperation;

            nonLongRunningOperation = new NonLongRunningOperation(operation, operation.FindLongRunningOperationInfo(_context), resource, nonLroName, _context);
            _mgmtNonLongRunningOperations.Add(nonLroName, nonLongRunningOperation);
            return nonLongRunningOperation;
        }

        public override CSharpType FindTypeForSchema(Schema schema)
        {
            TypeProvider? result;
            if (!SchemaMap.TryGetValue(schema, out result) && !ResourceSchemaMap.TryGetValue(schema, out result))
            {
                throw new KeyNotFoundException($"{schema.Name} was not found in model and resource schema map");
            }

            return result.Type;
        }

        public override CSharpType? FindTypeByName(string originalName)
        {
            _nameToTypeProvider.TryGetValue(originalName, out TypeProvider? provider);
            provider ??= ResourceSchemaMap.Values.FirstOrDefault(m => m.Type.Name == originalName);
            return provider?.Type;
        }

        public bool TryGetTypeProvider(string originalName, [MaybeNullWhen(false)] out TypeProvider provider)
        {
            if (_nameToTypeProvider.TryGetValue(originalName, out provider))
                return true;

            provider = ResourceSchemaMap.Values.FirstOrDefault(m => m.Type.Name == originalName);
            return provider != null;
        }

        public IEnumerable<Resource> FindResources(ResourceData resourceData)
        {
            return ArmResources.Where(resource => resource.ResourceData == resourceData);
        }


        private TypeProvider BuildModel(Schema schema) => schema switch
        {
            SealedChoiceSchema sealedChoiceSchema => (TypeProvider)new EnumType(sealedChoiceSchema, _context),
            ChoiceSchema choiceSchema => new EnumType(choiceSchema, _context),
            ObjectSchema objectSchema => schema.Extensions != null && (schema.Extensions.MgmtReferenceType || schema.Extensions.MgmtPropertyReferenceType || schema.Extensions.MgmtTypeReferenceType)
            ? new MgmtReferenceType(objectSchema, _context)
            : new MgmtObjectType(objectSchema, _context),
            _ => throw new NotImplementedException()
        };

        private TypeProvider BuildResourceModel(Schema schema) => schema switch
        {
            ObjectSchema objectSchema => new ResourceData(objectSchema, _context),
            _ => throw new NotImplementedException()
        };

        private void ReorderOperationParameters()
        {
            foreach (var operationGroup in _codeModel.OperationGroups)
            {
                foreach (var operation in operationGroup.Operations)
                {
                    var httpRequest = operation.Requests.FirstOrDefault()?.Protocol.Http as HttpRequest;
                    if (httpRequest != null)
                    {
                        var orderedParams = operation.Parameters
                            .Where(p => p.In == ParameterLocation.Path)
                            .OrderBy(
                                p => httpRequest.Path.IndexOf(
                                    "{" + p.CSharpName() + "}",
                                    StringComparison.InvariantCultureIgnoreCase));
                        operation.Parameters = orderedParams.Concat(operation.Parameters
                                .Where(p => p.In != ParameterLocation.Path).ToList())
                            .ToList();
                    }
                }
            }
        }

        private void DecorateOperationSets()
        {
            foreach (var operationSet in _rawRequestPathToOperationSets.Values)
            {
                if (operationSet.TryGetResourceDataSchemaName(_mgmtConfiguration, out var resourceDataSchemaName))
                {
                    // if this operation set corresponds to a SDK resource, we add it to the map
                    HashSet<OperationSet>? result;
                    if (!_resourceDataSchemaNameToOperationSets.TryGetValue(resourceDataSchemaName, out result))
                    {
                        result = new HashSet<OperationSet>();
                        _resourceDataSchemaNameToOperationSets.Add(resourceDataSchemaName, result);
                    }
                    result.Add(operationSet);
                }
            }
        }

        private void CategorizeOperationGroups()
        {
            foreach (var operationGroup in _codeModel.OperationGroups)
            {
                var requestPathList = new HashSet<string>();
                _operationGroupToRequestPaths.Add(operationGroup, requestPathList);
                foreach (var operation in operationGroup.Operations)
                {
                    var path = operation.GetHttpPath();
                    requestPathList.Add(path);
                    if (_rawRequestPathToOperationSets.TryGetValue(path, out var operationSet))
                    {
                        operationSet.Add(operation, operationGroup);
                    }
                    else
                    {
                        operationSet = new OperationSet(path)
                        {
                            {operation, operationGroup }
                        };
                        _rawRequestPathToOperationSets.Add(path, operationSet);
                    }
                }
            }
        }
    }
}
