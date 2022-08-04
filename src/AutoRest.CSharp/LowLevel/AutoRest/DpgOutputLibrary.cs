// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class DpgOutputLibrary : OutputLibrary
    {
        private readonly IReadOnlyDictionary<InputEnumType, EnumType> _enums;
        private readonly IReadOnlyDictionary<InputModelType, ModelTypeProvider> _models;
        private readonly TypeFactory _typeFactory;

        public IEnumerable<EnumType> Enums => _enums.Values;
        public IEnumerable<ModelTypeProvider> Models => _models.Values;
        public IReadOnlyList<LowLevelClient> RestClients { get; }
        public ClientOptionsTypeProvider ClientOptions { get; }

        public DpgOutputLibrary(Func<TypeFactory, IReadOnlyDictionary<InputEnumType, EnumType>> enumsFactory, Func<TypeFactory, IReadOnlyDictionary<InputModelType, ModelTypeProvider>> modelsFactory, Func<TypeFactory, IReadOnlyList<LowLevelClient>> restClientsFactory, ClientOptionsTypeProvider clientOptions)
        {
            _typeFactory = new TypeFactory(this);
            _enums = enumsFactory(_typeFactory);
            _models = modelsFactory(_typeFactory);
            RestClients = restClientsFactory(_typeFactory);
            ClientOptions = clientOptions;
        }

        public override CSharpType ResolveEnum(InputEnumType enumType) => _enums != null
            ? _enums.TryGetValue(enumType with {IsNullable = false}, out var typeProvider) ? typeProvider.Type : _typeFactory.CreateType(enumType.EnumValueType)
            : throw new InvalidOperationException($"{nameof(ResolveEnum)} is called before enums are generated.");
        public override CSharpType ResolveModel(InputModelType model) => _models != null
            ? _models.TryGetValue(model, out var typeProvider) ? typeProvider.Type : new CSharpType(typeof(object), model.IsNullable)
            : throw new InvalidOperationException($"{nameof(ResolveModel)} is called before models are generated.");

        public override CSharpType FindTypeForSchema(Schema schema) => throw new NotImplementedException($"{nameof(FindTypeForSchema)} shouldn't be called for DPG!");

        public override CSharpType? FindTypeByName(string originalName) => null;
    }
}
