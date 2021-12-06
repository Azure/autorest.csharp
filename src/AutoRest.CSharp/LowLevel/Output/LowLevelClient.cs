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
using AutoRest.CSharp.Output.Models.Responses;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Operation = AutoRest.CSharp.Input.Operation;

namespace AutoRest.CSharp.Output.Models
{
    internal class LowLevelClient : TypeProvider
    {
        public static readonly Parameter ClientDiagnosticsParameter = new("clientDiagnostics", "The ClientDiagnostics instance to use", new CSharpType(typeof(ClientDiagnostics)), null, true);
        public static readonly Parameter PipelineParameter = new("pipeline", "The pipeline instance to use", new CSharpType(typeof(HttpPipeline)), null, true);
        public static readonly Parameter KeyAuthParameter = new("keyCredential", "The key credential to copy", new CSharpType(typeof(AzureKeyCredential)), null, false);
        public static readonly Parameter TokenAuthParameter = new("tokenCredential", "The token credential to copy", new CSharpType(typeof(TokenCredential)), null, false);

        protected override string DefaultName { get; }
        protected override string DefaultAccessibility { get; } = "public";

        private readonly bool _hasPublicConstructors;
        private MethodSignature? _subClientInternalConstructor;

        public string Description { get; }
        public MethodSignature[] PublicConstructors { get; }
        public MethodSignature SubClientInternalConstructor => _subClientInternalConstructor ??= BuildSubClientInternalConstructor();

        public IReadOnlyList<RestClientMethod> RequestMethods;
        public IReadOnlyList<LowLevelClientMethod> ClientMethods { get; }

        public ClientOptionsTypeProvider ClientOptions { get; }
        public IReadOnlyList<Parameter> Parameters { get; }
        public ClientFields Fields { get; }

        public string? ParentClientTypeName { get; }

        public bool IsSubClient => ParentClientTypeName != null;

        public static LowLevelClient CreateEmptyTopLevelClient(BuildContext<LowLevelOutputLibrary> context, ClientOptionsTypeProvider clientOptions)
        {
            var operationGroup = new OperationGroup { Key = string.Empty };
            var endpointParameter = context.CodeModel.GlobalParameters.FirstOrDefault(RestClientBuilder.IsEndpointParameter);
            var clientParameters = endpointParameter != null ? new[] { endpointParameter } : Array.Empty<RequestParameter>();
            return new(operationGroup, new RestClientBuilder(clientParameters, context), context, clientOptions, null);
        }

        public LowLevelClient(OperationGroup operationGroup, BuildContext<LowLevelOutputLibrary> context, ClientOptionsTypeProvider clientOptions, string? parentClientTypeName)
            : this(operationGroup, new RestClientBuilder(operationGroup, context), context, clientOptions, parentClientTypeName) { }

        private LowLevelClient(OperationGroup operationGroup, RestClientBuilder builder, BuildContext<LowLevelOutputLibrary> context, ClientOptionsTypeProvider clientOptions, string? parentClientTypeName)
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
            Fields = new ClientFields(context, Parameters);

            PublicConstructors = BuildPublicConstructors().ToArray();

            var clientMethods = BuildMethods(builder, operationGroup.Operations, Declaration.Name);

            ClientMethods = clientMethods
                .OrderBy(m => m.IsLongRunning ? 2 : m.PagingInfo != null ? 1 : 0) // Temporary sorting to minimize amount of changed files. Will be removed when new LRO is implemented
                .ToArray();

            RequestMethods = ClientMethods.Select(m => m.RequestMethod)
                .Concat(ClientMethods.Select(m => m.PagingInfo?.NextPageMethod).WhereNotNull())
                .Distinct()
                .ToArray();
        }

        private static IEnumerable<LowLevelClientMethod> BuildMethods(RestClientBuilder builder, IEnumerable<Operation> operations, string clientName)
        {
            var requestMethods = new Dictionary<ServiceRequest, RestClientMethod>();
            foreach (var operation in operations)
            {
                foreach (ServiceRequest serviceRequest in operation.Requests)
                {
                    // See also DataPlaneRestClient::EnsureNormalMethods if changing
                    if (serviceRequest.Protocol.Http is not HttpRequest httpRequest)
                    {
                        continue;
                    }

                    requestMethods.Add(serviceRequest, builder.BuildRequestMethod(operation, serviceRequest, httpRequest));
                }
            }

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

            if (Fields.CredentialFields.Count == 0)
            {
                yield return BuildPublicConstructor(null, clientOptionsParameter);
            }
            else
            {
                foreach (var credentialField in Fields.CredentialFields)
                {
                    yield return BuildPublicConstructor(credentialField, clientOptionsParameter);
                }
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
                .Where(p => Fields.GetFieldByParameter(p) != null)
                .ToArray();

            return new MethodSignature(Declaration.Name, $"Initializes a new instance of {Declaration.Name}", "internal", constructorParameters);
        }
    }
}
