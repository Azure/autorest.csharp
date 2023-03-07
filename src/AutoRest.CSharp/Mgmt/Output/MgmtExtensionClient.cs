// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using Azure.ResourceManager;
using static AutoRest.CSharp.Output.Models.MethodSignatureModifiers;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class MgmtExtensionClient : MgmtTypeProvider
    {
        private readonly IEnumerable<MgmtClientOperation> _operations;
        private readonly MgmtExtension? _extensionForChildResources;

        public MgmtExtensionClient(CSharpType resourceType, IEnumerable<MgmtClientOperation> operations, MgmtExtension? extensionForChildResources)
            : base(resourceType.Name)
        {
            _operations = operations;
            _extensionForChildResources = extensionForChildResources;
            ExtendedResourceType = resourceType;
            DefaultName = $"{resourceType.Name}ExtensionClient";
        }

        public override bool IsInitializedByProperties => true;

        public override bool HasChildResourceGetMethods => false;

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

        private Parameter? _generalExtensionParameter;
        private Parameter GeneralExtensionParameter => _generalExtensionParameter ??= new Parameter(
                "resource",
                null,
                typeof(ArmResource),
                null,
                ValidationType.None,
                null);

        protected override IEnumerable<MgmtClientOperation> EnsureClientOperations()
        {
            // here we capsulate the MgmtClientOperation again to remove the extra "extension parameter" we added when constructing them in MgmtExtension.EnsureClientOperations
            return _operations.Select(operation => MgmtClientOperation.FromOperations(operation)!);
        }

        protected override string CalculateOperationName(Operation operation, string clientResourceName)
        {
            return base.CalculateOperationName(operation, clientResourceName);
        }

        public CSharpType ExtendedResourceType { get; }

        public override CSharpType? BaseType => typeof(ArmResource);

        protected override string DefaultName { get; }

        protected override string DefaultNamespace => Configuration.MgmtConfiguration.IsArmCore ?
            base.DefaultNamespace : $"{base.DefaultNamespace}.Mock";

        public bool IsEmpty => !ClientOperations.Any() && !ChildResources.Any();

        public override IEnumerable<Resource> ChildResources => _extensionForChildResources?.ChildResources ?? Enumerable.Empty<Resource>();

        private FormattableString? _description;
        public override FormattableString Description => _description ??= $"A class to add extension methods to {ResourceName}.";

        protected override string DefaultAccessibility => "public";
    }
}
