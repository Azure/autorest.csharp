// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Models.Types;
using Azure.ResourceManager;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class ArmClientExtensions : MgmtExtensions
    {
        public ArmClientExtensions(IEnumerable<Operation> allOperations, BuildContext<MgmtOutputLibrary> context)
            : base(allOperations, typeof(ArmClient), context, RequestPath.Tenant)
        {
        }

        public override bool IsEmpty => !_context.Library.ArmResources.Any();

        protected override string VariableName => Context.Configuration.MgmtConfiguration.IsArmCore ? "this" : "client";
    }
}
