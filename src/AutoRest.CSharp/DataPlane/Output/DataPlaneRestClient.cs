// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Serialization;
using static AutoRest.CSharp.Common.Output.Builders.ClientBuilder;

namespace AutoRest.CSharp.Output.Models
{
    internal class DataPlaneRestClient : TypeProvider
    {
        private readonly string _clientName;
        private readonly IReadOnlyDictionary<InputOperation, RestClientMethod> _requestMethods;

        public IReadOnlyList<LowLevelClientMethod> ProtocolMethods { get; }
        public RestClientBuilder ClientBuilder { get; }
        public ClientFields Fields { get; }
        public IReadOnlyList<Parameter> Parameters { get; }
        public IReadOnlyList<HlcMethods> Methods { get; }
        public ConstructorSignature Constructor { get; }

        public string ClientPrefix { get; }
        protected override string DefaultName { get; }
        protected override string DefaultAccessibility => "internal";

        public DataPlaneRestClient(InputClient inputClient, RestClientBuilder clientBuilder, TypeFactory typeFactory, DataPlaneOutputLibrary library, string clientName, string defaultNamespace, SourceInputModel? sourceInputModel)
            : base(defaultNamespace, sourceInputModel)
        {
            _clientName = clientName;
            var clientPrefix = GetClientPrefix(clientName, defaultNamespace);
            ClientPrefix = clientPrefix;
            DefaultName = clientPrefix + "Rest" + GetClientSuffix();

            Parameters = GetOrderedParameters(clientBuilder);
            ClientBuilder = clientBuilder;
            Fields = ClientFields.CreateForRestClient(Parameters);
            Constructor = new ConstructorSignature(Declaration.Name, $"Initializes a new instance of {Declaration.Name}", null, MethodSignatureModifiers.Public, Parameters.ToArray());

            var methods = CreateMethods(inputClient, Fields, clientPrefix + GetClientSuffix(), typeFactory, library);
            Methods = methods;
            _requestMethods = methods.ToDictionary(m => m.Operation, m => m.CreateMessageMethods[0]);
            ProtocolMethods = GetProtocolMethods(_requestMethods.Values, Fields, inputClient, typeFactory, library).ToList();
        }

        private static IReadOnlyList<HlcMethods> CreateMethods(InputClient inputClient, ClientFields fields, string clientName, TypeFactory typeFactory, DataPlaneOutputLibrary library)
        {
            var operationParameters = new Dictionary<InputOperation, MethodParametersBuilder>();

            foreach (var inputOperation in inputClient.Operations)
            {
                var builder = new MethodParametersBuilder(typeFactory, inputOperation);
                builder.BuildHlc();
                operationParameters[inputOperation] = builder;
            }

            var restClient = new MemberReference(new ValueExpression(), "RestClient");
            var methods = new List<HlcMethods>();
            foreach (var (operation, builder) in operationParameters)
            {
                var createNextPageMessageMethodParameters = operation.Paging is { NextLinkOperation: { } nextLinkOperation }
                    ? operationParameters[nextLinkOperation].CreateMessageParameters
                    : operation.Paging is { NextLinkName: {} }
                        ? builder.CreateMessageParameters.Prepend(KnownParameters.NextLink).ToArray()
                        : Array.Empty<Parameter>();

                var methodBuilder = new OperationMethodsBuilder(operation, restClient, fields, clientName, typeFactory, builder.RequestParts, builder.CreateMessageParameters, createNextPageMessageMethodParameters, builder.ParameterLinks);
                methods.Add(methodBuilder.BuildHlc(library.FindHeaderModel(operation)));
            }

            return methods;
        }

        private static IReadOnlyList<Parameter> GetOrderedParameters(RestClientBuilder clientBuilder)
        {
            var parameters = new List<Parameter> { KnownParameters.ClientDiagnostics, KnownParameters.Pipeline };
            parameters.AddRange(clientBuilder.GetOrderedParametersByRequired());
            return parameters;
        }

        private IEnumerable<LowLevelClientMethod> GetProtocolMethods(IEnumerable<RestClientMethod> methods, ClientFields fields, InputClient inputClient, TypeFactory typeFactory, DataPlaneOutputLibrary library)
        {
            // At least one protocol method is found in the config for this operationGroup
            if (!inputClient.Operations.Any(operation => IsProtocolMethodExists(operation, inputClient, library)))
            {
                return Enumerable.Empty<LowLevelClientMethod>();
            }

            // Filter protocol method requests for this operationGroup based on the config
            var operations = methods.Select(m => m.Operation).Where(operation => IsProtocolMethodExists(operation, inputClient, library));
            return LowLevelClient.BuildMethods(typeFactory, operations, fields, _clientName);
        }

        public RestClientMethod GetOperationMethod(InputOperation request)
            => _requestMethods[request];

        private static bool IsProtocolMethodExists(InputOperation operation, InputClient inputClient, DataPlaneOutputLibrary library)
            => library.ProtocolMethodsDictionary.TryGetValue(inputClient.Key, out var protocolMethods) &&
               protocolMethods.Any(m => m.Equals(operation.Name, StringComparison.OrdinalIgnoreCase));
    }
}
