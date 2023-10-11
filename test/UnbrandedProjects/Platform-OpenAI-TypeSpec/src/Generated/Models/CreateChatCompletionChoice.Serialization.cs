// <auto-generated/>

#nullable disable

using System.ServiceModel.Rest.Core;
using System.Text.Json;

namespace OpenAI.Models
{
    public partial class CreateChatCompletionChoice
    {
        internal static CreateChatCompletionChoice DeserializeCreateChatCompletionChoice(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            long index = default;
            ChatCompletionResponseMessage message = default;
            CreateChatCompletionChoiceFinishReason finishReason = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("index"u8))
                {
                    index = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("message"u8))
                {
                    message = ChatCompletionResponseMessage.DeserializeChatCompletionResponseMessage(property.Value);
                    continue;
                }
                if (property.NameEquals("finish_reason"u8))
                {
                    finishReason = new CreateChatCompletionChoiceFinishReason(property.Value.GetString());
                    continue;
                }
            }
            return new CreateChatCompletionChoice(index, message, finishReason);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="result"> The result to deserialize the model from. </param>
        internal static CreateChatCompletionChoice FromResponse(PipelineResponse result)
        {
            using var document = JsonDocument.Parse(result.Content);
            return DeserializeCreateChatCompletionChoice(document.RootElement);
        }
    }
}
