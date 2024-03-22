// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Common.Utilities;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Mgmt.Report;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure.Core;

namespace AutoRest.CSharp.Mgmt.AutoRest
{
    internal class MgmtOutputLibrary : OutputLibrary
    {
        /// <summary>
        /// This is a map from resource name to a list of <see cref="OperationSet"/>
        /// considering of the extension resources, one resource name might correspond to multiple operation sets
        /// This must be initialized before other maps
        /// </summary>
        private Dictionary<string, HashSet<OperationSet>> ResourceDataSchemaNameToOperationSets { get; }

        /// <summary>
        /// This is a map from raw request path to their corresponding <see cref="OperationSet"/>,
        /// which is a collection of the operations with the same raw request path
        /// </summary>
        internal Dictionary<string, OperationSet> RawRequestPathToOperationSets { get; }

        /// <summary>
        /// This is a map from operation to its request path
        /// </summary>
        private Lazy<IReadOnlyDictionary<InputOperation, RequestPath>> OperationsToRequestPaths { get; }

        /// <summary>
        /// This is a map from raw request path to the corresponding <see cref="MgmtRestClient"/>
        /// The type of values is a HashSet of <see cref="MgmtRestClient"/>, because we might get the case that multiple operation groups might share the same request path
        /// </summary>
        private Lazy<IReadOnlyDictionary<string, HashSet<MgmtRestClient>>> RawRequestPathToRestClient { get; }

        /// <summary>
        /// This is a map from raw request path to the corresponding <see cref="ResourceData"/>
        /// This must be initialized before other maps
        /// </summary>
        private Lazy<IReadOnlyDictionary<string, ResourceData>> RawRequestPathToResourceData { get; }

        /// <summary>
        /// This is a map from request path to the <see cref="ResourceObjectAssociation"/> which consists from <see cref="ResourceTypeSegment"/>, <see cref="Output.ResourceData"/>, <see cref="Resource"/> and <see cref="ResourceCollection"/>
        /// </summary>
        private Lazy<IReadOnlyDictionary<RequestPath, ResourceObjectAssociation>> RequestPathToResources { get; }

        public Lazy<IReadOnlyDictionary<RestClientMethod, PagingMethod>> PagingMethods { get; }

        private Lazy<IReadOnlyDictionary<InputOperation, RestClientMethod>> RestClientMethods { get; }

        private Lazy<IReadOnlyDictionary<InputType, TypeProvider>> AllSchemaMap { get; }

        public Lazy<IReadOnlyDictionary<InputType, TypeProvider>> ResourceSchemaMap { get; }

        internal Lazy<IReadOnlyDictionary<InputType, TypeProvider>> SchemaMap { get; }

        private Lazy<IReadOnlyDictionary<InputEnumType, EnumType>> AllEnumMap { get; }

        private Lazy<IReadOnlyDictionary<RequestPath, HashSet<InputOperation>>> ChildOperations { get; }

        private readonly InputNamespace _input;

        private readonly LookupDictionary<InputType, string, TypeProvider> _schemaOrNameToModels = new(schema => schema.Name);

        /// <summary>
        /// This is a collection that contains all the models from property bag, we use HashSet here to avoid potential duplicates
        /// </summary>
        public HashSet<TypeProvider> PropertyBagModels { get; }

        /// <summary>
        /// This is a map from <see cref="InputClient"/> to the list of raw request path of its operations
        /// </summary>
        private readonly Dictionary<InputClient, IEnumerable<string>> _operationGroupToRequestPaths = new();

