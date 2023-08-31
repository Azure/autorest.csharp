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
using Azure.ResourceManager.Models;

namespace MgmtMultipleParentResource
{
    public partial class TheParentData : IUtf8JsonSerializable, IModelJsonSerializable<TheParentData>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<TheParentData>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<TheParentData>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(Tags))
            {
                writer.WritePropertyName("tags"u8);
                writer.WriteStartObject();
                foreach (var item in Tags)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteStringValue(item.Value);
                }
                writer.WriteEndObject();
            }
            writer.WritePropertyName("location"u8);
            writer.WriteStringValue(Location);
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (Optional.IsDefined(AsyncExecution))
            {
                writer.WritePropertyName("asyncExecution"u8);
                writer.WriteBooleanValue(AsyncExecution.Value);
            }
            if (Optional.IsDefined(RunAsUser))
            {
                writer.WritePropertyName("runAsUser"u8);
                writer.WriteStringValue(RunAsUser);
            }
            if (Optional.IsDefined(RunAsPassword))
            {
                writer.WritePropertyName("runAsPassword"u8);
                writer.WriteStringValue(RunAsPassword);
            }
            if (Optional.IsDefined(TimeoutInSeconds))
            {
                writer.WritePropertyName("timeoutInSeconds"u8);
                writer.WriteNumberValue(TimeoutInSeconds.Value);
            }
            if (Optional.IsDefined(OutputBlobUri))
            {
                writer.WritePropertyName("outputBlobUri"u8);
                writer.WriteStringValue(OutputBlobUri.AbsoluteUri);
            }
            if (Optional.IsDefined(ErrorBlobUri))
            {
                writer.WritePropertyName("errorBlobUri"u8);
                writer.WriteStringValue(ErrorBlobUri.AbsoluteUri);
            }
            writer.WriteEndObject();
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

        internal static TheParentData DeserializeTheParentData(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IDictionary<string, string>> tags = default;
            AzureLocation location = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Optional<SystemData> systemData = default;
            Optional<bool> asyncExecution = default;
            Optional<string> runAsUser = default;
            Optional<string> runAsPassword = default;
            Optional<int> timeoutInSeconds = default;
            Optional<Uri> outputBlobUri = default;
            Optional<Uri> errorBlobUri = default;
            Optional<string> provisioningState = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("tags"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetString());
                    }
                    tags = dictionary;
                    continue;
                }
                if (property.NameEquals("location"u8))
                {
                    location = new AzureLocation(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("id"u8))
                {
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = new ResourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("systemData"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    systemData = JsonSerializer.Deserialize<SystemData>(property.Value.GetRawText());
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
                        if (property0.NameEquals("asyncExecution"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            asyncExecution = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("runAsUser"u8))
                        {
                            runAsUser = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("runAsPassword"u8))
                        {
                            runAsPassword = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("timeoutInSeconds"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            timeoutInSeconds = property0.Value.GetInt32();
                            continue;
                        }
                        if (property0.NameEquals("outputBlobUri"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            outputBlobUri = new Uri(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("errorBlobUri"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            errorBlobUri = new Uri(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("provisioningState"u8))
                        {
                            provisioningState = property0.Value.GetString();
                            continue;
                        }
                    }
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new TheParentData(id, name, type, systemData.Value, Optional.ToDictionary(tags), location, Optional.ToNullable(asyncExecution), runAsUser.Value, runAsPassword.Value, Optional.ToNullable(timeoutInSeconds), outputBlobUri.Value, errorBlobUri.Value, provisioningState.Value, rawData);
        }

        TheParentData IModelJsonSerializable<TheParentData>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeTheParentData(doc.RootElement, options);
        }

        BinaryData IModelSerializable<TheParentData>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        TheParentData IModelSerializable<TheParentData>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeTheParentData(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="TheParentData"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="TheParentData"/> to convert. </param>
        public static implicit operator RequestContent(TheParentData model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="TheParentData"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator TheParentData(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeTheParentData(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
