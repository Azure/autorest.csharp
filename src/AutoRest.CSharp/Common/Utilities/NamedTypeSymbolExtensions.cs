// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Utilities
{
    internal static class NamedTypeSymbolExtensions
    {
        private static readonly SymbolDisplayFormat FullyQualifiedNameFormat = new(typeQualificationStyle: SymbolDisplayTypeQualificationStyle.NameAndContainingTypesAndNamespaces);

        public static CSharpType GetCSharpType(this INamedTypeSymbol symbol)
        {
            if (symbol.ConstructedFrom.SpecialType == SpecialType.System_Nullable_T)
            {
                return GetCSharpType((INamedTypeSymbol)symbol.TypeArguments[0]).WithNullable(true);
            }

            var symbolName = symbol.ToDisplayString(FullyQualifiedNameFormat);
            var assemblyName = symbol.ContainingAssembly.Name;
            if (symbol.TypeArguments.Length > 0)
            {
                symbolName += $"`{symbol.TypeArguments.Length}";
            }

            var type = Type.GetType(symbolName) ?? Type.GetType($"{symbolName}, {assemblyName}") ?? throw new InvalidOperationException($"Type '{symbolName}' can't be found in assembly '{assemblyName}'.");
            return symbol.TypeArguments.Length > 0
                ? new CSharpType(type, symbol.TypeArguments.Cast<INamedTypeSymbol>().Select(GetCSharpType).ToArray())
                : type;
        }

        public static bool IsSameType(this INamedTypeSymbol symbol, CSharpType type)
        {
            if (type.IsValueType && type.IsNullable) // for cases such as `int?`
            {
                if (symbol.ConstructedFrom.SpecialType != SpecialType.System_Nullable_T)
                    return false;
                return IsSameType((INamedTypeSymbol)symbol.TypeArguments.Single(), type.GetNonNullable());
            }

            if (symbol.ContainingNamespace.ToString() != type.Namespace || symbol.Name != type.Name || symbol.TypeArguments.Length != type.Arguments.Length)
            {
                return false;
            }

            for (int i = 0; i < type.Arguments.Length; ++i)
            {
                if (!IsSameType((INamedTypeSymbol)symbol.TypeArguments[i], type.Arguments[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
