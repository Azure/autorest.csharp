﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using AutoRest.CSharp.V3.Generation.Types;
using AutoRest.CSharp.V3.Output.Models.Requests;
using AutoRest.CSharp.V3.Output.Models.Serialization;
using AutoRest.CSharp.V3.Output.Models.Serialization.Json;
using AutoRest.CSharp.V3.Output.Models.Types;
using AutoRest.CSharp.V3.Utilities;
using Azure.Core;
using JsonElementExtensions = Azure.Core.JsonElementExtensions;

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

                    using (writer.Scope($"foreach (var {collectionItemVariable:D} in {name})"))
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

                    using (writer.Scope($"foreach (var {dictionaryItemVariable:D} in {name})"))
                    {
                        writer.Line($"{writerName}.WritePropertyName({dictionaryItemVariable}.Key);");
                        writer.ToSerializeCall(
                            dictionary.ValueSerialization,
                            w => w.Append($"{dictionaryItemVariable}.Value"),
                            writerName);
                    }

                    writer.Line($"{writerName}.WriteEndObject();");
                    return;

                case JsonObjectSerialization obj:
                    writer.Line($"{writerName}.WriteStartObject();");

                    foreach (JsonPropertySerialization property in obj.Properties)
                    {
                        bool hasNullableType = property.Property?.Declaration.Type.IsNullable == true;
                        bool emptyAsUndefined = property.Property?.EmptyAsUndefined == true;

                        CodeWriter.CodeWriterScope? scope = default;
                        if (hasNullableType || emptyAsUndefined)
                        {
                            var propertyName = property.Property!.Declaration.Name;
                            writer.Append($"if (");
                            if (hasNullableType)
                            {
                                writer.Append($"{propertyName} != null");
                            }

                            if (emptyAsUndefined)
                            {
                                if (hasNullableType)
                                {
                                    writer.Append($" && ");
                                }
                                writer.UseNamespace(typeof(Enumerable).Namespace!);
                                writer.Append($"{propertyName}.Any()");
                            }
                            writer.Append($")");
                            scope = writer.Scope();
                        }

                        using (scope)
                        {
                            writer.Line($"{writerName}.WritePropertyName({property.Name:L});");
                            writer.ToSerializeCall(
                                property.ValueSerialization,
                                w => w.Append($"{property.Property?.Declaration.Name}"));
                        }

                        if (scope != default && property.Required)
                        {
                            using (writer.Scope($"else"))
                            {
                                writer.Line($"{writerName}.WriteNull({property.Name:L});");
                            }
                        }
                    }

                    if (obj.AdditionalProperties != null)
                    {
                        var itemVariable = new CodeWriterDeclaration("item");

                        using (writer.Scope($"foreach (var {itemVariable:D} in {obj.AdditionalProperties.Property.Declaration.Name})"))
                        {
                            writer.Line($"{writerName}.WritePropertyName({itemVariable}.Key);");
                            writer.ToSerializeCall(
                                obj.AdditionalProperties.ValueSerialization,
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

                        if (frameworkType == typeof(JsonElement))
                        {
                            writer.Line($"{name}.WriteTo({writerName});");
                            return;
                        }

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
                            if (valueSerialization.Format == SerializationFormat.DateTime_Unix)
                            {
                                writer.AppendRaw("WriteNumberValue");
                            }
                            else
                            {
                                writer.AppendRaw("WriteStringValue");
                            }
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

        private static void DeserializeIntoVariableMayBeObject(this CodeWriter writer,
            JsonSerialization serialization,
            Action<CodeWriter, CodeWriterDelegate> valueCallback,
            CodeWriterDelegate element,
            Dictionary<ObjectTypeProperty, CodeWriterDeclaration>? propertyVariables = null)
        {
            if (serialization is JsonObjectSerialization obj)
            {
                var itemVariable = new CodeWriterDeclaration("property");

                if (propertyVariables == null)
                {
                    // this is the first level of object hierarchy
                    // collect all properties and initialize the dictionary
                    propertyVariables = new Dictionary<ObjectTypeProperty, CodeWriterDeclaration>();

                    CollectProperties(propertyVariables, obj);

                    foreach (var variable in propertyVariables)
                    {
                        var objectTypeProperty = variable.Key;
                        writer.Line($"{objectTypeProperty.Declaration.Type} {variable.Value:D} = default;");
                    }
                }

                var dictionaryVariable = new CodeWriterDeclaration("additionalPropertiesDictionary");

                var objAdditionalProperties = obj.AdditionalProperties;
                if (objAdditionalProperties != null)
                {
                    writer.Line($"{objAdditionalProperties.Type} {dictionaryVariable:D} = default;");
                }

                using (writer.Scope($"foreach (var {itemVariable:D} in {element}.EnumerateObject())"))
                {
                    foreach (JsonPropertySerialization property in obj.Properties)
                    {
                        CSharpType? type = property.Property?.Declaration.Type;

                        bool hasNullableType = type != null && type.IsNullable;

                        void WriteNullCheck()
                        {
                            using (writer.Scope($"if ({itemVariable.ActualName}.Value.ValueKind == {typeof(JsonValueKind)}.Null)"))
                            {
                                writer.Append($"continue;");
                            }
                        }

                        writer.Append($"if({itemVariable.ActualName}.NameEquals({property.Name:L}))");
                        using (writer.Scope())
                        {
                            if (hasNullableType)
                            {
                                WriteNullCheck();
                            }

                            if (property.Property != null)
                            {
                                // Reading a property value
                                writer.DeserializeIntoVariable(
                                    property.ValueSerialization,
                                    (w, v) => w.Line($"{propertyVariables[property.Property]} = {v};"),
                                    w => w.Append($"{itemVariable.ActualName}.Value"));
                            }
                            else
                            {
                                // Reading a nested object
                                writer.DeserializeIntoVariableMayBeObject(
                                    property.ValueSerialization,
                                    (w, v) => { },
                                    w => w.Append($"{itemVariable.ActualName}.Value"),
                                    propertyVariables);
                            }

                            writer.Line($"continue;");
                        }
                    }

                    if (objAdditionalProperties != null)
                    {
                        writer.Line($"{dictionaryVariable} ??= new {objAdditionalProperties.Type}();");
                        writer.DeserializeValue(
                            objAdditionalProperties.ValueSerialization,
                            w => w.Append($"{itemVariable}.Value"),
                            (w, v) => w.Line($"{dictionaryVariable}.Add({itemVariable}.Name, {v});"));
                    }
                }

                if (objAdditionalProperties != null)
                {
                    writer.Line($"{propertyVariables[objAdditionalProperties.Property]} = {dictionaryVariable};");
                }

                if (obj.Type != null)
                {
                    var initializers = new List<ObjectPropertyInitializer>();
                    foreach (var variable in propertyVariables)
                    {
                        var property = variable.Key;

                        initializers.Add(new ObjectPropertyInitializer(
                            property,
                            new Reference(variable.Value.ActualName, property.Declaration.Type)));
                    }

                    valueCallback(writer,
                        w => w.WriteInitialization((ObjectType) obj.Type.Implementation, initializers));
                }
            }
            else
            {
                writer.DeserializeIntoVariableWithNullHandling(serialization, valueCallback, element);
            }
        }

        /// Collects a list of properties being read from all level of object hierarchy
        private static void CollectProperties(Dictionary<ObjectTypeProperty, CodeWriterDeclaration> propertyVariables, JsonObjectSerialization obj)
        {
            foreach (JsonPropertySerialization jsonProperty in obj.Properties)
            {
                ObjectTypeProperty? objectProperty = jsonProperty.Property;

                if (objectProperty != null)
                {
                    var propertyDeclaration = new CodeWriterDeclaration(jsonProperty.Name.ToVariableName());
                    propertyVariables.Add(objectProperty, propertyDeclaration);
                }
                else if (jsonProperty.ValueSerialization is JsonObjectSerialization objectSerialization)
                {
                    CollectProperties(propertyVariables, objectSerialization);
                }
            }

            var additionalPropertiesProperty = obj.AdditionalProperties?.Property;
            if (additionalPropertiesProperty != null)
            {
                var propertyDeclaration = new CodeWriterDeclaration(additionalPropertiesProperty.Declaration.Name.ToVariableName());
                propertyVariables.Add(additionalPropertiesProperty, propertyDeclaration);
            }
        }

        private static void DeserializeIntoVariableWithNullHandling(this CodeWriter writer, JsonSerialization serialization, Action<CodeWriter, CodeWriterDelegate> valueCallback, CodeWriterDelegate element)
        {
            CSharpType? type = null;
            switch (serialization)
            {
                case JsonArraySerialization array:
                    type = array.Type;
                    break;
                case JsonDictionarySerialization dictionary:
                    type = dictionary.Type;
                    break;
                case JsonValueSerialization valueSerialization:
                    type = valueSerialization.Type;
                    break;
            }

            if (type != null && (type.IsNullable || !type.IsValueType))
            {
                using (writer.Scope($"if ({element}.ValueKind == {typeof(JsonValueKind)}.Null)"))
                {
                    valueCallback(writer, w => w.Append($"null"));
                }
                using (writer.Scope($"else"))
                {
                    writer.DeserializeIntoVariable(serialization, valueCallback, element);
                }
            }
            else
            {
                writer.DeserializeIntoVariable(serialization, valueCallback, element);
            }
        }

        private static void DeserializeIntoVariable(this CodeWriter writer, JsonSerialization serialization, Action<CodeWriter, CodeWriterDelegate> valueCallback, CodeWriterDelegate element)
        {
            switch (serialization)
            {
                case JsonArraySerialization array:
                    var arrayVariable = new CodeWriterDeclaration("array");
                    writer.Line($"{array.Type} {arrayVariable:D} = new {array.Type}();");

                    var collectionItemVariable = new CodeWriterDeclaration("item");
                    using (writer.Scope($"foreach (var {collectionItemVariable:D} in {element}.EnumerateArray())"))
                    {
                        writer.DeserializeValue(
                            array.ValueSerialization,
                            w => w.Append($"{collectionItemVariable}"),
                            (w, returnValue) => writer.Append($"{arrayVariable}.Add({returnValue});"));
                    }

                    valueCallback(writer, w => w.Append(arrayVariable));
                    return;
                case JsonDictionarySerialization dictionary:
                    var dictionaryVariable = new CodeWriterDeclaration("dictionary");
                    writer.Line($"{dictionary.Type} {dictionaryVariable:D} = new {dictionary.Type}();");

                    var dictionaryItemVariable = new CodeWriterDeclaration("property");
                    using (writer.Scope($"foreach (var {dictionaryItemVariable:D} in {element}.EnumerateObject())"))
                    {
                        writer.DeserializeValue(
                            dictionary.ValueSerialization,
                            w => w.Append($"{dictionaryItemVariable}.Value"),
                            (w, returnValue) => writer.Append($"{dictionaryVariable}.Add({dictionaryItemVariable}.Name, {returnValue});"));
                    }

                    valueCallback(writer, w => w.Append(dictionaryVariable));
                    return;
                case JsonValueSerialization valueSerialization:
                    valueCallback(writer, w => w.DeserializeValue(valueSerialization, element));
                    return;
            }
        }

        public static void DeserializeValue(this CodeWriter writer, JsonSerialization serialization, CodeWriterDelegate value, Action<CodeWriter, CodeWriterDelegate> valueCallback)
        {
            writer.DeserializeIntoVariableMayBeObject(
                serialization,
                valueCallback,
                value);
        }

        private static void DeserializeValue(this CodeWriter writer, JsonValueSerialization serialization, CodeWriterDelegate element)
        {
            writer.UseNamespace(typeof(JsonElementExtensions).Namespace!);

            if (serialization.Type.IsFrameworkType)
            {
                DeserializeFrameworkTypeValue(writer, element, serialization.Type.FrameworkType, serialization.Format);
            }
            else
            {
                writer.DeserializeImplementation(serialization.Type.Implementation, element);
            }
        }

        private static void DeserializeFrameworkTypeValue(CodeWriter writer, CodeWriterDelegate element, Type frameworkType, SerializationFormat serializationFormat)
        {
            bool includeFormat = false;

            writer.Append($"{element}.");

            if (frameworkType == typeof(JsonElement))
                writer.AppendRaw("Clone");
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

            if (includeFormat && serializationFormat.ToFormatSpecifier() is string formatString)
            {
                writer.Literal(formatString);
            }

            writer.AppendRaw(")");
        }

        public static void DeserializeImplementation(this CodeWriter writer, TypeProvider implementation, CodeWriterDelegate element)
        {
            switch (implementation)
            {
                case ObjectType objectType:
                    writer.Append($"{implementation.Type}.Deserialize{objectType.Declaration.Name}({element})");
                    break;

                case EnumType clientEnum when clientEnum.IsExtendable:
                    writer.Append($"new {implementation.Type}(");
                    DeserializeFrameworkTypeValue(writer, element, clientEnum.BaseType.FrameworkType, SerializationFormat.Default);
                    writer.Append($")");
                    break;

                case EnumType clientEnum when !clientEnum.IsExtendable:
                    DeserializeFrameworkTypeValue(writer, element, clientEnum.BaseType.FrameworkType, SerializationFormat.Default);
                    writer.Append($".To{clientEnum.Declaration.Name}()");
                    break;
            }
        }

        public static string? ToFormatSpecifier(this SerializationFormat format) => format switch
        {
            SerializationFormat.DateTime_RFC1123 => "R",
            SerializationFormat.DateTime_ISO8601 => "O",
            SerializationFormat.Date_ISO8601 => "D",
            SerializationFormat.DateTime_Unix => "U",
            SerializationFormat.Bytes_Base64Url => "U",
            SerializationFormat.Duration_ISO8601 => "P",
            SerializationFormat.Time_ISO8601 => "T",
            _ => null
        };

        public static void WriteDeserializationForMethods(this CodeWriter writer, JsonSerialization serialization, bool async,
            Action<CodeWriter, CodeWriterDelegate> callback, string response)
        {
            var documentVariable = new CodeWriterDeclaration("document");
            writer.Append($"using var {documentVariable:D} = ");
            if (async)
            {
                writer.Line($"await {typeof(JsonDocument)}.ParseAsync({response}.ContentStream, default, cancellationToken).ConfigureAwait(false);");
            }
            else
            {
                writer.Line($"{typeof(JsonDocument)}.Parse({response}.ContentStream);");
            }

            writer.DeserializeValue(
                serialization,
                w => w.Append($"{documentVariable}.RootElement"),
                callback
            );
        }
    }
}