        public MgmtOutputLibrary(InputNamespace inputNamespace)
        {
            _input = inputNamespace;

            // these dictionaries are initialized right now and they would not change later
            RawRequestPathToOperationSets = CategorizeOperationGroups();
            ResourceDataSchemaNameToOperationSets = DecorateOperationSets();
            AllEnumMap = new Lazy<IReadOnlyDictionary<InputEnumType, EnumType>>(EnsureAllEnumMap);
            AllSchemaMap = new Lazy<IReadOnlyDictionary<InputType, TypeProvider>>(InitializeModels);

            // others are populated later
            OperationsToRequestPaths = new Lazy<IReadOnlyDictionary<InputOperation, RequestPath>>(PopulateOperationsToRequestPaths);
            RawRequestPathToRestClient = new Lazy<IReadOnlyDictionary<string, HashSet<MgmtRestClient>>>(EnsureRestClients);
            RawRequestPathToResourceData = new Lazy<IReadOnlyDictionary<string, ResourceData>>(EnsureRequestPathToResourceData);
            RequestPathToResources = new Lazy<IReadOnlyDictionary<RequestPath, ResourceObjectAssociation>>(EnsureRequestPathToResourcesMap);
            PagingMethods = new Lazy<IReadOnlyDictionary<RestClientMethod, PagingMethod>>(EnsurePagingMethods);
            RestClientMethods = new Lazy<IReadOnlyDictionary<InputOperation, RestClientMethod>>(EnsureRestClientMethods);
            ResourceSchemaMap = new Lazy<IReadOnlyDictionary<InputType, TypeProvider>>(EnsureResourceSchemaMap);
            SchemaMap = new Lazy<IReadOnlyDictionary<InputType, TypeProvider>>(EnsureSchemaMap);
            ChildOperations = new Lazy<IReadOnlyDictionary<RequestPath, HashSet<InputOperation>>>(EnsureResourceChildOperations);

            // initialize the property bag collection
            // TODO -- considering provide a customized comparer
            PropertyBagModels = new HashSet<TypeProvider>();
        }

        public Dictionary<CSharpType, OperationSource> CSharpTypeToOperationSource { get; } = new Dictionary<CSharpType, OperationSource>();
        public IEnumerable<OperationSource> OperationSources => CSharpTypeToOperationSource.Values;

        public ICollection<LongRunningInterimOperation> InterimOperations { get; } = new List<LongRunningInterimOperation>();

        private void UpdateBodyParameters()
        {
            Dictionary<InputType, int> usageCounts = new Dictionary<InputType, int>(ReferenceEqualityComparer.Instance);

            // run one pass to get the schema usage count
            foreach (var client in _input.Clients)
            {
                foreach (var operation in client.Operations)
                {
                    foreach (var parameter in operation.Parameters)
                    {
                        if (parameter.Location != RequestLocation.Body)
                            continue;

                        IncrementCount(usageCounts, parameter.Type);
                    }
                    foreach (var response in operation.Responses)
                    {
                        var responseSchema = response.BodyType;
                        if (responseSchema is null)
                            continue;

                        IncrementCount(usageCounts, responseSchema);
                    }
                }
            }

            // run second pass to rename the ones based on the schema usage count
            foreach (var client in _input.Clients)
            {
                foreach (var operation in client.Operations)
                {
                    if (operation.HttpMethod != RequestMethod.Patch && operation.HttpMethod != RequestMethod.Put && operation.HttpMethod != RequestMethod.Post)
                        continue;

                    var bodyParam = operation.Parameters.FirstOrDefault(p => p.Location == RequestLocation.Body);
                    if (bodyParam is null)
                        continue;

                    if (!usageCounts.TryGetValue(bodyParam.Type, out var count))
                        continue;

                    // get the request path and operation set
                    RequestPath requestPath = RequestPath.FromOperation(operation, client, MgmtContext.TypeFactory);
                    var operationSet = RawRequestPathToOperationSets[requestPath];
                    if (operationSet.TryGetResourceDataSchema(out var resourceDataSchema))
                    {
                        // if this is a resource, we need to make sure its body parameter is required when the verb is put or patch
                        BodyParameterNormalizer.MakeRequired(bodyParam, operation.HttpMethod);
                    }

                    if (count != 1)
                    {
                        //even if it has multiple uses for a model type we should normalize the param name just not change the type
                        BodyParameterNormalizer.UpdateParameterNameOnly(bodyParam, ResourceDataSchemaNameToOperationSets, operation);
                        continue;
                    }
                    if (resourceDataSchema is not null)
                    {
                        //TODO handle expandable request paths. We assume that this is fine since if all of the expanded
                        //types use the same model they should have a common name, but since this case doesn't exist yet
                        //we don't know for sure
                        if (requestPath.IsExpandable)
                            throw new InvalidOperationException($"Found expandable path in UpdatePatchParameterNames for {client.Key}.{operation.CSharpName()} : {requestPath}");
                        var name = GetResourceName(resourceDataSchema.Name, operationSet, requestPath);
                        BodyParameterNormalizer.Update(operation.HttpMethod, bodyParam, name, operation);
                    }
                    else
                    {
                        BodyParameterNormalizer.UpdateUsingReplacement(bodyParam, ResourceDataSchemaNameToOperationSets, operation);
                    }
                }
            }

            // run third pass to rename the corresponding parameters
            foreach (var client in _input.Clients)
            {
                foreach (var operation in client.Operations)
                {
                    foreach (var param in operation.Parameters)
                    {
                        if (param.Location != RequestLocation.Body)
                            continue;

                        if (param.Type is not InputModelType inputModel)
                            continue;

                        string originalName = param.Name;
                        param.Name = NormalizeParamNames.GetNewName(originalName, inputModel.Name, ResourceDataSchemaNameToOperationSets);

                        string fullSerializedName = operation.GetFullSerializedName(param);
                        MgmtReport.Instance.TransformSection.AddTransformLogForApplyChange(
                            new TransformItem(TransformTypeName.UpdateBodyParameter, fullSerializedName),
                            fullSerializedName, "SetBodyParameterNameOnThirdPass", originalName, param.Name);

                    }
                }
            }
        }

