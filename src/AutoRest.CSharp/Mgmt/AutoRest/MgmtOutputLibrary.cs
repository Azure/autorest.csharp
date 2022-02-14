// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Management;
using Azure.ResourceManager.Resources;

namespace AutoRest.CSharp.Mgmt.AutoRest
{
    internal class MgmtOutputLibrary : OutputLibrary
    {
        /// <summary>
        /// This is a map from resource name to a list of <see cref="OperationSet"/>
        /// considering of the extension resources, one resource name might correspond to multiple operation sets
        /// This must be initialized before other maps
        /// </summary>
        private CachedDictionary<string, HashSet<OperationSet>> ResourceDataSchemaNameToOperationSets { get; }

        /// <summary>
        /// This is a map from raw request path to their corresponding <see cref="OperationSet"/>,
        /// which is a collection of the operations with the same raw request path
        /// </summary>
        private CachedDictionary<string, OperationSet> RawRequestPathToOperationSets { get; }

        /// <summary>
        /// This is a map from raw request path to the corresponding <see cref="MgmtRestClient"/>
        /// The type of values is a HashSet of <see cref="MgmtRestClient"/>, because we might get the case that multiple operation groups might share the same request path
        /// </summary>
        private CachedDictionary<string, HashSet<MgmtRestClient>> RawRequestPathToRestClient { get; }

        /// <summary>
        /// This is a map from raw request path to the corresponding <see cref="ResourceData"/>
        /// This must be initialized before other maps
        /// </summary>
        private CachedDictionary<string, ResourceData> RawRequestPathToResourceData { get; }

        /// <summary>
        /// This is a map from request path to the <see cref="ResourceObjectAssociation"/> which consists from <see cref="ResourceTypeSegment"/>, <see cref="Output.ResourceData"/>, <see cref="Resource"/> and <see cref="ResouColl"/>
        /// </summary>
        private CachedDictionary<RequestPath, ResourceObjectAssociation> RequestPathToResources { get; }

        public CachedDictionary<RestClientMethod, PagingMethod> PagingMethods { get; }

        private CachedDictionary<Operation, RestClientMethod> RestClientMethods { get; }

        private CachedDictionary<Schema, TypeProvider> AllSchemaMap { get; }

        public CachedDictionary<Schema, TypeProvider> ResourceSchemaMap { get; }

        internal CachedDictionary<Schema, TypeProvider> SchemaMap { get; }

        private CachedDictionary<string, HashSet<Operation>> ChildOperations { get; }

        private Dictionary<string, TypeProvider> _nameToTypeProvider;
        private IEnumerable<Schema> _allSchemas;

        private Dictionary<string, string> _mergedOperations;

        /// <summary>
        /// This is a map from <see cref="OperationGroup"/> to the list of raw request path of its operations
        /// </summary>
        private Dictionary<OperationGroup, IEnumerable<string>> _operationGroupToRequestPaths;

        public MgmtOutputLibrary()
        {
            OmitOperationGroups.RemoveOperationGroups();
            MgmtContext.CodeModel.UpdateSubscriptionIdForAllResource();
            _operationGroupToRequestPaths = new Dictionary<OperationGroup, IEnumerable<string>>();
            RawRequestPathToOperationSets = new CachedDictionary<string, OperationSet>(CategorizeOperationGroups);
            ResourceDataSchemaNameToOperationSets = new CachedDictionary<string, HashSet<OperationSet>>(DecorateOperationSets);
            RawRequestPathToRestClient = new CachedDictionary<string, HashSet<MgmtRestClient>>(EnsureRestClients);
            RawRequestPathToResourceData = new CachedDictionary<string, ResourceData>(EnsureRequestPathToResourceData);
            RequestPathToResources = new CachedDictionary<RequestPath, ResourceObjectAssociation>(EnsureRequestPathToResourcesMap);
            PagingMethods = new CachedDictionary<RestClientMethod, PagingMethod>(EnsurePagingMethods);
            RestClientMethods = new CachedDictionary<Operation, RestClientMethod>(EnsureRestClientMethods);
            AllSchemaMap = new CachedDictionary<Schema, TypeProvider>(InitializeModels);
            ResourceSchemaMap = new CachedDictionary<Schema, TypeProvider>(EnsureResourceSchemaMap);
            SchemaMap = new CachedDictionary<Schema, TypeProvider>(EnsureSchemaMap);
            ChildOperations = new CachedDictionary<string, HashSet<Operation>>(EnsureResourceChildOperations);
            _nameToTypeProvider = new Dictionary<string, TypeProvider>();
            _mergedOperations = MgmtContext.MgmtConfiguration.MergeOperations
                .SelectMany(kv => kv.Value.Select(v => (FullOperationName: v, MethodName: kv.Key)))
                .ToDictionary(kv => kv.FullOperationName, kv => kv.MethodName);
            _allSchemas = MgmtContext.CodeModel.Schemas.Choices.Cast<Schema>()
                .Concat(MgmtContext.CodeModel.Schemas.SealedChoices)
                .Concat(MgmtContext.CodeModel.Schemas.Objects)
                .Concat(MgmtContext.CodeModel.Schemas.Groups);
            _allSchemas.UpdateAcronyms();
            _allSchemas.UpdateFrameworkTypes();

            // We can only manipulate objects from the code model, not RestClientMethod
            ReorderOperationParameters();
        }

