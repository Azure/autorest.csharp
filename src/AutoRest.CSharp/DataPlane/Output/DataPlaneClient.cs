// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Output.Models
{
    internal class DataPlaneClient : TypeProvider
    {
        protected override string DefaultName { get; }
        public string Description { get; }
        public RestClient RestClient { get; }

        public DataPlaneClient(InputClient inputClient, RestClient restClient, string defaultName, string defaultNamespace, SourceInputModel? sourceInputModel) : base(defaultNamespace, sourceInputModel)
        {
            DefaultName = ClientBuilder.GetClientPrefix(inputClient.Name, defaultName) + ClientBuilder.GetClientSuffix();
            Description = BuilderHelpers.EscapeXmlDocDescription(ClientBuilder.CreateDescription(inputClient.Description, ClientBuilder.GetClientPrefix(Declaration.Name, defaultName)));
            RestClient = restClient;
        }

        protected override string DefaultAccessibility => "public";
    }
}
