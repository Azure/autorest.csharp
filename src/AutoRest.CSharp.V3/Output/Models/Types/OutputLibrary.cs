// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoRest.CSharp.V3.Input;
using AutoRest.CSharp.V3.Output.Builders;
using AutoRest.CSharp.V3.Output.Models.Requests;

namespace AutoRest.CSharp.V3.Output.Models.Types
{
    internal class OutputLibrary
    {
        private readonly CodeModel _codeModel;
        private readonly BuildContext _context;
        private Dictionary<Schema, ISchemaType>? _models;
        private Dictionary<OperationGroup, Client>? _clients;
        private Dictionary<OperationGroup, RestClient>? _restClients;
        private LongRunningOperation[]? _operations;

        public OutputLibrary(CodeModel codeModel, BuildContext context)
        {
            _codeModel = codeModel;
            _context = context;
        }

        public IEnumerable<ISchemaType> Models => SchemaMap.Values;

        public IEnumerable<RestClient> RestClients
        {
            get
            {
                EnsureClients();
                return _restClients!.Values;
            }
        }

        public IEnumerable<Client> Clients
        {
            get
            {
                EnsureClients();
                return _clients!.Values;
            }
        }

        public IEnumerable<LongRunningOperation> LongRunningOperations
        {
            get
            {
                return _operations ??= BuildLongRunningOperations().ToArray();
            }
        }

        private IEnumerable<LongRunningOperation> BuildLongRunningOperations()
        {
            foreach (var operationGroup in _codeModel.OperationGroups)
            {
                foreach (var operation in operationGroup.Operations)
                {
                    if (operation.IsLongRunning)
                    {
                        yield return new LongRunningOperation(operationGroup, operation, _context);
                    }
                }
            }
        }

        public ISchemaType FindTypeForSchema(Schema schema)
        {
            return SchemaMap[schema];
        }

        private Dictionary<Schema, ISchemaType> SchemaMap => _models ??= BuildModels();

        private void EnsureClients()
        {
            var clientBuilder = new ClientBuilder(_context);

            var allClients = _codeModel.OperationGroups.ToDictionary(og => og, clientBuilder.BuildClient);

            _clients = allClients.ToDictionary(c => c.Key, c=> c.Value.Client);
            _restClients = allClients.ToDictionary(c => c.Key, c=> c.Value.RestClient);
        }

        private Dictionary<Schema, ISchemaType> BuildModels()
        {
            var allSchemas = _codeModel.Schemas.Choices.Cast<Schema>()
                .Concat(_codeModel.Schemas.SealedChoices)
                .Concat(_codeModel.Schemas.Objects)
                .Concat(_codeModel.Schemas.Groups);

            return allSchemas.ToDictionary(schema => schema, BuildModel);
        }

        private ISchemaType BuildModel(Schema schema) => schema switch
        {
            SealedChoiceSchema sealedChoiceSchema => (ISchemaType)new EnumType(sealedChoiceSchema, _context),
            ChoiceSchema choiceSchema => new EnumType(choiceSchema, _context),
            ObjectSchema objectSchema => new ObjectType(objectSchema, _context),
            _ => throw new NotImplementedException()
        };

        public LongRunningOperation FindLongRunningOperation(Operation operation)
        {
            Debug.Assert(operation.IsLongRunning);

            return LongRunningOperations.Single(lro => lro.Operation == operation);
        }

        public Client FindClient(OperationGroup operationGroup)
        {
            EnsureClients();
            return _clients![operationGroup];
        }
    }
}
