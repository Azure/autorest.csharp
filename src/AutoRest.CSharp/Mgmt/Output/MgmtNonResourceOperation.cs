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
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class MgmtNonResourceOperation : TypeProvider
    {
        private BuildContext<MgmtOutputLibrary> _context;
        private IEnumerable<ClientMethod>? _clientMethods;
        private IEnumerable<PagingMethod>? _pagingMethods;

        internal OperationGroup OperationGroup { get; }
        protected MgmtRestClient? _restClient;

        public MgmtNonResourceOperation(OperationGroup operationGroup, BuildContext<MgmtOutputLibrary> context, string defaultName) : base(context)
        {
            _context = context;
            OperationGroup = operationGroup;
            DefaultName = defaultName;

            if (operationGroup.TryGetListInstanceSchema(out var schema))
                SchemaName = schema.Name.ToPlural();
            else
                SchemaName = operationGroup.Key;
        }

        protected override string DefaultName { get; }

        public string SchemaName { get; }

        protected override string DefaultAccessibility { get; } = "public";

        public MgmtRestClient RestClient => _restClient ??= _context.Library.GetRestClient(OperationGroup);

        public IEnumerable<ClientMethod> ClientMethods => _clientMethods ??= ClientBuilder.BuildMethods(OperationGroup, RestClient, Declaration, OverrideMethodName);

        public IEnumerable<PagingMethod> PagingMethods => _pagingMethods ??= ClientBuilder.BuildPagingMethods(OperationGroup, RestClient, Declaration, OverrideMethodName);

        private string OverrideMethodName(OperationGroup operationGroup, Operation operation, RestClientMethod restClientMethod) {
            var verb = operation.CSharpName();
            const string list = "List";
            if (verb.StartsWith(list, StringComparison.InvariantCultureIgnoreCase))
            {
                return $"{list}{SchemaName}{verb.Substring(list.Length)}";
            }
            return $"{operation.CSharpName()}{SchemaName}";
        }
    }
}
