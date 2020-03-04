// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.V3.Input.Source
{
    public class ModelTypeMapping
    {
        public string SchemaName { get; }
        public INamedTypeSymbol ExistingType { get; }

        public SourceMemberMapping[] PropertyMappings { get; }

        public ModelTypeMapping(string schemaName, INamedTypeSymbol existingType, SourceMemberMapping[] propertyMappings)
        {
            SchemaName = schemaName;
            ExistingType = existingType;
            PropertyMappings = propertyMappings;
        }

        public SourceMemberMapping? GetMemberForSchema(string name)
        {
            return PropertyMappings.SingleOrDefault(p => p.SchemaName == name);
        }
    }
}
