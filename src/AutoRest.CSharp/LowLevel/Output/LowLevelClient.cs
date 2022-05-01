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

        private readonly bool _hasPublicConstructors;
        private ConstructorSignature? _subClientInternalConstructor;

        public string Description { get; }
        public ConstructorSignature[] PublicConstructors { get; }
        public ConstructorSignature SubClientInternalConstructor => _subClientInternalConstructor ??= BuildSubClientInternalConstructor();

        public IReadOnlyList<LowLevelClient> SubClients;
        public IReadOnlyList<RestClientMethod> RequestMethods;
        public IReadOnlyList<LowLevelClientMethod> ClientMethods { get; }
        public IReadOnlyList<LowLevelSubClientFactoryMethod> SubClientFactoryMethods { get; }

        public ClientOptionsTypeProvider ClientOptions { get; }
        public IReadOnlyList<Parameter> Parameters { get; }
        public ClientFields Fields { get; }
        public bool IsSubClient { get; }
        public bool IsResourceClient { get; }

        public LowLevelClient(string name, string ns, string description, bool isSubClient, IReadOnlyList<LowLevelClient> subClients, IEnumerable<(ServiceRequest ServiceRequest, Operation Operation)> serviceRequests, RestClientBuilder builder, BuildContext<LowLevelOutputLibrary> context, ClientOptionsTypeProvider clientOptions)
            : base(context)
        {
            DefaultName = name;
            DefaultNamespace = ns;
            Description = BuilderHelpers.EscapeXmlDescription(string.IsNullOrWhiteSpace(description)
                ? $"The {ClientBuilder.GetClientPrefix(Declaration.Name, context)} service client."
                : BuilderHelpers.EscapeXmlDescription(description));
            IsSubClient = isSubClient;
            SubClients = subClients;

            ClientOptions = clientOptions;
            _hasPublicConstructors = !IsSubClient;

            Parameters = builder.GetOrderedParametersByRequired();
            IsResourceClient = Parameters.Any(p => p.IsResourceIdentifier);
            Fields = ClientFields.CreateForClient(Parameters, context);

            PublicConstructors = BuildPublicConstructors().ToArray();

            var clientMethods = BuildMethods(builder, serviceRequests, Declaration.Name).ToArray();

            ClientMethods = clientMethods
                .OrderBy(m => m.IsLongRunning ? 2 : m.PagingInfo != null ? 1 : 0) // Temporary sorting to minimize amount of changed files. Will be removed when new LRO is implemented
                .ToArray();

            RequestMethods = clientMethods.Select(m => m.RequestMethod)
                .Concat(ClientMethods.Select(m => m.PagingInfo?.NextPageMethod).WhereNotNull())
                .Distinct()
                .ToArray();

            SubClientFactoryMethods = BuildSubClientFactoryMethods().ToArray();
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
                        ? typeof(Azure.Operation<BinaryData>)
                        : headAsBoolean
                            ? typeof(Azure.Response<bool>)
                            : typeof(Azure.Response);
                }

                var parameters = operation.IsLongRunning
                    ? requestMethod.Parameters.Prepend(KnownParameters.WaitForCompletion).ToArray()
                    : requestMethod.Parameters;
                var methodSignature = new MethodSignature(requestMethod.Name, requestMethod.Description, requestMethod.Accessibility | Virtual, returnType, null, parameters);

                yield return new LowLevelClientMethod(methodSignature, requestMethod, operationSchemas, diagnostic, pagingInfo, operation.IsLongRunning);
            }
        }

        private IEnumerable<ConstructorSignature> BuildPublicConstructors()
        {
            if (!_hasPublicConstructors)
            {
                yield break;
            }

            var clientOptionsType = ClientOptions.Type.WithNullable(true);
            var clientOptionsParameter = new Parameter("options", "The options for configuring the client.", clientOptionsType, Constant.Default(clientOptionsType), ValidationType.None, Constant.NewInstanceOf(clientOptionsType).GetConstantFormattable());

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

        private ConstructorSignature BuildPublicConstructor(FieldDeclaration? credentialField, Parameter clientOptionsParameter)
        {
            var constructorParameters = RestClientBuilder.GetConstructorParameters(Parameters, credentialField?.Type).Append(clientOptionsParameter).ToArray();
            return new ConstructorSignature(Declaration.Name, $"Initializes a new instance of {Declaration.Name}", Public, constructorParameters);
        }

        public IEnumerable<LowLevelSubClientFactoryMethod> BuildSubClientFactoryMethods()
        {
            foreach (var subClient in SubClients)
            {
                var constructorCallParameters = GetSubClientFactoryMethodParameters(subClient).ToArray();
                var methodParameters = constructorCallParameters.Where(p => Fields.GetFieldByParameter(p) == null).ToArray();

                var subClientName = subClient.Type.Name;
                var libraryName = Context.DefaultLibraryName;
                var methodName = subClientName.StartsWith(libraryName)
                    ? subClientName[libraryName.Length..]
                    : subClientName;

                if (!subClient.IsResourceClient)
                {
                    methodName += ClientBuilder.GetClientSuffix(Context);
                }

                var methodSignature = new MethodSignature($"Get{methodName}", $"Initializes a new instance of {subClient.Type.Name}", Public | Virtual, subClient.Type, null, methodParameters.ToArray());
                FieldDeclaration? cachingField = methodParameters.Any() ? null : new FieldDeclaration(FieldModifiers.Private, subClient.Type, $"_cached{subClient.Type.Name}");

                yield return new LowLevelSubClientFactoryMethod(methodSignature, cachingField, constructorCallParameters);
            }
        }

        private ConstructorSignature BuildSubClientInternalConstructor()
        {
            var constructorParameters = GetSubClientFactoryMethodParameters(this)
                .Select(p => p with {DefaultValue = null, Validation = ValidationType.None, Initializer = null})
                .ToArray();

            return new ConstructorSignature(Declaration.Name, $"Initializes a new instance of {Declaration.Name}", Internal, constructorParameters);
        }

        private static IEnumerable<Parameter> GetSubClientFactoryMethodParameters(LowLevelClient subClient)
            => new[]{ KnownParameters.ClientDiagnostics, KnownParameters.Pipeline, KnownParameters.KeyAuth, KnownParameters.TokenAuth }
                .Concat(RestClientBuilder.GetConstructorParameters(subClient.Parameters, null, includeAPIVersion: true))
                .Where(p => subClient.Fields.GetFieldByParameter(p) != null);
    }
}
