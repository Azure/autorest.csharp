﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
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

        public DataPlaneRestClient(InputClient inputClient, RestClientBuilder clientBuilder, BuildContext<DataPlaneOutputLibrary> context)
            : base(inputClient, context, GetClientName(inputClient, context), GetOrderedParameters(clientBuilder))
        {
            _context = context;
            ClientBuilder = clientBuilder;
            ProtocolMethods = GetProtocolMethods(inputClient, clientBuilder, context).ToList();
            Fields = ClientFields.CreateForRestClient(Parameters);
        }

        protected override Dictionary<InputOperation, RestClientMethod> EnsureNormalMethods()
        {
            var requestMethods = new Dictionary<InputOperation, RestClientMethod>();

            foreach (var operation in InputClient.Operations)
            {
                var headerModel = _context.Library.FindHeaderModel(operation);
                var accessibility = operation.Accessibility ?? "public";
                requestMethods.Add(operation, ClientBuilder.BuildMethod(operation, headerModel, accessibility));
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

        private IEnumerable<LowLevelClientMethod> GetProtocolMethods(InputClient inputClient, RestClientBuilder restClientBuilder, BuildContext<DataPlaneOutputLibrary> context)
        {
            // At least one protocol method is found in the config for this operationGroup
            if (!inputClient.Operations.Any(operation => IsProtocolMethodExists(operation, inputClient, context)))
            {
                return Enumerable.Empty<LowLevelClientMethod>();
            }

            // Filter protocol method requests for this operationGroup based on the config
            var operations = Methods
                .Select(m => m.Operation)
                .Where(operation => IsProtocolMethodExists(operation, inputClient, context));

            return LowLevelClient.BuildMethods(restClientBuilder, operations, GetClientName(inputClient, context), false);
        }

        private static string GetClientName(InputClient inputClient, BuildContext<DataPlaneOutputLibrary> context)
            => context.Library.FindClient(inputClient)?.Declaration.Name ?? inputClient.Name;

        private static bool IsProtocolMethodExists(InputOperation operation, InputClient inputClient, BuildContext<DataPlaneOutputLibrary> context)
            => context.Library.ProtocolMethodsDictionary.TryGetValue(inputClient.Key, out var protocolMethods) &&
                protocolMethods.Any(m => m.Equals(operation.Name, StringComparison.OrdinalIgnoreCase));
    }
}
