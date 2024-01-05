// <auto-generated/>

#nullable disable

using System.ClientModel.Primitives;
using System.Text.Json;

namespace OpenAI.Models
{
    public partial class CreateModerationResponseResult
    {
        internal static CreateModerationResponseResult DeserializeCreateModerationResponseResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            bool flagged = default;
            CreateModerationResponseResultCategories categories = default;
            CreateModerationResponseResultCategoryScores categoryScores = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("flagged"u8))
                {
                    flagged = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("categories"u8))
                {
                    categories = CreateModerationResponseResultCategories.DeserializeCreateModerationResponseResultCategories(property.Value);
                    continue;
                }
                if (property.NameEquals("category_scores"u8))
                {
                    categoryScores = CreateModerationResponseResultCategoryScores.DeserializeCreateModerationResponseResultCategoryScores(property.Value);
                    continue;
                }
            }
            return new CreateModerationResponseResult(flagged, categories, categoryScores);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static CreateModerationResponseResult FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeCreateModerationResponseResult(document.RootElement);
        }
    }
}
