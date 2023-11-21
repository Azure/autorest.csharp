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

namespace MgmtDiscriminator.Models
{
    public partial class RequestMethodMatchConditionParameters : IUtf8JsonSerializable, IJsonModel<RequestMethodMatchConditionParameters>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<RequestMethodMatchConditionParameters>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<RequestMethodMatchConditionParameters>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RequestMethodMatchConditionParameters>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(RequestMethodMatchConditionParameters)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("typeName"u8);
            writer.WriteStringValue(TypeName.ToString());
            writer.WritePropertyName("operator"u8);
            writer.WriteStringValue(Operator.ToString());
            if (Optional.IsDefined(NegateCondition))
            {
                writer.WritePropertyName("negateCondition"u8);
                writer.WriteBooleanValue(NegateCondition.Value);
            }
            if (Optional.IsCollectionDefined(Transforms))
            {
                writer.WritePropertyName("transforms"u8);
                writer.WriteStartArray();
                foreach (var item in Transforms)
                {
                    writer.WriteStringValue(item.ToString());
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(MatchValues))
            {
                writer.WritePropertyName("matchValues"u8);
                writer.WriteStartArray();
                foreach (var item in MatchValues)
                {
                    writer.WriteStringValue(item.ToString());
                }
                writer.WriteEndArray();
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

        RequestMethodMatchConditionParameters IJsonModel<RequestMethodMatchConditionParameters>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RequestMethodMatchConditionParameters>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(RequestMethodMatchConditionParameters)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeRequestMethodMatchConditionParameters(document.RootElement, options);
        }

        internal static RequestMethodMatchConditionParameters DeserializeRequestMethodMatchConditionParameters(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            RequestMethodMatchConditionParametersTypeName typeName = default;
            RequestMethodOperator @operator = default;
            Optional<bool> negateCondition = default;
            Optional<IList<Transform>> transforms = default;
            Optional<IList<RequestMethodMatchConditionParametersMatchValuesItem>> matchValues = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("typeName"u8))
                {
                    typeName = new RequestMethodMatchConditionParametersTypeName(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("operator"u8))
                {
                    @operator = new RequestMethodOperator(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("negateCondition"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    negateCondition = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("transforms"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<Transform> array = new List<Transform>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(new Transform(item.GetString()));
                    }
                    transforms = array;
                    continue;
                }
                if (property.NameEquals("matchValues"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<RequestMethodMatchConditionParametersMatchValuesItem> array = new List<RequestMethodMatchConditionParametersMatchValuesItem>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(new RequestMethodMatchConditionParametersMatchValuesItem(item.GetString()));
                    }
                    matchValues = array;
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new RequestMethodMatchConditionParameters(typeName, @operator, Optional.ToNullable(negateCondition), Optional.ToList(transforms), Optional.ToList(matchValues), serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<RequestMethodMatchConditionParameters>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RequestMethodMatchConditionParameters>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new InvalidOperationException($"The model {nameof(RequestMethodMatchConditionParameters)} does not support '{options.Format}' format.");
            }
        }

        RequestMethodMatchConditionParameters IPersistableModel<RequestMethodMatchConditionParameters>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RequestMethodMatchConditionParameters>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeRequestMethodMatchConditionParameters(document.RootElement, options);
                    }
                default:
                    throw new InvalidOperationException($"The model {nameof(RequestMethodMatchConditionParameters)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<RequestMethodMatchConditionParameters>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
