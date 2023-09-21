using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Decorator;

namespace AutoRest.CSharp.Mgmt.Report.TransformerTarget
{
    internal class ObjectPropertyTransformerTarget : TransformerTargetBase
    {
        public ObjectSchema ObjectSchema { get; init; }
        public Property Property { get; init; }

        public ObjectPropertyTransformerTarget(ObjectSchema objectSchema, Property property)
        {
            ObjectSchema = objectSchema;
            Property = property;
        }

        public override string GetOriginalName()
        {
            return ObjectSchema.GetOriginalName(Property);
        }
    }
}
