// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CustomizationsInCadl.Models
{
    public partial class FirstLayer
    {
        /// <summary> Property to change serialization and deserialization in this class and all derived classes. </summary>
        [CodeGenMemberSerializationHooks(SerializationValueHook = nameof(WriteStringToBeChanged))]
        public string StringToBeChanged { get; set; }

        internal void WriteStringToBeChanged(Utf8JsonWriter writer)
        {
            writer.WriteStringValue(StringToBeChanged.ToUpperInvariant());
        }
    }
}
