// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using static AutoRest.CSharp.Common.Output.Builders.ClientBuilder;

namespace AutoRest.CSharp.Output.Models
{
    internal class RestClient : TypeProvider
    {
        private readonly string _clientName;
        private readonly IReadOnlyDictionary<InputOperation, RestClientMethod> _requestMethods;

        public IReadOnlyList<LowLevelClientMethod> ProtocolMethods { get; }
        public IReadOnlyList<Parameter> ClientParameters { get; }
        public ClientFields Fields { get; }
        public IReadOnlyList<Parameter> Parameters { get; }
        public IReadOnlyList<HlcMethods> Methods { get; }
        public ConstructorSignature Constructor { get; }

        public string ClientPrefix { get; }
        protected override string DefaultName { get; }
        protected override string DefaultAccessibility => "internal";

        public RestClient(InputClient inputClient, IReadOnlyList<Parameter> clientParameters, IReadOnlyList<Parameter> restClientParameters, TypeFactory typeFactory, OutputLibrary library, string clientName, string defaultNamespace, SourceInputModel? sourceInputModel)
            : base(defaultNamespace, sourceInputModel)
        {
            _clientName = clientName;
            var clientPrefix = GetClientPrefix(clientName, defaultNamespace);
            ClientPrefix = clientPrefix;
            DefaultName = clientPrefix + "Rest" + GetClientSuffix();

            ClientParameters = clientParameters;
            Parameters = restClientParameters;
            Fields = ClientFields.CreateForRestClient(restClientParameters);
            Constructor = new ConstructorSignature(Declaration.Name, $"Initializes a new instance of {Declaration.Name}", null, MethodSignatureModifiers.Public, Parameters.ToArray());

            var methods = CreateMethods(inputClient, Fields, clientPrefix + GetClientSuffix(), typeFactory, library);
            Methods = methods;
            _requestMethods = methods.ToDictionary(m => m.Operation, m => m.CreateMessageMethods[0]);
            ProtocolMethods = GetProtocolMethods(_requestMethods.Values, Fields, inputClient, typeFactory, library).ToList();
        }

        private IReadOnlyList<HlcMethods> CreateMethods(InputClient inputClient, ClientFields fields, string clientName, TypeFactory typeFactory, OutputLibrary library)
        {
            var operationParameters = new Dictionary<InputOperation, MethodParametersBuilder>();

            foreach (var inputOperation in inputClient.Operations)
            {
                var builder = new MethodParametersBuilder(typeFactory, inputOperation);
                if (Configuration.AzureArm)
                {
                    builder.BuildMpg();
                }
                else
                {
                    builder.BuildHlc();
                }
                operationParameters[inputOperation] = builder;
            }

            var restClient = new MemberReference(null, "RestClient");
            var methods = new List<HlcMethods>();
            foreach (var (operation, builder) in operationParameters)
            {
                var createNextPageMessageMethodParameters = operation.Paging is { NextLinkOperation: { } nextLinkOperation }
                    ? operationParameters[nextLinkOperation].CreateMessageParameters
                    : operation.Paging is { NextLinkName: {} }
                        ? builder.CreateMessageParameters.Prepend(KnownParameters.NextLink).ToArray()
                        : Array.Empty<Parameter>();

                var methodBuilder = new OperationMethodsBuilder(operation, restClient, fields, clientName, typeFactory, builder.RequestParts, builder.CreateMessageParameters, createNextPageMessageMethodParameters, builder.ParameterLinks);
                methods.Add(BuildMethods(library, methodBuilder, operation));
            }

            return methods;
        }

        protected virtual HlcMethods BuildMethods(OutputLibrary library, OperationMethodsBuilder methodBuilder, InputOperation operation)
        {
            return methodBuilder.BuildHlc(library is DataPlaneOutputLibrary dpl ? dpl.FindHeaderModel(operation) : null);
        }

        private IEnumerable<LowLevelClientMethod> GetProtocolMethods(IEnumerable<RestClientMethod> methods, ClientFields fields, InputClient inputClient, TypeFactory typeFactory, OutputLibrary library)
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

        private static bool IsProtocolMethodExists(InputOperation operation, InputClient inputClient, OutputLibrary library)
            => library is DataPlaneOutputLibrary dpl && dpl.ProtocolMethodsDictionary.TryGetValue(inputClient.Key, out var protocolMethods) &&
               protocolMethods.Any(m => m.Equals(operation.Name, StringComparison.OrdinalIgnoreCase));
    }
}
