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
        public SourcePropertySerializationMapping(ISymbol existingMember, string[]? serializationPath, string? serializationValueHook, string? deserializationHook, string? bicepSerializationValueHook)
        {
            ExistingMember = existingMember;
            SerializationPath = serializationPath;
            SerializationValueHook = serializationValueHook;
            DeserializationValueHook = deserializationHook;
            BicepSerializationValueHook = bicepSerializationValueHook;
        }

        public ISymbol ExistingMember { get; }
        public IReadOnlyList<string>? SerializationPath { get; }
        public string? SerializationValueHook { get; }
        public string? DeserializationValueHook { get; }

        public string? BicepSerializationValueHook { get; }
    }
}
