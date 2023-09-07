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

namespace Azure.Network.Management.Interface.Models
{
    public partial class Probe : IUtf8JsonSerializable, IModelJsonSerializable<Probe>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<Probe>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<Probe>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<Probe>(this, options.Format);

            writer.WriteStartObject();
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (Optional.IsDefined(Id))
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(Id);
            }
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (Optional.IsDefined(Protocol))
            {
                writer.WritePropertyName("protocol"u8);
                writer.WriteStringValue(Protocol.Value.ToString());
            }
            if (Optional.IsDefined(Port))
            {
                writer.WritePropertyName("port"u8);
                writer.WriteNumberValue(Port.Value);
            }
            if (Optional.IsDefined(IntervalInSeconds))
            {
                writer.WritePropertyName("intervalInSeconds"u8);
                writer.WriteNumberValue(IntervalInSeconds.Value);
            }
            if (Optional.IsDefined(NumberOfProbes))
            {
                writer.WritePropertyName("numberOfProbes"u8);
                writer.WriteNumberValue(NumberOfProbes.Value);
            }
            if (Optional.IsDefined(RequestPath))
            {
                writer.WritePropertyName("requestPath"u8);
                writer.WriteStringValue(RequestPath);
            }
            writer.WriteEndObject();
            if (_serializedAdditionalRawData is not null && options.Format == ModelSerializerFormat.Json)
            {
                foreach (var property in _serializedAdditionalRawData)
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

        internal static Probe DeserializeProbe(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> name = default;
            Optional<string> etag = default;
            Optional<string> type = default;
            Optional<string> id = default;
            Optional<IReadOnlyList<SubResource>> loadBalancingRules = default;
            Optional<ProbeProtocol> protocol = default;
            Optional<int> port = default;
            Optional<int> intervalInSeconds = default;
            Optional<int> numberOfProbes = default;
            Optional<string> requestPath = default;
            Optional<ProvisioningState> provisioningState = default;
            Dictionary<string, BinaryData> serializedAdditionalRawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("etag"u8))
                {
                    etag = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("properties"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("loadBalancingRules"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<SubResource> array = new List<SubResource>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(DeserializeSubResource(item));
                            }
                            loadBalancingRules = array;
                            continue;
                        }
                        if (property0.NameEquals("protocol"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            protocol = new ProbeProtocol(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("port"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            port = property0.Value.GetInt32();
                            continue;
                        }
                        if (property0.NameEquals("intervalInSeconds"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            intervalInSeconds = property0.Value.GetInt32();
                            continue;
                        }
                        if (property0.NameEquals("numberOfProbes"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            numberOfProbes = property0.Value.GetInt32();
                            continue;
                        }
                        if (property0.NameEquals("requestPath"u8))
                        {
                            requestPath = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("provisioningState"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            provisioningState = new ProvisioningState(property0.Value.GetString());
                            continue;
                        }
                    }
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    serializedAdditionalRawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new Probe(id.Value, name.Value, etag.Value, type.Value, Optional.ToList(loadBalancingRules), Optional.ToNullable(protocol), Optional.ToNullable(port), Optional.ToNullable(intervalInSeconds), Optional.ToNullable(numberOfProbes), requestPath.Value, Optional.ToNullable(provisioningState), serializedAdditionalRawData);
        }

        Probe IModelJsonSerializable<Probe>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<Probe>(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeProbe(doc.RootElement, options);
        }

        BinaryData IModelSerializable<Probe>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<Probe>(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        Probe IModelSerializable<Probe>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<Probe>(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeProbe(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="Probe"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="Probe"/> to convert. </param>
        public static implicit operator RequestContent(Probe model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="Probe"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator Probe(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeProbe(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
