// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Output.Models
{
    internal static class LowLevelOutputLibraryFactory
    {
        public static LowLevelOutputLibrary Create(CodeModel codeModel, BuildContext<LowLevelOutputLibrary> context)
        {
            UpdateListMethodNames(codeModel);

            var clientInfosByName = codeModel.OperationGroups
                .Select(og => CreateClientInfo(og, context))
                .ToDictionary(ci => ci.Name);

            var topLevelClientInfos = SetHierarchy(clientInfosByName, context);

            var clientOptions = CreateClientOptions(topLevelClientInfos, context);
            SetRequestsToClients(clientInfosByName.Values);

            return new LowLevelOutputLibrary(context, () =>
            {
                var topLevelClients = CreateClients(topLevelClientInfos, context, clientOptions, null);
                return EnumerateAllClients(topLevelClients);
            }, clientOptions);
        }

        private static void UpdateListMethodNames(CodeModel codeModel)
        {
            var defaultName = codeModel.Language.Default.Name.ReplaceLast("Client", "");
            foreach (var operationGroup in codeModel.OperationGroups)
            {
                foreach (var operation in operationGroup.Operations)
                {
                    var resourceName = operationGroup.Key.IsNullOrEmpty() ? defaultName : operationGroup.Key;
                    operation.Language.Default.Name = operation.Language.Default.Name.RenameGetMethod(resourceName).RenameListToGet(resourceName);
                }
            }
        }

        private static ClientOptionsTypeProvider CreateClientOptions(IReadOnlyList<ClientInfo> topLevelClientInfos, BuildContext context)
        {
            var clientName = topLevelClientInfos.Count == 1
                ? topLevelClientInfos[0].Name
                : topLevelClientInfos.SingleOrDefault(c => string.IsNullOrEmpty(c.OperationGroupKey))?.Name;

            var clientOptionsName = clientName != null
                ? $"{ClientBuilder.GetClientPrefix(clientName, context)}ClientOptions"
                : $"{ClientBuilder.GetClientPrefix(context.DefaultLibraryName, context)}ClientOptions";

            return new ClientOptionsTypeProvider(context, clientOptionsName, clientName);
        }

        /// <summary>
        /// Simple implementation of breadth first traversal
        /// </summary>
        /// <param name="topLevelClients"></param>
        /// <returns>All clients</returns>
        private static IReadOnlyList<LowLevelClient> EnumerateAllClients(IEnumerable<LowLevelClient> topLevelClients)
        {
            var allClients = new List<LowLevelClient>(topLevelClients);
            for (int i = 0; i < allClients.Count; i++)
            {
                allClients.AddRange(allClients[i].SubClients);
            }
            return allClients;
        }

        public static ClientInfo CreateClientInfo(OperationGroup operationGroup, BuildContext context)
        {
            var clientNamePrefix = ClientBuilder.GetClientPrefix(operationGroup.Language.Default.Name, context);
            var clientNamespace = context.DefaultNamespace;
            var clientDescription = operationGroup.Language.Default.Description;
            var operations = operationGroup.Operations;
            var clientParameters = RestClientBuilder.GetParametersFromOperations(operations).ToList();
            var resourceParameters = clientParameters.Where(cp => cp.IsResourceParameter).ToHashSet();
            var isSubClient = Configuration.SingleTopLevelClient && !string.IsNullOrEmpty(operationGroup.Key) || resourceParameters.Any();
            var clientName = isSubClient ? clientNamePrefix : clientNamePrefix + ClientBuilder.GetClientSuffix(context);

            INamedTypeSymbol? existingType;
            if (context.SourceInputModel == null || (existingType = context.SourceInputModel.FindForType(context.DefaultNamespace, clientName)) == null)
            {
                return new ClientInfo(operationGroup.Key, clientName, clientNamespace, clientDescription, operations, clientParameters, resourceParameters);
            }

            clientName = existingType.Name;
            clientNamespace = existingType.ContainingNamespace.ToDisplayString();
            return new ClientInfo(operationGroup.Key, clientName, clientNamespace, clientDescription, existingType, operations, clientParameters, resourceParameters);
        }

        private static IReadOnlyList<ClientInfo> SetHierarchy(IReadOnlyDictionary<string, ClientInfo> clientInfosByName, BuildContext context)
        {
            var sourceInputModel = context.SourceInputModel;
            if (sourceInputModel != null)
            {
                foreach (var clientInfo in clientInfosByName.Values)
                {
                    AssignParents(clientInfo, clientInfosByName, sourceInputModel);
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
                var clientName = ClientBuilder.GetClientPrefix(context.DefaultLibraryName, context) + ClientBuilder.GetClientSuffix(context);
                var clientNamespace = context.DefaultNamespace;
                var endpointParameter = context.CodeModel.GlobalParameters.FirstOrDefault(RestClientBuilder.IsEndpointParameter);
                var clientParameters = endpointParameter != null ? new[] { endpointParameter } : Array.Empty<RequestParameter>();

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

            return new[] {topLevelClientInfo};
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

        public static void SetRequestsToClients(IEnumerable<ClientInfo> clientInfos)
        {
            foreach (var clientInfo in clientInfos)
            {
                foreach (var operation in clientInfo.Operations)
                {
                    if (operation.RequestMediaTypes != null)
                    {
                        SetRequestToClient(clientInfo, operation.Requests.First(), operation);
                        continue;
                    }

                    foreach (var request in operation.Requests)
                    {
                        SetRequestToClient(clientInfo, request, operation);
                    }
                }
            }
        }

        public static void SetRequestToClient(ClientInfo clientInfo, ServiceRequest request, Operation operation)
        {
            switch (clientInfo.ResourceParameters.Count)
            {
                case 1:
                    var requestParameter = clientInfo.ResourceParameters.Single();
                    if (operation.Parameters.Contains(requestParameter) || request.Parameters.Contains(requestParameter))
                    {
                        break;
                    }

                    while (clientInfo.Parent != null && clientInfo.ResourceParameters.Count != 0)
                    {
                        clientInfo = clientInfo.Parent;
                    }
                    break;
                case >1:
                    var requestParameters = operation.Parameters.Concat(request.Parameters).ToHashSet();
                    while (clientInfo.Parent != null && !clientInfo.ResourceParameters.IsSubsetOf(requestParameters))
                    {
                        clientInfo = clientInfo.Parent;
                    }

                    break;
            }

            clientInfo.Requests.Add((request, operation));
        }

        private static IEnumerable<LowLevelClient> CreateClients(IEnumerable<ClientInfo> clientInfos, BuildContext<LowLevelOutputLibrary> context, ClientOptionsTypeProvider clientOptions, LowLevelClient? parentClient)
        {
            foreach (var clientInfo in clientInfos)
            {
                var subClients = new List<LowLevelClient>();

                var client = new LowLevelClient(
                    clientInfo.Name,
                    clientInfo.Namespace,
                    clientInfo.Description,
                    parentClient,
                    clientInfo.Requests,
                    new RestClientBuilder(clientInfo.ClientParameters, context),
                    context,
                    clientOptions)
                {
                    SubClients = subClients
                };

                 subClients.AddRange(CreateClients(clientInfo.Children, context, clientOptions, client));

                 yield return client;
            }
        }

        public class ClientInfo
        {
            public string OperationGroupKey { get; }
            public string Name { get; }
            public string Namespace { get; }
            public string Description { get; }
            public INamedTypeSymbol? ExistingType { get; }
            public ICollection<Operation> Operations { get; }
            public IReadOnlyList<RequestParameter> ClientParameters { get; }
            public ISet<RequestParameter> ResourceParameters { get; }

            public ClientInfo? Parent { get; set; }
            public IList<ClientInfo> Children { get; }
            public IList<(ServiceRequest ServiceRequest, Operation Operation)> Requests { get; }

            public ClientInfo(string operationGroupKey, string clientName, string clientNamespace, string clientDescription, ICollection<Operation> operations, IReadOnlyList<RequestParameter> clientParameters, ISet<RequestParameter> resourceParameters)
                : this(operationGroupKey, clientName, clientNamespace, clientDescription, null, operations, clientParameters, resourceParameters)
            {
            }

            public ClientInfo(string operationGroupKey, string clientName, string clientNamespace, string clientDescription, INamedTypeSymbol? existingType, ICollection<Operation> operations, IReadOnlyList<RequestParameter> clientParameters, ISet<RequestParameter> resourceParameters)
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
                Requests = new List<(ServiceRequest, Operation)>();
            }

            public ClientInfo(string clientName, string clientNamespace, IReadOnlyList<RequestParameter> clientParameters)
            {
                OperationGroupKey = string.Empty;
                Name = clientName;
                Namespace = clientNamespace;
                Description = string.Empty;
                ExistingType = null;
                Operations = Array.Empty<Operation>();
                ClientParameters = clientParameters;
                ResourceParameters = new HashSet<RequestParameter>();
                Children = new List<ClientInfo>();
                Requests = new List<(ServiceRequest, Operation)>();
            }
        }
    }
}
