using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Decorator;

namespace AutoRest.CSharp.Mgmt.Report.TransformerTarget
{
    internal class SealedChoiceValueTransformerTarget : TransformerTargetBase
    {
        public SealedChoiceSchema SealedChoiceSchema { get; init; }
        public ChoiceValue ChoiceValue { get; init; }

        public SealedChoiceValueTransformerTarget(SealedChoiceSchema sealedChoiceSchema, ChoiceValue choiceValue)
        {
            ChoiceValue = choiceValue;
            SealedChoiceSchema = sealedChoiceSchema;
        }

        public override string GetOriginalName()
        {
            return SealedChoiceSchema.GetOriginalName(ChoiceValue);
        }
    }
}
