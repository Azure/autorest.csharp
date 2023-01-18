// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Generation.Types;
using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;

namespace AutoRest.CSharp.Input.Source
{
    public static class SourceInputHelper
    {
        internal static IEnumerable<ITypeSymbol> GetSymbols(INamespaceSymbol namespaceSymbol)
        {
            foreach (var childNamespaceSymbol in namespaceSymbol.GetNamespaceMembers())
            {
                foreach (var symbol in GetSymbols(childNamespaceSymbol))
                {
                    yield return symbol;
                }
            }

            foreach (INamedTypeSymbol symbol in namespaceSymbol.GetTypeMembers())
            {
                yield return symbol;
            }
        }

        internal static bool IsEqualType(INamedTypeSymbol symbol, CSharpType type)
        {
            if (type.IsValueType && type.IsNullable)
            {
                if (symbol.Name != "Nullable" || symbol.TypeArguments.Length != 1)
                {
                    return false;
                }
                return IsEqualType((INamedTypeSymbol)symbol.TypeArguments.Single(), type.GetNonNullable());
            }

            if (symbol.ContainingNamespace.ToString() != type.Namespace || symbol.Name!= type.Name || symbol.TypeArguments.Length != type.Arguments.Length)
            {
                return false;
            }

            for (int i = 0; i < type.Arguments.Length; ++i)
            {
                if (!IsEqualType((INamedTypeSymbol)symbol.TypeArguments[i], type.Arguments[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
