// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Mgmt.Decorator;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class Resource : TypeProvider
    {
        public Resource(OperationGroup operationGroup, BuildContext context)
            : base(context)
        {
            OperationGroup = operationGroup;
            DefaultName = operationGroup.Resource(context.Configuration.MgmtConfiguration);
            Description = BuilderHelpers.EscapeXmlDescription(
                $"A Class representing a {DefaultName} along with the instance operations that can be performed on it.");
            DefaultAccessibility = "public";
        }

        internal OperationGroup OperationGroup { get; }

        public override string DefaultName { get; }

        public string Description { get; }
    }
}
