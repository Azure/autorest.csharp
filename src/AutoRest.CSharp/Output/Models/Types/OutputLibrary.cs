// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Responses;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal abstract class OutputLibrary
    {
        protected readonly CodeModel _codeModel;
        protected readonly BuildContext _context;
        private Dictionary<Schema, TypeProvider>? _models;

        protected OutputLibrary (CodeModel codeModel, BuildContext context)
        {
            _codeModel = codeModel;
            _context = context;
        }

        public virtual IEnumerable<Client> Clients => Enumerable.Empty<Client>();
        public virtual IEnumerable<LongRunningOperation> LongRunningOperations => Enumerable.Empty<LongRunningOperation>();
        public virtual IEnumerable<ResponseHeaderGroupType> HeaderModels => Enumerable.Empty<ResponseHeaderGroupType>();

        public virtual LongRunningOperation? FindLongRunningOperation(Operation operation) => null;
        public virtual Client? FindClient(OperationGroup operationGroup) => null;
        public virtual ResponseHeaderGroupType? FindHeaderModel(Operation operation) => null;

        protected Dictionary<Schema, TypeProvider> SchemaMap => _models ??= BuildModels();
        public IEnumerable<TypeProvider> Models => SchemaMap.Values;

        public TypeProvider FindTypeForSchema(Schema schema)
        {
            return SchemaMap[schema];
        }

        protected Dictionary<Schema, TypeProvider> BuildModels()
        {
            var allSchemas = _codeModel.Schemas.Choices.Cast<Schema>()
                .Concat(_codeModel.Schemas.SealedChoices)
                .Concat(_codeModel.Schemas.Objects)
                .Concat(_codeModel.Schemas.Groups);

            return allSchemas.ToDictionary(schema => schema, BuildModel);
        }

        protected TypeProvider BuildModel(Schema schema) => schema switch
        {
            SealedChoiceSchema sealedChoiceSchema => (TypeProvider)new EnumType(sealedChoiceSchema, _context),
            ChoiceSchema choiceSchema => new EnumType(choiceSchema, _context),
            ObjectSchema objectSchema => new ObjectType(objectSchema, _context),
            _ => throw new NotImplementedException()
        };

        public IEnumerable<RestClient> RestClients => EnsureRestClients().Values;

        protected abstract Dictionary<OperationGroup, RestClient> EnsureRestClients();

        public RestClient FindRestClient(OperationGroup operationGroup)
        {
            return EnsureRestClients()[operationGroup];
        }
    }
}
