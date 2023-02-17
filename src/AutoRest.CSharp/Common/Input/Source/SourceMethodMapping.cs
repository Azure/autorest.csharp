// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using AutoRest.CSharp.Generation.Types;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Input.Source
{
    internal record SourceMethodMapping(string OriginalName, IReadOnlyList<CSharpType> ParameterTypes, ISymbol ExistingMember);
}
