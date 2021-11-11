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
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Request = AutoRest.CSharp.Output.Models.Requests.Request;

namespace AutoRest.CSharp.Output.Models
{
    internal class LowLevelRestClient : RestClient
    {
        private static readonly Parameter ClientDiagnosticsParameter = new("clientDiagnostics", "The ClientDiagnostics instance to use", new CSharpType(typeof(ClientDiagnostics)), null, true);
        private static readonly Parameter PipelineParameter = new("pipeline", "The pipeline instance to use", new CSharpType(typeof(HttpPipeline)), null, true);
        private static readonly Parameter KeyAuthParameter = new("keyCredential", "The key credential to copy", new CSharpType(typeof(AzureKeyCredential)), null, false);
        private static readonly Parameter TokenAuthParameter = new("tokenCredential", "The token credential to copy", new CSharpType(typeof(TokenCredential)), null, false);

        protected override string DefaultAccessibility { get; } = "public";

        private readonly BuildContext<LowLevelOutputLibrary> _context;
        private readonly bool _hasPublicConstructors = true;
        private readonly Dictionary<string, FieldDeclaration> _parametersToFields;

        private LowLevelClientMethod[]? _clientMethods;
        private LowLevelPagingMethod[]? _pagingMethods;
        private LowLevelLongRunningOperationMethod[]? _longRunningOperationMethods;
        private MethodSignature[]? _constructors;
        private MethodSignature? _subClientInternalConstructor;

        public override string Description => BuilderHelpers.EscapeXmlDescription(ClientBuilder.CreateDescription(OperationGroup, ClientBuilder.GetClientPrefix(Declaration.Name, _context)));
        public MethodSignature[] PublicConstructors => _constructors ??= BuildPublicConstructors().ToArray();
        public LowLevelClientMethod[] ClientMethods => _clientMethods ??= BuildMethods().ToArray();
        public LowLevelPagingMethod[] PagingMethods => _pagingMethods ??= BuildPagingMethods().ToArray();
        public LowLevelLongRunningOperationMethod[] LongRunningOperationMethods => _longRunningOperationMethods ??= BuildLongRunningOperationMethods().ToArray();

        public FieldDeclaration? AuthorizationHeaderConstant { get; }
        public FieldDeclaration? ScopesConstant { get; }

        public FieldDeclaration ClientDiagnosticsField { get; }
        public FieldDeclaration PipelineField { get; }
        public FieldDeclaration? KeyAuthField { get; }
        public FieldDeclaration? TokenAuthField { get; }
        public IReadOnlyList<FieldDeclaration> Fields { get; }
        public ClientOptionsTypeProvider ClientOptions { get; }

        public MethodSignature SubClientInternalConstructor => _subClientInternalConstructor ??= BuildSubClientInternalConstructor();
        public string? ParentClientTypeName { get; }

        public bool IsSubClient => ParentClientTypeName != null;

        public static LowLevelRestClient CreateEmptyTopLevelClient(BuildContext<LowLevelOutputLibrary> context, ClientOptionsTypeProvider clientOptions)
        {
            var operationGroup = new OperationGroup { Key = string.Empty };
            var endpointParameter = context.CodeModel.GlobalParameters.FirstOrDefault(RestClientBuilder.IsEndpointParameter);
            var clientParameters = endpointParameter != null ? new[] { endpointParameter } : Array.Empty<RequestParameter>();
            return new(operationGroup, clientParameters, context, clientOptions, null);
        }

        public LowLevelRestClient(OperationGroup operationGroup, BuildContext<LowLevelOutputLibrary> context, ClientOptionsTypeProvider clientOptions, string? parentClientTypeName)
            : this(operationGroup, null, context, clientOptions, parentClientTypeName) { }

