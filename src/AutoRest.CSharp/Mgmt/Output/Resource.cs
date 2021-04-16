// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class Resource : TypeProvider
    {
        public Resource(string resourceName, BuildContext context)
            : base(context)
        {
            DefaultName = resourceName;
            Description = BuilderHelpers.EscapeXmlDescription(
                $"A Class representing a {DefaultName} along with the instance operations that can be performed on it.");
            DefaultAccessibility = "public";
        }

        public override string DefaultName { get; }

        public string Description { get; }
    }
}
