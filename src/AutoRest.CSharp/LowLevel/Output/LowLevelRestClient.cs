// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Output.Models
{
    internal class LowLevelRestClient : TypeProvider
    {
        private readonly OperationGroup _operationGroup;
        private readonly BuildContext<LowLevelOutputLibrary> _context;
        private RestClientBuilder _builder;

        private LowLevelClientMethod[]? _allMethods;

        protected override string DefaultAccessibility { get; } = "public";

        public LowLevelRestClient(OperationGroup operationGroup, BuildContext<LowLevelOutputLibrary> context) : base(context)
        {
            _operationGroup = operationGroup;
            _context = context;
            _builder = new RestClientBuilder (operationGroup, context);
            Parameters = _builder.GetOrderedParameters ().Where (p => !p.IsApiVersionParameter).ToArray();
            ClientPrefix = ClientBuilder.GetClientPrefix(operationGroup.Language.Default.Name, context);
            var clientSuffix = ClientBuilder.GetClientSuffix(context);
            DefaultName = ClientPrefix + clientSuffix;
        }

        public Parameter[] Parameters { get; }
        public string Description => BuilderHelpers.EscapeXmlDescription(ClientBuilder.CreateDescription(_operationGroup, ClientBuilder.GetClientPrefix(Declaration.Name, _context)));
        public LowLevelClientMethod[] Methods => _allMethods ??= BuildAllMethods().ToArray();
        public string ClientPrefix { get; }
        protected override string DefaultName { get; }

        private IEnumerable<LowLevelClientMethod> BuildAllMethods()
        {
            var requestMethods = new Dictionary<ServiceRequest, RestClientMethod>();

            foreach (var operation in _operationGroup.Operations)
            {
                ServiceRequest serviceRequest = operation.Requests.FirstOrDefault(r => r.Protocol.Http is HttpRequest);
                if (serviceRequest != null)
                {
                    // Prepare our parameter list. If there were any parameters that should be passed in the body of the request,
                    // we want to generate a single parameter of type `RequestContent` named `requestBody` paramter. We want that
                    // parameter to be the last required parameter in the method signature (so any required path or query parameters
                    // will show up first.

                    IEnumerable<RequestParameter> requestParameters = serviceRequest.Parameters.Where (FilterServiceParamaters);
                    var accessibility = operation.Accessibility ?? "public";
                    RestClientMethod method = _builder.BuildMethod(operation, (HttpRequest)serviceRequest.Protocol.Http!, requestParameters, null, accessibility);
                    List<Parameter> parameters = method.Parameters.ToList();
                    RequestBody? body = null;

                    if (serviceRequest.Parameters.Any(p => p.In == ParameterLocation.Body))
                    {
                        // The service request had some parameters for the body, so create a parameter for the body and inject it into the list of parameters,
                        // right before the first optional parameter.
                        Parameter bodyParam = new Parameter("requestBody", "The request body", typeof(Azure.Core.RequestContent), null, true);
                        int firstOptionalParameterIndex = parameters.FindIndex(p => p.DefaultValue != null);
                        if (firstOptionalParameterIndex == -1)
                        {
                            firstOptionalParameterIndex = parameters.Count;
                        }
                        parameters.Insert(firstOptionalParameterIndex, bodyParam);
                        body = new RequestContentRequestBody(bodyParam);
                    }

                    // Inject the RequestOptions
                    CSharpType requestType = new CSharpType (typeof(Azure.RequestOptions)).WithNullable(true);
                    Parameter requestOptions = new Parameter ("requestOptions", "The request options", requestType, new Constant(null, requestType), true);
                    parameters.Insert (parameters.Count, requestOptions);

                    Request request = new Request (method.Request.HttpMethod, method.Request.PathSegments, method.Request.Query, method.Request.Headers, body);
                    RestClientMethod restClientMethod = new RestClientMethod (method.Name, method.Description, method.ReturnType, request, parameters.ToArray(), method.Responses, method.HeaderModel, method.BufferResponse, method.Accessibility);
                    Diagnostic diagnostic = new Diagnostic($"{Declaration.Name}.{method.Name}");
                    yield return new LowLevelClientMethod(restClientMethod, diagnostic);
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

        public IReadOnlyCollection<Parameter> GetConstructorParameters(CSharpType credentialType)
        {
            return RestClientBuilder.GetConstructorParameters(Parameters, credentialType, true);
        }
    }
}
