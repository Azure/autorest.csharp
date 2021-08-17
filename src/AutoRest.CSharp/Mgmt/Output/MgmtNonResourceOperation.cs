// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

            SchemaName = operationGroup.Key.ToSingular(false);
        }

        protected override string DefaultName { get; }

        public string SchemaName { get; }

        protected override string DefaultAccessibility { get; } = "public";

        public MgmtRestClient RestClient => _restClient ??= _context.Library.GetRestClient(OperationGroup);

        public IEnumerable<ClientMethod> ClientMethods => _clientMethods ??= ClientBuilder.BuildMethods(OperationGroup, RestClient, Declaration, OverrideMethodName);

        public IEnumerable<PagingMethod> PagingMethods => _pagingMethods ??= ClientBuilder.BuildPagingMethods(OperationGroup, RestClient, Declaration, OverrideMethodName);

        private string OverrideMethodName(OperationGroup operationGroup, Operation operation, RestClientMethod restClientMethod)
        {
            var operationName = operation.CSharpName();
            var schemaName = SchemaName;
            // Change GetAll -> Get
            const string getAll = "GetAll";
            if (operationName.StartsWith(getAll, StringComparison.InvariantCultureIgnoreCase))
            {
                operationName = $"Get{operationName.Substring(getAll.Length)}";
            }
            // Split the Camel Case verb into words
            var words = operationName.SplitByCamelCase();
            // We assume the first word is the verb, and insert the schema name after it
            var verb = words.First();
            var wordsLeft = words.Skip(1);
            if (ShouldUsePlural(wordsLeft, restClientMethod))
            {
                schemaName = schemaName.ToPlural();
            }
            return $"{verb}{schemaName}{string.Join("", wordsLeft)}";
        }

        // If the method is not returning a collection, we just return false.
        // If the method name only has one word, we need plural
        // If the second word falls into the escape word list, we need plural
        // For instance, the original operation name is `GetByLocation`, and the schema is `Usage`, we need to ensure the result is `GetUsagesByLocation`
        // otherwise we do not need plural. For instance, the original operation name is `GetTypes`, we need to ensure the result is `GetUsageTypes` instead of `GetUsagesTypes`
        private bool ShouldUsePlural(IEnumerable<string> wordsLeft, RestClientMethod restClientMethod)
        {
            if (!restClientMethod.IsListMethod())
                return false;
            if (!wordsLeft.Any())
                return true;
            if (escapeWords.Contains(wordsLeft.First(), StringComparer.InvariantCultureIgnoreCase))
                return true;

            return false;
        }

        private static readonly string[] escapeWords = { "By" };
    }
}
