// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using System.Text;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class SubscriptionExtensions : MgmtTypeProvider
    {
        public override RequestPath ContextualPath => RequestPath.Subscription;

        public SubscriptionExtensions(BuildContext context) : base(context)
        {
        }

        protected override string DefaultName => "SubscriptionExtensions";

        protected override string DefaultAccessibility => "public";
    }
}
