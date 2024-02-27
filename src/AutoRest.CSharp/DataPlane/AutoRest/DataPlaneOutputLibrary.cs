// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Security;
using AutoRest.CSharp.Common.Decorator;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Mgmt.Decorator.Transformer;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Responses;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;
using Microsoft.CodeAnalysis.CSharp;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class DataPlaneOutputLibrary : OutputLibrary
    {
        private CachedDictionary<InputClient, DataPlaneRestClient> _restClients;
        private CachedDictionary<InputClient, DataPlaneClient> _clients;
        private CachedDictionary<InputOperation, LongRunningOperation> _operations;
        private CachedDictionary<InputOperation, DataPlaneResponseHeaderGroupType> _headerModels;
        private IReadOnlyDictionary<InputEnumType, EnumType> _enums;
        private IReadOnlyDictionary<InputModelType, ModelTypeProvider> _models;
        private CachedDictionary<string, List<string>> _protocolMethodsDictionary;

        private readonly InputNamespace _input;
        private readonly SourceInputModel? _sourceInputModel;
        private readonly Lazy<ModelFactoryTypeProvider?> _modelFactory;
        private readonly string _libraryName;
        private readonly TypeFactory _typeFactory;

        public DataPlaneOutputLibrary(CodeModel codeModel, SourceInputModel? sourceInputModel)
        {
            var schemaUsageProvider = new SchemaUsageProvider(codeModel); // Create schema usage before transformation applied

            _typeFactory = new TypeFactory(this);
            _sourceInputModel = sourceInputModel;

            // schema usage transformer must run first
            SchemaUsageTransformer.Transform(codeModel);
            DefaultDerivedSchema.AddDefaultDerivedSchemas(codeModel);
            ConstantSchemaTransformer.Transform(codeModel);
            ModelPropertyClientDefaultValueTransformer.Transform(codeModel);

            _input = new CodeModelConverter(codeModel, schemaUsageProvider).CreateNamespace();

            _libraryName = Configuration.LibraryName;

            var enums = new Dictionary<InputEnumType, EnumType>();
            var models = new Dictionary<InputModelType, ModelTypeProvider>();

            DpgOutputLibraryBuilder.CreateModels(_input.Models, models, _typeFactory, sourceInputModel);
            DpgOutputLibraryBuilder.CreateEnums(_input.Enums, enums, models, _typeFactory, sourceInputModel);

            _enums = enums;
            _models = models;

            var allModels = new List<TypeProvider>(_enums.Values);
            allModels.AddRange(_models.Values);
            Models = allModels;

            _restClients = new CachedDictionary<InputClient, DataPlaneRestClient>(EnsureRestClients);
            _clients = new CachedDictionary<InputClient, DataPlaneClient>(EnsureClients);
            _operations = new CachedDictionary<InputOperation, LongRunningOperation>(EnsureLongRunningOperations);
            _headerModels = new CachedDictionary<InputOperation, DataPlaneResponseHeaderGroupType>(EnsureHeaderModels);
            _modelFactory = new Lazy<ModelFactoryTypeProvider?>(() => ModelFactoryTypeProvider.TryCreate(Models, _typeFactory, _sourceInputModel));
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
            return new ClientOptionsTypeProvider(_sourceInputModel?.GetServiceVersionOverrides() ?? _input.ApiVersions, $"{clientPrefix}ClientOptions", Configuration.Namespace, $"Client options for {clientPrefix}Client.", _sourceInputModel);
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
            => _enums.TryGetValue(enumType with { IsNullable = false }, out var typeProvider)
                ? typeProvider.Type.WithNullable(enumType.IsNullable)
                : throw new InvalidOperationException($"No {nameof(EnumType)} has been created for `{enumType.Name}` {nameof(InputEnumType)}.");

        public override CSharpType ResolveModel(InputModelType model)
            => _models.TryGetValue(model with { IsNullable = false }, out var modelTypeProvider)
                ? modelTypeProvider.Type.WithNullable(model.IsNullable)
                : new CSharpType(typeof(object), model.IsNullable);

        public override CSharpType FindTypeForSchema(Schema schema) => throw new NotImplementedException($"{nameof(FindTypeForSchema)} shouldn't be called for HLC!");

        public override TypeProvider FindTypeProviderForSchema(Schema schema) => throw new NotImplementedException($"{nameof(FindTypeProviderForSchema)} shouldn't be called for HLC!");

        public override CSharpType? FindTypeByName(string originalName) => Models.Where(m => m.Declaration.Name == originalName)?.Select(m => m.Type).FirstOrDefault();

        public LongRunningOperation FindLongRunningOperation(InputOperation operation)
        {
            Debug.Assert(operation.LongRunning != null);

            return _operations[operation];
        }

        public DataPlaneClient? FindClient(InputClient inputClient)
        {
            _clients.TryGetValue(inputClient, out var client);
            return client;
        }

        public DataPlaneResponseHeaderGroupType? FindHeaderModel(InputOperation operation)
        {
            _headerModels.TryGetValue(operation, out var model);
            return model;
        }

        private LongRunningOperationInfo FindLongRunningOperationInfo(InputClient inputClient, InputOperation operation)
        {
            var client = FindClient(inputClient);

            Debug.Assert(client != null, "client != null, LROs should be disabled when public clients are disabled.");

            var nextOperationMethod = operation.Paging != null
                ? client.RestClient.GetNextOperationMethod(operation)
                : null;

            return new LongRunningOperationInfo(
                client.Declaration.Accessibility,
                ClientBuilder.GetClientPrefix(client.RestClient.Declaration.Name, string.Empty),
                nextOperationMethod);
        }

        public IEnumerable<DataPlaneRestClient> RestClients => _restClients.Values;

        private Dictionary<InputOperation, DataPlaneResponseHeaderGroupType> EnsureHeaderModels()
        {
            var headerModels = new Dictionary<InputOperation, DataPlaneResponseHeaderGroupType>();
            if (Configuration.GenerateResponseHeaderModels)
            {
                foreach (var inputClient in _input.Clients)
                {
                    var clientPrefix = ClientBuilder.GetClientPrefix(GetClientDeclarationName(inputClient), _input.Name);
                    foreach (var operation in inputClient.Operations)
                    {
                        var headers = DataPlaneResponseHeaderGroupType.TryCreate(operation, _typeFactory, clientPrefix, _sourceInputModel);
                        if (headers != null)
                        {
                            headerModels.Add(operation, headers);
                        }
                    }
                }
            }

            return headerModels;
        }

        private Dictionary<InputOperation, LongRunningOperation> EnsureLongRunningOperations()
        {
            var operations = new Dictionary<InputOperation, LongRunningOperation>();

            if (Configuration.PublicClients && Configuration.GenerateLongRunningOperationTypes)
            {
                foreach (var client in _input.Clients)
                {
                    var clientName = _clients[client].Declaration.Name;
                    var clientPrefix = ClientBuilder.GetClientPrefix(clientName, _input.Name);

                    foreach (var operation in client.Operations)
                    {
                        if (operation.LongRunning is null)
                        {
                            continue;
                        }

                        var existingType = _sourceInputModel?.FindForType(Configuration.Namespace, clientName);
                        var accessibility = existingType is not null
                            ? SyntaxFacts.GetText(existingType.DeclaredAccessibility)
                            : "public";

                        operations.Add(operation, new LongRunningOperation(operation, _typeFactory, accessibility, clientPrefix, FindLongRunningOperationInfo(client, operation), _sourceInputModel));
                    }
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
                    clients.Add(inputClient, new DataPlaneClient(inputClient, _restClients[inputClient], GetClientDefaultName(inputClient), this, _sourceInputModel));
                }
            }

            return clients;
        }

        private Dictionary<InputClient, DataPlaneRestClient> EnsureRestClients()
        {
            var restClients = new Dictionary<InputClient, DataPlaneRestClient>();
            foreach (var client in _input.Clients)
            {
                var clientParameters = RestClientBuilder.GetParametersFromOperations(client.Operations).ToList();
                var restClientBuilder = new RestClientBuilder(clientParameters, _typeFactory, this);
                restClients.Add(client, new DataPlaneRestClient(client, restClientBuilder, GetRestClientDefaultName(client), this, _typeFactory, _sourceInputModel));
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

        private string GetRestClientDefaultName(InputClient inputClient)
        {
            var clientPrefix = ClientBuilder.GetClientPrefix(GetClientDeclarationName(inputClient), _input.Name);
            return clientPrefix + "Rest" + ClientBuilder.GetClientSuffix();
        }

        private string GetClientDeclarationName(InputClient inputClient)
        {
            var defaultName = GetClientDefaultName(inputClient);
            var existingType = _sourceInputModel?.FindForType(Configuration.Namespace, defaultName);
            return existingType != null ? existingType.Name : defaultName;
        }

        private string GetClientDefaultName(InputClient inputClient)
        {
            var clientPrefix = ClientBuilder.GetClientPrefix(inputClient.Name, _input.Name);
            var clientSuffix = ClientBuilder.GetClientSuffix();
            return clientPrefix + clientSuffix;
        }
    }
}
