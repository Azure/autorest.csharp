// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using AutoRest.CSharp.Common.Input;
using System.Diagnostics;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Builders;
using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;

namespace AutoRest.CSharp.Output.Models.Types
{
    [DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
    internal abstract class TypeProvider
    {
        private readonly Lazy<INamedTypeSymbol?> _existingType;

        protected string? _deprecation;

        private TypeDeclarationOptions? _type;
        protected readonly SourceInputModel? _sourceInputModel;

        protected TypeProvider(string defaultNamespace, SourceInputModel? sourceInputModel)
        {
            _sourceInputModel = sourceInputModel;
            DefaultNamespace = defaultNamespace;
            _existingType = new Lazy<INamedTypeSymbol?>(() => sourceInputModel?.FindForType(DefaultNamespace, DefaultName));
        }

        protected TypeProvider(BuildContext context) : this(context.DefaultNamespace, context.SourceInputModel) { }

        public CSharpType Type => new(this, TypeArguments);
        public TypeDeclarationOptions Declaration => _type ??= BuildType();

        protected abstract string DefaultName { get; }
        protected virtual string DefaultNamespace { get; }
        protected abstract string DefaultAccessibility { get; }

        public bool IsValueType => TypeKind is TypeKind.Struct or TypeKind.Enum;
        public virtual bool IsEnum { get; protected init; } = false;

        private IReadOnlyList<CSharpType>? _typeArguments;
        protected IReadOnlyList<CSharpType> TypeArguments => _typeArguments ??= BuildTypeArguments().ToArray();

        public TypeProvider? DeclaringTypeProvider { get; protected init; }

        public string? Deprecated => _deprecation;
        protected virtual TypeKind TypeKind { get; } = TypeKind.Class;
        protected virtual bool IsAbstract { get; } = false;
        protected INamedTypeSymbol? ExistingType => _existingType.Value;
        public virtual SignatureType? SignatureType => null;

        internal virtual Type? SerializeAs => null;

        protected virtual IEnumerable<CSharpType> BuildTypeArguments()
        {
            yield break;
        }

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

        public static string GetDefaultModelNamespace(string? namespaceOverride, string defaultNamespace)
        {
            if (namespaceOverride != default)
            {
                return namespaceOverride;
            }

            if (Configuration.ModelNamespace)
            {
                return $"{defaultNamespace}.Models";
            }

            return defaultNamespace;
        }

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

        private string GetDebuggerDisplay()
        {
            if (_type is null)
                return "<pending calculation>";

            return $"TypeProvider ({Declaration.Accessibility} {Declaration.Namespace}.{Declaration.Name}";
        }
    }
}
