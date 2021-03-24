// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Output.Models
{
    internal class LowLevelRestClient : ClientBase
    {
        private readonly OperationGroup _operationGroup;
        private readonly BuildContext<LowLevelOutputLibrary> _context;
        private RestClientBuilder<LowLevelOutputLibrary> _builder;

        private RestClientMethod[]? _allMethods;

        protected override string DefaultAccessibility { get; } = "public";

        public LowLevelRestClient(OperationGroup operationGroup, BuildContext<LowLevelOutputLibrary> context) : base(context)
        {
            _operationGroup = operationGroup;
            _context = context;
            _builder = new RestClientBuilder<LowLevelOutputLibrary> (operationGroup, context);

            Parameters = _builder.GetOrderedParameters ();
            ClientPrefix = GetClientPrefix(operationGroup.Language.Default.Name, context);
            DefaultName = ClientPrefix + ClientSuffix;
            Description = "";
        }

        public Parameter[] Parameters { get; }
        public string Description { get; }
        public RestClientMethod[] Methods => _allMethods ??= BuildAllMethods().ToArray();
        public string ClientPrefix { get; }
        protected override string DefaultName { get; }

        private IEnumerable<RestClientMethod> BuildAllMethods()
        {
            var requestMethods = new Dictionary<ServiceRequest, RestClientMethod>();

            foreach (var operation in _operationGroup.Operations)
            {
                foreach (var serviceRequest in operation.Requests)
                {
                    // See also RestClient::EnsureNormalMethods if changing
                    if (!(serviceRequest.Protocol.Http is HttpRequest httpRequest))
                    {
                        continue;
                    }
                    IEnumerable<RequestParameter> requestParameters = serviceRequest.Parameters.Where (p => {
                        switch (p.In)
                        {
                            case ParameterLocation.Header:
                            case ParameterLocation.Query:
                            case ParameterLocation.Path:
                            case ParameterLocation.Uri:
                                return true;
                            default:
                                return false;
                        }
                    });
                    requestMethods.Add(serviceRequest, _builder.BuildMethod(operation, httpRequest, requestParameters, null));
                }
            }

            foreach (var operation in _operationGroup.Operations)
            {
                ServiceRequest serviceRequest = operation.Requests.FirstOrDefault();
                if (serviceRequest != null)
                {
                    yield return requestMethods[serviceRequest];
                }
            }
        }

        public IReadOnlyCollection<Parameter> GetConstructorParameters(CSharpType credentialType, bool includeProtocolOptions = false)
        {
            return RestClientHelpers.GetConstructorParameters(Parameters, credentialType, includeProtocolOptions, true);
        }
    }
}
