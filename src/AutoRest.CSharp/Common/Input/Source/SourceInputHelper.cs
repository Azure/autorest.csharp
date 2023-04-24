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
    }
}
