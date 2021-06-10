// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Responses;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class MgmtExtensionOperation : TypeProvider
    {
        private BuildContext<MgmtOutputLibrary> _context;
        private PagingMethod[]? _pagingMethods;

        internal OperationGroup OperationGroup { get; }
        protected MgmtRestClient? _restClient;

        public MgmtExtensionOperation(OperationGroup operationGroup, BuildContext<MgmtOutputLibrary> context) : base(context)
        {
            _context = context;
            OperationGroup = operationGroup;

            if (operationGroup.TryGetListInstanceSchema(out var schema))
                DefaultName = schema.Name;
            else
                DefaultName = operationGroup.Key;
        }

        protected override string DefaultName { get; }

        protected override string DefaultAccessibility { get; } = "public";

        public MgmtRestClient RestClient => _restClient ??= _context.Library.GetRestClient(OperationGroup);

        public PagingMethod[] PagingMethods => _pagingMethods ??= EnsurePagingMethods();

        private PagingMethod[] EnsurePagingMethods()
        {
            var pagingMethods = ClientBuilder.BuildPagingMethods(OperationGroup, RestClient, Declaration, (_, operation, _) => $"{operation.CSharpName()}{DefaultName}");
            var convertedPagingMethods = ConvertToPaging(OperationGroup, RestClient, Declaration, (_, operation, _) => $"{operation.CSharpName()}{DefaultName}");
            return pagingMethods.Concat(convertedPagingMethods).ToArray();
        }

        private IEnumerable<PagingMethod> ConvertToPaging(OperationGroup operationGroup, RestClient restClient, TypeDeclarationOptions declaration,
            Func<OperationGroup, Operation, RestClientMethod, string>? nameOverrider = default)
        {
            var clientMethods = ClientBuilder.BuildMethods(operationGroup, restClient, declaration, nameOverrider);
            foreach (var clientMethod in clientMethods)
            {
                var method = clientMethod.RestClientMethod;
                if (!(method.Responses.SingleOrDefault(r => r.ResponseBody != null)?.ResponseBody is ObjectResponseBody objectResponseBody))
                {
                    throw new InvalidOperationException($"Method {method.Name} has to have a return value");
                }

                var paging = new Paging()
                {
                    // we currently only convert the non-paging list with the return model of { "value": { "type": "array" }}
                    ItemName = "value"
                };
                yield return new PagingMethod(
                    clientMethod.RestClientMethod,
                    null,
                    clientMethod.Name,
                    clientMethod.Diagnostics,
                    new PagingResponseInfo(paging, objectResponseBody.Type)
                );
            }
        }
    }
}
