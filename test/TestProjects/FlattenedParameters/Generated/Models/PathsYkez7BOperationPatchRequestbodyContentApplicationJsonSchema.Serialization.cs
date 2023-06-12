// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace FlattenedParameters.Models
{
    internal partial class PathsYkez7BOperationPatchRequestbodyContentApplicationJsonSchema : IUtf8JsonSerializable, IModelSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelSerializable)this).Serialize(writer, new SerializableOptions());

        void IModelSerializable.Serialize(Utf8JsonWriter writer, SerializableOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(Items))
            {
                if (Items != null)
                {
                    writer.WritePropertyName("items"u8);
                    writer.WriteStartArray();
                    foreach (var item in Items)
                    {
                        writer.WriteStringValue(item);
                    }
                    writer.WriteEndArray();
                }
                else
                {
                    writer.WriteNull("items");
                }
            }
            writer.WriteEndObject();
        }
    }
}
