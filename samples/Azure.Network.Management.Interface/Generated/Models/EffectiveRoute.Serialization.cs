// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.Network.Management.Interface.Models
{
    public partial class EffectiveRoute : IUtf8JsonSerializable, IModelJsonSerializable<EffectiveRoute>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<EffectiveRoute>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<EffectiveRoute>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (Optional.IsDefined(DisableBgpRoutePropagation))
            {
                writer.WritePropertyName("disableBgpRoutePropagation"u8);
                writer.WriteBooleanValue(DisableBgpRoutePropagation.Value);
            }
            if (Optional.IsDefined(Source))
            {
                writer.WritePropertyName("source"u8);
                writer.WriteStringValue(Source.Value.ToString());
            }
            if (Optional.IsDefined(State))
            {
                writer.WritePropertyName("state"u8);
                writer.WriteStringValue(State.Value.ToString());
            }
            if (Optional.IsCollectionDefined(AddressPrefix))
            {
                writer.WritePropertyName("addressPrefix"u8);
                writer.WriteStartArray();
                foreach (var item in AddressPrefix)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(NextHopIpAddress))
            {
                writer.WritePropertyName("nextHopIpAddress"u8);
                writer.WriteStartArray();
                foreach (var item in NextHopIpAddress)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(NextHopType))
            {
                writer.WritePropertyName("nextHopType"u8);
                writer.WriteStringValue(NextHopType.Value.ToString());
            }
            writer.WriteEndObject();
        }

        EffectiveRoute IModelJsonSerializable<EffectiveRoute>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument doc = JsonDocument.ParseValue(ref reader);
            return DeserializeEffectiveRoute(doc.RootElement, options);
        }

        BinaryData IModelSerializable<EffectiveRoute>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        EffectiveRoute IModelSerializable<EffectiveRoute>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeEffectiveRoute(document.RootElement, options);
        }

        internal static EffectiveRoute DeserializeEffectiveRoute(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> name = default;
            Optional<bool> disableBgpRoutePropagation = default;
            Optional<EffectiveRouteSource> source = default;
            Optional<EffectiveRouteState> state = default;
            Optional<IReadOnlyList<string>> addressPrefix = default;
            Optional<IReadOnlyList<string>> nextHopIpAddress = default;
            Optional<RouteNextHopType> nextHopType = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("disableBgpRoutePropagation"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    disableBgpRoutePropagation = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("source"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    source = new EffectiveRouteSource(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("state"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    state = new EffectiveRouteState(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("addressPrefix"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    addressPrefix = array;
                    continue;
                }
                if (property.NameEquals("nextHopIpAddress"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    nextHopIpAddress = array;
                    continue;
                }
                if (property.NameEquals("nextHopType"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    nextHopType = new RouteNextHopType(property.Value.GetString());
                    continue;
                }
            }
            return new EffectiveRoute(name.Value, Optional.ToNullable(disableBgpRoutePropagation), Optional.ToNullable(source), Optional.ToNullable(state), Optional.ToList(addressPrefix), Optional.ToList(nextHopIpAddress), Optional.ToNullable(nextHopType));
        }
    }
}