        public Dictionary<CSharpType, OperationSource> CSharpTypeToOperationSource { get; } = new Dictionary<CSharpType, OperationSource>();

        public IEnumerable<OperationSource> OperationSources => CSharpTypeToOperationSource.Values;

        // Initialize ResourceData, Models and resource manager common types
        private Dictionary<Schema, TypeProvider> InitializeModels()
        {
            //_models = new Dictionary<Schema, TypeProvider>();
            var resourceModels = new Dictionary<Schema, TypeProvider>();

            // first, construct models and resource data models
            foreach (var schema in _allSchemas)
            {
                if (ResourceDataSchemaNameToOperationSets.ContainsKey(schema.Name))
                {
                    var model = BuildResourceModel(schema);
                    resourceModels.Add(schema, model);
                    _nameToTypeProvider.Add(schema.Name, model); // TODO: ADO #5829 create new dictionary that allows look-up with multiple key types to eliminate duplicate dictionaries
                }
                else
                {
                    var model = BuildModel(schema);
                    resourceModels.Add(schema, model);
                    _nameToTypeProvider.Add(schema.Name, model);
                }

            }

            // second, collect any model which can be replaced as whole (not as a property or as a base class)
            var replacedTypes = new List<MgmtObjectType>();
            foreach (var schema in MgmtContext.CodeModel.Schemas.Objects)
            {
                TypeProvider? type;

                if (resourceModels.TryGetValue(schema, out type))
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
                                    replacedTypes.Add(new ResourceData(schema, csharpType.Name, csharpType.Namespace));
                                    break;
                                case MgmtReferenceType referenceType:
                                    replacedTypes.Add(new MgmtReferenceType(schema, csharpType.Name, csharpType.Namespace));
                                    break;
                                default:
                                    replacedTypes.Add(new MgmtObjectType(schema, csharpType.Name, csharpType.Namespace));
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
                resourceModels[schema] = replacedType;
            }

            return resourceModels;
        }

        private IEnumerable<OperationSet>? _resourceOperationSets;
        public IEnumerable<OperationSet> ResourceOperationSets => _resourceOperationSets ??= ResourceDataSchemaNameToOperationSets.SelectMany(pair => pair.Value);

        public OperationSet GetOperationSet(string requestPath)
        {
            return RawRequestPathToOperationSets[requestPath];
        }

        public RestClientMethod GetRestClientMethod(Operation operation) => RestClientMethods[operation];

        private Dictionary<RestClientMethod, PagingMethod> EnsurePagingMethods()
        {
            var pagingMethods = new Dictionary<RestClientMethod, PagingMethod>();
            var placeholder = new TypeDeclarationOptions("Placeholder", "Placeholder", "public", false, true);
            foreach (var restClient in RestClients)
            {
                var methods = ClientBuilder.BuildPagingMethods(restClient.OperationGroup, restClient, placeholder);
                foreach (var method in methods)
                {
                    pagingMethods.Add(method.Method, method);
                }
            }

            return pagingMethods;
        }

        private Dictionary<Operation, RestClientMethod> EnsureRestClientMethods()
        {
            var restClientMethods = new Dictionary<Operation, RestClientMethod>();
            foreach (var restClient in RestClients)
            {
                foreach (var restClientMethod in restClient.Methods)
                {
                    // skip all internal methods
                    if (restClientMethod.Accessibility != "public")
                        continue;
                    restClientMethods.Add(restClientMethod.Operation, restClientMethod);
                }
            }

            return restClientMethods;
        }

        public ArmClientExtensions ArmClientExtensions => EnsureArmClientExtensions();

