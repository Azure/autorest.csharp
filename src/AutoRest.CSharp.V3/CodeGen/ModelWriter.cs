using AutoRest.CSharp.V3.Pipeline.Generated;

namespace AutoRest.CSharp.V3.CodeGen
{
    internal class ModelWriter : StringCSharpWriter
    {
        //public void WriteObjectSchema(ObjectSchema schema)
        //{
        //    FileHeader();

        //    Usings();

        //    var schemaCs = schema.Language.CSharp;
        //    using (Namespace(schemaCs?.Type?.Namespace?.FullName ?? "[NO NAMESPACE]"))
        //    {
        //        using (Class("public partial", schemaCs?.Name ?? "[NO NAME]"))
        //        {
        //            foreach (var property in schema.Properties)
        //            {
        //                var propertySchemaCs = property.Schema.Language.CSharp;
        //                var type = propertySchemaCs?.Type?.FullName ?? "[NO TYPE]";
        //                var propertyCs = property.Language.CSharp;
        //                AutoProperty("public", type, propertyCs?.Name ?? "[NO NAME]");
        //            }
        //        }
        //    }
        //}

        public void WriteSchema(Schema schema)
        {
            FileHeader();

            Usings();

            //WriteSchemaInternal(schema);

            var schemaCs = schema.Language.CSharp;
            using (Namespace(schemaCs?.Type?.Namespace?.FullName ?? "[NO NAMESPACE]"))
            {
                using (Class("public partial", schemaCs?.Name ?? "[NO NAME]"))
                {
                    if (schema is ObjectSchema objectSchema)
                    {
                        foreach (var property in objectSchema.Properties)
                        {
                            var propertySchemaCs = property.Schema.Language.CSharp;
                            var type = propertySchemaCs?.Type?.FullName ?? "[NO TYPE]";
                            var propertyCs = property.Language.CSharp;
                            AutoProperty("public", type, propertyCs?.Name ?? "[NO NAME]");
                        }
                    }
                }
            }
        }

        //private void WriteSchemaInternal(Schema schema)
        //{
        //    var schemaCs = schema.Language.CSharp;
        //    using (Namespace(schemaCs?.Type?.Namespace?.FullName ?? "[NO NAMESPACE]"))
        //    {
        //        using (Class("public partial", schemaCs?.Name ?? "[NO NAME]"))
        //        {
        //        }
        //    }
        //}

        //private void WriteSchemaInternal(ObjectSchema objectSchema)
        //{
        //    var schemaCs = objectSchema.Language.CSharp;
        //    using (Namespace(schemaCs?.Type?.Namespace?.FullName ?? "[NO NAMESPACE]"))
        //    {
        //        using (Class("public partial", schemaCs?.Name ?? "[NO NAME]"))
        //        {
        //            foreach (var property in objectSchema.Properties)
        //            {
        //                var propertySchemaCs = property.Schema.Language.CSharp;
        //                var type = propertySchemaCs?.Type?.FullName ?? "[NO TYPE]";
        //                var propertyCs = property.Language.CSharp;
        //                AutoProperty("public", type, propertyCs?.Name ?? "[NO NAME]");
        //            }
        //        }
        //    }
        //}

        //private void WriteSchemaInternal(ArraySchema schema)
        //{
        //    FileHeader();

        //    Usings();

        //    var schemaCs = schema.Language.CSharp;
        //    using (Namespace(schemaCs?.Type?.Namespace?.FullName ?? "[NO NAMESPACE]"))
        //    {
        //        using (Class("public partial", schemaCs?.Name ?? "[NO NAME]"))
        //        {
        //            if (schema is ObjectSchema objectSchema)
        //            {
        //                foreach (var property in objectSchema.Properties)
        //                {
        //                    var propertySchemaCs = property.Schema.Language.CSharp;
        //                    var type = propertySchemaCs?.Type?.FullName ?? "[NO TYPE]";
        //                    var propertyCs = property.Language.CSharp;
        //                    AutoProperty("public", type, propertyCs?.Name ?? "[NO NAME]");
        //                }
        //            }
        //        }
        //    }
        //}
    }
}
