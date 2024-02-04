// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace AutoRest.CSharp.Input.Source
{
    public class SourcePropertySerializationMapping
    {
        public SourcePropertySerializationMapping(string propertyName, IReadOnlyList<string>? serializationPath, string? serializationValueHook, string? deserializationValueHook, string? bicepSerializationValueHook)
        {
            PropertyName = propertyName;
            SerializationPath = serializationPath;
            SerializationValueHook = serializationValueHook;
            DeserializationValueHook = deserializationValueHook;
            BicepSerializationValueHook = bicepSerializationValueHook;
        }

        public string PropertyName { get; }
        public IReadOnlyList<string>? SerializationPath { get; }
        public string? SerializationValueHook { get; }
        public string? DeserializationValueHook { get; }

        public string? BicepSerializationValueHook { get; }
    }
}
