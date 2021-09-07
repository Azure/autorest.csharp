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
        private enum ResourceType
        {
            Default,
            Tuple
        }

        private BuildContext<MgmtOutputLibrary> _context;
        private CodeModel _codeModel;
        private MgmtConfiguration _mgmtConfiguration;

        private Dictionary<OperationGroup, MgmtRestClient>? _restClients;

        private Dictionary<ResourceType, Dictionary<OperationGroup, Resource>>? _armResources;
        private Dictionary<ResourceType, Dictionary<OperationGroup, ResourceContainer>>? _resourceContainers;

        /// <summary>
        /// This is a map from raw request path to the corresponding <see cref="ResourceData"/>
        /// This must be initialized before other maps
        /// </summary>
        private IDictionary<string, ResourceData>? _rawRequestPathToResourceData;

        /// <summary>
        /// This is a map from raw request path to a list of <see cref="RawOperationSet"/>
        /// This must be initialized before other maps
        /// </summary>
        private Dictionary<string, List<RawOperationSet>> _resourceNameToRawOperationSets;

        private Dictionary<Schema, TypeProvider>? _resourceModels;
        private Dictionary<string, TypeProvider> _nameToTypeProvider;
        private IEnumerable<Schema> _allSchemas;
        private Dictionary<Operation, MgmtLongRunningOperation>? _longRunningOperations;
        private Dictionary<Operation, NonLongRunningOperation>? _nonLongRunningOperations;
        private Dictionary<string, OperationGroup> _nonResourceOperationGroupMapping;

        private Dictionary<string, string> _mergedOperations;

        /// <summary>
        /// A mapping of parent resource type to child operation groups that are not resources.
        /// </summary>
        private Dictionary<string, HashSet<OperationGroup>> _childNonResourceOperationGroups;

        /// <summary>
        /// This is a map from raw request path to their corresponding <see cref="RawOperationSet"/>,
        /// which is a collection of the operations with the same raw request path
        /// </summary>
        private Dictionary<string, RawOperationSet> _rawRequestPathToOperations;

        /// <summary>
        /// This is a map from <see cref="OperationGroup"/> to the list of raw request path of its operations
        /// </summary>
        private Dictionary<OperationGroup, List<string>> _operationGroupToRequestPaths;

        private Dictionary<string, List<Resource>>? _childResources;

        public MgmtOutputLibrary(CodeModel codeModel, BuildContext<MgmtOutputLibrary> context) : base(codeModel, context)
        {
            CodeModelValidator.Validate(codeModel);
            OmitOperationGroups.RemoveOperationGroups(codeModel, context);
            _context = context;
            _mgmtConfiguration = context.Configuration.MgmtConfiguration;
            UpdateSubscriptionIdForTenantIdResource(codeModel);
            _codeModel = codeModel;
            _childNonResourceOperationGroups = new Dictionary<string, HashSet<OperationGroup>>();
            _operationGroupToRequestPaths = new Dictionary<OperationGroup, List<string>>();
            _rawRequestPathToOperations = new Dictionary<string, RawOperationSet>();
            _resourceNameToRawOperationSets = new Dictionary<string, List<RawOperationSet>>();
            _nameToTypeProvider = new Dictionary<string, TypeProvider>();
            _nonResourceOperationGroupMapping = new Dictionary<string, OperationGroup>();
            _mergedOperations = _mgmtConfiguration.MergeOperations.SelectMany(kv => kv.Value.Select(v => (FullOperationName: v, MethodName: kv.Key))).ToDictionary(kv => kv.FullOperationName, kv => kv.MethodName);
            _allSchemas = _codeModel.Schemas.Choices.Cast<Schema>()
                .Concat(_codeModel.Schemas.SealedChoices)
                .Concat(_codeModel.Schemas.Objects)
                .Concat(_codeModel.Schemas.Groups);

            // We can only manipulate objects from the code model, not RestClientMethod
            ReorderOperationParameters();

            // Categorize the operation group with their operation paths
            CategorizeOperationGroups();

            DecorateOperationGroup();
            UpdateListMethodNames();
        }

        /// <summary>
        /// This is the map from resource name to their raw request path
        /// </summary>
        private IDictionary<string, List<string>>? _resourceNameToRequestPaths;

        /// <summary>
        /// This is the map from resource name to a list of the corresponding raw request path
        /// </summary>
        private IDictionary<string, List<string>> ResourceNameToRequestPathMap => EnsureResourceNameToRequestPathsMap();

        private IDictionary<string, List<string>> EnsureResourceNameToRequestPathsMap()
        {
            if (_resourceNameToRequestPaths != null)
                return _resourceNameToRequestPaths;

            _resourceNameToRequestPaths = new Dictionary<string, List<string>>();
            foreach (var pair in _rawRequestPathToOperations)
            {
                var operationSet = pair.Value;
                if (operationSet.TryGetResourceName(_mgmtConfiguration, out var resourceName))
                {
                    if (_resourceNameToRequestPaths.TryGetValue(resourceName, out var list))
                    {
                        list.Add(operationSet.RequestPath);
                    }
                    else
                    {
                        _resourceNameToRequestPaths.Add(resourceName, new List<string> { operationSet.RequestPath });
                    }
                }
            }

            return _resourceNameToRequestPaths;
        }

        private void UpdateListMethodNames()
        {
            foreach (var operationGroup in _codeModel.OperationGroups)
            {
                foreach (var operation in operationGroup.Operations)
                {
                    var curName = operation.Language.Default.Name;
                    if (curName.Equals("List") || curName.StartsWith("ListBy"))
                    {
                        operation.Language.Default.Name = curName.Replace("List", "GetAll");
                    }
                    else if (curName.Equals("ListAll"))
                    {
                        if (operation.Parameters.Any(p => p.In == ParameterLocation.Path && p.Language.Default.Name.ToLower() == "resourcegroupname"))
                        {
                            operation.Language.Default.Name = "GetByResourceGroup";
                        }
                        else if (operation.Parameters.Any(p => p.In == ParameterLocation.Path && p.Language.Default.Name.ToLower() == "subscriptionid"))
                        {
                            operation.Language.Default.Name = "GetBySubscription";
                        }
                        else if (operation.Parameters.Any(p => p.In == ParameterLocation.Path && p.Language.Default.Name.ToLower() == "groupid"))
                        {
                            operation.Language.Default.Name = "GetByManagementGroup";
                        }
                        else
                        {
                            if (operation.Parameters.Any(p => p.In == ParameterLocation.Path))
                            {
                                ErrorHelpers.ThrowError($"{operationGroup.Key} has an operation {operation.Language.Default.Name} which isn't using standard path parameter names. Please update in your swagger or an autorest directive.");
                            }
                            else
                            {
                                operation.Language.Default.Name = "GetByTenant";
                            }
                        }
                    }
                    else if (curName.StartsWith("List"))
                    {
                        operation.Language.Default.Name = curName.Replace("List", "Get");
                    }
                }
            }
        }

        private void UpdateSubscriptionIdForTenantIdResource(CodeModel codeModel)
        {
            foreach (var operationGroup in codeModel.OperationGroups)
            {
                var subscriptionParameters = operationGroup.Operations
                        .SelectMany(op => op.Parameters)
                        .Where(p => p.Language.Default.Name.Equals("subscriptionId", StringComparison.InvariantCultureIgnoreCase));
                if (operationGroup.IsAncestorResourceTypeTenant(_context) && subscriptionParameters.Count() > 0)
                {
                    // subscriptionParameters all reference to the same object, so we need a copy of it.
                    // We only need to change enum value of Implementation, ShallowCopy is enough.
                    var newSubParam = subscriptionParameters.First().ShallowCopy();
                    newSubParam.Implementation = ImplementationLocation.Method;
                    foreach (var op in operationGroup.Operations)
                    {
                        var newParams = op.Parameters.ToList();
                        for (int i = 0; i < newParams.Count; i++)
                        {
                            if (newParams[i].Language.Default.Name.Equals("subscriptionId", StringComparison.InvariantCultureIgnoreCase))
                            {
                                newParams[i] = newSubParam;
                            }
                        }
                        op.Parameters = newParams;
                    }
                }
            }
        }

        public IEnumerable<Resource> ManagementGroupChildResources => GetChildren(ResourceTypeBuilder.ManagementGroups);

        private IEnumerable<Resource> GetChildren(string parent)
        {
            if (EnsureChildResources().TryGetValue(parent, out var children))
            {
                foreach (var child in children)
                {
                    yield return child;
                }
            }
            else
            {
                yield break;
            }
        }

        public IEnumerable<ResourceData> ResourceData => EnsureResourceData().Values;

        public IEnumerable<MgmtRestClient> RestClients => EnsureRestClients().Values;

        public IEnumerable<Resource> ArmResources => EnsureArmResources()[ResourceType.Default].Values;

        public IEnumerable<Resource> TupleResources => EnsureArmResources()[ResourceType.Tuple].Values;

        public IEnumerable<ResourceContainer> ResourceContainers => EnsureResourceContainers()[ResourceType.Default].Values;

        public IEnumerable<ResourceContainer> TupleResourceContainers => EnsureResourceContainers()[ResourceType.Tuple].Values;

        public IEnumerable<MgmtLongRunningOperation> LongRunningOperations => EnsureLongRunningOperations().Values;

        public IEnumerable<NonLongRunningOperation> NonLongRunningOperations => EnsureNonLongRunningOperations().Values;

        private static HashSet<string> ResourceTypes = new HashSet<string>
        {
            "resourceGroups",
            "subscriptions",
            "tenant"
        };

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

        public OperationGroup? GetOperationGroupForNonResource(string modelName)
        {
            OperationGroup? result = null;
            _nonResourceOperationGroupMapping.TryGetValue(modelName, out result);
            return result;
        }

        public ResourceContainer? GetResourceContainer(OperationGroup operationGroup)
        {
            if (EnsureResourceContainers()[ResourceType.Default].TryGetValue(operationGroup, out var result))
            {
                return result;
            }
            if (EnsureResourceContainers()[ResourceType.Tuple].TryGetValue(operationGroup, out result))
            {
                return result;
            }

            return null;
        }

        internal ResourceData? GetResourceDataFromSchema(string schemaName)
        {
            if (_resourceNameToRawOperationSets.TryGetValue(schemaName, out var operationSets))
            {
                var operationSet = operationSets.First();
                return EnsureResourceData()[operationSet.RequestPath];
            }
            return null;
        }

        public ResourceData GetResourceData(OperationGroup operationGroup)
        {
            if (TryGetResourceData(operationGroup, out var resourceData))
                return resourceData;

            throw new InvalidOperationException($"Cannot get ResourceData corresponding to {operationGroup}");
        }

        public bool TryGetMethodForMergedOperation(string operationFullName, [MaybeNullWhen(false)] out string methodName) => _mergedOperations.TryGetValue(operationFullName, out methodName);

        public bool TryGetResourceData(OperationGroup operationGroup, [MaybeNullWhen(false)] out ResourceData resourceData)
        {
            resourceData = null;
            foreach (var requestPath in _operationGroupToRequestPaths[operationGroup])
            {
                if (EnsureResourceData().TryGetValue(requestPath, out resourceData))
                    return true;
            }
            return false;
        }

        public Resource GetArmResource(OperationGroup operationGroup)
        {
            Resource? result;
            if (!EnsureArmResources()[ResourceType.Default].TryGetValue(operationGroup, out result))
            {
                result = EnsureArmResources()[ResourceType.Tuple][operationGroup];
            }
            return result;
        }

        public bool TryGetArmResource(OperationGroup operationGroup, [MaybeNullWhen(false)] out Resource resource)
        {
            return EnsureArmResources()[ResourceType.Default].TryGetValue(operationGroup, out resource);
        }

        /// <summary>
        /// Looks up a <see cref="RestClient" /> object by <see cref="OperationGroup" />.
        /// </summary>
        /// <param name="operationGroup">OperationGroup object.</param>
        /// <returns>The <see cref="RestClient" /> object associated with the operation group.</returns>
        public MgmtRestClient GetRestClient(OperationGroup operationGroup) => EnsureRestClients()[operationGroup];

        public OperationGroup? GetOperationGroupBySchema(Schema schema)
        {
            if (_resourceNameToRawOperationSets.TryGetValue(schema.Name, out var rawOperationSets))
                return rawOperationSets.FirstOrDefault()?.Operations.FirstOrDefault()?.Item2;
            return null;
        }

        internal LongRunningOperation GetLongRunningOperation(Operation op) => EnsureLongRunningOperations()[op];

        internal NonLongRunningOperation GetNonLongRunningOperation(Operation op) => EnsureNonLongRunningOperations()[op];

        internal MgmtObjectType? GetMgmtObjectFromModelName(string name)
        {
            TypeProvider? provider = _nameToTypeProvider[name];
            return provider as MgmtObjectType;
        }

        private Dictionary<OperationGroup, MgmtRestClient> EnsureRestClients()
        {
            if (_restClients != null)
            {
                return _restClients;
            }

            _restClients = new Dictionary<OperationGroup, MgmtRestClient>();
            foreach (var operationGroup in _codeModel.OperationGroups)
            {
                _restClients.Add(operationGroup, new MgmtRestClient(operationGroup, _context));
            }

            return _restClients;
        }

        private OperationGroup? GetRestApiOperationGroup()
        {
            foreach (var operationGroup in _codeModel.OperationGroups)
            {
                if (operationGroup.Key == "Operations")
                    return operationGroup;
            }

            return null;
        }

        public IEnumerable<MgmtNonResourceOperation> GetNonResourceOperations(string parent)
        {
            if (_childNonResourceOperationGroups.TryGetValue(parent, out var operationGroups))
            {
                return operationGroups.Select(operationGroup => new MgmtNonResourceOperation(operationGroup, _context,
                    ResourceTypeBuilder.TypeToExtensionName.GetValueOrDefault(parent) ?? parent));
            }

            return Enumerable.Empty<MgmtNonResourceOperation>();
        }

        private Dictionary<ResourceType, Dictionary<OperationGroup, Resource>> EnsureArmResources()
        {
            if (_armResources != null)
            {
                return _armResources;
            }

            _armResources = new Dictionary<ResourceType, Dictionary<OperationGroup, Resource>>();
            _armResources.Add(ResourceType.Default, new Dictionary<OperationGroup, Resource>());
            _armResources.Add(ResourceType.Tuple, new Dictionary<OperationGroup, Resource>());
            foreach (var operationGroup in _codeModel.GetResourceOperationGroups(_mgmtConfiguration))
            {
                var resourceType = operationGroup.IsTupleResource(_context) ? ResourceType.Tuple : ResourceType.Default;
                var childOperationGroups = _childNonResourceOperationGroups.GetValueOrDefault(operationGroup.ResourceType(_mgmtConfiguration));
                var resource = new Resource(operationGroup, _context, childOperationGroups);
                // validate to ensure that all the resource operations here have unique names
                EnsureUniqueName(_armResources, resource);
                _armResources[resourceType].Add(operationGroup, resource);
            }

            return _armResources;
        }

        private static void EnsureUniqueName<T, V>(IDictionary<ResourceType, V> mapToSearchIn, T value) where T : Resource where V : IDictionary<OperationGroup, T>
        {
            // we need to iterate over the existing items (including Default resource type and Tuple resource type)
            // to see if there are already any resource operations are returning the same resource as this new one
            foreach (var pair in mapToSearchIn.SelectMany(p => p.Value))
            {
                var existing = pair.Value;
                if (value.Type.Name.Equals(existing.Type.Name))
                {
                    throw new Exception($"Operation Group {existing.OperationGroup.Key} and {value.OperationGroup.Key} return the same resource {existing.ResourceName}, please consider mark these operation groups as extension resource in the `operation-group-is-extension` section");
                }
            }
        }

        private Dictionary<ResourceType, Dictionary<OperationGroup, ResourceContainer>> EnsureResourceContainers()
        {
            if (_resourceContainers != null)
            {
                return _resourceContainers;
            }

            _resourceContainers = new Dictionary<ResourceType, Dictionary<OperationGroup, ResourceContainer>>();
            _resourceContainers.Add(ResourceType.Default, new Dictionary<OperationGroup, ResourceContainer>());
            _resourceContainers.Add(ResourceType.Tuple, new Dictionary<OperationGroup, ResourceContainer>());
            foreach (var operationGroup in _codeModel.GetResourceOperationGroups(_mgmtConfiguration))
            {
                if (!operationGroup.IsSingletonResource(_context.Configuration.MgmtConfiguration))
                {
                    var resourceType = operationGroup.IsTupleResource(_context) ? ResourceType.Tuple : ResourceType.Default;
                    var resourceContainer = new ResourceContainer(operationGroup, _context);
                    // validate to ensure that all the resource container here have unique names
                    EnsureUniqueName(_resourceContainers, resourceContainer);
                    _resourceContainers[resourceType].Add(operationGroup, resourceContainer);
                }
            }

            return _resourceContainers;
        }

        private IDictionary<string, ResourceData> EnsureResourceData()
        {
            if (_rawRequestPathToResourceData != null)
            {
                return _rawRequestPathToResourceData;
            }

            _rawRequestPathToResourceData = new Dictionary<string, ResourceData>();
            foreach (var entry in ResourceSchemaMap)
            {
                var schema = entry.Key;
                if (ResourceNameToRequestPathMap.TryGetValue(schema.Name, out var requestPaths))
                {
                    foreach (var requestPath in requestPaths)
                    {
                        if (!_rawRequestPathToResourceData.ContainsKey(requestPath))
                        {
                            var resourceData = new ResourceData((ObjectSchema)schema, _context);
                            _rawRequestPathToResourceData.Add(requestPath, resourceData);
                        }
                    }
                }
            }

            return _rawRequestPathToResourceData;
        }

        private Dictionary<string, List<Resource>> EnsureChildResources()
        {
            if (_childResources != null)
            {
                return _childResources;
            }

            _childResources = new Dictionary<string, List<Resource>>();
            var parentResourceTypes = new HashSet<string> { ResourceTypeBuilder.Tenant, ResourceTypeBuilder.ManagementGroups, ResourceTypeBuilder.Subscriptions, ResourceTypeBuilder.ResourceGroups };
            foreach (var resource in ArmResources)
            {
                var parents = resource.OperationGroup.Operations.Where(op => parentResourceTypes.Contains(op.ParentResourceType())).Select(op => op.ParentResourceType()).Distinct().ToList();
                foreach (var parent in parents)
                {
                    if (_childResources.TryGetValue(parent, out var resources))
                    {
                        resources.Add(resource);
                    }
                    else
                    {
                        _childResources.Add(parent, new List<Resource> { resource });
                    }
                }
            }

            return _childResources;
        }

        internal bool IsLongRunningReallyLong(RestClientMethod clientMethod)
        {
            return clientMethod.Operation.IsLongRunningReallyLong ?? false;
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
                foreach (var operationGroup in _codeModel.OperationGroups)
                {
                    foreach (var operation in operationGroup.Operations)
                    {
                        if (operation.IsLongRunning)
                        {
                            _longRunningOperations.Add(
                                operation,
                                new MgmtLongRunningOperation(
                                    operationGroup,
                                    operation,
                                    _context,
                                    FindLongRunningOperationInfo(operationGroup, operation)));
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
                foreach (var operationGroup in _codeModel.OperationGroups)
                {
                    // if non-resource, we won't be able to get the info for LRO
                    if (operationGroup.IsResource(_mgmtConfiguration))
                    {
                        foreach (var operation in operationGroup.Operations)
                        {
                            if (!operation.IsLongRunning
                                && operation.Requests.FirstOrDefault().Protocol.Http is HttpRequest httpRequest
                                && desiredHttpMethods.Contains(httpRequest.Method))
                            {
                                _nonLongRunningOperations.Add(
                                    operation,
                                    new NonLongRunningOperation(
                                        operationGroup,
                                        operation,
                                        _context,
                                        FindLongRunningOperationInfo(operationGroup, operation)
                                    )
                                );
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

        public LongRunningOperationInfo FindLongRunningOperationInfo(OperationGroup operationGroup, Operation operation)
        {
            var mgmtRestClient = GetRestClient(operationGroup);

            Debug.Assert(mgmtRestClient != null, "Unexpected. Unable find matching rest client.");

            var nextOperationMethod = operation?.Language?.Default?.Paging != null
                ? mgmtRestClient.GetNextOperationMethod(operation.Requests.Single())
                : null;

            return new LongRunningOperationInfo(
                "public",
                mgmtRestClient.ClientPrefix,
                nextOperationMethod);
        }

        private Dictionary<Schema, TypeProvider> BuildModels()
        {
            var models = new Dictionary<Schema, TypeProvider>();

            foreach (var schema in _allSchemas)
            {
                if (_resourceNameToRawOperationSets.ContainsKey(schema.Name))
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
                if (_resourceNameToRawOperationSets.ContainsKey(schema.Name))
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

        private void DecorateOperationGroup()
        {
            foreach (var operationSet in _rawRequestPathToOperations.Values)
            {
                foreach (var operation in operationSet)
                {
                    var operationGroup = operation.Item2;
                    ResourceTypes.Add(operationGroup.ResourceType(_mgmtConfiguration));

                    string? parent;
                    if (_mgmtConfiguration.OperationGroupToParent.TryGetValue(operationGroup.Key, out parent))
                    {
                        // If overridden, add parent to known types list (trusting user input)
                        ResourceTypes.Add(parent);
                    }
                    if (operationSet.TryGetResourceName(_mgmtConfiguration, out var resourceName))
                    {
                        AddOperationSetToResourceMap(resourceName, operationSet);
                    }
                    else
                    {
                        // TODO -- this will be removed after everything is based on request path
                        if (operationGroup.IsResource(_mgmtConfiguration))
                            continue;
                        AddNonResourceOperationGroupMapping(operationGroup);
                        AddToChildNonResourceOperationGroupMap(operationGroup);
                    }
                }
            }
            ParentDetection.VerifyParents(_codeModel.OperationGroups, ResourceTypes, _mgmtConfiguration);
        }

        private void AddToChildNonResourceOperationGroupMap(OperationGroup operationGroup)
        {
            var parent = operationGroup.ParentResourceType(_mgmtConfiguration);
            if (_childNonResourceOperationGroups.ContainsKey(parent))
            {
                _childNonResourceOperationGroups[parent].Add(operationGroup);
            }
            else
            {
                _childNonResourceOperationGroups[parent] = new HashSet<OperationGroup>() { operationGroup };
            }
        }

        private void AddNonResourceOperationGroupMapping(OperationGroup operationsGroup)
        {
            foreach (var operation in operationsGroup.Operations.Where(o => o.Language.Default.Name == "Get"))
            {
                var responseSchema = operation.Responses.First().ResponseSchema;
                if (responseSchema != null)
                {
                    _nonResourceOperationGroupMapping[responseSchema.Name] = operationsGroup;
                }
            }
        }

        private void AddOperationSetToResourceMap(string resourceName, RawOperationSet operationSet)
        {
            List<RawOperationSet>? result;
            if (!_resourceNameToRawOperationSets.TryGetValue(resourceName, out result))
            {
                result = new List<RawOperationSet>();
                _resourceNameToRawOperationSets.Add(resourceName, result);
            }
            result.Add(operationSet);
        }

        private void CategorizeOperationGroups()
        {
            foreach (var operationGroup in _codeModel.OperationGroups)
            {
                var requestPathList = new List<string>();
                _operationGroupToRequestPaths.Add(operationGroup, requestPathList);
                foreach (var operation in operationGroup.Operations)
                {
                    var path = operation.GetHttpPath();
                    requestPathList.Add(path);
                    if (_rawRequestPathToOperations.TryGetValue(path, out var list))
                    {
                        list.Add(new Tuple<Operation, OperationGroup>(operation, operationGroup));
                    }
                    else
                    {
                        _rawRequestPathToOperations.Add(path, new RawOperationSet(path, new List<Tuple<Operation, OperationGroup>> { new Tuple<Operation, OperationGroup>(operation, operationGroup) }));
                    }
                }
            }
        }
    }
}
