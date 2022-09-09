// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Models;
using Azure.ResourceManager;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class ArmClientExtension : MgmtExtension
    {
        public ArmClientExtension(IEnumerable<Operation> allOperations)
            : base(allOperations, typeof(ArmClient), RequestPath.Tenant)
        {
        }

        public override bool IsEmpty => !MgmtContext.Library.ArmResources.Any();

        protected override string VariableName => Configuration.MgmtConfiguration.IsArmCore ? "this" : "client";

        public override MgmtExtensionClient ExtensionClient => throw new InvalidOperationException("ArmClientExtension does not have an extension client");
    }
}
