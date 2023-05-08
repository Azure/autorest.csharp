// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using AutoRest.CSharp.Utilities;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Input.Source
{
    public class SourcePropertySerailizationMapping
    {
        public SourcePropertySerailizationMapping(ISymbol existingMember, string[]? serializationPath, string? serializationHook, string? deserializationHook)
        {
            ExistingMember = existingMember;
            SerializationPath = serializationPath ?? new[] {existingMember.Name.ToVariableName()};
            SerializationHook = serializationHook;
            DeserializationHook = deserializationHook;
        }

        public ISymbol ExistingMember { get; }
        public IReadOnlyList<string> SerializationPath { get; }
        public string? SerializationHook { get; }
        public string? DeserializationHook { get; }
    }
}
