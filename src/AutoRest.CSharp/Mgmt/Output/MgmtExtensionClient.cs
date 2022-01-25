// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System.Collections.Generic;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class MgmtExtensionClient : MgmtExtensions
    {
        private readonly MgmtExtensions _publicExtension;

        public MgmtExtensionClient(IEnumerable<Operation> allOperations, string resourceName, BuildContext<MgmtOutputLibrary> context, string defaultName, RequestPath contextualPath, MgmtExtensions publicExtension)
            : base(allOperations, resourceName, context, defaultName, contextualPath)
        {
            _publicExtension = publicExtension;
        }

        public override IEnumerable<Resource> ChildResources => _publicExtension.ChildResources;
    }
}
