// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.Core.Serialization;
using MgmtListMethods;

namespace MgmtListMethods.Models
{
    internal partial class ResGrpParentWithAncestorWithNonResChListResult : IUtf8JsonSerializable, IModelJsonSerializable<ResGrpParentWithAncestorWithNonResChListResult>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<ResGrpParentWithAncestorWithNonResChListResult>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<ResGrpParentWithAncestorWithNonResChListResult>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            writer.WritePropertyName("value"u8);
            writer.WriteStartArray();
            foreach (var item in Value)
            {
                if (item is null)
                {
                    writer.WriteNullValue();
                }
                else
                {
                    ((IModelJsonSerializable<ResGrpParentWithAncestorWithNonResChData>)item).Serialize(writer, options);
                }
            }
            writer.WriteEndArray();
            if (Optional.IsDefined(NextLink))
            {
                writer.WritePropertyName("nextLink"u8);
                writer.WriteStringValue(NextLink);
            }
            if (_rawData is not null && options.Format == ModelSerializerFormat.Json)
            {
                foreach (var property in _rawData)
                {
                    writer.WritePropertyName(property.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(property.Value);
#else
                    JsonSerializer.Serialize(writer, JsonDocument.Parse(property.Value.ToString()).RootElement);
#endif
                }
            }
            writer.WriteEndObject();
        }

        internal static ResGrpParentWithAncestorWithNonResChListResult DeserializeResGrpParentWithAncestorWithNonResChListResult(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<ResGrpParentWithAncestorWithNonResChData> value = default;
            Optional<string> nextLink = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    List<ResGrpParentWithAncestorWithNonResChData> array = new List<ResGrpParentWithAncestorWithNonResChData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ResGrpParentWithAncestorWithNonResChData.DeserializeResGrpParentWithAncestorWithNonResChData(item));
                    }
                    value = array;
                    continue;
                }
                if (property.NameEquals("nextLink"u8))
                {
                    nextLink = property.Value.GetString();
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new ResGrpParentWithAncestorWithNonResChListResult(value, nextLink.Value, rawData);
        }

        ResGrpParentWithAncestorWithNonResChListResult IModelJsonSerializable<ResGrpParentWithAncestorWithNonResChListResult>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeResGrpParentWithAncestorWithNonResChListResult(doc.RootElement, options);
        }

        BinaryData IModelSerializable<ResGrpParentWithAncestorWithNonResChListResult>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        ResGrpParentWithAncestorWithNonResChListResult IModelSerializable<ResGrpParentWithAncestorWithNonResChListResult>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeResGrpParentWithAncestorWithNonResChListResult(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="ResGrpParentWithAncestorWithNonResChListResult"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="ResGrpParentWithAncestorWithNonResChListResult"/> to convert. </param>
        public static implicit operator RequestContent(ResGrpParentWithAncestorWithNonResChListResult model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="ResGrpParentWithAncestorWithNonResChListResult"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator ResGrpParentWithAncestorWithNonResChListResult(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeResGrpParentWithAncestorWithNonResChListResult(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
