// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.V3.Generation.Types;
using AutoRest.CSharp.V3.Input.Source;
using AutoRest.CSharp.V3.Output.Builders;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.V3.Output.Models.Types
{
    internal abstract class ITypeProvider
    {
        private readonly BuildContext _context;
        private TypeDeclarationOptions? _type;
        private TypeMapping? _mapping;

        protected ITypeProvider(BuildContext context)
        {
            _context = context;
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

        private TypeDeclarationOptions BuildType()
        {
            _mapping = _context.SourceInputModel.FindForType(DefaultNamespace, DefaultName);

            return BuilderHelpers.CreateTypeAttributes(
                DefaultName,
                DefaultNamespace,
                DefaultAccessibility,
                _mapping?.ExistingType,
                existingTypeOverrides: TypeKind == TypeKind.Enum);
        }
    }
}
