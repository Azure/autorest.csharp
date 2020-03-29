// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.V3.Input.Source
{
    public class TypeMapping
    {
        public TypeMapping(string originalName, INamedTypeSymbol existingType)
        {
            OriginalName = originalName;
            ExistingType = existingType;
        }

        public string OriginalName { get; }
        public INamedTypeSymbol ExistingType { get; }
    }
}