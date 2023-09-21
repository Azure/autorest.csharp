using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRest.CSharp.Mgmt.Report.TransformerTarget
{
    internal abstract class TransformerTargetBase
    {
        public abstract string GetOriginalName();

        public TransformerTargetBase()
        {
        }
    }
}
