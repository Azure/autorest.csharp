// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System.Collections.Generic;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class ArmResourceExtensions : MgmtExtensions
    {
        public ArmResourceExtensions(IEnumerable<Operation> allOperations, BuildContext<MgmtOutputLibrary> context) : base(allOperations, context)
        {
        }

        public override string ResourceName => "ArmResource";

        protected override string DefaultName => "ArmResourceExtensions";

        protected override RequestPath ContextualPath => RequestPath.Any;
    }
}
