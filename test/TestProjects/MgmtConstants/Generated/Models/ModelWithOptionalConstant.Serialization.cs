// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace MgmtConstants.Models
{
    public partial class ModelWithOptionalConstant : IUtf8JsonSerializable, IJsonModel<ModelWithOptionalConstant>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<ModelWithOptionalConstant>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<ModelWithOptionalConstant>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ModelWithOptionalConstant>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(ModelWithOptionalConstant)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(OptionalStringConstant))
            {
                writer.WritePropertyName("optionalStringConstant"u8);
                writer.WriteStringValue(OptionalStringConstant.Value.ToString());
            }
            if (Optional.IsDefined(OptionalIntConstant))
            {
                writer.WritePropertyName("optionalIntConstant"u8);
                writer.WriteNumberValue(OptionalIntConstant.Value.ToSerialInt32());
            }
            if (Optional.IsDefined(OptionalBooleanConstant))
            {
                writer.WritePropertyName("optionalBooleanConstant"u8);
                writer.WriteBooleanValue(OptionalBooleanConstant.Value);
            }
            if (Optional.IsDefined(OptionalFloatConstant))
            {
                writer.WritePropertyName("optionalFloatConstant"u8);
                writer.WriteNumberValue(OptionalFloatConstant.Value.ToSerialSingle());
            }
            if (_serializedAdditionalRawData != null && options.Format != "W")
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

        ModelWithOptionalConstant IJsonModel<ModelWithOptionalConstant>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ModelWithOptionalConstant>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(ModelWithOptionalConstant)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeModelWithOptionalConstant(document.RootElement, options);
        }

        internal static ModelWithOptionalConstant DeserializeModelWithOptionalConstant(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<StringConstant> optionalStringConstant = default;
            Optional<IntConstant> optionalIntConstant = default;
            Optional<bool> optionalBooleanConstant = default;
            Optional<FloatConstant> optionalFloatConstant = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("optionalStringConstant"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    optionalStringConstant = new StringConstant(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("optionalIntConstant"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    optionalIntConstant = new IntConstant(property.Value.GetInt32());
                    continue;
                }
                if (property.NameEquals("optionalBooleanConstant"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    optionalBooleanConstant = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("optionalFloatConstant"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    optionalFloatConstant = new FloatConstant(property.Value.GetSingle());
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new ModelWithOptionalConstant(Optional.ToNullable(optionalStringConstant), Optional.ToNullable(optionalIntConstant), Optional.ToNullable(optionalBooleanConstant), Optional.ToNullable(optionalFloatConstant), serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<ModelWithOptionalConstant>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ModelWithOptionalConstant>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new InvalidOperationException($"The model {nameof(ModelWithOptionalConstant)} does not support '{options.Format}' format.");
            }
        }

        ModelWithOptionalConstant IPersistableModel<ModelWithOptionalConstant>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ModelWithOptionalConstant>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeModelWithOptionalConstant(document.RootElement, options);
                    }
                default:
                    throw new InvalidOperationException($"The model {nameof(ModelWithOptionalConstant)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<ModelWithOptionalConstant>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
