// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class LowLevelOutputLibrary : OutputLibrary
    {
        private readonly TypeFactory _typeFactory;
        public IReadOnlyList<LowLevelClient> RestClients { get; }
        public ClientOptionsTypeProvider ClientOptions { get; }

        public LowLevelOutputLibrary(Func<TypeFactory, IReadOnlyList<LowLevelClient>> restClientsFactory, ClientOptionsTypeProvider clientOptions)
        {
            _typeFactory = new TypeFactory(this);
            RestClients = restClientsFactory(_typeFactory);
            ClientOptions = clientOptions;
        }

        public override CSharpType FindTypeForSchema(Schema schema)
            => schema.Type switch
            {
                AllSchemaTypes.Choice => _typeFactory.CreateType(((ChoiceSchema)schema).ChoiceType, false),
                AllSchemaTypes.SealedChoice => _typeFactory.CreateType(((SealedChoiceSchema)schema).ChoiceType, false),
                // This is technically invalid behavior, we are hitting this in generating responses we throw away.
                // https://github.com/Azure/autorest.csharp/issues/1108
                // throw new InvalidOperationException($"FindTypeForSchema of invalid schema {schema.Name} in LowLevelOutputLibrary");
                _ => new CSharpType(typeof(object))
            };

        public override CSharpType? FindTypeByName(string originalName) => null;
    }
}
