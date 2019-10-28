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
            using var _ = Usings();
            var cs = schema.Language.CSharp;
            //using (Namespace(schemaCs?.Type?.Namespace?.FullName ?? "[NO NAMESPACE]"))
            //{
            //    using (Class("public partial", schemaCs?.Name ?? "[NO NAME]"))
            //    {
            //    }
            //}
            using (Namespace(cs?.Type?.Namespace))
            {
                using (Class("public partial", cs)) { }
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
                using (Class("public partial", cs))
                {
                    foreach (var property in schema.Properties)
                    {
                        
                        //var type = propertySchemaCs?.Type?.FullName ?? "[NO TYPE]";
                        var propertyCs = property.Language.CSharp;
                        var propertySchemaCs = property.Schema.Language.CSharp;
                        AutoProperty("public", propertySchemaCs?.Type, propertyCs);
                    }
                }
            }
            return true;
        }

        private bool WriteSealedChoiceSchema(SealedChoiceSchema schema)
        {
            FileHeader();
            using var _ = Usings();
            var cs = schema.Language.CSharp;
            using (Namespace(cs?.Type?.Namespace))
            {
                using (Enum("public", cs))
                {
                    foreach (var choice in schema.Choices)
                    {
                        var choiceCs = choice.Language.CSharp;
                        EnumValue(choiceCs);
                    }
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
                using (Enum("public", cs))
                {
                    foreach (var choice in schema.Choices)
                    {
                        var choiceCs = choice.Language.CSharp;
                        EnumValue(choiceCs);
                    }
                }
            }
            return true;
        }
    }
}
