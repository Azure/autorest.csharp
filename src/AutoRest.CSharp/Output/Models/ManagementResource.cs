// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Output.Models
{
    internal class ManagementResource : TypeProvider
    {
        private readonly OperationGroup _operationGroup;

        public ManagementResource(OperationGroup operationGroup, BuildContext context)
            : base(context)
        {
            _operationGroup = operationGroup;
            DefaultName = operationGroup.Language.Default.Name.ToCleanName();
        }

        protected override string DefaultName { get; }

        protected override string DefaultAccessibility { get; } = "public";

        public string Description => BuilderHelpers.EscapeXmlDescription(
            CreateDescription(_operationGroup, Declaration.Name));

        protected static string CreateDescription(OperationGroup operationGroup, string name)
        {
            StringBuilder summary = new StringBuilder();
            return string.IsNullOrWhiteSpace(operationGroup.Language.Default.Description) ?
                $"A class representing a {name} along with the instance operations that can be performed on it." :
                BuilderHelpers.EscapeXmlDescription(operationGroup.Language.Default.Description);
        }
    }
}
