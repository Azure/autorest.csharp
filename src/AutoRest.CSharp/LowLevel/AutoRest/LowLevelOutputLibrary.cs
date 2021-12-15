// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
        public ClientOptionsTypeProvider ClientOptions { get; }

        public LowLevelOutputLibrary(CodeModel codeModel, BuildContext<LowLevelOutputLibrary> context)
        {
            _codeModel = codeModel;
            _context = context;
            ClientOptions = new ClientOptionsTypeProvider(_context);
            UpdateListMethodNames();
            RestClients = EnsureRestClients();
        }

        public ICollection<LowLevelClient> RestClients { get; }

        private ICollection<LowLevelClient> EnsureRestClients()
        {
            var restClients = new List<LowLevelClient>();

            string? topLevelClientName = null;
            if (_context.Configuration.SingleTopLevelClient)
            {
                var topLevelOperationGroup = _codeModel.OperationGroups.FirstOrDefault(og => string.IsNullOrEmpty(og.Key));
                LowLevelClient topLevelClient;
                if (topLevelOperationGroup != null)
                {
                    var language = topLevelOperationGroup.Language.Default;
                    var name = language.Name;
                    var description = language.Description;
                    var operations = topLevelOperationGroup.Operations;
                    topLevelClient = new LowLevelClient(name, description, null, operations, new RestClientBuilder(operations, _context), _context, ClientOptions);
                }
                else
                {
                    var endpointParameter = _context.CodeModel.GlobalParameters.FirstOrDefault(RestClientBuilder.IsEndpointParameter);
                    var clientParameters = endpointParameter != null ? new[] { endpointParameter } : Array.Empty<RequestParameter>();
                    topLevelClient = new LowLevelClient(string.Empty, string.Empty, null, Array.Empty<Operation>(), new RestClientBuilder(clientParameters, _context), _context, ClientOptions);
                }

                restClients.Add(topLevelClient);
                topLevelClientName = topLevelClient.Declaration.Name;
            }

            foreach (var operationGroup in _codeModel.OperationGroups)
            {
                if (!string.IsNullOrEmpty(operationGroup.Key))
                {
                    var language = operationGroup.Language.Default;
                    var name = language.Name;
                    var description = language.Description;
                    var operations = operationGroup.Operations;

                    restClients.Add(new LowLevelClient(name, description, topLevelClientName, operations, new RestClientBuilder(operations, _context), _context, ClientOptions));
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
