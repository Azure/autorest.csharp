// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.Mgmt.Report
{
    internal class TransformLog
    {
        public TransformLog(TransformItem item, string targetFullSerializedName, string logMessage)
        {
            Transformer = item;
            LogMessage = logMessage;
            TargetFullSerializedName = targetFullSerializedName;
        }

        public TransformItem Transformer { get; }
        public string LogMessage { get; }
        public string TargetFullSerializedName { get; }

        public override string ToString()
        {
            return $"{Transformer}+{TargetFullSerializedName}=>{LogMessage}";
        }
    }
}
