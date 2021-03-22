// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Responses;
using AutoRest.CSharp.Output.Models.Type.Decorate;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class OutputLibrary
    {
        private readonly CodeModel _codeModel;
        private readonly BuildContext _context;
        private Dictionary<Schema, TypeProvider>? _models;
        private Dictionary<OperationGroup, Client>? _clients;
        private Dictionary<OperationGroup, RestClient>? _restClients;
        private Dictionary<OperationGroup, ResourceOperation>? _resourceOperations;
        private Dictionary<OperationGroup, ResourceContainer>? _resourceContainers;
        private Dictionary<string, ResourceData>? _resourceData;
        private Dictionary<string, ArmResource>? _armResource;

        private Dictionary<Schema, TypeProvider>? _resourceModels;
        private Dictionary<Operation, LongRunningOperation>? _operations;
        private Dictionary<Operation, ResponseHeaderGroupType>? _headerModels;
        private Dictionary<string, List<OperationGroup>> _operationGroups;
        private IEnumerable<Schema> _allSchemas;

        private Dictionary<Schema, TypeProvider> SchemaMap => _models ??= BuildModels();

        public Dictionary<Schema, TypeProvider> ResourceSchemaMap => _resourceModels ??= BuildResourceModels();

        public OutputLibrary(CodeModel codeModel, BuildContext context)
        {
            _codeModel = codeModel;
            _context = context;
            _operationGroups = new Dictionary<string, List<OperationGroup>>();
            _allSchemas = _codeModel.Schemas.Choices.Cast<Schema>()
                .Concat(_codeModel.Schemas.SealedChoices)
                .Concat(_codeModel.Schemas.Objects)
                .Concat(_codeModel.Schemas.Groups);
            if (context.Configuration.AzureArm)
            {
                DecorateOperationGroup();
                DecorateSchema();
            }
        }

        public IEnumerable<TypeProvider> Models => SchemaMap.Values;

        public IEnumerable<ArmResource> ArmResource => EnsureArmResource().Values;

        public IEnumerable<ResourceData> ResourceData => EnsureResourceData().Values;

        public IEnumerable<RestClient> RestClients => EnsureRestClients().Values;

        public IEnumerable<ResourceOperation> ResourceOperations => EnsureResourceOperations().Values;

        public IEnumerable<ResourceContainer> ResourceContainers => EnsureResourceContainers().Values;

        public IEnumerable<Client> Clients => EnsureClients().Values;

        public IEnumerable<LongRunningOperation> LongRunningOperations => EnsureLongRunningOperations().Values;

        public IEnumerable<ResponseHeaderGroupType> HeaderModels => (_headerModels ??= EnsureHeaderModels()).Values;

        private static HashSet<string> ResourceTypes = new HashSet<string>
        {
            {"resourceGroups"},
            {"subscriptions"}
        };


        private Dictionary<Operation, ResponseHeaderGroupType> EnsureHeaderModels()
        {
            if (_headerModels != null)
            {
                return _headerModels;
            }

            _headerModels = new Dictionary<Operation, ResponseHeaderGroupType>();
            foreach (var operationGroup in _codeModel.OperationGroups)
            {
                foreach (var operation in operationGroup.Operations)
                {
                    var headers = ResponseHeaderGroupType.TryCreate(operationGroup, operation, _context);
                    if (headers != null)
                    {
                        _headerModels.Add(operation, headers);
                    }
                }
            }

            return _headerModels;
        }

        private Dictionary<Operation, LongRunningOperation> EnsureLongRunningOperations()
        {
            if (_operations != null)
            {
                return _operations;
            }

            _operations = new Dictionary<Operation, LongRunningOperation>();

            if (_context.Configuration.PublicClients)
            {
                foreach (var operationGroup in _codeModel.OperationGroups)
                {
                    foreach (var operation in operationGroup.Operations)
                    {
                        if (operation.IsLongRunning)
                        {
                            _operations.Add(operation, new LongRunningOperation(operationGroup, operation, _context));
                        }
                    }
                }
            }

            return _operations;
        }

        private Dictionary<OperationGroup, Client> EnsureClients()
        {
            if (_clients != null)
            {
                return _clients;
            }

            _clients = new Dictionary<OperationGroup, Client>();

            if (_context.Configuration.PublicClients)
            {
                foreach (var operationGroup in _codeModel.OperationGroups)
                {
                    _clients.Add(operationGroup, new Client(operationGroup, _context));
                }
            }

            return _clients;
        }

        private Dictionary<OperationGroup, RestClient> EnsureRestClients()
        {
            if (_restClients != null)
            {
                return _restClients;
            }

            _restClients = new Dictionary<OperationGroup, RestClient>();
            foreach (var operationGroup in _codeModel.OperationGroups)
            {
                _restClients.Add(operationGroup, new RestClient(operationGroup, _context));
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
                        _resourceData.Add(operation.Resource, new ResourceData((ObjectSchema)schema, operation, _context, true));
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

        public TypeProvider FindTypeForSchema(Schema schema)
        {
            TypeProvider? result;
            if (!SchemaMap.TryGetValue(schema, out result) && !ResourceSchemaMap.TryGetValue(schema, out result))
            {
                throw new KeyNotFoundException($"{schema.Name} was not found in model and resource schema map");
            }

            return result;
        }

        private Dictionary<Schema, TypeProvider> BuildModels()
        {
            var models = new Dictionary<Schema, TypeProvider>();

            foreach (var schema in _allSchemas)
            {
                if (_context.Configuration.AzureArm && _operationGroups.ContainsKey(schema.Name))
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
            ObjectSchema objectSchema => new ObjectType(objectSchema, _context),
            _ => throw new NotImplementedException()
        };

        private TypeProvider BuildResourceModel(Schema schema) => schema switch
        {
            ObjectSchema objectSchema => new ObjectType(objectSchema, _context, true),
            _ => throw new NotImplementedException()
        };

        public LongRunningOperation FindLongRunningOperation(Operation operation)
        {
            Debug.Assert(operation.IsLongRunning);

            return EnsureLongRunningOperations()[operation];
        }

        public Client? FindClient(OperationGroup operationGroup)
        {
            EnsureClients().TryGetValue(operationGroup, out var client);
            return client;
        }

        public RestClient FindRestClient(OperationGroup operationGroup)
        {
            return EnsureRestClients()[operationGroup];
        }

        public ResponseHeaderGroupType? FindHeaderModel(Operation operation)
        {
            EnsureHeaderModels().TryGetValue(operation, out var model);
            return model;
        }

        private void DecorateOperationGroup()
        {
            foreach (var operationsGroup in _codeModel.OperationGroups)
            {
                MapHttpMethodToOperation(operationsGroup);
                string? resourceType;
                operationsGroup.ResourceType = _context.Configuration.OperationGroupToResourceType.TryGetValue(operationsGroup.Key, out resourceType) ? resourceType : ResourceTypeBuilder.ConstructOperationResourseType(operationsGroup);
                ResourceTypes.Add(operationsGroup.ResourceType);
                operationsGroup.IsTenantResource = TenantDetection.IsTenantOnly(operationsGroup);
                operationsGroup.IsExtensionResource = ExtensionDetection.IsExtension(operationsGroup);
                operationsGroup.Parent = (operationsGroup.IsTenantResource || operationsGroup.IsExtensionResource) ? null : ParentDetection.GetParent(operationsGroup);
                string? resource;
                operationsGroup.Resource = _context.Configuration.OperationGroupToResource.TryGetValue(operationsGroup.Key, out resource) ? resource : SchemaDetection.GetSchema(operationsGroup).Name;
                AddOperationGroupToResourceMap(operationsGroup);
                string? nameOverride;
                if (_context.Configuration.ResourceRename.TryGetValue(operationsGroup.Resource, out nameOverride))
                {
                    operationsGroup.Resource = nameOverride;
                }
            }
            //now that resolved all operations groups to resource types above, can try solve for the parent
            foreach (var operationsGroup in _codeModel.OperationGroups)
            {
                if (operationsGroup.Parent != null && !ResourceTypes.Contains(operationsGroup.Parent))
                {
                    throw new ArgumentException($"Could not set parent for operations group {operationsGroup.ResourceType}. Please add to readme.md");
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
