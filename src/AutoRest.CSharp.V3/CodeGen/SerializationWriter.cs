// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.V3.Pipeline.Generated;
using System;
using System.Linq;
using System.Text.Json;
using AutoRest.CSharp.V3.Pipeline;
using AutoRest.CSharp.V3.Utilities;

namespace AutoRest.CSharp.V3.CodeGen
{
    internal class SerializationWriter : StringWriter
    {
        public bool WriteSerialization(Schema schema) =>
            schema switch
            {
                ObjectSchema objectSchema => WriteObjectSerialization(objectSchema),
                SealedChoiceSchema sealedChoiceSchema => WriteSealedChoiceSerialization(sealedChoiceSchema),
                ChoiceSchema choiceSchema => WriteChoiceSerialization(choiceSchema),
                _ => WriteDefaultSerialization(schema)
            };

        private bool WriteDefaultSerialization(Schema schema)
        {
            Header();
            using var _ = UsingStatements();
            var cs = schema.Language.CSharp;
            using (Namespace(cs?.Type?.Namespace))
            {
                using (Class(null, "partial", cs?.Name)) { }
            }
            return true;
        }

        private void WriteProperty(Schema schema, string name, string serializedName, bool isNullable)
        {
            if (schema is ArraySchema array)
            {
                Line($"writer.WriteStartArray(\"{serializedName}\");");
                using (ForEach($"var item in {name}"))
                {
                    Line(array.ElementType.ToSerializeCall("item", serializedName, isNullable, true) ?? $"// {array.ElementType.GetType().Name}: Not Implemented");
                }
                Line("writer.WriteEndArray();");
                return;
            }
            if (schema is DictionarySchema dictionary)
            {
                Line($"writer.WriteStartObject(\"{serializedName}\");");
                using (ForEach($"var item in {name}"))
                {
                    Line(dictionary.ElementType.ToSerializeCall("item.Value", "item.Key", isNullable, false, false) ?? $"// {dictionary.ElementType.GetType().Name}: Not Implemented");
                }
                Line("writer.WriteEndObject();");
                return;
            }

            Line(schema.ToSerializeCall(name, serializedName, isNullable) ?? $"// {schema.GetType().Name} {name}: Not Implemented");
        }

        private void ReadProperty(Schema schema, string name, string typeText, string typeName)
        {
            if (schema is ArraySchema array)
            {
                using (ForEach("var item in property.Value.EnumerateArray()"))
                {
                    var elementType = array.ElementType.Language.CSharp?.Type;
                    var elementTypeName = elementType?.Name ?? "[NO TYPE NAME]";
                    //TODO: Hack for property name/type name clashing
                    var elementTypeText = elementType?.FullName ?? "[NO TYPE]";
                    var createText = array.ElementType.ToDeserializeCall("item", elementTypeText, elementTypeName);
                    Line(createText != null ? $"result.{name}.Add({createText});" : $"// {array.ElementType.GetType().Name}: Not Implemented");
                }
                return;
            }
            if (schema is DictionarySchema dictionary)
            {
                using (ForEach("var item in property.Value.EnumerateObject()"))
                {
                    var elementType = dictionary.ElementType.Language.CSharp?.Type;
                    var elementTypeName = elementType?.Name ?? "[NO TYPE NAME]";
                    //TODO: Hack for property name/type name clashing
                    var elementTypeText = elementType?.FullName ?? "[NO TYPE]";
                    var createText = dictionary.ElementType.ToDeserializeCall("item.Value", elementTypeText, elementTypeName);
                    Line(createText != null ? $"result.{name}.Add(item.Name, {createText});" : $"// {dictionary.ElementType.GetType().Name}: Not Implemented");
                }
                return;
            }

            var callText = schema.ToDeserializeCall("property.Value", typeText, typeName);
            Line(callText != null ? $"result.{name} = {callText};" : $"// {schema.GetType().Name} {name}: Not Implemented");
        }

