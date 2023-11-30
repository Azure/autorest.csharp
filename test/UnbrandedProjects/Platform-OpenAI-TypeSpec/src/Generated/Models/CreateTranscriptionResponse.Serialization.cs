// <auto-generated/>

#nullable disable

using System.Net.ClientModel.Core;
using System.Text.Json;

namespace OpenAI.Models
{
    public partial class CreateTranscriptionResponse
    {
        internal static CreateTranscriptionResponse DeserializeCreateTranscriptionResponse(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string text = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("text"u8))
                {
                    text = property.Value.GetString();
                    continue;
                }
            }
            return new CreateTranscriptionResponse(text);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static CreateTranscriptionResponse FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeCreateTranscriptionResponse(document.RootElement);
        }
    }
}
