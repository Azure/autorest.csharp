// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace AnomalyDetector.Models
{
    public partial class ModelState : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(EpochIds))
            {
                writer.WritePropertyName("epochIds"u8);
                writer.WriteStartArray();
                foreach (var item in EpochIds)
                {
                    writer.WriteNumberValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(TrainLosses))
            {
                writer.WritePropertyName("trainLosses"u8);
                writer.WriteStartArray();
                foreach (var item in TrainLosses)
                {
                    writer.WriteNumberValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(ValidationLosses))
            {
                writer.WritePropertyName("validationLosses"u8);
                writer.WriteStartArray();
                foreach (var item in ValidationLosses)
                {
                    writer.WriteNumberValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(LatenciesInSeconds))
            {
                writer.WritePropertyName("latenciesInSeconds"u8);
                writer.WriteStartArray();
                foreach (var item in LatenciesInSeconds)
                {
                    writer.WriteNumberValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }

        internal static ModelState DeserializeModelState(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IList<int>> epochIds = default;
            Optional<IList<float>> trainLosses = default;
            Optional<IList<float>> validationLosses = default;
            Optional<IList<float>> latenciesInSeconds = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("epochIds"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<int> array = new List<int>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetInt32());
                    }
                    epochIds = array;
                    continue;
                }
                if (property.NameEquals("trainLosses"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<float> array = new List<float>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetSingle());
                    }
                    trainLosses = array;
                    continue;
                }
                if (property.NameEquals("validationLosses"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<float> array = new List<float>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetSingle());
                    }
                    validationLosses = array;
                    continue;
                }
                if (property.NameEquals("latenciesInSeconds"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<float> array = new List<float>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetSingle());
                    }
                    latenciesInSeconds = array;
                    continue;
                }
            }
            return new ModelState(Optional.ToList(epochIds), Optional.ToList(trainLosses), Optional.ToList(validationLosses), Optional.ToList(latenciesInSeconds));
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static ModelState FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeModelState(document.RootElement);
        }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }
    }
}
