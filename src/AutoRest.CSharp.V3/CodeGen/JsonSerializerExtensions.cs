// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using AutoRest.CSharp.V3.ClientModels;
using AutoRest.CSharp.V3.ClientModels.Serialization;

namespace AutoRest.CSharp.V3.CodeGen
{
    internal static class JsonSerializerExtensions
    {
        public static void ToSerializeCall(this CodeWriter writer, ClientTypeReference type, SerializationFormat format, TypeFactory typeFactory, CodeWriterDelegate name, CodeWriterDelegate? serializedName = null, CodeWriterDelegate? writerName = null)
        {
            writerName ??= w => w.AppendRaw("writer");

            if (serializedName != null)
            {
                writer.Line($"{writerName}.WritePropertyName({serializedName});");
            }

            CSharpType implementationType = typeFactory.CreateType(type);

            switch (type)
            {
                case CollectionTypeReference array:
                    writer.Line($"{writerName}.WriteStartArray();");
                    string collectionItemVariable = writer.GetTemporaryVariable("item");
                    writer.Line($"foreach (var {collectionItemVariable:D} in {name})");
                    using (writer.Scope())
                    {
                        writer.ToSerializeCall(
                            array.ItemType,
                            format,
                            typeFactory,
                            w => w.AppendRaw(collectionItemVariable),
                            serializedName: null,
                            writerName);
                    }

                    writer.Line($"{writerName}.WriteEndArray();");
                    return;

                case DictionaryTypeReference dictionary:
                    writer.Line($"{writerName}.WriteStartObject();");
                    string itemVariable = writer.GetTemporaryVariable("item");
                    writer.Line($"foreach (var {itemVariable:D} in {name})");
                    using (writer.Scope())
                    {
                        writer.ToSerializeCall(
                            dictionary.ValueType,
                            format,
                            typeFactory,
                            w => w.Append($"{itemVariable}.Value"),
                            w => w.Append($"{itemVariable}.Key"),
                            writerName);
                    }

                    writer.Line($"{writerName}.WriteEndObject();");
                    return;

                case SchemaTypeReference schemaTypeReference:
                    switch (typeFactory.ResolveReference(schemaTypeReference))
                    {
                        case ClientObject _:
                            writer.Line($"{writerName}.WriteObjectValue({name});");
                            return;

                        case ClientEnum clientEnum:
                            writer.Append($"{writerName}.WriteStringValue({name}")
                                .AppendNullableValue(implementationType)
                                .AppendRaw(clientEnum.IsStringBased ? ".ToString()" : ".ToSerialString()")
                                .Line($");");
                            return;
                    }
                    return;

                case BinaryTypeReference _:
                    writer.Line($"{writerName}.WriteBase64StringValue({name});");
                    return;

                case FrameworkTypeReference frameworkTypeReference:
                    var frameworkType = frameworkTypeReference.Type;
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
                             frameworkType == typeof(char))
                    {
                        writer.AppendRaw("WriteStringValue");
                    }
                    else if (frameworkType == typeof(bool))
                    {
                        writer.AppendRaw("WriteBooleanValue");
                    }
                    else if (frameworkType == typeof(DateTimeOffset) ||
                             frameworkType == typeof(DateTime) ||
                             frameworkType == typeof(TimeSpan))
                    {
                        writer.AppendRaw("WriteStringValue");
                        writeFormat = true;
                    }

                    writer.Append($"({name}")
                        .AppendNullableValue(implementationType);

                    if (writeFormat && format.ToFormatSpecifier() is string formatString)
                    {
                        writer.Append($", {formatString:L}");
                    }

                    writer.LineRaw(");");
                    return;
            }
        }

        public static void ToDeserializeCall(this CodeWriter writer, JsonSerialization serialization, TypeFactory typeFactory, CodeWriterDelegate element, out string destination)
        {
            var type = serialization.Type;

            destination = writer.GetTemporaryVariable("value");

            if (serialization is JsonValueSerialization valueSerialization)
            {
                writer.Append($"var {destination:D} =")
                    .ToDeserializeCall(valueSerialization, typeFactory, element);
                writer.LineRaw(";");
            }
            else
            {
                string s = destination;

                writer
                    .Line($"{typeFactory.CreateType(type)} {destination:D} = new {typeFactory.CreateConcreteType(type)}();")
                    .ToDeserializeCall(serialization, typeFactory, w=>w.AppendRaw(s), element);
            }
        }

