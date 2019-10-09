using AutoRest.CSharp.V3.Pipeline.Generated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


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
                        AutoProperty("public", property.Schema.Type.ToString(), property.Language.Default.Name);

                    }
                }
            }

        }

    }
}
