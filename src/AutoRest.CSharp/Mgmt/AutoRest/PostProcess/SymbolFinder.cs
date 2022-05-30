// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Mgmt.AutoRest.PostProcess
{
    internal static class SymbolFinder
    {
        public static IEnumerable<INamedTypeSymbol> GetResourceSymbols(Compilation compilation)
            => GetNonNullSymbols(compilation, MgmtContext.Library.ArmResources);

        public static IEnumerable<INamedTypeSymbol> GetCollectionSymbols(Compilation compilation)
            => GetNonNullSymbols(compilation, MgmtContext.Library.ResourceCollections);

        public static IEnumerable<INamedTypeSymbol> GetResourceDataSymbols(Compilation compilation)
            => GetNonNullSymbols(compilation, MgmtContext.Library.ResourceData);

        public static IEnumerable<INamedTypeSymbol> GetExtensionSymbols(Compilation compilation)
            => GetNonNullSymbols(compilation, MgmtContext.Library.ExtensionWrapper.AsIEnumerable());

        public static IEnumerable<INamedTypeSymbol> GetModelSymbols(Compilation compilation)
            => GetNullableSymbols(compilation, MgmtContext.Library.Models).WhereNotNull();

        private static IEnumerable<INamedTypeSymbol> GetNonNullSymbols<T>(Compilation compilation, IEnumerable<T> providers) where T : TypeProvider
            => providers.Select(p => GetTypeSymbol(compilation, p.Type));

        private static IEnumerable<INamedTypeSymbol?> GetNullableSymbols<T>(Compilation compilation, IEnumerable<T> providers) where T : TypeProvider
            => providers.Select(p => GetNullableTypeSymbol(compilation, p.Type));

        public static INamedTypeSymbol? GetNullableTypeSymbol(Compilation compilation, CSharpType type)
            => GetNullableTypeSymbol(compilation, type.Namespace, type.Name);

        public static INamedTypeSymbol GetTypeSymbol(Compilation compilation, CSharpType type)
        {
            var symbol = GetNullableTypeSymbol(compilation, type);
            Debug.Assert(symbol != null);
            return symbol;
        }

        public static INamedTypeSymbol? GetNullableTypeSymbol(Compilation compilation, string @namespace, string name)
            => compilation.GetTypeByMetadataName($"{@namespace}.{name}");

        public static INamedTypeSymbol GetTypeSymbol(Compilation compilation, string @namespace, string name)
        {
            var symbol = GetNullableTypeSymbol(compilation, @namespace, name);
            Debug.Assert(symbol != null);
            return symbol;
        }
    }
}
