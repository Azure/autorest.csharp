// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Output.Builders;
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
            RestClients = LowLevelClientHierarchyResolver.BuildClientHierarchy(_codeModel.OperationGroups, _context, ClientOptions);
        }

        public IReadOnlyList<LowLevelClient> RestClients { get; }

        private void UpdateListMethodNames()
        {
            var defaultName = _codeModel.Language.Default.Name.ReplaceLast("Client", "");
            foreach (var operationGroup in _codeModel.OperationGroups)
            {
                foreach (var operation in operationGroup.Operations)
                {
                    var resourceName = operationGroup.Key.IsNullOrEmpty() ? defaultName : operationGroup.Key;
                    operation.Language.Default.Name = operation.Language.Default.Name.RenameGetMethod(resourceName).RenameListToGet(resourceName);
                }
            }
        }

        public override CSharpType FindTypeForSchema(Schema schema)
            => schema.Type switch
            {
                AllSchemaTypes.Choice => _context.TypeFactory.CreateType(((ChoiceSchema)schema).ChoiceType, false),
                AllSchemaTypes.SealedChoice => _context.TypeFactory.CreateType(((SealedChoiceSchema)schema).ChoiceType, false),
                // This is technically invalid behavior, we are hitting this in generating responses we throw away.
                // https://github.com/Azure/autorest.csharp/issues/1108
                // throw new InvalidOperationException($"FindTypeForSchema of invalid schema {schema.Name} in LowLevelOutputLibrary");
                _ => new CSharpType(typeof(object))
            };

        public override CSharpType? FindTypeByName(string originalName) => null;
    }
}
