// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.CodeAnalysis;
using System.Collections.Generic;

namespace AutoRest.CSharp.Input.Source
{
    public class SourceInputHelper
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
