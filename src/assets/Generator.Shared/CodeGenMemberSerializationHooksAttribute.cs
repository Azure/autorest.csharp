// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;

namespace Azure.Core
{
    [AttributeUsage(AttributeTargets.Property)]
    internal class CodeGenMemberSerializationHooksAttribute : Attribute
    {
        public string? SerializationHookMethodName { get; }
        public string? DeserializationHookMethodName { get; }

        /// <summary>
        /// Construct information about the serialization and deserialization hook methods for this property.
        /// The signature of the serialization hook method must be or compatible with when invoking:
        /// private void SerializeHook(Utf8JsonWriter writer);
        /// The signature of the deserialization hook method must be or compatible with when invoking:
        /// private void DeserializationHook(JsonProperty property, ref Optional&lt;TypeOfTheProperty&gt; propertyValue);
        ///
        /// Leave null value on either serializationHookMethodName or deserializationHookMethodName to indicate that the generator will not change its corresponding behavior.
        /// </summary>
        /// <param name="serializationHookMethodName">the method name of the serialization hook method</param>
        /// <param name="deserializationHookMethodName">the method name of the deserialization hook method</param>
        public CodeGenMemberSerializationHooksAttribute(string? serializationHookMethodName, string? deserializationHookMethodName)
        {
            SerializationHookMethodName = serializationHookMethodName;
            DeserializationHookMethodName = deserializationHookMethodName;
        }
    }
}
