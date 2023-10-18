// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Output.Models.Serialization.Xml;
using AutoRest.CSharp.Output.Models.Types;
using Azure.Core;
using Azure.Core.Serialization;

namespace AutoRest.CSharp.Generation.Writers
{
    internal class SerializationWriter
    {
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
        {
            var declaration = model.Declaration;
            var jsonSerialization = model.JsonSerialization;
            var xmlSerialization = model.XmlSerialization;
            var isStruct = model.IsStruct;
            var hasJson = jsonSerialization != null;
            var hasXml = xmlSerialization != null;

            //var typeOfT = model.IsUnknownDerivedType ? model.Inherits!.Implementation!.Type : model.Type;
            var typeOfT = model.Type;
            CSharpType iModelSerializableType = new CSharpType(typeof(IModelSerializable<>), typeOfT);
            CSharpType iModelJsonSerializableType = new CSharpType(typeof(IModelJsonSerializable<>), typeOfT);

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
                // TODO -- write the serialization proxy attribute here

                writer.Append($"{declaration.Accessibility} partial {(isStruct ? "struct" : "class")} {declaration.Name}");

                writer
                    .AppendIf($": ", hasJson || hasXml)
                    .AppendIf($"{Configuration.ApiTypes.IUtf8JsonSerializableType}, {iModelJsonSerializableType}, ", hasJson)
                    .AppendIf($"{typeof(IModelJsonSerializable<object>)}, ", hasJson && model.IsStruct)
                    .AppendIf($"{typeof(IXmlSerializable)}, ", hasXml)
                    //.AppendIf($"{iModelSerializableType}, ", hasXml) // TODO
                    .RemoveTrailingComma();

                writer.Line();
                using (writer.Scope())
                {
                    if (xmlSerialization != null)
                    {
                        WriteXmlSerialize(writer, declaration, xmlSerialization);
                    }

                    if (jsonSerialization != null)
                    {
                        WriteJsonSerialize(writer, model, jsonSerialization);
                    }

                    foreach (var method in model.Methods)
                    {
                        writer.WriteXmlDocumentationSummary(method.Signature.Description);
                        writer.WriteXmlDocumentationParameters(method.Signature.Parameters);
                        writer.WriteMethod(method);
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

        private static void WriteXmlSerialize(CodeWriter writer, TypeDeclarationOptions declaration, XmlObjectSerialization serialization)
        {
            writer.WriteMethod(XmlSerializationMethodsBuilder.BuildXmlSerializableWrite(serialization));
            writer.WriteMethod(XmlSerializationMethodsBuilder.BuildDeserialize(declaration, serialization));
        }

        private static void WriteJsonSerialize(CodeWriter writer, SerializableObjectType model, JsonObjectSerialization jsonSerialization)
        {
            // the methods that implement the interface IModelJsonSerializable<T> (do not include inherited methods)
            foreach (var method in JsonSerializationMethodsBuilder.BuildModelJsonSerializableMethods(model, jsonSerialization))
            {
                writer.WriteMethod(method);
            }

            // the deserialize static method
            if (JsonSerializationMethodsBuilder.BuildDeserialize(model.Declaration, jsonSerialization, model.GetExistingType()) is { } deserialize)
            {
                writer.WriteMethod(deserialize);
            }
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
