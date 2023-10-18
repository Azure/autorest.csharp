// <auto-generated/>

#nullable disable

using System.Net.ClientModel.Core;
using System.Text.Json;

namespace OpenAI.Models
{
    public partial class CreateCategories
    {
        internal static CreateCategories DeserializeCreateCategories(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            bool hate = default;
            bool hateThreatening = default;
            bool harassment = default;
            bool harassmentThreatening = default;
            bool selfHarm = default;
            bool selfHarmIntent = default;
            bool selfHarmInstructive = default;
            bool sexual = default;
            bool sexualMinors = default;
            bool violence = default;
            bool violenceGraphic = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("hate"u8))
                {
                    hate = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("hate/threatening"u8))
                {
                    hateThreatening = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("harassment"u8))
                {
                    harassment = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("harassment/threatening"u8))
                {
                    harassmentThreatening = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("self-harm"u8))
                {
                    selfHarm = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("self-harm/intent"u8))
                {
                    selfHarmIntent = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("self-harm/instructive"u8))
                {
                    selfHarmInstructive = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("sexual"u8))
                {
                    sexual = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("sexual/minors"u8))
                {
                    sexualMinors = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("violence"u8))
                {
                    violence = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("violence/graphic"u8))
                {
                    violenceGraphic = property.Value.GetBoolean();
                    continue;
                }
            }
            return new CreateCategories(hate, hateThreatening, harassment, harassmentThreatening, selfHarm, selfHarmIntent, selfHarmInstructive, sexual, sexualMinors, violence, violenceGraphic);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="result"> The result to deserialize the model from. </param>
        internal static CreateCategories FromResponse(PipelineResponse result)
        {
            using var document = JsonDocument.Parse(result.Content);
            return DeserializeCreateCategories(document.RootElement);
        }
    }
}
