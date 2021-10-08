// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System.Collections.Generic;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class ManagementGroupExtensions : MgmtExtensions
    {
        public ManagementGroupExtensions(IEnumerable<Operation> allOperations, BuildContext<MgmtOutputLibrary> context) : base(allOperations, context)
        {
        }

        public override string ResourceName => "ManagementGroup";

        protected override string DefaultName => "ManagementGroupExtensions";
    }
}
