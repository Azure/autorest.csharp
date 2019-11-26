// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.V3.Pipeline.Generated;
using System;
using System.Linq;
using System.Text.Json;
using AutoRest.CSharp.V3.Pipeline;
using AutoRest.CSharp.V3.Plugins;
using AutoRest.CSharp.V3.Utilities;

namespace AutoRest.CSharp.V3.CodeGen
{
    internal class SerializationWriter : StringWriter
    {
        private readonly TypeFactory _typeFactory;

        public SerializationWriter(TypeFactory typeFactory)
        {
            _typeFactory = typeFactory;
        }

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
            var cs = _typeFactory.CreateType(schema);
            using (Namespace(cs?.Namespace))
            {
                using (Class(null, "partial", schema.CSharpName())) { }
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
                    Line(array.ElementType.ToSerializeCall(_typeFactory, "item", serializedName, isNullable, true) ?? $"// {array.ElementType.GetType().Name}: Not Implemented");
                }
                Line("writer.WriteEndArray();");
                return;
            }
            if (schema is DictionarySchema dictionary)
            {
                Line($"writer.WriteStartObject(\"{serializedName}\");");
                using (ForEach($"var item in {name}"))
                {
                    Line(dictionary.ElementType.ToSerializeCall(_typeFactory, "item.Value", "item.Key", isNullable, false, false) ?? $"// {dictionary.ElementType.GetType().Name}: Not Implemented");
                }
                Line("writer.WriteEndObject();");
                return;
            }

            Line(schema.ToSerializeCall(_typeFactory, name, serializedName, isNullable) ?? $"// {schema.GetType().Name} {name}: Not Implemented");
        }

        private void ReadProperty(Schema schema, string name, string typeText, string typeName)
        {
            if (schema is ArraySchema array)
            {
                using (ForEach("var item in property.Value.EnumerateArray()"))
                {
                    var elementType = _typeFactory.CreateType(array.ElementType);
                    var elementTypeName = elementType?.Name ?? "[NO TYPE NAME]";
                    //TODO: Hack for property name/type name clashing
                    var elementTypeText = elementType?.FullName ?? "[NO TYPE]";
                    var createText = array.ElementType.ToDeserializeCall(_typeFactory, "item", elementTypeText, elementTypeName);
                    Line(createText != null ? $"result.{name}.Add({createText});" : $"// {array.ElementType.GetType().Name}: Not Implemented");
                }
                return;
            }
            if (schema is DictionarySchema dictionary)
            {
                using (ForEach("var item in property.Value.EnumerateObject()"))
                {
                    var elementType = _typeFactory.CreateType(dictionary.ElementType);
                    var elementTypeName = elementType?.Name ?? "[NO TYPE NAME]";
                    //TODO: Hack for property name/type name clashing
                    var elementTypeText = elementType?.FullName ?? "[NO TYPE]";
                    var createText = dictionary.ElementType.ToDeserializeCall(_typeFactory, "item.Value", elementTypeText, elementTypeName);
                    Line(createText != null ? $"result.{name}.Add(item.Name, {createText});" : $"// {dictionary.ElementType.GetType().Name}: Not Implemented");
                }
                return;
            }

            var callText = schema.ToDeserializeCall(_typeFactory, "property.Value", typeText, typeName);
            Line(callText != null ? $"result.{name} = {callText};" : $"// {schema.GetType().Name} {name}: Not Implemented");
        }

        //TODO: This is currently input schemas only. Does not handle output-style schemas.
        private bool WriteObjectSerialization(ObjectSchema schema)
        {
            Header();
            using var _ = UsingStatements();
            var cs = _typeFactory.CreateType(schema);
            using (Namespace(cs.Namespace))
            {
                using (Class(null, "partial", schema.CSharpName()))
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

                        var propertyInfos = schema.Properties ?? Enumerable.Empty<Property>();
                        foreach (var property in propertyInfos)
                        {
                            var hasField = property.Schema.IsLazy() && !(property.Required ?? false);
                            var name = (hasField ? $"_{property.CSharpVariableName()}" : null) ?? property?.CSharpName() ?? "[NO NAME]";

                            var serializedName = property!.Language.Default.Name;
                            var isNullable = property.IsNullable();
                            using (isNullable ? If($"{name} != null") : new DisposeAction())
                            {
                                WriteProperty(property.Schema, name, serializedName, isNullable);
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
                            var propertyInfos = (schema.Properties ?? Enumerable.Empty<Property>())
                                // Do not deserialize constant properties
                                .Where(p => !(p.Schema is ConstantSchema)).ToArray();
                            foreach (var property in propertyInfos)
                            {
                                var name = property.CSharpName();
                                var serializedName = property.Language.Default.Name;
                                using (If($"property.NameEquals(\"{serializedName}\")"))
                                {
                                    var propertyType = _typeFactory.CreateType(property.Schema);
                                    var propertyTypeName = propertyType?.Name ?? "[NO TYPE NAME]";
                                    //TODO: Hack for property name/type name clashing
                                    //var propertyType = Type(property.Schema.Language.CSharp?.Type);
                                    ReadProperty(property.Schema, name, propertyType.FullName, propertyTypeName);
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
            var cs = _typeFactory.CreateType(schema);
            using (Namespace(cs.Namespace))
            {
                using (Class("internal", "static", $"{schema.CSharpName()}Extensions"))
                {
                    var stringText = Type(typeof(string));
                    var csTypeText = Type(cs);
                    var nameMap = schema.Choices.Select(c => (Choice: $"{csTypeText}.{c.CSharpName()}", Serial: $"\"{c.Value}\"")).ToArray();
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
            return true;
        }

        private bool WriteChoiceSerialization(ChoiceSchema schema)
        {
            Header();
            using var _ = UsingStatements();
            var cs = _typeFactory.CreateType(schema);
            using (Namespace(cs?.Namespace))
            {
                using (Struct(null, "readonly partial", schema.CSharpName()))
                {
                    var stringText = Type(typeof(string));
                    foreach (var choice in schema.Choices.Select(c => c))
                    {
                        Line($"private const {Pair(stringText, $"{choice.CSharpName()}Value")} = \"{choice.Value}\";");
                    }
                    Line();

                    var csTypeText = Type(cs);
                    foreach (var choice in schema.Choices)
                    {
                        Line($"public static {Pair(csTypeText, choice?.CSharpName())} {{ get; }} = new {csTypeText}({choice?.CSharpName()}Value);");
                    }
                }
            }
            return true;
        }
    }
}
