// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoRest.CSharp.Common.Decorator;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Responses;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;
using Microsoft.CodeAnalysis.CSharp;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class DataPlaneOutputLibrary : OutputLibrary
    {
        private CachedDictionary<InputClient, RestClient> _restClients;
        private CachedDictionary<InputClient, DataPlaneClient> _clients;
        private CachedDictionary<InputOperation, LongRunningOperation> _operations;
        private CachedDictionary<InputOperation, DataPlaneResponseHeaderGroupType> _headerModels;
        private IReadOnlyDictionary<InputEnumType, EnumType> _enums;
        private IReadOnlyDictionary<InputModelType, ModelTypeProvider> _models;
        private CachedDictionary<string, List<string>> _protocolMethodsDictionary;

        private readonly InputNamespace _input;
        private readonly SourceInputModel? _sourceInputModel;
        private readonly Lazy<ModelFactoryTypeProvider?> _modelFactory;
        private readonly string _defaultName;
        private readonly string _defaultNamespace;
        private readonly string _libraryName;
        private readonly TypeFactory _typeFactory;

        public DataPlaneOutputLibrary(CodeModel codeModel, SourceInputModel? sourceInputModel)
        {
            var schemaUsageProvider = new SchemaUsageProvider(codeModel);
            SchemaUsageTransformer.Transform(codeModel);
            ConstantSchemaTransformer.Transform(codeModel);

            _typeFactory = new TypeFactory(this);
            _sourceInputModel = sourceInputModel;
            // // schema usage transformer must run first
            _input = new CodeModelConverter(codeModel, schemaUsageProvider).CreateNamespace();

            _defaultName = _input.Name;
            _defaultNamespace = Configuration.Namespace;
            _libraryName = Configuration.LibraryName;

            var defaultModelNamespace = TypeProvider.GetDefaultModelNamespace(null, _defaultNamespace);
            _enums = DpgOutputLibrary.CreateEnums(_input.Enums, defaultModelNamespace, _typeFactory, sourceInputModel);
            _models = DpgOutputLibrary.CreateModels(_input.Models, defaultModelNamespace, _typeFactory, sourceInputModel);

            var allModels = new List<TypeProvider>(_enums.Values);
            allModels.AddRange(_models.Values);
            Models = allModels;

            _restClients = new CachedDictionary<InputClient, RestClient>(EnsureRestClients);
            _clients = new CachedDictionary<InputClient, DataPlaneClient>(EnsureClients);
            _operations = new CachedDictionary<InputOperation, LongRunningOperation>(EnsureLongRunningOperations);
            _headerModels = new CachedDictionary<InputOperation, DataPlaneResponseHeaderGroupType>(EnsureHeaderModels);
            _modelFactory = new Lazy<ModelFactoryTypeProvider?>(() => ModelFactoryTypeProvider.TryCreate(Models, _sourceInputModel));
            _protocolMethodsDictionary = new CachedDictionary<string, List<string>>(GetProtocolMethodsDictionary);

            ClientOptions = CreateClientOptions();
            Authentication = _input.Auth;
        }

        private ClientOptionsTypeProvider? CreateClientOptions()
        {
            if (!Configuration.PublicClients || !_input.Clients.Any())
            {
                return null;
            }

            var clientPrefix = ClientBuilder.GetClientPrefix(_libraryName, _input.Name);
            return new ClientOptionsTypeProvider(_sourceInputModel?.GetServiceVersionOverrides() ?? _input.ApiVersions, $"{clientPrefix}ClientOptions", _defaultNamespace, $"Client options for {clientPrefix}Client.", _sourceInputModel);
        }

        public ModelFactoryTypeProvider? ModelFactory => _modelFactory.Value;
        public ClientOptionsTypeProvider? ClientOptions { get; }
        public InputAuth Authentication { get; }
        public IEnumerable<DataPlaneClient> Clients => _clients.Values;
        public IEnumerable<LongRunningOperation> LongRunningOperations => _operations.Values;
        public IEnumerable<DataPlaneResponseHeaderGroupType> HeaderModels => _headerModels.Values;
        public IEnumerable<TypeProvider> Models { get; }

        public IDictionary<string, List<string>> ProtocolMethodsDictionary => _protocolMethodsDictionary;

        public override CSharpType ResolveEnum(InputEnumType enumType)
            => _enums.TryGetValue(enumType with {IsNullable = false}, out var typeProvider)
                ? typeProvider.Type.WithNullable(enumType.IsNullable)
                : throw new InvalidOperationException($"No {nameof(EnumType)} has been created for `{enumType.Name}` {nameof(InputEnumType)}.");

        public override CSharpType ResolveModel(InputModelType model)
            => _models.TryGetValue(model with {IsNullable = false}, out var modelTypeProvider)
                ? modelTypeProvider.Type.WithNullable(model.IsNullable)
                : new CSharpType(typeof(object), model.IsNullable);

        public override TypeProvider FindTypeProviderForInputType(InputType inputType) => throw new NotImplementedException($"{nameof(FindTypeProviderForInputType)} shouldn't be called for HLC!");

        public override CSharpType? FindTypeByName(string originalName) => Models.Where(m => m.Declaration.Name == originalName)?.Select(m => m.Type).FirstOrDefault();

        public LongRunningOperation? FindLongRunningOperation(InputOperation operation)
            => operation.LongRunning is not null && Configuration.PublicClients ? _operations[operation] : null;

        public DataPlaneResponseHeaderGroupType? FindHeaderModel(InputOperation operation)
        {
            _headerModels.TryGetValue(operation, out var model);
            return model;
        }

        public IEnumerable<RestClient> RestClients => _restClients.Values;

        private Dictionary<InputOperation, DataPlaneResponseHeaderGroupType> EnsureHeaderModels()
        {
            var headerModels = new Dictionary<InputOperation, DataPlaneResponseHeaderGroupType>();
            foreach (var inputClient in _input.Clients)
            {
                var clientName = GetClientName(inputClient);
                var clientPrefix = ClientBuilder.GetClientPrefix(clientName, _defaultName);
                foreach (var operation in inputClient.Operations)
                {
                    var headers = DataPlaneResponseHeaderGroupType.TryCreate(operation, _typeFactory, clientPrefix, _defaultNamespace, _sourceInputModel);
                    if (headers != null)
                    {
                        headerModels.Add(operation, headers);
                    }
                }
            }

            return headerModels;
        }

        private Dictionary<InputOperation, LongRunningOperation> EnsureLongRunningOperations()
        {
            var operations = new Dictionary<InputOperation, LongRunningOperation>();
            if (!Configuration.PublicClients)
            {
                return operations;
            }

            foreach (var inputClient in _input.Clients)
            {
                var clientName = GetClientName(inputClient);
                var clientPrefix = ClientBuilder.GetClientPrefix(clientName, _defaultName);

                foreach (var operation in inputClient.Operations)
                {
                    if (operation.LongRunning is null)
                    {
                        continue;
                    }

                    var existingType = _sourceInputModel?.FindForType(_defaultNamespace, clientName);
                    var accessibility = existingType is not null
                        ? SyntaxFacts.GetText(existingType.DeclaredAccessibility)
                        : "public";

                    operations.Add(operation, new LongRunningOperation(operation, _typeFactory, accessibility, clientPrefix, _defaultNamespace, _sourceInputModel));
                }
            }

            return operations;
        }

        private Dictionary<InputClient, DataPlaneClient> EnsureClients()
        {
            var clients = new Dictionary<InputClient, DataPlaneClient>();

            if (Configuration.PublicClients)
            {
                foreach (var inputClient in _input.Clients)
                {
                    clients.Add(inputClient, new DataPlaneClient(inputClient, _restClients[inputClient], _defaultName, _defaultNamespace, this, _sourceInputModel));
                }
            }

            return clients;
        }

        private Dictionary<InputClient, RestClient> EnsureRestClients()
        {
            var restClients = new Dictionary<InputClient, RestClient>();
            foreach (var inputClient in _input.Clients)
            {
                var clientParameters = RestClientBuilder.GetParametersFromOperations(inputClient.Operations)
                    .Select(p => RestClientBuilder.BuildConstructorParameter(p, _typeFactory))
                    .OrderBy(p => p.IsOptionalInSignature)
                    .ToList();

                var restClientParameters = new[]{ KnownParameters.ClientDiagnostics, KnownParameters.Pipeline }.Union(clientParameters).ToList();
                var clientName = GetClientName(inputClient);
                var clientMethodsBuilder = new ClientMethodsBuilder(inputClient.Operations, this, _sourceInputModel, _typeFactory);
                restClients.Add(inputClient, new RestClient(clientMethodsBuilder, clientParameters, restClientParameters, clientName, _defaultNamespace, inputClient.Key, _sourceInputModel));
            }

            return restClients;
        }

        // Get a Dictionary<operationGroupName, List<methodNames>> based on the "protocol-method-list" config
        private static Dictionary<string, List<string>> GetProtocolMethodsDictionary()
        {
            Dictionary<string, List<string>> protocolMethodsDictionary = new();
            foreach (var operationId in Configuration.ProtocolMethodList)
            {
                var operationGroupKeyAndIdArr = operationId.Split('_');

                // If "operationGroup_operationId" passed in the config
                if (operationGroupKeyAndIdArr.Length > 1)
                {
                    var operationGroupKey = operationGroupKeyAndIdArr[0];
                    var methodName = operationGroupKeyAndIdArr[1];
                    AddToProtocolMethodsDictionary(protocolMethodsDictionary, operationGroupKey, methodName);
                }
                // If operationGroup is not present, only operationId is passed in the config
                else
                {
                    AddToProtocolMethodsDictionary(protocolMethodsDictionary, "", operationId);
                }
            }

            return protocolMethodsDictionary;
        }

        private static void AddToProtocolMethodsDictionary(Dictionary<string, List<string>> protocolMethodsDictionary, string operationGroupKey, string methodName)
        {
            if (!protocolMethodsDictionary.ContainsKey(operationGroupKey))
            {
                List<string> methodList = new();
                methodList.Add(methodName);
                protocolMethodsDictionary.Add(operationGroupKey, methodList);
            }
            else
            {
                var methodList = protocolMethodsDictionary[operationGroupKey];
                methodList.Add(methodName);
            }
        }

        private string GetClientName(InputClient inputClient)
        {
            var clientPrefix = ClientBuilder.GetClientPrefix(inputClient.Name, _defaultName);
            var clientSuffix = ClientBuilder.GetClientSuffix();
            var clientName = clientPrefix + clientSuffix;
            var existingType = _sourceInputModel?.FindForType(_defaultNamespace, clientName);
            return existingType?.Name ?? clientName;
        }
    }
}