        private static void IncrementCount(Dictionary<InputType, int> usageCounts, InputType schema)
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
        private Dictionary<InputType, TypeProvider> InitializeModels()
        {
            var defaultDerivedTypes = new Dictionary<string, MgmtObjectType>();
            // first, construct resource data models
            foreach (var inputModel in _input.Models)
            {
                var defaultDerivedType = GetDefaultDerivedType(inputModel, defaultDerivedTypes);
                var model = ResourceDataSchemaNameToOperationSets.ContainsKey(inputModel.Name) ? BuildResourceData(inputModel, defaultDerivedType) : BuildModel(inputModel, defaultDerivedType);
                _schemaOrNameToModels.Add(inputModel, model);
            }

            foreach (var inputEnum in _input.Enums)
            {
                var model = BuildModel(inputEnum);
                _schemaOrNameToModels.Add(inputEnum, model);
            }

            //this is where we update
            UpdateBodyParameters();

            // second, collect any model which can be replaced as whole (not as a property or as a base class)
            var replacedTypes = new Dictionary<InputModelType, TypeProvider>();
            foreach (var schema in _input.Models)
            {
                if (_schemaOrNameToModels.TryGetValue(schema, out var type))
                {
                    if (type is MgmtObjectType mgmtObjectType)
                    {
                        var csharpType = TypeReferenceTypeChooser.GetExactMatch(mgmtObjectType);
                        if (csharpType != null)
                        {
                            // re-construct the model with replaced csharp type (e.g. the type in Resource Manager)
                            switch (mgmtObjectType)
                            {
                                case MgmtReferenceType:
                                    // when we get a reference type, we should still wrap it into a reference type
                                    replacedTypes.Add(schema, new MgmtReferenceType(schema, csharpType.Name, csharpType.Namespace));
                                    break;
                                default:
                                    // other types will go into SystemObjectType
                                    replacedTypes.Add(schema, csharpType.Implementation);
                                    break;
                            }
                        }
                    }
                }
            }

            // third, update the entries in cache maps with the new model instances
            foreach (var (schema, replacedType) in replacedTypes)
            {
                var originalModel = _schemaOrNameToModels[schema];
                _schemaOrNameToModels[schema] = replacedType;
                MgmtReport.Instance.TransformSection.AddTransformLogForApplyChange(
                    new TransformItem(TransformTypeName.ReplaceTypeWhenInitializingModel, schema.GetFullSerializedName()),
                    schema.GetFullSerializedName(),
                    "ReplaceType", originalModel.Declaration.FullName, replacedType.Declaration.FullName);
            }
            return _schemaOrNameToModels;
        }

        private IEnumerable<OperationSet>? _resourceOperationSets;
        public IEnumerable<OperationSet> ResourceOperationSets => _resourceOperationSets ??= ResourceDataSchemaNameToOperationSets.SelectMany(pair => pair.Value);


