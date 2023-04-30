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

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class DataPlaneOutputLibrary : OutputLibrary
    {
        private CachedDictionary<InputClient, RestClient> _restClients;
        private CachedDictionary<InputClient, DataPlaneClient> _clients;
        private CachedDictionary<InputOperation, LongRunningOperation> _operations;
        private CachedDictionary<InputOperation, DataPlaneResponseHeaderGroupType> _headerModels;
        private CachedDictionary<InputEnumType, EnumType> _enums;
        private CachedDictionary<Schema, TypeProvider> _models;
        private CachedDictionary<string, List<string>> _protocolMethodsDictionary;

        private readonly InputNamespace _input;
        private readonly SourceInputModel? _sourceInputModel;
        private readonly Lazy<ModelFactoryTypeProvider?> _modelFactory;
        private readonly string _defaultName;
        private readonly string _defaultNamespace;
        private readonly string _libraryName;
        private readonly TypeFactory _typeFactory;
        private readonly SchemaUsageProvider _schemaUsageProvider;

        public DataPlaneOutputLibrary(CodeModel codeModel, SourceInputModel? sourceInputModel)
        {
            _typeFactory = new TypeFactory(this);
            _schemaUsageProvider = new SchemaUsageProvider(codeModel);
            _sourceInputModel = sourceInputModel;
            // // schema usage transformer must run first
            SchemaUsageTransformer.Transform(codeModel);
            DefaultDerivedSchema.AddDefaultDerivedSchemas(codeModel);
            _input = new CodeModelConverter().CreateNamespace(codeModel, _schemaUsageProvider);

            _defaultName = _input.Name;
            _defaultNamespace = Configuration.Namespace ?? _input.Name;
            _libraryName = Configuration.LibraryName ?? _input.Name;

            _restClients = new CachedDictionary<InputClient, RestClient>(EnsureRestClients);
            _clients = new CachedDictionary<InputClient, DataPlaneClient>(EnsureClients);
            _operations = new CachedDictionary<InputOperation, LongRunningOperation>(EnsureLongRunningOperations);
            _headerModels = new CachedDictionary<InputOperation, DataPlaneResponseHeaderGroupType>(EnsureHeaderModels);
            _enums = new CachedDictionary<InputEnumType, EnumType>(() => BuildEnums(codeModel));
            _models = new CachedDictionary<Schema, TypeProvider>(() => BuildModels(codeModel));
            _modelFactory = new Lazy<ModelFactoryTypeProvider?>(() => ModelFactoryTypeProvider.TryCreate(ClientBuilder.GetClientPrefix(Configuration.LibraryName, _libraryName), _input.Name, Models, _sourceInputModel));
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
        public IEnumerable<TypeProvider> Models => _models.Values;
        public IDictionary<string, List<string>> ProtocolMethodsDictionary => _protocolMethodsDictionary;

        public override CSharpType ResolveEnum(InputEnumType enumType) => _enums[enumType].Type;
        public override CSharpType ResolveModel(InputModelType model) => throw new NotImplementedException($"{nameof(ResolveModel)} is not implemented for HLC yet.");

        public override CSharpType FindTypeForSchema(Schema schema) => _models[schema].Type;

        public override TypeProvider FindTypeProviderForSchema(Schema schema) => _models[schema];

        public override CSharpType? FindTypeByName(string originalName)
        {
            foreach (var model in Models)
            {
                if (originalName == model.Type.Name)
                {
                    return model.Type;
                }
            }
            return null;
        }

        private Dictionary<InputEnumType, EnumType> BuildEnums(CodeModel codeModel)
        {
            var dictionary = new Dictionary<InputEnumType, EnumType>(InputEnumType.IgnoreNullabilityComparer);
            foreach (var schema in codeModel.AllSchemas)
            {
                var defaultNamespace = TypeProvider.GetDefaultModelNamespace(schema.Extensions?.Namespace, _defaultNamespace);
                switch (schema)
                {
                    case SealedChoiceSchema sealedChoiceSchema:
                        var inputEnum = CodeModelConverter.CreateEnumType(sealedChoiceSchema);
                        dictionary.Add(inputEnum, new EnumType(inputEnum, defaultNamespace, EnumType.GetAccessibility(schema, _schemaUsageProvider), _typeFactory, _sourceInputModel));
                        break;
                    case ChoiceSchema choiceSchema:
                        var inputExtensibleEnum = CodeModelConverter.CreateEnumType(choiceSchema);
                        dictionary.Add(inputExtensibleEnum, new EnumType(inputExtensibleEnum, defaultNamespace, EnumType.GetAccessibility(schema, _schemaUsageProvider), _typeFactory, _sourceInputModel));
                        break;
                }
            }

            return dictionary;
        }

        private Dictionary<Schema, TypeProvider> BuildModels(CodeModel codeModel)
            => codeModel.AllSchemas.ToDictionary(schema => schema, BuildModel);

        private TypeProvider BuildModel(Schema schema) => schema switch
        {
            SealedChoiceSchema sealedChoiceSchema => _enums[CodeModelConverter.CreateEnumType(sealedChoiceSchema)],
            ChoiceSchema choiceSchema => _enums[CodeModelConverter.CreateEnumType(choiceSchema)],
            ObjectSchema objectSchema => new SchemaObjectType(objectSchema, this, _typeFactory, _schemaUsageProvider, _defaultNamespace, _sourceInputModel),
            _ => throw new NotImplementedException()
        };

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

            if (Configuration.PublicClients)
            {
                foreach (var inputClient in _input.Clients)
                {
                    var client = FindClient(inputClient);
                    Debug.Assert(client != null, "client != null, LROs should be disabled when public clients are disabled.");

                    foreach (var methods in client.RestClient.Methods)
                    {
                        if (methods is not { Operation: { LongRunning: {}} operation })
                        {
                            continue;
                        }

                        var createNextPageMessageName = methods.RestClientNextPageMethod is not null
                            ? methods.CreateMessageMethods[1].Signature.Name
                            : null;

                        var info = new LongRunningOperationInfo(client.Declaration.Accessibility, client.RestClient.ClientPrefix, createNextPageMessageName);
                        operations.Add(operation, new LongRunningOperation(operation, _typeFactory, info, _defaultNamespace, _sourceInputModel));
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
                    clients.Add(inputClient, new DataPlaneClient(inputClient, _restClients[inputClient], this, _defaultName, _defaultNamespace, _sourceInputModel));
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
                var clientMethodsBuilder = new ClientMethodsBuilder(inputClient.Operations, _typeFactory, true, true);
                restClients.Add(inputClient, new RestClient(inputClient, clientMethodsBuilder, clientParameters, restClientParameters, _typeFactory, this, clientName, _defaultNamespace, _sourceInputModel));
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
