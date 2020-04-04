// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using AutoRest.CSharp.V3.Generation.Types;
using AutoRest.CSharp.V3.Output.Models.Serialization.Json;
using AutoRest.CSharp.V3.Output.Models.Serialization.Xml;
using AutoRest.CSharp.V3.Output.Models.Types;
using Azure.Core;

namespace AutoRest.CSharp.V3.Generation.Writers
{
    internal class SerializationWriter
    {
        public void WriteSerialization(CodeWriter writer, ISchemaType schema)
        {
            switch (schema)
            {
                case ObjectType objectSchema:
                    WriteObjectSerialization(writer, objectSchema);
                    break;
                case EnumType sealedChoiceSchema when !sealedChoiceSchema.IsExtendable:
                    WriteSealedChoiceSerialization(writer, sealedChoiceSchema);
                    break;
            }
        }

        private void WriteObjectSerialization(CodeWriter writer, ObjectType model)
        {
            if (!model.Serializations.Any())
            {
                return;
            }

            using (writer.Namespace(model.Declaration.Namespace))
            {
                if (model.IsStruct)
                {
                    writer.Append($"{model.Declaration.Accessibility} partial struct {model.Declaration.Name}");
                }
                else
                {
                    writer.Append($"{model.Declaration.Accessibility} partial class {model.Declaration.Name}");
                }

                if (model.IncludeSerializer)
                {
                    bool hasJson = model.Serializations.OfType<JsonSerialization>().Any();
                    bool hasXml = model.Serializations.OfType<XmlElementSerialization>().Any();
                    if (hasJson || hasXml)
                    {
                        writer.Append($": ");
                    }

                    if (hasJson)
                    {
                        writer.Append($"{typeof(IUtf8JsonSerializable)}");
                        writer.Append($", ");
                    }

                    if (hasXml)
                    {
                        writer.Append($"{typeof(IXmlSerializable)}");
                        writer.Append($", ");
                    }

                    writer.RemoveTrailingComma();
                }

                using (writer.Scope())
                {
                    foreach (var serialization in model.Serializations)
                    {
                        switch (serialization)
                        {
                            case JsonSerialization jsonSerialization:
                                if (model.IncludeSerializer)
                                {
                                    WriteJsonSerialize(writer, jsonSerialization);
                                }

                                if (model.IncludeDeserializer)
                                {
                                    WriteJsonDeserialize(writer, model, jsonSerialization);
                                }

                                break;
                            case XmlElementSerialization xmlSerialization:
                                if (model.IncludeSerializer)
                                {
                                    WriteXmlSerialize(writer, xmlSerialization);
                                }

                                if (model.IncludeDeserializer)
                                {
                                    WriteXmlDeserialize(writer, model, xmlSerialization);
                                }

                                break;
                            default:
                                throw new NotImplementedException(serialization.ToString());
                        }
                    }
                }
            }
        }

        private void WriteXmlSerialize(CodeWriter writer, XmlElementSerialization serialization)
        {
            const string namehint = "nameHint";
            writer.Append($"void {typeof(IXmlSerializable)}.{nameof(IXmlSerializable.Write)}({typeof(XmlWriter)} writer, {typeof(string)} {namehint})");
            using (writer.Scope())
            {
                writer.ToSerializeCall(
                    serialization,
                    w => w.AppendRaw("this"),
                    null,
                    w => w.AppendRaw(namehint));
            }
            writer.Line();
        }

        private void WriteXmlDeserialize(CodeWriter writer, ObjectType model, XmlElementSerialization serialization)
        {
            using (writer.Scope($"internal static {model.Type} Deserialize{model.Declaration.Name}({typeof(XElement)} element)"))
            {
                writer.ToDeserializeCall(
                    serialization,
                    w=> w.AppendRaw("element"),
                    (w, v) => w.Line($"return {v};"),
                    true);
            }
            writer.Line();
        }

        private void WriteJsonDeserialize(CodeWriter writer, ObjectType model, JsonSerialization jsonSerialization)
        {
            using (writer.Scope($"internal static {model.Type} Deserialize{model.Declaration.Name}({typeof(JsonElement)} element)"))
            {
                if (model.Discriminator?.HasDescendants == true)
                {
                    using (writer.Scope($"if (element.TryGetProperty({model.Discriminator.SerializedName:L}, out {typeof(JsonElement)} discriminator))"))
                    {
                        writer.Line($"switch (discriminator.GetString())");
                        using (writer.Scope())
                        {
                            foreach (var implementation in model.Discriminator.Implementations)
                            {
                                writer
                                    .Append($"case {implementation.Key:L}: return ")
                                    .DeserializeImplementation(implementation.Type.Implementation, w => w.Append($"element"));
                                writer.Line($";");
                            }
                        }
                    }
                }

                writer.DeserializeValue(jsonSerialization,
                    w=> w.AppendRaw("element"),
                    (w, v) => w.Line($"return {v};"));
            }
            writer.Line();
        }

        private void WriteJsonSerialize(CodeWriter writer, JsonSerialization jsonSerialization)
        {
            writer.Append($"void {typeof(IUtf8JsonSerializable)}.{nameof(IUtf8JsonSerializable.Write)}({typeof(Utf8JsonWriter)} writer)");
            using (writer.Scope())
            {
                writer.ToSerializeCall(jsonSerialization, w => w.AppendRaw("this"));
            }
            writer.Line();
        }

        private void WriteSealedChoiceSerialization(CodeWriter writer, EnumType schema)
        {
            using (writer.Namespace(schema.Declaration.Namespace))
            {
                string declaredTypeName = schema.Declaration.Name;

                using (writer.Scope($"internal static class {declaredTypeName}Extensions"))
                {
                    using (writer.Scope($"public static {schema.BaseType} ToSerialString(this {declaredTypeName} value) => value switch", end: "};"))
                    {
                        foreach (EnumTypeValue value in schema.Values)
                        {
                            writer.Line($"{declaredTypeName}.{value.Declaration.Name} => {value.Value.Value:L},");
                        }

                        writer.Line($"_ => throw new {typeof(ArgumentOutOfRangeException)}(nameof(value), value, \"Unknown {declaredTypeName} value.\")");
                    }
                    writer.Line();

                    using (writer.Scope($"public static {declaredTypeName} To{declaredTypeName}(this {schema.BaseType} value)"))
                    {
                        foreach (EnumTypeValue value in schema.Values)
                        {
                            writer.Line($"if ({schema.BaseType}.Equals(value, {value.Value.Value:L})) return {declaredTypeName}.{value.Declaration.Name};");
                        }

                        writer.Line($"throw new {typeof(ArgumentOutOfRangeException)}(nameof(value), value, \"Unknown {declaredTypeName} value.\");");
                    }
                    writer.Line();
                }
            }
        }
    }
}
