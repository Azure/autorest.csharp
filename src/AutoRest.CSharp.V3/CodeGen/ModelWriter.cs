using AutoRest.CSharp.V3.Pipeline.Generated;
using AutoRest.CSharp.V3.Utilities;
using CaseExtensions;

namespace AutoRest.CSharp.V3.CodeGen
{
    internal class ModelWriter : StringCSharpWriter
    {
        public ModelWriter()
        {
        }

        public void WriteObjectSchema(ObjectSchema schema)
        {
            FileHeader();

            Usings();

            var schemaCs = schema.Language.Csharp;
            using (Namespace(schemaCs?.Type?.Namespace?.FullName ?? "[NO NAMESPACE]"))
            {
                using (Class("public partial", schema.Language.Default.Name.ToCleanName()))
                {
                    foreach (var property in schema.Properties)
                    {
                        var propertyCs = property.Schema.Language.Csharp;
                        var type = propertyCs?.Type?.FullName ?? "[NO TYPE]";
                        AutoProperty("public", type, property.SerializedName.ToCleanName());
                    }
                }
            }
        }

        public void WriteSchema(Schema schema)
        {
            FileHeader();

            Usings();

            var schemaCs = schema.Language.Csharp;
            using (Namespace(schemaCs?.Type?.Namespace?.FullName ?? "[NO NAMESPACE]"))
            {
                using (Class("public partial", schema.Language.Default.Name.ToCleanName()))
                {
                    if (schema is ObjectSchema objectSchema)
                    {
                        foreach (var property in objectSchema.Properties)
                        {
                            var propertyCs = property.Schema.Language.Csharp;
                            var type = propertyCs?.Type?.FullName ?? "[NO TYPE]";
                            AutoProperty("public", type, property.SerializedName.ToCleanName());
                        }
                    }
                }
            }
        }
    }
}
