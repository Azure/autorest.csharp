// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;
using System.Xml.Linq;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;
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
        public void WriteSerialization(CodeWriter writer, TypeProvider schema)
        {
            switch (schema)
            {
                case SerializableObjectType objectSchema:
                    if (objectSchema.IncludeSerializer || objectSchema.IncludeDeserializer)
                    {
                        WriteObjectSerialization(writer, objectSchema);
                    }
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
                //[TODO] Azure.Core is not needed to compile, but previous version of writer has been adding it.
                writer.UseNamespace("Azure.Core");

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

                    foreach (var method in model.Methods)
                    {
                        writer.WriteXmlDocumentationSummary(method.Signature.Description);
                        writer.WriteXmlDocumentationParameters(method.Signature.Parameters);
                        writer.WriteMethod(method);
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

        private static void WriteXmlSerialize(CodeWriter writer, XmlObjectSerialization serialization)
        {
            writer.WriteMethod(XmlSerializationMethodsBuilder.BuildXmlSerializableWrite(serialization));
        }

        private static void WriteXmlDeserialize(CodeWriter writer, TypeDeclarationOptions declaration, XmlObjectSerialization serialization)
        {
            writer.WriteMethod(XmlSerializationMethodsBuilder.BuildDeserialize(declaration, serialization));
        }

        private static void WriteJsonDeserialize(CodeWriter writer, TypeDeclarationOptions declaration, JsonObjectSerialization serialization)
        {
            writer.WriteMethod(JsonSerializationMethodsBuilder.BuildDeserialize(declaration, serialization));
        }

        private static void WriteJsonSerialize(CodeWriter writer, JsonObjectSerialization jsonSerialization)
        {
            writer.WriteMethod(JsonSerializationMethodsBuilder.BuildUtf8JsonSerializableWrite(jsonSerialization));
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
