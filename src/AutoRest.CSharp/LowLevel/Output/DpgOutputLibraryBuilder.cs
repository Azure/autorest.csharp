// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Input.Examples;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Common.Utilities;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Microsoft.CodeAnalysis;
using Configuration = AutoRest.CSharp.Common.Input.Configuration;

namespace AutoRest.CSharp.Output.Models
{
    internal class DpgOutputLibraryBuilder
    {
        private const string MaxCountParameterName = "maxCount";

        private readonly InputNamespace _rootNamespace;
        private readonly SourceInputModel? _sourceInputModel;
        private readonly string _libraryName;

        public DpgOutputLibraryBuilder(InputNamespace rootNamespace, SourceInputModel? sourceInputModel)
        {
            _rootNamespace = rootNamespace;
            _sourceInputModel = sourceInputModel;
            _libraryName = Configuration.LibraryName;
        }

        public DpgOutputLibrary Build(bool isTspInput)
        {
            var inputClients = UpdateOperations().ToList();

            var clientInfosByName = inputClients
                .Select(og => CreateClientInfo(og, _sourceInputModel, _rootNamespace.Name))
                .ToDictionary(ci => ci.Name);
            AssignParentClients(inputClients, clientInfosByName);
            var topLevelClientInfos = SetHierarchy(clientInfosByName);
            var parametersInClientOptions = new List<Parameter>();
            var clientOptions = CreateClientOptions(topLevelClientInfos, parametersInClientOptions);

            SetRequestsToClients(clientInfosByName.Values);

            var enums = new Dictionary<InputEnumType, EnumType>();
            var models = new Dictionary<InputModelType, ModelTypeProvider>();
            var clients = new List<LowLevelClient>();

            var library = new DpgOutputLibrary(_libraryName, enums, models, clients, clientOptions, isTspInput, _sourceInputModel);

            if (isTspInput)
            {
                CreateModels(_rootNamespace.Models, models, library.TypeFactory, _sourceInputModel);
                CreateEnums(_rootNamespace.Enums, enums, models, library.TypeFactory, _sourceInputModel);
            }
            CreateClients(clients, topLevelClientInfos, library.TypeFactory, clientOptions, parametersInClientOptions);

            return library;
        }

        public static void CreateEnums(IReadOnlyList<InputEnumType> inputEnums, IDictionary<InputEnumType, EnumType> enums, IDictionary<InputModelType, ModelTypeProvider> models, TypeFactory typeFactory, SourceInputModel? sourceInputModel)
        {
            foreach (var inputEnum in inputEnums)
            {
                // [TODO]: Consolidate default namespace choice between HLC and DPG
                var ns = ExtractNamespace(inputEnum.CrossLanguageDefinitionId);
                enums.Add(inputEnum, new EnumType(inputEnum, TypeProvider.GetDefaultModelNamespace(ns, Configuration.Namespace), "public", typeFactory, sourceInputModel));
            }
        }

        private static string? ExtractNamespace(string crossLanguageDefinitionId)
        {
            if (Configuration.Generation1ConvenienceClient)
            {
                var index = crossLanguageDefinitionId.LastIndexOf(".");
                return index >= 0 ? crossLanguageDefinitionId[..index] : null;
            }

            return null;
        }

        public static void CreateModels(IReadOnlyList<InputModelType> inputModels, IDictionary<InputModelType, ModelTypeProvider> models, TypeFactory typeFactory, SourceInputModel? sourceInputModel)
        {
            var defaultDerivedTypes = new Dictionary<string, ModelTypeProvider>();
            foreach (var model in inputModels)
            {
                ModelTypeProvider? defaultDerivedType = GetDefaultDerivedType(models, typeFactory, model, defaultDerivedTypes, sourceInputModel);
                // [TODO]: Consolidate default namespace choice between HLC and DPG
                var ns = ExtractNamespace(model.CrossLanguageDefinitionId);
                var typeProvider = new ModelTypeProvider(model, TypeProvider.GetDefaultModelNamespace(ns, Configuration.Namespace), sourceInputModel, typeFactory, defaultDerivedType);
                models.Add(model, typeProvider);
            }
        }

