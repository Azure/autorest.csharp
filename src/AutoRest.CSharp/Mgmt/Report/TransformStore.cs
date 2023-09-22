// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using AutoRest.CSharp.Common.Utilities;
using YamlDotNet.Serialization;

namespace AutoRest.CSharp.Mgmt.Report
{
    internal class TransformStore
    {
        private class TransformerItemDetail
        {
            public int Usage { get; set; } = 0;
        }

        public static TransformStore Instance { get; set; } = new TransformStore();

        private Dictionary<TransformItem, TransformerItemDetail> _items = new Dictionary<TransformItem, TransformerItemDetail>();
        private List<TransformLog> _transformLogs = new List<TransformLog>();

        public ReadOnlyCollection<TransformLog> TransformLogs => this._transformLogs.AsReadOnly();

        public TransformStore()
        {
        }

        public void AddTransformer(TransformItem item)
        {
            this._items.Add(item, new TransformerItemDetail());
        }

        public void AddTransformer(string type, string key, params string[] arguments)
        {
            var item = new TransformItem(type, key, arguments);
            this.AddTransformer(item);
        }

        public void AddTransformers(IEnumerable<TransformItem> items)
        {
            foreach (var item in items)
                this.AddTransformer(item);
        }

        public void AddTransformersInDictoinary(string type, IReadOnlyDictionary<string, string> dict)
        {
            foreach (var item in dict)
            {
                this.AddTransformer(type, item.Key, item.Value);
            }
        }

        public void AddTransformersInArray(string type, IEnumerable<string> arr)
        {
            foreach (var item in arr)
            {
                this.AddTransformer(type, item);
            }
        }

        public void IncreaseUsage(TransformItem item)
        {
            if (_items.TryGetValue(item, out TransformerItemDetail? detail))
            {
                detail!.Usage++;
            }
            else
            {
                AutoRestLogger.Warning($"TransfomerItem {item} found without config (i.e. built-in)").Wait();
                this.AddTransformer(item);
                this.IncreaseUsage(item);
            }
        }

        public void AddTransformLog(TransformItem item, string targetFullSerializedName, string logMessage)
        {
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

        private string CreateChangeMessage(string changeName, string? from, string? to) => $"{changeName}: '{from ?? "<null>"}' --> '{to ?? "<null>"}'";

        public string ToYaml()
        {
            var ser = new SerializerBuilder().Build();
            var yaml = ser.Serialize(this);
            return yaml ;
        }
    }

}
