// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.V3.Input.Source
{
    public class SourceTypeMapping
    {
        public string SchemaName { get; }
        public INamedTypeSymbol ExistingType { get; }

        public SourceTypeMapping(string schemaName, INamedTypeSymbol existingType)
        {
            SchemaName = schemaName;
            ExistingType = existingType;
        }
    }
}
