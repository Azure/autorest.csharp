using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Decorator;

namespace AutoRest.CSharp.Mgmt.Report.TransformerTarget
{
    internal class ChoiceValueTransformerTarget : TransformerTargetBase
    {
        public ChoiceSchema ChoiceSchema { get; init; }
        public ChoiceValue ChoiceValue { get; init; }

        public ChoiceValueTransformerTarget(ChoiceSchema choiceSchema, ChoiceValue choiceValue)
        {
            ChoiceValue = choiceValue;
            ChoiceSchema = choiceSchema;
        }

        public override string GetOriginalName()
        {
            return ChoiceSchema.GetOriginalName(ChoiceValue);
        }
    }
}
