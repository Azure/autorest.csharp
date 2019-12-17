// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Text.Json;
using AutoRest.CSharp.V3.ClientModels;
using AutoRest.CSharp.V3.Plugins;
using AutoRest.CSharp.V3.Utilities;

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
                    writer.ToSerializeCall(array.ItemType, format, _typeFactory, w => w.Append("item"));
                }
                writer.Line("writer.WriteEndArray();");

                return;
            }

            if (type is DictionaryTypeReference dictionary)
            {
                writer.Line($"writer.WriteStartObject(\"{serializedName}\");");
                using (writer.ForEach($"var item in {name}"))
                {
                    writer.ToSerializeCall(dictionary.ValueType, format, _typeFactory, w => w.Append("item.Value"), w => w.Append("item.Key"));
                }
                writer.Line("writer.WriteEndObject();");

                return;
            }

            writer.ToSerializeCall(type, format, _typeFactory, w => w.Append(name), w => w.Literal(serializedName));
        }

        private void ReadProperty(CodeWriter writer, ClientObjectProperty property)
        {
            var type = property.Type;
            var name = property.Name;
            var format = property.Format;

            CSharpType propertyType = _typeFactory.CreateType(type);

            void WriteInitialization()
            {
                if (propertyType.IsNullable)
                {
                    WriteNullCheck(writer);

                    writer.Append($"result.{name} = new {writer.Type(_typeFactory.CreateConcreteType(property.Type))}()")
                        .SemicolonLine();
                }
            }

            if (type is CollectionTypeReference array)
            {
                WriteInitialization();

                using (writer.ForEach("var item in property.Value.EnumerateArray()"))
                {
                    writer.Append($"result.{name}.Add(");
                    writer.ToDeserializeCall(array.ItemType, format, _typeFactory, w => w.Append("item"));
                    writer.Line(");");
                }
                return;
            }
            if (type is DictionaryTypeReference dictionary)
            {
                WriteInitialization();

                using (writer.ForEach("var item in property.Value.EnumerateObject()"))
                {
                    writer.Append($"result.{name}.Add(item.Name, ");
                    writer.ToDeserializeCall(dictionary.ValueType, format, _typeFactory, w => w.Append("item.Value"));
                    writer.Line(");");
                }
                return;
            }

            if (propertyType.IsNullable)
            {
                WriteNullCheck(writer);
            }
            writer.Append($"result.{name} = ");
            writer.ToDeserializeCall(type, format, _typeFactory, w => w.Append("property.Value"));
            writer.Line(";");
        }

        private static void WriteNullCheck(CodeWriter writer)
        {
            using (writer.If($"property.Value.ValueKind == {writer.Type(typeof(JsonValueKind))}.Null"))
            {
                writer.Append("continue;");
            }
        }

        //TODO: This is currently input schemas only. Does not handle output-style schemas.
        private void WriteObjectSerialization(CodeWriter writer, ClientObject model)
        {
            var cs = _typeFactory.CreateType(model);
            var serializerName = model.Name + "Serializer";
            using (writer.Namespace(cs.Namespace))
            {
                using (writer.Class(null, "partial", serializerName))
                {
                    using (writer.Method("internal static", "void", "Serialize", writer.Pair(cs, "model"), writer.Pair(typeof(Utf8JsonWriter), "writer")))
                    {
                        if (model.Discriminator?.HasDirectDescendants == true)
                        {
                            writer.Line("switch (model)");
                            using (writer.Scope())
                            {
                                foreach (var implementation in model.Discriminator.Implementations)
                                {
                                    if (!implementation.IsDirect)
                                    {
                                        continue;
                                    }

                                    var type = _typeFactory.CreateType(implementation.Type);
                                    var localName = type.Name.ToVariableName();
                                    writer.Append("case ").AppendType(type).Space().Append(localName).Append(":").Line();
                                    writer.ToSerializeCall(implementation.Type, SerializationFormat.Default,  _typeFactory, w => w.Append(localName));
                                    writer.Line("return;");
                                }
                            }
                        }

                        writer.Line("writer.WriteStartObject();");

                        var currentType = model;

                        while (currentType != null)
                        {
                            foreach (var property in currentType.Properties)
                            {
                                using (property.Type.IsNullable ? writer.If($"model.{ property.Name} != null") : default)
                                {
                                    WriteProperty(writer, property.Type, property.Format, "model." + property.Name, property.SerializedName);
                                }
                            }

                            if (currentType.Inherits == null)
                            {
                                break;
                            }

                            currentType = (ClientObject)_typeFactory.ResolveReference(currentType.Inherits);

                            writer.Line();
                        }

                        writer.Line("writer.WriteEndObject();");
                    }

                    var typeText = writer.Type(cs);
                    using (writer.Method("internal static", typeText, "Deserialize", writer.Pair(typeof(JsonElement), "element")))
                    {
                        if (model.Discriminator?.HasDescendants == true)
                        {
                            using (writer.If($"element.TryGetProperty(\"{model.Discriminator.SerializedName}\", out {writer.Type(typeof(JsonElement))} discriminator)"))
                            {
                                writer.Line("switch (discriminator.GetString())");
                                using (writer.Scope())
                                {
                                    foreach (var implementation in model.Discriminator.Implementations)
                                    {
                                        writer
                                            .Append("case ")
                                            .Literal(implementation.Key)
                                            .Append(": return ")
                                            .ToDeserializeCall(implementation.Type, SerializationFormat.Default, _typeFactory, w => w.Append("element"));
                                        writer.SemicolonLine();
                                    }
                                }
                            }
                        }

                        writer.Line($"var result = new {typeText}();");
                        using (writer.ForEach("var property in element.EnumerateObject()"))
                        {
                            var currentType = model;

                            while (currentType != null)
                            {
                                foreach (var property in currentType.Properties)
                                {
                                    using (writer.If($"property.NameEquals(\"{property.SerializedName}\")"))
                                    {
                                        ReadProperty(writer, property);
                                        writer.Line("continue;");
                                    }
                                }

                                if (currentType.Inherits == null)
                                {
                                    break;
                                }

                                currentType = (ClientObject)_typeFactory.ResolveReference(currentType.Inherits);

                                writer.Line();
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
