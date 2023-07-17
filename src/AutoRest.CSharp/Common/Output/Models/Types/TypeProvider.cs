// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Builders;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal abstract class TypeProvider
    {
        private readonly Lazy<INamedTypeSymbol?> _existingType;

        protected string? _deprecated;

        private TypeDeclarationOptions? _type;

        protected TypeProvider(string defaultNamespace, SourceInputModel? sourceInputModel)
        {
            DefaultNamespace = defaultNamespace;
            _existingType = new Lazy<INamedTypeSymbol?>(() => sourceInputModel?.FindForType(DefaultNamespace, DefaultName));
        }

        protected TypeProvider(BuildContext context) : this(context.DefaultNamespace, context.SourceInputModel) {}

        public CSharpType Type => new(this, TypeKind is TypeKind.Struct or TypeKind.Enum, this is EnumType);
        public TypeDeclarationOptions Declaration => _type ??= BuildType();

        protected abstract string DefaultName { get; }
        protected virtual string DefaultNamespace { get; }
        protected abstract string DefaultAccessibility { get; }

        public string? Deprecated => _deprecated;
        protected virtual TypeKind TypeKind { get; } = TypeKind.Class;
        protected virtual bool IsAbstract { get; } = false;
        protected INamedTypeSymbol? ExistingType => _existingType.Value;

        internal virtual Type? SerializeAs => null;

        private TypeDeclarationOptions BuildType()
        {
            return BuilderHelpers.CreateTypeAttributes(
                DefaultName,
                DefaultNamespace,
                DefaultAccessibility,
                ExistingType,
                existingTypeOverrides: TypeKind == TypeKind.Enum,
                isAbstract: IsAbstract);
        }

        public static string GetDefaultModelNamespace(string? namespaceExtension, string defaultNamespace)
        {
            if (namespaceExtension != default)
            {
                return namespaceExtension;
            }

            if (Configuration.ModelNamespace)
            {
                return $"{defaultNamespace}.Models";
            }

            return defaultNamespace;
        }

        public static string GetDefaultNamespace(string? namespaceExtension, BuildContext context)
            => GetDefaultModelNamespace(namespaceExtension, context.DefaultNamespace);

        public override bool Equals(object? obj)
        {
            if (obj is null)
                return false;
            if (obj is not TypeProvider other)
                return false;

            return string.Equals(DefaultName, other.DefaultName, StringComparison.Ordinal) &&
                string.Equals(DefaultNamespace, other.DefaultNamespace, StringComparison.Ordinal) &&
                string.Equals(DefaultAccessibility, other.DefaultAccessibility, StringComparison.Ordinal) &&
                TypeKind == other.TypeKind;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(DefaultName, DefaultNamespace, DefaultAccessibility, TypeKind);
        }
    }
}
