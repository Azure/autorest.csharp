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
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure.ResourceManager;
using Azure.ResourceManager.ManagementGroups;
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
        /// This is a map from operation to its corresponding operation group
        /// </summary>
        private CachedDictionary<Operation, OperationGroup> OperationsToOperationGroups { get; }

        /// <summary>
        /// This is a map from operation to its request path
        /// </summary>
        private CachedDictionary<Operation, RequestPath> OperationsToRequestPaths { get; }

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
        private readonly Dictionary<OperationGroup, IEnumerable<string>> _operationGroupToRequestPaths;

        public MgmtOutputLibrary()
        {
            OmitOperationGroups.RemoveOperationGroups();
            MgmtContext.CodeModel.UpdateSubscriptionIdForAllResource();
            _operationGroupToRequestPaths = new Dictionary<OperationGroup, IEnumerable<string>>();
            RawRequestPathToOperationSets = new CachedDictionary<string, OperationSet>(CategorizeOperationGroups);
            OperationsToOperationGroups = new CachedDictionary<Operation, OperationGroup>(PopulateOperationsToOperationGroups);
            OperationsToRequestPaths = new CachedDictionary<Operation, RequestPath>(PopulateOperationsToRequestPaths);
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
            _mergedOperations = Configuration.MgmtConfiguration.MergeOperations
                .SelectMany(kv => kv.Value.Select(v => (FullOperationName: v, MethodName: kv.Key)))
                .ToDictionary(kv => kv.FullOperationName, kv => kv.MethodName);
            MgmtContext.CodeModel.UpdateAcronyms();
            _allSchemas = MgmtContext.CodeModel.AllSchemas;
            UrlToUri.UpdateSuffix(_allSchemas);
            MgmtContext.CodeModel.UpdatePatchOperations();
            _allSchemas.VerifyAndUpdateFrameworkTypes();
            _allSchemas.UpdateSealChoiceTypes();
            CommonSingleWordModels.Update(_allSchemas);
            NormalizeParamNames.Update(ResourceDataSchemaNameToOperationSets);
            RenameTimeToOn.UpdateNames(_allSchemas);

            // We can only manipulate objects from the code model, not RestClientMethod
            ReorderOperationParameters();
        }

        public bool IsArmCore => Configuration.MgmtConfiguration.IsArmCore;

        public Dictionary<CSharpType, OperationSource> CSharpTypeToOperationSource { get; } = new Dictionary<CSharpType, OperationSource>();
        public IEnumerable<OperationSource> OperationSources => CSharpTypeToOperationSource.Values;

        private Dictionary<string, Schema> UpdateBodyParameterNames()
        {
            Dictionary<Schema, int> usageCounts = new Dictionary<Schema, int>();
            Dictionary<string, Schema> updatedModels = new Dictionary<string, Schema>();
            foreach (var operationGroup in MgmtContext.CodeModel.OperationGroups)
            {
                foreach (var operation in operationGroup.Operations)
                {
                    foreach (var request in operation.Requests)
                    {
                        var httpRequest = request.Protocol.Http as HttpRequest;
                        if (httpRequest is null)
                            continue;

                        var bodyParam = request.Parameters.FirstOrDefault(p => p.In == HttpParameterIn.Body)?.Schema;
                        if (bodyParam is null)
                            continue;

                        IncrementCount(usageCounts, bodyParam);
                    }
                    foreach (var response in operation.Responses)
                    {
                        var responseSchema = response.ResponseSchema;
                        if (responseSchema is null)
                            continue;

                        IncrementCount(usageCounts, responseSchema);
                    }
                }
            }

            foreach (var operationGroup in MgmtContext.CodeModel.OperationGroups)
            {
                foreach (var operation in operationGroup.Operations)
                {
                    foreach (var request in operation.Requests)
                    {
                        if (request.Protocol.Http is not HttpRequest httpRequest)
                            continue;

                        if (httpRequest.Method != HttpMethod.Patch && httpRequest.Method != HttpMethod.Put && httpRequest.Method != HttpMethod.Post)
                            continue;

                        var bodyParam = request.Parameters.FirstOrDefault(p => p.In == HttpParameterIn.Body);
                        if (bodyParam is null)
                            continue;

                        if (!usageCounts.TryGetValue(bodyParam.Schema, out var count))
                            continue;

                        if (count != 1)
                            continue;

                        RequestPath requestPath = RequestPath.FromOperation(operation, operationGroup);
                        var operationSet = RawRequestPathToOperationSets[requestPath];
                        var resourceDataModelName = ResourceDataSchemaNameToOperationSets.FirstOrDefault(kv => kv.Value.Contains(operationSet));
                        if (resourceDataModelName.Key is not null)
                        {
                            //TODO handle expandable request paths.  We assume that this is fine since if all of the expanded
                            //types use the same model they should have a common name, but since this case doesn't exist yet
                            //we don't know for sure
                            if (requestPath.IsExpandable)
                                throw new InvalidOperationException($"Found expandable path in UpdatePatchParameterNames for {operationGroup.Key}.{operation.CSharpName()} : {requestPath}");
                            var name = GetResourceName(resourceDataModelName.Key, operationSet, requestPath);
                            updatedModels.Add(bodyParam.Schema.Language.Default.Name, bodyParam.Schema);
                            BodyParameterNormalizer.Update(httpRequest.Method, operation.CSharpName(), bodyParam, name);
                        }
                    }
                }
            }
            return updatedModels;
        }

        private static void IncrementCount(Dictionary<Schema, int> usageCounts, Schema schema)
        {
            if (usageCounts.ContainsKey(schema))
            {
                usageCounts[schema]++;
            }
            else
            {
                usageCounts.Add(schema, 1);
            }
        }

        // Initialize ResourceData, Models and resource manager common types
        private Dictionary<Schema, TypeProvider> InitializeModels()
        {
            var resourceModels = new Dictionary<Schema, TypeProvider>();

            // first, construct resource data models
            foreach (var schema in _allSchemas)
            {
                var model = ResourceDataSchemaNameToOperationSets.ContainsKey(schema.Name) ? BuildResourceModel(schema) : BuildModel(schema);
                resourceModels.Add(schema, model);
                _nameToTypeProvider.Add(schema.Name, model); // TODO: ADO #5829 create new dictionary that allows look-up with multiple key types to eliminate duplicate dictionaries
            }

            //this is where we update
            var updatedModels = UpdateBodyParameterNames();
            foreach (var (oldName, schema) in updatedModels)
            {
                resourceModels.Remove(schema);
                _nameToTypeProvider.Remove(oldName);
                var model = BuildModel(schema);
                resourceModels.Add(schema, model);
                _nameToTypeProvider.Add(schema.Name, model);
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

        public OperationGroup GetOperationGroup(Operation operation) => OperationsToOperationGroups[operation];

        public OperationSet GetOperationSet(string requestPath) => RawRequestPathToOperationSets[requestPath];

        public RestClientMethod GetRestClientMethod(Operation operation) => RestClientMethods[operation];

        public RequestPath GetRequestPath(Operation operation) => OperationsToRequestPaths[operation];

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
                    if (restClientMethod.Accessibility != MethodSignatureModifiers.Public)
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
        public MgmtExtensions TenantExtensions => _tenantExtensions ??= EnsureExtensions(typeof(TenantResource), RequestPath.Tenant);
        public MgmtExtensions SubscriptionExtensions => _subscriptionExtensions ??= EnsureExtensions(typeof(SubscriptionResource), RequestPath.Subscription);
        public MgmtExtensions ResourceGroupExtensions => _resourceGroupsExtensions ??= EnsureExtensions(typeof(ResourceGroupResource), RequestPath.ResourceGroup);
        public MgmtExtensions ManagementGroupExtensions => _managementGroupExtensions ??= EnsureExtensions(typeof(ManagementGroupResource), RequestPath.ManagementGroup);
        public MgmtExtensions ArmResourceExtensions => _armResourceExtensions ??= EnsureExtensions(typeof(ArmResource), RequestPath.Any);

        public MgmtExtensionsWrapper ExtensionWrapper => EnsureExtensionsWrapper();

        private MgmtExtensionsWrapper? _extensionsWrapper;
        private MgmtExtensionsWrapper EnsureExtensionsWrapper()
        {
            if (_extensionsWrapper != null)
                return _extensionsWrapper;

            _extensionsWrapper = IsArmCore ?
                new MgmtExtensionsWrapper(new[] { TenantExtensions, ManagementGroupExtensions, ArmResourceExtensions }) :
                new MgmtExtensionsWrapper(new[] { TenantExtensions, SubscriptionExtensions, ResourceGroupExtensions, ManagementGroupExtensions, ArmResourceExtensions, ArmClientExtensions });
            return _extensionsWrapper;
        }

        private MgmtExtensionClient? _tenantExtensionClient;
        private MgmtExtensionClient? _managementGroupExtensionClient;
        private MgmtExtensionClient? _subscriptionExtensionClient;
        private MgmtExtensionClient? _resourceGroupExtensionClient;
        private MgmtExtensionClient? _armResourceExtensionClient;
        public MgmtExtensionClient SubscriptionExtensionsClient => _subscriptionExtensionClient ??= EnsureExtensionsClient(SubscriptionExtensions);
        public MgmtExtensionClient ResourceGroupExtensionsClient => _resourceGroupExtensionClient ??= EnsureExtensionsClient(ResourceGroupExtensions);
        public MgmtExtensionClient TenantExtensionsClient => _tenantExtensionClient ??= EnsureExtensionsClient(TenantExtensions);
        public MgmtExtensionClient ManagementGroupExtensionsClient => _managementGroupExtensionClient ??= EnsureExtensionsClient(ManagementGroupExtensions);
        public MgmtExtensionClient ArmResourceExtensionsClient => _armResourceExtensionClient ??= EnsureExtensionsClient(ArmResourceExtensions);

        private MgmtExtensionClient EnsureExtensionsClient(MgmtExtensions publicExtension) =>
            new MgmtExtensionClient(publicExtension);

        private MgmtExtensions EnsureExtensions(Type armCoreType, RequestPath contextualPath)
        {
            bool shouldGenerateChildren = !Configuration.MgmtConfiguration.IsArmCore || armCoreType.Namespace != MgmtContext.Context.DefaultNamespace;
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
                var restClient = new MgmtRestClient(operationGroup, new MgmtRestClientBuilder(operationGroup));
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

            foreach ((var resourceDataSchemaName, var operationSets) in ResourceDataSchemaNameToOperationSets)
            {
                var resourceOperationsList = FindResourceToChildOperationsMap(operationSets);
                foreach ((var operationSet, var operations) in resourceOperationsList)
                {
                    var isSingleton = operationSet.IsSingletonResource();
                    // get the corresponding resource data
                    var originalResourcePath = operationSet.GetRequestPath();
                    var resourceData = GetResourceData(originalResourcePath);
                    // we calculate the resource type of the resource
                    var resourcePaths = originalResourcePath.Expand();
                    foreach (var resourcePath in resourcePaths)
                    {
                        var resourceType = resourcePath.GetResourceType();
                        var resource = new Resource(operationSet, operations, GetResourceName(resourceDataSchemaName, operationSet, resourcePath), resourceType, resourceData);
                        var collection = isSingleton ? null : new ResourceCollection(operationSet, operations, resource);
                        resource.ResourceCollection = collection;

                        requestPathToResources.Add(resourcePath, new ResourceObjectAssociation(resourceType, resourceData, resource, collection));
                    }
                }
            }

            return requestPathToResources;
        }

        private string? GetDefaultNameFromConfiguration(OperationSet operationSet, ResourceTypeSegment resourceType)
        {
            if (Configuration.MgmtConfiguration.RequestPathToResourceName.TryGetValue(operationSet.RequestPath, out var name))
                return name;
            if (Configuration.MgmtConfiguration.RequestPathToResourceName.TryGetValue($"{operationSet.RequestPath}|{resourceType}", out name))
                return name;

            return null;
        }

        private string GetResourceName(string candidateName, OperationSet operationSet, RequestPath requestPath)
        {
            // read configuration to see if we could get a configuration for this resource
            var resourceType = requestPath.GetResourceType();
            var defaultNameFromConfig = GetDefaultNameFromConfiguration(operationSet, resourceType);
            if (defaultNameFromConfig != null)
                return defaultNameFromConfig;

            var resourcesWithSameName = ResourceDataSchemaNameToOperationSets[candidateName];
            var resourcesWithSameType = ResourceOperationSets
                .SelectMany(opSet => opSet.GetRequestPath().Expand())
                .Where(rqPath => rqPath.GetResourceType().Equals(resourceType));

            var isById = requestPath.IsById;
            int countOfSameResourceDataName = resourcesWithSameName.Count();
            int countOfSameResourceTypeName = resourcesWithSameType.Count();
            if (!isById)
            {
                // this is a regular resource and the name is unique
                if (countOfSameResourceDataName == 1)
                    return candidateName;

                // if countOfSameResourceDataName > 1, we need to have the resource types as the resource type name
                // if we have the unique resource type, we just use the resource type to construct our resource type name
                var types = resourceType.Types;
                var name = string.Join("", types.Select(segment => segment.ConstantValue.LastWordToSingular().FirstCharToUpperCase()));
                if (countOfSameResourceTypeName == 1)
                    return name;

                string parentPrefix = GetParentPrefix(requestPath);
                // if countOfSameResourceTypeName > 1, we will have to add the scope as prefix to fully qualify the resource type name
                // first we try to add the parent name as prefix
                if (!DoMultipleResourcesShareMyPrefixes(requestPath, parentPrefix, resourcesWithSameType))
                    return $"{parentPrefix}{name}";

                // if we get here, parent prefix is not enough, we try the resource name if it is a constant
                if (requestPath.Last().IsConstant)
                    return $"{requestPath.Last().ConstantValue.FirstCharToUpperCase()}{name}";

                // if we get here, we have tried all approaches to get a solid resource type name, throw an exception
                throw new InvalidOperationException($"Cannot determine a resource class name for resource with the request path: {requestPath}, please assign a valid resource name in `request-path-to-resource-name` section");
            }
            // if this resource is based on a "ById" operation
            // if we only have one resource class with this name - we have no choice but use this "ById" resource
            if (countOfSameResourceDataName == 1)
                return candidateName;

            // otherwise we need to add a "ById" suffix to make this resource to have a different name
            // TODO -- introduce a flag that suppress the exception here to be thrown which notice the user to assign a proper name in config
            return $"{candidateName}ById";
        }

        private string GetParentPrefix(RequestPath pathToWalk)
        {
            while (pathToWalk.Count > 2)
            {
                pathToWalk = pathToWalk.GetParent();
                if (RawRequestPathToResourceData.TryGetValue(pathToWalk.ToString()!, out var parentData))
                {
                    return parentData.Declaration.Name.Substring(0, parentData.Declaration.Name.Length - 4);
                }
                else
                {
                    var prefix = GetCoreParentName(pathToWalk);
                    if (prefix is not null)
                        return prefix;
                }
            }
            return string.Empty;
        }

        private string? GetCoreParentName(RequestPath requestPath)
        {
            var resourceType = requestPath.GetResourceType();
            if (resourceType.Equals(ResourceTypeSegment.ManagementGroup))
                return nameof(ResourceTypeSegment.ManagementGroup);
            if (resourceType.Equals(ResourceTypeSegment.ResourceGroup))
                return nameof(ResourceTypeSegment.ResourceGroup);
            if (resourceType.Equals(ResourceTypeSegment.Subscription))
                return nameof(ResourceTypeSegment.Subscription);
            if (resourceType.Equals(ResourceTypeSegment.Tenant))
                return nameof(ResourceTypeSegment.Tenant);
            return null;
        }

        private bool DoMultipleResourcesShareMyPrefixes(RequestPath requestPath, string parentPrefix, IEnumerable<RequestPath> resourcesWithSameType)
        {
            foreach (var resourcePath in resourcesWithSameType)
            {
                if (resourcePath.Equals(requestPath))
                    continue; //skip myself

                if (GetParentPrefix(resourcePath).Equals(parentPrefix, StringComparison.Ordinal))
                    return true;
            }
            return false;
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

        private Dictionary<OperationSet, IEnumerable<Operation>> FindResourceToChildOperationsMap(IEnumerable<OperationSet> resourceOperationSets)
        {
            return resourceOperationSets.ToDictionary(
                operationSet => operationSet,
                operationSet => GetChildOperations(operationSet.RequestPath));
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
            foreach (var operationSet in RawRequestPathToOperationSets.Values)
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
            if (!AllSchemaMap.IsPopulated)
            {
                result = ResourceDataSchemaNameToOperationSets.ContainsKey(schema.Name) ? BuildResourceModel(schema) : BuildModel(schema);
            }
            else if (!SchemaMap.TryGetValue(schema, out result) && !ResourceSchemaMap.TryGetValue(schema, out result))
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
                            .Where(p => p.In == HttpParameterIn.Path)
                            .OrderBy(
                                p => httpRequest.Path.IndexOf(
                                    "{" + p.CSharpName() + "}",
                                    StringComparison.InvariantCultureIgnoreCase));
                        operation.Parameters = orderedParams.Concat(operation.Parameters
                                .Where(p => p.In != HttpParameterIn.Path).ToList())
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
                    if (!resourceDataSchemaNameToOperationSets.TryGetValue(resourceDataSchemaName, out HashSet<OperationSet>? result))
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

                var bodySchema = operation.GetBodyParameter()?.Schema;
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
            var rawRequestPathToOperationSets = new Dictionary<string, OperationSet>();
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

        private Dictionary<Operation, RequestPath> PopulateOperationsToRequestPaths()
        {
            var operationsToRequestPath = new Dictionary<Operation, RequestPath>();
            foreach (var operationGroup in MgmtContext.CodeModel.OperationGroups)
            {
                foreach (var operation in operationGroup.Operations)
                {
                    operationsToRequestPath[operation] = RequestPath.FromOperation(operation, operationGroup);
                }
            }
            return operationsToRequestPath;
        }

        private Dictionary<Operation, OperationGroup> PopulateOperationsToOperationGroups()
        {
            var operationsToOperationGroups = new Dictionary<Operation, OperationGroup>();
            foreach (var operationGroup in MgmtContext.CodeModel.OperationGroups)
            {
                foreach (var operation in operationGroup.Operations)
                {
                    operationsToOperationGroups[operation] = operationGroup;
                }
            }
            return operationsToOperationGroups;
        }
    }
}