        private MgmtObjectType? GetDefaultDerivedType(InputModelType model, Dictionary<string, MgmtObjectType> defaultDerivedTypes)
        {
            //only want to create one instance of the default derived per polymorphic set
            bool isBasePolyType = model.DiscriminatorPropertyName is not null;
            bool isChildPolyType = model.DiscriminatorValue is not null;
            if (!isBasePolyType && !isChildPolyType)
            {
                return null;
            }

            var actualBase = model;
            while (actualBase.BaseModel?.DiscriminatorPropertyName is not null)
            {
                actualBase = actualBase.BaseModel;
            }

            //We don't need to create default type if its an input only model
            if (!actualBase.Usage.HasFlag(InputModelTypeUsage.Output))
                return null;

            string defaultDerivedName = $"Unknown{actualBase.Name}";
            if (!defaultDerivedTypes.TryGetValue(defaultDerivedName, out MgmtObjectType? defaultDerivedType))
            {
                //create the "Unknown" version
                var unknownDerivedType = new InputModelType(
                    defaultDerivedName,
                    actualBase.Namespace,
                    "internal",
                    null,
                    // [TODO]: Condition is added to minimize change
                    $"Unknown version of {actualBase.Name}",
                    actualBase.Usage,
                    Array.Empty<InputModelProperty>(),
                    actualBase,
                    Array.Empty<InputModelType>(),
                    "Unknown", //TODO: do we need to support extensible enum / int values?
                    null,
                    null,
                    false)
                {
                    IsUnknownDiscriminatorModel = true
                };

                defaultDerivedType = new MgmtObjectType(unknownDerivedType);
                defaultDerivedTypes.Add(defaultDerivedName, defaultDerivedType);
                _schemaOrNameToModels.Add(unknownDerivedType, defaultDerivedType);
            }

            return defaultDerivedType;
        }

        public OperationSet GetOperationSet(string requestPath) => RawRequestPathToOperationSets[requestPath];

        public RestClientMethod GetRestClientMethod(InputOperation operation)
        {
            if (RestClientMethods.Value.TryGetValue(operation, out var restClientMethod))
            {
                return restClientMethod;
            }
            throw new Exception($"The {operation.OperationId} method does not exist.");
        }

        public RequestPath GetRequestPath(InputOperation operation) => OperationsToRequestPaths.Value[operation];

        private Dictionary<RestClientMethod, PagingMethod> EnsurePagingMethods()
        {
            var pagingMethods = new Dictionary<RestClientMethod, PagingMethod>();
            var placeholder = new TypeDeclarationOptions("Placeholder", "Placeholder", "public", false, true);
            foreach (var restClient in RestClients)
            {
                var methods = ClientBuilder.BuildPagingMethods(restClient.InputClient, restClient, placeholder);
                foreach (var method in methods)
                {
                    pagingMethods.Add(method.Method, method);
                }
            }

            return pagingMethods;
        }

        private Dictionary<InputOperation, RestClientMethod> EnsureRestClientMethods()
        {
            var restClientMethods = new Dictionary<InputOperation, RestClientMethod>(new ObjectReferenceEqualityComparer<InputOperation>());
            foreach (var restClient in RestClients)
            {
                foreach (var (operation, restClientMethod) in restClient.Methods)
                {
                    if (restClientMethod.Accessibility != MethodSignatureModifiers.Public)
                        continue;
                    if (!restClientMethods.TryAdd(operation, restClientMethod))
                    {
                        throw new Exception($"An rest method '{operation.OperationId}' has already been added");
                    }
                }
            }

            return restClientMethods;
        }

        private ModelFactoryTypeProvider? _modelFactory;
        public ModelFactoryTypeProvider? ModelFactory => _modelFactory ??= ModelFactoryTypeProvider.TryCreate(AllSchemaMap.Value.Values.Where(ShouldIncludeModel), MgmtContext.TypeFactory, MgmtContext.Context.SourceInputModel);

        private bool ShouldIncludeModel(TypeProvider model)
        {
            if (model is MgmtReferenceType)
                return false;

            return model.Type.Namespace.StartsWith(MgmtContext.Context.DefaultNamespace);
        }

        private MgmtExtensionBuilder? _extensionBuilder;
        internal MgmtExtensionBuilder ExtensionBuilder => _extensionBuilder ??= EnsureExtensionBuilder();

