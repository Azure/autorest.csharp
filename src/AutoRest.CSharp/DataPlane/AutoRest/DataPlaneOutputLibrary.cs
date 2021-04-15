// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Responses;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class DataPlaneOutputLibrary : OutputLibrary
    {
        private CachedDictionary<OperationGroup, DataPlaneRestClient> _restClients;
        private CachedDictionary<OperationGroup, DataPlaneClient> _clients;
        private CachedDictionary<Operation, DataPlaneLongRunningOperation> _operations;
        private CachedDictionary<Operation, DataPlaneResponseHeaderGroupType> _headerModels;
        private CachedDictionary<Schema, TypeProvider> _models;
        private BuildContext<DataPlaneOutputLibrary> _context;
        private CodeModel _codeModel;

        public DataPlaneOutputLibrary(CodeModel codeModel, BuildContext<DataPlaneOutputLibrary> context) : base(codeModel, context)
        {
            _context = context;
            _codeModel = codeModel;

            _restClients = new CachedDictionary<OperationGroup, DataPlaneRestClient> (EnsureRestClients);
            _clients = new CachedDictionary<OperationGroup, DataPlaneClient>(EnsureClients);
            _operations = new CachedDictionary<Operation, DataPlaneLongRunningOperation>(EnsureLongRunningOperations);
            _headerModels = new CachedDictionary<Operation, DataPlaneResponseHeaderGroupType>(EnsureHeaderModels);
            _models = new CachedDictionary<Schema, TypeProvider> (BuildModels);
        }

        public IEnumerable<DataPlaneClient> Clients => _clients.Values;
        public IEnumerable<DataPlaneLongRunningOperation> LongRunningOperations => _operations.Values;
        public IEnumerable<DataPlaneResponseHeaderGroupType> HeaderModels => _headerModels.Values;
        internal CachedDictionary<Schema, TypeProvider> SchemaMap => _models;
        public IEnumerable<TypeProvider> Models => SchemaMap.Values;

        public override CSharpType FindTypeForSchema(Schema schema)
        {
            return SchemaMap[schema].Type;
        }

        public override CSharpType? FindTypeByName(string originalName)
        {
            foreach (var model in Models)
            {
                if (originalName == model.Type.Name)
                {
                    return model.Type;
                }
            }
            return null;
        }

        protected virtual Dictionary<Schema, TypeProvider> BuildModels()
        {
            var allSchemas = _codeModel.Schemas.Choices.Cast<Schema>()
                .Concat(_codeModel.Schemas.SealedChoices)
                .Concat(_codeModel.Schemas.Objects)
                .Concat(_codeModel.Schemas.Groups);

            return allSchemas.ToDictionary(schema => schema, BuildModel);
        }

        private TypeProvider BuildModel(Schema schema) => schema switch
        {
            SealedChoiceSchema sealedChoiceSchema => (TypeProvider)new EnumType(sealedChoiceSchema, _context),
            ChoiceSchema choiceSchema => new EnumType(choiceSchema, _context),
            ObjectSchema objectSchema => new ObjectType(objectSchema, _context),
            _ => throw new NotImplementedException()
        };

        public DataPlaneLongRunningOperation FindLongRunningOperation(Operation operation)
        {
            Debug.Assert(operation.IsLongRunning);

            return _operations[operation];
        }

        public DataPlaneClient? FindClient(OperationGroup operationGroup)
        {
            _clients.TryGetValue(operationGroup, out var client);
            return client;
        }

        public DataPlaneResponseHeaderGroupType? FindHeaderModel(Operation operation)
        {
            _headerModels.TryGetValue(operation, out var model);
            return model;
        }

        public IEnumerable<DataPlaneRestClient> RestClients => _restClients.Values;

        public DataPlaneRestClient FindRestClient(OperationGroup operationGroup)
        {
            return _restClients[operationGroup];
        }

        private Dictionary<Operation, DataPlaneResponseHeaderGroupType> EnsureHeaderModels()
        {
            var headerModels = new Dictionary<Operation, DataPlaneResponseHeaderGroupType>();
            foreach (var operationGroup in _codeModel.OperationGroups)
            {
                foreach (var operation in operationGroup.Operations)
                {
                    var headers = DataPlaneResponseHeaderGroupType.TryCreate(operationGroup, operation, _context);
                    if (headers != null)
                    {
                        headerModels.Add(operation, headers);
                    }
                }
            }

            return headerModels;
        }

        private Dictionary<Operation, DataPlaneLongRunningOperation> EnsureLongRunningOperations()
        {
            var operations = new Dictionary<Operation, DataPlaneLongRunningOperation>();

            if (_context.Configuration.PublicClients)
            {
                foreach (var operationGroup in _codeModel.OperationGroups)
                {
                    foreach (var operation in operationGroup.Operations)
                    {
                        if (operation.IsLongRunning)
                        {
                            operations.Add(operation, new DataPlaneLongRunningOperation(operationGroup, operation, _context));
                        }
                    }
                }
            }

            return operations;
        }

        private Dictionary<OperationGroup, DataPlaneClient> EnsureClients()
        {
            var clients = new Dictionary<OperationGroup, DataPlaneClient>();

            if (_context.Configuration.PublicClients)
            {
                foreach (var operationGroup in _codeModel.OperationGroups)
                {
                    clients.Add(operationGroup, new DataPlaneClient(operationGroup, _context));
                }
            }

            return clients;
        }

        private Dictionary<OperationGroup, DataPlaneRestClient> EnsureRestClients()
        {
            var restClients = new Dictionary<OperationGroup, DataPlaneRestClient>();
            foreach (var operationGroup in _codeModel.OperationGroups)
            {
                restClients.Add(operationGroup, new DataPlaneRestClient(operationGroup, _context));
            }

            return restClients;
        }
    }
}
