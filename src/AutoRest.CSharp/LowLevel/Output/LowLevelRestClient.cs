// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Responses;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Request = AutoRest.CSharp.Output.Models.Requests.Request;

namespace AutoRest.CSharp.Output.Models
{
    internal class LowLevelRestClient : TypeProvider
    {
        private static readonly Parameter ClientDiagnosticsParameter = new("clientDiagnostics", "The ClientDiagnostics instance to use", new CSharpType(typeof(ClientDiagnostics)), null, true);
        private static readonly Parameter PipelineParameter = new("pipeline", "The pipeline instance to use", new CSharpType(typeof(HttpPipeline)), null, true);
        private static readonly Parameter KeyAuthParameter = new("keyCredential", "The key credential to copy", new CSharpType(typeof(AzureKeyCredential)), null, false);
        private static readonly Parameter TokenAuthParameter = new("tokenCredential", "The token credential to copy", new CSharpType(typeof(TokenCredential)), null, false);

        protected override string DefaultName { get; }
        protected override string DefaultAccessibility { get; } = "public";

        private readonly bool _hasPublicConstructors;
        private readonly Dictionary<string, FieldDeclaration> _parameterNamesToFields;
        private readonly FieldDeclaration? _keyAuthField;
        private readonly FieldDeclaration? _tokenAuthField;
        private MethodSignature? _subClientInternalConstructor;

        public string Description { get; }
        public MethodSignature[] PublicConstructors { get; }
        public MethodSignature SubClientInternalConstructor => _subClientInternalConstructor ??= BuildSubClientInternalConstructor();

        public IReadOnlyList<RestClientMethod> RequestMethods;
        public IReadOnlyList<LowLevelClientMethod> ClientMethods { get; }

        public FieldDeclaration? AuthorizationHeaderConstant { get; }
        public FieldDeclaration? ScopesConstant { get; }

        public FieldDeclaration ClientDiagnosticsField { get; }
        public FieldDeclaration PipelineField { get; }
        public IReadOnlyList<FieldDeclaration> Fields { get; }
        public IReadOnlyList<Parameter> Parameters { get; }
        public ClientOptionsTypeProvider ClientOptions { get; }

        public string? ParentClientTypeName { get; }

        public bool IsSubClient => ParentClientTypeName != null;

        public static LowLevelRestClient CreateEmptyTopLevelClient(BuildContext<LowLevelOutputLibrary> context, ClientOptionsTypeProvider clientOptions)
        {
            var operationGroup = new OperationGroup { Key = string.Empty };
            var endpointParameter = context.CodeModel.GlobalParameters.FirstOrDefault(RestClientBuilder.IsEndpointParameter);
            var clientParameters = endpointParameter != null ? new[] { endpointParameter } : Array.Empty<RequestParameter>();
            return new(operationGroup, new RestClientBuilder(clientParameters, context), context, clientOptions, null);
        }

        public LowLevelRestClient(OperationGroup operationGroup, BuildContext<LowLevelOutputLibrary> context, ClientOptionsTypeProvider clientOptions, string? parentClientTypeName)
            : this(operationGroup, new RestClientBuilder(operationGroup, context), context, clientOptions, parentClientTypeName) { }

