using AutoRest.CSharp.V3.Pipeline.Generated;

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
                using (Class("public partial", schema.Language.Default.Name))
                {
                    foreach (var property in schema.Properties)
                    {
                        var propertyCs = property.Schema.Language.Csharp;
                        var type = propertyCs?.Type?.FullName ?? "[NO TYPE]";
                        AutoProperty("public", type, property.SerializedName);
                    }
                }
            }

        }

    }
}
