// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Input.Source
{
    public abstract class CompilationInput
    {
        private Compilation _compilation;
        private Func<INamedTypeSymbol, bool>? _typeFilter;
        private Func<IMethodSymbol, bool>? _methodFilter;

        public CompilationInput(Compilation compilation, Func<INamedTypeSymbol, bool>? typeFilter = null, Func<IMethodSymbol, bool>? methodFilter = null)
        {
            _compilation= compilation;
            _typeFilter= typeFilter;
            _methodFilter= methodFilter;
        }

        public Compilation Compilation => _compilation;
        public bool FilterType(INamedTypeSymbol type) => _typeFilter == null || _typeFilter(type);
        public bool FilterMethod(IMethodSymbol method) => _methodFilter == null || _methodFilter(method);
    }
}
