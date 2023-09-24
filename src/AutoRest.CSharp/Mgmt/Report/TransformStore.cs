// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Common.Utilities;

namespace AutoRest.CSharp.Mgmt.Report
{
    internal class TransformStore
    {
        private class TransformerItemDetail
        {
            public int Usage { get; set; } = 0;
        }

        public static TransformStore Instance { get; set; } = new TransformStore();

        private Dictionary<TransformItem, TransformerItemDetail> _transformItems = new Dictionary<TransformItem, TransformerItemDetail>();

        private List<TransformLog> _transformLogs = new List<TransformLog>();
        public ReadOnlyCollection<TransformLog> TransformLogs => this._transformLogs.AsReadOnly();

        public TransformStore()
        {
        }

        public void AddTransformer(TransformItem item)
        {
            this._transformItems.Add(item, new TransformerItemDetail());
        }

        public void AddTransformer(string type, string key, bool fromConfig, params string[] arguments)
        {
            var item = new TransformItem(type, key, fromConfig, arguments);
            this.AddTransformer(item);
        }

        public void AddTransformers(IEnumerable<TransformItem> items)
        {
            foreach (var item in items)
                this.AddTransformer(item);
        }

        public void IncreaseUsage(TransformItem item)
        {
            if (_transformItems.TryGetValue(item, out TransformerItemDetail? detail))
            {
                detail!.Usage++;
            }
            else
            {
                AutoRestLogger.Warning($"New TransfomerItem {item} found (i.e. built-in)").Wait();
                this.AddTransformer(item);
                this.IncreaseUsage(item);
            }
        }

        private void UpdateTransformItemFromStore(TransformItem item)
        {
            var found = _transformItems.Keys.FirstOrDefault(k => k == item);
            if (found != null)
            {
                item.IsFromConfig = found.IsFromConfig;
            }
        }

        public void AddTransformLog(TransformItem item, string targetFullSerializedName, string logMessage)
        {
            this.UpdateTransformItemFromStore(item);
            this._transformLogs.Add(new TransformLog(item, targetFullSerializedName, logMessage));
            this.IncreaseUsage(item);
        }

        public void AddTransformLogForApplyChange(TransformItem item, string targetFullSerializedName, string changeName, string? from, string? to)
        {
            this.AddTransformLog(item, targetFullSerializedName, CreateChangeMessage(changeName, from, to));
        }

        public void AddTransformLogForApplyChange(string transformType, string key, string argument, string targetFullSerializedName, string changeName, string? from, string? to)
        {
            this.AddTransformLog(new TransformItem(transformType, key, argument), targetFullSerializedName, CreateChangeMessage(changeName, from, to));
        }

        private string CreateChangeMessage(string changeName, string? from, string? to) => $"{changeName} '{from ?? "<null>"}' --> '{to ?? "<null>"}'";

        public string LogsToCsv(bool includeHeader = true)
        {
            StringBuilder sb = new StringBuilder();
            if (includeHeader)
                sb.AppendLine("index,transformType,transformKey,transformArguments, isFromConfig, transformTarget,transformLog");
            int i = 0;
            foreach (var item in TransformLogs)
            {
                sb.AppendLine($"{i},{item.Transformer.TransformType},{item.Transformer.Key},{item.Transformer.ArgumentsAsString},{item.Transformer.IsFromConfig},{item.TargetFullSerializedName},{item.LogMessage}");
                i++;
            }
            return sb.ToString();
        }

        public string UsagesToCsv(bool includeHeader = true)
        {
            StringBuilder sb = new StringBuilder();
            if (includeHeader)
                sb.AppendLine("index,transformType,transformKey,transformArguments, isFromConfig, usage");
            int i = 0;
            foreach (var (item, detail) in this._transformItems)
            {
                sb.AppendLine($"{i},{item.TransformType},{item.Key},{item.ArgumentsAsString},{item.IsFromConfig},{detail.Usage}");
                i++;
            }
            return sb.ToString();
        }

    }

}
