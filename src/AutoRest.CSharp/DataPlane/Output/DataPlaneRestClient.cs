﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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

        public DataPlaneRestClient(OperationGroup operationGroup, IReadOnlyList<LowLevelClientMethod> protocolMethods, RestClientBuilder clientBuilder, BuildContext<DataPlaneOutputLibrary> context)
            : base(operationGroup, context, context.Library.FindClient(operationGroup)?.Declaration.Name, GetOrderedParameters(clientBuilder, protocolMethods))
        {
            _context = context;
            ClientBuilder = clientBuilder;
            ProtocolMethods = protocolMethods;
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

        private static IReadOnlyList<Parameter> GetOrderedParameters(RestClientBuilder clientBuilder, IReadOnlyList<LowLevelClientMethod> protocolMethods)
        {
            var parameters = new List<Parameter>();
            parameters.Add(KnownParameters.ClientDiagnostics);
            parameters.Add(KnownParameters.Pipeline);
            parameters.AddRange(clientBuilder.GetOrderedParametersByRequired());
            return parameters;
        }
    }
}
