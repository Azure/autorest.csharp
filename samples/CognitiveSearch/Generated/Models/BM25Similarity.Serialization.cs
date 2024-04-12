// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class BM25Similarity : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(K1))
            {
                writer.WritePropertyName("k1"u8);
                writer.WriteNumberValue(K1.Value);
            }
            if (Optional.IsDefined(B))
            {
                writer.WritePropertyName("b"u8);
                writer.WriteNumberValue(B.Value);
            }
            writer.WritePropertyName("@odata.type"u8);
            writer.WriteStringValue(OdataType);
            writer.WriteEndObject();
        }

        internal static BM25Similarity DeserializeBM25Similarity(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            double? k1 = default;
            double? b = default;
            string odataType = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("k1"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    k1 = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("b"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    b = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("@odata.type"u8))
                {
                    odataType = property.Value.GetString();
                    continue;
                }
            }
            return new BM25Similarity(odataType, k1, b);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static new BM25Similarity FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeBM25Similarity(document.RootElement);
        }

        /// <summary> Convert into a <see cref="RequestContent"/>. </summary>
        internal override RequestContent ToRequestContent()
        {
            BinaryData binaryData = ModelReaderWriter.Write(this, new ModelReaderWriterOptions("W"));
            return RequestContent.Create(binaryData);
        }
    }
}
