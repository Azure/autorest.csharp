// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Input.Source
{
    public class SourcePropertySerailizationMapping
    {
        public SourcePropertySerailizationMapping(ISymbol existingMember, string[] serializationPath)
        {
            ExistingMember = existingMember;
            SerializationPath = serializationPath;
        }

        public ISymbol ExistingMember { get; }
        public string[] SerializationPath { get; }
    }
}
