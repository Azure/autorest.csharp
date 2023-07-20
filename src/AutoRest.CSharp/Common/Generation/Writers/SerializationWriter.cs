// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;
using System.Xml.Linq;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Output.Models.Serialization.Xml;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.Core;
using Azure.Core.Serialization;

namespace AutoRest.CSharp.Generation.Writers
{
    internal class SerializationWriter
    {
        public static readonly ModelWriter.MethodBodyImplementation JsonFromResponseMethod = WriteJsonFromResponseMethod;
        public static readonly ModelWriter.MethodBodyImplementation JsonToRequestContentMethod = WriteJsonToRequestContentMethod;

        public void WriteSerialization(CodeWriter writer, TypeProvider schema)
        {
            switch (schema)
            {
                case SerializableObjectType objectSchema:
                    WriteObjectSerialization(writer, objectSchema);
                    break;
                case EnumType { IsExtensible: false } sealedChoiceSchema:
                    WriteEnumSerialization(writer, sealedChoiceSchema);
                    break;
            }
        }

        private void WriteObjectSerialization(CodeWriter writer, SerializableObjectType model)
            => WriteObjectSerialization(writer, model, model.Declaration, model.JsonSerialization, model.XmlSerialization, model.IsStruct);

        private void WriteObjectSerialization(CodeWriter writer, SerializableObjectType model, TypeDeclarationOptions declaration, JsonObjectSerialization? jsonSerialization, XmlObjectSerialization? xmlSerialization, bool isStruct)
        {
            var hasJson = jsonSerialization != null;
            var hasXml = xmlSerialization != null;

            if (!hasJson && !hasXml)
            {
                return;
            }

            using (writer.Namespace(declaration.Namespace))
            {
                if (jsonSerialization is { IncludeConverter: true })
                {
                    writer.Append($"[{typeof(JsonConverter)}(typeof({declaration.Name}Converter))]");
                }

                writer.Append($"{declaration.Accessibility} partial {(isStruct ? "struct" : "class")} {declaration.Name}");

                writer
                    .AppendIf($": ", hasJson || hasXml)
                    .AppendIf($"{typeof(IUtf8JsonSerializable)}, ", hasJson)
                    .AppendIf($"{typeof(IJsonModelSerializable)}, ", hasJson)
                    .AppendIf($"{typeof(IXmlSerializable)}, ", hasXml)
                    .AppendIf($"{typeof(IXmlModelSerializable)}, ", hasXml)
                    .RemoveTrailingComma();

                writer.Line();
                using (writer.Scope())
                {
                    if (xmlSerialization != null)
                    {
                            WriteXmlSerialize(writer, xmlSerialization);
                            WriteXmlDeserialize(writer, declaration, xmlSerialization, hasJson);
                    }

                    if (jsonSerialization != null)
                    {
                            WriteJsonSerialize(writer, jsonSerialization);
                            WriteJsonDeserialize(writer, declaration, jsonSerialization, hasXml);
                    }

                    foreach (var methodDefinition in model.Methods)
                    {
                        using (writer.WriteCommonMethod(methodDefinition.Signature, null, false, methodDefinition.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public)))
                        {
                            methodDefinition.BodyImplementation(writer, model);
                        }
                        writer.Line();
                    }

                    if (jsonSerialization is { IncludeConverter: true })
                    {
                        WriteCustomJsonConverter(writer, declaration, jsonSerialization.Type);
                    }
                }
            }
        }

        private static void WriteCustomJsonConverter(CodeWriter writer, TypeDeclarationOptions declaration, CSharpType type)
        {
            writer.Append($"internal partial class {declaration.Name}Converter : {typeof(JsonConverter)}<{type}>");
            using (writer.Scope())
            {
                using (writer.Scope($"public override void  Write({typeof(Utf8JsonWriter)} writer, {type} model, {typeof(JsonSerializerOptions)} options)"))
                {
                    writer.Append($"writer.{nameof(Utf8JsonWriterExtensions.WriteObjectValue)}(model);");
                }

                using (writer.Scope($"public override {type} Read(ref {typeof(Utf8JsonReader)} reader, {typeof(Type)} typeToConvert, {typeof(JsonSerializerOptions)} options)"))
                {
                    var document = new CodeWriterDeclaration("document");
                    writer.Line($"using var {document:D} = {typeof(JsonDocument)}.ParseValue(ref reader);");
                    writer.Line($"return Deserialize{declaration.Name}({document}.RootElement);");
                }
            }
        }

        private static void WriteXmlSerialize(CodeWriter writer, XmlObjectSerialization serialization)
        {
            var nameHint = new CodeWriterDeclaration("nameHint");
            writer.Append($"void {typeof(IXmlModelSerializable)}.{nameof(IXmlModelSerializable.Serialize)}({typeof(XmlWriter)} writer, {typeof(ModelSerializerOptions)} options)");
            writer.Line($" => (({typeof(IXmlSerializable)})this).{nameof(IXmlSerializable.Write)}(writer, null, options);");
            writer.Line();
            writer.Append($"void {typeof(IXmlSerializable)}.{nameof(IXmlSerializable.Write)}({typeof(XmlWriter)} writer, {typeof(string)} {nameHint:D}, {typeof(ModelSerializerOptions)} options)");
            using (writer.Scope())
            {
                writer.ToSerializeCall(serialization, nameHint);
            }
            writer.Line();
        }

