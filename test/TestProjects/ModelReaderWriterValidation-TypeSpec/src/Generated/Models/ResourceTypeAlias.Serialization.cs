// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace ModelReaderWriterValidationTypeSpec.Models
{
    public partial class ResourceTypeAlias : IUtf8JsonSerializable, IJsonModel<ResourceTypeAlias>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<ResourceTypeAlias>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<ResourceTypeAlias>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ResourceTypeAlias>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ResourceTypeAlias)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (Optional.IsCollectionDefined(Paths))
            {
                writer.WritePropertyName("paths"u8);
                writer.WriteStartArray();
                foreach (var item in Paths)
                {
                    if (item != null)
                    {
                        ((IJsonModel<ResourceTypeAliasPath>)item).Write(writer, options);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(AliasType))
            {
                writer.WritePropertyName("aliasType"u8);
                writer.WriteStringValue(AliasType.Value.ToSerialString());
            }
            if (Optional.IsDefined(DefaultPath))
            {
                writer.WritePropertyName("defaultPath"u8);
                writer.WriteStringValue(DefaultPath);
            }
            if (Optional.IsDefined(DefaultPattern))
            {
                writer.WritePropertyName("defaultPattern"u8);
                if (DefaultPattern != null)
                {
                    ((IJsonModel<ResourceTypeAliasPattern>)DefaultPattern).Write(writer, options);
                }
                else
                {
                    writer.WriteNullValue();
                }
            }
            if (Optional.IsDefined(DefaultMetadata))
            {
                writer.WritePropertyName("defaultMetadata"u8);
                if (DefaultMetadata != null)
                {
                    ((IJsonModel<ResourceTypeAliasPathMetadata>)DefaultMetadata).Write(writer, options);
                }
                else
                {
                    writer.WriteNullValue();
                }
            }
            if (options.Format != "W" && _serializedAdditionalRawData != null)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
            writer.WriteEndObject();
        }

        ResourceTypeAlias IJsonModel<ResourceTypeAlias>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ResourceTypeAlias>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ResourceTypeAlias)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeResourceTypeAlias(document.RootElement, options);
        }

        internal static ResourceTypeAlias DeserializeResourceTypeAlias(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> name = default;
            Optional<IReadOnlyList<ResourceTypeAliasPath>> paths = default;
            Optional<ResourceTypeAliasType> aliasType = default;
            Optional<string> defaultPath = default;
            Optional<ResourceTypeAliasPattern> defaultPattern = default;
            Optional<ResourceTypeAliasPathMetadata> defaultMetadata = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("paths"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<ResourceTypeAliasPath> array = new List<ResourceTypeAliasPath>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ResourceTypeAliasPath.DeserializeResourceTypeAliasPath(item));
                    }
                    paths = array;
                    continue;
                }
                if (property.NameEquals("aliasType"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    aliasType = property.Value.GetString().ToResourceTypeAliasType();
                    continue;
                }
                if (property.NameEquals("defaultPath"u8))
                {
                    defaultPath = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("defaultPattern"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    defaultPattern = ResourceTypeAliasPattern.DeserializeResourceTypeAliasPattern(property.Value);
                    continue;
                }
                if (property.NameEquals("defaultMetadata"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    defaultMetadata = ResourceTypeAliasPathMetadata.DeserializeResourceTypeAliasPathMetadata(property.Value);
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new ResourceTypeAlias(name.Value, Optional.ToList(paths), Optional.ToNullable(aliasType), defaultPath.Value, defaultPattern.Value, defaultMetadata.Value, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<ResourceTypeAlias>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ResourceTypeAlias>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ResourceTypeAlias)} does not support '{options.Format}' format.");
            }
        }

        ResourceTypeAlias IPersistableModel<ResourceTypeAlias>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ResourceTypeAlias>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeResourceTypeAlias(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ResourceTypeAlias)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<ResourceTypeAlias>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static ResourceTypeAlias FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeResourceTypeAlias(document.RootElement);
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
