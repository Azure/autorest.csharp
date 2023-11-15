// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Utilities;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Mgmt.Report;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure.Core;

namespace AutoRest.CSharp.Mgmt.AutoRest
{
    internal class MgmtOutputLibrary : OutputLibrary
    {
        private readonly SourceInputModel? _sourceInputModel;

        /// <summary>
        /// This is a map from resource name to a list of <see cref="OperationSet"/>
        /// considering of the extension resources, one resource name might correspond to multiple operation sets
        /// This must be initialized before other maps
        /// </summary>
        private Dictionary<string, HashSet<OperationSet>> ResourceDataTypeNameToOperationSets { get; }

        /// <summary>
        /// This is a map from raw request path to their corresponding <see cref="OperationSet"/>,
        /// which is a collection of the operations with the same raw request path
        /// </summary>
        internal Dictionary<string, OperationSet> RawRequestPathToOperationSets { get; }

        /// <summary>
        /// This is a map from operation to its request path
        /// </summary>
        private CachedDictionary<InputOperation, RequestPath> OperationsToRequestPaths { get; }

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
        /// This is a map from request path to the <see cref="ResourceObjectAssociation"/> which consists from <see cref="ResourceTypeSegment"/>, <see cref="Output.ResourceData"/>, <see cref="Resource"/> and <see cref="ResourceCollection"/>
        /// </summary>
        private CachedDictionary<RequestPath, ResourceObjectAssociation> RequestPathToResources { get; }

        private CachedDictionary<InputOperation, RestClientOperationMethods> OperationMethods { get; }

        private Dictionary<InputType, TypeProvider> AllInputTypeMap { get; }

        public CachedDictionary<InputType, TypeProvider> ResourceTypeMap { get; }

        internal CachedDictionary<InputType, TypeProvider> InputTypeMap { get; }

        private CachedDictionary<InputEnumType, EnumType> AllEnumMap { get; }

        private CachedDictionary<RequestPath, HashSet<InputOperation>> ChildOperations { get; }

        private readonly InputNamespace _input;

        private readonly LookupDictionary<InputType, string, TypeProvider> _schemaOrNameToModels = new(inputType => inputType.Name);

        /// <summary>
        /// This is a map from <see cref="OperationGroup"/> to the list of raw request path of its operations
        /// </summary>
        private readonly Dictionary<InputClient, IEnumerable<string>> _operationGroupToRequestPaths = new();

        private readonly Dictionary<object, string> _renamingMap = new();

        /// <summary>
        /// This is a collection that contains all the models from property bag, we use HashSet here to avoid potential duplicates
        /// </summary>
        public HashSet<TypeProvider> PropertyBagModels { get; }

        public TypeFactory TypeFactory { get; }

        public MgmtOutputLibrary(InputNamespace inputNamespace, SourceInputModel? sourceInputModel)
        {
            TypeFactory = new TypeFactory(this);
            _input = inputNamespace;
            _sourceInputModel = sourceInputModel;

            // these dictionaries are initialized right now and they would not change later
            RawRequestPathToOperationSets = CategorizeOperationGroups();
            ResourceDataTypeNameToOperationSets = DecorateOperationSets();
            //_schemaToInputEnumMap = new CodeModelConverter(codeModel, schemaUsages).CreateEnums();

            AllInputTypeMap = InitializeModels();

            // others are populated later
            OperationsToRequestPaths = new CachedDictionary<InputOperation, RequestPath>(() => PopulateOperationsToRequestPaths());
            RawRequestPathToRestClient = new CachedDictionary<string, HashSet<MgmtRestClient>>(EnsureRestClients);
            RawRequestPathToResourceData = new CachedDictionary<string, ResourceData>(EnsureRequestPathToResourceData);
            RequestPathToResources = new CachedDictionary<RequestPath, ResourceObjectAssociation>(EnsureRequestPathToResourcesMap);
            OperationMethods = new CachedDictionary<InputOperation, RestClientOperationMethods>(EnsureRestClientMethods);
            ResourceTypeMap = new CachedDictionary<InputType, TypeProvider>(EnsureResourceSchemaMap);
            InputTypeMap = new CachedDictionary<InputType, TypeProvider>(EnsureSchemaMap);
            AllEnumMap = new CachedDictionary<InputEnumType, EnumType>(EnsureAllEnumMap);
            ChildOperations = new CachedDictionary<RequestPath, HashSet<InputOperation>>(EnsureResourceChildOperations);

            // initialize the property bag collection
            // TODO -- considering provide a customized comparer
            PropertyBagModels = new HashSet<TypeProvider>();

            //this is where we construct renaming map
            UpdateBodyParameters();
        }

