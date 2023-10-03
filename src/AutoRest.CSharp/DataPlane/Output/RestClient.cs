// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using static AutoRest.CSharp.Common.Output.Builders.ClientBuilder;

namespace AutoRest.CSharp.Output.Models
{
    internal class RestClient : TypeProvider
    {
        public IReadOnlyList<Parameter> ClientParameters { get; }
        public ClientFields Fields { get; }
        public IReadOnlyList<Parameter> Parameters { get; }
        public IReadOnlyList<RestClientOperationMethods> Methods { get; }
        public IReadOnlyList<RestClientOperationMethods>? ProtocolMethods { get; }
        public ConstructorSignature Constructor { get; }

        public string Key { get; }
        public string ClientPrefix { get; }
        protected override string DefaultName { get; }
        protected override string DefaultAccessibility => "internal";

        public RestClient(ClientMethodsBuilder clientMethodsBuilder, IReadOnlyList<Parameter> clientParameters, IReadOnlyList<Parameter> restClientParameters, string clientName, string defaultNamespace, string clientKey, SourceInputModel? sourceInputModel)
            : base(defaultNamespace, sourceInputModel)
        {
            var clientPrefix = GetClientPrefix(clientName, defaultNamespace);
            ClientPrefix = clientPrefix;
            DefaultName = clientPrefix + "Rest" + GetClientSuffix();
            Key = clientKey;

            ClientParameters = clientParameters;
            Parameters = restClientParameters;
            Fields = ClientFields.CreateForRestClient(restClientParameters);
            Constructor = new ConstructorSignature(Type, $"Initializes a new instance of {Declaration.Name}", null, MethodSignatureModifiers.Public, Parameters.ToArray());

            Methods = clientMethodsBuilder.Build(Fields, new DpgOperationSampleBuilder(), clientPrefix + GetClientSuffix(), Declaration.Namespace, Key).ToList();

            ProtocolMethods = null;
        }
    }
}
