// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class DpgOutputLibrary : OutputLibrary
    {
        private readonly string _libraryName;
        private readonly IReadOnlyDictionary<InputEnumType, EnumType> _enums;
        private readonly IReadOnlyDictionary<InputModelType, ModelTypeProvider> _models;
        private readonly bool _isTspInput;
        private readonly SourceInputModel? _sourceInputModel;

        public TypeFactory TypeFactory { get; }
        public IEnumerable<EnumType> Enums => _enums.Values;
        public IEnumerable<ModelTypeProvider> Models => _models.Values;
        public IReadOnlyList<LowLevelClient> RestClients { get; }
        public ClientOptionsTypeProvider ClientOptions { get; }
        public IEnumerable<TypeProvider> AllModels => new List<TypeProvider>(_enums.Values).Concat(_models.Values);

        public DpgOutputLibrary(string libraryName, IReadOnlyDictionary<InputEnumType, EnumType> enums, IReadOnlyDictionary<InputModelType, ModelTypeProvider> models, IReadOnlyList<LowLevelClient> restClients, ClientOptionsTypeProvider clientOptions, bool isTspInput, SourceInputModel? sourceInputModel)
        {
            TypeFactory = new TypeFactory(this);
            _libraryName = libraryName;
            _enums = enums;
            _models = models;
            _isTspInput = isTspInput;
             _sourceInputModel = sourceInputModel;
            RestClients = restClients;
            ClientOptions = clientOptions;
        }

        private AspDotNetExtensionTypeProvider? _aspDotNetExtension;
        public AspDotNetExtensionTypeProvider AspDotNetExtension => _aspDotNetExtension ??= new AspDotNetExtensionTypeProvider(RestClients, Configuration.Namespace, _sourceInputModel);

        private ModelFactoryTypeProvider? _modelFactoryProvider;
        public ModelFactoryTypeProvider? ModelFactory => _modelFactoryProvider ??= ModelFactoryTypeProvider.TryCreate(ClientBuilder.GetClientPrefix(Configuration.LibraryName, _libraryName), Configuration.Namespace, AllModels, _sourceInputModel);


        public override CSharpType ResolveEnum(InputEnumType enumType)
        {
            if (!_isTspInput || enumType.Usage == InputModelTypeUsage.None)
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
            => _models.TryGetValue(model, out var modelTypeProvider) ? modelTypeProvider.Type : new CSharpType(typeof(object), model.IsNullable);

        public override CSharpType? FindTypeByName(string originalName) => Models.Where(m => m.Declaration.Name == originalName)?.Select(m => m.Type).FirstOrDefault();

        public override CSharpType FindTypeForSchema(Schema schema) => throw new NotImplementedException($"{nameof(FindTypeForSchema)} shouldn't be called for DPG!");

        public override TypeProvider FindTypeProviderForSchema(Schema schema) => throw new NotImplementedException($"{nameof(FindTypeForSchema)} shouldn't be called for DPG!");
    }
}
