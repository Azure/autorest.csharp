// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using AutoRest.CSharp.V3.Generation.Types;
using AutoRest.CSharp.V3.Output.Models.Serialization;
using AutoRest.CSharp.V3.Output.Models.Serialization.Json;
using AutoRest.CSharp.V3.Output.Models.Types;
namespace AutoRest.CSharp.V3.Generation.Writers
{
    internal static class JsonCodeWriterExtensions
    {
        public static void ToSerializeCall(this CodeWriter writer, JsonSerialization serialization, CodeWriterDelegate name, CodeWriterDelegate? writerName = null)
        {
            writerName ??= w => w.AppendRaw("writer");

            switch (serialization)
            {
                case JsonArraySerialization array:
                    writer.Line($"{writerName}.WriteStartArray();");
                    string collectionItemVariable = writer.GetTemporaryVariable("item");
                    writer.Line($"foreach (var {collectionItemVariable:D} in {name})");
                    using (writer.Scope())
                    {
                        writer.ToSerializeCall(
                            array.ValueSerialization,
                            w => w.AppendRaw(collectionItemVariable),
                            writerName);
                    }

                    writer.Line($"{writerName}.WriteEndArray();");
                    return;

                case JsonObjectSerialization dictionary:
                    writer.Line($"{writerName}.WriteStartObject();");
                    string itemVariable = writer.GetTemporaryVariable("item");

                    foreach (JsonPropertySerialization property in dictionary.Properties)
                    {
                        CSharpType? serializationType = property.ValueSerialization.Type;
                        bool hasNullableType = serializationType != null && serializationType.IsNullable;
                        using (hasNullableType ? writer.If($"{property.MemberName} != null") : default)
                        {
                            writer.Line($"{writerName}.WritePropertyName({property.Name:L});");
                            writer.ToSerializeCall(
                                property.ValueSerialization,
                                w => w.Append($"{property.MemberName}"));
                        }
                    }

                    if (dictionary.AdditionalProperties != null)
                    {
                        writer.Line($"foreach (var {itemVariable:D} in {name})");
                        using (writer.Scope())
                        {
                            writer.Line($"{writerName}.WritePropertyName({itemVariable}.Key);");
                            writer.ToSerializeCall(
                                dictionary.AdditionalProperties.ValueSerialization,
                                w => w.Append($"{itemVariable}.Value"),
                                writerName);
                        }
                    }

                    writer.Line($"{writerName}.WriteEndObject();");
                    return;

                case JsonValueSerialization valueSerialization:
                    if (valueSerialization.Type.IsFrameworkType)
                    {
                        var frameworkType = valueSerialization.Type.FrameworkType;
                        bool writeFormat = false;

                        writer.Append($"{writerName}.");
                        if (frameworkType == typeof(decimal) ||
                            frameworkType == typeof(double) ||
                            frameworkType == typeof(float) ||
                            frameworkType == typeof(long) ||
                            frameworkType == typeof(int) ||
                            frameworkType == typeof(short))
                        {
                            writer.AppendRaw("WriteNumberValue");
                        }
                        else if (frameworkType == typeof(object))
                        {
                            writer.AppendRaw("WriteObjectValue");
                        }
                        else if (frameworkType == typeof(string) ||
                                 frameworkType == typeof(char) ||
                                 frameworkType == typeof(Guid))
                        {
                            writer.AppendRaw("WriteStringValue");
                        }
                        else if (frameworkType == typeof(bool))
                        {
                            writer.AppendRaw("WriteBooleanValue");
                        }
                        else if (frameworkType == typeof(byte[]))
                        {
                            writer.AppendRaw("WriteBase64StringValue");
                            writeFormat = true;
                        }
                        else if (frameworkType == typeof(DateTimeOffset) ||
                                 frameworkType == typeof(DateTime) ||
                                 frameworkType == typeof(TimeSpan))
                        {
                            writer.AppendRaw("WriteStringValue");
                            writeFormat = true;
                        }

                        writer.Append($"({name}")
                            .AppendNullableValue(valueSerialization.Type);

                        if (writeFormat && valueSerialization.Format.ToFormatSpecifier() is string formatString)
                        {
                            writer.Append($", {formatString:L}");
                        }

                        writer.LineRaw(");");
                        return;
                    }

                    switch (valueSerialization.Type.Implementation)
                    {
                        case ObjectType _:
                            writer.Line($"{writerName}.WriteObjectValue({name});");
                            return;

                        case EnumType clientEnum:
                            writer.Append($"{writerName}.WriteStringValue({name}")
                                .AppendNullableValue(valueSerialization.Type)
                                .AppendRaw(clientEnum.IsStringBased ? ".ToString()" : ".ToSerialString()")
                                .Line($");");
                            return;
                    }

                    throw new NotSupportedException();

                default:
                    throw new NotSupportedException();
            }
        }

