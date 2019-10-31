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
            FileHeader();
            using var _ = UsingStatements();
            var cs = schema.Language.CSharp;
            using (Namespace(cs?.Type?.Namespace))
            {
                using (Class(null, "partial", cs?.Name)) { }
            }
            return true;
        }

        private bool WriteObjectSchema(ObjectSchema schema)
        {
            FileHeader();
            using var _ = UsingStatements();
            var cs = schema.Language.CSharp;
            using (Namespace(cs?.Type?.Namespace))
            {
                using (Class(null, "partial", cs?.Name))
                {
                    foreach (var (propertyCs, propertySchemaCs) in schema.Properties.Select(p => (p.Language.CSharp, p.Schema.Language.CSharp)))
                    {
                        if (propertySchemaCs?.IsLazy ?? false)
                        {
                            LazyProperty("public", propertySchemaCs!.Type, propertySchemaCs.LazyType ?? propertySchemaCs.Type, propertyCs?.Name);
                            continue;
                        }
                        AutoProperty("public", propertySchemaCs?.Type, propertyCs?.Name);
                    }
                }
            }
            return true;
        }

        private bool WriteSealedChoiceSchema(SealedChoiceSchema schema)
        {
            FileHeader();
            var cs = schema.Language.CSharp;
            using (Namespace(cs?.Type?.Namespace))
            {
                using (Enum(null, null, cs?.Name))
                {
                    schema.Choices.Select(c => c.Language.CSharp).ForEachLast(cc => EnumValue(cc?.Name), cc => EnumValue(cc?.Name, false));
                }
            }
            return true;
        }

        private bool WriteChoiceSchema(ChoiceSchema schema)
        {
            FileHeader();
            using var _ = UsingStatements();
            var cs = schema.Language.CSharp;
            var csType = cs?.Type;
            using (Namespace(csType?.Namespace))
            {
                var implementType = new CSharpType {FrameworkType = typeof(IEquatable<>), SubType1 = csType};
                using (Struct(null, "readonly", cs?.Name, Type(implementType)))
                {
                    var stringText = Type(typeof(string));
                    foreach (var (choice, choiceCs) in schema.Choices.Select(c => (c, c.Language.CSharp)))
                    {
                        Line($"internal const {Pair(stringText, $"{choiceCs.Name}Value")} = \"{choice.Value}\";");
                    }
                    Line($"private readonly {Pair(stringText, "_value")};");
                    Line();

                    using (Method("public", null, cs?.Name, Pair(stringText, "value")))
                    {
                        Line($"_value = value ?? throw new {Type(typeof(ArgumentNullException))}(nameof(value));");
                    }
                    Line();

                    var csTypeText = Type(csType);
                    foreach (var choiceCs in schema.Choices.Select(c => c.Language.CSharp))
                    {
                        Line($"public static {Pair(csTypeText, choiceCs.Name)} {{ get; }} = new {csTypeText}({choiceCs.Name}Value);");
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
                    MethodExpression("public override", boolText, "Equals", new []{Pair(typeof(object), "obj")}, $"obj is {csTypeText} other && Equals(other)");
                    MethodExpression("public", boolText, "Equals", new[] { Pair(csTypeText, "obj") }, $"{stringText}.Equals(_value, other._value, {Type(typeof(StringComparison))}.Ordinal)");
                    Line();

                    Line(editorBrowsableNever);
                    MethodExpression("public override", Type(typeof(int)), "GetHashCode", null, "_value?.GetHashCode() ?? 0");
                    MethodExpression("public override", stringText, "ToString", null, "_value");
                }
            }
            return true;
        }
    }
}
