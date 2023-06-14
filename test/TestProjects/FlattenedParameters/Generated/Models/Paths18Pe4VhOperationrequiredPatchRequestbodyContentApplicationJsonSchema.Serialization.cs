// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace FlattenedParameters.Models
{
    internal partial class Paths18Pe4VhOperationrequiredPatchRequestbodyContentApplicationJsonSchema : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("flattened"u8);
            writer.WriteStartObject();
            writer.WritePropertyName("required"u8);
            writer.WriteStringValue(Required);
            if (Optional.IsDefined(NonRequired))
            {
                writer.WritePropertyName("non_required"u8);
                writer.WriteStringValue(NonRequired);
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }
    }
}
