// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Input.Examples;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models.Types;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Output.Models
{
    internal class DpgOutputLibraryBuilder
    {
        private readonly InputNamespace _rootNamespace;
        private readonly SourceInputModel? _sourceInputModel;
        private readonly string _defaultNamespace;
        private readonly string _libraryName;

        public DpgOutputLibraryBuilder(InputNamespace rootNamespace, SourceInputModel? sourceInputModel)
        {
            rootNamespace = RenameInputsVisitor.Visit(rootNamespace);
            rootNamespace = RenameAnonymousTypesVisitor.Visit(rootNamespace);

            _rootNamespace = rootNamespace;
            _sourceInputModel = sourceInputModel;
            _defaultNamespace = Configuration.Namespace;
            _libraryName = Configuration.LibraryName;
        }

        public DpgOutputLibrary Build(bool isTspInput)
        {
            var inputClients = _rootNamespace.Clients;

            var clientInfosByName = inputClients
                .Select(og => CreateClientInfo(og, _sourceInputModel, _rootNamespace.Name))
                .ToDictionary(ci => ci.Name);
            AssignParentClients(inputClients, clientInfosByName);
            var topLevelClientInfos = SetHierarchy(clientInfosByName);
            var clientOptions = CreateClientOptions(topLevelClientInfos);

            SetRequestsToClients(clientInfosByName.Values);
            return new DpgOutputLibrary(_rootNamespace, topLevelClientInfos, clientOptions, isTspInput, _sourceInputModel);
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

            IReadOnlyList<string> apiVersions = _sourceInputModel?.GetServiceVersionOverrides() ?? _rootNamespace.ApiVersions;
            if (Configuration.IsBranded)
            {
                return new ClientOptionsTypeProvider(apiVersions, clientOptionsName, _defaultNamespace, description, _sourceInputModel);
            }

            if (apiVersions.Count <= 1)
            {
                return new ClientOptionsTypeProvider(null, clientOptionsName, _defaultNamespace, description, _sourceInputModel);
            }

            throw new InvalidOperationException("Multiple API versions are not supported in the unbranded path.");
        }

        private static ClientInfo CreateClientInfo(InputClient inputClient, SourceInputModel? sourceInputModel, string rootNamespaceName)
        {
            var clientNamePrefix = ClientBuilder.GetClientPrefix(inputClient.Name, rootNamespaceName);
            var clientNamespace = Configuration.Namespace;
            var clientDescription = inputClient.Description;
            var operations = inputClient.Operations;
            var clientParameters = RestClientBuilder.GetParametersFromOperations(operations);
            var resourceParameters = clientParameters.Where(cp => cp.IsResourceParameter).ToHashSet();
            var isSubClient = Configuration.SingleTopLevelClient && !string.IsNullOrEmpty(inputClient.Name) || resourceParameters.Any() || !string.IsNullOrEmpty(inputClient.Parent);
            var clientName = isSubClient ? clientNamePrefix : clientNamePrefix + ClientBuilder.GetClientSuffix();

            if (sourceInputModel?.FindForType(clientNamespace, clientName) is not {} existingType)
            {
                return new ClientInfo(inputClient.Key, clientName, clientNamespace, clientDescription, operations, clientParameters, resourceParameters, inputClient.Examples);
            }

            clientName = existingType.Name;
            clientNamespace = existingType.ContainingNamespace.ToDisplayString();
            return new ClientInfo(inputClient.Key, clientName, clientNamespace, clientDescription, existingType, operations, clientParameters, resourceParameters, inputClient.Examples);
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
                var infoForEndpoint = topLevelClients.FirstOrDefault(c => c.ClientParameters.Any(p => p.IsEndpoint));
                var endpointParameter = infoForEndpoint?.ClientParameters.FirstOrDefault(p => p.IsEndpoint);
                var clientParameters = endpointParameter != null ? new[] { endpointParameter } : Array.Empty<InputParameter>();
                var clientExamples = infoForEndpoint?.Examples ?? Array.Empty<InputClientExample>();

                topLevelClientInfo = new ClientInfo(clientName, clientNamespace, clientParameters, clientExamples);
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

        //Assgin parent according to the customized inputModel
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

        public class ClientInfo
        {
            public string OperationGroupKey { get; }
            public string Name { get; }
            public string Namespace { get; }
            public string Description { get; }
            public INamedTypeSymbol? ExistingType { get; }
            public IReadOnlyList<InputOperation> Operations { get; }

            private readonly IReadOnlyList<InputClientExample> _initialExamples;
            private IReadOnlyList<InputClientExample>? _examples;
            public IReadOnlyList<InputClientExample> Examples => _examples ??= EnsureExamples();

            private IReadOnlyList<InputClientExample> EnsureExamples()
            {
                // pick up all examples from child client infos here, since we might promote some parameters from child clients
                var examples = new List<InputClientExample>();
                foreach (var example in _initialExamples)
                {
                    var clientParameterExamples = new List<InputParameterExample>(example.ClientParameters);
                    foreach (var child in Children)
                    {
                        if (child.Examples.FirstOrDefault(e => e.Key == example.Key) is {} childExamples)
                        {
                            clientParameterExamples.AddRange(childExamples.ClientParameters);
                        }
                    }

                    examples.Add(example with {ClientParameters = clientParameterExamples});
                }

                return examples;
            }

            private readonly IReadOnlyList<InputParameter> _initClientParameters;
            private IReadOnlyList<InputParameter>? _clientParameters;
            public IReadOnlyList<InputParameter> ClientParameters => _clientParameters ??= EnsureClientParameters();

            private IReadOnlyList<InputParameter> EnsureClientParameters()
            {
                if (_initClientParameters.Count == 0)
                {
                    var endpointParameter = Children.SelectMany(c => c.ClientParameters).FirstOrDefault(p => p.IsEndpoint);
                    return endpointParameter != null ? new[] { endpointParameter } : Array.Empty<InputParameter>();
                }
                return _initClientParameters;
            }
            public ISet<InputParameter> ResourceParameters { get; }

            public ClientInfo? Parent { get; set; }
            public IList<ClientInfo> Children { get; }
            public IList<InputOperation> Requests { get; }

            public ClientInfo(string operationGroupKey, string clientName, string clientNamespace, string clientDescription, IReadOnlyList<InputOperation> operations, IReadOnlyList<InputParameter> clientParameters, ISet<InputParameter> resourceParameters, IReadOnlyList<InputClientExample> examples)
                : this(operationGroupKey, clientName, clientNamespace, clientDescription, null, operations, clientParameters, resourceParameters, examples)
            {
            }

            public ClientInfo(string operationGroupKey, string clientName, string clientNamespace, string clientDescription, INamedTypeSymbol? existingType, IReadOnlyList<InputOperation> operations, IReadOnlyList<InputParameter> clientParameters, ISet<InputParameter> resourceParameters, IReadOnlyList<InputClientExample> examples)
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
                _initialExamples = examples;
            }

            public ClientInfo(string clientName, string clientNamespace, IReadOnlyList<InputParameter> clientParameters, IReadOnlyList<InputClientExample> examples)
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
                _initialExamples = examples;
            }
        }
    }
}
