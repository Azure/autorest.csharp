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
    public partial class ClassThatInheritsFromBaseClassWithDiscriminatorAndSomeProperties : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(SomeProperty))
            {
                writer.WritePropertyName("SomeProperty");
                writer.WriteStringValue(SomeProperty);
            }
            if (Optional.IsDefined(SomeOtherProperty))
            {
                writer.WritePropertyName("SomeOtherProperty");
                writer.WriteStringValue(SomeOtherProperty);
            }
            writer.WritePropertyName("DiscriminatorProperty");
            writer.WriteStringValue(DiscriminatorProperty);
            if (Optional.IsDefined(BaseClassProperty))
            {
                writer.WritePropertyName("BaseClassProperty");
                writer.WriteStringValue(BaseClassProperty);
            }
            if (Optional.IsDefined(DfeString))
            {
                writer.WritePropertyName("DfeString");
                JsonSerializer.Serialize(writer, DfeString);
            }
            if (Optional.IsDefined(DfeDouble))
            {
                writer.WritePropertyName("DfeDouble");
                JsonSerializer.Serialize(writer, DfeDouble);
            }
            if (Optional.IsDefined(DfeBool))
            {
                writer.WritePropertyName("DfeBool");
                JsonSerializer.Serialize(writer, DfeBool);
            }
            if (Optional.IsDefined(DfeInt))
            {
                writer.WritePropertyName("DfeInt");
                JsonSerializer.Serialize(writer, DfeInt);
            }
            if (Optional.IsDefined(DfeObject))
            {
                writer.WritePropertyName("DfeObject");
                JsonSerializer.Serialize(writer, DfeObject);
            }
            if (Optional.IsDefined(DfeListOfObject))
            {
                writer.WritePropertyName("DfeListOfObject");
                JsonSerializer.Serialize(writer, DfeListOfObject);
            }
            if (Optional.IsDefined(DfeListOfT))
            {
                writer.WritePropertyName("DfeListOfT");
                JsonSerializer.Serialize(writer, DfeListOfT);
            }
            if (Optional.IsDefined(DfeListOfString))
            {
                writer.WritePropertyName("DfeListOfString");
                JsonSerializer.Serialize(writer, DfeListOfString);
            }
            if (Optional.IsDefined(DfeKeyValuePairs))
            {
                writer.WritePropertyName("DfeKeyValuePairs");
                JsonSerializer.Serialize(writer, DfeKeyValuePairs);
            }
            if (Optional.IsDefined(DfeDateTime))
            {
                writer.WritePropertyName("DfeDateTime");
                JsonSerializer.Serialize(writer, DfeDateTime);
            }
            if (Optional.IsDefined(DfeDuration))
            {
                writer.WritePropertyName("DfeDuration");
                JsonSerializer.Serialize(writer, DfeDuration);
            }
            if (Optional.IsDefined(DfeUri))
            {
                writer.WritePropertyName("DfeUri");
                JsonSerializer.Serialize(writer, DfeUri);
            }
            writer.WriteEndObject();
        }

        internal static ClassThatInheritsFromBaseClassWithDiscriminatorAndSomeProperties DeserializeClassThatInheritsFromBaseClassWithDiscriminatorAndSomeProperties(JsonElement element)
        {
            Optional<string> someProperty = default;
            Optional<string> someOtherProperty = default;
            string discriminatorProperty = default;
            Optional<string> baseClassProperty = default;
            Optional<DataFactoryExpression<string>> dfeString = default;
            Optional<DataFactoryExpression<double>> dfeDouble = default;
            Optional<DataFactoryExpression<bool>> dfeBool = default;
            Optional<DataFactoryExpression<int>> dfeInt = default;
            Optional<DataFactoryExpression<BinaryData>> dfeObject = default;
            Optional<DataFactoryExpression<IList<BinaryData>>> dfeListOfObject = default;
            Optional<DataFactoryExpression<IList<SeparateClass>>> dfeListOfT = default;
            Optional<DataFactoryExpression<IList<string>>> dfeListOfString = default;
            Optional<DataFactoryExpression<IDictionary<string, string>>> dfeKeyValuePairs = default;
            Optional<DataFactoryExpression<DateTimeOffset>> dfeDateTime = default;
            Optional<DataFactoryExpression<TimeSpan>> dfeDuration = default;
            Optional<DataFactoryExpression<Uri>> dfeUri = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("SomeProperty"))
                {
                    someProperty = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("SomeOtherProperty"))
                {
                    someOtherProperty = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("DiscriminatorProperty"))
                {
                    discriminatorProperty = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("BaseClassProperty"))
                {
                    baseClassProperty = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("DfeString"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    dfeString = JsonSerializer.Deserialize<DataFactoryExpression<string>>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("DfeDouble"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    dfeDouble = JsonSerializer.Deserialize<DataFactoryExpression<double>>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("DfeBool"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    dfeBool = JsonSerializer.Deserialize<DataFactoryExpression<bool>>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("DfeInt"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    dfeInt = JsonSerializer.Deserialize<DataFactoryExpression<int>>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("DfeObject"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    dfeObject = JsonSerializer.Deserialize<DataFactoryExpression<BinaryData>>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("DfeListOfObject"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    dfeListOfObject = JsonSerializer.Deserialize<DataFactoryExpression<IList<BinaryData>>>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("DfeListOfT"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    dfeListOfT = JsonSerializer.Deserialize<DataFactoryExpression<IList<SeparateClass>>>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("DfeListOfString"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    dfeListOfString = JsonSerializer.Deserialize<DataFactoryExpression<IList<string>>>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("DfeKeyValuePairs"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    dfeKeyValuePairs = JsonSerializer.Deserialize<DataFactoryExpression<IDictionary<string, string>>>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("DfeDateTime"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    dfeDateTime = JsonSerializer.Deserialize<DataFactoryExpression<DateTimeOffset>>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("DfeDuration"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    dfeDuration = JsonSerializer.Deserialize<DataFactoryExpression<TimeSpan>>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("DfeUri"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    dfeUri = JsonSerializer.Deserialize<DataFactoryExpression<Uri>>(property.Value.GetRawText());
                    continue;
                }
            }
            return new ClassThatInheritsFromBaseClassWithDiscriminatorAndSomeProperties(baseClassProperty.Value, dfeString.Value, dfeDouble.Value, dfeBool.Value, dfeInt.Value, dfeObject.Value, dfeListOfObject.Value, dfeListOfT.Value, dfeListOfString.Value, dfeKeyValuePairs.Value, dfeDateTime.Value, dfeDuration.Value, dfeUri.Value, discriminatorProperty, someProperty.Value, someOtherProperty.Value);
        }
    }
}