        private MgmtExtensionBuilder EnsureExtensionBuilder()
        {
            var extensionOperations = new Dictionary<Type, IEnumerable<InputOperation>>();
            // find the extension operations for the armcore types other than ArmResource
            foreach (var (armCoreType, extensionContextualPath) in RequestPath.ExtensionChoices)
            {
                var operations = ShouldGenerateChildrenForType(armCoreType) ? GetChildOperations(extensionContextualPath) : Enumerable.Empty<InputOperation>();
                extensionOperations.Add(armCoreType, operations);
            }

            // find the extension operations for ArmResource
            var armResourceOperations = new Dictionary<RequestPath, IEnumerable<InputOperation>>();
            foreach (var (parentRequestPath, operations) in ChildOperations.Value)
            {
                if (parentRequestPath.IsParameterizedScope())
                {
                    armResourceOperations.Add(parentRequestPath, operations);
                }
            }

            return new MgmtExtensionBuilder(extensionOperations, armResourceOperations);
        }

        private bool ShouldGenerateChildrenForType(Type armCoreType)
            => !Configuration.MgmtConfiguration.IsArmCore || armCoreType.Namespace != MgmtContext.Context.DefaultNamespace;

        public IEnumerable<MgmtExtension> Extensions => ExtensionBuilder.Extensions;
        public IEnumerable<MgmtMockableExtension> MockableExtensions => ExtensionBuilder.MockableExtensions;
        public MgmtExtensionWrapper ExtensionWrapper => ExtensionBuilder.ExtensionWrapper;

        public MgmtExtension GetExtension(Type armCoreType) => ExtensionBuilder.GetExtension(armCoreType);

        private IEnumerable<ResourceData>? _resourceDatas;
        public IEnumerable<ResourceData> ResourceData => _resourceDatas ??= RawRequestPathToResourceData.Value.Values.Distinct();

        private IEnumerable<MgmtRestClient>? _restClients;
        public IEnumerable<MgmtRestClient> RestClients => _restClients ??= RawRequestPathToRestClient.Value.Values.SelectMany(v => v).Distinct();

        private IEnumerable<Resource>? _armResources;
        public IEnumerable<Resource> ArmResources => _armResources ??= RequestPathToResources.Value.Values.Select(bag => bag.Resource).Distinct();

        private IEnumerable<ResourceCollection>? _resourceCollections;
        public IEnumerable<ResourceCollection> ResourceCollections => _resourceCollections ??= RequestPathToResources.Value.Values.Select(bag => bag.ResourceCollection).WhereNotNull().Distinct();

        private Dictionary<InputType, TypeProvider> EnsureResourceSchemaMap()
        {
            return AllSchemaMap.Value.Where(kv => kv.Value is ResourceData).ToDictionary(kv => kv.Key, kv => kv.Value);
        }

        private Dictionary<InputType, TypeProvider> EnsureSchemaMap()
        {
            return AllSchemaMap.Value.Where(kv => !(kv.Value is ResourceData)).ToDictionary(kv => kv.Key, kv => kv.Value);
        }

        public Dictionary<InputEnumType, EnumType> EnsureAllEnumMap()
            => _input.Enums.ToDictionary(e => e, e => new EnumType(e, MgmtContext.TypeFactory, MgmtContext.Context), InputEnumType.IgnoreNullabilityComparer);

        private IEnumerable<TypeProvider>? _models;
        public IEnumerable<TypeProvider> Models => _models ??= SchemaMap.Value.Values.Where(m => m is not SystemObjectType);

        public ResourceData GetResourceData(string requestPath)
        {
            if (TryGetResourceData(requestPath, out var resourceData))
                return resourceData;

            throw new InvalidOperationException($"Request path {requestPath} does not correspond to a ResourceData");
        }

        public bool TryGetResourceData(string requestPath, [MaybeNullWhen(false)] out ResourceData resourceData)
        {
            return RawRequestPathToResourceData.Value.TryGetValue(requestPath, out resourceData);
        }

        public bool TryGetArmResource(RequestPath requestPath, [MaybeNullWhen(false)] out Resource resource)
        {
            resource = null;
            if (RequestPathToResources.Value.TryGetValue(requestPath, out var bag))
            {
                resource = bag.Resource;
                return true;
            }

            return false;
        }

        public MgmtRestClient GetRestClient(InputOperation operation)
        {
            var requestPath = operation.GetHttpPath();
            if (TryGetRestClients(requestPath, out var restClients))
            {
                // return the first client that contains this operation
                return restClients.Single(client => client.InputClient.Operations.Contains(operation));
            }

            throw new InvalidOperationException($"Cannot find MgmtRestClient corresponding to {requestPath} with method {operation.HttpMethod}");
        }

