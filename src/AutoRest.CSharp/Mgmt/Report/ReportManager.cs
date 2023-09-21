using System.Collections.Generic;

namespace AutoRest.CSharp.Mgmt.Report
{
    internal class ReportManager
    {
        public static ReportManager Instance { get; private set; } = new ReportManager();

        private List<TransformLog> TransformLogs { get; } = new List<TransformLog>();

        public void AddTransformLog(string transformType, string key, string[] arguments, string targetFullSerializedName, string logMessage)
        {
            this.TransformLogs.Add(new TransformLog(transformType, key, arguments, targetFullSerializedName, logMessage));
        }

        public void AddTransformLog(string transformType, string key, string argument, string targetFullSerializedName, string logMessage)
        {
            this.TransformLogs.Add(new TransformLog(transformType, key, new string[] { argument }, targetFullSerializedName, logMessage));
        }

        public void AddTransformLogForApplyChange(string transformType, string key, string argument, string targetFullSerializedName, string changeName, string? from, string? to)
        {
            this.AddTransformLog(transformType, key, argument, targetFullSerializedName, CreateChangeMessage(changeName, from, to));
        }

        private string CreateChangeMessage(string changeName, string? from, string? to) => $"{changeName}: '{from ?? "<null>"}' --> '{to ?? "<null>"}'";
    }
}
