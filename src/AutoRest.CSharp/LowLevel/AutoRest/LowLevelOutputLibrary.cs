// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class LowLevelOutputLibrary : OutputLibrary
    {
        private readonly CodeModel _codeModel;
        private readonly BuildContext<LowLevelOutputLibrary> _context;
        private readonly CachedDictionary<OperationGroup, LowLevelRestClient> _restClients;
        public ClientOptionsTypeProvider ClientOptions { get; }

        public LowLevelOutputLibrary(CodeModel codeModel, BuildContext<LowLevelOutputLibrary> context) : base(codeModel, context)
        {
            _codeModel = codeModel;
            _context = context;
            ClientOptions = new ClientOptionsTypeProvider(_context);
            UpdateListMethodNames();
            _restClients = new CachedDictionary<OperationGroup, LowLevelRestClient>(EnsureRestClients);
        }

        public ICollection<LowLevelRestClient> RestClients => _restClients.Values;
        private Dictionary<OperationGroup, LowLevelRestClient> EnsureRestClients()
        {
            var restClients = new Dictionary<OperationGroup, LowLevelRestClient>();

            string? topLevelClientName = null;
            if (_context.Configuration.SingleTopLevelClient)
            {
                var topLevelOperationGroup = _codeModel.OperationGroups.FirstOrDefault(og => string.IsNullOrEmpty(og.Key));
                var topLevelClient = topLevelOperationGroup != null ? new LowLevelRestClient(topLevelOperationGroup, _context, ClientOptions, null) : LowLevelRestClient.CreateEmptyTopLevelClient(_context, ClientOptions);
                restClients.Add(topLevelClient.OperationGroup, topLevelClient);
                topLevelClientName = topLevelClient.Declaration.Name;
            }

            foreach (var operationGroup in _codeModel.OperationGroups)
            {
                if (!restClients.ContainsKey(operationGroup))
                {
                    restClients.Add(operationGroup, new LowLevelRestClient(operationGroup, _context, ClientOptions, topLevelClientName));
                }
            }

            return restClients;
        }

        private void UpdateListMethodNames()
        {
            foreach (var operationGroup in _codeModel.OperationGroups)
            {
                foreach (var operation in operationGroup.Operations)
                {
                    var resourceName = operationGroup.Key.IsNullOrEmpty() ? _codeModel.Language.Default.Name.ReplaceLast("Client", "") : operationGroup.Key;
                    operation.Language.Default.Name = operation.Language.Default.Name.RenameGetMethod(resourceName).RenameListToGet(resourceName);
                }
            }
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
    }
}
