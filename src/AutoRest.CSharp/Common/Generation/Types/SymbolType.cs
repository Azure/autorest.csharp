// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Buffers;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutoRest.CSharp.Generation.Writers;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Generation.Types
{
    internal sealed class SymbolType : CSharpType
    {
        public SymbolType(INamedTypeSymbol symbol, bool isNullable)
            : base(@namespace: symbol.ContainingNamespace.ToDisplayString(),
                  name: symbol.Name,
                  isValueType: symbol.IsValueType,
                  isEnum: symbol.TypeKind == TypeKind.Enum,
                  isPublic: symbol.DeclaredAccessibility.HasFlag(Accessibility.Public),
                  arguments: symbol.TypeArguments.Select(t => new SymbolType((INamedTypeSymbol)t, false)).ToArray(),
                  isNullable: isNullable,
                  serializeAs: null)
        {
            Symbol = symbol;
        }

        public INamedTypeSymbol Symbol { get; }

        protected override bool Equals(CSharpType otherType, bool ignoreNullable)
        {
            if (otherType is not SymbolType other)
                return false;

            return SymbolEqualityComparer.Default.Equals(Symbol, other.Symbol) &&
                    Arguments.SequenceEqual(other.Arguments) &&
                    (ignoreNullable || IsNullable == other.IsNullable);
        }

        public override bool Equals(Type type) => false;
        protected override int BuildHashCode()
        {
            var arguments = new HashCode();
            foreach (var arg in Arguments)
            {
                arguments.Add(arg);
            }
            return HashCode.Combine(SymbolEqualityComparer.Default.GetHashCode(Symbol), arguments.ToHashCode(), IsNullable);
        }

        public override CSharpType GetGenericTypeDefinition()
            => throw new NotSupportedException($"{nameof(Types.SymbolType)} doesn't support generics.");

        public override CSharpType WithNullable(bool isNullable) =>
            isNullable == IsNullable ? this : new SymbolType(Symbol, isNullable);

        public override string ToString()
        {
            return new CodeWriter().Append($"{this}").ToString(false);
        }

        public override bool TryGetCSharpFriendlyName([MaybeNullWhen(false)] out string name)
        {
            name = null;
            return false;
        }
    }
}