        private static ModelTypeProvider? GetDefaultDerivedType(IDictionary<InputModelType, ModelTypeProvider> models, TypeFactory typeFactory, InputModelType model, Dictionary<string, ModelTypeProvider> defaultDerivedTypes, SourceInputModel? sourceInputModel)
        {
            //only want to create one instance of the default derived per polymorphic set
            bool isBasePolyType = model.DiscriminatorProperty is not null;
            bool isChildPolyType = model.DiscriminatorValue is not null;
            if (!isBasePolyType && !isChildPolyType)
            {
                return null;
            }

            var actualBase = model;
            while (actualBase.BaseModel?.DiscriminatorProperty is not null)
            {
                actualBase = actualBase.BaseModel;
            }

            //Since the unknown type is used for deserialization only we don't need to create if it is an input only model
            // TODO -- remove this condition completely when remove the UseModelReaderWriter flag
            if (!Configuration.UseModelReaderWriter && !actualBase.Usage.HasFlag(InputModelTypeUsage.Output))
            {
                return null;
            }

            string defaultDerivedName = $"Unknown{actualBase.Name}";
            if (!defaultDerivedTypes.TryGetValue(defaultDerivedName, out ModelTypeProvider? defaultDerivedType))
            {
                //create the "Unknown" version
                var unknownDerivedType = new InputModelType(
                    defaultDerivedName,
                    string.Empty,
                    "internal",
                    null,
                    $"Unknown version of {actualBase.Name}",
                    model.Usage.HasFlag(InputModelTypeUsage.Input) ? InputModelTypeUsage.Input | InputModelTypeUsage.Output : InputModelTypeUsage.Output,
                    Array.Empty<InputModelProperty>(),
                    actualBase,
                    Array.Empty<InputModelType>(),
                    "Unknown", //TODO: do we need to support extensible enum / int values?
                    null,
                    new Dictionary<string, InputModelType>(),
                    null)
                {
                    IsUnknownDiscriminatorModel = true
                };
                defaultDerivedType = new ModelTypeProvider(unknownDerivedType, TypeProvider.GetDefaultModelNamespace(null, Configuration.Namespace), sourceInputModel, typeFactory, null);
                defaultDerivedTypes.Add(defaultDerivedName, defaultDerivedType);
                models.Add(unknownDerivedType, defaultDerivedType);
            }

            return defaultDerivedType;
        }

        private IEnumerable<InputClient> UpdateOperations()
        {
            var defaultName = _rootNamespace.Name.ReplaceLast("Client", "");
            // this map of old/new InputOperation is to update the lazy initialization of `Paging.NextLinkOperation`
            var operationsMap = new Dictionary<InputOperation, Func<InputOperation>>();
            foreach (var client in _rootNamespace.Clients)
            {
                var clientName = client.Name.IsNullOrEmpty() ? defaultName : client.Name;
                foreach (var operation in client.Operations)
                {
                    operationsMap.CreateAndCacheResult(operation, () => UpdateOperation(operation, clientName, operationsMap));
                }

                yield return client with { Operations = client.Operations.Select(op => operationsMap[op]()).ToList() };
            }
        }

        private static InputOperation UpdateOperation(InputOperation operation, string clientName, IReadOnlyDictionary<InputOperation, Func<InputOperation>> operationsMap)
        {
            var name = UpdateOperationName(operation, operation.ResourceName ?? clientName);
            if (operation.Paging != null && !Configuration.DisablePaginationTopRenaming && !operation.Parameters.Any(p => p.Name.Equals(MaxCountParameterName, StringComparison.OrdinalIgnoreCase)))
            {
                operation = operation with
                {
                    Parameters = UpdatePageableOperationParameters(operation.Parameters),
                    Paging = UpdateOperationPaging(operation.Paging, operationsMap),
                };
            }

            return operation with
            {
                Name = name,
            };
        }

