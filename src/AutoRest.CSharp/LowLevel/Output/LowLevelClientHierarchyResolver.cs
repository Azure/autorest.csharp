// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models.Types;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Output.Models
{
    internal static class LowLevelClientHierarchyResolver
    {
        public static IReadOnlyList<LowLevelClient> BuildClientHierarchy(ICollection<OperationGroup> operationGroups, BuildContext<LowLevelOutputLibrary> context, ClientOptionsTypeProvider clientOptions)
        {
            var clientInfosByName = operationGroups
                .Select(og => CreateClientInfo(og, context))
                .ToDictionary(ci => ci.Name);

            var topLevelClientInfos = SetHierarchy(clientInfosByName, context);
            SetRequestsToClients(clientInfosByName.Values);
            var topLevelClients = CreateClients(topLevelClientInfos, context, clientOptions);

            return EnumerateAllClients(topLevelClients);
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

        private static ClientInfo CreateClientInfo(OperationGroup operationGroup, BuildContext<LowLevelOutputLibrary> context)
        {
            var clientName = GetClientNameFromCodeModel(context, operationGroup);
            var clientNamespace = context.DefaultNamespace;
            var clientDescription = operationGroup.Language.Default.Description;

            if (context.SourceInputModel == null)
            {
                return new ClientInfo(operationGroup.Key, clientName, clientNamespace, clientDescription, operationGroup.Operations);
            }

            var existingType = context.SourceInputModel.FindForType(context.DefaultNamespace, clientName);
            if (existingType == null)
            {
                return new ClientInfo(operationGroup.Key, clientName, clientNamespace, clientDescription, operationGroup.Operations);
            }

            clientName = existingType.Name;
            clientNamespace = existingType.ContainingNamespace.ToDisplayString();
            return new ClientInfo(operationGroup.Key, clientName, clientNamespace, clientDescription, existingType, operationGroup.Operations);
        }

        private static string GetClientNameFromCodeModel(BuildContext context, OperationGroup operationGroup)
            => ClientBuilder.GetClientPrefix(operationGroup.Language.Default.Name, context);

        private static IReadOnlyList<ClientInfo> SetHierarchy(IReadOnlyDictionary<string, ClientInfo> clientInfosByName, BuildContext context)
        {
            var sourceInputModel = context.SourceInputModel;
            if (sourceInputModel != null)
            {
                foreach (var clientInfo in clientInfosByName.Values)
                {
                    if (clientInfo.Parent == null && clientInfo.ExistingType != null)
                    {
                        AssignParents(clientInfo, clientInfosByName, sourceInputModel);
                    }
                }
            }

            var topLevelClients = clientInfosByName.Values.Where(c => c.Parent == null).ToList();
            if (!context.Configuration.SingleTopLevelClient || topLevelClients.Count == 1)
            {
                return topLevelClients;
            }

            var topLevelClientInfo = topLevelClients.FirstOrDefault(c => string.IsNullOrEmpty(c.OperationGroupKey));
            if (topLevelClientInfo == null)
            {
                var clientName = ClientBuilder.GetClientPrefix(string.Empty, context);
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
            while (child.ExistingType != null && sourceInputModel.TryGetClientSourceInput(child.ExistingType, out var clientSourceInput) && clientSourceInput.ParentClientType != null)
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
                    foreach (var request in operation.Requests)
                    {
                        SetRequestToClient(clientInfo, request, operation);
                    }
                }
            }
        }

        private static void SetRequestToClient(ClientInfo clientInfo, ServiceRequest request, Operation operation)
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

        private static IEnumerable<LowLevelClient> CreateClients(IEnumerable<ClientInfo> clientInfos, BuildContext<LowLevelOutputLibrary> context, ClientOptionsTypeProvider clientOptions)
        {
            foreach (var clientInfo in clientInfos)
            {
                var subClients = clientInfo.Children.Count > 0
                    ? CreateClients(clientInfo.Children, context, clientOptions).ToArray()
                    : Array.Empty<LowLevelClient>();

                var isSubClient = clientInfo.Parent != null;
                var name = isSubClient || clientInfo.ExistingType != null ? clientInfo.Name : clientInfo.Name + ClientBuilder.GetClientSuffix(context);

                yield return new LowLevelClient(
                    name,
                    clientInfo.Namespace,
                    clientInfo.Description,
                    isSubClient,
                    subClients,
                    clientInfo.Requests,
                    new RestClientBuilder(clientInfo.ClientParameters, context),
                    context,
                    clientOptions);
            }
        }

        private class ClientInfo
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

            public ClientInfo(string operationGroupKey, string clientName, string clientNamespace, string clientDescription, ICollection<Operation> operations)
                : this(operationGroupKey, clientName, clientNamespace, clientDescription, null, operations)
            {
            }

            public ClientInfo(string operationGroupKey, string clientName, string clientNamespace, string clientDescription, INamedTypeSymbol? existingType, ICollection<Operation> operations)
            {
                OperationGroupKey = operationGroupKey;
                Name = clientName;
                Namespace = clientNamespace;
                Description = clientDescription;
                ExistingType = existingType;
                Operations = operations;
                ClientParameters = RestClientBuilder.GetParametersFromOperations(operations).ToList();
                ResourceParameters = ClientParameters.Where(cp => cp.IsResourceParameter).ToHashSet();
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
