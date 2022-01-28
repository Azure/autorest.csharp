// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Types;
using Azure.ResourceManager.Core;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class MgmtExtensionClient : MgmtTypeProvider
    {
        private string _defaultName;
        public MgmtExtensionClient(BuildContext<MgmtOutputLibrary> context, MgmtExtensions publicExtension)
            : base(context, publicExtension.ResourceName)
        {
            Extension = publicExtension;
            _defaultName = $"{ResourceName}ExtensionClient";
        }

        private ConstructorSignature? _armClientCtor;
        public override ConstructorSignature? ArmClientCtor => _armClientCtor ??= new ConstructorSignature(
                Name: Type.Name,
                Description: $"Initializes a new instance of the <see cref=\"{Type.Name}\"/> class.",
                Modifiers: "internal",
                Parameters: new[] { ArmClientParameter, ResourceIdentifierParameter },
                Initializer: new(
                    isBase: true,
                    arguments: new[] { ArmClientParameter, ResourceIdentifierParameter }));

        public override Type? BaseType => typeof(ArmResource);

        protected override string DefaultName => _defaultName;

        public MgmtExtensions Extension { get; }

        public override IEnumerable<Resource> ChildResources => Extension.ChildResources;

        private string? _description;
        public override string Description => _description ??= $"A class to add extension methods to {ResourceName}.";

        protected override string DefaultAccessibility => "internal";

        protected override IEnumerable<MgmtClientOperation> EnsureClientOperations() => Extension.ClientOperations;
    }
}
