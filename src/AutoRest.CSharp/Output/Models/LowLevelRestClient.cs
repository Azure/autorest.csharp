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
                ServiceRequest serviceRequest = operation.Requests.FirstOrDefault(r => r.Protocol.Http is HttpRequest);
                if (serviceRequest != null)
                {
                    IEnumerable<RequestParameter> requestParameters = serviceRequest.Parameters.Where (FilterServiceParamaters);
                    RestClientMethod method = _builder.BuildMethod(operation, (HttpRequest)serviceRequest.Protocol.Http!, requestParameters, null, true);
                    // Inject the body parameter
                    List<Parameter> parameters = method.Parameters.ToList();
                    Parameter bodyParam = new Parameter ("body", "The request body", typeof(Azure.Core.RequestContent), null, true);
                    parameters.Insert (0, bodyParam);
                    RequestBody body = new RequestContentRequestBody (bodyParam);
                    Request request = new Request (method.Request.HttpMethod, method.Request.PathSegments, method.Request.Query, method.Request.Headers, body);
                    yield return new RestClientMethod (method.Name, method.Description, method.ReturnType, request, parameters.ToArray(), method.Responses, method.HeaderModel, method.BufferResponse, method.IsVisible);
                }
            }
        }

        private bool FilterServiceParamaters (RequestParameter p)
        {
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
        }

        public IReadOnlyCollection<Parameter> GetConstructorParameters(CSharpType credentialType, bool includeProtocolOptions = false)
        {
            return RestClientBuilder<LowLevelOutputLibrary>.GetConstructorParameters(Parameters, credentialType, includeProtocolOptions, true);
        }
    }
}
