// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CognitiveServices.TextAnalytics.Models
{
    public partial class InnerError : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("code");
            writer.WriteStringValue(Code.ToString());
            writer.WritePropertyName("message");
            writer.WriteStringValue(Message);
            if (Target != null)
            {
                writer.WritePropertyName("target");
                writer.WriteStringValue(Target);
            }
            if (Innererror != null)
            {
                writer.WritePropertyName("innererror");
                writer.WriteObjectValue(Innererror);
            }
            writer.WriteEndObject();
        }
        internal static InnerError DeserializeInnerError(JsonElement element)
        {
            InnerError result = new InnerError();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("code"))
                {
                    result.Code = new InnerErrorCode(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("message"))
                {
                    result.Message = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("target"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Target = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("innererror"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Innererror = DeserializeInnerError(property.Value);
                    continue;
                }
            }
            return result;
        }
    }
}