        private static void WriteXmlDeserialize(CodeWriter writer, TypeDeclarationOptions declaration, XmlObjectSerialization serialization, bool hasJson)
        {
            string deserializeMethod = $"Deserialize{declaration.Name}";

            if (!hasJson)
            {
                using (writer.Scope($"object {typeof(IModelSerializable)}.{nameof(IModelSerializable.Deserialize)}({typeof(BinaryData)} data, {typeof(ModelSerializerOptions)} options)"))
                {
                    WriteXmlInterfaceBody(writer, deserializeMethod);
                }
                writer.Line();
            }

            var element = new CodeWriterDeclaration("element");
            using (writer.Scope($"internal static {serialization.Type} {deserializeMethod}({typeof(XElement)} {element:D}, {typeof(ModelSerializerOptions)} options = default)"))
            {
                writer.Line($"options ??= {typeof(ModelSerializerOptions)}.{nameof(ModelSerializerOptions.AzureServiceDefault)};");
                var propertyVariables = writer.ToDeserializeObjectCall(serialization, element);
                var initializers = new List<PropertyInitializer>();
                foreach (var propertyVariable in propertyVariables)
                {
                    var property = propertyVariable.Key;
                    initializers.Add(new PropertyInitializer(property.PropertyName, property.PropertyType, property.ShouldSkipSerialization, $"{propertyVariable.Value.ActualName}"));
                }

                var objectType = (ObjectType)serialization.Type.Implementation;
                writer.WriteInitialization(v => writer.Line($"return {v};"), objectType, objectType.SerializationConstructor, initializers);
            }
            writer.Line();
        }

        private static void WriteXmlInterfaceBody(CodeWriter writer, string deserializeMethod)
        {
            writer.Line($"return {deserializeMethod}({typeof(XElement)}.{nameof(XElement.Load)}(data.ToStream()), options);");
        }

        private static void WriteJsonInterfaceBody(CodeWriter writer, string deserializeMethod)
        {
            writer.Line($"using var doc = {typeof(JsonDocument)}.{nameof(JsonDocument.Parse)}(data);");
            writer.Line($"return {deserializeMethod}(doc.RootElement, options);");
        }

        private static void WriteJsonDeserialize(CodeWriter writer, TypeDeclarationOptions declaration, JsonObjectSerialization serialization, bool hasXml)
        {
            string deserializeMethod = $"Deserialize{declaration.Name}";

            using (writer.Scope($"object {typeof(IModelSerializable)}.{nameof(IModelSerializable.Deserialize)}({typeof(BinaryData)} data, {typeof(ModelSerializerOptions)} options)"))
            {
                if (hasXml)
                {
                    using (writer.Scope($"if (data.ToMemory().Span.StartsWith(\"{{\"u8))"))
                    {
                        WriteJsonInterfaceBody(writer, deserializeMethod);
                    }
                    using (writer.Scope($"else"))
                    {
                        WriteXmlInterfaceBody(writer, deserializeMethod);
                    }
                }
                else
                {
                    WriteJsonInterfaceBody(writer, deserializeMethod);
                }
            }
            writer.Line();

            using (writer.Scope($"internal static {serialization.Type} {deserializeMethod}({typeof(JsonElement)} element, {typeof(ModelSerializerOptions)} options = default)"))
            {
                writer.Line($"options ??= {typeof(ModelSerializerOptions)}.{nameof(ModelSerializerOptions.AzureServiceDefault)};");

                if (!serialization.Type.IsValueType) // only return null for reference type (e.g. no enum)
                {
                    using (writer.Scope($"if (element.{nameof(JsonElement.ValueKind)} == {typeof(JsonValueKind)}.Null)"))
                    {
                        writer.Line($"return null;");
                    }
                }

                var discriminator = serialization.Discriminator;

                if (discriminator is not null && discriminator.HasDescendants)
                {
                    using (writer.Scope($"if (element.TryGetProperty({discriminator.SerializedName:L}, out {typeof(JsonElement)} discriminator))"))
                    {
                        writer.Line($"switch (discriminator.GetString())");
                        using (writer.Scope())
                        {
                            foreach (var implementation in discriminator.Implementations)
                            {
                                var implementationFormattable = JsonCodeWriterExtensions.GetDeserializeImplementationFormattable(implementation.Type.Implementation, $"element", JsonSerializationOptions.None);
                                writer.Line($"case {implementation.Key:L}: return {implementationFormattable};");
                            }
                        }
                    }
                }

                if (discriminator is not null && !serialization.Type.HasParent && !serialization.Type.Equals(discriminator.DefaultObjectType.Type))
                {
                    writer.Line($"return {JsonCodeWriterExtensions.GetDeserializeImplementationFormattable(discriminator.DefaultObjectType.Type.Implementation, $"element", JsonSerializationOptions.None)};");
                }
                else
                {
                    writer.WriteObjectInitialization(serialization);
                }
            }
            writer.Line();

            using (writer.Scope($"object {typeof(IJsonModelSerializable)}.{nameof(IJsonModelSerializable.Deserialize)}(ref {typeof(Utf8JsonReader)} reader, {typeof(ModelSerializerOptions)} options)"))
            {
                writer.Line($"using var doc = {typeof(JsonDocument)}.{nameof(JsonDocument.ParseValue)}(ref reader);");
                writer.Line($"return {deserializeMethod}(doc.RootElement, options);");
            }
            writer.Line();
        }

