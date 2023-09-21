using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Decorator;

namespace AutoRest.CSharp.Mgmt.Report.TransformerTarget
{
    internal class SchemaTransformerTarget : TransformerTargetBase
    {
        public Schema Schema { get; init; }

        public SchemaTransformerTarget(Schema schema)
        {
            Schema = schema;
        }

        public override string GetOriginalName()
        {
            return Schema.GetOriginalName();
        }
    }
}
