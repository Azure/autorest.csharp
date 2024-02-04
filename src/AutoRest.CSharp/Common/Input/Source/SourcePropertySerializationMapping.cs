// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace AutoRest.CSharp.Input.Source
{
    public class SourcePropertySerializationMapping
    {
        public SourcePropertySerializationMapping(string propertyName, IReadOnlyList<string>? serializationPath, string? serializationValueHook, string? deserializationValueHook)
        {
            PropertyName = propertyName;
            SerializationPath = serializationPath;
            SerializationValueHook = serializationValueHook;
            DeserializationValueHook = deserializationValueHook;
        }

        public string PropertyName { get; }
        public IReadOnlyList<string>? SerializationPath { get; }
        public string? SerializationValueHook { get; }
        public string? DeserializationValueHook { get; }
    }
}
