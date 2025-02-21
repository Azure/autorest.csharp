// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;

namespace Azure.AI.FormRecognizer.Models
{
    public partial class TrainResult
    {
        internal static TrainResult DeserializeTrainResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<TrainingDocumentInfo> trainingDocuments = default;
            IReadOnlyList<FormFieldsReport> fields = default;
            float? averageModelAccuracy = default;
            IReadOnlyList<ErrorInformation> errors = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("trainingDocuments"u8))
                {
                    List<TrainingDocumentInfo> array = new List<TrainingDocumentInfo>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(TrainingDocumentInfo.DeserializeTrainingDocumentInfo(item));
                    }
                    trainingDocuments = array;
                    continue;
                }
                if (property.NameEquals("fields"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<FormFieldsReport> array = new List<FormFieldsReport>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(FormFieldsReport.DeserializeFormFieldsReport(item));
                    }
                    fields = array;
                    continue;
                }
                if (property.NameEquals("averageModelAccuracy"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    averageModelAccuracy = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("errors"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<ErrorInformation> array = new List<ErrorInformation>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ErrorInformation.DeserializeErrorInformation(item));
                    }
                    errors = array;
                    continue;
                }
            }
            return new TrainResult(trainingDocuments, fields ?? new ChangeTrackingList<FormFieldsReport>(), averageModelAccuracy, errors ?? new ChangeTrackingList<ErrorInformation>());
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static TrainResult FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content, new JsonDocumentOptions { MaxDepth = 256 });
            return DeserializeTrainResult(document.RootElement);
        }
    }
}
