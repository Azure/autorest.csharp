// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Expressions.DataFactory;

namespace Inheritance.Models
{
    public partial class ClassThatInheritsFromSomePropertiesAndBaseClass : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (BaseClassProperty != null)
            {
                writer.WritePropertyName("BaseClassProperty"u8);
                writer.WriteStringValue(BaseClassProperty);
            }
            if (DfeString != null)
            {
                writer.WritePropertyName("DfeString"u8);
                JsonSerializer.Serialize(writer, DfeString);
            }
            if (DfeDouble != null)
            {
                writer.WritePropertyName("DfeDouble"u8);
                JsonSerializer.Serialize(writer, DfeDouble);
            }
            if (DfeBool != null)
            {
                writer.WritePropertyName("DfeBool"u8);
                JsonSerializer.Serialize(writer, DfeBool);
            }
            if (DfeInt != null)
            {
                writer.WritePropertyName("DfeInt"u8);
                JsonSerializer.Serialize(writer, DfeInt);
            }
            if (DfeObject != null)
            {
                writer.WritePropertyName("DfeObject"u8);
                JsonSerializer.Serialize(writer, DfeObject);
            }
            if (DfeListOfT != null)
            {
                writer.WritePropertyName("DfeListOfT"u8);
                JsonSerializer.Serialize(writer, DfeListOfT);
            }
            if (DfeListOfString != null)
            {
                writer.WritePropertyName("DfeListOfString"u8);
                JsonSerializer.Serialize(writer, DfeListOfString);
            }
            if (DfeKeyValuePairs != null)
            {
                writer.WritePropertyName("DfeKeyValuePairs"u8);
                JsonSerializer.Serialize(writer, DfeKeyValuePairs);
            }
            if (DfeDateTime != null)
            {
                writer.WritePropertyName("DfeDateTime"u8);
                JsonSerializer.Serialize(writer, DfeDateTime);
            }
            if (DfeDuration != null)
            {
                writer.WritePropertyName("DfeDuration"u8);
                JsonSerializer.Serialize(writer, DfeDuration);
            }
            if (DfeUri != null)
            {
                writer.WritePropertyName("DfeUri"u8);
                JsonSerializer.Serialize(writer, DfeUri);
            }
            if (SomeProperty != null)
            {
                writer.WritePropertyName("SomeProperty"u8);
                writer.WriteStringValue(SomeProperty);
            }
            if (SomeOtherProperty != null)
            {
                writer.WritePropertyName("SomeOtherProperty"u8);
                writer.WriteStringValue(SomeOtherProperty);
            }
            writer.WriteEndObject();
        }

        internal static ClassThatInheritsFromSomePropertiesAndBaseClass DeserializeClassThatInheritsFromSomePropertiesAndBaseClass(JsonElement element)
        {
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
            }
            return new ClassThatInheritsFromSomePropertiesAndBaseClass(
                someProperty.Value,
                someOtherProperty.Value,
                baseClassProperty.Value,
                dfeString.Value,
                dfeDouble.Value,
                dfeBool.Value,
                dfeInt.Value,
                dfeObject.Value,
                dfeListOfT.Value,
                dfeListOfString.Value,
                dfeKeyValuePairs.Value,
                dfeDateTime.Value,
                dfeDuration.Value,
                dfeUri.Value);
        }
    }
}
