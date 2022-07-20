﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
using Azure.Core;
using Operation = AutoRest.CSharp.Input.Operation;
using static AutoRest.CSharp.Output.Models.MethodSignatureModifiers;

namespace AutoRest.CSharp.Output.Models
{
    internal class LowLevelClient : TypeProvider
    {
        protected override string DefaultName { get; }
        protected override string DefaultNamespace { get; }
        protected override string DefaultAccessibility => "public";

        private ConstructorSignature? _subClientInternalConstructor;

        public string Description { get; }
        public ConstructorSignature[] PrimaryConstructors { get; }
        public ConstructorSignature[] SecondaryConstructors { get; }
        public ConstructorSignature SubClientInternalConstructor => _subClientInternalConstructor ??= BuildSubClientInternalConstructor();

        public IReadOnlyList<LowLevelClient> SubClients { get; init; }
        public IReadOnlyList<RestClientMethod> RequestMethods { get; }
        public IReadOnlyList<LowLevelClientMethod> ClientMethods { get; }
        public LowLevelClient? ParentClient;
        public LowLevelSubClientFactoryMethod? FactoryMethod { get; }

        public ClientOptionsTypeProvider ClientOptions { get; }
        public IReadOnlyList<Parameter> Parameters { get; }
        public ClientFields Fields { get; }
        public bool IsSubClient { get; }
        public bool IsResourceClient { get; }

        public LowLevelClient(string name, string ns, string description, LowLevelClient? parentClient, IEnumerable<(ServiceRequest ServiceRequest, Operation Operation)> serviceRequests, RestClientBuilder builder, BuildContext<LowLevelOutputLibrary> context, ClientOptionsTypeProvider clientOptions)
            : base(context)
        {
            DefaultName = name;
            DefaultNamespace = ns;
            Description = BuilderHelpers.EscapeXmlDescription(string.IsNullOrWhiteSpace(description)
                ? $"The {ClientBuilder.GetClientPrefix(Declaration.Name, context)} service client."
                : BuilderHelpers.EscapeXmlDescription(description));
            IsSubClient = parentClient != null;
            ParentClient = parentClient;

            ClientOptions = clientOptions;

            Parameters = builder.GetOrderedParametersByRequired();
            IsResourceClient = Parameters.Any(p => p.IsResourceIdentifier);
            Fields = ClientFields.CreateForClient(Parameters, context);

            (PrimaryConstructors, SecondaryConstructors) = BuildPublicConstructors(Parameters);

            var clientMethods = BuildMethods(builder, serviceRequests, Declaration.Name).ToArray();

            ClientMethods = clientMethods
                .OrderBy(m => m.IsLongRunning ? 2 : m.PagingInfo != null ? 1 : 0) // Temporary sorting to minimize amount of changed files. Will be removed when new LRO is implemented
                .ToArray();

            RequestMethods = clientMethods.Select(m => m.RequestMethod)
                .Concat(ClientMethods.Select(m => m.PagingInfo?.NextPageMethod).WhereNotNull())
                .Distinct()
                .ToArray();

            FactoryMethod = parentClient != null ? BuildFactoryMethod(parentClient.Fields) : null;

            SubClients = Array.Empty<LowLevelClient>();
        }

