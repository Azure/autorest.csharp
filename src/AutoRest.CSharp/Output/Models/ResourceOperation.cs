// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using AutoRest.CSharp.V3.Input;
using AutoRest.CSharp.V3.Output.Builders;
using AutoRest.CSharp.V3.Output.Models.Types;
using AutoRest.CSharp.V3.Utilities;

namespace AutoRest.CSharp.V3.Output.Models
{
    internal class ResourceOperation : TypeProvider
    {
        private const string ClientSuffixValue = "Client";
        private const string OperationsSuffixValue = "Operations";
        private OperationGroup _operationGroup;
        private RestClient? _restClient;

        public ResourceOperation(OperationGroup operationGroup, BuildContext context)
            : base(context)
        {
            _operationGroup = operationGroup;
            var clientPrefix = GetClientPrefix(operationGroup.Language.Default.Name);
            DefaultName = clientPrefix + OperationsSuffixValue;
        }

        protected override string DefaultName { get; }

        protected override string DefaultAccessibility { get; } = "public";

        public string Description => BuilderHelpers.EscapeXmlDescription(CreateDescription(_operationGroup, GetClientPrefix(Declaration.Name)));

        public RestClient RestClient => _restClient ??= _context.Library.FindRestClient(_operationGroup);

        protected string GetClientPrefix(string name)
        {
            name = string.IsNullOrEmpty(name) ? _context.CodeModel.Language.Default.Name : name.ToCleanName();

            if (name.EndsWith(OperationsSuffixValue) && name.Length >= OperationsSuffixValue.Length)
            {
                name = name.Substring(0, name.Length - OperationsSuffixValue.Length);
            }

            if (name.EndsWith(ClientSuffixValue) && name.Length >= ClientSuffixValue.Length)
            {
                name = name.Substring(0, name.Length - ClientSuffixValue.Length);
            }

            return name;
        }

        protected static string CreateDescription(OperationGroup operationGroup, string clientPrefix)
        {
            StringBuilder summary = new StringBuilder();
            return string.IsNullOrWhiteSpace(operationGroup.Language.Default.Description) ?
                $"A class representing the operations that can be performed over a specific {clientPrefix}." :
                BuilderHelpers.EscapeXmlDescription(operationGroup.Language.Default.Description);
        }
    }
}
