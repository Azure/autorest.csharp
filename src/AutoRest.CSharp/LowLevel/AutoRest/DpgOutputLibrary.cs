// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class DpgOutputLibrary : OutputLibrary
    {
        private readonly Dictionary<InputEnumType, EnumType> _enums;
        private readonly Dictionary<InputModelType, ObjectType> _models;
        private readonly bool _isCadlInput;

        public TypeFactory TypeFactory { get; }
        public IEnumerable<EnumType> Enums => _enums.Values;
        public IEnumerable<ObjectType> Models => _models.Values;
        public IReadOnlyList<LowLevelClient> RestClients { get; }
        public ClientOptionsTypeProvider ClientOptions { get; }

        private IEnumerable<TypeProvider>? _allModels;
        public IEnumerable<TypeProvider> AllModels => _allModels ??= new List<TypeProvider>(_enums.Values).Concat(_models.Values);

        public DpgOutputLibrary(Dictionary<InputEnumType, EnumType> enums, Dictionary<InputModelType, ObjectType> models, IReadOnlyList<LowLevelClient> restClients, ClientOptionsTypeProvider clientOptions, bool isCadlInput)
        {
            TypeFactory = new TypeFactory(this);
            _enums = enums;
            _models = models;
            _isCadlInput = isCadlInput;
            RestClients = restClients;
            ClientOptions = clientOptions;
        }

        public override CSharpType ResolveEnum(InputEnumType enumType)
        {
            if (!_isCadlInput)
            {
                return TypeFactory.CreateType(enumType.EnumValueType);
            }

            if (_enums.TryGetValue(enumType, out var typeProvider))
            {
                return typeProvider.Type;
            }

            throw new InvalidOperationException($"No {nameof(EnumType)} has been created for `{enumType.Name}` {nameof(InputEnumType)}.");
        }

        public override CSharpType ResolveModel(InputModelType model)
            => _models.TryGetValue(model, out var modelFactory) ? modelFactory.Type : new CSharpType(typeof(object), model.IsNullable);

        public override CSharpType FindTypeForSchema(Schema schema) => throw new NotImplementedException($"{nameof(FindTypeForSchema)} shouldn't be called for DPG!");

        public override CSharpType? FindTypeByName(string originalName) => null;
    }
}
