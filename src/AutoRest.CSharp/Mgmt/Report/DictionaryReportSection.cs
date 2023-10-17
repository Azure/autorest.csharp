// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace AutoRest.CSharp.Mgmt.Report
{
    internal class DictionaryReportSection<T> : ReportSection
    {
        public Dictionary<string, T> _dict = new Dictionary<string, T>();

        public DictionaryReportSection(string name)
            : base(name)
        {
        }

        public DictionaryReportSection(string name, Dictionary<string, T> dict)
            : base(name)
        {
            this._dict = new Dictionary<string, T>(dict);
        }

        public override Dictionary<string, object?> GenerateSection()
        {
            return this._dict.ToDictionary(kv => kv.Key, kv => (object?)kv.Value);
        }

        public override void Reset()
        {
            this._dict = new Dictionary<string, T>();
        }

        public void Add(string key, T item)
        {
            this._dict[key] = item;
        }
    }
}