        public bool TryGetRestClients(string requestPath, [MaybeNullWhen(false)] out HashSet<MgmtRestClient> restClients)
        {
            return RawRequestPathToRestClient.Value.TryGetValue(requestPath, out restClients);
        }

        private Dictionary<string, HashSet<MgmtRestClient>> EnsureRestClients()
        {
            var rawRequestPathToRestClient = new Dictionary<string, HashSet<MgmtRestClient>>();
            foreach (var inputClient in _input.Clients)
            {
                var restClient = new MgmtRestClient(inputClient, new MgmtRestClientBuilder(inputClient));
                foreach (var requestPath in _operationGroupToRequestPaths[inputClient])
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
                foreach (var operationSet in operationSets)
                {
                    // get the corresponding resource data
                    var originalResourcePath = operationSet.GetRequestPath();
                    var operations = GetChildOperations(originalResourcePath);
                    var resourceData = GetResourceData(originalResourcePath);
                    if (resourceData is EmptyResourceData emptyResourceData)
                        BuildPartialResource(requestPathToResources, resourceDataSchemaName, operationSet, operations, originalResourcePath, emptyResourceData);
                    else
                        BuildResource(requestPathToResources, resourceDataSchemaName, operationSet, operations, originalResourcePath, resourceData);
                }
            }

            return requestPathToResources;
        }

        private void BuildResource(Dictionary<RequestPath, ResourceObjectAssociation> result, string resourceDataSchemaName, OperationSet operationSet, IEnumerable<InputOperation> operations, RequestPath originalResourcePath, ResourceData resourceData)
        {
            var isSingleton = operationSet.IsSingletonResource();
            // we calculate the resource type of the resource
            var resourcePaths = originalResourcePath.Expand();
            foreach (var resourcePath in resourcePaths)
            {
                var resourceType = resourcePath.GetResourceType();
                var resource = new Resource(operationSet, operations, GetResourceName(resourceDataSchemaName, operationSet, resourcePath), resourceType, resourceData);
                var collection = isSingleton ? null : new ResourceCollection(operationSet, operations, resource);
                resource.ResourceCollection = collection;

                result.Add(resourcePath, new ResourceObjectAssociation(resourceType, resourceData, resource, collection));
            }
        }

        private void BuildPartialResource(Dictionary<RequestPath, ResourceObjectAssociation> result, string resourceDataSchemaName, OperationSet operationSet, IEnumerable<InputOperation> operations, RequestPath originalResourcePath, EmptyResourceData emptyResourceData)
        {
            var resourceType = originalResourcePath.GetResourceType();
            var resource = new PartialResource(operationSet, operations, GetResourceName(resourceDataSchemaName, operationSet, originalResourcePath, isPartial: true), resourceDataSchemaName, resourceType, emptyResourceData);
            result.Add(originalResourcePath, new ResourceObjectAssociation(originalResourcePath.GetResourceType(), emptyResourceData, resource, null));
        }

        private string? GetDefaultNameFromConfiguration(OperationSet operationSet, ResourceTypeSegment resourceType)
        {
            if (Configuration.MgmtConfiguration.RequestPathToResourceName.TryGetValue(operationSet.RequestPath, out var name))
                return name;
            if (Configuration.MgmtConfiguration.RequestPathToResourceName.TryGetValue($"{operationSet.RequestPath}|{resourceType}", out name))
                return name;

            return null;
        }

        private string GetResourceName(string candidateName, OperationSet operationSet, RequestPath requestPath, bool isPartial = false)
        {
            // read configuration to see if we could get a configuration for this resource
            var resourceType = requestPath.GetResourceType();
            var defaultNameFromConfig = GetDefaultNameFromConfiguration(operationSet, resourceType);
            if (defaultNameFromConfig != null)
                return defaultNameFromConfig;

            var resourceName = CalculateResourceName(candidateName, operationSet, requestPath, resourceType);

            return isPartial ?
                $"{resourceName}{MgmtContext.RPName}" :
                resourceName;
        }

