﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using AutoRest.CSharp.V3.Generation.Types;
using AutoRest.CSharp.V3.Output.Models.Serialization;
using AutoRest.CSharp.V3.Output.Models.Serialization.Json;
using AutoRest.CSharp.V3.Output.Models.Types;
using AutoRest.CSharp.V3.Utilities;

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
                    var collectionItemVariable = new CodeWriterDeclaration("item");
                    writer.Line($"foreach (var {collectionItemVariable:D} in {name})");
                    using (writer.Scope())
                    {
                        writer.ToSerializeCall(
                            array.ValueSerialization,
                            w => w.Append(collectionItemVariable),
                            writerName);
                    }

                    writer.Line($"{writerName}.WriteEndArray();");
                    return;

                case JsonDictionarySerialization dictionary:
                    writer.Line($"{writerName}.WriteStartObject();");
                    var dictionaryItemVariable = new CodeWriterDeclaration("item");

                    writer.Line($"foreach (var {dictionaryItemVariable:D} in {name})");
                    using (writer.Scope())
                    {
                        writer.Line($"{writerName}.WritePropertyName({dictionaryItemVariable}.Key);");
                        writer.ToSerializeCall(
                            dictionary.ValueSerialization,
                            w => w.Append($"{dictionaryItemVariable}.Value"),
                            writerName);
                    }

                    writer.Line($"{writerName}.WriteEndObject();");
                    return;

                case JsonObjectSerialization dictionary:
                    writer.Line($"{writerName}.WriteStartObject();");
                    var itemVariable = new CodeWriterDeclaration("item");

                    foreach (JsonPropertySerialization property in dictionary.Properties)
                    {
                        CSharpType? serializationType = property.ValueSerialization.Type;
                        bool hasNullableType = serializationType != null && serializationType.IsNullable;
                        using (hasNullableType ? writer.Scope($"if ({property.MemberName} != null)") : default)
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
                    writer.UseNamespace(typeof(Utf8JsonWriterExtensions).Namespace!);

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
                                .AppendEnumToString(clientEnum)
                                .Line($");");
                            return;
                    }

                    throw new NotSupportedException();

                default:
                    throw new NotSupportedException();
            }
        }

        public static void DeserializeDeclareVariable(this CodeWriter writer, JsonSerialization serialization, CodeWriterDelegate element, ref string destination)
        {
            var destinationDeclaration = new CodeWriterDeclaration(destination);

            if (serialization is JsonValueSerialization valueSerialization)
            {
                writer.Append($"var {destinationDeclaration:D} =")
                    .DeserializeValue(valueSerialization, element);
                writer.LineRaw(";");
            }
            else
            {
                var type = serialization.Type;
                Debug.Assert(type != null);

                writer
                    .Line($"{type} {destinationDeclaration:D};")
                    .DeserializeIntoVariable(serialization, w => w.Append(destinationDeclaration), element);
            }

            destination = destinationDeclaration.ActualName;
        }

        private static void DeserializeIntoVariable(this CodeWriter writer, JsonSerialization serialization, CodeWriterDelegate destination, CodeWriterDelegate element)
        {
            switch (serialization)
            {
                case JsonArraySerialization array:
                    var arrayVariable = new CodeWriterDeclaration("array");
                    writer.Line($"{array.ImplementationType} {arrayVariable:D} = new {array.ImplementationType}();");

                    var collectionItemVariable = new CodeWriterDeclaration("item");
                    writer.Line($"foreach (var {collectionItemVariable:D} in {element}.EnumerateArray())");
                    using (writer.Scope())
                    {
                        if (array.ValueSerialization is JsonValueSerialization valueSerialization)
                        {
                            writer.Append($"{arrayVariable}.Add(");
                            writer.DeserializeValue(
                                valueSerialization,
                                w => w.Append(collectionItemVariable));
                            writer.Line($");");
                        }
                        else
                        {
                            var itemVariableName = "value";
                            writer.DeserializeDeclareVariable(
                                array.ValueSerialization,
                                w => w.Append(collectionItemVariable),
                                ref itemVariableName);

                            writer.Append($"{arrayVariable}.Add({itemVariableName});");
                        }
                    }

                    writer.Append($"{destination} = {arrayVariable}");
                    return;
                case JsonDictionarySerialization dictionary:
                    var dictionaryVariable = new CodeWriterDeclaration("array");
                    writer.Line($"{dictionary.Type} {dictionaryVariable:D} = new {dictionary.Type}();");

                    var dictionaryItemVariable = new CodeWriterDeclaration("property");
                    writer.Line($"foreach (var {dictionaryItemVariable:D} in {element}.EnumerateObject())");
                    using (writer.Scope())
                    {
                        if (dictionary.ValueSerialization is JsonValueSerialization valueSerialization)
                        {
                            writer.Append($"{dictionaryVariable}.Add({dictionaryItemVariable}.Name, ");
                            writer.DeserializeValue(
                                valueSerialization,
                                w => w.Append($"{dictionaryItemVariable}.Value"));
                            writer.Line($");");
                        }
                        else
                        {
                            var itemVariableName = "value";
                            writer.DeserializeDeclareVariable(
                                dictionary.ValueSerialization,
                                w => w.Append($"{dictionaryItemVariable}.Value"),
                                ref itemVariableName);

                            writer.Append($"{dictionaryVariable}.Add({dictionaryItemVariable}.Name, {itemVariableName});");
                        }
                    }

                    writer.Append($"{destination} = {dictionaryVariable}");

                    return;
                case JsonObjectSerialization obj:
                    var itemVariable = new CodeWriterDeclaration("property");
                    var propertyVariables = new Dictionary<JsonPropertySerialization, CodeWriterDeclaration>();

                    foreach (JsonPropertySerialization property in obj.Properties)
                    {
                        var propertyDeclaration = new CodeWriterDeclaration(property.Name.ToVariableName());
                        propertyVariables.Add(property, propertyDeclaration);

                        writer.Line($"{property.ValueSerialization.Type} {propertyDeclaration:D} = default;");
                    }

                    writer.Line($"foreach (var {itemVariable:D} in {element}.EnumerateObject())");
                    using (writer.Scope())
                    {
                        foreach (JsonPropertySerialization property in obj.Properties)
                        {
                            ReadProperty(writer, itemVariable.ActualName, w => w.Append(propertyVariables[property]), property);
                        }

                        if (obj.AdditionalProperties is JsonDictionarySerialization additionalProperties)
                        {
                            if (additionalProperties.ValueSerialization is JsonValueSerialization valueSerialization)
                            {
                                writer.Append($"{destination}.Add({itemVariable}.Name, ");
                                writer.DeserializeValue(
                                    valueSerialization,
                                    w => w.Append($"{itemVariable}.Value"));
                                writer.Line($");");
                            }
                            else
                            {
                                var itemVariableName = "value";
                                writer.DeserializeDeclareVariable(
                                    additionalProperties.ValueSerialization,
                                    w => w.Append($"{itemVariable}.Value"),
                                    ref itemVariableName);

                                writer.Append($"{destination}.Add({itemVariable}.Name, {itemVariableName});");
                            }
                        }
                    }

                    // This just happens to work, we need a better binding mechanism
                    writer.Append($"{destination} = new {obj.ImplementationType}(");
                    foreach (JsonPropertySerialization property in obj.Properties)
                    {
                        writer.Append($"{propertyVariables[property]}, ");
                    }

                    writer.RemoveTrailingComma();
                    writer.Line($");");

                    return;
            }

            writer.Append($"{destination} = ");
            DeserializeValue(writer, (JsonValueSerialization) serialization, element);
            writer.Line($";");
        }

        private static void ReadProperty(CodeWriter writer, string itemVariable, CodeWriterDelegate destination, JsonPropertySerialization property)
        {
            CSharpType? type = property.ValueSerialization.Type;

            bool hasNullableType = type != null && type.IsNullable;

            void WriteNullCheck()
            {
                using (writer.Scope($"if ({itemVariable}.Value.ValueKind == {typeof(JsonValueKind)}.Null)"))
                {
                    writer.Append($"continue;");
                }
            }

            writer.Append($"if({itemVariable}.NameEquals({property.Name:L}))");
            using (writer.Scope())
            {
                if (hasNullableType)
                {
                    WriteNullCheck();
                }

                writer.DeserializeIntoVariable(property.ValueSerialization, destination, w => w.Append($"{itemVariable}.Value"));
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

        private static void DeserializeValue(this CodeWriter writer, JsonValueSerialization serialization, CodeWriterDelegate element)
        {
            writer.UseNamespace(typeof(JsonElementExtensions).Namespace!);

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
                writer.DeserializeImplementation(serialization.Type.Implementation, element);
            }
        }

        public static void DeserializeImplementation(this CodeWriter writer, ITypeProvider implementation, CodeWriterDelegate element)
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

        public static void WriteDeserializationForMethods(this CodeWriter writer, JsonSerialization serialization, bool async,
            ref string destination, string response, string document = "document")
        {
            writer.Append($"using var {document:D} = ");
            if (async)
            {
                writer.Line($"await {typeof(JsonDocument)}.ParseAsync({response}.ContentStream, default, cancellationToken).ConfigureAwait(false);");
            }
            else
            {
                writer.Line($"{typeof(JsonDocument)}.Parse({response}.ContentStream);");
            }

            writer.DeserializeDeclareVariable(
                serialization,
                w => w.Append($"{document}.RootElement"),
                ref destination
            );
        }
    }
}
