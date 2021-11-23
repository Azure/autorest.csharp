// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
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
        /// This is a map from raw request path to the corresponding <see cref="Resource"/>
        /// </summary>
        private Dictionary<string, Resource>? _rawRequestPathToArmResource;

        /// <summary>
        /// This is a map from raw request path to the corresponding <see cref="ResourceCollection"/>
        /// </summary>
        private Dictionary<string, ResourceCollection>? _rawRequestPathToResourceCollection;

        /// <summary>
        /// This is a map from raw request path to the corresponding <see cref="ResourceData"/>
        /// This must be initialized before other maps
        /// </summary>
        private IDictionary<string, ResourceData>? _rawRequestPathToResourceData;

        /// <summary>
        /// This is a map from resource name to a list of <see cref="OperationSet"/>
        /// considering of the extension resources, one resource name might correspond to multiple operation sets
        /// This must be initialized before other maps
        /// </summary>
        private Dictionary<string, HashSet<OperationSet>> _resourceDataSchemaNameToOperationSets;

        private Dictionary<Schema, TypeProvider>? _resourceModels;
        private Dictionary<string, TypeProvider> _nameToTypeProvider;
        private IEnumerable<Schema> _allSchemas;
        private Dictionary<Operation, MgmtLongRunningOperation>? _longRunningOperations;
        private Dictionary<Operation, NonLongRunningOperation>? _nonLongRunningOperations;

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

        public MgmtOutputLibrary(CodeModel codeModel, BuildContext<MgmtOutputLibrary> context) : base(codeModel, context)
        {
            OmitOperationGroups.RemoveOperationGroups(codeModel, context);
            _context = context;
            _mgmtConfiguration = context.Configuration.MgmtConfiguration;
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

        public IDictionary<Operation, RestClientMethod> RestClientMethods => EnsureRestClientMethods();

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

        public ResourceGroupExtensions ResourceGroupExtensions => EnsureResourceGroupExtensions();

        public ManagementGroupExtensions ManagementGroupExtensions => EnsureManagementExtensions();

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

        private IEnumerable<ResourceData>? _resourceDatas;
        public IEnumerable<ResourceData> ResourceData => _resourceDatas ??= EnsureRequestPathToResourceData().Values.Distinct();

        private IEnumerable<MgmtRestClient>? _restClients;
        public IEnumerable<MgmtRestClient> RestClients => _restClients ??= EnsureRestClients().Values.SelectMany(v => v).Distinct();

        private IEnumerable<Resource>? _armResources;
        public IEnumerable<Resource> ArmResources => _armResources ??= EnsureRequestPathToArmResources().Values.Distinct();

        private IEnumerable<ResourceCollection>? _resourceCollections;
        public IEnumerable<ResourceCollection> ResourceCollections => _resourceCollections ??= EnsureRequestPathToResourceCollections().Values.Distinct();

        public IEnumerable<MgmtLongRunningOperation> LongRunningOperations => EnsureLongRunningOperations().Values;

        public IEnumerable<NonLongRunningOperation> NonLongRunningOperations => EnsureNonLongRunningOperations().Values;

        private Dictionary<Schema, TypeProvider>? _models;

        public Dictionary<Schema, TypeProvider> ResourceSchemaMap => _resourceModels ??= BuildResourceModels();

        internal Dictionary<Schema, TypeProvider> SchemaMap => _models ??= BuildModels();

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

        public ResourceCollection? GetResourceCollection(string requestPath)
        {
            if (TryGetResourceCollection(requestPath, out var collection))
                return collection;

            return null;
        }

        public bool TryGetResourceCollection(string requestPath, [MaybeNullWhen(false)] out ResourceCollection collection)
        {
            return EnsureRequestPathToResourceCollections().TryGetValue(requestPath, out collection);
        }

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

        public Resource GetArmResource(string requestPath)
        {
            if (TryGetArmResource(requestPath, out var resource))
                return resource;

            throw new InvalidOperationException($"Cannot get Resource corresponding to {requestPath}");
        }

        public bool TryGetArmResource(string requestPath, [MaybeNullWhen(false)] out Resource resource)
        {
            return EnsureRequestPathToArmResources().TryGetValue(requestPath, out resource);
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

        internal LongRunningOperation GetLongRunningOperation(Operation op) => EnsureLongRunningOperations()[op];

        internal NonLongRunningOperation GetNonLongRunningOperation(Operation op) => EnsureNonLongRunningOperations()[op];

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

        private Dictionary<string, Resource> EnsureRequestPathToArmResources()
        {
            if (_rawRequestPathToArmResource != null)
                return _rawRequestPathToArmResource;

            _rawRequestPathToArmResource = new Dictionary<string, Resource>();
            foreach ((var resourceName, var operationSets) in _resourceDataSchemaNameToOperationSets)
            {
                var resourceOperationsList = FindResourceToChildOperationsMap(operationSets);
                foreach (var resourceOperations in resourceOperationsList)
                {
                    // TODO -- support the request path that contains multiple resource types
                    // we calculate the resource type of the resource
                    var resourceType = GetResourceType(resourceOperations.Keys);
                    var resource = new Resource(resourceOperations, resourceName, resourceType, _context);
                    // one resource might appear multiple times since one resource might corresponds to multiple request paths
                    foreach (var resourceOperationSet in resourceOperations.Keys)
                    {
                        _rawRequestPathToArmResource.Add(resourceOperationSet.RequestPath, resource);
                    }
                }
            }

            return _rawRequestPathToArmResource;
        }

        private ResourceType GetResourceType(IEnumerable<OperationSet> operationSets)
        {
            var resourceTypes = operationSets.Select(operationSet => operationSet.GetRequestPath(_context).GetResourceType(_mgmtConfiguration)).Distinct();

            if (resourceTypes.Count() > 1)
                throw new InvalidOperationException($"Request path(s) {string.Join(", ", operationSets.Select(set => set.GetRequestPath(_context)))} contain multiple resource types in it ({string.Join(", ", resourceTypes)}), please double check and override it in `request-path-to-resource-type` section.");

            var resourceType = resourceTypes.First();

            if (!resourceType.IsConstant)
                throw new InvalidOperationException($"The resource type of request path(s) {string.Join(", ", operationSets.Select(set => set.GetRequestPath(_context)))} contains variables in it, please double check and override it in `request-path-to-resource-type` section.");

            if (resourceType == ResourceType.Scope)
                throw new InvalidOperationException($"Request path(s) {string.Join(", ", operationSets.Select(set => set.GetRequestPath(_context)))} is a 'ById' resource, we cannot derive a resource type from its request path, please double check and override it in `request-path-to-resource-type` section.");

            return resourceType;
        }

        private Dictionary<string, ResourceCollection> EnsureRequestPathToResourceCollections()
        {
            if (_rawRequestPathToResourceCollection != null)
                return _rawRequestPathToResourceCollection;

            _rawRequestPathToResourceCollection = new Dictionary<string, ResourceCollection>();
            foreach ((var resourceName, var operationSets) in _resourceDataSchemaNameToOperationSets)
            {
                var resourceOperationsList = FindResourceToChildOperationsMap(operationSets);
                foreach (var resourceOperations in resourceOperationsList)
                {
                    // ensure this set of OperationSets are either all singletons, or none of them is singleton
                    Debug.Assert(resourceOperations.Keys.All(operationSet => operationSet.IsSingletonResource(_context))
                        || resourceOperations.Keys.All(operationSet => !operationSet.IsSingletonResource(_context)));
                    // check if this set of OperationSets are all singleton, singleton resource does not need resource collections
                    if (resourceOperations.Keys.All(operationSet => operationSet.IsSingletonResource(_context)))
                        continue;
                    var collection = new ResourceCollection(resourceOperations, resourceName, _context);
                    // one resource might appear multiple times since one resource might corresponds to multiple request paths
                    foreach (var resourceOperationSet in resourceOperations.Keys)
                    {
                        _rawRequestPathToResourceCollection.Add(resourceOperationSet.RequestPath, collection);
                    }
                }
            }

            return _rawRequestPathToResourceCollection;
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

        private Dictionary<Operation, MgmtLongRunningOperation> EnsureLongRunningOperations()
        {
            if (_longRunningOperations != null)
            {
                return _longRunningOperations;
            }

            _longRunningOperations = new Dictionary<Operation, MgmtLongRunningOperation>();

            if (_context.Configuration.PublicClients)
            {
                foreach (var operationSet in OperationSets)
                {
                    foreach (var operation in operationSet)
                    {
                        if (operation.IsLongRunning)
                        {
                            _longRunningOperations.Add(
                                operation,
                                new MgmtLongRunningOperation(
                                    operation,
                                    operationSet[operation],
                                    operation.FindLongRunningOperationInfo(_context),
                                    _context));
                        }
                    }
                }
            }
            return _longRunningOperations;
        }

        private Dictionary<Operation, NonLongRunningOperation> EnsureNonLongRunningOperations()
        {
            if (_nonLongRunningOperations != null)
            {
                return _nonLongRunningOperations;
            }

            _nonLongRunningOperations = new Dictionary<Operation, NonLongRunningOperation>();
            var desiredHttpMethods = new HttpMethod[] { HttpMethod.Put, HttpMethod.Delete, HttpMethod.Patch };

            if (_context.Configuration.PublicClients)
            {
                foreach (var operationSet in OperationSets)
                {
                    if (operationSet.IsResource(_mgmtConfiguration))
                    {
                        foreach (var operation in operationSet)
                        {
                            var httpRequest = operation.GetHttpRequest();
                            if (!operation.IsLongRunning && httpRequest != null && desiredHttpMethods.Contains(httpRequest.Method))
                            {
                                _nonLongRunningOperations.Add(
                                    operation,
                                    new NonLongRunningOperation(operation, operation.FindLongRunningOperationInfo(_context), _context));
                            }
                        }
                    }
                }
            }

            return _nonLongRunningOperations;
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
            var requestPaths = EnsureRequestPathToResourceData().Where(pair => pair.Value == resourceData).Select(pair => pair.Key).ToHashSet();
            return EnsureRequestPathToArmResources().Where(pair => requestPaths.Contains(pair.Key)).Select(pair => pair.Value);
        }

        private Dictionary<Schema, TypeProvider> BuildModels()
        {
            var models = new Dictionary<Schema, TypeProvider>();

            foreach (var schema in _allSchemas)
            {
                if (_resourceDataSchemaNameToOperationSets.ContainsKey(schema.Name))
                {
                    continue;
                }
                TypeProvider typeOfModel = BuildModel(schema);
                models.Add(schema, typeOfModel);
                _nameToTypeProvider.Add(schema.Name, typeOfModel);
            }
            return models;
        }

        private Dictionary<Schema, TypeProvider> BuildResourceModels()
        {
            var resourceModels = new Dictionary<Schema, TypeProvider>();

            foreach (var schema in _allSchemas)
            {
                if (_resourceDataSchemaNameToOperationSets.ContainsKey(schema.Name))
                {
                    TypeProvider typeOfModel = BuildResourceModel(schema);
                    resourceModels.Add(schema, typeOfModel);
                    _nameToTypeProvider.Add(schema.Name, typeOfModel); // TODO: ADO #5829 create new dictionary that allows look-up with multiple key types to eliminate duplicate dictionaries
                }
            }
            return resourceModels;
        }

        private TypeProvider BuildModel(Schema schema) => schema switch
        {
            SealedChoiceSchema sealedChoiceSchema => (TypeProvider)new EnumType(sealedChoiceSchema, _context),
            ChoiceSchema choiceSchema => new EnumType(choiceSchema, _context),
            ObjectSchema objectSchema => schema.Extensions != null && (schema.Extensions.MgmtReferenceType || schema.Extensions.MgmtPropertyReferenceType)
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
