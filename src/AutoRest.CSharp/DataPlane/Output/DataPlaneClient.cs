// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Output.Models
{
    internal class DataPlaneClient : TypeProvider
    {
        private readonly DataPlaneOutputLibrary _library;
        protected override string DefaultName { get; }
        public string Description { get; }
        public RestClient RestClient { get; }

        public DataPlaneClient(InputClient inputClient, RestClient restClient, string defaultName, string defaultNamespace, DataPlaneOutputLibrary library, SourceInputModel? sourceInputModel) : base(defaultNamespace, sourceInputModel)
        {
            _library = library;
            DefaultName = ClientBuilder.GetClientPrefix(inputClient.Name, defaultName) + ClientBuilder.GetClientSuffix();
            Description = BuilderHelpers.EscapeXmlDocDescription(ClientBuilder.CreateDescription(inputClient.Description, ClientBuilder.GetClientPrefix(Declaration.Name, defaultName)));
            RestClient = restClient;
            Methods = restClient.Methods
                .OrderBy(m => m.Order)
                .Select(CreateMethodBuilder)
                .SelectMany(b => b.Build());
        }

        private DataPlaneLegacyMethodBuilderBase CreateMethodBuilder(RestClientOperationMethods methods)
        {
            var name = Declaration.Name;
            var fields = RestClient.Fields;
            var restClientReference = new MemberExpression(null, "RestClient");
            var convenienceMethod = (MethodSignature)methods.Convenience!.Signature;
            var createRequestMethod = (MethodSignature)methods.CreateRequest.Signature;

            var lroType = _library.FindLongRunningOperation(methods.Operation)?.Type;
            if (methods.PageItemType is not null)
            {
                var createNextPageRequestMethod = methods.CreateNextPageMessageSignature;
                if (lroType is not null)
                {
                    return new LroPagingDataPlaneLegacyMethodBuilder(name, fields, restClientReference, convenienceMethod, createRequestMethod, createNextPageRequestMethod, lroType);
                }

                var itemPropertyName = methods.Operation.Paging!.ItemName ?? "value";
                var nextLinkName = methods.Operation.Paging!.NextLinkName;
                return new PagingDataPlaneLegacyMethodBuilder(name, fields, restClientReference, convenienceMethod, createRequestMethod, createNextPageRequestMethod, methods.PageItemType, itemPropertyName, nextLinkName);
            }

            if (lroType is not null)
            {
                return new LroDataPlaneLegacyMethodBuilder(name, fields, restClientReference, convenienceMethod, createRequestMethod, lroType);
            }

            return new DataPlaneLegacyMethodBuilder(name, fields, restClientReference, convenienceMethod);
        }

        protected override string DefaultAccessibility => "public";
        public IEnumerable<Method> Methods { get; }
    }
}
