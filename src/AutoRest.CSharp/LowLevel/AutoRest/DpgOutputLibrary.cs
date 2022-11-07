// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Decorator;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class DpgOutputLibrary : OutputLibrary
    {
        private readonly Dictionary<InputEnumType, EnumType> _enums;
        private readonly Dictionary<InputModelType, ObjectType> _rawModels;
        private readonly bool _isCadlInput;

        public TypeFactory TypeFactory { get; }
        public IEnumerable<EnumType> Enums => _enums.Values;

        public IEnumerable<ObjectType> Models => AllModelMap.Values;
        public IReadOnlyList<LowLevelClient> RestClients { get; }
        public ClientOptionsTypeProvider ClientOptions { get; }

        public CachedDictionary<InputModelType, ObjectType> AllModelMap { get; }

        private IEnumerable<TypeProvider>? _allModels;
        public IEnumerable<TypeProvider> AllModels => _allModels ??= new List<TypeProvider>(Enums).Concat(Models);

        public DpgOutputLibrary(Dictionary<InputEnumType, EnumType> enums, Dictionary<InputModelType, ObjectType> models, IReadOnlyList<LowLevelClient> restClients, ClientOptionsTypeProvider clientOptions, bool isCadlInput)
        {
            TypeFactory = new TypeFactory(this);
            _enums = enums;
            _rawModels = models;
            _isCadlInput = isCadlInput;
            RestClients = restClients;
            ClientOptions = clientOptions;
            AllModelMap = new CachedDictionary<InputModelType, ObjectType>(InitializeModels);
        }

        private Dictionary<InputModelType, ObjectType> InitializeModels()
        {
            var models = new Dictionary<InputModelType, ObjectType>(_rawModels);
            var replacedTypes = new Dictionary<InputModelType, ObjectType>();
            foreach (var (inputModel, objectType) in _rawModels)
            {
                if (objectType is ModelTypeProvider modelTypeProvider)
                {
                    var csharpType = TypeReferenceTypeChooser.GetExactMatch(modelTypeProvider);
                    if (csharpType != null)
                    {
                        replacedTypes.Add(inputModel, (SystemObjectType)csharpType.Implementation);
                    }
                }
            }

            // replace those filtered types
            foreach (var (inputModel, objectType) in replacedTypes)
            {
                models[inputModel] = objectType;
            }

            return models;
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
        {
            if (!AllModelMap.IsPopulated)
            {
                return _rawModels.TryGetValue(model, out var objectType) ? objectType.Type : new CSharpType(typeof(object), model.IsNullable);
            }
            else if (AllModelMap.TryGetValue(model, out var result))
            {
                return result.Type;
            }
            throw new KeyNotFoundException($"{model.Namespace}.{model.Name} was not found in model and resource schema map");
        }

        public override CSharpType FindTypeForSchema(Schema schema) => throw new NotImplementedException($"{nameof(FindTypeForSchema)} shouldn't be called for DPG!");

        public override CSharpType? FindTypeByName(string originalName) => null;
    }
}