        private static string UpdateOperationName(InputOperation operation, string clientName)
            => operation.CleanName.RenameGetMethod(clientName).RenameListToGet(clientName);

        private static IReadOnlyList<InputParameter> UpdatePageableOperationParameters(IReadOnlyList<InputParameter> operationParameters)
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

        private static OperationPaging? UpdateOperationPaging(OperationPaging? sourcePaging, IReadOnlyDictionary<InputOperation, Func<InputOperation>> operationsMap)
        {
            if (sourcePaging == null)
            {
                return null;
            }

            if (sourcePaging.NextLinkOperation != null && operationsMap.TryGetValue(sourcePaging.NextLinkOperation, out var nextLinkOperationRef))
            {
                return sourcePaging with { NextLinkOperation = nextLinkOperationRef() };
            }

            return sourcePaging;
        }

        private ClientOptionsTypeProvider CreateClientOptions(IReadOnlyList<ClientInfo> topLevelClientInfos, List<Parameter> parametersInClientOptions)
        {
            var clientName = topLevelClientInfos.Count == 1
                ? topLevelClientInfos[0].Name
                : topLevelClientInfos.SingleOrDefault(c => string.IsNullOrEmpty(c.OperationGroupKey))?.Name;

            var clientOptionsName = $"{ClientBuilder.GetClientPrefix(clientName ?? _libraryName, _rootNamespace.Name)}ClientOptions";
            var description = clientName != null
                ? (FormattableString)$"Client options for {clientName}."
                : $"Client options for {_libraryName} library clients.";

            IReadOnlyList<string>? apiVersions = _sourceInputModel?.GetServiceVersionOverrides() ?? _rootNamespace.ApiVersions;
            return new ClientOptionsTypeProvider(apiVersions, clientOptionsName, Configuration.Namespace, description, _sourceInputModel)
            {
                AdditionalParameters = parametersInClientOptions
            };
        }