        public bool IsArmCore => Configuration.MgmtConfiguration.IsArmCore;

        public Dictionary<CSharpType, OperationSource> CSharpTypeToOperationSource { get; } = new Dictionary<CSharpType, OperationSource>();
        public IEnumerable<OperationSource> OperationSources => CSharpTypeToOperationSource.Values;

        public ICollection<LongRunningInterimOperation> InterimOperations { get; } = new List<LongRunningInterimOperation>();

        private void UpdateBodyParameters()
        {
            Dictionary<InputType, int> usageCounts = new Dictionary<InputType, int>();

            // TODO: fill in modelsToUpdate and parametersToUpdate
            // TODO: update the input types with modelsToUpdate, update the input operations with parametersToUpdate afterwards
            //Dictionary<object, string> renamingMap = new Dictionary<object, string>();

            // run one pass to get the schema usage count
            foreach (var operationGroup in _input.Clients)
            {
                foreach (var operation in operationGroup.Operations)
                {
                    foreach (var request in operation.Parameters)
                    {
                        IncrementCount(usageCounts, request.Type);
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
            foreach (var operationGroup in _input.Clients)
            {
                foreach (var operation in operationGroup.Operations)
                {
                    if (operation.HttpMethod!= RequestMethod.Patch && operation.HttpMethod != RequestMethod.Put && operation.HttpMethod != RequestMethod.Post)
                        continue;

                    var bodyParam = operation.Parameters.FirstOrDefault(p => p.Location == RequestLocation.Body);
                    if (bodyParam is null)
                        continue;

                    if (!usageCounts.TryGetValue(bodyParam.Type, out var count))
                        continue;

                    // get the request path and operation set
                    RequestPath requestPath = RequestPath.FromOperation(operation, operationGroup, TypeFactory);
                    var operationSet = RawRequestPathToOperationSets[requestPath];
                    if (operationSet.TryGetResourceDataSchema(out var resourceDataSchema, _input))
                    {
                        // TODO: change parameter to required, put this logic outside of output library to the code model tranformer or afterwards
                        // if this is a resource, we need to make sure its body parameter is required when the verb is put or patch
                        BodyParameterNormalizer.MakeRequired(bodyParam, operation.HttpMethod);
                    }

                    if (count != 1)
                    {
                        //even if it has multiple uses for a model type we should normalize the param name just not change the type
                        BodyParameterNormalizer.UpdateParameterNameOnly(bodyParam, ResourceDataTypeNameToOperationSets, operation, _renamingMap);
                        continue;
                    }
                    if (resourceDataSchema is not null)
                    {
                        //TODO handle expandable request paths. We assume that this is fine since if all of the expanded
                        //types use the same model they should have a common name, but since this case doesn't exist yet
                        //we don't know for sure
                        if (requestPath.IsExpandable)
                            throw new InvalidOperationException($"Found expandable path in UpdatePatchParameterNames for {operationGroup.Key}.{operation.CleanName} : {requestPath}");
                        var name = GetResourceName(resourceDataSchema.Name, operationSet, requestPath);
                        BodyParameterNormalizer.Update(operation.HttpMethod, bodyParam, name, operation, _renamingMap);
                    }
                    else
                    {
                        BodyParameterNormalizer.UpdateUsingReplacement(bodyParam, ResourceDataTypeNameToOperationSets, operation, _renamingMap);
                    }
                }
            }

            // run third pass to rename the corresponding parameters
            foreach (var operationGroup in _input.Clients)
            {
                foreach (var operation in operationGroup.Operations)
                {
                    foreach (var param in operation.Parameters)
                    {
                        if (param.Location != RequestLocation.Body)
                            continue;

                        if (param.Type is not InputModelType inputModel)
                            continue;

                        string oriName = param.Name;
                        var newParamName = NormalizeParamNames.GetNewName(param.Name, inputModel.Name, ResourceDataTypeNameToOperationSets);
                        _renamingMap.Add(param, newParamName);

                        string fullSerializedName = operation.GetFullSerializedName(param);
                        MgmtReport.Instance.TransformSection.AddTransformLogForApplyChange(
                            new TransformItem(TransformTypeName.UpdateBodyParameter, fullSerializedName),
                            fullSerializedName, "SetBodyParameterNameOnThirdPass", oriName, newParamName);
                    }
                }
            }
        }

        private static void IncrementCount(Dictionary<InputType, int> usageCounts, InputType inputType)
        {
            if (usageCounts.ContainsKey(inputType))
            {
                usageCounts[inputType]++;
            }
            else
            {
                usageCounts.Add(inputType, 1);
            }
        }

        // Initialize ResourceData, Models and resource manager common types
        private Dictionary<InputType, TypeProvider> InitializeModels()
        {

            // first, construct resource data models
            foreach (var inputModel in _input.Models)
            {
                var model = ResourceDataTypeNameToOperationSets.ContainsKey(inputModel.Name) ? BuildResourceData(inputModel) : BuildModel(inputModel);
                _schemaOrNameToModels.Add(inputModel, model);
            }

            // second, collect any model which can be replaced as whole (not as a property or as a base class)
            var replacedTypes = new List<MgmtObjectType>();
            foreach (var inputType in _input.Models)
            {
                if (_schemaOrNameToModels.TryGetValue(inputType, out TypeProvider? type))
                {
                    if (type is MgmtObjectType mgmtObjectType)
                    {
                        var csharpType = TypeReferenceTypeChooser.GetExactMatch(mgmtObjectType, _sourceInputModel);
                        if (csharpType != null)
                        {
                            // re-construct the model with replaced csharp type (e.g. the type in Resource Manager)
                            switch (mgmtObjectType)
                            {
                                case ResourceData resourceData:
                                    replacedTypes.Add(new ResourceData(this, inputType, TypeFactory, _sourceInputModel, csharpType.Name, csharpType.Namespace));
                                    break;
                                case MgmtReferenceType referenceType:
                                    replacedTypes.Add(new MgmtReferenceType(this, inputType, TypeFactory, _sourceInputModel, csharpType.Name, csharpType.Namespace));
                                    break;
                                default:
                                    replacedTypes.Add(new MgmtObjectType(this, inputType, TypeFactory, _sourceInputModel, csharpType.Name, csharpType.Namespace));
                                    break;
                            }
                        }
                    }
                }
            }

            // third, update the entries in cache maps with the new model instances
            foreach (var replacedType in replacedTypes)
            {
                var oriModel = _schemaOrNameToModels[replacedType.InputModel];
                _schemaOrNameToModels[replacedType.InputModel] = replacedType;
                MgmtReport.Instance.TransformSection.AddTransformLogForApplyChange(
                    new TransformItem(TransformTypeName.ReplaceTypeWhenInitializingModel, replacedType.InputModel.Name),
                    replacedType.InputModel.Name,
                    "ReplaceType", oriModel.Declaration.FullName, replacedType.Declaration.FullName);
            }

            return _schemaOrNameToModels;
        }

        private IEnumerable<OperationSet>? _resourceOperationSets;
        public IEnumerable<OperationSet> ResourceOperationSets => _resourceOperationSets ??= ResourceDataTypeNameToOperationSets.SelectMany(pair => pair.Value);

        public OperationSet GetOperationSet(string requestPath) => RawRequestPathToOperationSets[requestPath];

        public RestClientOperationMethods GetOperationMethods(InputOperation operation)
        {
            if (OperationMethods.TryGetValue(operation, out var legacyMethods))
            {
                return legacyMethods;
            }
            throw new Exception($"The {operation.Name} methods do not exist.");
        }

        public MethodSignature GetRestClientPublicMethodSignature(InputOperation operation)
            => (MethodSignature)GetOperationMethods(operation).Convenience!.Signature;

        public RequestPath GetRequestPath(InputOperation operation) => OperationsToRequestPaths[operation];

        private Dictionary<InputOperation, RestClientOperationMethods> EnsureRestClientMethods()
        {
            var operationMethods = new Dictionary<InputOperation, RestClientOperationMethods>();
            foreach (var restClient in RestClients)
            {
                foreach (var restClientMethods in restClient.Methods)
                {
                    if (!restClientMethods.Convenience!.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public))
                    {
                        continue;
                    }

                    var operation = restClientMethods.Operation;
                    if (!operationMethods.TryAdd(operation, restClientMethods))
                    {
                        throw new Exception($"An rest method '{operation.Name}' has already been added");
                    }
                }
            }

            return operationMethods;
        }

        private ModelFactoryTypeProvider? _modelFactory;
        public ModelFactoryTypeProvider? ModelFactory => _modelFactory ??= ModelFactoryTypeProvider.TryCreate(AllInputTypeMap.Values.Where(ShouldIncludeModel), _sourceInputModel);

        private bool ShouldIncludeModel(TypeProvider model)
        {
            if (model is MgmtReferenceType)
                return false;

            return model.Type.Namespace.StartsWith(Configuration.Namespace);
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
            foreach (var (parentRequestPath, operations) in ChildOperations)
            {
                if (parentRequestPath.IsParameterizedScope())
                {
                    armResourceOperations.Add(parentRequestPath, operations);
                }
            }

            return new MgmtExtensionBuilder(extensionOperations, armResourceOperations, this, _sourceInputModel);
        }

        private bool ShouldGenerateChildrenForType(Type armCoreType)
            => !Configuration.MgmtConfiguration.IsArmCore || armCoreType.Namespace != Configuration.Namespace;

        public IEnumerable<MgmtExtension> Extensions => ExtensionBuilder.Extensions;
        public IEnumerable<MgmtMockableExtension> MockableExtensions => ExtensionBuilder.MockableExtensions;
        public MgmtExtensionWrapper ExtensionWrapper => ExtensionBuilder.ExtensionWrapper;

        public MgmtExtension GetExtension(Type armCoreType) => ExtensionBuilder.GetExtension(armCoreType);

        private IEnumerable<ResourceData>? _resourceDatas;
        public IEnumerable<ResourceData> ResourceData => _resourceDatas ??= RawRequestPathToResourceData.Values.Distinct();

        private IEnumerable<MgmtRestClient>? _restClients;
        public IEnumerable<MgmtRestClient> RestClients => _restClients ??= RawRequestPathToRestClient.Values.SelectMany(v => v).Distinct();

        private IEnumerable<Resource>? _armResources;
        public IEnumerable<Resource> ArmResources => _armResources ??= RequestPathToResources.Values.Select(bag => bag.Resource).Distinct();

        private IEnumerable<ResourceCollection>? _resourceCollections;
        public IEnumerable<ResourceCollection> ResourceCollections => _resourceCollections ??= RequestPathToResources.Values.Select(bag => bag.ResourceCollection).WhereNotNull().Distinct();

        private Dictionary<InputType, TypeProvider> EnsureResourceSchemaMap()
        {
            return AllInputTypeMap.Where(kv => kv.Value is ResourceData).ToDictionary(kv => kv.Key, kv => kv.Value);
        }

        private Dictionary<InputType, TypeProvider> EnsureSchemaMap()
        {
            return AllInputTypeMap.Where(kv => !(kv.Value is ResourceData)).ToDictionary(kv => kv.Key, kv => kv.Value);
        }

        private Dictionary<InputEnumType, EnumType> EnsureAllEnumMap()
        {
            var dictionary = new Dictionary<InputEnumType, EnumType>(InputEnumType.IgnoreNullabilityComparer);
            foreach (var (inputType, typeProvider) in AllInputTypeMap)
            {
                if (inputType is InputEnumType enumType)
                {
                    dictionary.Add(enumType, (EnumType)typeProvider);
                }
            }

            return dictionary;
        }

        public IEnumerable<TypeProvider> Models => GetModels();

        private IEnumerable<TypeProvider> GetModels()
        {
            var models = InputTypeMap.Values;

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

        public MgmtRestClient GetRestClient(InputOperation operation)
        {
            var requestPath = operation.Path;
            if (TryGetRestClients(requestPath, out var restClients))
            {
                // return the first client that contains this operation
                return restClients.Single(client => client.Methods.Select(m => m.Operation).Contains(operation));
            }

            throw new InvalidOperationException($"Cannot find MgmtRestClient corresponding to {requestPath} with method {operation.HttpMethod}");
        }

        public bool TryGetRestClients(string requestPath, [MaybeNullWhen(false)] out HashSet<MgmtRestClient> restClients)
        {
            return RawRequestPathToRestClient.TryGetValue(requestPath, out restClients);
        }

        private Dictionary<string, HashSet<MgmtRestClient>> EnsureRestClients()
        {
            var rawRequestPathToRestClient = new Dictionary<string, HashSet<MgmtRestClient>>();

            foreach (InputClient inputClient in _input.Clients)
            {
                var ctorParameters = inputClient.Operations
                    .SelectMany(op => op.Parameters)
                    .Where(p => p.Kind == InputOperationParameterKind.Client)
                    .GroupBy(p => p.Name)
                    .Select(g => RestClientBuilder.BuildConstructorParameter(g.First(), TypeFactory))
                    .Select(p => p.IsApiVersionParameter ? p with { DefaultValue = Constant.Default(p.Type.WithNullable(true)), Initializer = p.DefaultValue is {} defaultValue ? new ConstantExpression(defaultValue) : null } : p)
                    .OrderBy(p => p.IsOptionalInSignature)
                    .ToList();

                var clientParameters = new[] { KnownParameters.Pipeline }.Union(ctorParameters).ToList();
                var restClientParameters = new[] { KnownParameters.Pipeline, KnownParameters.ApplicationId }.Union(ctorParameters).ToList();
                var operations = inputClient.Operations;
                var clientName = string.IsNullOrEmpty(inputClient.Name) ? _input.Name : inputClient.Name;
                var restClient = new MgmtRestClient(inputClient, clientParameters, restClientParameters, operations, clientName, this, _sourceInputModel);

                foreach (var operation in inputClient.Operations)
                {
                    // Do not trim the tenant resource path '/'.
                    var requestPath = operation.Path.Length == 1
                        ? operation.Path
                        : operation.Path.TrimEnd('/');

                    if (rawRequestPathToRestClient.TryGetValue(requestPath, out var set))
                    {
                        set.Add(restClient);
                    }
                    else
                    {
                        rawRequestPathToRestClient.Add(requestPath, new HashSet<MgmtRestClient> { restClient });
                    }
                }
            }

            return rawRequestPathToRestClient;
        }

        private Dictionary<RequestPath, ResourceObjectAssociation> EnsureRequestPathToResourcesMap()
        {
            var requestPathToResources = new Dictionary<RequestPath, ResourceObjectAssociation>();

            foreach ((var resourceDataSchemaName, var operationSets) in ResourceDataTypeNameToOperationSets)
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
            var isSingleton = operationSet.IsSingletonResource(this);
            // we calculate the resource type of the resource
            var resourcePaths = originalResourcePath.Expand();
            foreach (var resourcePath in resourcePaths)
            {
                var resourceType = resourcePath.GetResourceType();
                var resource = new Resource(operationSet, operations, GetResourceName(resourceDataSchemaName, operationSet, resourcePath), resourceType, resourceData, this, _sourceInputModel);
                var collection = isSingleton ? null : new ResourceCollection(operationSet, operations, resource, this, _sourceInputModel);
                resource.ResourceCollection = collection;

                result.Add(resourcePath, new ResourceObjectAssociation(resourceType, resourceData, resource, collection));
            }
        }

        private void BuildPartialResource(Dictionary<RequestPath, ResourceObjectAssociation> result, string resourceDataSchemaName, OperationSet operationSet, IEnumerable<InputOperation> operations, RequestPath originalResourcePath, EmptyResourceData emptyResourceData)
        {
            var resourceType = originalResourcePath.GetResourceType();
            var resource = new PartialResource(operationSet, operations, GetResourceName(resourceDataSchemaName, operationSet, originalResourcePath, isPartial: true), resourceDataSchemaName, resourceType, emptyResourceData, this, _sourceInputModel);
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

            var resourceName = CalculateResourceName(candidateName, requestPath, resourceType);

            return isPartial ?
                $"{resourceName}{ClientBuilder.GetRPName(Configuration.Namespace)}" :
                resourceName;
        }

        private string CalculateResourceName(string candidateName, RequestPath requestPath, ResourceTypeSegment resourceType)
        {
            // find all the expanded request paths of resources that are assiociated with the same resource data model
            var resourcesWithSameResourceData = ResourceDataTypeNameToOperationSets[candidateName]
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
                pathToWalk = pathToWalk.ParentRequestPath(this);
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

        public IEnumerable<InputOperation> GetChildOperations(RequestPath requestPath)
        {
            if (requestPath == RequestPath.Any)
                return Enumerable.Empty<InputOperation>();

            if (ChildOperations.TryGetValue(requestPath, out var operations))
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
                    var parentRequestPath = operation.ParentRequestPath(_input, this);
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
            foreach ((var schema, var provider) in ResourceTypeMap)
            {
                if (ResourceDataTypeNameToOperationSets.TryGetValue(schema.Name, out var operationSets))
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

        public override CSharpType ResolveEnum(InputEnumType enumType) => AllEnumMap[enumType].Type;
        public override CSharpType ResolveModel(InputModelType model) => _schemaOrNameToModels[model].Type;

        public override TypeProvider FindTypeProviderForInputType(InputType inputType)
        {
            TypeProvider? result;
            if (AllInputTypeMap is null)
            {
                result = ResourceDataTypeNameToOperationSets.ContainsKey(inputType.Name) ? BuildResourceData(inputType) : BuildModel(inputType);
            }
            else if (!InputTypeMap.TryGetValue(inputType, out result) && !ResourceTypeMap.TryGetValue(inputType, out result))
            {
                throw new KeyNotFoundException($"{inputType.Name} was not found in model and resource type map");
            }
            return result;
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

            provider = ResourceTypeMap.Values.FirstOrDefault(m => m.Type.Name == originalName);
            return provider != null;
        }

        public IEnumerable<Resource> FindResources(ResourceData resourceData)
        {
            return ArmResources.Where(resource => resource.ResourceData == resourceData);
        }

        private TypeProvider BuildModel(InputType inputType) => inputType switch
        {
            InputEnumType enumType => new EnumType(enumType, TypeFactory, _sourceInputModel, GetNewName(inputType)),
            // TODO: handle this when regen resource manager
            // inputType.Extensions != null && (inputType.Extensions.MgmtReferenceType || inputType.Extensions.MgmtPropertyReferenceType || inputType.Extensions.MgmtTypeReferenceType) ? new MgmtReferenceType(inputModel, TypeFactory)
            InputModelType inputModel => new MgmtObjectType(this, inputModel, TypeFactory, _sourceInputModel, newName: GetNewName(inputType)),
            _ => throw new NotImplementedException($"Unhandled input type {inputType.GetType()} with name {inputType.Name}")
        };

        private string? GetNewName(object o) => _renamingMap.TryGetValue(o, out var name) ? name : null;

        private TypeProvider BuildResourceData(InputType inputType)
        {
            if (inputType is InputModelType inputModel)
            {
                string? newName = GetNewName(inputType);
                if (inputModel.IsEmpty)
                {
                    return new EmptyResourceData(this, inputModel, TypeFactory, _sourceInputModel, newName);
                }
                return new ResourceData(this, inputModel, TypeFactory, _sourceInputModel, newName);
            }
            throw new NotImplementedException();
        }

        private Dictionary<string, HashSet<OperationSet>> DecorateOperationSets()
        {
            Dictionary<string, HashSet<OperationSet>> resourceDataSchemaNameToOperationSets = new Dictionary<string, HashSet<OperationSet>>();
            foreach (var operationSet in RawRequestPathToOperationSets.Values)
            {
                if (operationSet.TryGetResourceDataSchema(out var resourceDataType, _input))
                {
                    // ensure the name of resource data is singular
                    var typeName = resourceDataType.Name;
                    // skip this step if the configuration is set to keep this plural
                    if (!Configuration.MgmtConfiguration.KeepPluralResourceData.Contains(typeName))
                    {
                        _renamingMap.Add(resourceDataType, typeName.LastWordToSingular(false));
                    }
                    else
                    {
                        MgmtReport.Instance.TransformSection.AddTransformLog(
                            new TransformItem(TransformTypeName.KeepPluralResourceData, typeName),
                            resourceDataType.GetFullSerializedName(), $"Keep ObjectName as Plural: {typeName}");
                    }
                    // if this operation set corresponds to a SDK resource, we add it to the map
                    if (!resourceDataSchemaNameToOperationSets.TryGetValue(typeName, out HashSet<OperationSet>? result))
                    {
                        result = new HashSet<OperationSet>();
                        resourceDataSchemaNameToOperationSets.Add(typeName, result);
                    }
                    result.Add(operationSet);
                }
            }

            return resourceDataSchemaNameToOperationSets;
        }

        private Dictionary<string, OperationSet> CategorizeOperationGroups()
        {
            var rawRequestPathToOperationSets = new Dictionary<string, OperationSet>();
            foreach (var client in _input.Clients)
            {
                var requestPathList = new HashSet<string>();
                _operationGroupToRequestPaths.Add(client, requestPathList);
                foreach (var operation in client.Operations)
                {
                    var path = operation.GetHttpPath();
                    requestPathList.Add(path);
                    if (!rawRequestPathToOperationSets.TryGetValue(path, out var operationSet))
                    {
                        operationSet = new OperationSet(path, client, rawRequestPathToOperationSets, TypeFactory);
                        rawRequestPathToOperationSets.Add(path, operationSet);
                    }

                    operationSet.Add(operation);
                }
            }

            // add operation set for the partial resources here
            foreach (var path in Configuration.MgmtConfiguration.PartialResources.Keys)
            {
                rawRequestPathToOperationSets.Add(path, new OperationSet(path, null, rawRequestPathToOperationSets, TypeFactory));
            }

            return rawRequestPathToOperationSets;
        }

        private Dictionary<InputOperation, RequestPath> PopulateOperationsToRequestPaths()
        {
            var operationsToRequestPath = new Dictionary<InputOperation, RequestPath>();
            foreach (var client in _input.Clients)
            {
                foreach (var operation in client.Operations)
                {
                    operationsToRequestPath[operation] = RequestPath.FromOperation(operation, client, TypeFactory);
                }
            }
            return operationsToRequestPath;
        }
    }
}