        public static void ToDeserializeCall(this CodeWriter writer, JsonSerialization serialization, CodeWriterDelegate element, ref string destination)
        {
            destination = writer.GetTemporaryVariable(destination);

            if (serialization is JsonValueSerialization valueSerialization)
            {
                writer.Append($"var {destination:D} =")
                    .ToDeserializeCall(valueSerialization, element);
                writer.LineRaw(";");
            }
            else
            {
                string s = destination;

                var type = serialization.Type;
                TryGetInitializerType(serialization, out CSharpType? implementationType);

                Debug.Assert(type != null);
                Debug.Assert(implementationType != null);

                writer
                    .Line($"{type} {destination:D} = new {implementationType}();")
                    .ToDeserializeCall(serialization, w => w.AppendRaw(s), element);
            }
        }

        private static void ToDeserializeCall(this CodeWriter writer, JsonSerialization serialization, CodeWriterDelegate destination, CodeWriterDelegate element)
        {
            switch (serialization)
            {
                case JsonArraySerialization array:
                    string collectionItemVariable = writer.GetTemporaryVariable("item");
                    writer.Line($"foreach (var {collectionItemVariable:D} in {element}.EnumerateArray())");
                    using (writer.Scope())
                    {
                        if (array.ValueSerialization is JsonValueSerialization valueSerialization)
                        {
                            writer.Append($"{destination}.Add(");
                            writer.ToDeserializeCall(
                                valueSerialization,
                                w => w.AppendRaw(collectionItemVariable));
                            writer.Line($");");
                        }
                        else
                        {
                            var itemVariableName = "value";
                            writer.ToDeserializeCall(
                                array.ValueSerialization,
                                w => w.AppendRaw(collectionItemVariable),
                                ref itemVariableName);

                            writer.Append($"{destination}.Add({itemVariableName});");
                        }
                    }

                    return;
                case JsonObjectSerialization dictionary:
                    string itemVariable = writer.GetTemporaryVariable("property");
                    writer.Line($"foreach (var {itemVariable:D} in {element}.EnumerateObject())");
                    using (writer.Scope())
                    {
                        foreach (JsonPropertySerialization property in dictionary.Properties)
                        {
                            ReadProperty(writer, itemVariable, destination, property);
                        }

                        if (dictionary.AdditionalProperties is JsonDynamicPropertiesSerialization additionalProperties)
                        {
                            if (additionalProperties.ValueSerialization is JsonValueSerialization valueSerialization)
                            {
                                writer.Append($"{destination}.Add({itemVariable}.Name, ");
                                writer.ToDeserializeCall(
                                    valueSerialization,
                                    w => w.Append($"{itemVariable}.Value"));
                                writer.Line($");");
                            }
                            else
                            {
                                var itemVariableName = "value";
                                writer.ToDeserializeCall(
                                    additionalProperties.ValueSerialization,
                                    w => w.Append($"{itemVariable}.Value"),
                                    ref itemVariableName);

                                writer.Append($"{destination}.Add({itemVariable}.Name, {itemVariableName});");
                            }
                        }
                    }

                    return;
            }

            writer.Append($"{destination} = ");
            ToDeserializeCall(writer, (JsonValueSerialization) serialization, element);
            writer.Line($";");
        }