        private LowLevelRestClient(OperationGroup operationGroup, IEnumerable<RequestParameter>? clientParameters, BuildContext<LowLevelOutputLibrary> context, ClientOptionsTypeProvider clientOptions, string? parentClientTypeName)
            : base(operationGroup, clientParameters, context, ClientBuilder.GetClientPrefix(operationGroup.Language.Default.Name, context), parentClientTypeName != null ? string.Empty : ClientBuilder.GetClientSuffix(context))
        {
            _context = context;
            ClientOptions = clientOptions;
            if (ExistingType != null && context.SourceInputModel != null && context.SourceInputModel.TryGetClientSourceInput(ExistingType, out var codeGenClientAttribute))
            {
                ParentClientTypeName = codeGenClientAttribute.ParentClientType?.Name;
                _hasPublicConstructors = !IsSubClient || codeGenClientAttribute.ForcePublicConstructors;
            }
            else if (ParentClientTypeName == null && !string.IsNullOrEmpty(parentClientTypeName) && !string.IsNullOrEmpty(operationGroup.Language.Default.Name))
            {
                ParentClientTypeName = parentClientTypeName;
                _hasPublicConstructors = false;
            }

            ClientDiagnosticsField = new("private readonly", typeof(ClientDiagnostics), "_" + ClientDiagnosticsParameter.Name);
            PipelineField = new("private readonly", typeof(HttpPipeline), "_" + PipelineParameter.Name);

            var fields = new List<FieldDeclaration>();
            foreach (var scheme in context.CodeModel.Security.Schemes)
            {
                switch (scheme)
                {
                    case AzureKeySecurityScheme azureKeySecurityScheme:
                        AuthorizationHeaderConstant = new("private const", typeof(string), "AuthorizationHeader", $"{azureKeySecurityScheme.HeaderName:L}");
                        KeyAuthField = new("private readonly", KeyAuthParameter.Type.WithNullable(true), "_" + KeyAuthParameter.Name);
                        fields.Add(AuthorizationHeaderConstant);
                        break;
                    case AADTokenSecurityScheme aadTokenSecurityScheme:
                        ScopesConstant = new("private static readonly", typeof(string[]), "AuthorizationScopes", $"new string[]{{ {aadTokenSecurityScheme.Scopes.GetLiteralsFormattable()} }}");
                        TokenAuthField = new("private readonly", TokenAuthParameter.Type.WithNullable(true), "_" + TokenAuthParameter.Name);
                        fields.Add(ScopesConstant);
                        break;
                }
            }

            _parametersToFields = new Dictionary<string, FieldDeclaration>();
            foreach (var (parameterName, fieldDeclaration) in GetParametersToFields(Parameters))
            {
                if (fieldDeclaration != null)
                {
                    _parametersToFields[parameterName] = fieldDeclaration;
                    fields.Add(fieldDeclaration);
                }
            }

            Fields = fields;
        }

        public FieldDeclaration? GetFieldReferenceByParameter(Parameter parameter)
            => parameter.Name switch
            {
                "credential" when parameter.Type.EqualsIgnoreNullable(KeyAuthParameter.Type) => KeyAuthField,
                "credential" when parameter.Type.EqualsIgnoreNullable(TokenAuthParameter.Type) => TokenAuthField,
                var name => _parametersToFields.TryGetValue(name, out var field) ? field : null
            };

