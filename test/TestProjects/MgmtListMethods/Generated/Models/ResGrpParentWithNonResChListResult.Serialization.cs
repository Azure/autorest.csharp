// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;
using MgmtListMethods;

namespace MgmtListMethods.Models
{
    internal partial class ResGrpParentWithNonResChListResult : IUtf8JsonSerializable, IModelJsonSerializable<ResGrpParentWithNonResChListResult>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<ResGrpParentWithNonResChListResult>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<ResGrpParentWithNonResChListResult>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("value"u8);
            writer.WriteStartArray();
            foreach (var item in Value)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            if (Optional.IsDefined(NextLink))
            {
                writer.WritePropertyName("nextLink"u8);
                writer.WriteStringValue(NextLink);
            }
            writer.WriteEndObject();
        }

        ResGrpParentWithNonResChListResult IModelJsonSerializable<ResGrpParentWithNonResChListResult>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeResGrpParentWithNonResChListResult(document.RootElement, options);
        }

        BinaryData IModelSerializable<ResGrpParentWithNonResChListResult>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        ResGrpParentWithNonResChListResult IModelSerializable<ResGrpParentWithNonResChListResult>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeResGrpParentWithNonResChListResult(document.RootElement, options);
        }

        internal static ResGrpParentWithNonResChListResult DeserializeResGrpParentWithNonResChListResult(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<ResGrpParentWithNonResChData> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    List<ResGrpParentWithNonResChData> array = new List<ResGrpParentWithNonResChData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ResGrpParentWithNonResChData.DeserializeResGrpParentWithNonResChData(item));
                    }
                    value = array;
                    continue;
                }
                if (property.NameEquals("nextLink"u8))
                {
                    nextLink = property.Value.GetString();
                    continue;
                }
            }
            return new ResGrpParentWithNonResChListResult(value, nextLink.Value);
        }
    }
}
