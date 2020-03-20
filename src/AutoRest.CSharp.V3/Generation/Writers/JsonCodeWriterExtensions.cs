// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using AutoRest.CSharp.V3.Generation.Types;
using AutoRest.CSharp.V3.Input;
using AutoRest.CSharp.V3.Output.Models.Requests;
using AutoRest.CSharp.V3.Output.Models.Serialization;
using AutoRest.CSharp.V3.Output.Models.Serialization.Json;
using AutoRest.CSharp.V3.Output.Models.Shared;
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

                case JsonObjectSerialization obj:
                    writer.Line($"{writerName}.WriteStartObject();");
                    var itemVariable = new CodeWriterDeclaration("item");

                    foreach (JsonPropertySerialization property in obj.Properties)
                    {
                        bool hasNullableType = property.Property != null && property.Property.Declaration.Type.IsNullable;
                        using (hasNullableType ? writer.Scope($"if ({property.Property!.Declaration.Name} != null)") : default)
                        {
                            writer.Line($"{writerName}.WritePropertyName({property.Name:L});");
                            writer.ToSerializeCall(
                                property.ValueSerialization,
                                w => w.Append($"{property.Property?.Declaration.Name}"));
                        }
                    }

                    if (obj.AdditionalProperties != null)
                    {
                        writer.ToSerializeCall(
                            obj.AdditionalProperties.Serialization,
                            w => w.Append($"{obj.AdditionalProperties.Property.Declaration.Name}"),
                            writerName);
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
                    .DeserializeIntoVariableMayBeObject(serialization, w => w.Append(destinationDeclaration), element);
            }

            destination = destinationDeclaration.ActualName;
        }

        private static void DeserializeIntoVariableMayBeObject(this CodeWriter writer,
            JsonSerialization serialization,
            CodeWriterDelegate destination,
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

                writer.Line($"foreach (var {itemVariable:D} in {element}.EnumerateObject())");
                using (writer.Scope())
                {
                    foreach (JsonPropertySerialization property in obj.Properties)
                    {
                        CSharpType? type = property.ValueSerialization.Type;

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
                                    w => w.Append(propertyVariables[property.Property]),
                                    w => w.Append($"{itemVariable.ActualName}.Value"));
                            }
                            else
                            {
                                // Reading a nested object
                                writer.DeserializeIntoVariableMayBeObject(
                                    property.ValueSerialization,
                                    w => { },
                                    w => w.Append($"{itemVariable.ActualName}.Value"));
                            }

                            writer.Line($"continue;");
                        }
                    }

                    var objAdditionalProperties = obj.AdditionalProperties;
                    if (objAdditionalProperties != null)
                    {
                        var variable = propertyVariables[objAdditionalProperties.Property];

                        writer.Line($"{variable} ??= new {objAdditionalProperties.Serialization.Type}();");

                        DeserializeValue(writer,
                            objAdditionalProperties.Serialization.ValueSerialization,
                            w => w.Append($"{itemVariable}.Value"),
                            (w, v) => w.Line($"{variable}.Add({itemVariable}.Name, {v});"));
                    }
                }

                if (obj.ImplementationType != null)
                {
                    var initializers = new List<ObjectPropertyInitializer>();
                    foreach (var variable in propertyVariables)
                    {
                        var property = variable.Key;

                        initializers.Add(new ObjectPropertyInitializer(
                            property,
                            new Reference(variable.Value.ActualName, property.Declaration.Type)));
                    }

                    writer.Append($"{destination} = ")
                        .WriteInitialization((ObjectType) obj.ImplementationType.Implementation, initializers)
                        .Line($";");
                }
            }
            else
            {
                DeserializeIntoVariable(writer, serialization, destination, element);
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
                        DeserializeValue(writer,
                            array.ValueSerialization,
                            w => w.Append($"{collectionItemVariable}"),
                            (w, returnValue) => writer.Append($"{arrayVariable}.Add({returnValue});"));
                    }

                    writer.Line($"{destination} = {arrayVariable};");
                    return;
                case JsonDictionarySerialization dictionary:
                    var dictionaryVariable = new CodeWriterDeclaration("array");
                    writer.Line($"{dictionary.Type} {dictionaryVariable:D} = new {dictionary.Type}();");

                    var dictionaryItemVariable = new CodeWriterDeclaration("property");
                    writer.Line($"foreach (var {dictionaryItemVariable:D} in {element}.EnumerateObject())");
                    using (writer.Scope())
                    {
                        DeserializeValue(writer,
                            dictionary.ValueSerialization,
                            w => w.Append($"{dictionaryItemVariable}.Value"),
                            (w, returnValue) => writer.Append($"{dictionaryVariable}.Add({dictionaryItemVariable}.Name, {returnValue});"));
                    }

                    writer.Line($"{destination} = {dictionaryVariable};");

                    return;
            }

            writer.Append($"{destination} = ");
            DeserializeValue(writer, (JsonValueSerialization) serialization, element);
            writer.Line($";");
        }

        private static void DeserializeValue(CodeWriter writer, JsonSerialization serialization, CodeWriterDelegate value, Action<CodeWriter, CodeWriterDelegate> callback)
        {
            if (serialization is JsonValueSerialization valueSerialization)
            {
                callback(writer, w => w.DeserializeValue(valueSerialization, value));
            }
            else
            {
                var itemVariableName = "value";
                writer.DeserializeDeclareVariable(
                    serialization,
                    value,
                    ref itemVariableName);

                callback(writer, w => w.AppendRaw(itemVariableName));
            }
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