        public static void ToDeserializeCall(this CodeWriter writer, JsonSerialization serialization, TypeFactory typeFactory, CodeWriterDelegate destination, CodeWriterDelegate element)
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
                                typeFactory,
                                w => w.AppendRaw(collectionItemVariable));
                            writer.Line($");");
                        }
                        else
                        {
                            writer.ToDeserializeCall(
                                array.ValueSerialization,
                                typeFactory,
                                w => w.AppendRaw(collectionItemVariable),
                                out var temp);

                            writer.Append($"{destination}.Add({temp});");
                        }
                    }

                    return;
                case JsonObjectSerialization dictionary:
                    if (dictionary.AdditionalProperties is JsonDynamicPropertiesSerialization additionalProperties)
                    {
                        string itemVariable = writer.GetTemporaryVariable("item");
                        writer.Line($"foreach (var {itemVariable:D} in {element}.EnumerateObject())");
                        using (writer.Scope())
                        {
                            if (additionalProperties.ValueSerialization is JsonValueSerialization valueSerialization)
                            {
                                writer.Append($"{destination}.Add({itemVariable}.Name, ");
                                writer.ToDeserializeCall(
                                    valueSerialization,
                                    typeFactory,
                                    w => w.Append($"{itemVariable}.Value"));
                                writer.Line($");");
                            }
                            else
                            {
                                writer.ToDeserializeCall(
                                    additionalProperties.ValueSerialization,
                                    typeFactory,
                                    w => w.Append($"{itemVariable}.Value"),
                                    out var temp);

                                writer.Append($"{destination}.Add({itemVariable}.Name, {temp});");
                            }
                        }
                    }
                    return;
            }

            writer.Append($"{destination} = ");
            ToDeserializeCall(writer, (JsonValueSerialization)serialization, typeFactory, element);
            writer.Line($";");
        }

        public static void ToDeserializeCall(this CodeWriter writer, JsonValueSerialization serialization, TypeFactory typeFactory, CodeWriterDelegate element)
        {
            switch (serialization.Type)
            {
                case SchemaTypeReference schemaTypeReference:
                    writer.ToDeserializeCall(schemaTypeReference, typeFactory, element);
                    return;

                case BinaryTypeReference _:
                    writer.Append($"{element}.GetBytesFromBase64()");
                    return;

                case FrameworkTypeReference frameworkTypeReference:
                    bool includeFormat = false;
                    var frameworkType = frameworkTypeReference.Type;
                    writer.Append($"{element}.");
                    if (frameworkType == typeof(object))
                        writer.AppendRaw("GetObject");
                    if (frameworkType == typeof(bool))
                        writer.AppendRaw("GetBoolean");
                    if (frameworkType == typeof(char))
                        writer.AppendRaw("GetString");
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
                    return;
            }
        }

        public static void ToDeserializeCall(this CodeWriter writer, SchemaTypeReference type, TypeFactory typeFactory, CodeWriterDelegate element)
        {
            CSharpType cSharpType = typeFactory.CreateType(type).WithNullable(false);

            switch (typeFactory.ResolveReference(type))
            {
                case ClientObject _:
                    writer.Append($"{cSharpType}.Deserialize{cSharpType.Name}({element})");
                    break;

                case ClientEnum clientEnum when clientEnum.IsStringBased:
                    writer.Append($"new {cSharpType}({element}.GetString())");
                    break;

                case ClientEnum clientEnum when !clientEnum.IsStringBased:
                    writer.Append($"{element}.GetString().To{cSharpType}()");
                    break;
            }
        }

        public static string? ToFormatSpecifier(this SerializationFormat format) => format switch
        {
            SerializationFormat.DateTime_RFC1123 => "R",
            SerializationFormat.DateTime_ISO8601 => "S",
            SerializationFormat.Date_ISO8601 => "D",
            SerializationFormat.DateTime_Unix => "U",
            SerializationFormat.Duration_ISO8601 => "P",
            _ => null
        };
    }
}