        private MgmtExtensions? _tenantExtensions;
        private MgmtExtensions? _managementGroupExtensions;
        private MgmtExtensions? _subscriptionExtensions;
        private MgmtExtensions? _resourceGroupsExtensions;
        private MgmtExtensions? _armResourceExtensions;
        public MgmtExtensions TenantExtensions => _tenantExtensions ??= EnsureExtensions(typeof(Tenant), RequestPath.Tenant);
        public MgmtExtensions SubscriptionExtensions => _subscriptionExtensions ??= EnsureExtensions(typeof(Subscription), RequestPath.Subscription);
        public MgmtExtensions ResourceGroupExtensions => _resourceGroupsExtensions ??= EnsureExtensions(typeof(ResourceGroup), RequestPath.ResourceGroup);
        public MgmtExtensions ManagementGroupExtensions => _managementGroupExtensions ??= EnsureExtensions(typeof(ManagementGroup), RequestPath.ManagementGroup);
        public MgmtExtensions ArmResourceExtensions => _armResourceExtensions ??= EnsureExtensions(typeof(ArmResource), RequestPath.Any);

        private MgmtExtensionClient? _tenantExtensionClient;
        private MgmtExtensionClient? _managementGroupExtensionClient;
        private MgmtExtensionClient? _subscriptionExtensionClient;
        private MgmtExtensionClient? _resourceGroupExtensionClient;
        public MgmtExtensionClient SubscriptionExtensionsClient => _subscriptionExtensionClient ??= EnsureExtensionsClient(SubscriptionExtensions);
        public MgmtExtensionClient ResourceGroupExtensionsClient => _resourceGroupExtensionClient ??= EnsureExtensionsClient(ResourceGroupExtensions);
        public MgmtExtensionClient TenantExtensionsClient => _tenantExtensionClient ??= EnsureExtensionsClient(TenantExtensions);
        public MgmtExtensionClient ManagementGroupExtensionsClient => _managementGroupExtensionClient ??= EnsureExtensionsClient(ManagementGroupExtensions);

        private MgmtExtensionClient EnsureExtensionsClient(MgmtExtensions publicExtension) =>
            new MgmtExtensionClient(publicExtension);

        private MgmtExtensions EnsureExtensions(Type armCoreType, RequestPath contextualPath)
        {
            bool shouldGenerateChildren = MgmtContext.MgmtConfiguration.IsArmCore ? armCoreType.Namespace != MgmtContext.Context.DefaultNamespace : true;
            var operations = shouldGenerateChildren ? GetChildOperations(contextualPath) : Enumerable.Empty<Operation>();
            return new MgmtExtensions(operations, armCoreType, contextualPath);
        }

        private ArmClientExtensions? _armClientExtensions;
        private ArmClientExtensions EnsureArmClientExtensions()
        {
            if (_armClientExtensions != null)
                return _armClientExtensions;

            _armClientExtensions = new ArmClientExtensions(GetChildOperations(RequestPath.Tenant));
            return _armClientExtensions;
        }

        private IEnumerable<ResourceData>? _resourceDatas;
        public IEnumerable<ResourceData> ResourceData => _resourceDatas ??= RawRequestPathToResourceData.Values.Distinct();

        private IEnumerable<MgmtRestClient>? _restClients;
        public IEnumerable<MgmtRestClient> RestClients => _restClients ??= RawRequestPathToRestClient.Values.SelectMany(v => v).Distinct();

        private IEnumerable<Resource>? _armResources;
        public IEnumerable<Resource> ArmResources => _armResources ??= RequestPathToResources.Values.Select(bag => bag.Resource).Distinct();

        private Dictionary<CSharpType, Resource>? _csharpTypeToResource;
        public Dictionary<CSharpType, Resource> CsharpTypeToResource => _csharpTypeToResource ??= ArmResources.ToDictionary(resource => resource.Type, resource => resource);

        private IEnumerable<ResourceCollection>? _resourceCollections;
        public IEnumerable<ResourceCollection> ResourceCollections => _resourceCollections ??= RequestPathToResources.Values.Select(bag => bag.ResourceCollection).WhereNotNull().Distinct();

        private Dictionary<Schema, TypeProvider> EnsureResourceSchemaMap()
        {
            return AllSchemaMap.Where(kv => kv.Value is ResourceData).ToDictionary(kv => kv.Key, kv => kv.Value);
        }