        private static void ReadProperty(CodeWriter writer, string itemVariable, CodeWriterDelegate destination, JsonPropertySerialization property)
        {
            CSharpType? type = property.ValueSerialization.Type;
            string? name = property.MemberName;

            bool hasNullableType = type != null && type.IsNullable;

            void WriteNullCheck()
            {
                using (writer.If($"{itemVariable}.Value.ValueKind == {writer.Type(typeof(JsonValueKind))}.Null"))
                {
                    writer.Append($"continue;");
                }
            }

            void WriteInitialization()
            {
                if (hasNullableType && TryGetInitializerType(property.ValueSerialization, out CSharpType? initializerType))
                {
                    writer.Line($"{destination}.{name} = new {initializerType}();");
                }
            }

            writer.Append($"if({itemVariable}.NameEquals({property.Name:L}))");
            using (writer.Scope())
            {
                if (hasNullableType)
                {
                    WriteNullCheck();
                }

                WriteInitialization();

                CodeWriterDelegate nextDestination = name == null ? destination : w => w.Append($"{destination}.{name}");
                writer.ToDeserializeCall(property.ValueSerialization, nextDestination, w => w.Append($"{itemVariable}.Value"));
                writer.Line($"continue;");
            }
        }

        private static bool TryGetInitializerType(JsonSerialization jsonSerialization, [NotNullWhen(true)] out CSharpType? type)
        {
            type = jsonSerialization switch
            {
                JsonObjectSerialization objectSerialization => objectSerialization.ImplementationType,
                JsonArraySerialization arraySerialization => arraySerialization.ImplementationType,
                _ => null
            };

            return type != null;
        }

        private static void ToDeserializeCall(this CodeWriter writer, JsonValueSerialization serialization, CodeWriterDelegate element)
        {
            if (serialization.Type.IsFrameworkType)
            {
                var frameworkType = serialization.Type.FrameworkType;
                bool includeFormat = false;

                writer.Append($"{element}.");
                if (frameworkType == typeof(object))
                    writer.AppendRaw("GetObject");
                if (frameworkType == typeof(bool))
                    writer.AppendRaw("GetBoolean");
                if (frameworkType == typeof(char))
                    writer.AppendRaw("GetChar");
                if (frameworkType == typeof(short))
                    writer.AppendRaw("GetInt16");
                if (frameworkType == typeof(int))
                    writer.AppendRaw("GetInt32");
                if (frameworkType == typeof(long))
                    writer.AppendRaw("GetInt64");
                if (frameworkType == typeof(float))
                    writer.AppendRaw("GetSingle");
                if (frameworkType == typeof(double))
                    writer.AppendRaw("GetDouble");
                if (frameworkType == typeof(decimal))
                    writer.AppendRaw("GetDecimal");
                if (frameworkType == typeof(string))
                    writer.AppendRaw("GetString");
                if (frameworkType == typeof(Guid))
                    writer.AppendRaw("GetGuid");

                if (frameworkType == typeof(byte[]))
                {
                    writer.AppendRaw("GetBytesFromBase64");
                    includeFormat = true;
                }

                if (frameworkType == typeof(DateTimeOffset))
                {
                    writer.AppendRaw("GetDateTimeOffset");
                    includeFormat = true;
                }

                if (frameworkType == typeof(TimeSpan))
                {
                    writer.AppendRaw("GetTimeSpan");
                    includeFormat = true;
                }

                writer.AppendRaw("(");

                if (includeFormat && serialization.Format.ToFormatSpecifier() is string formatString)
                {
                    writer.Literal(formatString);
                }

                writer.AppendRaw(")");
            }
            else
            {
                writer.ToDeserializeCall(serialization.Type.Implementation, element);
            }
        }

        public static void ToDeserializeCall(this CodeWriter writer, ITypeProvider implementation, CodeWriterDelegate element)
        {
            switch (implementation)
            {
                case ObjectType objectType:
                    writer.Append($"{implementation.Type}.Deserialize{objectType.Declaration.Name}({element})");
                    break;

                case EnumType clientEnum when clientEnum.IsStringBased:
                    writer.Append($"new {implementation.Type}({element}.GetString())");
                    break;

                case EnumType clientEnum when !clientEnum.IsStringBased:
                    writer.Append($"{element}.GetString().To{clientEnum.Declaration.Name}()");
                    break;
            }
        }

        public static string? ToFormatSpecifier(this SerializationFormat format) => format switch
        {
            SerializationFormat.DateTime_RFC1123 => "R",
            SerializationFormat.DateTime_ISO8601 => "S",
            SerializationFormat.Date_ISO8601 => "D",
            SerializationFormat.DateTime_Unix => "U",
            SerializationFormat.Bytes_Base64Url => "U",
            SerializationFormat.Duration_ISO8601 => "P",
            _ => null
        };
    }
}