        private LowLevelRestClient(OperationGroup operationGroup, RestClientBuilder builder, BuildContext<LowLevelOutputLibrary> context, ClientOptionsTypeProvider clientOptions, string? parentClientTypeName)
            : base(context)
        {
            var clientPrefix = ClientBuilder.GetClientPrefix(operationGroup.Language.Default.Name, context);
            DefaultName = clientPrefix + (parentClientTypeName != null ? string.Empty : ClientBuilder.GetClientSuffix(context));
            Description = BuilderHelpers.EscapeXmlDescription(ClientBuilder.CreateDescription(operationGroup, ClientBuilder.GetClientPrefix(Declaration.Name, context)));

            ClientOptions = clientOptions;
            if (ExistingType != null && context.SourceInputModel != null && context.SourceInputModel.TryGetClientSourceInput(ExistingType, out var codeGenClientAttribute))
            {
                ParentClientTypeName = codeGenClientAttribute.ParentClientType?.Name;
            }
            else if (ParentClientTypeName == null && !string.IsNullOrEmpty(parentClientTypeName) && !string.IsNullOrEmpty(operationGroup.Language.Default.Name))
            {
                ParentClientTypeName = parentClientTypeName;
            }

            _hasPublicConstructors = !IsSubClient;

            Parameters = builder.GetOrderedParameters();

            ClientDiagnosticsField = new("private readonly", typeof(ClientDiagnostics), "_" + ClientDiagnosticsParameter.Name);
            PipelineField = new("private readonly", typeof(HttpPipeline), "_" + PipelineParameter.Name);

            _parameterNamesToFields = new Dictionary<string, FieldDeclaration>
            {
                [PipelineParameter.Name] = PipelineField,
                [ClientDiagnosticsParameter.Name] = ClientDiagnosticsField
            };

            var fields = new List<FieldDeclaration>();
            foreach (var scheme in context.CodeModel.Security.Schemes)
            {
                switch (scheme)
                {
                    case AzureKeySecurityScheme azureKeySecurityScheme:
                        AuthorizationHeaderConstant = new("private const", typeof(string), "AuthorizationHeader", $"{azureKeySecurityScheme.HeaderName:L}");
                        _keyAuthField = new("private readonly", KeyAuthParameter.Type.WithNullable(true), "_" + KeyAuthParameter.Name);

                        fields.Add(AuthorizationHeaderConstant);
                        fields.Add(_keyAuthField);
                        _parameterNamesToFields[KeyAuthParameter.Name] = _keyAuthField;
                        break;
                    case AADTokenSecurityScheme aadTokenSecurityScheme:
                        ScopesConstant = new("private static readonly", typeof(string[]), "AuthorizationScopes", $"new string[]{{ {aadTokenSecurityScheme.Scopes.GetLiteralsFormattable()} }}");
                        _tokenAuthField = new("private readonly", TokenAuthParameter.Type.WithNullable(true), "_" + TokenAuthParameter.Name);

                        fields.Add(ScopesConstant);
                        fields.Add(_tokenAuthField);
                        _parameterNamesToFields[TokenAuthParameter.Name] = _tokenAuthField;
                        break;
                }
            }

            fields.Add(PipelineField);
            fields.Add(ClientDiagnosticsField);

            foreach (Parameter parameter in Parameters)
            {
                var field = new FieldDeclaration("private readonly", parameter.Type, "_" + parameter.Name);
                fields.Add(field);
                _parameterNamesToFields.Add(parameter.Name, field);
            }

            Fields = fields;

            PublicConstructors = BuildPublicConstructors().ToArray();

            var requestMethods = BuildRequestMethods(operationGroup, builder);

            var clientMethods = BuildMethods(Declaration.Name, requestMethods).ToArray();
            ClientMethods = clientMethods
                .OrderBy(m => m.IsLongRunning ? 2 : m.PagingInfo != null ? 1 : 0) // Temporary sorting to minimize amount of changed files. Will be removed when new LRO is implemented
                .ToArray();

            RequestMethods = ClientMethods.Select(m => m.RequestMethod)
                .Concat(ClientMethods.Select(m => m.PagingInfo?.NextPageMethod).WhereNotNull())
                .Distinct()
                .ToArray();
        }

        public FieldDeclaration? GetFieldByParameter(Parameter parameter)
            => parameter.Name switch
            {
                "credential" when parameter.Type.EqualsIgnoreNullable(KeyAuthParameter.Type) => _keyAuthField,
                "credential" when parameter.Type.EqualsIgnoreNullable(TokenAuthParameter.Type) => _tokenAuthField,
                var name => _parameterNamesToFields.TryGetValue(name, out var field) ? field : null
            };

