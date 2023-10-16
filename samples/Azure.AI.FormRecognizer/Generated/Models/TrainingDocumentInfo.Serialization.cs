// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.AI.FormRecognizer.Models
{
    public partial class TrainingDocumentInfo : IUtf8JsonSerializable, IModelJsonSerializable<TrainingDocumentInfo>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<TrainingDocumentInfo>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<TrainingDocumentInfo>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("documentName"u8);
            writer.WriteStringValue(DocumentName);
            writer.WritePropertyName("pages"u8);
            writer.WriteNumberValue(Pages);
            writer.WritePropertyName("errors"u8);
            writer.WriteStartArray();
            foreach (var item in Errors)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("status"u8);
            writer.WriteStringValue(Status.ToSerialString());
            writer.WriteEndObject();
        }

        TrainingDocumentInfo IModelJsonSerializable<TrainingDocumentInfo>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument doc = JsonDocument.ParseValue(ref reader);
            return DeserializeTrainingDocumentInfo(doc.RootElement, options);
        }

        BinaryData IModelSerializable<TrainingDocumentInfo>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        TrainingDocumentInfo IModelSerializable<TrainingDocumentInfo>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeTrainingDocumentInfo(document.RootElement, options);
        }

        internal static TrainingDocumentInfo DeserializeTrainingDocumentInfo(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string documentName = default;
            int pages = default;
            IReadOnlyList<ErrorInformation> errors = default;
            TrainStatus status = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("documentName"u8))
                {
                    documentName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("pages"u8))
                {
                    pages = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("errors"u8))
                {
                    List<ErrorInformation> array = new List<ErrorInformation>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ErrorInformation.DeserializeErrorInformation(item));
                    }
                    errors = array;
                    continue;
                }
                if (property.NameEquals("status"u8))
                {
                    status = property.Value.GetString().ToTrainStatus();
                    continue;
                }
            }
            return new TrainingDocumentInfo(documentName, pages, errors, status);
        }
    }
}
