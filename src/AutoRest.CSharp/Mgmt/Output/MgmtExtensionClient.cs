// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System.Collections.Generic;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class MgmtExtensionClient : MgmtExtensions
    {
        private string _defaultName;
        public MgmtExtensionClient(BuildContext<MgmtOutputLibrary> context, MgmtExtensions publicExtension)
            : base(context, publicExtension)
        {
            PublicExtension = publicExtension;
            _defaultName = $"{ResourceName}ExtensionClient";
        }

        protected override string DefaultName => _defaultName;

        public MgmtExtensions PublicExtension { get; }

        public override IEnumerable<Resource> ChildResources => PublicExtension.ChildResources;
    }
}
