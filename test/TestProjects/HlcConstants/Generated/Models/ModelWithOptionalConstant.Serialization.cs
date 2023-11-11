// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Net.ClientModel;
using System.Net.ClientModel.Core;
using System.Text.Json;
using Azure.Core;

namespace HlcConstants.Models
{
    public partial class ModelWithOptionalConstant : IUtf8JsonSerializable, IJsonModel<ModelWithOptionalConstant>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<ModelWithOptionalConstant>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<ModelWithOptionalConstant>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if ((options.Format != ModelReaderWriterFormat.Wire || ((IModel<ModelWithOptionalConstant>)this).GetWireFormat(options) != ModelReaderWriterFormat.Json) && options.Format != ModelReaderWriterFormat.Json)
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<ModelWithOptionalConstant>)} interface");
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
            if (_serializedAdditionalRawData != null && options.Format == ModelReaderWriterFormat.Json)
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

        ModelWithOptionalConstant IJsonModel<ModelWithOptionalConstant>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(ModelWithOptionalConstant)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeModelWithOptionalConstant(document.RootElement, options);
        }

        internal static ModelWithOptionalConstant DeserializeModelWithOptionalConstant(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

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
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new ModelWithOptionalConstant(Optional.ToNullable(optionalStringConstant), Optional.ToNullable(optionalIntConstant), Optional.ToNullable(optionalBooleanConstant), Optional.ToNullable(optionalFloatConstant), serializedAdditionalRawData);
        }

        BinaryData IModel<ModelWithOptionalConstant>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(ModelWithOptionalConstant)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        ModelWithOptionalConstant IModel<ModelWithOptionalConstant>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(ModelWithOptionalConstant)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeModelWithOptionalConstant(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<ModelWithOptionalConstant>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;
    }
}