        public static IEnumerable<LowLevelClientMethod> BuildMethods(RestClientBuilder builder, IEnumerable<(ServiceRequest ServiceRequest, Operation Operation)> serviceRequests, string clientName)
        {
            var requestMethods = new Dictionary<ServiceRequest, RestClientMethod>();
            foreach (var (serviceRequest, operation) in serviceRequests)
            {
                // See also DataPlaneRestClient::EnsureNormalMethods if changing
                if (serviceRequest.Protocol.Http is not HttpRequest httpRequest)
                {
                    continue;
                }

                requestMethods.Add(serviceRequest, builder.BuildRequestMethod(operation, serviceRequest, httpRequest));
            }

            foreach (var (request, requestMethod) in requestMethods)
            {
                var operation = requestMethod.Operation;
                var paging = operation.Language.Default.Paging;
                Schema? requestSchema = request.Parameters.FirstOrDefault(p => p.In == HttpParameterIn.Body)?.Schema;
                Schema? responseSchema = operation.Responses.FirstOrDefault()?.ResponseSchema;
                Schema? exceptionSchema = operation.Exceptions.FirstOrDefault()?.ResponseSchema;
                var operationSchemas = new LowLevelOperationSchemaInfo(requestSchema, responseSchema, exceptionSchema);
                var diagnostic = new Diagnostic($"{clientName}.{requestMethod.Name}");

                LowLevelPagingInfo? pagingInfo = null;
                CSharpType returnType;
                if (paging != null)
                {
                    if (!operation.IsLongRunning && requestMethod.Responses.SingleOrDefault(r => r.ResponseBody != null)?.ResponseBody is not ObjectResponseBody)
                    {
                        throw new InvalidOperationException($"Method {requestMethod.Name} has to have a return value");
                    }

                    var nextLinkOperation = paging.NextLinkOperation;
                    var nextLinkName = paging.NextLinkName;

                    RestClientMethod? nextPageMethod = nextLinkOperation != null
                        ? requestMethods[nextLinkOperation.Requests.Single()]
                        : nextLinkName != null ? RestClientBuilder.BuildNextPageMethod(requestMethod) : null;

                    pagingInfo = new LowLevelPagingInfo(nextPageMethod, nextLinkName, paging.ItemName ?? "value");
                    returnType = operation.IsLongRunning
                        ? typeof(Azure.Operation<Azure.Pageable<BinaryData>>)
                        : typeof(Azure.Pageable<BinaryData>);
                }
                else
                {
                    var headAsBoolean = requestMethod.Request.HttpMethod == RequestMethod.Head && Configuration.HeadAsBoolean;
                    returnType = operation.IsLongRunning
                        ? ((responseSchema != null) ? typeof(Azure.Operation<BinaryData>) : typeof(Azure.Operation))
                        : headAsBoolean
                            ? typeof(Azure.Response<bool>)
                            : typeof(Azure.Response);
                }

                var parameters = operation.IsLongRunning
                    ? requestMethod.Parameters.Prepend(KnownParameters.WaitForCompletion).ToArray()
                    : requestMethod.Parameters;
                var methodSignature = new MethodSignature(requestMethod.Name, requestMethod.Summary, requestMethod.Description, requestMethod.Accessibility | Virtual, returnType, null, parameters);

                yield return new LowLevelClientMethod(methodSignature, requestMethod, operationSchemas, diagnostic, pagingInfo, operation.IsLongRunning);
            }
        }


        private (ConstructorSignature[] PrimaryConstructors, ConstructorSignature[] SecondaryConstructors) BuildPublicConstructors(IReadOnlyList<Parameter> orderedParameters)
        {
            if (!IsSubClient)
            {
                var requiredParameters = RestClientBuilder.GetRequiredParameters(orderedParameters).ToArray();
                var optionalParameters = RestClientBuilder.GetOptionalParameters(orderedParameters).Append(CreateOptionsParameter()).ToArray();

                return (
                    BuildPrimaryConstructors(requiredParameters, optionalParameters).ToArray(),
                    BuildSecondaryConstructors(requiredParameters, optionalParameters).ToArray()
                );
            }
            else
            {
                return (Array.Empty<ConstructorSignature>(), new[] { CreateMockingConstructor() });
            }
        }

        private IEnumerable<ConstructorSignature> BuildPrimaryConstructors(IReadOnlyList<Parameter> requiredParameters, IReadOnlyList<Parameter> optionalParameters)
        {
            var optionalToRequired = optionalParameters
                .Select(parameter => ClientOptions.Type.EqualsIgnoreNullable(parameter.Type)
                ? parameter with { DefaultValue = null, Validation = ValidationType.None }
                : parameter with
                {
                    DefaultValue = null,
                    Validation = parameter.Initializer != null ? Parameter.GetValidation(parameter.Type, parameter.RequestLocation, parameter.SkipUrlEncoding) : parameter.Validation,
                    Initializer = null
                }).ToArray();

            if (Fields.CredentialFields.Count == 0)
            {
                yield return CreatePrimaryConstructor(requiredParameters.Concat(optionalToRequired).ToArray());
            }
            else
            {
                foreach (var credentialField in Fields.CredentialFields)
                {
                    yield return CreatePrimaryConstructor(requiredParameters.Append(CreateCredentialParameter(credentialField!.Type)).Concat(optionalToRequired).ToArray());
                }
            }
        }

