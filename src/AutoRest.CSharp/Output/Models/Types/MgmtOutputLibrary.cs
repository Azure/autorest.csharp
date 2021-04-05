// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models.Type.Decorate;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class MgmtOutputLibrary : OutputLibrary
    {
        private BuildContext<MgmtOutputLibrary> _context;
        private CodeModel _codeModel;

        private Dictionary<OperationGroup, MgmtClient>? _clients;
        private Dictionary<OperationGroup, MgmtRestClient>? _restClients;
        private Dictionary<OperationGroup, ResourceOperation>? _resourceOperations;
        private Dictionary<OperationGroup, ResourceContainer>? _resourceContainers;
        private Dictionary<string, ResourceData>? _resourceData;
        private Dictionary<string, ArmResource>? _armResource;

        private Dictionary<Schema, TypeProvider>? _resourceModels;
        private Dictionary<string, List<OperationGroup>> _operationGroups;
        private IEnumerable<Schema> _allSchemas;

        public Dictionary<Schema, TypeProvider> ResourceSchemaMap => _resourceModels ??= BuildResourceModels();

        public MgmtOutputLibrary(CodeModel codeModel, BuildContext<MgmtOutputLibrary> context) : base(codeModel, context)
        {
            _codeModel = codeModel;
            _context = context;
            _operationGroups = new Dictionary<string, List<OperationGroup>>();
            _allSchemas = _codeModel.Schemas.Choices.Cast<Schema>()
                .Concat(_codeModel.Schemas.SealedChoices)
                .Concat(_codeModel.Schemas.Objects)
                .Concat(_codeModel.Schemas.Groups);
            DecorateOperationGroup();
            DecorateSchema();
        }

        public IEnumerable<ArmResource> ArmResource => EnsureArmResource().Values;

        public IEnumerable<ResourceData> ResourceData => EnsureResourceData().Values;

        public IEnumerable<MgmtRestClient> RestClients => EnsureRestClients().Values;

        public IEnumerable<ResourceOperation> ResourceOperations => EnsureResourceOperations().Values;

        public IEnumerable<ResourceContainer> ResourceContainers => EnsureResourceContainers().Values;

        public IEnumerable<MgmtClient> Clients => EnsureClients().Values;

        private Dictionary<Schema, TypeProvider>? _models;
        internal Dictionary<Schema, TypeProvider> SchemaMap => _models ??= BuildModels();
        public IEnumerable<TypeProvider> Models => SchemaMap.Values;

        private Dictionary<OperationGroup, MgmtClient> EnsureClients()
        {
            if (_clients != null)
            {
                return _clients;
            }

            _clients = new Dictionary<OperationGroup, MgmtClient>();

            if (_context.Configuration.PublicClients)
            {
                foreach (var operationGroup in _codeModel.OperationGroups)
                {
                    _clients.Add(operationGroup, new MgmtClient(operationGroup, _context));
                }
            }

            return _clients;
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

        private Dictionary<OperationGroup, ResourceOperation> EnsureResourceOperations()
        {
            if (_resourceOperations != null)
            {
                return _resourceOperations;
            }

            _resourceOperations = new Dictionary<OperationGroup, ResourceOperation>();
            foreach (var operationGroup in _codeModel.OperationGroups)
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
            foreach (var operationGroup in _codeModel.OperationGroups)
            {
                _resourceContainers.Add(operationGroup, new ResourceContainer(operationGroup, _context));
            }

            return _resourceContainers;
        }

        private Dictionary<string, ResourceData> EnsureResourceData()
        {
            if (_resourceData != null)
            {
                return _resourceData;
            }

            _resourceData = new Dictionary<string, ResourceData>();
            foreach (var entry in ResourceSchemaMap)
            {
                var schema = entry.Key;
                var operations = _operationGroups[schema.Name];
                foreach (var operation in operations)
                {
                    if (!_resourceData.ContainsKey(operation.Resource))
                    {
                        var resourceData = new ResourceData((ObjectSchema)schema, operation, _context);
                        CSharpType? inherits = ((ObjectType)entry.Value).Inherits;
                        if (!(inherits is null))
                        {
                            resourceData.OverrideInherits(inherits);
                        }
                        _resourceData.Add(operation.Resource, resourceData);
                    }
                }
            }

            return _resourceData;
        }

        private Dictionary<string, ArmResource> EnsureArmResource()
        {
            if (_armResource != null)
            {
                return _armResource;
            }

            _armResource = new Dictionary<string, ArmResource>();
            foreach (var entry in ResourceSchemaMap)
            {
                var schema = entry.Key;
                var operations = _operationGroups[schema.Name];
                foreach (var operation in operations)
                {
                    if (!_armResource.ContainsKey(operation.Resource))
                    {
                        _armResource.Add(operation.Resource, new ArmResource(operation.Resource, _context));
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

            if (_context.Configuration.AzureArm)
            {
                foreach (var schema in _allSchemas)
                {
                    if (_operationGroups.ContainsKey(schema.Name))
                    {
                        resourceModels.Add(schema, BuildResourceModel(schema));
                    }
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


        public MgmtClient? FindClient(OperationGroup operationGroup)
        {
            EnsureClients().TryGetValue(operationGroup, out var client);
            return client;
        }

        public MgmtRestClient FindRestClient(OperationGroup operationGroup)
        {
            return EnsureRestClients()[operationGroup];
        }

        private void DecorateOperationGroup()
        {
            foreach (var operationsGroup in _codeModel.OperationGroups)
            {
                MapHttpMethodToOperation(operationsGroup);
                string? resourceType;
                operationsGroup.ResourceType = _context.Configuration.OperationGroupToResourceType.TryGetValue(operationsGroup.Key, out resourceType) ? resourceType : ResourceTypeBuilder.ConstructOperationResourceType(operationsGroup);
                operationsGroup.IsTenantResource = TenantDetection.IsTenantOnly(operationsGroup);
                string? resource;
                operationsGroup.Resource = _context.Configuration.OperationGroupToResource.TryGetValue(operationsGroup.Key, out resource) ? resource : SchemaDetection.GetSchema(operationsGroup).Name;
                AddOperationGroupToResourceMap(operationsGroup);
                string? nameOverride;
                if (_context.Configuration.ResourceRename.TryGetValue(operationsGroup.Resource, out nameOverride))
                {
                    operationsGroup.Resource = nameOverride;
                }
            }
        }

        private void DecorateSchema()
        {
            foreach (var schema in _allSchemas)
            {
                string? resourceName;
                if (_context.Configuration.ResourceRename.TryGetValue(schema.Name, out resourceName))
                {
                    schema.NameOverride = resourceName;
                }
            }
        }

        private void MapHttpMethodToOperation(OperationGroup operationsGroup)
        {
            operationsGroup.OperationHttpMethodMapping = new Dictionary<HttpMethod, List<ServiceRequest>>();
            foreach (var operation in operationsGroup.Operations)
            {
                foreach (var serviceRequest in operation.Requests)
                {
                    if (serviceRequest.Protocol.Http is HttpRequest httpRequest)
                    {
                        httpRequest.ProviderSegments = ProviderSegmentDetection.GetProviderSegments(httpRequest.Path);
                        List<ServiceRequest>? list;
                        if (!operationsGroup.OperationHttpMethodMapping.TryGetValue(httpRequest.Method, out list))
                        {
                            list = new List<ServiceRequest>();
                            operationsGroup.OperationHttpMethodMapping.Add(httpRequest.Method, list);
                        }
                        list.Add(serviceRequest);
                    }
                }
            }
        }

        private void AddOperationGroupToResourceMap(OperationGroup operationsGroup)
        {
            List<OperationGroup>? result;
            if (!_operationGroups.TryGetValue(operationsGroup.Resource, out result))
            {
                result = new List<OperationGroup>();
                _operationGroups.Add(operationsGroup.Resource, result);
            }
            result.Add(operationsGroup);
        }
    }
}
