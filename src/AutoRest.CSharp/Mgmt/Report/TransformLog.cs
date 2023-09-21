using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoRest.CSharp.Mgmt.Report.TransformerTarget;

namespace AutoRest.CSharp.Mgmt.Report
{
    internal class TransformLog
    {
        public TransformLog(string transformType, string key, string[] arguments, string targetOriginalName, string logMessage)
        {
            TransformType = transformType;
            Key = key;
            Arguments = arguments;
            LogMessage = logMessage;
            TargetOriginalName = targetOriginalName;
        }

        public string TransformType { get; }
        public string Key { get; }
        public string[] Arguments { get; }
        public string LogMessage { get; }
        public string TargetOriginalName { get; }
    }
}
