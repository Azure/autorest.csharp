using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRest.CSharp.Mgmt.Report
{
    internal class TransformerApplyRecord
    {
        public TransformerItem Transformer { get; set; }
        public string ApplyToSerializedPath { get; set; }
        public string Description { get; set; }

        public TransformerApplyRecord(TransformerItem transformer, string spplyToSerializedPath, string description)
        {
            this.Transformer = transformer;
            this.ApplyToSerializedPath = spplyToSerializedPath;
            this.Description = description;
        }
    }
}
