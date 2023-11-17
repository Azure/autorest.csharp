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

namespace FlattenedParameters.Models
{
    internal partial class Paths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema : IUtf8JsonSerializable, IJsonModel<Paths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<Paths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<Paths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if ((options.Format != "W" || ((IPersistableModel<Paths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema>)this).GetFormatFromOptions(options) != "J") && options.Format != "J")
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
            if (_serializedAdditionalRawData != null && options.Format == "J")
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

        Paths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema IJsonModel<Paths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(Paths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializePaths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema(document.RootElement, options);
        }

        internal static Paths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema DeserializePaths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

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
                if (options.Format == "J")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new Paths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema(required.Value, nonRequired.Value, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<Paths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(Paths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        Paths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema IPersistableModel<Paths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(Paths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializePaths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema(document.RootElement, options);
        }

        string IPersistableModel<Paths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
