// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

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
            Optional<IReadOnlyList<FormFieldsReport>> fields = default;
            Optional<float> averageModelAccuracy = default;
            Optional<IReadOnlyList<ErrorInformation>> errors = default;
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
            return new TrainResult(trainingDocuments, Optional.ToList(fields), Optional.ToNullable(averageModelAccuracy), Optional.ToList(errors));
        }
    }
}
