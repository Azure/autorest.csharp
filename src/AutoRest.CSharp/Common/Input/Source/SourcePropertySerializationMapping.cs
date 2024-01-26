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
        private readonly string? _propertyName;
        private readonly ISymbol? _existingMember;

        public SourcePropertySerializationMapping(string propertyName, IReadOnlyList<string>? serializationPath, string? serializationValueHook, string? deserializationValueHook)
        {
            _propertyName = propertyName;
            SerializationPath = serializationPath;
            SerializationValueHook = serializationValueHook;
            DeserializationValueHook = deserializationValueHook;
        }

        public SourcePropertySerializationMapping(ISymbol existingMember, IReadOnlyList<string>? serializationPath, string? serializationValueHook, string? deserializationHook)
        {
            _existingMember = existingMember;
            SerializationPath = serializationPath;
            SerializationValueHook = serializationValueHook;
            DeserializationValueHook = deserializationHook;
        }

        public string PropertyName => _propertyName ?? throw new InvalidOperationException("we should not call this when the attribute is defined on the property instead of the type");
        public ISymbol ExistingMember => _existingMember ?? throw new InvalidOperationException("we should not call this when the attribute is defined on the type instead of the property");
        public IReadOnlyList<string>? SerializationPath { get; }
        public string? SerializationValueHook { get; }
        public string? DeserializationValueHook { get; }
    }
}
