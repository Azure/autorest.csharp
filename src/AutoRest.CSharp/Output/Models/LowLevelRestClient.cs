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

        private Dictionary<ServiceRequest, RestClientMethod>? _requestMethods;
        private RestClientMethod[]? _allMethods;

        protected override string DefaultAccessibility { get; } = "public";

        public LowLevelRestClient(OperationGroup operationGroup, BuildContext<LowLevelOutputLibrary> context) : base(context)
        {
            _operationGroup = operationGroup;
            _context = context;
            _builder = new RestClientBuilder<LowLevelOutputLibrary> (operationGroup, context, FilterMethodParameters);

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
            foreach (var operation in _operationGroup.Operations)
            {
                foreach (var serviceRequest in operation.Requests)
                {
                    RestClientMethod method = GetOperationMethod(serviceRequest);
                    yield return method;
                    // Only return the first request
                    break;
                }
            }
        }

        public RestClientMethod GetOperationMethod(ServiceRequest request)
        {
            return EnsureNormalMethods()[request];
        }

        private Dictionary<ServiceRequest, RestClientMethod> EnsureNormalMethods()
        {
            if (_requestMethods != null)
            {
                return _requestMethods;
            }

            _requestMethods = new Dictionary<ServiceRequest, RestClientMethod>();

            foreach (var operation in _operationGroup.Operations)
            {
                foreach (var serviceRequest in operation.Requests)
                {
                    // See also RestClient::EnsureNormalMethods if changing
                    if (!(serviceRequest.Protocol.Http is HttpRequest httpRequest))
                    {
                        continue;
                    }

                    _requestMethods.Add(serviceRequest, _builder.BuildMethod(operation, httpRequest, serviceRequest.Parameters, null));
                }
            }

            return _requestMethods;
        }

        private bool FilterMethodParameters(RequestParameter parameter)
        {
            switch (parameter.In)
            {
                case ParameterLocation.Header:
                case ParameterLocation.Query:
                case ParameterLocation.Path:
                    return true;
                default:
                    return false;
            }
        }

        public IReadOnlyCollection<Parameter> GetConstructorParameters(CSharpType credentialType, bool includeProtocolOptions = false)
        {
            return RestClientHelpers.GetConstructorParameters (Parameters, credentialType, includeProtocolOptions);
        }
    }
}
