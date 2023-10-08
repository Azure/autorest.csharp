// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public string GenerateReport()
        {
            StringBuilder sb = new StringBuilder();

            var serializer = new SerializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();
            var yaml = serializer.Serialize(this._sections.ToDictionary(kv => kv.Key, kv => kv.Value.GenerateSection()));
            sb.AppendLine(yaml);
            return sb.ToString();
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
