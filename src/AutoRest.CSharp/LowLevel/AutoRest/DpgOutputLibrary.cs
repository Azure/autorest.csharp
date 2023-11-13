// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Input.Examples;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Builders;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class DpgOutputLibrary : OutputLibrary
    {
        private readonly IReadOnlyDictionary<InputEnumType, EnumType> _enums;
        private readonly IReadOnlyDictionary<InputModelType, ModelTypeProvider> _models;
        private readonly IReadOnlyList<TypeProvider> _privateAllModels;
        private readonly bool _isTspInput;

        public TypeFactory TypeFactory { get; }
        public IEnumerable<EnumType> Enums => _enums.Values;
        public IEnumerable<ModelTypeProvider> Models => _models.Values;
        public IReadOnlyList<DpgClient> RestClients { get; }
        public ClientOptionsTypeProvider ClientOptions { get; }
        public IEnumerable<TypeProvider> AllModels { get; }
        public ModelFactoryTypeProvider? ModelFactory { get; }
        public AspDotNetExtensionTypeProvider AspDotNetExtension { get; }
        public IReadOnlyList<string> AccessOverriddenModels { get; }

        public DpgOutputLibrary(InputNamespace rootNamespace, IReadOnlyList<DpgOutputLibraryBuilder.ClientInfo> topLevelClientInfos, ClientOptionsTypeProvider clientOptions, bool isTspInput, SourceInputModel? sourceInputModel)
        {
            TypeFactory = new TypeFactory(this);

            var defaultNamespace = Configuration.Namespace;
            var libraryName = Configuration.LibraryName;
            var defaultModelNamespace = TypeProvider.GetDefaultModelNamespace(null, defaultNamespace);

            _enums = CreateEnums(rootNamespace.Enums, defaultModelNamespace, TypeFactory, sourceInputModel);
            _models = CreateModels(rootNamespace.Models, defaultModelNamespace, TypeFactory, sourceInputModel);

            var allModels = new List<TypeProvider>(_enums.Values);
            allModels.AddRange(_models.Values);
            _privateAllModels = allModels;

            _isTspInput = isTspInput;
            AllModels = _isTspInput ? allModels : Array.Empty<TypeProvider>();
            RestClients = CreateClients(topLevelClientInfos, clientOptions, rootNamespace, TypeFactory, libraryName, sourceInputModel);
            ClientOptions = clientOptions;
            ModelFactory = ModelFactoryTypeProvider.TryCreate(AllModels, TypeFactory, sourceInputModel);
            AspDotNetExtension = new AspDotNetExtensionTypeProvider(RestClients, Configuration.Namespace, sourceInputModel);
            AccessOverriddenModels = _isTspInput
                ? _enums.Where(e => e.Key.Accessibility is not null).Select(e => e.Value.Declaration.Name)
                    .Concat(_models.Where(m => m.Key.Accessibility is not null).Select(e => e.Value.Declaration.Name))
                    .ToList()
                : Array.Empty<string>();
        }

        public override CSharpType ResolveEnum(InputEnumType enumType)
        {
            // [TODO] In swagger-based DPG, ambiguity between protocol and convenience method signatures check is dependent on `ResolveEnum` returning EnumValueType instead of enum itself
            if (!_isTspInput || enumType.Usage == InputModelTypeUsage.None)
            {
                return TypeFactory.CreateType(enumType.EnumValueType);
            }

            if (_enums.TryGetValue(enumType with {IsNullable = false}, out var typeProvider))
            {
                return typeProvider.Type.WithNullable(enumType.IsNullable);
            }

            throw new InvalidOperationException($"No {nameof(EnumType)} has been created for `{enumType.Name}` {nameof(InputEnumType)}.");
        }

        public override CSharpType ResolveModel(InputModelType model)
            => _models.TryGetValue(model with {IsNullable = false}, out var modelTypeProvider) ? modelTypeProvider.Type.WithNullable(model.IsNullable) : new CSharpType(typeof(object), model.IsNullable);

        public override CSharpType? FindTypeByName(string originalName) => _privateAllModels.FirstOrDefault(m => m.Declaration.Name == originalName)?.Type;

        public override TypeProvider FindTypeProviderForInputType(InputType inputType) => throw new NotImplementedException($"{nameof(FindTypeProviderForInputType)} shouldn't be called for DPG!");

        public static IReadOnlyDictionary<InputEnumType, EnumType> CreateEnums(IReadOnlyList<InputEnumType> inputEnums, string defaultNamespace, TypeFactory typeFactory, SourceInputModel? sourceInputModel)
            => inputEnums.ToDictionary(e => e, e => new EnumType(e, defaultNamespace, "public", typeFactory, sourceInputModel), InputEnumType.IgnoreNullabilityComparer);

        public static IReadOnlyDictionary<InputModelType, ModelTypeProvider> CreateModels(IReadOnlyList<InputModelType> inputModels, string defaultNamespace, TypeFactory typeFactory, SourceInputModel? sourceInputModel)
        {
            var models = new Dictionary<InputModelType, ModelTypeProvider>();
            var defaultDerivedTypes = new Dictionary<string, ModelTypeProvider>();
            foreach (var model in inputModels)
            {
                ModelTypeProvider? defaultDerivedType = GetDefaultDerivedType(models, defaultNamespace, typeFactory, model, defaultDerivedTypes, sourceInputModel);
                models.Add(model, new ModelTypeProvider(model, defaultNamespace, sourceInputModel, typeFactory, defaultDerivedType));
            }

            return models;
        }

        private static ModelTypeProvider? GetDefaultDerivedType(IDictionary<InputModelType, ModelTypeProvider> models, string defaultNamespace, TypeFactory typeFactory, InputModelType model, Dictionary<string, ModelTypeProvider> defaultDerivedTypes, SourceInputModel? sourceInputModel)
        {
            //only want to create one instance of the default derived per polymorphic set
            bool isBasePolyType = model.DiscriminatorPropertyName is not null;
            bool isChildPolyType = model.DiscriminatorValue is not null;
            if (!isBasePolyType && !isChildPolyType)
            {
                return null;
            }

            var actualBase = model;
            while (actualBase.BaseModel?.DiscriminatorPropertyName is not null)
            {
                actualBase = actualBase.BaseModel;
            }

            //We don't need to create default type if its an input only model
            if (!actualBase.Usage.HasFlag(InputModelTypeUsage.Output))
                return null;

            string defaultDerivedName = $"Unknown{actualBase.Name}";
            if (!defaultDerivedTypes.TryGetValue(defaultDerivedName, out ModelTypeProvider? defaultDerivedType))
            {
                //create the "Unknown" version
                var unknownDerivedType = new InputModelType(
                    defaultDerivedName,
                    actualBase.Namespace,
                    "internal",
                    null,
                    // [TODO]: Condition is added to minimize change
                    Configuration.Generation1ConvenienceClient ? $"The {defaultDerivedName}" : $"Unknown version of {actualBase.Name}",
                    Configuration.Generation1ConvenienceClient ? actualBase.Usage : InputModelTypeUsage.Output,
                    Array.Empty<InputModelProperty>(),
                    actualBase,
                    Array.Empty<InputModelType>(),
                    "Unknown", //TODO: do we need to support extensible enum / int values?
                    null,
                    null,
                    false)
                {
                    IsUnknownDiscriminatorModel = true
                };

                defaultDerivedType = new ModelTypeProvider(unknownDerivedType, defaultNamespace, sourceInputModel, typeFactory);
                defaultDerivedTypes.Add(defaultDerivedName, defaultDerivedType);
                models.Add(unknownDerivedType, defaultDerivedType);
            }

            return defaultDerivedType;
        }

        private static IReadOnlyList<DpgClient> CreateClients(IEnumerable<DpgOutputLibraryBuilder.ClientInfo> topLevelClientInfos, ClientOptionsTypeProvider clientOptions, InputNamespace rootNamespace, TypeFactory typeFactory, string libraryName, SourceInputModel? sourceInputModel)
        {
            var topLevelClients = CreateClients(topLevelClientInfos, clientOptions, null, rootNamespace, typeFactory, libraryName, sourceInputModel);
            var allClients = new List<DpgClient>();

            // Simple implementation of breadth first traversal
            allClients.AddRange(topLevelClients);
            for (int i = 0; i < allClients.Count; i++)
            {
                allClients.AddRange(allClients[i].SubClients);
            }

            return allClients;
        }

        private static IEnumerable<DpgClient> CreateClients(IEnumerable<DpgOutputLibraryBuilder.ClientInfo> clientInfos, ClientOptionsTypeProvider clientOptions, DpgClient? parentClient, InputNamespace rootNamespace, TypeFactory typeFactory, string libraryName, SourceInputModel? sourceInputModel)
        {
            foreach (var clientInfo in clientInfos)
            {
                var description = string.IsNullOrWhiteSpace(clientInfo.Description)
                    ? $"The {ClientBuilder.GetClientPrefix(clientInfo.Name, rootNamespace.Name)} {(parentClient == null ? "service client" : "sub-client")}."
                    : BuilderHelpers.EscapeXmlDocDescription(clientInfo.Description);

                var subClients = new List<DpgClient>();
                var clientParameters = clientInfo.ClientParameters
                    .Select(p => RestClientBuilder.BuildConstructorParameter(p, typeFactory))
                    .OrderBy(p => p.IsOptionalInSignature)
                    .ToList();

                var client = new DpgClient(
                    clientInfo.Name,
                    clientInfo.Namespace,
                    clientInfo.OperationGroupKey,
                    description,
                    libraryName,
                    parentClient,
                    clientInfo.Requests,
                    clientParameters,
                    clientInfo.Examples,
                    rootNamespace.Auth,
                    sourceInputModel,
                    clientOptions,
                    typeFactory)
                {
                    SubClients = subClients
                };

                subClients.AddRange(CreateClients(clientInfo.Children, clientOptions, client, rootNamespace, typeFactory, libraryName, sourceInputModel));

                yield return client;
            }
        }
    }
}
