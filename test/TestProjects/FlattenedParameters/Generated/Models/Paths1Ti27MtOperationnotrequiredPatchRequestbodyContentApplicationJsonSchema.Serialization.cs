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

namespace FlattenedParameters.Models
{
    internal partial class Paths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema : IUtf8JsonSerializable, IJsonModel<Paths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<Paths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<Paths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (options.Format == ModelReaderWriterFormat.Wire && ((IModel<Paths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema>)this).GetWireFormat(options) != ModelReaderWriterFormat.Json && options.Format != ModelReaderWriterFormat.Json)
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<Paths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema>)} interface");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("flattened"u8);
            writer.WriteStartObject();
            if (Optional.IsDefined(Required))
            {
                writer.WritePropertyName("required"u8);
                writer.WriteStringValue(Required);
            }
            if (Optional.IsDefined(NonRequired))
            {
                writer.WritePropertyName("non_required"u8);
                writer.WriteStringValue(NonRequired);
            }
            writer.WriteEndObject();
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

        Paths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema IJsonModel<Paths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(Paths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializePaths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema(document.RootElement, options);
        }

        internal static Paths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema DeserializePaths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> required = default;
            Optional<string> nonRequired = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("flattened"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("required"u8))
                        {
                            required = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("non_required"u8))
                        {
                            nonRequired = property0.Value.GetString();
                            continue;
                        }
                    }
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new Paths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema(required.Value, nonRequired.Value, serializedAdditionalRawData);
        }

        BinaryData IModel<Paths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(Paths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        Paths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema IModel<Paths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(Paths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializePaths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<Paths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;
    }
}