        private static IReadOnlyDictionary<ServiceRequest, RestClientMethod> BuildRequestMethods(OperationGroup operationGroup, RestClientBuilder builder)
        {
            var requestMethods = new Dictionary<ServiceRequest, RestClientMethod>();

            foreach (var operation in operationGroup.Operations)
            {
                foreach (ServiceRequest serviceRequest in operation.Requests)
                {
                    // See also DataPlaneRestClient::EnsureNormalMethods if changing
                    if (serviceRequest.Protocol.Http is not HttpRequest httpRequest)
                    {
                        continue;
                    }

                    // Prepare our parameter list. If there were any parameters that should be passed in the body of the request,
                    // we want to generate a single parameter of type `RequestContent` named `requestBody` paramter. We want that
                    // parameter to be the last required parameter in the method signature (so any required path or query parameters
                    // will show up first.

                    var requestParameters = serviceRequest.Parameters.Where(FilterServiceParameters).ToList();
                    var accessibility = operation.Accessibility ?? "public";

                    RestClientMethod method = builder.BuildMethod(operation, httpRequest, requestParameters, null, accessibility);
                    RequestHeader[] requestHeaders = method.Request.Headers;
                    List<Parameter> parameters = method.Parameters.ToList();
                    RequestBody? body = null;

                    if (serviceRequest.Parameters.Any(p => p.In == ParameterLocation.Body))
                    {
                        // If any body parameter is required, mark the entire request content as required.
                        bool isBodyRequired = serviceRequest.Parameters.Any(p => p.In == ParameterLocation.Body && p.IsRequired);

                        // The service request had some parameters for the body, so create a parameter for the body and inject it into the list of parameters,
                        // right before the first optional parameter.
                        Parameter bodyParameter = new Parameter("content", "The content to send as the body of the request.", typeof(RequestContent), null, isBodyRequired);
                        int bodyIndex = parameters.FindIndex(p => p.DefaultValue != null);
                        if (bodyIndex == -1)
                        {
                            bodyIndex = parameters.Count;
                        }
                        parameters.Insert(bodyIndex, bodyParameter);
                        body = new RequestContentRequestBody(bodyParameter);

                        // If there's a Content-Type parameter in the parameters list, move it to after the parameter for the body, and change the
                        // type to be `Content-Type`
                        RequestParameter contentTypeRequestParameter = requestParameters.FirstOrDefault(IsSynthesizedContentTypeParameter);
                        if (contentTypeRequestParameter != null)
                        {
                            int contentTypeParamIndex = parameters.FindIndex(p => p.Name == contentTypeRequestParameter.CSharpName());

                            // If the service parameter has a constant value (which is the case in general, because most operations only use
                            // a single content type), it will not be in the parameter list for the operation method.
                            if (contentTypeParamIndex != -1)
                            {
                                Parameter contentTypeParameter = parameters[contentTypeParamIndex] with { Type = new CSharpType(typeof(Azure.Core.ContentType)) };

                                parameters.RemoveAt(contentTypeParamIndex);

                                // If the Content-Type parameter came before the the body, the removal of it above shifted the body parameter
                                // closer to the start of the list.
                                if (contentTypeParamIndex < bodyIndex)
                                {
                                    bodyIndex--;
                                }

                                parameters.Insert(bodyIndex + 1, contentTypeParameter);

                                // The request headers will have a reference to the parameter we've just updated the type of, so we need to update that reference as well.
                                for (int i = 0; i < requestHeaders.Length; i++)
                                {
                                    var requestHeader = requestHeaders[i];
                                    if (!requestHeader.Value.IsConstant && requestHeader.Value.Reference.Name == contentTypeParameter.Name)
                                    {
                                        requestHeaders[i] = new RequestHeader(requestHeader.Name, contentTypeParameter, requestHeader.SerializationStyle, requestHeader.Format);
                                    }
                                }
                            }
                        }
                    }

                    var request = new Request (method.Request.HttpMethod, method.Request.PathSegments, method.Request.Query, requestHeaders, body);

                    requestMethods.Add(serviceRequest, new RestClientMethod(method.Name, method.Description, method.ReturnType, request, parameters.ToArray(), method.Responses, method.HeaderModel, method.BufferResponse, method.Accessibility, operation));
                }
            }

            return requestMethods;
        }

