// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.ComponentModel;
using System.Linq;
using AutoRest.CSharp.V3.Pipeline;
using AutoRest.CSharp.V3.Pipeline.Generated;
using AutoRest.CSharp.V3.Plugins;
using AutoRest.CSharp.V3.Utilities;

namespace AutoRest.CSharp.V3.CodeGen
{
    internal class SchemaWriter : StringWriter
    {
        private readonly TypeFactory _typeFactory;

        public SchemaWriter(TypeFactory typeFactory)
        {
            _typeFactory = typeFactory;
        }

        public bool WriteSchema(Schema schema) =>
            schema switch
            {
                ObjectSchema objectSchema => WriteObjectSchema(objectSchema),
                SealedChoiceSchema sealedChoiceSchema => WriteSealedChoiceSchema(sealedChoiceSchema),
                ChoiceSchema choiceSchema => WriteChoiceSchema(choiceSchema),
                _ => WriteDefaultSchema(schema)
            };

        public bool WriteDefaultSchema(Schema schema)
        {
            Header();
            using var _ = UsingStatements();
            var cs = _typeFactory.CreateType(schema);
            using (Namespace(cs.Namespace))
            {
                using (Class(null, "partial", schema.CSharpName())) { }
            }
            return true;
        }

        //TODO: This is currently input schemas only. Does not handle output-style schemas.
        private bool WriteObjectSchema(ObjectSchema schema)
        {
            Header();
            using var _ = UsingStatements();
            var cs = _typeFactory.CreateType(schema);
            using (Namespace(cs?.Namespace))
            {
                using (Class(null, "partial", schema.CSharpName()))
                {
                    var propertyInfos = (schema.Properties ?? Enumerable.Empty<Property>())
                        .Select(p => (Property: p, PropertySchemaCs: p.Schema.Language.CSharp)).ToArray();
                    foreach (var (property, _) in propertyInfos)
                    {
                        if (property.Schema is ConstantSchema constantSchema)
                        {
                            //TODO: Determine if type can use 'const' field instead of 'static' property
                            Line($"public static {Pair(_typeFactory.CreateType(constantSchema.ValueType), property.CSharpName())} {{ get; }} = {constantSchema.ToValueString()};");
                            continue;
                        }
                        if ((property.Schema.IsLazy()) && !(property.Required ?? false) && !(property.Required ?? false))
                        {
                            LazyProperty("public", _typeFactory.CreateType(property.Schema), _typeFactory.CreateConcreteType(property.Schema), property.CSharpName(), property.IsNullable());
                            continue;
                        }
                        AutoProperty("public", _typeFactory.CreateType(property.Schema), property.CSharpName(), property.IsNullable(), property.Required ?? false);
                    }

                    var filteredPropertyInfos = propertyInfos.Where(p => !(p.Property.Schema is ConstantSchema)).ToArray();
                    if (filteredPropertyInfos.Any(pi => pi.Property.Required ?? false))
                    {
                        Line();
                        Line("#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.");
                        using (Method("private", null, schema.CSharpName()))
                        {
                        }
                        Line("#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.");

                        Line();
                        var requiredProperties = filteredPropertyInfos.Where(pi => pi.Property.Required ?? false)
                            .Select(pi => (Info: pi, VariableName: pi.Property.CSharpVariableName(), InputType: _typeFactory.CreateInputType(pi.Property.Schema))).ToArray();
                        var parameters = requiredProperties.Select(rp => Pair(rp.InputType, rp.VariableName)).ToArray();
                        using (Method("public", null, schema.CSharpName(), parameters))
                        {
                            foreach (var ((property, _), variableName, _) in requiredProperties)
                            {
                                if (property.Schema.IsLazy())
                                {
                                    Line($"{property.CSharpName()} = new {Type(_typeFactory.CreateConcreteType(property.Schema))}({variableName});");
                                    continue;
                                }
                                Line($"{property.CSharpName()} = {variableName};");
                            }
                        }
                    }
                }
            }
            return true;
        }

        private bool WriteSealedChoiceSchema(SealedChoiceSchema schema)
        {
            Header();
            using var _ = UsingStatements();
            var cs = _typeFactory.CreateType(schema);
            using (Namespace(cs.Namespace))
            {
                using (Enum(null, null, schema.CSharpName()))
                {
                    schema.Choices.Select(c => c).ForEachLast(ccs => EnumValue(ccs.CSharpName()), ccs => EnumValue(ccs.CSharpName(), false));
                }
            }
            return true;
        }

        private bool WriteChoiceSchema(ChoiceSchema schema)
        {
            Header();
            using var _ = UsingStatements();
            var cs = _typeFactory.CreateType(schema);
            using (Namespace(cs.Namespace))
            {
                var implementType = new CSharpType {FrameworkType = typeof(IEquatable<>), SubType1 = cs};
                using (Struct(null, "readonly partial", schema.CSharpName(), Type(implementType)))
                {
                    var stringText = Type(typeof(string));
                    var nullableStringText = Type(typeof(string), true);
                    Line($"private readonly {Pair(nullableStringText, "_value")};");
                    Line();

                    using (Method("public", null, schema.CSharpName(), Pair(stringText, "value")))
                    {
                        Line($"_value = value ?? throw new {Type(typeof(ArgumentNullException))}(nameof(value));");
                    }
                    Line();

                    var csTypeText = Type(cs);
                    var boolText = Type(typeof(bool));
                    var leftRightParams = new[] {Pair(csTypeText, "left"), Pair(csTypeText, "right")};
                    MethodExpression("public static", boolText, "operator ==", leftRightParams, "left.Equals(right)");
                    MethodExpression("public static", boolText, "operator !=", leftRightParams, "!left.Equals(right)");
                    MethodExpression("public static implicit", null, $"operator {csTypeText}", new[]{Pair(stringText, "value")}, $"new {csTypeText}(value)");
                    Line();

                    var editorBrowsableNever = $"[{AttributeType(typeof(EditorBrowsableAttribute))}({Type(typeof(EditorBrowsableState))}.Never)]";
                    Line(editorBrowsableNever);
                    MethodExpression("public override", boolText, "Equals", new[]{Pair(typeof(object), "obj", true)}, $"obj is {csTypeText} other && Equals(other)");
                    MethodExpression("public", boolText, "Equals", new[] { Pair(csTypeText, "other") }, $"{stringText}.Equals(_value, other._value, {Type(typeof(StringComparison))}.Ordinal)");
                    Line();

                    Line(editorBrowsableNever);
                    MethodExpression("public override", Type(typeof(int)), "GetHashCode", null, "_value?.GetHashCode() ?? 0");
                    MethodExpression("public override", nullableStringText, "ToString", null, "_value");
                }
            }
            return true;
        }
    }
}
