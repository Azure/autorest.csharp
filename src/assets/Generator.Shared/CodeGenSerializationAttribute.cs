// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;

namespace Azure.Core
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true, Inherited = true)]
    internal class CodeGenSerializationAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets the property name which these hooks should apply to
        /// When this attribute applies to a type (class or struct), we must have a non-null PropertyName
        /// When this attribute applies to a property, the value of PropertyName will be ignored
        /// </summary>
        public string? PropertyName { get; set; }
        public string[]? SerializationPath { get; }
        /// <summary>
        /// Gets or sets the method name to use when serializing the property value (property name excluded)
        /// The signature of the serialization hook method must be or compatible with when invoking:
        /// private void SerializeHook(Utf8JsonWriter writer);
        /// </summary>
        public string? SerializationValueHook { get; set; }
        /// <summary>
        /// Gets or sets the method name to use when deserializing the property value from the JSON
        /// private static void DeserializationHook(JsonProperty property, ref TypeOfTheProperty propertyValue); // if the property is required
        /// private static void DeserializationHook(JsonProperty property, ref Optional&lt;TypeOfTheProperty&gt; propertyValue); // if the property is optional
        /// </summary>
        public string? DeserializationValueHook { get; set; }

        public CodeGenSerializationAttribute(string propertyName)
        {
            PropertyName = propertyName;
            SerializationPath = null;
        }

        public CodeGenSerializationAttribute(string propertyName, string serializationName)
        {
            PropertyName = propertyName;
            SerializationPath = new[] { serializationName };
        }

        public CodeGenSerializationAttribute(string propertyName, string[] serializationPath)
        {
            PropertyName = propertyName;
            SerializationPath = serializationPath;
        }
    }
}
