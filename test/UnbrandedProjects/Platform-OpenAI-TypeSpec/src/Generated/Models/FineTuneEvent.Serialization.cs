// <auto-generated/>

#nullable disable

using System;
using System.Net.ClientModel.Core;
using System.Text.Json;

namespace OpenAI.Models
{
    public partial class FineTuneEvent
    {
        internal static FineTuneEvent DeserializeFineTuneEvent(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string @object = default;
            DateTimeOffset createdAt = default;
            string level = default;
            string message = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("object"u8))
                {
                    @object = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("created_at"u8))
                {
                    createdAt = DateTimeOffset.FromUnixTimeSeconds(property.Value.GetInt64());
                    continue;
                }
                if (property.NameEquals("level"u8))
                {
                    level = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("message"u8))
                {
                    message = property.Value.GetString();
                    continue;
                }
            }
            return new FineTuneEvent(@object, createdAt, level, message);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="result"> The result to deserialize the model from. </param>
        internal static FineTuneEvent FromResponse(PipelineResponse result)
        {
            using var document = JsonDocument.Parse(result.Content);
            return DeserializeFineTuneEvent(document.RootElement);
        }
    }
}
