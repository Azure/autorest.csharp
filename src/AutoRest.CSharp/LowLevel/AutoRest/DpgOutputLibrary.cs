// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Decorator;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Utilities;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class DpgOutputLibrary : OutputLibrary
    {
        private const string MaxCountParameterName = "maxCount";

        private readonly InputNamespace _rootNamespace;
        private readonly SourceInputModel? _sourceInputModel;
        private readonly string _defaultNamespace;
        private readonly string _libraryName;
        private readonly bool _isCadlInput;

        public TypeFactory TypeFactory { get; }

        private readonly Dictionary<InputType, TypeProvider> _inputToTypeProviders = new();

        public CachedDictionary<InputType, TypeProvider> AllModelMap { get; }

        private IEnumerable<EnumType>? _enums;
        public IEnumerable<EnumType> Enums => _enums ??= AllModelMap.Values.OfType<EnumType>();

        private IEnumerable<ModelTypeProvider>? _models;
        public IEnumerable<ObjectType> Models => _models ??= AllModelMap.Values.OfType<ModelTypeProvider>();

        private IReadOnlyList<LowLevelClient>? _restClients;
        public IReadOnlyList<LowLevelClient> RestClients => _restClients ??= EnsureClients();

        private ClientOptionsTypeProvider? _clientOptions;
        public ClientOptionsTypeProvider ClientOptions => _clientOptions ??= EnsureClientOptions();

        private IEnumerable<TypeProvider>? _allModels;
        public IEnumerable<TypeProvider> AllModels => _allModels ??= AllModelMap.Values;

        public DpgOutputLibrary(InputNamespace rootNamespace, bool isCadlInput, SourceInputModel? sourceInputMode)
        {
            TypeFactory = new TypeFactory(this);
            _rootNamespace = rootNamespace;
            _sourceInputModel = sourceInputMode;
            _isCadlInput = isCadlInput;
            _defaultNamespace = Configuration.Namespace ?? rootNamespace.Name;
            _libraryName = Configuration.LibraryName ?? rootNamespace.Name;
            AllModelMap = new CachedDictionary<InputType, TypeProvider>(InitializeModels);
        }

        private Dictionary<InputType, TypeProvider> InitializeModels()
        {
            if (_isCadlInput)
            {
                foreach (var input in _rootNamespace.Models)
                {
                    if (input.Usage != InputModelTypeUsage.None)
                    {
                        var model = BuildModel(input);
                        _inputToTypeProviders.Add(input, model);
                    }
                }

                foreach (var input in _rootNamespace.Enums)
                {
                    if (input.Usage != InputModelTypeUsage.None)
                    {
                        var enumModel = BuildModel(input);
                        _inputToTypeProviders.Add(input, enumModel);
                    }
                }

                var replacedTypes = new Dictionary<InputModelType, ObjectType>();
                foreach (var input in _rootNamespace.Models)
                {
                    if (_inputToTypeProviders.TryGetValue(input, out var type) && type is ModelTypeProvider modelTypeProvider)
                    {
                        var csharpType = TypeReferenceTypeChooser.GetExactMatch(modelTypeProvider);
                        if (csharpType != null)
                        {
                            replacedTypes.Add(input, (SystemObjectType)csharpType.Implementation);
                        }
                    }
                }

                // replace those filtered types
                foreach (var (inputModel, objectType) in replacedTypes)
                {
                    _inputToTypeProviders[inputModel] = objectType;
                }
            }

            return _inputToTypeProviders;
        }

        private TypeProvider BuildModel(InputType inputType) => inputType switch
        {
            InputModelType inputModelType => new ModelTypeProvider(inputModelType, _defaultNamespace, _sourceInputModel, TypeFactory),
            InputEnumType inputEnumType => new EnumType(inputEnumType, _defaultNamespace, "public", TypeFactory, _sourceInputModel),
            _ => throw new InvalidOperationException("This should never happen")
        };

        private ClientOptionsTypeProvider EnsureClientOptions()
        {
            (var clientOptions, _) = EnsureClientPairs();
            return clientOptions;
        }

        private List<LowLevelClient> EnsureClients()
        {
            (_, var clients) = EnsureClientPairs();
            return clients;
        }

        private (ClientOptionsTypeProvider ClientOptions, List<LowLevelClient> Clients)? _clientPairs;
        private (ClientOptionsTypeProvider ClientOptions, List<LowLevelClient> Clients) EnsureClientPairs()
        {
            if (_clientPairs != null)
                return _clientPairs.Value;

            var inputClients = UpdateOperations();

            var clientInfosByName = inputClients
                .Select(og => CreateClientInfo(og, _sourceInputModel, _rootNamespace.Name))
                .ToDictionary(ci => ci.Name);
            var topLevelClientInfos = SetHierarchy(clientInfosByName);
            var clientOptions = CreateClientOptions(topLevelClientInfos);

            SetRequestsToClients(clientInfosByName.Values);

            var clients = CreateClients(topLevelClientInfos, TypeFactory, clientOptions);

            _clientPairs = (clientOptions, clients);

            return _clientPairs.Value;
        }

        private static void SetRequestsToClients(IEnumerable<ClientInfo> clientInfos)
        {
            foreach (var clientInfo in clientInfos)
            {
                foreach (var operation in clientInfo.Operations)
                {
                    SetRequestToClient(clientInfo, operation);
                }
            }
        }

        private static void SetRequestToClient(ClientInfo clientInfo, InputOperation operation)
        {
            switch (clientInfo.ResourceParameters.Count)
            {
                case 1:
                    var requestParameter = clientInfo.ResourceParameters.Single();
                    if (operation.Parameters.Contains(requestParameter))
                    {
                        break;
                    }

                    while (clientInfo.Parent != null && clientInfo.ResourceParameters.Count != 0)
                    {
                        clientInfo = clientInfo.Parent;
                    }
                    break;
                case > 1:
                    var requestParameters = operation.Parameters.ToHashSet();
                    while (clientInfo.Parent != null && !clientInfo.ResourceParameters.IsSubsetOf(requestParameters))
                    {
                        clientInfo = clientInfo.Parent;
                    }

                    break;
            }

            clientInfo.Requests.Add(operation);
        }

        private ClientOptionsTypeProvider CreateClientOptions(IReadOnlyList<ClientInfo> topLevelClientInfos)
        {
            var clientName = topLevelClientInfos.Count == 1
                ? topLevelClientInfos[0].Name
                : topLevelClientInfos.SingleOrDefault(c => string.IsNullOrEmpty(c.OperationGroupKey))?.Name;

            var clientOptionsName = $"{ClientBuilder.GetClientPrefix(clientName ?? _libraryName, _rootNamespace.Name)}ClientOptions";
            var description = clientName != null
                ? (FormattableString)$"Client options for {clientName}."
                : $"Client options for {_libraryName} library clients.";

            return new ClientOptionsTypeProvider(_sourceInputModel?.GetServiceVersionOverrides() ?? _rootNamespace.ApiVersions, clientOptionsName, _defaultNamespace, description, _sourceInputModel);
        }

        private IReadOnlyList<ClientInfo> SetHierarchy(IReadOnlyDictionary<string, ClientInfo> clientInfosByName)
        {
            if (_sourceInputModel != null)
            {
                foreach (var clientInfo in clientInfosByName.Values)
                {
                    AssignParents(clientInfo, clientInfosByName, _sourceInputModel);
                }
            }

            var topLevelClients = clientInfosByName.Values.Where(c => c.Parent == null).ToList();
            if (!Configuration.SingleTopLevelClient || topLevelClients.Count == 1)
            {
                return topLevelClients;
            }

            var topLevelClientInfo = topLevelClients.FirstOrDefault(c => string.IsNullOrEmpty(c.OperationGroupKey));
            if (topLevelClientInfo == null)
            {
                var clientName = ClientBuilder.GetClientPrefix(_libraryName, _rootNamespace.Name) + ClientBuilder.GetClientSuffix();
                var clientNamespace = _defaultNamespace;
                var endpointParameter = topLevelClients.SelectMany(c => c.ClientParameters).FirstOrDefault(p => p.IsEndpoint);
                var clientParameters = endpointParameter != null ? new[] { endpointParameter } : Array.Empty<InputParameter>();

                topLevelClientInfo = new ClientInfo(clientName, clientNamespace, clientParameters);
            }

            foreach (var clientInfo in topLevelClients)
            {
                if (clientInfo != topLevelClientInfo)
                {
                    clientInfo.Parent = topLevelClientInfo;
                    topLevelClientInfo.Children.Add(clientInfo);
                }
            }

            return new[] { topLevelClientInfo };
        }

        private static void AssignParents(in ClientInfo clientInfo, IReadOnlyDictionary<string, ClientInfo> clientInfosByName, SourceInputModel sourceInputModel)
        {
            var child = clientInfo;
            while (child.Parent == null && child.ExistingType != null && sourceInputModel.TryGetClientSourceInput(child.ExistingType, out var clientSourceInput) && clientSourceInput.ParentClientType != null)
            {
                var parent = clientInfosByName[clientSourceInput.ParentClientType.Name];
                if (clientInfo == parent)
                {
                    throw new InvalidOperationException("loop");
                }

                child.Parent = parent;
                parent.Children.Add(child);
                child = parent;
            }
        }

        private static ClientInfo CreateClientInfo(InputClient ns, SourceInputModel? sourceInputModel, string rootNamespaceName)
        {
            var clientNamePrefix = ClientBuilder.GetClientPrefix(ns.Name, rootNamespaceName);
            var clientNamespace = Configuration.Namespace ?? rootNamespaceName;
            var clientDescription = ns.Description;
            var operations = ns.Operations;
            var clientParameters = RestClientBuilder.GetParametersFromOperations(operations).ToList();
            var resourceParameters = clientParameters.Where(cp => cp.IsResourceParameter).ToHashSet();
            var isSubClient = Configuration.SingleTopLevelClient && !string.IsNullOrEmpty(ns.Name) || resourceParameters.Any();
            var clientName = isSubClient ? clientNamePrefix : clientNamePrefix + ClientBuilder.GetClientSuffix();

            INamedTypeSymbol? existingType;
            if (sourceInputModel == null || (existingType = sourceInputModel.FindForType(clientNamespace, clientName)) == null)
            {
                return new ClientInfo(ns.Name, clientName, clientNamespace, clientDescription, operations, clientParameters, resourceParameters);
            }

            clientName = existingType.Name;
            clientNamespace = existingType.ContainingNamespace.ToDisplayString();
            return new ClientInfo(ns.Name, clientName, clientNamespace, clientDescription, existingType, operations, clientParameters, resourceParameters);
        }

        private IEnumerable<InputClient> UpdateOperations()
        {
            var defaultName = _rootNamespace.Name.ReplaceLast("Client", "");
            // this map of old/new InputOperation is to update the lazy initialization of `Paging.NextLinkOperation`
            var operationsMap = new Dictionary<InputOperation, InputOperation>();
            foreach (var client in _rootNamespace.Clients)
            {
                var clientName = client.Name.IsNullOrEmpty() ? defaultName : client.Name;
                yield return client with { Operations = client.Operations.Select(op => UpdateOperation(op, clientName, operationsMap)).ToList() };
            }
        }

        private static InputOperation UpdateOperation(InputOperation operation, string clientName, IDictionary<InputOperation, InputOperation> operationsMap)
        {
            InputOperation updatedOperation;
            if (operation.Paging != null && !Configuration.DisablePaginationTopRenaming && !operation.Parameters.Any(p => p.Name.Equals(MaxCountParameterName, StringComparison.OrdinalIgnoreCase)))
            {
                updatedOperation = operation with
                {
                    Name = UpdateOperationName(operation, clientName),
                    Parameters = UpdateOperationParameters(operation.Parameters),
                    // to update the lazy initialization of `Paging.NextLinkOperation`
                    Paging = operation.Paging with { NextLinkOperationRef = operation.Paging.NextLinkOperation != null ? () => operationsMap[operation.Paging.NextLinkOperation] : null }
                };
            }
            else
            {
                updatedOperation = operation with { Name = UpdateOperationName(operation, clientName) };
            }
            operationsMap.Add(operation, updatedOperation);

            return updatedOperation;
        }

        private static string UpdateOperationName(InputOperation operation, string clientName)
            => operation.Name.RenameGetMethod(clientName).RenameListToGet(clientName);

        private static IReadOnlyList<InputParameter> UpdateOperationParameters(IReadOnlyList<InputParameter> operationParameters)
        {
            var parameters = new List<InputParameter>(operationParameters.Count);
            foreach (var parameter in operationParameters)
            {
                if (parameter.Name.Equals("top", StringComparison.OrdinalIgnoreCase))
                {
                    parameters.Add(parameter with { Name = MaxCountParameterName });
                }
                else
                {
                    parameters.Add(parameter);
                }
            }

            return parameters;
        }

        public override CSharpType ResolveEnum(InputEnumType enumType)
        {
            if (!_isCadlInput)
            {
                return TypeFactory.CreateType(enumType.EnumValueType);
            }

            if (!AllModelMap.IsPopulated)
            {
                if (enumType.Usage != InputModelTypeUsage.None)
                    return BuildModel(enumType).Type;
                return new CSharpType(typeof(object), enumType.IsNullable);
            }
            else if (AllModelMap.TryGetValue(enumType, out var result))
            {
                return result.Type;
            }

            throw new InvalidOperationException($"No {nameof(EnumType)} has been created for `{enumType.Name}` {nameof(InputEnumType)}.");
        }

        public override CSharpType ResolveModel(InputModelType model)
        {
            if (!AllModelMap.IsPopulated)
            {
                return model.Usage != InputModelTypeUsage.None ? BuildModel(model).Type : new CSharpType(typeof(object), model.IsNullable);
            }

            if (AllModelMap.TryGetValue(model, out var result))
            {
                return result.Type;
            }
            return new CSharpType(typeof(object), model.IsNullable);
        }

        public override CSharpType FindTypeForSchema(Schema schema) => throw new NotImplementedException($"{nameof(FindTypeForSchema)} shouldn't be called for DPG!");

        public override CSharpType? FindTypeByName(string originalName) => null;

        private List<LowLevelClient> CreateClients(IEnumerable<ClientInfo> topLevelClientInfos, TypeFactory typeFactory, ClientOptionsTypeProvider clientOptions)
        {
            var allClients = new List<LowLevelClient>();
            var topLevelClients = CreateClients(topLevelClientInfos, typeFactory, clientOptions, null);

            // Simple implementation of breadth first traversal
            allClients.AddRange(topLevelClients);
            for (int i = 0; i < allClients.Count; i++)
            {
                allClients.AddRange(allClients[i].SubClients);
            }

            return allClients;
        }

        private IEnumerable<LowLevelClient> CreateClients(IEnumerable<ClientInfo> clientInfos, TypeFactory typeFactory, ClientOptionsTypeProvider clientOptions, LowLevelClient? parentClient)
        {
            foreach (var clientInfo in clientInfos)
            {
                var description = string.IsNullOrWhiteSpace(clientInfo.Description)
                    ? $"The {ClientBuilder.GetClientPrefix(clientInfo.Name, _rootNamespace.Name)} {(parentClient == null ? "service client" : "sub-client")}."
                    : BuilderHelpers.EscapeXmlDescription(clientInfo.Description);

                var subClients = new List<LowLevelClient>();

                var client = new LowLevelClient(
                    clientInfo.Name,
                    clientInfo.Namespace,
                    description,
                    _libraryName,
                    parentClient,
                    clientInfo.Requests,
                    clientInfo.ClientParameters,
                    _rootNamespace.Auth,
                    _sourceInputModel,
                    clientOptions,
                    typeFactory)
                {
                    SubClients = subClients
                };

                subClients.AddRange(CreateClients(clientInfo.Children, typeFactory, clientOptions, client));

                yield return client;
            }
        }

        private class ClientInfo
        {
            public string OperationGroupKey { get; }
            public string Name { get; }
            public string Namespace { get; }
            public string Description { get; }
            public INamedTypeSymbol? ExistingType { get; }
            public IReadOnlyList<InputOperation> Operations { get; }
            public IReadOnlyList<InputParameter> ClientParameters { get; }
            public ISet<InputParameter> ResourceParameters { get; }

            public ClientInfo? Parent { get; set; }
            public IList<ClientInfo> Children { get; }
            public IList<InputOperation> Requests { get; }

            public ClientInfo(string operationGroupKey, string clientName, string clientNamespace, string clientDescription, IReadOnlyList<InputOperation> operations, IReadOnlyList<InputParameter> clientParameters, ISet<InputParameter> resourceParameters)
                : this(operationGroupKey, clientName, clientNamespace, clientDescription, null, operations, clientParameters, resourceParameters)
            {
            }

            public ClientInfo(string operationGroupKey, string clientName, string clientNamespace, string clientDescription, INamedTypeSymbol? existingType, IReadOnlyList<InputOperation> operations, IReadOnlyList<InputParameter> clientParameters, ISet<InputParameter> resourceParameters)
            {
                OperationGroupKey = operationGroupKey;
                Name = clientName;
                Namespace = clientNamespace;
                Description = clientDescription;
                ExistingType = existingType;
                Operations = operations;
                ClientParameters = clientParameters;
                ResourceParameters = resourceParameters;
                Children = new List<ClientInfo>();
                Requests = new List<InputOperation>();
            }

            public ClientInfo(string clientName, string clientNamespace, IReadOnlyList<InputParameter> clientParameters)
            {
                OperationGroupKey = string.Empty;
                Name = clientName;
                Namespace = clientNamespace;
                Description = string.Empty;
                ExistingType = null;
                Operations = Array.Empty<InputOperation>();
                ClientParameters = clientParameters;
                ResourceParameters = new HashSet<InputParameter>();
                Children = new List<ClientInfo>();
                Requests = new List<InputOperation>();
            }
        }
    }
}
