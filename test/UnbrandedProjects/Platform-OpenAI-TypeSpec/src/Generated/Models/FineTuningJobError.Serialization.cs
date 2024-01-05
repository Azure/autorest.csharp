// <auto-generated/>

#nullable disable

using System.ClientModel.Internal;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace OpenAI.Models
{
    public partial class FineTuningJobError
    {
        internal static FineTuningJobError DeserializeFineTuningJobError(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            OptionalProperty<string> message = default;
            OptionalProperty<string> code = default;
            OptionalProperty<string> param = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("message"u8))
                {
                    message = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("code"u8))
                {
                    code = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("param"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        param = null;
                        continue;
                    }
                    param = property.Value.GetString();
                    continue;
                }
            }
            return new FineTuningJobError(message.Value, code.Value, param.Value);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static FineTuningJobError FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeFineTuningJobError(document.RootElement);
        }
    }
}
