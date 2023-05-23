﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
using static AutoRest.CSharp.Common.Output.Builders.ClientBuilder;

namespace AutoRest.CSharp.Output.Models
{
    internal class RestClient : TypeProvider
    {
        private readonly string _clientName;
        public IReadOnlyList<Parameter> ClientParameters { get; }
        public ClientFields Fields { get; }
        public IReadOnlyList<Parameter> Parameters { get; }
        public IReadOnlyList<LegacyMethods> Methods { get; }
        public ConstructorSignature Constructor { get; }

        public string ClientPrefix { get; }
        protected override string DefaultName { get; }
        protected override string DefaultAccessibility => "internal";

        public RestClient(ClientMethodsBuilder clientMethodsBuilder, IReadOnlyList<Parameter> clientParameters, IReadOnlyList<Parameter> restClientParameters, TypeFactory typeFactory, OutputLibrary library, string clientName, string defaultNamespace, SourceInputModel? sourceInputModel)
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

            var restClient = new MemberReference(null, "RestClient");
            Methods = clientMethodsBuilder
                .Build(restClient, Fields, clientPrefix + GetClientSuffix())
                .Select(b => BuildMethods(library, b))
                .ToList();
        }

        protected virtual LegacyMethods BuildMethods(OutputLibrary library, OperationMethodsBuilderBase methodBuilder)
        {
            if (library is DataPlaneOutputLibrary dpl)
            {
                return methodBuilder.BuildLegacy(dpl.FindHeaderModel(methodBuilder.Operation), dpl.FindLongRunningOperation(methodBuilder.Operation)?.Type, null);
            }

            return methodBuilder.BuildLegacy(null, null, null);
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
            return new ClientMethodsBuilder(operations, typeFactory, false, false)
                .Build(null, fields, _clientName)
                .Select(b => b.BuildDpg());
        }

        private static bool IsProtocolMethodExists(InputOperation operation, InputClient inputClient, OutputLibrary library)
            => library is DataPlaneOutputLibrary dpl && dpl.ProtocolMethodsDictionary.TryGetValue(inputClient.Key, out var protocolMethods) &&
               protocolMethods.Any(m => m.Equals(operation.Name, StringComparison.OrdinalIgnoreCase));
    }
}
