// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace Inheritance.Models
{
    /// <summary>
    /// The SomeProperties class.
    /// </summary>
    [CodeGenSerialization(nameof(SomeProperty), SerializationValueHook = nameof(SerializationMethodHook))]
    public partial class SomeProperties : IUtf8JsonSerializable
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void SerializationMethodHook(Utf8JsonWriter writer)
        {
            writer.WriteStringValue("OverloadSucceeded");
        }

        /// <summary>
        /// Forwards call
        /// </summary>
        /// <param name="writer"></param>
        #pragma warning disable AZC0014 // Types from certain namespaces should not be exposed as part of public API surface.
        public void CallWrite(Utf8JsonWriter writer) => ((IUtf8JsonSerializable)this).Write(writer);
        #pragma warning restore AZC0014 // Types from certain namespaces should not be exposed as part of public API surface.
    }
}
