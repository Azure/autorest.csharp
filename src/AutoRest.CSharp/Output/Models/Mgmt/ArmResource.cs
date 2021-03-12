// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Output.Models
{
    internal class ArmResource : TypeProvider
    {
        public ArmResource(string resourceName, BuildContext context)
            : base(context)
        {
            DefaultName = resourceName;
            Description = BuilderHelpers.EscapeXmlDescription(
                $"A Class representing a {DefaultName} along with the instance operations that can be performed on it.");
        }

        protected override string DefaultName { get; }

        protected override string DefaultAccessibility => "public";

        public string Description { get; }
    }
}
