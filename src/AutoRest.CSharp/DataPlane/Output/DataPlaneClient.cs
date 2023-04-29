// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Output.Models
{
    internal class DataPlaneClient : TypeProvider
    {
        private readonly InputClient _inputClient;
        private readonly DataPlaneOutputLibrary _library;
        private Method[]? _pagingMethods;

        protected override string DefaultName { get; }
        public string Description { get; }
        public RestClient RestClient { get; }

        public DataPlaneClient(InputClient inputClient, RestClient restClient, DataPlaneOutputLibrary library, string defaultName, string defaultNamespace, SourceInputModel? sourceInputModel) : base(defaultNamespace, sourceInputModel)
        {
            _inputClient = inputClient;
            _library = library;
            DefaultName = ClientBuilder.GetClientPrefix(inputClient.Name, defaultName) + ClientBuilder.GetClientSuffix();
            Description = BuilderHelpers.EscapeXmlDescription(ClientBuilder.CreateDescription(_inputClient.Description, ClientBuilder.GetClientPrefix(Declaration.Name, defaultName)));
            RestClient = restClient;
        }

        public Method[] PagingMethods => _pagingMethods ??= RestClient.Methods.SelectMany(m => m.ConvenienceMethods).ToArray();

        protected override string DefaultAccessibility { get; } = "public";
    }
}
