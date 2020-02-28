// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace lro.Models
{
    public partial class OperationResult : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Status != null)
            {
                writer.WritePropertyName("status");
                writer.WriteStringValue(Status.Value.ToString());
            }
            if (Error != null)
            {
                writer.WritePropertyName("error");
                writer.WriteObjectValue(Error);
            }
            writer.WriteEndObject();
        }
        internal static OperationResult DeserializeOperationResult(JsonElement element)
        {
            OperationResult result = new OperationResult();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("status"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Status = new OperationResultStatus(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("error"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Error = OperationResultError.DeserializeOperationResultError(property.Value);
                    continue;
                }
            }
            return result;
        }
    }
}
