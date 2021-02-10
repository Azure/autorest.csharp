// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using AutoRest.CSharp.V3.Generation.Types;
using AutoRest.CSharp.V3.Input;
using AutoRest.CSharp.V3.Output.Builders;
using AutoRest.CSharp.V3.Output.Models.Requests;
using AutoRest.CSharp.V3.Output.Models.Responses;
using AutoRest.CSharp.V3.Output.Models.Serialization;
using AutoRest.CSharp.V3.Output.Models.Shared;
using AutoRest.CSharp.V3.Output.Models.Types;
using AutoRest.CSharp.V3.Utilities;

namespace AutoRest.CSharp.V3.Output.Models
{
    internal class ResourceData : TypeProvider
    {
        private const string ClientSuffixValue = "Client";
        private const string OperationsSuffixValue = "Data";
        private readonly OperationGroup _operationGroup;
        private readonly BuildContext _context;
        public ResourceData(OperationGroup operationGroup, BuildContext context) : base(context)
        {
            _operationGroup = operationGroup;
            _context = context;
            ClientPrefix = GetClientPrefix(operationGroup.Language.Default.Name);
            DefaultName = ClientPrefix + OperationsSuffixValue;
        }
        public string ClientPrefix { get; }
        protected override string DefaultAccessibility { get; } = "public";
        protected override string DefaultName { get; }
        public string Description => BuilderHelpers.EscapeXmlDescription($"A class representing the {ClientPrefix} data model.");

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
    }
}
