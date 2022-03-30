// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Responses;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Operation = AutoRest.CSharp.Input.Operation;
using static AutoRest.CSharp.Output.Models.MethodSignatureModifiers;
using System.Runtime.CompilerServices;

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

            foreach (var (request, method) in requestMethods)
            {
                var operation = method.Operation;
                var paging = operation.Language.Default.Paging;
                Schema? requestSchema = request.Parameters.FirstOrDefault(p => p.In == HttpParameterIn.Body)?.Schema;
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

        private Parameter CreateOptionsParameter(bool isRequired)
        {
            var clientOptionsType = ClientOptions.Type.WithNullable(true);
            return new Parameter("options", "The options for configuring the client.", clientOptionsType, isRequired ? null : Constant.NewInstanceOf(clientOptionsType), false);
        }

        private IEnumerable<ConstructorSignature> BuildPublicConstructors()
        {
            if (!_hasPublicConstructors)
            {
                yield break;
            }

            if (Fields.CredentialFields.Count == 0)
            {
                foreach (var constructor in BuildPublicConstructor(null))
                {
                    yield return constructor;
                }
            }
            else
            {
                foreach (var credentialField in Fields.CredentialFields)
                {
                    foreach (var constructor in BuildPublicConstructor(credentialField))
                    {
                        yield return constructor;
                    }
                }
            }
        }

        private ConstructorInitializer BuildConstructorInitializer(Parameter[] constructorParameters)
        {
            var initializer = constructorParameters.Select(parameter =>
            {
                if (parameter.DefaultValue == null)
                {
                    return FormattableStringFactory.Create("{0:I}", parameter.Name);
                }

                var defaultValue = parameter.DefaultValue.Value;
                if (defaultValue.IsNewInstanceSentinel)
                {
                    return FormattableStringFactory.Create("new {0:I}()", defaultValue.Type);
                }
                if (parameter.Type.Equals(typeof(Uri)))
                {
                    return FormattableStringFactory.Create("new {0:I}({1:L})", typeof(Uri), defaultValue.Value);
                }
                return FormattableStringFactory.Create("{0:L}", defaultValue.Value);
            }).ToArray();

            return new ConstructorInitializer(false, initializer);
        }

        private IEnumerable<ConstructorSignature> BuildPublicConstructor(FieldDeclaration? credentialField)
        {
            var constructorParameters = RestClientBuilder.GetConstructorParameters(Parameters, credentialField?.Type).Append(CreateOptionsParameter(false)).ToArray();

            var requiredParameters = constructorParameters.Where(parameter => parameter.DefaultValue == null).ToArray();
            var minimalConstructorSignature = new ConstructorSignature(
                Declaration.Name,
                $"Initializes a new instance of {Declaration.Name}",
                Public,
                requiredParameters,
                BuildConstructorInitializer(constructorParameters));
            yield return minimalConstructorSignature;

            var optionalParameters = constructorParameters.Where(parameter => parameter.DefaultValue != null).ToArray();
            if (optionalParameters.Length == 1)
            {
                var optionsRequiredConstructorSignature = new ConstructorSignature(Declaration.Name, $"Initializes a new instance of {Declaration.Name}", Public, constructorParameters.SkipLast(1).Append(CreateOptionsParameter(true)).ToArray());
                yield return optionsRequiredConstructorSignature;
            }
            else
            {
                var optionsOptionalParameters = requiredParameters.ToList();
                foreach (var parameter in optionalParameters)
                {
                    if (parameter.Name != "options")
                    {
                        optionsOptionalParameters.Add(new Parameter(parameter.Name, parameter.Description, parameter.Type, null, parameter.Validate, parameter.IsApiVersionParameter, parameter.IsResourceIdentifier, parameter.SkipUrlEncoding, parameter.RequestLocation, parameter.UseDefaultValueInCtorParam));
                    }
                }
                optionsOptionalParameters.Add(CreateOptionsParameter(false));

                var optionsOptionalConstructorSignature = new ConstructorSignature(Declaration.Name, $"Initializes a new instance of {Declaration.Name}", Public, optionsOptionalParameters);
                yield return optionsOptionalConstructorSignature;
            }
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
                .Select(p => p with { DefaultValue = null, Validate = false })
                .ToArray();

            return new ConstructorSignature(Declaration.Name, $"Initializes a new instance of {Declaration.Name}", Internal, constructorParameters);
        }

        private static IEnumerable<Parameter> GetSubClientFactoryMethodParameters(LowLevelClient subClient)
            => new[] { KnownParameters.ClientDiagnostics, KnownParameters.Pipeline, KnownParameters.KeyAuth, KnownParameters.TokenAuth }
                .Concat(RestClientBuilder.GetConstructorParameters(subClient.Parameters, null, includeAPIVersion: true))
                .Where(p => subClient.Fields.GetFieldByParameter(p) != null);
    }
}
