// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using Azure.ResourceManager;
using static AutoRest.CSharp.Output.Models.MethodSignatureModifiers;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class BaseResource : MgmtTypeProvider
    {
        private const string DataFieldName = "_data";
        /// <summary>
        /// Finds the corresponding <see cref="ResourceData"/> of this <see cref="Resource"/>
        /// </summary>
        public ResourceData ResourceData { get; }

        public BaseResource(string resourceName, IEnumerable<Resource> derivedResources) : base(resourceName)
        {
            DerivedResources = derivedResources;
            ResourceData = derivedResources.First().ResourceData;
        }

        protected override bool IsAbstract => true;

        public IEnumerable<Resource> DerivedResources { get; private set; }

        public override CSharpType? BaseType => typeof(ArmResource);

        public override FormattableString Description => $"TODO";

        private string? _defaultName;
        protected override string DefaultName => _defaultName ??= ResourceName.AddResourceSuffixToResourceName();

        protected override ConstructorSignature? EnsureArmClientCtor()
        {
            return new ConstructorSignature(
              Name: Type.Name,
              null,
              Description: $"Initializes a new instance of the <see cref=\"{Type.Name}\"/> class.",
              Modifiers: Internal,
              Parameters: new[] { ArmClientParameter, ResourceIdentifierParameter },
              Initializer: new(
                  isBase: true,
                  arguments: new[] { ArmClientParameter, ResourceIdentifierParameter }));
        }

        protected override ConstructorSignature? EnsureResourceDataCtor()
        {
            return new ConstructorSignature(
                Name: Type.Name,
                null,
                Description: $"Initializes a new instance of the <see cref = \"{Type.Name}\"/> class.",
                Modifiers: Internal,
                Parameters: new[] { ArmClientParameter, ResourceDataParameter },
                Initializer: new(
                    IsBase: false,
                    Arguments: new FormattableString[] { $"{ArmClientParameter.Name:I}", Resource.ResourceDataIdExpression($"{ResourceDataParameter.Name:I}", ResourceData) }));
        }

        protected override IEnumerable<MgmtClientOperation> EnsureClientOperations()
        {
            return Enumerable.Empty<MgmtClientOperation>();
        }

        protected override FieldModifiers FieldModifiers => base.FieldModifiers | FieldModifiers.ReadOnly;

        protected override IEnumerable<FieldDeclaration>? GetAdditionalFields()
        {
            yield return new FieldDeclaration(FieldModifiers, ResourceData.Type, DataFieldName);
        }

        public MethodSignature StaticFactoryMethod => new MethodSignature(
            Name: "GetResource",
            Summary: null,
            Description: null,
            Modifiers: MethodSignatureModifiers.Internal | MethodSignatureModifiers.Static,
            ReturnType: Type,
            ReturnDescription: null,
            Parameters: new[] { ArmClientParameter, ResourceDataParameter });

        public Parameter ResourceDataParameter => new(Name: "data", Description: $"The resource that is the target of operations.", Type: ResourceData.Type, DefaultValue: null, ValidationType.None, null);
    }
}
