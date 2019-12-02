// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Text.Json;
using AutoRest.CSharp.V3.ClientModel;
using AutoRest.CSharp.V3.Pipeline;
using AutoRest.CSharp.V3.Plugins;

namespace AutoRest.CSharp.V3.CodeGen
{
    internal class SerializationWriter : StringWriter
    {
        private readonly TypeFactory _typeFactory;

        public SerializationWriter(TypeFactory typeFactory)
        {
            _typeFactory = typeFactory;
        }

        public void WriteSerialization(ClientModel.ClientModel schema)
        {
            switch (schema)
            {
                case ClientObject objectSchema:
                    WriteObjectSerialization(objectSchema);
                    break;
                case ClientEnum sealedChoiceSchema when !sealedChoiceSchema.IsStringBased:
                    WriteSealedChoiceSerialization(sealedChoiceSchema);
                    break;
            }
        }

        private void WriteProperty(ClientTypeReference type, string name, string serializedName)
        {
            if (type is CollectionTypeReference array)
            {
                Line($"writer.WriteStartArray(\"{serializedName}\");");
                using (ForEach($"var item in {name}"))
                {
                    this.ToSerializeCall(array.ItemType, _typeFactory, "item", serializedName, true);
                }
                Line("writer.WriteEndArray();");
                return;
            }

            if (type is DictionaryTypeReference dictionary)
            {
                Line($"writer.WriteStartObject(\"{serializedName}\");");
                using (ForEach($"var item in {name}"))
                {
                    this.ToSerializeCall(dictionary.ValueType, _typeFactory, "item.Value", "item.Key", false, false);
                }
                Line("writer.WriteEndObject();");
                return;
            }

            this.ToSerializeCall(type, _typeFactory, name, serializedName);
        }

        private void ReadProperty(ClientTypeReference type, string name)
        {
            if (type is CollectionTypeReference array)
            {
                using (ForEach("var item in property.Value.EnumerateArray()"))
                {
                    var elementType = _typeFactory.CreateType(array.ItemType);
                    var elementTypeName = elementType.Name;
                    var elementTypeText = Type(elementType);
                    Append($"result.{name}.Add(");
                    this.ToDeserializeCall(array.ItemType, _typeFactory, "item", elementTypeText, elementTypeName);
                    Line(");");
                }
                return;
            }
            if (type is DictionaryTypeReference dictionary)
            {
                using (ForEach("var item in property.Value.EnumerateObject()"))
                {
                    var elementType = _typeFactory.CreateType(dictionary.ValueType);
                    var elementTypeName = elementType.Name;
                    var elementTypeText = Type(elementType);
                    Append($"result.{name}.Add(item.Name, ");
                    this.ToDeserializeCall(dictionary.ValueType, _typeFactory, "item.Value", elementTypeText, elementTypeName);
                    Line(");");
                }
                return;
            }

            var t = Type(_typeFactory.CreateType(type));
            Append($"result.{name} = ");
            this.ToDeserializeCall(type, _typeFactory, "property.Value", t, t);
            Line(";");
        }

        //TODO: This is currently input schemas only. Does not handle output-style schemas.
        private void WriteObjectSerialization(ClientObject model)
        {
            Header();
            using var _ = UsingStatements();
            var cs = _typeFactory.CreateType(model);
            using (Namespace(cs.Namespace))
            {
                using (Class(null, "partial", model.CSharpName()))
                {
                    using (Method("internal", "void", "Serialize", Pair(typeof(Utf8JsonWriter), "writer")))
                    {
                         Line("writer.WriteStartObject();");

                        var propertyInfos = model.Properties;
                        foreach (var property in propertyInfos)
                        {
                            using (property.Type.IsNullable ? If($"{property.Name} != null") : new DisposeAction())
                            {
                                WriteProperty(property.Type, property.Name, property.SerializedName);
                            }
                        }

                        Line("writer.WriteEndObject();");
                    }

                    var typeText = Type(cs);
                    using (Method("internal static", typeText, "Deserialize", Pair(typeof(JsonElement), "element")))
                    {
                        Line($"var result = new {typeText}();");
                        using (ForEach("var property in element.EnumerateObject()"))
                        {
                            foreach (var property in model.Properties)
                            {
                                using (If($"property.NameEquals(\"{property.SerializedName}\")"))
                                {
                                    ReadProperty(property.Type, property.Name);
                                    Line("continue;");
                                }
                            }
                        }
                        Line("return result;");
                    }
                }
            }
        }

        private void WriteSealedChoiceSerialization(ClientEnum schema)
        {
            Header();
            using var _ = UsingStatements();
            var cs = _typeFactory.CreateType(schema);
            using (Namespace(cs.Namespace))
            {
                using (Class("internal", "static", $"{schema.CSharpName()}Extensions"))
                {
                    var stringText = Type(typeof(string));
                    var csTypeText = Type(cs);
                    var nameMap = schema.Values.Select(c => (Choice: $"{csTypeText}.{c.Name}", Serial: $"\"{c.Value.Value}\"")).ToArray();
                    var exceptionEntry = $"_ => throw new {Type(typeof(ArgumentOutOfRangeException))}(nameof(value), value, \"Unknown {csTypeText} value.\")";

                    var toSerialString = String.Join(Environment.NewLine, nameMap
                        .Select(nm => $"{nm.Choice} => {nm.Serial},")
                        .Append(exceptionEntry)
                        .Append("}")
                        .Prepend("{")
                        .Prepend("value switch"));
                    MethodExpression("public static", stringText, "ToSerialString", new[] { Pair($"this {csTypeText}", "value") }, toSerialString);
                    Line();

                    var toChoiceType = String.Join(Environment.NewLine, nameMap
                        .Select(nm => $"{nm.Serial} => {nm.Choice},")
                        .Append(exceptionEntry)
                        .Append("}")
                        .Prepend("{")
                        .Prepend("value switch"));
                    MethodExpression("public static", csTypeText, $"To{schema.CSharpName()}", new[] { Pair($"this {stringText}", "value") }, toChoiceType);
                }
            }
        }
    }
}