        private static IEnumerable<LowLevelClientMethod> BuildMethods(string clientName, IReadOnlyDictionary<ServiceRequest, RestClientMethod> requestMethods)
        {
            foreach (var (request, method) in requestMethods)
            {
                var operation = method.Operation;
                var paging = operation.Language.Default.Paging;
                Schema? requestSchema = request.Parameters.FirstOrDefault(p => p.In == ParameterLocation.Body)?.Schema;
                Schema? responseSchema = operation.Responses.FirstOrDefault()?.ResponseSchema;
                Schema? exceptionSchema = operation.Exceptions.FirstOrDefault()?.ResponseSchema;
                var operationSchemas = new LowLevelOperationSchemaInfo(requestSchema, responseSchema, exceptionSchema);
                var diagnostic = new Diagnostic($"{clientName}.{method.Name}");

                LowLevelPagingInfo? pagingInfo = null;
                if (paging != null)
                {
                    if (!operation.IsLongRunning && method.Responses.SingleOrDefault(r => r.ResponseBody != null)?.ResponseBody is not ObjectResponseBody)
                    {
                        throw new InvalidOperationException($"Method {method.Name} has to have a return value");
                    }

                    var nextLinkOperation = paging.NextLinkOperation;
                    var nextLinkName = paging.NextLinkName;

                    RestClientMethod? nextPageMethod = nextLinkOperation != null
                        ? requestMethods[nextLinkOperation.Requests.Single()]
                        : nextLinkName != null ? RestClientBuilder.BuildNextPageMethod(method) : null;

                    pagingInfo = new LowLevelPagingInfo(nextPageMethod, nextLinkName, paging.ItemName ?? "value");
                }

                yield return new LowLevelClientMethod(method, operationSchemas, diagnostic, pagingInfo, operation.IsLongRunning);
            }
        }

        private IEnumerable<MethodSignature> BuildPublicConstructors()
        {
            if (!_hasPublicConstructors)
            {
                yield break;
            }

            var clientOptionsType = ClientOptions.Type.WithNullable(true);
            var clientOptionsParameter = new Parameter("options", "The options for configuring the client.", clientOptionsType, Constant.NewInstanceOf(clientOptionsType), false);

            if (_keyAuthField != null)
            {
                yield return BuildPublicConstructor(_keyAuthField, clientOptionsParameter);
            }

            if (_tokenAuthField != null)
            {
                yield return BuildPublicConstructor(_tokenAuthField, clientOptionsParameter);
            }

            if (_keyAuthField == null && _tokenAuthField == null)
            {
                yield return BuildPublicConstructor(null, clientOptionsParameter);
            }
        }

        private MethodSignature BuildPublicConstructor(FieldDeclaration? credentialField, Parameter clientOptionsParameter)
        {
            var constructorParameters = RestClientBuilder.GetConstructorParameters(Parameters, credentialField?.Type).Append(clientOptionsParameter).ToArray();
            return new MethodSignature(Declaration.Name, $"Initializes a new instance of {Declaration.Name}", "public", constructorParameters);
        }

        private MethodSignature BuildSubClientInternalConstructor()
        {
            var constructorParameters = new[]{ClientDiagnosticsParameter, PipelineParameter, KeyAuthParameter, TokenAuthParameter}
                .Concat(RestClientBuilder.GetConstructorParameters(Parameters, null, includeAPIVersion: true))
                .Where(p => GetFieldByParameter(p) != null)
                .ToArray();

            return new MethodSignature(Declaration.Name, $"Initializes a new instance of {Declaration.Name}", "internal", constructorParameters);
        }

        private static bool FilterServiceParameters(RequestParameter p)
            => p.In switch
            {
                ParameterLocation.Header => true,
                ParameterLocation.Query => true,
                ParameterLocation.Path => true,
                ParameterLocation.Uri => true,
                _ => false
            };

        private static bool IsSynthesizedContentTypeParameter(RequestParameter p)
            => p.Origin == "modelerfour:synthesized/content-type";
    }
}
