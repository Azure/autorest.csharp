// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using AutoRest.CSharp.Utilities;
using Microsoft.CodeAnalysis;
using NUnit.Framework.Internal;

namespace AutoRest.CSharp.Input.Source
{
    public class SourcePropertySerializationMapping
    {
        public SourcePropertySerializationMapping(ISymbol? existingMember, string[]? serializationPath, string? serializationValueHook, string? deserializationHook)
        {
            ExistingMember = existingMember;
            SerializationPath = serializationPath;
            SerializationValueHook = serializationValueHook;
            DeserializationValueHook = deserializationHook;
        }
        public SourcePropertySerializationMapping(string? propertyName, string[]? serializationPath, string? serializationValueHook, string? deserializationHook)
        {
            PropertyName = propertyName;
            SerializationPath = serializationPath;
            SerializationValueHook = serializationValueHook;
            DeserializationValueHook = deserializationHook;
        }

        public ISymbol? ExistingMember { get; }
        public string? PropertyName { get; }
        public IReadOnlyList<string>? SerializationPath { get; }
        public string? SerializationValueHook { get; }
        public string? DeserializationValueHook { get; }
    }
}
