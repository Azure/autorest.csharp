// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Builders;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal abstract class TypeProvider
    {
        protected readonly BuildContext _context;
        private readonly Lazy<INamedTypeSymbol?> _existingType;
        private TypeDeclarationOptions? _type;

        protected TypeProvider(BuildContext context)
        {
            _context = context;
            _existingType = new Lazy<INamedTypeSymbol?>(() =>  _context.SourceInputModel?.FindForType(DefaultNamespace, DefaultName));
        }

        public CSharpType Type => new CSharpType(
            this,
            Declaration.Namespace,
            Declaration.Name,
            TypeKind == TypeKind.Struct || TypeKind == TypeKind.Enum);
        public TypeDeclarationOptions Declaration => _type ??= BuildType();

        protected abstract string DefaultName { get; }
        protected virtual string DefaultNamespace => _context.DefaultNamespace;
        protected abstract string DefaultAccessibility { get; }
        protected virtual TypeKind TypeKind { get; } = TypeKind.Class;
        protected INamedTypeSymbol? ExistingType => _existingType.Value;

        private TypeDeclarationOptions BuildType()
        {
            return BuilderHelpers.CreateTypeAttributes(
                DefaultName,
                DefaultNamespace,
                DefaultAccessibility,
                ExistingType,
                existingTypeOverrides: TypeKind == TypeKind.Enum);
        }
    }
}
