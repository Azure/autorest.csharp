// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Models;
using Azure.ResourceManager;
using static AutoRest.CSharp.Output.Models.MethodSignatureModifiers;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class NewMgmtExtensionClient : MgmtTypeProvider
    {
        private readonly IEnumerable<MgmtClientOperation> _operations;
        public NewMgmtExtensionClient(CSharpType resourceType, IEnumerable<MgmtClientOperation> operations)
            : base(resourceType.Name)
        {
            _operations = operations;
            ExtendedResourceType = resourceType;
            DefaultName = $"{resourceType.Name}ExtensionClient";
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
            return _operations;
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

        private bool? _isEmpty;
        public bool IsEmpty => _isEmpty ??= _operations.Any();

        public override IEnumerable<Resource> ChildResources => Enumerable.Empty<Resource>();

        private FormattableString? _description;
        public override FormattableString Description => _description ??= $"A class to add extension methods to {ResourceName}.";

        protected override string DefaultAccessibility => "public";

        protected override IEnumerable<MgmtClientOperation> EnsureClientOperations() => AllOperations;
    }
}
