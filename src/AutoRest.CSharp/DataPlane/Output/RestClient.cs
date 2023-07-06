// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Models;
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
        public IReadOnlyList<LowLevelClientMethod>? ProtocolMethods { get; }
        public ConstructorSignature Constructor { get; }

        public string ClientPrefix { get; }
        protected override string DefaultName { get; }
        protected override string DefaultAccessibility => "internal";

        public RestClient(ClientMethodsBuilder clientMethodsBuilder, ClientMethodsBuilder? protocolMethodsBuilder, IReadOnlyList<Parameter> clientParameters, IReadOnlyList<Parameter> restClientParameters, string clientName, string defaultNamespace, SourceInputModel? sourceInputModel)
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

            var restClient = new MemberExpression(null, "RestClient");
            Methods = clientMethodsBuilder
                .Build(restClient, Fields, clientPrefix + GetClientSuffix(), Declaration.Namespace)
                .Select(b => b.BuildLegacy())
                .ToList();

            ProtocolMethods = protocolMethodsBuilder?
                .Build(Snippets.Null, Fields, clientPrefix + GetClientSuffix(), Declaration.Namespace)
                .Select(b => b.BuildDpg())
                .ToList();
        }
    }
}
