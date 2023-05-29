// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using AutoRest.CSharp.Utilities;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Input.Source
{
    public class SourcePropertySerializationMapping
    {
        public SourcePropertySerializationMapping(ISymbol existingMember, string[]? serializationPath, string? serializationHook, string? serializationValueHook, string? deserializationHook)
        {
            ExistingMember = existingMember;
            SerializationPath = serializationPath;
            SerializationHook = serializationHook;
            SerializationValueHook = serializationValueHook;
            DeserializationValueHook = deserializationHook;
        }

        public ISymbol ExistingMember { get; }
        public IReadOnlyList<string>? SerializationPath { get; }
        public string? SerializationHook { get; }
        public string? SerializationValueHook { get; }
        public string? DeserializationValueHook { get; }
    }
}
