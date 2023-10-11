// <auto-generated/>

#nullable disable

using System.ServiceModel.Rest.Core;
using System.Text.Json;

namespace OpenAI.Models
{
    public partial class DeleteFileResponse
    {
        internal static DeleteFileResponse DeserializeDeleteFileResponse(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string id = default;
            string @object = default;
            bool deleted = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("object"u8))
                {
                    @object = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("deleted"u8))
                {
                    deleted = property.Value.GetBoolean();
                    continue;
                }
            }
            return new DeleteFileResponse(id, @object, deleted);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="result"> The result to deserialize the model from. </param>
        internal static DeleteFileResponse FromResponse(PipelineResponse result)
        {
            using var document = JsonDocument.Parse(result.Content);
            return DeserializeDeleteFileResponse(document.RootElement);
        }
    }
}
