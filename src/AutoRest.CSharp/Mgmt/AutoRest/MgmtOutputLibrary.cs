// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.AutoRest
{
    internal class MgmtOutputLibrary : OutputLibrary
    {
        private BuildContext<MgmtOutputLibrary> _context;
        private CodeModel _codeModel;
        private MgmtConfiguration _mgmtConfiguration;

        private Dictionary<OperationGroup, MgmtRestClient>? _restClients;
        private Dictionary<OperationGroup, ResourceOperation>? _resourceOperations;
        private Dictionary<OperationGroup, ResourceContainer>? _resourceContainers;
        private Dictionary<OperationGroup, ResourceData>? _resourceData;
        private Dictionary<OperationGroup, Resource>? _armResource;

        private Dictionary<Schema, TypeProvider>? _resourceModels;
        private Dictionary<string, List<OperationGroup>> _operationGroups;
        private IEnumerable<Schema> _allSchemas;

        public MgmtOutputLibrary(CodeModel codeModel, BuildContext<MgmtOutputLibrary> context) : base(codeModel, context)
        {
            _codeModel = codeModel;
            _context = context;
            _mgmtConfiguration = context.Configuration.MgmtConfiguration;
            _operationGroups = new Dictionary<string, List<OperationGroup>>();
            _allSchemas = _codeModel.Schemas.Choices.Cast<Schema>()
                .Concat(_codeModel.Schemas.SealedChoices)
                .Concat(_codeModel.Schemas.Objects)
                .Concat(_codeModel.Schemas.Groups);
            DecorateOperationGroup();
        }

        public IEnumerable<Resource> ArmResource => EnsureArmResource().Values;

        public IEnumerable<ResourceData> ResourceData => EnsureResourceData().Values;

        public IEnumerable<MgmtRestClient> RestClients => EnsureRestClients().Values;

        public IEnumerable<ResourceOperation> ResourceOperations => EnsureResourceOperations().Values;

        public IEnumerable<ResourceContainer> ResourceContainers => EnsureResourceContainers().Values;

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

        private Dictionary<OperationGroup, ResourceOperation> EnsureResourceOperations()
        {
            if (_resourceOperations != null)
            {
                return _resourceOperations;
            }

            _resourceOperations = new Dictionary<OperationGroup, ResourceOperation>();
            foreach (var operationGroup in _codeModel.GetResourceOperationGroups(_mgmtConfiguration))
            {
                _resourceOperations.Add(operationGroup, new ResourceOperation(operationGroup, _context));
            }

            return _resourceOperations;
        }

        private Dictionary<OperationGroup, ResourceContainer> EnsureResourceContainers()
        {
            if (_resourceContainers != null)
            {
                return _resourceContainers;
            }

            _resourceContainers = new Dictionary<OperationGroup, ResourceContainer>();
            foreach (var operationGroup in _codeModel.GetResourceOperationGroups(_mgmtConfiguration))
            {
                _resourceContainers.Add(operationGroup, new ResourceContainer(operationGroup, _context));
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
                            CSharpType? inherits = ((ObjectType)entry.Value).Inherits;
                            if (!(inherits is null))
                            {
                                resourceData.OverrideInherits(inherits);
                            }
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
                            _armResource.Add(operation, new Resource(operation.Resource(_mgmtConfiguration), _context));
                        }
                    }
                }
            }

            return _armResource;
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
            TypeProvider? provider = Models.FirstOrDefault (m => m.Type.Name == originalName);
            provider ??= ResourceSchemaMap.Values.FirstOrDefault (m => m.Type.Name == originalName);
            return provider?.Type;
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
                models.Add(schema, BuildModel(schema));

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
                    resourceModels.Add(schema, BuildResourceModel(schema));
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

        /// <summary>
        /// Looks for an <see cref="OperationGroup" /> by a <see cref="MgmtRestClient" />.
        /// </summary>
        /// <param name="restClient">The <see cref="MgmtRestClient" /> instance which is built from the operation group.</param>
        /// <returns>The operation group. `null` if not found.</returns>
        public OperationGroup FindOperationGroup(MgmtRestClient restClient) {
            return EnsureRestClients().FirstOrDefault(ogToClient => ogToClient.Value == restClient).Key;
        }

        /// <summary>
        /// Looks for an <see cref="OperationGroup" /> by a <see cref="ResourceOperation" />.
        /// </summary>
        /// <param name="resourceOperation">The <see cref="ResourceOperation" /> instance which is built from the operation group.</param>
        /// <returns>The operation group. `null` if not found.</returns>
        public OperationGroup FindOperationGroup(ResourceOperation resourceOperation) {
            return EnsureResourceOperations().FirstOrDefault(ogToOperation => ogToOperation.Value == resourceOperation).Key;
        }

        /// <summary>
        /// Looks for an <see cref="OperationGroup" /> by <see cref="ResourceContainer" />.
        /// </summary>
        /// <param name="container">The <see cref="ResourceContainer" /> instance which is built from the operation group.</param>
        /// <returns>The operation group. `null` if not found.</returns>
        public OperationGroup FindOperationGroup(ResourceContainer container) {
            return EnsureResourceContainers().FirstOrDefault(ogToContainer => ogToContainer.Value == container).Key;
        }

        /// <summary>
        /// Looks for an <see cref="OperationGroup" /> by <see cref="ResourceData" />.
        /// </summary>
        /// <param name="resourceData">The <see cref="ResourceData" /> instance which is built from the operation group.</param>
        /// <returns>The operation group. `null` if not found.</returns>
        public OperationGroup FindOperationGroup(ResourceData resourceData) {
            return EnsureResourceData().FirstOrDefault(ogToData => ogToData.Value == resourceData).Key;
        }

        /// <summary>
        /// Looks for an <see cref="OperationGroup" /> by <see cref="Resource" />.
        /// </summary>
        /// <param name="resource">The <see cref="Resource" /> instance which is built from the operation group.</param>
        /// <returns>The operation group. `null` if not found.</returns>
        public OperationGroup FindOperationGroup(Resource resource) {
            return EnsureArmResource().FirstOrDefault(ogToResource => ogToResource.Value == resource).Key;
        }

        public MgmtRestClient FindRestClient(OperationGroup operationGroup)
        {
            return EnsureRestClients()[operationGroup];
        }

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
