// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Net.ClientModel.Core;
using System.Text.Json;

namespace OpenAI.Models
{
    public partial class CreateModerationResponse
    {
        internal static CreateModerationResponse DeserializeCreateModerationResponse(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string id = default;
            string model = default;
            IReadOnlyList<CreateModerationResponseResult> results = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("model"u8))
                {
                    model = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("results"u8))
                {
                    List<CreateModerationResponseResult> array = new List<CreateModerationResponseResult>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(CreateModerationResponseResult.DeserializeCreateModerationResponseResult(item));
                    }
                    results = array;
                    continue;
                }
            }
            return new CreateModerationResponse(id, model, results);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static CreateModerationResponse FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeCreateModerationResponse(document.RootElement);
        }
    }
}
