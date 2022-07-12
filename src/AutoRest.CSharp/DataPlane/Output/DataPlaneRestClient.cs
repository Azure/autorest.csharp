// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Output.Models
{
    internal class DataPlaneRestClient : RestClient
    {
        private readonly BuildContext<DataPlaneOutputLibrary> _context;

        public IReadOnlyList<LowLevelClientMethod> ProtocolMethods { get; }
        public RestClientBuilder ClientBuilder { get; }
        public ClientFields Fields { get; }

        public DataPlaneRestClient(OperationGroup operationGroup, RestClientBuilder clientBuilder, BuildContext<DataPlaneOutputLibrary> context)
            : base(operationGroup, context, GetClientName(operationGroup, context), GetOrderedParameters(clientBuilder))
        {
            _context = context;
            ClientBuilder = clientBuilder;
            ProtocolMethods = GetProtocolMethods(operationGroup, clientBuilder, context).ToList();
            Fields = ClientFields.CreateForRestClient(Parameters);
        }

        protected override Dictionary<ServiceRequest, RestClientMethod> EnsureNormalMethods()
        {
            var operations = CodeModelConverter.CreateOperations(OperationGroup.Operations);
            var requestMethods = new Dictionary<ServiceRequest, RestClientMethod>();

            foreach (var (serviceRequest, operation) in operations)
            {
                var headerModel = _context.Library.FindHeaderModel(operation.Source);
                var accessibility = operation.Accessibility ?? "public";
                requestMethods.Add(serviceRequest, ClientBuilder.BuildMethod(operation, headerModel, accessibility));
            }

            return requestMethods;
        }

        private static IReadOnlyList<Parameter> GetOrderedParameters(RestClientBuilder clientBuilder)
        {
            var parameters = new List<Parameter>();
            parameters.Add(KnownParameters.ClientDiagnostics);
            parameters.Add(KnownParameters.Pipeline);
            parameters.AddRange(clientBuilder.GetOrderedParametersByRequired());
            return parameters;
        }

        private static IEnumerable<string> GetProtocolMethodsByOperationGroup(OperationGroup operationGroup, BuildContext<DataPlaneOutputLibrary> context)
        {
            context.Library.ProtocolMethodsDictionary.TryGetValue(operationGroup.Key, out var methodList);
            return methodList ?? Enumerable.Empty<string>();
        }

        private IEnumerable<LowLevelClientMethod> GetProtocolMethods(OperationGroup operationGroup, RestClientBuilder restClientBuilder, BuildContext<DataPlaneOutputLibrary> context)
        {
            // At least one protocol method is found in the config for this operationGroup
            if (!operationGroup.Operations.Any(operation => IsProtocolMethodExists(operation, operationGroup, context)))
            {
                return Enumerable.Empty<LowLevelClientMethod>();
            }

            // Filter protocol method requests for this operationGroup based on the config
            var operations = Methods
                .Select(m => m.Operation)
                .Where(operation => IsProtocolMethodExists(operation, operationGroup, context));

            return LowLevelClient.BuildMethods(restClientBuilder, operations, GetClientName(operationGroup, context));
        }

        private static string GetClientName(OperationGroup operationGroup, BuildContext<DataPlaneOutputLibrary> context)
            => context.Library.FindClient(operationGroup)?.Declaration.Name ?? operationGroup.Language.Default.Name;

        private static bool IsProtocolMethodExists(Operation operation, OperationGroup operationGroup, BuildContext<DataPlaneOutputLibrary> context)
            => GetProtocolMethodsByOperationGroup(operationGroup, context).Any(m => m.Equals(operation.Language.Default.Name, StringComparison.OrdinalIgnoreCase));

        private static bool IsProtocolMethodExists(InputOperation operation, OperationGroup operationGroup, BuildContext<DataPlaneOutputLibrary> context)
            => GetProtocolMethodsByOperationGroup(operationGroup, context).Any(m => m.Equals(operation.Name, StringComparison.OrdinalIgnoreCase));
    }
}
