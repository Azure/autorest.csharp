// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Output.Models.Types;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Mgmt.AutoRest.PostProcess
{
    internal static class ModelFinder
    {
        public static IEnumerable<INamedTypeSymbol> GetResourceSymbols(Compilation compilation)
            => GetSymbols(compilation, MgmtContext.Library.ArmResources);

        public static IEnumerable<INamedTypeSymbol> GetCollectionSymbols(Compilation compilation)
            => GetSymbols(compilation, MgmtContext.Library.ResourceCollections);

        public static IEnumerable<INamedTypeSymbol> GetResourceDataSymbols(Compilation compilation)
            => GetSymbols(compilation, MgmtContext.Library.ResourceData);

        public static IEnumerable<INamedTypeSymbol> GetExtensionSymbols(Compilation compilation)
            => GetSymbols(compilation, MgmtContext.Library.ExtensionWrapper.AsIEnumerable());

        private static IEnumerable<INamedTypeSymbol> GetSymbols<T>(Compilation compilation, IEnumerable<T> providers) where T : TypeProvider
            => providers.Select(p => GetTypeSymbolFromCSharpType(compilation, p.Type));

        private static INamedTypeSymbol GetTypeSymbolFromCSharpType(Compilation compilation, CSharpType type)
        {
            var symbol = compilation.GetTypeByMetadataName($"{type.Namespace}.{type.Name}");
            Debug.Assert(symbol != null);
            return symbol;
        }
    }
}