        protected override Dictionary<ServiceRequest, RestClientMethod> EnsureNormalMethods()
        {
            var requestMethods = new Dictionary<ServiceRequest, RestClientMethod>();

            foreach (var operation in OperationGroup.Operations)
            {
                foreach (ServiceRequest serviceRequest in operation.Requests)
                {
                    // See also DataPlaneRestClient::EnsureNormalMethods if changing
                    if (!(serviceRequest.Protocol.Http is HttpRequest httpRequest))
                    {
                        continue;
                    }

                    // Prepare our parameter list. If there were any parameters that should be passed in the body of the request,
                    // we want to generate a single parameter of type `RequestContent` named `requestBody` paramter. We want that
                    // parameter to be the last required parameter in the method signature (so any required path or query parameters
                    // will show up first.

                    IEnumerable<RequestParameter> requestParameters = serviceRequest.Parameters.Where(FilterServiceParameters);
                    var accessibility = operation.Accessibility ?? "public";
                    RestClientMethod method = Builder.BuildMethod(operation, httpRequest, requestParameters, null, accessibility);
                    RequestHeader[] requestHeaders = method.Request.Headers;
                    List<Parameter> parameters = method.Parameters.ToList();
                    RequestBody? body = null;

                    if (serviceRequest.Parameters.Any(p => p.In == ParameterLocation.Body))
                    {
                        RequestParameter bodyParameter = serviceRequest.Parameters.First(p => p.In == ParameterLocation.Body);

                        // If any body parameter is required, mark the entire request content as required.
                        bool isBodyRequired = serviceRequest.Parameters.Where(p => p.In == ParameterLocation.Body && p.IsRequired).Any();

                        // The service request had some parameters for the body, so create a parameter for the body and inject it into the list of parameters,
                        // right before the first optional parameter.
                        Parameter bodyParam = new Parameter("content", "The content to send as the body of the request.", typeof(Azure.Core.RequestContent), null, isBodyRequired);
                        int bodyIndex = parameters.FindIndex(p => p.DefaultValue != null);
                        if (bodyIndex == -1)
                        {
                            bodyIndex = parameters.Count;
                        }
                        parameters.Insert(bodyIndex, bodyParam);
                        body = new RequestContentRequestBody(bodyParam);

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

                    Request request = new Request (method.Request.HttpMethod, method.Request.PathSegments, method.Request.Query, requestHeaders, body);

                    requestMethods.Add(serviceRequest, new RestClientMethod(method.Name, method.Description, method.ReturnType, request, parameters.ToArray(), method.Responses, method.HeaderModel, method.BufferResponse, method.Accessibility, operation));
                }
            }

            return requestMethods;
        }

        private IEnumerable<LowLevelClientMethod> BuildMethods()
        {
            foreach (var operation in OperationGroup.Operations)
            {
                if (operation.IsLongRunning || operation.Language.Default.Paging != null)
                {
                    continue;
                }

                foreach (var request in operation.Requests)
                {
                    RestClientMethod method = GetOperationMethod(request);
                    Schema? requestSchema = request.Parameters.FirstOrDefault(p => p.In == ParameterLocation.Body)?.Schema;
                    Schema? responseSchema = operation.Responses.FirstOrDefault()?.ResponseSchema;
                    Schema? exceptionSchema = operation.Exceptions.FirstOrDefault()?.ResponseSchema;

                    yield return new LowLevelClientMethod(
                        method,
                        new LowLevelOperationSchemaInfo(requestSchema, responseSchema, exceptionSchema),
                        new Diagnostic($"{Declaration.Name}.{method.Name}"));
                }
            }
        }

        private IEnumerable<LowLevelPagingMethod> BuildPagingMethods()
        {
            foreach (var operation in OperationGroup.Operations)
            {
                Paging? paging = operation.Language.Default.Paging;
                if (paging == null || operation.IsLongRunning)
                {
                    continue;
                }

                foreach (var request in operation.Requests)
                {
                    RestClientMethod method = GetOperationMethod(request);
                    RestClientMethod? nextPageMethod = GetNextOperationMethod(request);
                    Schema? requestSchema = request.Parameters.FirstOrDefault(p => p.In == ParameterLocation.Body)?.Schema;
                    Schema? responseSchema = operation.Responses.FirstOrDefault()?.ResponseSchema;
                    Schema? exceptionSchema = operation.Exceptions.FirstOrDefault()?.ResponseSchema;

                    if (!(method.Responses.SingleOrDefault(r => r.ResponseBody != null)?.ResponseBody is ObjectResponseBody objectResponseBody))
                    {
                        throw new InvalidOperationException($"Method {method.Name} has to have a return value");
                    }

                    yield return new LowLevelPagingMethod(
                        method,
                        new LowLevelOperationSchemaInfo(requestSchema, responseSchema, exceptionSchema),
                        new Diagnostic($"{Declaration.Name}.{method.Name}"),
                        new LowLevelPagingResponseInfo(
                            nextPageMethod,
                            paging.NextLinkName,
                            paging.ItemName ?? "value")
                        );
                }
            }
        }

        private IEnumerable<LowLevelLongRunningOperationMethod> BuildLongRunningOperationMethods()
        {
            foreach (var operation in OperationGroup.Operations)
            {
                if (operation.IsLongRunning)
                {
                    Paging? paging = operation.Language.Default.Paging;

                    foreach (var request in operation.Requests)
                    {
                        RestClientMethod startMethod = GetOperationMethod(request);
                        Schema? requestSchema = request.Parameters.FirstOrDefault(p => p.In == ParameterLocation.Body)?.Schema;
                        Schema? responseSchema = operation.Responses.FirstOrDefault()?.ResponseSchema;
                        Schema? exceptionSchema = operation.Exceptions.FirstOrDefault()?.ResponseSchema;

                        LowLevelPagingResponseInfo? pagingInfo = null;

                        if (paging != null)
                        {
                            RestClientMethod? nextPageMethod = GetNextOperationMethod(request);
                            pagingInfo = new LowLevelPagingResponseInfo(nextPageMethod, paging.NextLinkName, paging.ItemName ?? "value");
                        }

                        yield return new LowLevelLongRunningOperationMethod(
                            startMethod,
                            new LowLevelOperationSchemaInfo(requestSchema, responseSchema, exceptionSchema),
                            new Diagnostic($"{Declaration.Name}.{startMethod.Name}"),
                            pagingInfo);
                    }
                }
            }
        }

        private IEnumerable<(string ParameterName, FieldDeclaration? Field)> GetParametersToFields(IEnumerable<Parameter> parameters)
        {
            yield return new(KeyAuthParameter.Name, KeyAuthField);
            yield return new(TokenAuthParameter.Name, TokenAuthField);
            yield return new(PipelineParameter.Name, PipelineField);
            yield return new(ClientDiagnosticsParameter.Name, ClientDiagnosticsField);

            foreach (Parameter parameter in parameters)
            {
                yield return new(parameter.Name, new FieldDeclaration("private readonly", parameter.Type, "_" + parameter.Name));
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

            if (KeyAuthField != null)
            {
                yield return BuildPublicConstructor(KeyAuthField, clientOptionsParameter);
            }

            if (TokenAuthField != null)
            {
                yield return BuildPublicConstructor(TokenAuthField, clientOptionsParameter);
            }

            if (KeyAuthField == null && TokenAuthField == null)
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
                .Where(p => _parametersToFields.ContainsKey(p.Name))
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
