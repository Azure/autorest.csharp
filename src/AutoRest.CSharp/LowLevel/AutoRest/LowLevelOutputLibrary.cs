// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models.Responses;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class LowLevelOutputLibrary : OutputLibrary
    {
        private readonly CodeModel _codeModel;
        private readonly BuildContext<LowLevelOutputLibrary> _context;
        private CachedDictionary<OperationGroup, LowLevelRestClient> _internalRestClients;
        private CachedDictionary<OperationGroup, LowLevelDataPlaneClient> _publicClients;

        public LowLevelOutputLibrary(CodeModel codeModel, BuildContext<LowLevelOutputLibrary> context) : base(codeModel, context)
        {
            _codeModel = codeModel;
            _context = context;
            _internalRestClients = new CachedDictionary<OperationGroup, LowLevelRestClient>(EnsureRestClients);
            _publicClients = new CachedDictionary<OperationGroup, LowLevelDataPlaneClient>(EnsureClients);
        }

        public IEnumerable<LowLevelRestClient> RestClients => _internalRestClients.Values;

        public IEnumerable<LowLevelDataPlaneClient> Clients => _publicClients.Values;

        private Dictionary<OperationGroup, LowLevelRestClient> EnsureRestClients()
        {
            var restClients = new Dictionary<OperationGroup, LowLevelRestClient>();
            foreach (var operationGroup in _codeModel.OperationGroups)
            {
                restClients.Add(operationGroup, new LowLevelRestClient(operationGroup, _context));
            }

            return restClients;
        }

        private Dictionary<OperationGroup, LowLevelDataPlaneClient> EnsureClients()
        {
            var clients = new Dictionary<OperationGroup, LowLevelDataPlaneClient>();
            foreach (var operationGroup in _codeModel.OperationGroups)
            {
                clients.Add(operationGroup, new LowLevelDataPlaneClient(operationGroup, _context));
            }

            return clients;
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
                    // This is technically invalid behavior, we are hitting this in generating responses we throw away.
                    // https://github.com/Azure/autorest.csharp/issues/1108
                    // throw new InvalidOperationException($"FindTypeForSchema of invalid schema {schema.Name} in LowLevelOutputLibrary");
                    return new CSharpType(typeof(object));
            }
        }

        public override CSharpType? FindTypeByName(string originalName) => null;

        public LowLevelRestClient FindRestClient(OperationGroup operationGroup)
        {
            return _internalRestClients[operationGroup];
        }
    }
}