        private static void WriteJsonSerialize(CodeWriter writer, JsonObjectSerialization jsonSerialization)
        {
            writer.Line($"void {typeof(IUtf8JsonSerializable)}.{nameof(IUtf8JsonSerializable.Write)}({typeof(Utf8JsonWriter)} writer) => (({typeof(IJsonModelSerializable)})this).Serialize(writer, {typeof(ModelSerializerOptions)}.{nameof(ModelSerializerOptions.AzureServiceDefault)});");
            writer.Line();

            using (writer.Scope($"void {typeof(IJsonModelSerializable)}.{nameof(IJsonModelSerializable.Serialize)}({typeof(Utf8JsonWriter)} writer, {typeof(ModelSerializerOptions)} options)"))
            {
                writer.ToSerializeCall(jsonSerialization);
            }
            writer.Line();
        }

        private static void WriteJsonToRequestContentMethod(CodeWriter writer, ObjectType objectType)
        {
            var contentVariable = new CodeWriterDeclaration("content");
            writer
                .Line($"var {contentVariable:D} = new {typeof(Utf8JsonRequestContent)}();")
                .Line($"{contentVariable:I}.{nameof(Utf8JsonRequestContent.JsonWriter)}.{nameof(Utf8JsonWriterExtensions.WriteObjectValue)}(this);")
                .Line($"return {contentVariable:I};");
        }

        private static void WriteJsonFromResponseMethod(CodeWriter writer, ObjectType objectType)
        {
            var documentVariable = new CodeWriterDeclaration("document");
            writer
                .Line($"using var {documentVariable:D} = {typeof(JsonDocument)}.{nameof(JsonDocument.Parse)}(response.{nameof(Response.Content)});")
                .Line($"return Deserialize{objectType.Declaration.Name}({documentVariable:I}.{nameof(JsonDocument.RootElement)});");
        }

        public static void WriteEnumSerialization(CodeWriter writer, EnumType enumType)
        {
            using (writer.Namespace(enumType.Declaration.Namespace))
            {
                string declaredTypeName = enumType.Declaration.Name;

                var isString = enumType.ValueType.FrameworkType == typeof(string);

                using (writer.Scope($"internal static partial class {declaredTypeName}Extensions"))
                {
                    if (!enumType.IsIntValueType)
                    {
                        WriteEnumSerializationMethod(writer, enumType, declaredTypeName);
                    }

                    WriteEnumDeserializationMethod(writer, enumType, declaredTypeName, isString);
                }
            }
        }

        private static void WriteEnumSerializationMethod(CodeWriter writer, EnumType enumType, string declaredTypeName)
        {
            using (writer.Scope($"public static {enumType.ValueType} {enumType.SerializationMethodName}(this {declaredTypeName} value) => value switch", end: "};"))
            {
                foreach (EnumTypeValue value in enumType.Values)
                {
                    writer.Line($"{declaredTypeName}.{value.Declaration.Name} => {value.Value.Value:L},");
                }

                writer.Line($"_ => throw new {typeof(ArgumentOutOfRangeException)}(nameof(value), value, \"Unknown {declaredTypeName} value.\")");
            }
            writer.Line();
        }

        private static void WriteEnumDeserializationMethod(CodeWriter writer, EnumType schema, string declaredTypeName, bool isString)
        {
            using (writer.Scope($"public static {declaredTypeName} To{declaredTypeName}(this {schema.ValueType} value)"))
            {
                if (isString)
                {
                    foreach (EnumTypeValue value in schema.Values)
                    {
                        if (value.Value.Value is string strValue && strValue.All(char.IsAscii))
                        {
                            writer.Append($"if ({typeof(StringComparer)}.{nameof(StringComparer.OrdinalIgnoreCase)}.{nameof(StringComparer.Equals)}(value, {strValue:L}))");
                        }
                        else
                        {
                            writer.Append($"if ({schema.ValueType}.Equals(value, {value.Value.Value:L}");
                            writer.Append($", {typeof(StringComparison)}.InvariantCultureIgnoreCase))");
                        }
                        writer.Line($" return {declaredTypeName}.{value.Declaration.Name};");
                    }
                }
                else// int, and float
                {
                    foreach (EnumTypeValue value in schema.Values)
                    {
                        writer.Line($"if (value == {value.Value.Value:L}) return {declaredTypeName}.{value.Declaration.Name};");
                    }
                }

                writer.Line($"throw new {typeof(ArgumentOutOfRangeException)}(nameof(value), value, \"Unknown {declaredTypeName} value.\");");
            }
            writer.Line();
        }
    }
}
