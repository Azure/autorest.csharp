// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using System.Text;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class TenantExtensions : TypeProvider
    {
        public TenantExtensions(BuildContext context) : base(context)
        {
        }

        protected override string DefaultName => "TenantExtensions";

        protected override string DefaultAccessibility => "public";
    }
}
