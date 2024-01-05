// <auto-generated/>

#nullable disable

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Models
{
    public partial class ListFilesResponse
    {
        internal static ListFilesResponse DeserializeListFilesResponse(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string @object = default;
            IReadOnlyList<OpenAIFile> data = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("object"u8))
                {
                    @object = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("data"u8))
                {
                    List<OpenAIFile> array = new List<OpenAIFile>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(OpenAIFile.DeserializeOpenAIFile(item));
                    }
                    data = array;
                    continue;
                }
            }
            return new ListFilesResponse(@object, data);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static ListFilesResponse FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeListFilesResponse(document.RootElement);
        }
    }
}