        //TODO: This is currently input schemas only. Does not handle output-style schemas.
        private bool WriteObjectSerialization(ObjectSchema schema)
        {
            Header();
            using var _ = UsingStatements();
            var cs = schema.Language.CSharp;
            using (Namespace(cs?.Type?.Namespace))
            {
                using (Class(null, "partial", cs?.Name))
                {
                    using (Method("internal", "void", "Serialize", Pair(typeof(Utf8JsonWriter), "writer"), Pair(typeof(bool), "includeName = true")))
                    {
                        using (If("includeName"))
                        {
                            Line($"writer.WriteStartObject(\"{schema.Language.Default.Name}\");");
                        }
                        using (Else())
                        {
                            Line("writer.WriteStartObject();");
                        }

                        var propertyInfos = (schema.Properties ?? Enumerable.Empty<Property>())
                            //TODO: Implement ConstantSchema
                            .Where(p => !(p.Schema is ConstantSchema))
                            .Select(p => (Property: p, PropertyCs: p.Language.CSharp, PropertySchemaCs: p.Schema.Language.CSharp)).ToArray();
                        foreach (var (property, propertyCs, propertySchemaCs) in propertyInfos)
                        {
                            var hasField = (propertySchemaCs?.IsLazy ?? false) && !(property.Required ?? false);
                            var name = (hasField ? $"_{propertyCs?.Name.ToVariableName()}" : null) ?? propertyCs?.Name ?? "[NO NAME]";
                            var serializedName = property.Language.Default.Name;
                            var isNullable = propertyCs?.IsNullable ?? false;
                            using (isNullable ? If($"{name} != null") : new DisposeAction())
                            {
                                WriteProperty(property.Schema, name, serializedName, isNullable);
                            }
                        }

                        Line("writer.WriteEndObject();");
                    }

                    var typeText = Type(cs?.Type);
                    using (Method("internal static", typeText, "Deserialize", Pair(typeof(JsonElement), "element")))
                    {
                        Line($"var result = new {typeText}();");
                        using (ForEach("var property in element.EnumerateObject()"))
                        {
                            var propertyInfos = (schema.Properties ?? Enumerable.Empty<Property>())
                                //TODO: Implement ConstantSchema
                                .Where(p => !(p.Schema is ConstantSchema))
                                .Select(p => (Property: p, PropertyCs: p.Language.CSharp, PropertySchemaCs: p.Schema.Language.CSharp)).ToArray();
                            foreach (var (property, propertyCs, propertySchemaCs) in propertyInfos)
                            {
                                var name = propertyCs?.Name ?? "[NO NAME]";
                                var serializedName = property.Language.Default.Name;
                                using (If($"property.NameEquals(\"{serializedName}\")"))
                                {
                                    var propertyType = propertySchemaCs?.Type;
                                    var propertyTypeName = propertyType?.Name ?? "[NO TYPE NAME]";
                                    //TODO: Hack for property name/type name clashing
                                    //var propertyType = Type(property.Schema.Language.CSharp?.Type);
                                    var propertyTypeText = propertySchemaCs?.Type?.FullName ?? "[NO TYPE]";
                                    ReadProperty(property.Schema, name, propertyTypeText, propertyTypeName);
                                    Line("continue;");
                                }
                            }
                        }
                        Line("return result;");
                    }
                }
            }
            return true;
        }

        private bool WriteSealedChoiceSerialization(SealedChoiceSchema schema)
        {
            Header();
            using var _ = UsingStatements();
            var cs = schema.Language.CSharp;
            using (Namespace(cs?.Type?.Namespace))
            {
                using (Class("internal", "static", $"{cs?.Name}Extensions"))
                {
                    var stringText = Type(typeof(string));
                    var csTypeText = Type(cs?.Type);
                    var nameMap = schema.Choices.Select(c => (Choice: $"{csTypeText}.{c.Language.CSharp?.Name}", Serial: $"\"{c.Value}\"")).ToArray();
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
                    MethodExpression("public static", csTypeText, $"To{cs?.Name}", new[] { Pair($"this {stringText}", "value") }, toChoiceType);
                }
            }
            return true;
        }

        private bool WriteChoiceSerialization(ChoiceSchema schema)
        {
            Header();
            using var _ = UsingStatements();
            var cs = schema.Language.CSharp;
            var csType = cs?.Type;
            using (Namespace(csType?.Namespace))
            {
                using (Struct(null, "readonly partial", cs?.Name))
                {
                    var stringText = Type(typeof(string));
                    foreach (var (choice, choiceCs) in schema.Choices.Select(c => (c, c.Language.CSharp)))
                    {
                        Line($"private const {Pair(stringText, $"{choiceCs.Name}Value")} = \"{choice.Value}\";");
                    }
                    Line();

                    var csTypeText = Type(csType);
                    foreach (var choiceCs in schema.Choices.Select(c => c.Language.CSharp))
                    {
                        Line($"public static {Pair(csTypeText, choiceCs?.Name)} {{ get; }} = new {csTypeText}({choiceCs?.Name}Value);");
                    }
                }
            }
            return true;
        }
    }
}
