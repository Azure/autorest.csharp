using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoRest.CSharp.Mgmt.Report.TransformerTarget;

namespace AutoRest.CSharp.Mgmt.Report.Transformer
{
    internal class RenameMappingTransfomer : Transformer
    {
        public override string TransformerType => "rename-mapping";

        public override string DisplayName => this.ToString();

        public override string GetLogForTransform(TransformerTargetBase target)
        {
            
        }
    }
}
