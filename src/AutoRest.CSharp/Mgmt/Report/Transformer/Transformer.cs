using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoRest.CSharp.Mgmt.Report.TransformerTarget;

namespace AutoRest.CSharp.Mgmt.Report.Transformer
{
    internal abstract class Transformer
    {
        protected Transformer(string key)
        {
            Key = key;
            Arguments = Array.Empty<string>();
        }

        protected Transformer(string key, string[] arguments)
        {
            Key = key;
            Arguments = arguments;
        }

        public abstract string TransformerType { get; }
        public abstract string DisplayName { get; }
        public abstract string GetLogForTransform(TransformerTargetBase target);

        public string Key { get; set; }
        public string[] Arguments { get; set; }

        public override string ToString()
        {
            return $"{this.Key}:{string.Join(", ", Arguments)}";
        }
    }
}
