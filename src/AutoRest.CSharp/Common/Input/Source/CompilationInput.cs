// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Input.Source
{
    public record CompilationInput(Compilation Compilation, Func<INamedTypeSymbol, bool>? typeFilter = null, Func<IMethodSymbol, bool>? methodFilter = null);
}