        private static ClientInfo CreateClientInfo(InputClient ns, SourceInputModel? sourceInputModel, string rootNamespaceName)
        {
            var clientNamePrefix = ClientBuilder.GetClientPrefix(ns.Name, rootNamespaceName);
            var clientNamespace = Configuration.Namespace;
            var clientDescription = ns.Description;
            var operations = ns.Operations;
            var clientParameters = RestClientBuilder.GetParametersFromClient(ns).ToList();
            var resourceParameters = clientParameters.Where(cp => cp.IsResourceParameter).ToHashSet();
            var isSubClient = Configuration.SingleTopLevelClient && !string.IsNullOrEmpty(ns.Name) || resourceParameters.Any() || !string.IsNullOrEmpty(ns.Parent);
            var clientName = isSubClient ? clientNamePrefix : clientNamePrefix + ClientBuilder.GetClientSuffix();

            INamedTypeSymbol? existingType;
            if (sourceInputModel == null || (existingType = sourceInputModel.FindForType(clientNamespace, clientName)) == null)
            {
                return new ClientInfo(ns.Name, clientName, clientNamespace, clientDescription, operations, ns.Parameters, resourceParameters);
            }

            clientName = existingType.Name;
            clientNamespace = existingType.ContainingNamespace.ToDisplayString();
            return new ClientInfo(ns.Name, clientName, clientNamespace, clientDescription, existingType, operations, ns.Parameters, resourceParameters);
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
                var clientNamespace = Configuration.Namespace;
                var clientParameters = topLevelClients.SelectMany(c => c.ClientParameters.Concat(c.Operations.SelectMany(op => op.Parameters)))
                    .Where(p => (p.Kind == InputOperationParameterKind.Client) && (!p.IsRequired || p.IsApiVersion || p.IsEndpoint))
                    .DistinctBy(p => p.Name)
                    .ToArray();

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

        // assign parent according to the information in the input Model
        private static void AssignParentClients(in IEnumerable<InputClient> clients, IReadOnlyDictionary<string, ClientInfo> clientInfosByName)
        {
            foreach (var client in clients)
            {
                if (!String.IsNullOrEmpty(client.Parent))
                {
                    ClientInfo? targetClient = null;
                    ClientInfo? targetParent = null;
                    foreach (var info in clientInfosByName.Values)
                    {
                        if (info.OperationGroupKey == client.Name)
                            targetClient = info;
                        if (info.OperationGroupKey == client.Parent)
                            targetParent = info;
                    }
                    if (targetClient != null && targetParent != null)
                    {
                        targetClient.Parent = targetParent;
                        targetParent.Children.Add(targetClient);
                    }
                }
            }
        }

        //Assign parent according to the customized inputModel
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

        private void CreateClients(List<LowLevelClient> allClients, IEnumerable<ClientInfo> topLevelClientInfos, TypeFactory typeFactory, ClientOptionsTypeProvider clientOptions, List<Parameter> parametersInClientOptions)
        {
            var topLevelClients = CreateClients(topLevelClientInfos, typeFactory, clientOptions, null, parametersInClientOptions);

            // Simple implementation of breadth first traversal
            allClients.AddRange(topLevelClients);
            for (int i = 0; i < allClients.Count; i++)
            {
                allClients.AddRange(allClients[i].SubClients);
            }
        }

        private IEnumerable<LowLevelClient> CreateClients(IEnumerable<ClientInfo> clientInfos, TypeFactory typeFactory, ClientOptionsTypeProvider clientOptions, LowLevelClient? parentClient, List<Parameter> parametersInClientOptions)
        {
            foreach (var clientInfo in clientInfos)
            {
                var description = string.IsNullOrWhiteSpace(clientInfo.Description)
                    ? $"The {ClientBuilder.GetClientPrefix(clientInfo.Name, _rootNamespace.Name)} {(parentClient == null ? "service client" : "sub-client")}."
                    : BuilderHelpers.EscapeXmlDocDescription(clientInfo.Description);

                var subClients = new List<LowLevelClient>();

                if (!Configuration.IsBranded)
                {
                    for (int i = 0; i < clientInfo.Requests.Count; i++)
                    {
                        clientInfo.Requests[i] = InputOperation.RemoveApiVersionParam(clientInfo.Requests[i]);
                    }
                }

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

                subClients.AddRange(CreateClients(clientInfo.Children, typeFactory, clientOptions, client, parametersInClientOptions));
                // parametersInClientOptions is assigned to ClientOptionsTypeProvider.AdditionalProperties before, which makes sure AdditionalProperties is readonly and won't change after ClientOptionsTypeProvider is built.
                parametersInClientOptions.AddRange(client.GetOptionalParametersInOptions());

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

            private IReadOnlyList<InputParameter>? _clientParameters;
            private IReadOnlyList<InputParameter> _initClientParameters;
            public IReadOnlyList<InputParameter> ClientParameters => _clientParameters ??= EnsureClientParameters();

            private IReadOnlyList<InputParameter> EnsureClientParameters()
            {
                if (_initClientParameters.Count == 0)
                {
                    var endpointParameter = this.Children.SelectMany(c => c.ClientParameters).FirstOrDefault(p => p.IsEndpoint);
                    return endpointParameter != null ? new[] { endpointParameter } : Array.Empty<InputParameter>();
                }
                return _initClientParameters;
            }

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
                _initClientParameters = clientParameters;
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
                _initClientParameters = clientParameters;
                ResourceParameters = new HashSet<InputParameter>();
                Children = new List<ClientInfo>();
                Requests = new List<InputOperation>();
            }
        }
    }
}
