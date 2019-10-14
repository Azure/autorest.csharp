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

            using (Namespace(schema.Language.Default.Namespace))
            {
                using (Class("public partial", schema.Language.Default.Name))
                {
                    foreach (var property in schema.Properties)
                    {
                        var type = property.Schema.Language.Csharp?.TypeName ?? property.Schema.Type.ToString();
                        AutoProperty("public", type, property.Language.Default.Name);
                    }
                }
            }

        }

    }
}
