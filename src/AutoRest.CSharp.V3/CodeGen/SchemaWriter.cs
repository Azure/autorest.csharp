using System;
using System.ComponentModel;
using System.Linq;
using AutoRest.CSharp.V3.Pipeline.Generated;
using AutoRest.CSharp.V3.Utilities;

namespace AutoRest.CSharp.V3.CodeGen
{
    internal class SchemaWriter : StringWriter
    {
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
            var cs = schema.Language.CSharp;
            using (Namespace(cs?.Type?.Namespace))
            {
                using (Class(null, "partial", cs?.Name)) { }
            }
            return true;
        }

        // CURRENTLY, INPUT SCHEMA
        private bool WriteObjectSchema(ObjectSchema schema)
        {
            Header();
            using var _ = UsingStatements();
            var cs = schema.Language.CSharp;
            using (Namespace(cs?.Type?.Namespace))
            {
                using (Class(null, "partial", cs?.Name))
                {
                    var propertyInfos = (schema.Properties?.Select(p => (Property: p, PropertyCs: p.Language.CSharp, PropertySchemaCs: p.Schema.Language.CSharp))
                                         ?? Enumerable.Empty<(Property, CSharpLanguage?, CSharpLanguage?)>()).ToArray();
                    foreach (var (property, propertyCs, propertySchemaCs) in propertyInfos)
                    {
                        if ((propertySchemaCs?.IsLazy ?? false) && !(property.Required ?? false) && !(propertySchemaCs?.HasRequired ?? false))
                        {
                            LazyProperty("public", propertySchemaCs!.Type, propertySchemaCs.ConcreteType ?? propertySchemaCs.Type, propertyCs?.Name, propertyCs?.IsNullable);
                            continue;
                        }
                        AutoProperty("public", propertySchemaCs?.Type, propertyCs?.Name, propertyCs?.IsNullable);
                    }

                    if (propertyInfos.Any(pi => pi.Property.Required ?? false))
                    {
                        Line();
                        var requiredProperties = propertyInfos.Where(pi => pi.Property.Required ?? false)
                            .Select(pi => (Info: pi, VariableName: pi.PropertyCs?.Name.ToVariableName(), InputType: pi.PropertySchemaCs?.InputType ?? pi.PropertySchemaCs?.Type)).ToArray();
                        var parameters = requiredProperties.Select(rp => Pair(rp.InputType, rp.VariableName)).ToArray();
                        using (Method("public", null, cs?.Name, parameters))
                        {
                            foreach (var ((_, propertyCs, propertySchemaCs), variableName, _) in requiredProperties)
                            {
                                if (propertySchemaCs?.IsLazy ?? false)
                                {
                                    Line($"{propertyCs?.Name} = new {Type(propertySchemaCs!.ConcreteType ?? propertySchemaCs.Type)}({variableName});");
                                    continue;
                                }
                                Line($"{propertyCs?.Name} = {variableName};");
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
            var cs = schema.Language.CSharp;
            using (Namespace(cs?.Type?.Namespace))
            {
                using (Enum(null, null, cs?.Name))
                {
                    schema.Choices.Select(c => c.Language.CSharp).ForEachLast(ccs => EnumValue(ccs?.Name), ccs => EnumValue(ccs?.Name, false));
                }
                Line();
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

        private bool WriteChoiceSchema(ChoiceSchema schema)
        {
            Header();
            using var _ = UsingStatements();
            var cs = schema.Language.CSharp;
            var csType = cs?.Type;
            using (Namespace(csType?.Namespace))
            {
                var implementType = new CSharpType {FrameworkType = typeof(IEquatable<>), SubType1 = csType};
                using (Struct(null, "readonly", cs?.Name, Type(implementType)))
                {
                    var stringText = Type(typeof(string));
                    var nullableStringText = Type(typeof(string), true);
                    foreach (var (choice, choiceCs) in schema.Choices.Select(c => (c, c.Language.CSharp)))
                    {
                        Line($"internal const {Pair(stringText, $"{choiceCs.Name}Value")} = \"{choice.Value}\";");
                    }
                    Line($"private readonly {Pair(nullableStringText, "_value")};");
                    Line();

                    using (Method("public", null, cs?.Name, Pair(stringText, "value")))
                    {
                        Line($"_value = value ?? throw new {Type(typeof(ArgumentNullException))}(nameof(value));");
                    }
                    Line();

                    var csTypeText = Type(csType);
                    foreach (var choiceCs in schema.Choices.Select(c => c.Language.CSharp))
                    {
                        Line($"public static {Pair(csTypeText, choiceCs?.Name)} {{ get; }} = new {csTypeText}({choiceCs?.Name}Value);");
                    }
                    Line();

                    var boolText = Type(typeof(bool));
                    var leftRightParams = new[] {Pair(csTypeText, "left"), Pair(csTypeText, "right")};
                    MethodExpression("public static", boolText, "operator ==", leftRightParams, "left.Equals(right)");
                    MethodExpression("public static", boolText, "operator !=", leftRightParams, "!left.Equals(right)");
                    MethodExpression("public static implicit", null, $"operator {csTypeText}", new []{Pair(stringText, "value")}, $"new {csTypeText}(value)");
                    Line();

                    var editorBrowsableNever = $"[{AttributeType(typeof(EditorBrowsableAttribute))}({Type(typeof(EditorBrowsableState))}.Never)]";
                    Line(editorBrowsableNever);
                    MethodExpression("public override", boolText, "Equals", new []{Pair(typeof(object), "obj", true)}, $"obj is {csTypeText} other && Equals(other)");
                    MethodExpression("public", boolText, "Equals", new[] { Pair(csTypeText, "obj") }, $"{stringText}.Equals(_value, other._value, {Type(typeof(StringComparison))}.Ordinal)");
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
