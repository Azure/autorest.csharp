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
        private readonly IReadOnlyDictionary<InputEnumType, EnumType> _enums;
        private readonly IReadOnlyDictionary<InputModelType, Func<ModelTypeProvider>> _modelFactories;

        public TypeFactory TypeFactory { get; }
        public IEnumerable<EnumType> Enums => _enums.Values;
        public IEnumerable<ModelTypeProvider> Models => _modelFactories.Values.Select(f => f());
        public IReadOnlyList<LowLevelClient> RestClients { get; }
        public ClientOptionsTypeProvider ClientOptions { get; }

        public DpgOutputLibrary(IReadOnlyDictionary<InputEnumType, EnumType> enums, IReadOnlyDictionary<InputModelType, Func<ModelTypeProvider>> modelFactories, IReadOnlyList<LowLevelClient> restClients, ClientOptionsTypeProvider clientOptions)
        {
            TypeFactory = new TypeFactory(this);
            _enums = enums;
            _modelFactories = modelFactories;
            RestClients = restClients;
            ClientOptions = clientOptions;
        }

        public override CSharpType ResolveEnum(InputEnumType enumType)
            => _enums.TryGetValue(enumType, out var typeProvider)
                ? typeProvider.Type
                : throw new InvalidOperationException($"No {nameof(EnumType)} has been created for `{enumType.Name}` {nameof(InputEnumType)}.");

        public override CSharpType ResolveModel(InputModelType model)
            => _modelFactories.TryGetValue(model, out var modelFactory) ? modelFactory().Type : new CSharpType(typeof(object), model.IsNullable);

        public override CSharpType FindTypeForSchema(Schema schema) => throw new NotImplementedException($"{nameof(FindTypeForSchema)} shouldn't be called for DPG!");

        public override CSharpType? FindTypeByName(string originalName) => null;
    }
}
