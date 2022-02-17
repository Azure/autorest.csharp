// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Output.Models
{
    internal class DataPlaneRestClient : RestClient
    {
        private BuildContext<DataPlaneOutputLibrary> _context;

        public IReadOnlyList<LowLevelClientMethod>? ProtocolMethods => _context.Configuration.ProtocolMethodList.Length > 0 && GetProtocolMethods() != null
            ? GetProtocolMethods().ToArray() : null;

        public DataPlaneRestClient(OperationGroup operationGroup, BuildContext<DataPlaneOutputLibrary> context)
            : base(operationGroup, context, context.Library.FindClient(operationGroup)?.Declaration.Name)
        {
            _context = context;
        }

        private IEnumerable<LowLevelClientMethod>? GetProtocolMethods()
        {
            // Filter protocol methods based on the config
            List<Operation> operations = new();
            foreach (var operation in OperationGroup.Operations)
            {
                if (isProtocolMethodExists(operation))
                {
                    operations.Add(operation);
                }

            }

            // Atleast one match found
            if (operations.Count > 0)
            {
                var clientParameters = RestClientBuilder.GetParametersFromOperations(operations).ToList();
                var restClientBuilder = new RestClientBuilder(clientParameters, _context);

                var clientInfo = LowLevelOutputLibraryFactory.CreateClientInfo(OperationGroup, _context);
                var clientInfoByName = _context.Library.DPGClientInfosByName[clientInfo.Name];

                // Filter protocol method requests based on the config
                List<(ServiceRequest, Operation)> requests = new();
                foreach (var (serviceRequest, operation) in clientInfoByName.Requests)
                {
                    if (isProtocolMethodExists(operation))
                    {
                        requests.Add((serviceRequest, operation));
                    }
                }

                return LowLevelClient.BuildMethods(restClientBuilder, requests, clientInfo.Name);
            }

            return null;
        }

        private bool isProtocolMethodExists(Operation operation)
        {
            var protocolMethods = _context.Configuration.ProtocolMethodList;
            return protocolMethods.Any(m => m.Equals(operation.Language.Default.Name, StringComparison.OrdinalIgnoreCase));
        }

        protected override Dictionary<ServiceRequest, RestClientMethod> EnsureNormalMethods()
        {
            var requestMethods = new Dictionary<ServiceRequest, RestClientMethod>();

            foreach (var operation in OperationGroup.Operations)
            {
                foreach (var serviceRequest in operation.Requests)
                {
                    // See also LowLevelClient::EnsureNormalMethods if changing
                    if (!(serviceRequest.Protocol.Http is HttpRequest httpRequest))
                    {
                        continue;
                    }
                    var headerModel = _context.Library.FindHeaderModel(operation);
                    var accessibility = operation.Accessibility ?? "public";
                    requestMethods.Add(serviceRequest, Builder.BuildMethod(operation, httpRequest, serviceRequest.Parameters, headerModel, accessibility));
                }
            }

            return requestMethods;
        }
    }
}
