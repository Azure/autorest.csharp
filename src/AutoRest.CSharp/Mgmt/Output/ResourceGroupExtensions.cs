// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using System.Text;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class ResourceGroupExtensions : MgmtTypeProvider
    {
        public override RequestPath ContextualPath => RequestPath.Subscription;

        public ResourceGroupExtensions(BuildContext context) : base(context)
        {
        }

        protected override string DefaultName => "ResourceGroupExtensions";

        protected override string DefaultAccessibility => "public";
    }
}
