// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using System.Text;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class SubscriptionExtensionClient : MgmtExtensions
    {
        public SubscriptionExtensionClient(IEnumerable<Operation> allOperations, BuildContext<MgmtOutputLibrary> context) : base(allOperations, "Subscription", context)
        {
        }

        protected override string DefaultName => "SubscriptionExtensionClient";

        protected override RequestPath ContextualPath => RequestPath.Subscription;
    }
}