        private Dictionary<Schema, TypeProvider> EnsureSchemaMap()
        {
            return AllSchemaMap.Where(kv => !(kv.Value is ResourceData)).ToDictionary(kv => kv.Key, kv => kv.Value);
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

        public ResourceData GetResourceData(string requestPath)
        {
            if (TryGetResourceData(requestPath, out var resourceData))
                return resourceData;

            throw new InvalidOperationException($"Request path {requestPath} does not correspond to a ResourceData");
        }

        public bool TryGetResourceData(string requestPath, [MaybeNullWhen(false)] out ResourceData resourceData)
        {
            return RawRequestPathToResourceData.TryGetValue(requestPath, out resourceData);
        }

        public bool TryGetArmResource(RequestPath requestPath, [MaybeNullWhen(false)] out Resource resource)
        {
            resource = null;
            if (RequestPathToResources.TryGetValue(requestPath, out var bag))
            {
                resource = bag.Resource;
                return true;
            }

            return false;
        }

        public bool TryGetResourceCollection(RequestPath requestPath, out ResourceCollection? collection)
        {
            collection = null;
            if (RequestPathToResources.TryGetValue(requestPath, out var bag))
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
            return RawRequestPathToRestClient.TryGetValue(requestPath, out restClients);
        }

        private Dictionary<string, HashSet<MgmtRestClient>> EnsureRestClients()
        {
            var rawRequestPathToRestClient = new Dictionary<string, HashSet<MgmtRestClient>>();
            foreach (var operationGroup in MgmtContext.CodeModel.OperationGroups)
            {
                var restClient = new MgmtRestClient(operationGroup);
                foreach (var requestPath in _operationGroupToRequestPaths[operationGroup])
                {
                    if (rawRequestPathToRestClient.TryGetValue(requestPath, out var set))
                        set.Add(restClient);
                    else
                        rawRequestPathToRestClient.Add(requestPath, new HashSet<MgmtRestClient> { restClient });
                }
            }

            return rawRequestPathToRestClient;
        }

        private Dictionary<RequestPath, ResourceObjectAssociation> EnsureRequestPathToResourcesMap()
        {
            var requestPathToResources = new Dictionary<RequestPath, ResourceObjectAssociation>();

            foreach ((var resourceName, var operationSets) in ResourceDataSchemaNameToOperationSets)
            {
                var resourceOperationsList = FindResourceToChildOperationsMap(operationSets);
                foreach (var resourceOperations in resourceOperationsList)
                {
                    // ensure this set of OperationSets are either all singletons, or none of them is singleton
                    Debug.Assert(resourceOperations.Keys.All(operationSet => operationSet.IsSingletonResource())
                        || resourceOperations.Keys.All(operationSet => !operationSet.IsSingletonResource()));
                    var isSingleton = resourceOperations.Keys.Any(operationSet => operationSet.IsSingletonResource());
                    // get the corresponding resource data
                    var originalResourcePaths = resourceOperations.Keys.Select(operationSet => operationSet.GetRequestPath());
                    var resourceDatas = originalResourcePaths.Select(path => GetResourceData(path)).Distinct();
                    if (resourceDatas.Count() != 1)
                        throw new InvalidOperationException($"{resourceDatas.Count()} ResourceData instances were found corresponding to the resource (RequestPath: [{string.Join(", ", originalResourcePaths)}]), please double confirm and separate them into different resources");
                    var resourceData = resourceDatas.Single();
                    // we calculate the resource type of the resource
                    var resourcePaths = originalResourcePaths.Select(path => path.Expand()).Distinct(new RequestPathCollectionEqualityComparer()).Single();
                    foreach (var resourcePath in resourcePaths)
                    {
                        var resourceType = resourcePath.GetResourceType();
                        var resource = new Resource(resourceOperations, resourceName, resourceType, resourceData);
                        var collection = isSingleton ? null : new ResourceCollection(resourceOperations, resource);
                        resource.ResourceCollection = collection;

                        requestPathToResources.Add(resourcePath, new ResourceObjectAssociation(resourceType, resourceData, resource, collection));
                    }
                }
            }

            return requestPathToResources;
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
            if (requestPath == RequestPath.Any)
                return Enumerable.Empty<Operation>();

            if (EnsureResourceChildOperations().TryGetValue(requestPath, out var operations))
                return operations;

            return Enumerable.Empty<Operation>();
        }

        private Dictionary<string, HashSet<Operation>> EnsureResourceChildOperations()
        {
            var childOperations = new Dictionary<string, HashSet<Operation>>();
            foreach ((var requestPath, var operationSet) in RawRequestPathToOperationSets)
            {
                if (operationSet.IsResource())
                    continue;
                foreach (var operation in operationSet)
                {
                    var parentRequestPath = operation.ParentRequestPath();
                    if (childOperations.TryGetValue(parentRequestPath, out var list))
                        list.Add(operation);
                    else
                        childOperations.Add(parentRequestPath, new HashSet<Operation> { operation });
                }
            }

            return childOperations;
        }

        private Dictionary<string, ResourceData> EnsureRequestPathToResourceData()
        {
            var rawRequestPathToResourceData = new Dictionary<string, ResourceData>();
            foreach (var entry in ResourceSchemaMap)
            {
                var schema = entry.Key;
                if (ResourceDataSchemaNameToOperationSets.TryGetValue(schema.Name, out var operationSets))
                {
                    // we are iterating over the ResourceSchemaMap, the value can only be [ResourceData]s
                    var resourceData = (ResourceData)entry.Value;
                    foreach (var operationSet in operationSets)
                    {
                        if (!rawRequestPathToResourceData.ContainsKey(operationSet.RequestPath))
                        {
                            rawRequestPathToResourceData.Add(operationSet.RequestPath, resourceData);
                        }
                    }
                }
            }

            return rawRequestPathToResourceData;
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
            SealedChoiceSchema sealedChoiceSchema => (TypeProvider)new EnumType(sealedChoiceSchema, MgmtContext.Context),
            ChoiceSchema choiceSchema => new EnumType(choiceSchema, MgmtContext.Context),
            ObjectSchema objectSchema => schema.Extensions != null && (schema.Extensions.MgmtReferenceType || schema.Extensions.MgmtPropertyReferenceType || schema.Extensions.MgmtTypeReferenceType)
            ? new MgmtReferenceType(objectSchema)
            : new MgmtObjectType(objectSchema),
            _ => throw new NotImplementedException()
        };

        private TypeProvider BuildResourceModel(Schema schema) => schema switch
        {
            ObjectSchema objectSchema => new ResourceData(objectSchema),
            _ => throw new NotImplementedException()
        };

        private void ReorderOperationParameters()
        {
            foreach (var operationGroup in MgmtContext.CodeModel.OperationGroups)
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

        private Dictionary<string, HashSet<OperationSet>> DecorateOperationSets()
        {
            Dictionary<string, HashSet<OperationSet>> resourceDataSchemaNameToOperationSets = new Dictionary<string, HashSet<OperationSet>>();
            foreach (var operationSet in RawRequestPathToOperationSets.Values)
            {
                if (operationSet.TryGetResourceDataSchemaName(out var resourceDataSchemaName))
                {
                    // if this operation set corresponds to a SDK resource, we add it to the map
                    HashSet<OperationSet>? result;
                    if (!resourceDataSchemaNameToOperationSets.TryGetValue(resourceDataSchemaName, out result))
                    {
                        result = new HashSet<OperationSet>();
                        resourceDataSchemaNameToOperationSets.Add(resourceDataSchemaName, result);
                    }
                    result.Add(operationSet);
                }
            }

            // check the patch operations in all the operationSets that correspond to a resource. If it only updates the tags, we remove it from the operation set
            foreach (var operationSet in resourceDataSchemaNameToOperationSets.Values.SelectMany(v => v))
            {
                // get the Patch operation from this OperationSet
                var operation = operationSet.FindOperation(HttpMethod.Patch);
                if (operation is null)
                    continue;

                var operationId = operation.OperationId(operationSet[operation]);

                var bodyParameter = operation.GetBodyParameter();
                if (bodyParameter is null)
                    continue;

                if (!bodyParameter.IsRequired)
                    throw new ErrorHelpers.ErrorException($"Patch operation {operation.GetHttpPath()} (operationId: {operationId}) has optional body parameter, please correct this using directive.");

                var bodySchema = bodyParameter.Schema;
                if (bodySchema is null)
                    continue;

                if (bodySchema.IsTagsOnly())
                {
                    // remove this operation from this operation set
                    operationSet.Remove(operation);
                }
            }
            return resourceDataSchemaNameToOperationSets;
        }

        private Dictionary<string, OperationSet> CategorizeOperationGroups()
        {
            Dictionary<string, OperationSet> rawRequestPathToOperationSets = new Dictionary<string, OperationSet>();
            foreach (var operationGroup in MgmtContext.CodeModel.OperationGroups)
            {
                var requestPathList = new HashSet<string>();
                _operationGroupToRequestPaths.Add(operationGroup, requestPathList);
                foreach (var operation in operationGroup.Operations)
                {
                    var path = operation.GetHttpPath();
                    requestPathList.Add(path);
                    if (rawRequestPathToOperationSets.TryGetValue(path, out var operationSet))
                    {
                        operationSet.Add(operation, operationGroup);
                    }
                    else
                    {
                        operationSet = new OperationSet(path)
                        {
                            {operation, operationGroup }
                        };
                        rawRequestPathToOperationSets.Add(path, operationSet);
                    }
                }
            }
            return rawRequestPathToOperationSets;
        }
    }
}
