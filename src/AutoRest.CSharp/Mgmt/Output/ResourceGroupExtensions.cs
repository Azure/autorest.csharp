// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Output.Models
{
    internal class ResourceGroupExtensions : TypeProvider
    {
        public ResourceGroupExtensions(BuildContext<MgmtOutputLibrary> context)
            : base(context)
        {
            DefaultName = "ResourceGroupExtensions";
            Description = "A class to add extension methods to ResourceGroup.";
        }

        protected override string DefaultName { get; }

        protected override string DefaultAccessibility { get; } = "public";

        public string Description { get; }
    }
}
