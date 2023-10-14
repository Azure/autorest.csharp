// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace AutoRest.CSharp.Mgmt.Report
{
    internal class MgmtReport
    {
        public static MgmtReport Instance { get; private set; } = new MgmtReport();

        public MgmtReport()
        {
            this._sections.Add(this.ObjectModelSection.Name, this.ObjectModelSection);
            this._sections.Add(this.EnumModelSection.Name, this.EnumModelSection);
            this._sections.Add(this.ResourceSection.Name, this.ResourceSection);
            this._sections.Add(this.TransformSection.Name, this.TransformSection);
        }

        private Dictionary<string, ReportSection> _sections = new Dictionary<string, ReportSection>();

        public DictionaryReportSection<ObjectModelItem> ObjectModelSection { get; } = new DictionaryReportSection<ObjectModelItem>("ObjectModels");
        public DictionaryReportSection<EnumModelItem> EnumModelSection { get; } = new DictionaryReportSection<EnumModelItem>("EnumModels");
        public DictionaryReportSection<ResourceItem> ResourceSection { get; } = new DictionaryReportSection<ResourceItem>("Resources");
        public TransformSection TransformSection { get; } = new TransformSection("Transforms");

        public string GenerateReport(string format)
        {
            var reportObj = this._sections.ToDictionary(kv => kv.Key, kv => kv.Value.GenerateSection());
            reportObj.Add("_help_message_", new Dictionary<string, object?>()
            {
                { "1", "If the transform configuration has a '!' postfix (i.e. 'ProxyResource!'), it means the config is not from *.md config file (i.e. it's built-in through hard code)" },
                { "2", "[{num}] in transform log is the index the transform is applied" },
                { "3", "[=] in transform log means the value (target FullSerializedName) is the same as the key (transform configuration)" }
            });

            switch (format.ToLower())
            {
                case "json":
                    return JsonSerializer.Serialize(reportObj, new JsonSerializerOptions()
                    {
                        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        WriteIndented = true,
                    });
                case "yaml":
                case "":
                    var serializer = new SerializerBuilder()
                     .WithNamingConvention(CamelCaseNamingConvention.Instance)
                     .Build();
                    return serializer.Serialize(reportObj);
                default:
                    throw new ArgumentException($"Unknown Report Format '{format}'. Only 'json' and 'yaml' is supported now");
            }
        }

        public void Reset()
        {
            foreach (var item in _sections)
            {
                item.Value.Reset();
            }
        }
    }
}
