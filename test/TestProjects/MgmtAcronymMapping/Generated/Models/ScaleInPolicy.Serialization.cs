// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace MgmtAcronymMapping.Models
{
    internal partial class ScaleInPolicy : IUtf8JsonSerializable, IModelJsonSerializable<ScaleInPolicy>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<ScaleInPolicy>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<ScaleInPolicy>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(Rules))
            {
                writer.WritePropertyName("rules"u8);
                writer.WriteStartArray();
                foreach (var item in Rules)
                {
                    writer.WriteStringValue(item.ToString());
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }

        ScaleInPolicy IModelJsonSerializable<ScaleInPolicy>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeScaleInPolicy(document.RootElement, options);
        }

        BinaryData IModelSerializable<ScaleInPolicy>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        ScaleInPolicy IModelSerializable<ScaleInPolicy>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeScaleInPolicy(document.RootElement, options);
        }

        internal static ScaleInPolicy DeserializeScaleInPolicy(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IList<VirtualMachineScaleSetScaleInRule>> rules = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("rules"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<VirtualMachineScaleSetScaleInRule> array = new List<VirtualMachineScaleSetScaleInRule>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(new VirtualMachineScaleSetScaleInRule(item.GetString()));
                    }
                    rules = array;
                    continue;
                }
            }
            return new ScaleInPolicy(Optional.ToList(rules));
        }
    }
}
