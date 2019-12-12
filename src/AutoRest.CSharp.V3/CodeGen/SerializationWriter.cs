// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Text.Json;
using AutoRest.CSharp.V3.ClientModels;
using AutoRest.CSharp.V3.Pipeline;
using AutoRest.CSharp.V3.Plugins;

namespace AutoRest.CSharp.V3.CodeGen
{
    internal class SerializationWriter
    {
        private readonly TypeFactory _typeFactory;

        public SerializationWriter(TypeFactory typeFactory)
        {
            _typeFactory = typeFactory;
        }

        public void WriteSerialization(CodeWriter writer, ClientModel schema)
        {
            switch (schema)
            {
                case ClientObject objectSchema:
                    WriteObjectSerialization(writer, objectSchema);
                    break;
                case ClientEnum sealedChoiceSchema when !sealedChoiceSchema.IsStringBased:
                    WriteSealedChoiceSerialization(writer, sealedChoiceSchema);
                    break;
            }
        }

        private void WriteProperty(CodeWriter writer, ClientTypeReference type, SerializationFormat format, string name, string serializedName)
        {
            if (type is CollectionTypeReference array)
            {
                writer.Line($"writer.WriteStartArray(\"{serializedName}\");");
                using (writer.ForEach($"var item in {name}"))
                {
                    writer.ToSerializeCall(array.ItemType, format, _typeFactory, "item", serializedName, false);
                }
                writer.Line("writer.WriteEndArray();");
                return;
            }

            if (type is DictionaryTypeReference dictionary)
            {
                writer.Line($"writer.WriteStartObject(\"{serializedName}\");");
                using (writer.ForEach($"var item in {name}"))
                {
                    writer.ToSerializeCall(dictionary.ValueType, format, _typeFactory, "item.Value", "item.Key", true, false);
                }
                writer.Line("writer.WriteEndObject();");
                return;
            }

            writer.ToSerializeCall(type, format, _typeFactory, name, serializedName);
        }

        private void ReadProperty(CodeWriter writer, ClientTypeReference type, string name)
        {
            if (type is CollectionTypeReference array)
            {
                using (writer.ForEach("var item in property.Value.EnumerateArray()"))
                {
                    var elementType = _typeFactory.CreateType(array.ItemType);
                    var elementTypeName = elementType.Name;
                    var elementTypeText = writer.Type(elementType);
                    writer.Append($"result.{name}.Add(");
                    writer.ToDeserializeCall(array.ItemType, _typeFactory, "item", elementTypeText, elementTypeName);
                    writer.Line(");");
                }
                return;
            }
            if (type is DictionaryTypeReference dictionary)
            {
                using (writer.ForEach("var item in property.Value.EnumerateObject()"))
                {
                    var elementType = _typeFactory.CreateType(dictionary.ValueType);
                    var elementTypeName = elementType.Name;
                    var elementTypeText = writer.Type(elementType);
                    writer.Append($"result.{name}.Add(item.Name, ");
                    writer.ToDeserializeCall(dictionary.ValueType, _typeFactory, "item.Value", elementTypeText, elementTypeName);
                    writer.Line(");");
                }
                return;
            }

            var t = writer.Type(_typeFactory.CreateType(type));
            writer.Append($"result.{name} = ");
            writer.ToDeserializeCall(type, _typeFactory, "property.Value", t, t);
            writer.Line(";");
        }

        //TODO: This is currently input schemas only. Does not handle output-style schemas.
        private void WriteObjectSerialization(CodeWriter writer, ClientObject model)
        {
            var cs = _typeFactory.CreateType(model);
            using (writer.Namespace(cs.Namespace))
            {
                using (writer.Class(null, "partial", model.CSharpName()))
                {
                    using (writer.Method("internal", "void", "Serialize", writer.Pair(typeof(Utf8JsonWriter), "writer")))
                    {
                        writer.Line("writer.WriteStartObject();");

                        var propertyInfos = model.Properties;
                        foreach (var property in propertyInfos)
                        {
                            using (property.Type.IsNullable ? writer.If($"{property.Name} != null") : default)
                            {
                                WriteProperty(writer, property.Type, property.Format, property.Name, property.SerializedName);
                            }
                        }

                        writer.Line("writer.WriteEndObject();");
                    }

                    var typeText = writer.Type(cs);
                    using (writer.Method("internal static", typeText, "Deserialize", writer.Pair(typeof(JsonElement), "element")))
                    {
                        writer.Line($"var result = new {typeText}();");
                        using (writer.ForEach("var property in element.EnumerateObject()"))
                        {
                            foreach (var property in model.Properties)
                            {
                                using (writer.If($"property.NameEquals(\"{property.SerializedName}\")"))
                                {
                                    ReadProperty(writer, property.Type, property.Name);
                                    writer.Line("continue;");
                                }
                            }
                        }
                        writer.Line("return result;");
                    }
                }
            }
        }

        private void WriteSealedChoiceSerialization(CodeWriter writer, ClientEnum schema)
        {
            var cs = _typeFactory.CreateType(schema);
            using (writer.Namespace(cs.Namespace))
            {
                using (writer.Class("internal", "static", $"{schema.CSharpName()}Extensions"))
                {
                    var stringText = writer.Type(typeof(string));
                    var csTypeText = writer.Type(cs);
                    var nameMap = schema.Values.Select(c => (Choice: $"{csTypeText}.{c.Name}", Serial: $"\"{c.Value.Value}\"")).ToArray();
                    var exceptionEntry = $"_ => throw new {writer.Type(typeof(ArgumentOutOfRangeException))}(nameof(value), value, \"Unknown {csTypeText} value.\")";

                    var toSerialString = String.Join(Environment.NewLine, nameMap
                        .Select(nm => $"{nm.Choice} => {nm.Serial},")
                        .Append(exceptionEntry)
                        .Append("}")
                        .Prepend("{")
                        .Prepend("value switch"));
                    writer.MethodExpression("public static", stringText, "ToSerialString", new[] { writer.Pair($"this {csTypeText}", "value") }, toSerialString);
                    writer.Line();

                    var toChoiceType = String.Join(Environment.NewLine, nameMap
                        .Select(nm => $"{nm.Serial} => {nm.Choice},")
                        .Append(exceptionEntry)
                        .Append("}")
                        .Prepend("{")
                        .Prepend("value switch"));
                    writer.MethodExpression("public static", csTypeText, $"To{schema.CSharpName()}", new[] { writer.Pair($"this {stringText}", "value") }, toChoiceType);
                }
            }
        }
    }
}
