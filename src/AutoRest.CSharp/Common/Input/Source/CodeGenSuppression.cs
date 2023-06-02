using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Common.Input.Source
{
    internal record Suppression(string Name, IEnumerable<ISymbol> Types)
    {
        public bool Matches(ISymbol symbol)
        {
            if (symbol is IMethodSymbol methodSymbol)
            {
                string name = methodSymbol.Name;
                // Use friendly name for ctors
                if (methodSymbol.MethodKind == MethodKind.Constructor)
                {
                    name = methodSymbol.ContainingType.Name;
                }

                return Name == name &&
                        Types.SequenceEqual(methodSymbol.Parameters.Select(p => p.Type), SymbolEqualityComparer.Default);
            }
            else
            {
                return symbol.Name == Name;
            }
        }
    }
}
