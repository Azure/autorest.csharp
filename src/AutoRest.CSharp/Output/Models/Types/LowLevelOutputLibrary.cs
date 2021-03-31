// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models.Responses;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class LowLevelOutputLibrary : OutputLibrary
    {
        private readonly CodeModel _codeModel;
        private readonly BuildContext<LowLevelOutputLibrary> _context;
        private Dictionary<OperationGroup, LowLevelRestClient>? _restClients;

        public LowLevelOutputLibrary(CodeModel codeModel, BuildContext<LowLevelOutputLibrary> context) : base(codeModel, context)
        {
            _codeModel = codeModel;
            _context = context;
        }

        public IEnumerable<LowLevelRestClient> RestClients => EnsureRestClients().Values;

        private Dictionary<OperationGroup, LowLevelRestClient> EnsureRestClients()
        {
            if (_restClients != null)
            {
                return _restClients;
            }

            _restClients = new Dictionary<OperationGroup, LowLevelRestClient>();
            foreach (var operationGroup in _codeModel.OperationGroups)
            {
                _restClients.Add(operationGroup, new LowLevelRestClient(operationGroup, _context));
            }

            return _restClients;
        }

        public override CSharpType FindTypeForSchema(Schema schema)
        {
            switch (schema.Type)
            {
                case AllSchemaTypes.Choice:
                    return _context.TypeFactory.CreateType(((ChoiceSchema)schema).ChoiceType, false);
                case AllSchemaTypes.SealedChoice:
                    return _context.TypeFactory.CreateType(((SealedChoiceSchema)schema).ChoiceType, false);
                default:
                    throw new InvalidOperationException ($"FindTypeForSchema of invalid schema {schema.Name} in LowLevelOutputLibrary");
            }
        }

        public override CSharpType? FindTypeByName(string name) => null;
    }
}
