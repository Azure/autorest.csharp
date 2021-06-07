// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Types;

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

        private Dictionary<ResourceType, Dictionary<OperationGroup, ResourceOperation>>? _resourceOperations;
        private Dictionary<ResourceType, Dictionary<OperationGroup, ResourceContainer>>? _resourceContainers;
        private Dictionary<OperationGroup, ResourceData>? _resourceData;
        private Dictionary<OperationGroup, Resource>? _armResource;

        private Dictionary<Schema, TypeProvider>? _resourceModels;
        private Dictionary<string, List<OperationGroup>> _operationGroups;
        private Dictionary<string, TypeProvider> _nameToTypeProvider;
        private IEnumerable<Schema> _allSchemas;
        private Dictionary<Operation, MgmtLongRunningOperation>? _longRunningOperations;
        private Dictionary<Operation, NonLongRunningOperation>? _nonLongRunningOperations;

        public MgmtOutputLibrary(CodeModel codeModel, BuildContext<MgmtOutputLibrary> context) : base(codeModel, context)
        {
            _codeModel = codeModel;
            _context = context;
            _mgmtConfiguration = context.Configuration.MgmtConfiguration;
            _operationGroups = new Dictionary<string, List<OperationGroup>>();
            _nameToTypeProvider = new Dictionary<string, TypeProvider>();
            _allSchemas = _codeModel.Schemas.Choices.Cast<Schema>()
                .Concat(_codeModel.Schemas.SealedChoices)
                .Concat(_codeModel.Schemas.Objects)
                .Concat(_codeModel.Schemas.Groups);
            RestApiOperationGroup = GetRestApiOperationGroup();
            DecorateOperationGroup();
        }

        public OperationGroup? RestApiOperationGroup { get; }

        public IEnumerable<Resource> ArmResource => EnsureArmResource().Values;

        public IEnumerable<ResourceData> ResourceData => EnsureResourceData().Values;

        public IEnumerable<MgmtRestClient> RestClients => EnsureRestClients().Values;

        public IEnumerable<ResourceOperation> ResourceOperations => EnsureResourceOperations()[ResourceType.Default].Values;

        public IEnumerable<ResourceOperation> TupleResourceOperations => EnsureResourceOperations()[ResourceType.Tuple].Values;

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

        public IEnumerable<TypeProvider> Models => SchemaMap.Values;

        public ResourceOperation GetResourceOperation(OperationGroup operationGroup) => EnsureResourceOperations()[ResourceType.Default][operationGroup];

        public ResourceContainer GetResourceContainer(OperationGroup operationGroup) => EnsureResourceContainers()[ResourceType.Default][operationGroup];

        internal ResourceData? GetResourceDataFromSchema(string schemaName)
        {
            List<OperationGroup>? operationGroups;
            OperationGroup opGroup;
            if (_operationGroups.TryGetValue(schemaName, out operationGroups))
                opGroup = operationGroups.FirstOrDefault();
            else
                return null;

            return GetResourceData(opGroup);
        }

        public ResourceData GetResourceData(OperationGroup operationGroup) => EnsureResourceData()[operationGroup];

        /// <summary>
        /// Looks up a <see cref="Resource" /> object by <see cref="OperationGroup" />.
        /// </summary>
        /// <param name="operationGroup">OperationGroup object.</param>
        /// <returns>The <see cref="Resource" /> object associated with the operation group.</returns>
        public Resource GetArmResource(OperationGroup operationGroup) => EnsureArmResource()[operationGroup];

        /// <summary>
        /// Looks up a <see cref="RestClient" /> object by <see cref="OperationGroup" />.
        /// </summary>
        /// <param name="operationGroup">OperationGroup object.</param>
        /// <returns>The <see cref="RestClient" /> object associated with the operation group.</returns>
        public MgmtRestClient GetRestClient(OperationGroup operationGroup) => EnsureRestClients()[operationGroup];

        public OperationGroup? GetOperationGroupBySchema(Schema schema)
        {
            List<OperationGroup>? operationGroups;
            if (_operationGroups.TryGetValue(schema.Name, out operationGroups))
                return operationGroups.FirstOrDefault();
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

        private Dictionary<ResourceType, Dictionary<OperationGroup, ResourceOperation>> EnsureResourceOperations()
        {
            if (_resourceOperations != null)
            {
                return _resourceOperations;
            }

            _resourceOperations = new Dictionary<ResourceType, Dictionary<OperationGroup, ResourceOperation>>();
            _resourceOperations.Add(ResourceType.Default, new Dictionary<OperationGroup, ResourceOperation>());
            _resourceOperations.Add(ResourceType.Tuple, new Dictionary<OperationGroup, ResourceOperation>());
            foreach (var operationGroup in _codeModel.GetResourceOperationGroups(_mgmtConfiguration))
            {
                var resourceType = operationGroup.IsTupleResource(_context) ? ResourceType.Tuple : ResourceType.Default;
                _resourceOperations[resourceType].Add(operationGroup, new ResourceOperation(operationGroup, _context));
            }

            return _resourceOperations;
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
                    _resourceContainers[resourceType].Add(operationGroup, new ResourceContainer(operationGroup, _context));
                }
            }

            return _resourceContainers;
        }

        private Dictionary<OperationGroup, ResourceData> EnsureResourceData()
        {
            if (_resourceData != null)
            {
                return _resourceData;
            }

            _resourceData = new Dictionary<OperationGroup, ResourceData>();
            foreach (var entry in ResourceSchemaMap)
            {
                var schema = entry.Key;
                List<OperationGroup>? operations = _operationGroups[schema.Name];

                if (operations != null)
                {
                    foreach (var operation in operations)
                    {
                        if (!_resourceData.ContainsKey(operation))
                        {
                            var resourceData = new ResourceData((ObjectSchema)schema, operation, _context);
                            _resourceData.Add(operation, resourceData);
                        }
                    }
                }
            }

            return _resourceData;
        }

        private Dictionary<OperationGroup, Resource> EnsureArmResource()
        {
            if (_armResource != null)
            {
                return _armResource;
            }

            _armResource = new Dictionary<OperationGroup, Resource>();
            foreach (var entry in ResourceSchemaMap)
            {
                var schema = entry.Key;
                List<OperationGroup>? operations = _operationGroups[schema.Name];

                if (operations != null)
                {
                    foreach (var operation in operations)
                    {
                        if (!_armResource.ContainsKey(operation))
                        {
                            _armResource.Add(operation, new Resource(operation, _context));
                        }
                    }
                }
            }

            return _armResource;
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
            TypeProvider? provider = _nameToTypeProvider[originalName];
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
                if (_operationGroups.ContainsKey(schema.Name))
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
                if (_operationGroups.ContainsKey(schema.Name))
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
            ObjectSchema objectSchema => new MgmtObjectType(objectSchema, _context, false),
            _ => throw new NotImplementedException()
        };

        private TypeProvider BuildResourceModel(Schema schema) => schema switch
        {
            ObjectSchema objectSchema => new MgmtObjectType(objectSchema, _context, true),
            _ => throw new NotImplementedException()
        };

        private void DecorateOperationGroup()
        {
            foreach (var operationsGroup in _codeModel.OperationGroups)
            {
                ResourceTypes.Add(operationsGroup.ResourceType(_mgmtConfiguration));

                // TODO better support for extension resources
                string? parent;
                if (_mgmtConfiguration.OperationGroupToParent.TryGetValue(operationsGroup.Key, out parent))
                {
                    // If overriden, add parent to known types list (trusting user input)
                    ResourceTypes.Add(parent);
                }
                if (operationsGroup.IsResource(_mgmtConfiguration))
                    AddOperationGroupToResourceMap(operationsGroup);
            }
            ParentDetection.VerfiyParents(_codeModel.OperationGroups, ResourceTypes, _mgmtConfiguration);
        }

        private void AddOperationGroupToResourceMap(OperationGroup operationsGroup)
        {
            List<OperationGroup>? result;
            if (!_operationGroups.TryGetValue(operationsGroup.Resource(_mgmtConfiguration), out result))
            {
                result = new List<OperationGroup>();
                _operationGroups.Add(operationsGroup.Resource(_mgmtConfiguration), result);
            }
            result.Add(operationsGroup);
        }
    }
}