        private IEnumerable<ConstructorSignature> BuildSecondaryConstructors(IReadOnlyList<Parameter> requiredParameters, IReadOnlyList<Parameter> optionalParameters)
        {
            if (requiredParameters.Any() || Fields.CredentialFields.Any())
            {
                yield return CreateMockingConstructor();
            }

            var optionalParametersArguments = optionalParameters
                .Select(p => p.Initializer ?? Parameter.GetParameterInitializer(p.Type, p.DefaultValue!.Value)!)
                .ToArray();

            if (Fields.CredentialFields.Count == 0)
            {
                yield return CreateSecondaryConstructor(requiredParameters, optionalParametersArguments);
            }
            else
            {
                foreach (var credentialField in Fields.CredentialFields)
                {
                    yield return CreateSecondaryConstructor(requiredParameters.Append(CreateCredentialParameter(credentialField!.Type)).ToArray(), optionalParametersArguments);
                }
            }
        }

        private ConstructorSignature CreatePrimaryConstructor(IReadOnlyList<Parameter> parameters)
            => new(Declaration.Name, $"Initializes a new instance of {Declaration.Name}", null, Public, parameters);

        private ConstructorSignature CreateSecondaryConstructor(IReadOnlyList<Parameter> parameters, FormattableString[] optionalParametersArguments)
        {
            var arguments = parameters
                .Select<Parameter, FormattableString>(p => $"{p.Name}")
                .Concat(optionalParametersArguments)
                .ToArray();
            return new(Declaration.Name, $"Initializes a new instance of {Declaration.Name}", null, Public, parameters, new ConstructorInitializer(false, arguments));
        }

        private Parameter CreateCredentialParameter(CSharpType type)
        {
            return new Parameter(
                "credential",
                "A credential used to authenticate to an Azure Service.",
                type,
                null,
                ValidationType.AssertNotNull,
                null);
        }

        private ConstructorSignature CreateMockingConstructor()
            => new(Declaration.Name, $"Initializes a new instance of {Declaration.Name} for mocking.", null, Protected, Array.Empty<Parameter>());

        private Parameter CreateOptionsParameter()
        {
            var clientOptionsType = ClientOptions.Type.WithNullable(true);
            return new Parameter("options", "The options for configuring the client.", clientOptionsType, Constant.Default(clientOptionsType), ValidationType.None, Constant.NewInstanceOf(clientOptionsType).GetConstantFormattable());
        }

        private ConstructorSignature BuildSubClientInternalConstructor()
        {
            var constructorParameters = GetSubClientFactoryMethodParameters()
                .Select(p => p with { DefaultValue = null, Validation = ValidationType.None, Initializer = null })
                .ToArray();

            return new ConstructorSignature(Declaration.Name, $"Initializes a new instance of {Declaration.Name}", null, Internal, constructorParameters);
        }

        public LowLevelSubClientFactoryMethod BuildFactoryMethod(ClientFields parentFields)
        {
            var constructorCallParameters = GetSubClientFactoryMethodParameters().ToArray();
            var methodParameters = constructorCallParameters.Where(p => parentFields.GetFieldByParameter(p) == null).ToArray();

            var subClientName = Type.Name;
            var libraryName = Context.DefaultLibraryName;
            var methodName = subClientName.StartsWith(libraryName)
                ? subClientName[libraryName.Length..]
                : subClientName;

            if (!IsResourceClient)
            {
                methodName += ClientBuilder.GetClientSuffix(Context);
            }

            var methodSignature = new MethodSignature($"Get{methodName}",
                $"Initializes a new instance of {Type.Name}", null, Public | Virtual, Type, null,
                methodParameters.ToArray());
            FieldDeclaration? cachingField = methodParameters.Any()
                ? null
                : new FieldDeclaration(FieldModifiers.Private, this.Type, $"_cached{Type.Name}");

            return new LowLevelSubClientFactoryMethod(methodSignature, cachingField, constructorCallParameters);
        }

        private IEnumerable<Parameter> GetSubClientFactoryMethodParameters()
            => new[] { KnownParameters.ClientDiagnostics, KnownParameters.Pipeline, KnownParameters.KeyAuth, KnownParameters.TokenAuth }
                .Concat(RestClientBuilder.GetConstructorParameters(Parameters, null, includeAPIVersion: true))
                .Where(p => Fields.GetFieldByParameter(p) != null);
    }
}
