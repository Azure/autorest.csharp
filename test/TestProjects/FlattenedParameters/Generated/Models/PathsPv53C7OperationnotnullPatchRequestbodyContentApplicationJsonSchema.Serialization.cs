// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace FlattenedParameters.Models
{
    internal partial class PathsPv53C7OperationnotnullPatchRequestbodyContentApplicationJsonSchema : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(Items))
            {
                writer.WritePropertyName("items"u8);
                writer.WriteStartArray();
                foreach (var item in Items)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }
    }
}
