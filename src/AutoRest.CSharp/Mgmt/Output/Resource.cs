// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class Resource : TypeProvider
    {
        private BuildContext<MgmtOutputLibrary> _context;

        public Resource(OperationGroup operationGroup, BuildContext<MgmtOutputLibrary> context)
            : base(context)
        {
            DefaultName = operationGroup.Resource(context.Configuration.MgmtConfiguration);
            Description = BuilderHelpers.EscapeXmlDescription(
                $"A Class representing a {DefaultName} along with the instance operations that can be performed on it.");
            _context = context;
            OperationGroup = operationGroup;
        }

        protected override string DefaultName { get; }

        protected override string DefaultAccessibility => "public";

        public string Description { get; }

        internal OperationGroup OperationGroup { get; private set; }

        public ResourceData ResourceDataObject => _context.Library.GetResourceData(OperationGroup);
    }
}
