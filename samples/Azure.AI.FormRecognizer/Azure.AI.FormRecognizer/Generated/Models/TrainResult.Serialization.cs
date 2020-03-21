// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

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
            TrainResult result;
            IList<TrainingDocumentInfo> trainingDocuments = new List<TrainingDocumentInfo>();
            IList<FormFieldsReport> fields = default;
            float? averageModelAccuracy = default;
            IList<ErrorInformation> errors = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("trainingDocuments"))
                {
                    List<TrainingDocumentInfo> array = new List<TrainingDocumentInfo>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(TrainingDocumentInfo.DeserializeTrainingDocumentInfo(item));
                    }
                    trainingDocuments = array;
                    continue;
                }
                if (property.NameEquals("fields"))
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
                if (property.NameEquals("averageModelAccuracy"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    averageModelAccuracy = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("errors"))
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
            result = new TrainResult(trainingDocuments, fields, averageModelAccuracy, errors);
            return result;
        }
    }
}