        private string CalculateResourceName(string candidateName, OperationSet operationSet, RequestPath requestPath, ResourceTypeSegment resourceType)
        {
            // find all the expanded request paths of resources that are assiociated with the same resource data model
            var resourcesWithSameResourceData = ResourceDataSchemaNameToOperationSets[candidateName]
                .SelectMany(opSet => opSet.GetRequestPath().Expand()).ToList();
            // find all the expanded resource types of resources that have the same resource type as this one
            var resourcesWithSameResourceType = ResourceOperationSets
                .SelectMany(opSet => opSet.GetRequestPath().Expand())
                .Where(rqPath => rqPath.GetResourceType().Equals(resourceType)).ToList();

            var isById = requestPath.IsById;
            int countOfSameResourceDataName = resourcesWithSameResourceData.Count;
            int countOfSameResourceTypeName = resourcesWithSameResourceType.Count;
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
                if (!DoMultipleResourcesShareMyPrefixes(requestPath, parentPrefix, resourcesWithSameResourceType))
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
                pathToWalk = pathToWalk.ParentRequestPath();
                if (RawRequestPathToResourceData.Value.TryGetValue(pathToWalk.ToString()!, out var parentData))
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

        public IEnumerable<InputOperation> GetChildOperations(RequestPath requestPath)
        {
            if (requestPath == RequestPath.Any)
                return Enumerable.Empty<InputOperation>();

            if (ChildOperations.Value.TryGetValue(requestPath, out var operations))
                return operations;

            return Enumerable.Empty<InputOperation>();
        }

        private Dictionary<RequestPath, HashSet<InputOperation>> EnsureResourceChildOperations()
        {
            var childOperations = new Dictionary<RequestPath, HashSet<InputOperation>>();
            foreach (var operationSet in RawRequestPathToOperationSets.Values)
            {
                if (operationSet.IsResource())
                    continue;
                foreach (var operation in operationSet)
                {
                    var parentRequestPath = operation.ParentRequestPath(_input);
                    if (childOperations.TryGetValue(parentRequestPath, out var list))
                        list.Add(operation);
                    else
                        childOperations.Add(parentRequestPath, new HashSet<InputOperation> { operation });
                }
            }

            return childOperations;
        }

        private Dictionary<string, ResourceData> EnsureRequestPathToResourceData()
        {
            var rawRequestPathToResourceData = new Dictionary<string, ResourceData>();
            foreach ((var schema, var provider) in ResourceSchemaMap.Value)
            {
                if (ResourceDataSchemaNameToOperationSets.TryGetValue(schema.Name, out var operationSets))
                {
                    // we are iterating over the ResourceSchemaMap, the value can only be [ResourceData]s
                    var resourceData = (ResourceData)provider;
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

        public override CSharpType ResolveEnum(InputEnumType enumType) => AllEnumMap.Value[enumType].Type;

        public override CSharpType ResolveModel(InputModelType model)
        {
            if (_schemaOrNameToModels.TryGetValue(model, out var value))
            {
                return value.Type;
            }

            // TODO: model has been turned in to a new instance somewhere, need to fix it later
            return FindTypeByName(model.OriginalName ?? model.Name) ?? throw new InvalidOperationException($"Cannot find model {model.Name}");
        }

        public override CSharpType? FindTypeByName(string originalName)
        {
            _schemaOrNameToModels.TryGetValue(originalName, out TypeProvider? provider);

            // Try to search declaration name too if no key matches. i.e. Resource Data Type will be appended a 'Data' in the name and won't be found through key
            provider ??= _schemaOrNameToModels.FirstOrDefault(s => s.Value is MgmtObjectType mot && mot.Declaration.Name == originalName).Value;

            return provider?.Type;
        }

        public bool TryGetTypeProvider(string originalName, [MaybeNullWhen(false)] out TypeProvider provider)
        {
            if (_schemaOrNameToModels.TryGetValue(originalName, out provider))
                return true;

            provider = ResourceSchemaMap.Value.Values.FirstOrDefault(m => m.Type.Name == originalName);
            return provider != null;
        }

        public IEnumerable<Resource> FindResources(ResourceData resourceData)
        {
            return ArmResources.Where(resource => resource.ResourceData == resourceData);
        }

        private TypeProvider BuildModel(InputType inputType, MgmtObjectType? defaultDerivedType = null) => inputType switch
        {
            InputEnumType enumType => new EnumType(enumType, MgmtContext.TypeFactory, MgmtContext.Context),
            // TODO: handle this when regen resource manager
            // inputType.Extensions != null && (inputType.Extensions.MgmtReferenceType || inputType.Extensions.MgmtPropertyReferenceType || inputType.Extensions.MgmtTypeReferenceType) ? new MgmtReferenceType(inputModel, TypeFactory)
            InputModelType inputModel => new MgmtObjectType(inputModel, defaultDerivedType: defaultDerivedType),
            _ => throw new NotImplementedException($"Unhandled input type {inputType.GetType()} with name {inputType.Name}")
        };

        private TypeProvider BuildResourceData(InputType inputType, MgmtObjectType? defaultDerivedType)
        {
            if (inputType is InputModelType inputModel)
            {
                if (inputModel.IsEmpty)
                {
                    return new EmptyResourceData(inputModel);
                }
                return new ResourceData(inputModel, defaultDerivedType: defaultDerivedType);
            }
            throw new NotImplementedException();
        }

        private Dictionary<string, HashSet<OperationSet>> DecorateOperationSets()
        {
            Dictionary<string, HashSet<OperationSet>> resourceDataSchemaNameToOperationSets = new Dictionary<string, HashSet<OperationSet>>();
            foreach (var operationSet in RawRequestPathToOperationSets.Values)
            {
                if (operationSet.TryGetResourceDataSchema(out var resourceDataSchema))
                {
                    // ensure the name of resource data is singular
                    var schemaName = resourceDataSchema.Name;
                    // skip this step if the configuration is set to keep this plural
                    if (!Configuration.MgmtConfiguration.KeepPluralResourceData.Contains(schemaName))
                    {
                        //resourceDataSchema.OriginalName ??= schemaName;
                        schemaName = schemaName.LastWordToSingular(false);
                        resourceDataSchema.Name = schemaName;
                    }
                    else
                    {
                        MgmtReport.Instance.TransformSection.AddTransformLog(
                            new TransformItem(TransformTypeName.KeepPluralResourceData, schemaName),
                            resourceDataSchema.GetFullSerializedName(), $"Keep ObjectName as Plural: {schemaName}");
                    }
                    // if this operation set corresponds to a SDK resource, we add it to the map
                    if (!resourceDataSchemaNameToOperationSets.TryGetValue(schemaName, out HashSet<OperationSet>? result))
                    {
                        result = new HashSet<OperationSet>();
                        resourceDataSchemaNameToOperationSets.Add(schemaName, result);
                    }
                    result.Add(operationSet);
                }
            }

            return resourceDataSchemaNameToOperationSets;
        }

        private Dictionary<string, OperationSet> CategorizeOperationGroups()
        {
            var rawRequestPathToOperationSets = new Dictionary<string, OperationSet>();
            foreach (var inputClient in _input.Clients)
            {
                var requestPathList = new HashSet<string>();
                _operationGroupToRequestPaths.Add(inputClient, requestPathList);
                foreach (var operation in inputClient.Operations)
                {
                    var path = operation.GetHttpPath();
                    requestPathList.Add(path);
                    if (rawRequestPathToOperationSets.TryGetValue(path, out var operationSet))
                    {
                        operationSet.Add(operation);
                    }
                    else
                    {
                        operationSet = new OperationSet(path, inputClient)
                        {
                            operation
                        };
                        rawRequestPathToOperationSets.Add(path, operationSet);
                    }
                }
            }

            // add operation set for the partial resources here
            foreach (var path in Configuration.MgmtConfiguration.PartialResources.Keys)
            {
                rawRequestPathToOperationSets.Add(path, new OperationSet(path, null));
            }

            return rawRequestPathToOperationSets;
        }

        private Dictionary<InputOperation, RequestPath> PopulateOperationsToRequestPaths()
        {
            var operationsToRequestPath = new Dictionary<InputOperation, RequestPath>(ReferenceEqualityComparer.Instance);
            foreach (var operationGroup in _input.Clients)
            {
                foreach (var operation in operationGroup.Operations)
                {
                    operationsToRequestPath[operation] = RequestPath.FromOperation(operation, operationGroup, MgmtContext.TypeFactory);
                }
            }
            return operationsToRequestPath;
        }

        private class ObjectReferenceEqualityComparer<T> : EqualityComparer<T> where T : class
        {
            public override bool Equals(T? x, T? y) => ReferenceEquals(x, y);

            public override int GetHashCode([DisallowNull] T obj) => RuntimeHelpers.GetHashCode(obj);
        }
    }
}
