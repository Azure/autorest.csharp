// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
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
            if (Optional.IsDefined(DfeArray))
            {
                writer.WritePropertyName("DfeArray");
                JsonSerializer.Serialize(writer, DfeArray);
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
            Optional<DataFactoryExpression<Array>> dfeArray = default;
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
                    dfeString = JsonSerializer.Deserialize<DataFactoryExpression<string>>(property.Value.ToString());
                    continue;
                }
                if (property.NameEquals("DfeDouble"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    dfeDouble = JsonSerializer.Deserialize<DataFactoryExpression<double>>(property.Value.ToString());
                    continue;
                }
                if (property.NameEquals("DfeBool"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    dfeBool = JsonSerializer.Deserialize<DataFactoryExpression<bool>>(property.Value.ToString());
                    continue;
                }
                if (property.NameEquals("DfeInt"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    dfeInt = JsonSerializer.Deserialize<DataFactoryExpression<int>>(property.Value.ToString());
                    continue;
                }
                if (property.NameEquals("DfeArray"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    dfeArray = JsonSerializer.Deserialize<DataFactoryExpression<Array>>(property.Value.ToString());
                    continue;
                }
            }
            return new ClassThatInheritsFromBaseClassWithDiscriminatorAndSomeProperties(baseClassProperty.Value, dfeString.Value, dfeDouble.Value, dfeBool.Value, dfeInt.Value, dfeArray.Value, discriminatorProperty, someProperty.Value, someOtherProperty.Value);
        }
    }
}
