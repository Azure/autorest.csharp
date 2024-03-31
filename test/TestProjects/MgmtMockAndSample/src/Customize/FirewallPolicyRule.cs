// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace MgmtMockAndSample.Models
{
    [CodeGenSerialization(nameof(NewStringSerializeProperty), "newStringSerializeProperty")]
    [CodeGenSerialization(nameof(NewArraySerializedProperty), "newArraySerializedProperty")]
    [CodeGenSerialization(nameof(NewDictionarySerializedProperty), new string[] {"fakeParent", "newDictionarySerializedProperty"}, SerializationValueHook = nameof(SerializeNameValue), DeserializationValueHook = nameof(DeserializeNameValue))]
    public abstract partial class FirewallPolicyRule
    {
        /// <summary>
        /// Add string property to FirewallPolicyRule.
        /// </summary>
        public string NewStringSerializeProperty { get; set; }
        /// <summary>
        /// Add list property to FirewallPolicyRule.
        /// </summary>
        public IList<string> NewArraySerializedProperty { get; set; }
        /// <summary>
        /// Add dictionary property to FirewallPolicyRule.
        /// </summary>
        public IDictionary<string, string> NewDictionarySerializedProperty { get; set; }

        /// <summary>
        /// Serialize the value of NewStringSerializeProperty.
        /// </summary>
        /// <param name="writer"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void SerializeNameValue(Utf8JsonWriter writer)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Deserialize the value of NewStringSerializeProperty.
        /// </summary>
        /// <param name="property"></param>
        /// <param name="value"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void DeserializeNameValue(JsonProperty property, ref IDictionary<string, string> value) // the type here is string since name is required
        {
            throw new System.NotImplementedException();
        }
    }
}
