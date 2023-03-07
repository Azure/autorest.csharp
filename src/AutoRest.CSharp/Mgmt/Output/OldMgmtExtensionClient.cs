// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Linq;
using System.Collections.Generic;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Input;
using static AutoRest.CSharp.Output.Models.MethodSignatureModifiers;
using Azure.ResourceManager;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class OldMgmtExtensionClient : MgmtTypeProvider
    {
        private string _defaultName;
        public OldMgmtExtensionClient(OldMgmtExtensions publicExtension)
            : base(publicExtension.ResourceName)
        {
            Extension = publicExtension;
            _defaultName = $"{(publicExtension.WrappedResourceName != null ? publicExtension.WrappedResourceName : ResourceName)}ExtensionClient";
        }

        protected override ConstructorSignature? EnsureArmClientCtor()
        {
            return new ConstructorSignature(
                Name: Type.Name,
                Summary: null,
                Description: $"Initializes a new instance of the <see cref=\"{Type.Name}\"/> class.",
                Modifiers: Internal,
                Parameters: new[] { ArmClientParameter, ResourceIdentifierParameter },
                Initializer: new(
                    isBase: true,
                    arguments: new[] { ArmClientParameter, ResourceIdentifierParameter }));
        }

        protected override IEnumerable<MgmtClientOperation> EnsureAllOperations()
        {
            return Extension.AllMgmtOperations.Select(operation =>
            {
                // TODO -- these logic needs a thorough refactor -- the values MgmtRestOperation consumes here are actually coupled together, some of the values are calculated multiple times (here and in writers).
                // we just leave this implementation here since it could work for now
                return MgmtClientOperation.FromOperation(operation);
            });
        }

        protected override string CalculateOperationName(Operation operation, string clientResourceName)
        {
            return base.CalculateOperationName(operation, clientResourceName);
        }

        public override CSharpType? BaseType => typeof(ArmResource);

        protected override string DefaultName => _defaultName;

        protected override string DefaultNamespace => Configuration.MgmtConfiguration.IsArmCore ?
            base.DefaultNamespace : $"{base.DefaultNamespace}.Mock";

        public OldMgmtExtensions Extension { get; }

        public bool IsEmpty => Extension.IsEmpty;

        public override IEnumerable<Resource> ChildResources => Extension.ChildResources;

        private FormattableString? _description;
        public override FormattableString Description => _description ??= $"A class to add extension methods to {ResourceName}.";

        protected override string DefaultAccessibility => "public";

        protected override IEnumerable<MgmtClientOperation> EnsureClientOperations() => Extension.ClientOperations;
    }
}
