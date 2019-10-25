using AutoRest.CSharp.V3.Pipeline.Generated;

namespace AutoRest.CSharp.V3.CodeGen
{
    internal class ModelWriter : StringCSharpWriter
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
            Usings();
            var schemaCs = schema.Language.CSharp;
            using (Namespace(schemaCs?.Type?.Namespace?.FullName ?? "[NO NAMESPACE]"))
            {
                using (Class("public partial", schemaCs?.Name ?? "[NO NAME]"))
                {
                }
            }
            return true;
        }

        private bool WriteObjectSchema(ObjectSchema schema)
        {
            FileHeader();
            Usings();
            var schemaCs = schema.Language.CSharp;
            using (Namespace(schemaCs?.Type?.Namespace?.FullName ?? "[NO NAMESPACE]"))
            {
                using (Class("public partial", schemaCs?.Name ?? "[NO NAME]"))
                {
                    foreach (var property in schema.Properties)
                    {
                        var propertySchemaCs = property.Schema.Language.CSharp;
                        var type = propertySchemaCs?.Type?.FullName ?? "[NO TYPE]";
                        var propertyCs = property.Language.CSharp;
                        AutoProperty("public", type, propertyCs?.Name ?? "[NO NAME]");
                    }
                }
            }
            return true;
        }

        private bool WriteSealedChoiceSchema(SealedChoiceSchema schema)
        {
            FileHeader();
            Usings();
            var schemaCs = schema.Language.CSharp;
            using (Namespace(schemaCs?.Type?.Namespace?.FullName ?? "[NO NAMESPACE]"))
            {
                using (Enum("public", schemaCs?.Name ?? "[NO NAME]"))
                {
                    foreach (var choice in schema.Choices)
                    {
                        var choiceCs = choice.Language.CSharp;
                        EnumValue(choiceCs?.Name ?? "[NO NAME]");
                    }
                }
            }
            return true;
        }

        private bool WriteChoiceSchema(ChoiceSchema schema)
        {
            FileHeader();
            Usings();
            var schemaCs = schema.Language.CSharp;
            using (Namespace(schemaCs?.Type?.Namespace?.FullName ?? "[NO NAMESPACE]"))
            {
                using (Enum("public", schemaCs?.Name ?? "[NO NAME]"))
                {
                    foreach (var choice in schema.Choices)
                    {
                        var choiceCs = choice.Language.CSharp;
                        EnumValue(choiceCs?.Name ?? "[NO NAME]");
                    }
                }
            }
            return true;
        }
    }
}
