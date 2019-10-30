using System;
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
            using var _ = Usings();
            var cs = schema.Language.CSharp;
            using (Namespace(cs?.Type?.Namespace))
            {
                using (Class("public partial", cs?.Name)) { }
            }
            return true;
        }

        private bool WriteObjectSchema(ObjectSchema schema)
        {
            FileHeader();
            using var _ = Usings();
            var cs = schema.Language.CSharp;
            using (Namespace(cs?.Type?.Namespace))
            {
                using (Class("public partial", cs?.Name))
                {
                    foreach (var (propertyCs, propertySchemaCs) in schema.Properties.Select(p => (p.Language.CSharp, p.Schema.Language.CSharp)))
                    {
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
                using (Enum("public", cs?.Name))
                {
                    schema.Choices.Select(c => c.Language.CSharp)
                        .ForEachLast(cc => EnumValue(cc), cc => EnumValue(cc, false));
                }
            }
            return true;
        }

        private bool WriteChoiceSchema(ChoiceSchema schema)
        {
            FileHeader();
            using var _ = Usings();
            var cs = schema.Language.CSharp;
            using (Namespace(cs?.Type?.Namespace))
            {
                var implementType = new CSharpType {FrameworkType = typeof(IEquatable<>), SubType1 = cs?.Type};
                using (Struct("public readonly", cs?.Name, Type(implementType)))
                {
                    foreach (var (choice, choiceCs) in schema.Choices.Select(c => (c, c.Language.CSharp)))
                    {
                        Line($"internal const {Type(typeof(string))} {choiceCs.Name} = \"{choice.Value}\";");
                    }
                    Line($"private readonly {Type(typeof(string))} _value;");
                    Line();

                    using (Method("public", cs?.Name))
                    {
                        Line($"_value = value ?? throw new {Type(typeof(ArgumentNullException))}(nameof(value));");
                    }


                }
            }
            return true;
        }
    }
}
