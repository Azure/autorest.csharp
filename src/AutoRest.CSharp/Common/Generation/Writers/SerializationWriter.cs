// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;
using System.Xml.Linq;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Output.Models.Serialization.Xml;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.Core;

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
            => WriteObjectSerialization(writer, model, model.Declaration, model.JsonSerialization, model.XmlSerialization, model.IsStruct, model.IncludeSerializer, model.IncludeDeserializer);

        private void WriteObjectSerialization(CodeWriter writer, SerializableObjectType model, TypeDeclarationOptions declaration, JsonObjectSerialization? jsonSerialization, XmlObjectSerialization? xmlSerialization, bool isStruct, bool includeSerializer, bool includeDeserializer)
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

                if (includeSerializer)
                {
                    writer
                        .AppendIf($": ", hasJson || hasXml)
                        .AppendIf($"{typeof(IUtf8JsonSerializable)}, ", hasJson)
                        .AppendIf($"{typeof(IXmlSerializable)}, ", hasXml)
                        .RemoveTrailingComma();
                }

                writer.Line();
                using (writer.Scope())
                {
                    if (xmlSerialization != null)
                    {
                        if (includeSerializer)
                        {
                            WriteXmlSerialize(writer, xmlSerialization);
                        }

                        if (includeDeserializer)
                        {
                            WriteXmlDeserialize(writer, declaration, xmlSerialization);
                        }
                    }

                    if (jsonSerialization != null)
                    {
                        if (includeSerializer)
                        {
                            WriteJsonSerialize(writer, jsonSerialization);
                        }

                        if (includeDeserializer)
                        {
                            WriteJsonDeserialize(writer, declaration, jsonSerialization);
                        }
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
                        WriteCustomJsonConverter(writer, declaration, jsonSerialization.Type, includeSerializer, includeDeserializer);
                    }
                }
            }
        }

        private static void WriteCustomJsonConverter(CodeWriter writer, TypeDeclarationOptions declaration, CSharpType type, bool includeSerializer, bool includeDeserializer)
        {
            writer.Append($"internal partial class {declaration.Name}Converter : {typeof(JsonConverter)}<{type}>");
            using (writer.Scope())
            {
                using (writer.Scope($"public override void  Write({typeof(Utf8JsonWriter)} writer, {type} model, {typeof(JsonSerializerOptions)} options)"))
                {
                    if (includeSerializer)
                    {
                        writer.Append($"writer.{nameof(Utf8JsonWriterExtensions.WriteObjectValue)}(model);");
                    }
                    else
                    {
                        writer.Append($"throw new {typeof(NotImplementedException)}();");
                    }
                }

                using (writer.Scope($"public override {type} Read(ref {typeof(Utf8JsonReader)} reader, {typeof(Type)} typeToConvert, {typeof(JsonSerializerOptions)} options)"))
                {
                    if (includeDeserializer)
                    {
                        var document = new CodeWriterDeclaration("document");
                        writer.Line($"using var {document:D} = {typeof(JsonDocument)}.ParseValue(ref reader);");
                        writer.Line($"return Deserialize{declaration.Name}({document}.RootElement);");
                    }
                    else
                    {
                        writer.Append($"throw new {typeof(NotImplementedException)}();");
                    }
                }
            }
        }

        private static void WriteXmlSerialize(CodeWriter writer, XmlElementSerialization serialization)
        {
            const string namehint = "nameHint";
            writer.Append($"void {typeof(IXmlSerializable)}.{nameof(IXmlSerializable.Write)}({typeof(XmlWriter)} writer, {typeof(string)} {namehint})");
            using (writer.Scope())
            {
                writer.ToSerializeCall(serialization, $"this", null, namehint);
            }
            writer.Line();
        }

        private static void WriteXmlDeserialize(CodeWriter writer, TypeDeclarationOptions declaration, XmlObjectSerialization serialization)
        {
            using (writer.Scope($"internal static {serialization.Type} Deserialize{declaration.Name}({typeof(XElement)} element)"))
            {
                writer.ToDeserializeCall(serialization, $"element", v => writer.Line($"return {v};"), true);
            }
            writer.Line();
        }

        private static void WriteJsonDeserialize(CodeWriter writer, TypeDeclarationOptions declaration, JsonObjectSerialization serialization)
        {
            using (writer.Scope($"internal static {serialization.Type} Deserialize{declaration.Name}({typeof(JsonElement)} element)"))
            {
                bool hasDecendants = serialization.Discriminator is null ? false : serialization.Discriminator.HasDescendants;
                bool isThisTheDefaultDerivedType = serialization.Type.Equals(serialization.Discriminator?.DefaultObjectType?.Type);
                if (serialization.Discriminator is not null && hasDecendants)
                {
                    using (writer.Scope($"if (element.TryGetProperty({serialization.Discriminator.SerializedName:L}, out {typeof(JsonElement)} discriminator))"))
                    {
                        writer.Line($"switch (discriminator.GetString())");
                        using (writer.Scope())
                        {
                            foreach (var implementation in serialization.Discriminator.Implementations)
                            {
                                var implementationFormattable = JsonCodeWriterExtensions.GetDeserializeImplementationFormattable(implementation.Type.Implementation, $"element", JsonSerializationOptions.None);
                                writer.Line($"case {implementation.Key:L}: return {implementationFormattable};");
                            }
                        }
                    }
                }

                if (serialization.Discriminator is not null && !isThisTheDefaultDerivedType && !serialization.Type.HasParent)
                {
                    writer.Line($"return {JsonCodeWriterExtensions.GetDeserializeImplementationFormattable(serialization.Discriminator.DefaultObjectType.Type.Implementation, $"element", JsonSerializationOptions.None)};");
                }
                else
                {
                    writer.WriteObjectInitialization(serialization);
                }
            }
            writer.Line();
        }

        private static void WriteJsonSerialize(CodeWriter writer, JsonObjectSerialization jsonSerialization)
        {

            using (writer.Scope($"void {typeof(IUtf8JsonSerializable)}.{nameof(IUtf8JsonSerializable.Write)}({typeof(Utf8JsonWriter)} writer)"))
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

        public static void WriteEnumSerialization(CodeWriter writer, EnumType schema)
        {
            using (writer.Namespace(schema.Declaration.Namespace))
            {
                string declaredTypeName = schema.Declaration.Name;

                var isString = schema.ValueType.FrameworkType == typeof(string);

                using (writer.Scope($"internal static partial class {declaredTypeName}Extensions"))
                {
                    if (!schema.IsIntValueType)
                    {
                        WriteEnumSerializationMethod(writer, schema, declaredTypeName);
                    }

                    WriteEnumDeserializationMethod(writer, schema, declaredTypeName, isString);
                }
            }
        }

        private static void WriteEnumSerializationMethod(CodeWriter writer, EnumType schema, string declaredTypeName)
        {
            using (writer.Scope($"public static {schema.ValueType} ToSerial{schema.ValueType.Name.FirstCharToUpperCase()}(this {declaredTypeName} value) => value switch", end: "};"))
            {
                foreach (EnumTypeValue value in schema.Values)
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
                        writer.Append($"if ({schema.ValueType}.Equals(value, {value.Value.Value:L}");
                        writer.Append($", {typeof(StringComparison)}.InvariantCultureIgnoreCase");
                        writer.Line($")) return {declaredTypeName}.{value.Declaration.Name};");
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
