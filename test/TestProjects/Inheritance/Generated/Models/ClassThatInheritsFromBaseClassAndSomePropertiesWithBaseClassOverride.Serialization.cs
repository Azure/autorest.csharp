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
using Azure.Core.Expressions.DataFactory;

namespace Inheritance.Models
{
    internal partial class ClassThatInheritsFromBaseClassAndSomePropertiesWithBaseClassOverride : IUtf8JsonSerializable, IJsonModel<ClassThatInheritsFromBaseClassAndSomePropertiesWithBaseClassOverride>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<ClassThatInheritsFromBaseClassAndSomePropertiesWithBaseClassOverride>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<ClassThatInheritsFromBaseClassAndSomePropertiesWithBaseClassOverride>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (options.Format == ModelReaderWriterFormat.Wire && ((IModel<ClassThatInheritsFromBaseClassAndSomePropertiesWithBaseClassOverride>)this).GetWireFormat(options) != ModelReaderWriterFormat.Json || options.Format != ModelReaderWriterFormat.Json)
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<ClassThatInheritsFromBaseClassAndSomePropertiesWithBaseClassOverride>)} interface");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(BaseClassProperty))
            {
                writer.WritePropertyName("BaseClassProperty"u8);
                writer.WriteStringValue(BaseClassProperty);
            }
            if (Optional.IsDefined(DfeString))
            {
                writer.WritePropertyName("DfeString"u8);
                JsonSerializer.Serialize(writer, DfeString);
            }
            if (Optional.IsDefined(DfeDouble))
            {
                writer.WritePropertyName("DfeDouble"u8);
                JsonSerializer.Serialize(writer, DfeDouble);
            }
            if (Optional.IsDefined(DfeBool))
            {
                writer.WritePropertyName("DfeBool"u8);
                JsonSerializer.Serialize(writer, DfeBool);
            }
            if (Optional.IsDefined(DfeInt))
            {
                writer.WritePropertyName("DfeInt"u8);
                JsonSerializer.Serialize(writer, DfeInt);
            }
            if (Optional.IsDefined(DfeObject))
            {
                writer.WritePropertyName("DfeObject"u8);
                JsonSerializer.Serialize(writer, DfeObject);
            }
            if (Optional.IsDefined(DfeListOfT))
            {
                writer.WritePropertyName("DfeListOfT"u8);
                JsonSerializer.Serialize(writer, DfeListOfT);
            }
            if (Optional.IsDefined(DfeListOfString))
            {
                writer.WritePropertyName("DfeListOfString"u8);
                JsonSerializer.Serialize(writer, DfeListOfString);
            }
            if (Optional.IsDefined(DfeKeyValuePairs))
            {
                writer.WritePropertyName("DfeKeyValuePairs"u8);
                JsonSerializer.Serialize(writer, DfeKeyValuePairs);
            }
            if (Optional.IsDefined(DfeDateTime))
            {
                writer.WritePropertyName("DfeDateTime"u8);
                JsonSerializer.Serialize(writer, DfeDateTime);
            }
            if (Optional.IsDefined(DfeDuration))
            {
                writer.WritePropertyName("DfeDuration"u8);
                JsonSerializer.Serialize(writer, DfeDuration);
            }
            if (Optional.IsDefined(DfeUri))
            {
                writer.WritePropertyName("DfeUri"u8);
                JsonSerializer.Serialize(writer, DfeUri);
            }
            if (Optional.IsDefined(SomeProperty))
            {
                writer.WritePropertyName("SomeProperty"u8);
                writer.WriteStringValue(SomeProperty);
            }
            if (Optional.IsDefined(SomeOtherProperty))
            {
                writer.WritePropertyName("SomeOtherProperty"u8);
                writer.WriteStringValue(SomeOtherProperty);
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

        ClassThatInheritsFromBaseClassAndSomePropertiesWithBaseClassOverride IJsonModel<ClassThatInheritsFromBaseClassAndSomePropertiesWithBaseClassOverride>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(ClassThatInheritsFromBaseClassAndSomePropertiesWithBaseClassOverride)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeClassThatInheritsFromBaseClassAndSomePropertiesWithBaseClassOverride(document.RootElement, options);
        }

        internal static ClassThatInheritsFromBaseClassAndSomePropertiesWithBaseClassOverride DeserializeClassThatInheritsFromBaseClassAndSomePropertiesWithBaseClassOverride(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> baseClassProperty = default;
            Optional<DataFactoryElement<string>> dfeString = default;
            Optional<DataFactoryElement<double>> dfeDouble = default;
            Optional<DataFactoryElement<bool>> dfeBool = default;
            Optional<DataFactoryElement<int>> dfeInt = default;
            Optional<DataFactoryElement<BinaryData>> dfeObject = default;
            Optional<DataFactoryElement<IList<SeparateClass>>> dfeListOfT = default;
            Optional<DataFactoryElement<IList<string>>> dfeListOfString = default;
            Optional<DataFactoryElement<IDictionary<string, string>>> dfeKeyValuePairs = default;
            Optional<DataFactoryElement<DateTimeOffset>> dfeDateTime = default;
            Optional<DataFactoryElement<TimeSpan>> dfeDuration = default;
            Optional<DataFactoryElement<Uri>> dfeUri = default;
            Optional<string> someProperty = default;
            Optional<string> someOtherProperty = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("BaseClassProperty"u8))
                {
                    baseClassProperty = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("DfeString"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    dfeString = JsonSerializer.Deserialize<DataFactoryElement<string>>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("DfeDouble"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    dfeDouble = JsonSerializer.Deserialize<DataFactoryElement<double>>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("DfeBool"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    dfeBool = JsonSerializer.Deserialize<DataFactoryElement<bool>>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("DfeInt"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    dfeInt = JsonSerializer.Deserialize<DataFactoryElement<int>>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("DfeObject"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    dfeObject = JsonSerializer.Deserialize<DataFactoryElement<BinaryData>>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("DfeListOfT"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    dfeListOfT = JsonSerializer.Deserialize<DataFactoryElement<IList<SeparateClass>>>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("DfeListOfString"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    dfeListOfString = JsonSerializer.Deserialize<DataFactoryElement<IList<string>>>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("DfeKeyValuePairs"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    dfeKeyValuePairs = JsonSerializer.Deserialize<DataFactoryElement<IDictionary<string, string>>>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("DfeDateTime"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    dfeDateTime = JsonSerializer.Deserialize<DataFactoryElement<DateTimeOffset>>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("DfeDuration"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    dfeDuration = JsonSerializer.Deserialize<DataFactoryElement<TimeSpan>>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("DfeUri"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    dfeUri = JsonSerializer.Deserialize<DataFactoryElement<Uri>>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("SomeProperty"u8))
                {
                    someProperty = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("SomeOtherProperty"u8))
                {
                    someOtherProperty = property.Value.GetString();
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new ClassThatInheritsFromBaseClassAndSomePropertiesWithBaseClassOverride(someProperty.Value, someOtherProperty.Value, serializedAdditionalRawData, baseClassProperty.Value, dfeString.Value, dfeDouble.Value, dfeBool.Value, dfeInt.Value, dfeObject.Value, dfeListOfT.Value, dfeListOfString.Value, dfeKeyValuePairs.Value, dfeDateTime.Value, dfeDuration.Value, dfeUri.Value);
        }

        BinaryData IModel<ClassThatInheritsFromBaseClassAndSomePropertiesWithBaseClassOverride>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(ClassThatInheritsFromBaseClassAndSomePropertiesWithBaseClassOverride)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        ClassThatInheritsFromBaseClassAndSomePropertiesWithBaseClassOverride IModel<ClassThatInheritsFromBaseClassAndSomePropertiesWithBaseClassOverride>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(ClassThatInheritsFromBaseClassAndSomePropertiesWithBaseClassOverride)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeClassThatInheritsFromBaseClassAndSomePropertiesWithBaseClassOverride(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<ClassThatInheritsFromBaseClassAndSomePropertiesWithBaseClassOverride>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;
    }
}
