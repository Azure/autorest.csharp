// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.ClientModel.Primitives;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Types;
using Azure.Core;

namespace AutoRest.CSharp.Generation.Writers
{
    internal class SerializationWriter
    {
        public void WriteSerialization(CodeWriter writer, TypeProvider schema)
        {
            switch (schema)
            {
                case SerializableObjectType obj:
                    if (obj.IncludeSerializer || obj.IncludeDeserializer)
                    {
                        WriteObjectSerialization(writer, obj);
                    }
                    break;
                case EnumType { IsExtensible: false } sealedChoiceSchema:
                    WriteEnumSerialization(writer, sealedChoiceSchema);
                    break;
            }
        }

        private void WriteObjectSerialization(CodeWriter writer, SerializableObjectType model)
        {
            var declaration = model.Declaration;
            var serialization = model.Serialization;

            if (serialization.Json == null && serialization.Xml == null)
            {
                return;
            }
            using (writer.Namespace(declaration.Namespace))
            {
                if (serialization.Json is { IncludeConverter: true })
                {
                    writer.Append($"[{typeof(JsonConverter)}(typeof({declaration.Name}Converter))]");
                }
                // write the serialization proxy attribute if the model has one
                if (serialization.PersistableModelProxyType is { } proxyType)
                {
                    writer.Append($"[{typeof(PersistableModelProxyAttribute)}(typeof({proxyType}))]");
                }

                writer.Append($"{declaration.Accessibility} partial {(model.IsStruct ? "struct" : "class")} {declaration.Name}")
                    .AppendRawIf(" : ", model.IncludeSerializer);
                foreach (var i in serialization.Interfaces)
                {
                    writer.Append($"{i}, ");
                }

                writer.RemoveTrailingComma();

                writer.Line();
                using (writer.Scope())
                {
                    foreach (var method in SerializationMethodsBuilder.BuildSerializationMethods(model, serialization))
                    {
                        writer.WriteMethod(method);
                    }

                    foreach (var method in model.Methods)
                    {
                        writer.WriteXmlDocumentationSummary(method.Signature.Description);
                        writer.WriteXmlDocumentationParameters(method.Signature.Parameters);
                        writer.WriteMethod(method);
                    }

                    if (serialization.Json is { IncludeConverter: true } json)
                    {
                        WriteCustomJsonConverter(writer, declaration, json.Type, model.IncludeSerializer, model.IncludeDeserializer);
                    }
                }
            }
        }

        private static void WriteCustomJsonConverter(CodeWriter writer, TypeDeclarationOptions declaration, CSharpType type, bool includeSerializer, bool includeDeserializer)
        {
            writer.Append($"internal partial class {declaration.Name}Converter : {typeof(JsonConverter)}<{type}>");
            using (writer.Scope())
            {
                using (writer.Scope($"public override void Write({typeof(Utf8JsonWriter)} writer, {type} model, {typeof(JsonSerializerOptions)} options)"))
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
