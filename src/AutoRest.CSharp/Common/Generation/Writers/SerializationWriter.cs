// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.ClientModel.Primitives;
using System.Linq;
using System.Text.Json.Serialization;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Serialization.Bicep;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Output.Models.Serialization.Xml;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Common.Output.Builders;

namespace AutoRest.CSharp.Generation.Writers
{
    internal class SerializationWriter
    {
        public void WriteSerialization(CodeWriter writer, TypeProvider schema)
        {
            switch (schema)
            {
                // The corresponding ResoruceData does not exist for PartialResource, so we do not need to generate serialization methods for it.
                case PartialResource:
                    break;
                case Resource resource:
                    WriteResourceJsonSerialization(writer, resource);
                    break;
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

        private void WriteResourceJsonSerialization(CodeWriter writer, Resource resource)
        {
            var declaration = resource.Declaration;

            using (writer.Namespace(declaration.Namespace))
            {
                var resourceDataType = resource.ResourceData.Type;
                writer.Append($"{declaration.Accessibility} partial class {declaration.Name} : IJsonModel<{resourceDataType}>");

                using (writer.Scope())
                {
                    foreach (var method in JsonSerializationMethodsBuilder.BuildResourceJsonSerializationMethods(resource))
                    {
                        writer.WriteMethod(method);
                    }
                }
            }
        }

        private void WriteObjectSerialization(CodeWriter writer, SerializableObjectType model)
        {
            var declaration = model.Declaration;
            var serialization = model.Serialization;

            if (!serialization.HasSerializations)
            {
                return;
            }
            using (writer.Namespace(declaration.Namespace))
            {
                var converter = serialization.Json?.JsonConverter;
                if (converter is not null)
                {
                    // this is an inner class therefore we directly write its name here instead of writing its type
                    writer.Append($"[{typeof(JsonConverter)}(typeof({converter.Declaration.Name}))]");
                }
                // write the serialization proxy attribute if the model has one
                if (serialization.PersistableModelProxyType is { } proxyType)
                {
                    writer.Append($"[{typeof(PersistableModelProxyAttribute)}(typeof({proxyType}))]");
                }

                writer.Append($"{declaration.Accessibility} partial {(model.IsStruct ? "struct" : "class")} {declaration.Name}")
                    .AppendRawIf(" : ", serialization.Interfaces?.Any() ?? false);

                if (serialization.Interfaces is not null)
                {
                    foreach (var i in serialization.Interfaces)
                    {
                        writer.Append($"{i}, ");
                    }
                }

                writer.RemoveTrailingComma();

                writer.Line();
                using (writer.Scope())
                {
                    foreach (var method in model.Methods)
                    {
                        writer.WriteMethodDocumentation(method.Signature);
                        writer.WriteMethod(method);
                    }

                    if (converter is not null)
                    {
                        WriteCustomJsonConverter(writer, converter);
                    }
                }
            }
        }

        private static void WriteCustomJsonConverter(CodeWriter writer, JsonConverterProvider converter)
        {
            writer.Append($"{converter.Declaration.Accessibility} partial class {converter.Declaration.Name} : {converter.Inherits!}");
            using (writer.Scope())
            {
                foreach (var method in converter.Methods)
                {
                    writer.WriteMethod(method);
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
