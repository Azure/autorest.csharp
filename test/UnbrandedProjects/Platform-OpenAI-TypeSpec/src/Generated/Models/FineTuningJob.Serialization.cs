// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Internal;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Models
{
    public partial class FineTuningJob
    {
        internal static FineTuningJob DeserializeFineTuningJob(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string id = default;
            FineTuningJobObject @object = default;
            DateTimeOffset createdAt = default;
            DateTimeOffset? finishedAt = default;
            string model = default;
            string fineTunedModel = default;
            string organizationId = default;
            FineTuningJobStatus status = default;
            FineTuningJobHyperparameters hyperparameters = default;
            string trainingFile = default;
            string validationFile = default;
            IReadOnlyList<string> resultFiles = default;
            long? trainedTokens = default;
            FineTuningJobError error = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("object"u8))
                {
                    @object = new FineTuningJobObject(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("created_at"u8))
                {
                    createdAt = DateTimeOffset.FromUnixTimeSeconds(property.Value.GetInt64());
                    continue;
                }
                if (property.NameEquals("finished_at"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        finishedAt = null;
                        continue;
                    }
                    finishedAt = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("model"u8))
                {
                    model = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("fine_tuned_model"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        fineTunedModel = null;
                        continue;
                    }
                    fineTunedModel = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("organization_id"u8))
                {
                    organizationId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("status"u8))
                {
                    status = new FineTuningJobStatus(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("hyperparameters"u8))
                {
                    hyperparameters = FineTuningJobHyperparameters.DeserializeFineTuningJobHyperparameters(property.Value);
                    continue;
                }
                if (property.NameEquals("training_file"u8))
                {
                    trainingFile = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("validation_file"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        validationFile = null;
                        continue;
                    }
                    validationFile = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("result_files"u8))
                {
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    resultFiles = array;
                    continue;
                }
                if (property.NameEquals("trained_tokens"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        trainedTokens = null;
                        continue;
                    }
                    trainedTokens = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("error"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        error = null;
                        continue;
                    }
                    error = FineTuningJobError.DeserializeFineTuningJobError(property.Value);
                    continue;
                }
            }
            return new FineTuningJob(id, @object, createdAt, finishedAt, model, fineTunedModel, organizationId, status, hyperparameters, trainingFile, validationFile, resultFiles, trainedTokens, error);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static FineTuningJob FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeFineTuningJob(document.RootElement);
        }
    }
}
