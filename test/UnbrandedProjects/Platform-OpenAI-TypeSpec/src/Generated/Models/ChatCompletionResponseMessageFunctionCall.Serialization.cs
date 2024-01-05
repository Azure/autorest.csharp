// <auto-generated/>

#nullable disable

using System.ClientModel.Primitives;
using System.Text.Json;

namespace OpenAI.Models
{
    public partial class ChatCompletionResponseMessageFunctionCall
    {
        internal static ChatCompletionResponseMessageFunctionCall DeserializeChatCompletionResponseMessageFunctionCall(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string name = default;
            string arguments = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("arguments"u8))
                {
                    arguments = property.Value.GetString();
                    continue;
                }
            }
            return new ChatCompletionResponseMessageFunctionCall(name, arguments);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static ChatCompletionResponseMessageFunctionCall FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeChatCompletionResponseMessageFunctionCall(document.RootElement);
        }
    }
}
