// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Models;
using Azure.ResourceManager;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class ArmClientExtension : MgmtExtension
    {
        public ArmClientExtension(IEnumerable<Operation> allOperations)
            : base(allOperations, Enumerable.Empty<MgmtExtensionClient>(), typeof(ArmClient), RequestPath.Tenant)
        {
        }

        public override bool IsEmpty => !MgmtContext.Library.ArmResources.Any();

        protected override string VariableName => Configuration.MgmtConfiguration.IsArmCore ? "this" : "client";
    }
}
