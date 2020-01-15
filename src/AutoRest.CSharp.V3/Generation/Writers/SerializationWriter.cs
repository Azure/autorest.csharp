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
        private readonly TypeFactory _typeFactory;

        public SerializationWriter(TypeFactory typeFactory)
        {
            _typeFactory = typeFactory;
        }

        public void WriteSerialization(CodeWriter writer, ISchemaType schema)
        {
            switch (schema)
            {
                case ObjectType objectSchema:
                    WriteObjectSerialization(writer, objectSchema);
                    break;
                case EnumType sealedChoiceSchema when !sealedChoiceSchema.IsStringBased:
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

            var cs = _typeFactory.CreateType(model);
            using (writer.Namespace(cs.Namespace))
            {
                writer.Append($"public partial class {model.Name}: {typeof(IUtf8JsonSerializable)}");

                if (model.Serializations.OfType<XmlElementSerialization>().Any())
                {
                    writer.Append($", {typeof(IXmlSerializable)}");
                }

                using (writer.Scope())
                {
                    foreach (var serialization in model.Serializations)
                    {
                        switch (serialization)
                        {
                            case JsonSerialization jsonSerialization:
                                WriteJsonSerialize(writer, jsonSerialization);
                                WriteJsonDeserialize(writer, model, jsonSerialization);
                                break;
                            case XmlElementSerialization xmlSerialization:
                                WriteXmlSerialize(writer, model, xmlSerialization);
                                WriteXmlDeserialize(writer, model, xmlSerialization);
                                break;
                            default:
                                throw new NotImplementedException(serialization.ToString());
                        }
                    }
                }
            }
        }

        private void WriteXmlSerialize(CodeWriter writer, ObjectType model, XmlElementSerialization serialization)
        {
            const string namehint = "nameHint";
            writer.Append($"void {typeof(IXmlSerializable)}.{nameof(IXmlSerializable.Write)}({typeof(XmlWriter)} writer, {typeof(string)} {namehint})");
            using (writer.Scope())
            {
                writer.ToSerializeCall(
                    serialization,
                    _typeFactory,
                    w => w.AppendRaw("this"),
                    null,
                    w => w.AppendRaw(namehint));
            }
        }

        private void WriteXmlDeserialize(CodeWriter writer, ObjectType model, XmlElementSerialization serialization)
        {
            var cs = _typeFactory.CreateType(model);
            var typeText = writer.Type(cs);
            using (writer.Method("internal static", typeText, "Deserialize"+cs.Name, writer.Pair(typeof(XElement), "element")))
            {
                var resultVariable = "result";
                writer.ToDeserializeCall(serialization,
                    _typeFactory,
                    w=> w.AppendRaw("element"), ref resultVariable, true);
                writer.Line($"return {resultVariable};");
            }
        }

        private void WriteJsonDeserialize(CodeWriter writer, ObjectType model, JsonSerialization jsonSerialization)
        {
            var cs = _typeFactory.CreateType(model);
            var typeText = writer.Type(cs);
            using (writer.Method("internal static", typeText, "Deserialize"+cs.Name, writer.Pair(typeof(JsonElement), "element")))
            {
                if (model.Discriminator?.HasDescendants == true)
                {
                    using (writer.If($"element.TryGetProperty(\"{model.Discriminator.SerializedName}\", out {writer.Type(typeof(JsonElement))} discriminator)"))
                    {
                        writer.Line($"switch (discriminator.GetString())");
                        using (writer.Scope())
                        {
                            foreach (var implementation in model.Discriminator.Implementations)
                            {
                                writer
                                    .Append($"case {implementation.Key:L}: return ")
                                    .ToDeserializeCall(implementation.Type, _typeFactory, w => w.Append($"element"));
                                writer.Line($";");
                            }
                        }
                    }
                }

                var resultVariable = "result";
                writer.ToDeserializeCall(jsonSerialization, _typeFactory, w=>w.AppendRaw("element"), ref resultVariable);
                writer.Line($"return {resultVariable};");
            }
        }

        private void WriteJsonSerialize(CodeWriter writer, JsonSerialization jsonSerialization)
        {
            writer.Append($"void {typeof(IUtf8JsonSerializable)}.{nameof(IUtf8JsonSerializable.Write)}({typeof(Utf8JsonWriter)} writer)");
            using (writer.Scope())
            {
                writer.ToSerializeCall(jsonSerialization, _typeFactory, w => w.AppendRaw("this"));
            }
        }

        private void WriteSealedChoiceSerialization(CodeWriter writer, EnumType schema)
        {
            var cs = _typeFactory.CreateType(schema);
            using (writer.Namespace(cs.Namespace))
            {
                using (writer.Scope($"internal static class {schema.Name}Extensions"))
                {
                    using (writer.Scope($"public static string ToSerialString(this {cs} value) => value switch", end: "};"))
                    {
                        foreach (EnumTypeValue value in schema.Values)
                        {
                            writer.Line($"{cs}.{value.Name} => {value.Value.Value:L},");
                        }

                        writer.Line($"_ => throw new {typeof(ArgumentOutOfRangeException)}(nameof(value), value, \"Unknown {cs.Name} value.\")");
                    }
                    writer.Line();

                    using (writer.Scope($"public static {cs} To{schema.Name}(this string value) => value switch", end: "};"))
                    {
                        foreach (EnumTypeValue value in schema.Values)
                        {
                            writer.Line($"{value.Value.Value:L} => {cs}.{value.Name},");
                        }

                        writer.Line($"_ => throw new {typeof(ArgumentOutOfRangeException)}(nameof(value), value, \"Unknown {cs.Name} value.\")");
                    }
                }
            }
        }
    }
}
