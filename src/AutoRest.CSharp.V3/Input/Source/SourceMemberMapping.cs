// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.V3.Input.Source
{
    public class SourceMemberMapping
    {
        public SourceMemberMapping(string schemaName, ISymbol existingMember)
        {
            SchemaName = schemaName;
            ExistingMember = existingMember;
        }

        public string SchemaName { get; }
        public ISymbol ExistingMember { get; }
    }
}